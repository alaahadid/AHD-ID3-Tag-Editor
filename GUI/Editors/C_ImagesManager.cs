/* This file is part of AHD ID3 Tag Editor (AITE)
 * A program that edit and create ID3 Tag.
 *
 * Copyright © Alaa Ibrahim Hadid 2012 - 2021
 *
 * This program is free software: you can redistribute it and/or modify
 * it under the terms of the GNU General Public License as published by
 * the Free Software Foundation, either version 3 of the License, or
 * (at your option) any later version.
 *
 * This program is distributed in the hope that it will be useful,
 * but WITHOUT ANY WARRANTY; without even the implied warranty of
 * MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
 * GNU General Public License for more details.
 *
 * You should have received a copy of the GNU General Public License
 * along with this program.  If not, see <http://www.gnu.org/licenses/>.
 */
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using MLV;
using AHD.ID3;
using AHD.ID3.Types;
using AHD.ID3.Frames;
using AHD.ID3.Editor.Base;
using AHD.ID3.MIME;
namespace AHD.ID3.Editor.GUI
{
    public partial class C_ImagesManager : EditorControl
    {
        public C_ImagesManager()
        {
            InitializeComponent();

            foreach (string typ in ID3FrameConsts.PictureTypes)
                comboBox1.Items.Add(typ);
            comboBox1.SelectedIndex = 0;
            DisableControls();
        }
        private bool isItemsDrag = false;
        public override string[] SelectedFiles
        {
            get
            {
                return base.SelectedFiles;
            }
            set
            {
                base.SelectedFiles = value;
                ReloadImages();
            }
        }
        public override void DisableSaving()
        {
            base.DisableSaving();
            toolStripButton1.Enabled = false;
        }
        private bool IsImageExist(AttachedPictureFrame frame)
        {
            foreach (ManagedListViewItem item in managedListView1.Items)
            {
                AttachedPictureFrame itemFrame = (AttachedPictureFrame)item.Tag;
                if (frame.Equals(itemFrame))
                {
                    return true;
                }
            }
            return false;
        }
        public void ClearImages()
        {
            managedListView1.Items.Clear();
            panel1.Visible = false;
            managedListView1.Invalidate();
            label_info.Text = "";
            Label1.Text = "";
        }
        public void DisableControls()
        {
            toolStrip1.Enabled = trackBar1.Enabled = managedListView1.Enabled = false;
            panel1.Visible = false;
        }
        public void EnableControls()
        {
            toolStrip1.Enabled = trackBar1.Enabled = managedListView1.Enabled = true;
        }
        public void ReloadImages()
        {
            ClearImages();
            if (files == null)
            { DisableControls(); return; }
            if (files.Length == 0)
            { DisableControls(); return; }
            EnableControls();
            Label1.Text = "Edit " + files.Length + " file(s)";
            for (int i = 0; i < files.Length; i++)
            {
                // load id3 v2
                ID3v2 v2 = new ID3v2();
                if (v2.Load(files[i]) == Result.Success)
                {
                    // load frames
                    foreach (ID3TagFrame frame in v2.Frames)
                    {
                        if (frame is AttachedPictureFrame)
                        {
                            if (!IsImageExist((AttachedPictureFrame)frame))
                            {
                                ManagedListViewItem item = new ManagedListViewItem();
                                item.DrawMode = ManagedListViewItemDrawMode.UserDraw;
                                item.Tag = frame;
                                managedListView1.Items.Add(item);
                            }
                        }
                    }
                }
            }
            managedListView1.Invalidate();
        }
        public void SaveChanges(object sender, EventArgs e)
        {
            if (files == null)
            {
                MessageBox.Show("No file selected !!");
                return;
            }
            if (files.Length == 0)
            {
                MessageBox.Show("No file selected !!");
                return;
            }
            OnProgressStart();
            // stop media and clear it
            OnClearMediaRequest();
            for (int i = 0; i < files.Length; i++)
            {
                // load the original file. Success or not doesn't matter.
                ID3v2 v2 = new ID3v2();
                bool hadTag = v2.Load(files[i]) == Result.Success;
                // we need to make sure about version. If we are creating id3v2, use default version.
                if (!hadTag)
                    v2.TagVersion = new ID3Version((byte)ID3TagSettings.ID3V2Version, 0);
                // remove any attached picture frame from the file
                for (int j = 0; j < v2.Frames.Count; j++)
                {
                    if (v2.Frames[j] is AttachedPictureFrame)
                    {
                        v2.Frames.RemoveAt(j);
                        j--;
                    }
                }

                // add the frames of this manager
                foreach (ManagedListViewItem item in managedListView1.Items)
                {
                    AttachedPictureFrame itemFrame = (AttachedPictureFrame)item.Tag;
                    if (v2.TagVersion.Major == 2)
                        itemFrame.ID = "PIC";
                    else
                        itemFrame.ID = "APIC";
                    v2.Frames.Add(itemFrame);
                }

                // save it !!
                // set flags
                v2.Compression = false;
                v2.Experimental = false;
                if (ID3TagSettings.DropExtendedHeader)
                    v2.ExtendedHeader = false;
                v2.Footer = ID3TagSettings.WriteFooter;
                v2.SavePadding = ID3TagSettings.KeepPadding;
                v2.Unsynchronisation = ID3TagSettings.UseUnsynchronisation;

                v2.Save(files[i]);

                int x = ((i + 1) * 100) / files.Length;
                OnProgress("Saving .. " + x + "%", x);
            }
            OnProgress("Changes saved successfuly.", 100);
            OnProgressFinish();

            OnUpdateRequired();

            // reload media
            OnReloadMediaRequest();
        }
        private void AddImage(object sender, EventArgs e)
        {
            OpenFileDialog op = new OpenFileDialog();
            op.Filter = "Supported image types (*.jpg;*.png;*.bmp;*.gif;*.jpeg;*.tiff;*.tga)|*.jpg;*.png;*.bmp;*.gif;*.jpeg;*.tif;*.tiff;*.tga";
            if (op.ShowDialog(this) == DialogResult.OK)
            {
                AttachedPictureFrame frame = new AttachedPictureFrame("APIC", "Attached picture frame", null, 0);//id doesn't matter now..
                frame.Description = "";
                frame.PictureType = "Other";
                frame.MIME = MIME.MimeManager.GetMime(Path.GetExtension(op.FileName));
                Stream stream = new FileStream(op.FileName, FileMode.Open, FileAccess.Read);
                byte[] buffer = new byte[stream.Length];
                stream.Read(buffer, 0, buffer.Length);
                stream.Dispose();
                stream.Close();

                frame.PictureData = buffer;

                if (!IsImageExist(frame))
                {
                    ManagedListViewItem item = new ManagedListViewItem();
                    item.DrawMode = ManagedListViewItemDrawMode.UserDraw;
                    item.Tag = frame;
                    managedListView1.Items.Add(item);
                }
                else
                {
                    MessageBox.Show("This image is already exist !");
                }
                managedListView1.Invalidate();
            }
        }
        private void RemoveSelected(object sender, EventArgs e)
        {
            for (int i = 0; i < managedListView1.Items.Count; i++)
            {
                if (managedListView1.Items[i].Selected)
                {
                    managedListView1.Items.Remove(managedListView1.Items[i]);
                    i--;
                }
            }
            managedListView1.Invalidate();
        }
        public bool ShowToolStrip
        {
            get { return toolStrip1.Visible; }
            set { toolStrip1.Visible = value; }
        }
        public void DeleteSelected()
        { RemoveSelected(this, null); }

        private void managedListView1_DrawItem(object sender, ManagedListViewItemDrawArgs e)
        {
            AttachedPictureFrame frame = (AttachedPictureFrame)managedListView1.Items[e.ItemIndex].Tag;

            e.TextToDraw = frame.Description + " (" + frame.PictureType + ")";
            try
            {
                System.IO.Stream stream = new System.IO.MemoryStream(frame.PictureData);
                e.ImageToDraw = new Bitmap(stream);
            }
            catch { }
        }
        private void managedListView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (managedListView1.SelectedItems.Count == 1)
            {
                panel1.Visible = true;
                AttachedPictureFrame frame = (AttachedPictureFrame)managedListView1.SelectedItems[0].Tag;
                textBox1.Text = frame.Description;
                comboBox1.SelectedItem = frame.PictureType;

                label_info.Text = "Type: " + frame.MIME;
                try
                {
                    System.IO.Stream stream = new System.IO.MemoryStream(frame.PictureData);
                    Bitmap img = new Bitmap(stream);
                    label_info.Text += ", Size: " + img.Width + " x " + img.Width;
                }
                catch { }
            }
            else
            {
                label_info.Text = "";
                panel1.Visible = false;
            }
        }
        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            managedListView1.ThunmbnailsHeight = managedListView1.ThunmbnailsWidth = trackBar1.Value;
            managedListView1.Invalidate();
        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (panel1.Visible)
            {
                if (managedListView1.SelectedItems.Count == 1)
                {
                    AttachedPictureFrame frame = (AttachedPictureFrame)managedListView1.SelectedItems[0].Tag;
                    frame.Description = textBox1.Text;
                    managedListView1.Invalidate();
                }
            }
        }
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (panel1.Visible)
            {
                if (managedListView1.SelectedItems.Count == 1)
                {
                    AttachedPictureFrame frame = (AttachedPictureFrame)managedListView1.SelectedItems[0].Tag;
                    frame.PictureType = comboBox1.SelectedItem.ToString();
                    managedListView1.Invalidate();
                }
            }
        }
        // reload
        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            ReloadImages();
        }

        public override void SaveTag(ID3v2 v2)
        {
            // stop media and clear it
            ClearMedia();
            OnClearMediaRequest();
            // remove any attached picture frame from the file
            for (int j = 0; j < v2.Frames.Count; j++)
            {
                if (v2.Frames[j] is AttachedPictureFrame)
                {
                    v2.Frames.RemoveAt(j);
                    j--;
                }
            }

            // add the frames of this manager
            foreach (ManagedListViewItem item in managedListView1.Items)
            {
                AttachedPictureFrame itemFrame = (AttachedPictureFrame)item.Tag;
                if (v2.TagVersion.Major == 2)
                    itemFrame.ID = "PIC";
                else
                    itemFrame.ID = "APIC";
                v2.Frames.Add(itemFrame);
            }
        }
        public override void LoadTag(ID3v2 v2)
        {
            EnableControls();
            Label1.Text = "";

            // load frames
            foreach (ID3TagFrame frame in v2.Frames)
            {
                if (frame is AttachedPictureFrame)
                {
                    if (!IsImageExist((AttachedPictureFrame)frame))
                    {
                        ManagedListViewItem item = new ManagedListViewItem();
                        item.DrawMode = ManagedListViewItemDrawMode.UserDraw;
                        item.Tag = frame;
                        managedListView1.Items.Add(item);
                    }
                }
            }
            managedListView1.Invalidate();
        }
        public override void ClearFields()
        {
            ClearImages();
        }

        private void managedListView1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Delete)
                RemoveSelected(this, null);
        }

        private void ExportSelectedImage(object sender, EventArgs e)
        {
            if (managedListView1.SelectedItems.Count == 1)
            {
                AttachedPictureFrame frame = (AttachedPictureFrame)managedListView1.SelectedItems[0].Tag;
                SaveFileDialog sav = new SaveFileDialog();
                sav.Filter = MIME.MimeManager.GetExtensionsFilter(frame.MIME);
                if (sav.ShowDialog(this) == DialogResult.OK)
                {
                    try
                    {
                        System.IO.Stream stream = new System.IO.MemoryStream(frame.PictureData);
                        Bitmap img = new Bitmap(stream);
                        img.Save(sav.FileName);
                        MessageBox.Show("Done !");
                    }
                    catch (Exception ex)
                    { MessageBox.Show("Error:\n" + ex.Message); }
                }
            }
        }

        private void ChangeSelectedImage(object sender, EventArgs e)
        {
            if (managedListView1.SelectedItems.Count == 1)
            {
                OpenFileDialog op = new OpenFileDialog();
                op.Filter = "Supported image types (*.jpg;*.png;*.bmp;*.gif;*.jpeg;*.tiff;*.tga)|*.jpg;*.png;*.bmp;*.gif;*.jpeg;*.tif;*.tiff;*.tga";
                if (op.ShowDialog(this) == DialogResult.OK)
                {
                    AttachedPictureFrame frame = (AttachedPictureFrame)managedListView1.SelectedItems[0].Tag;

                    frame.MIME = MIME.MimeManager.GetMime(Path.GetExtension(op.FileName));
                    Stream stream = new FileStream(op.FileName, FileMode.Open, FileAccess.Read);
                    byte[] buffer = new byte[stream.Length];
                    stream.Read(buffer, 0, buffer.Length);
                    stream.Dispose();
                    stream.Close();

                    frame.PictureData = buffer;

                    managedListView1.Invalidate();
                }
            }
        }

        private void managedListView1_DragDrop(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                List<string> files = new List<string>((string[])e.Data.GetData(DataFormats.FileDrop));
                List<string> addFiles = new List<string>();
                for (int i = 0; i < files.Count; i++)
                {
                    if (Directory.Exists(files[i]))
                    {
                        addFiles.AddRange(Directory.GetFiles(files[i], "*", SearchOption.AllDirectories));
                    }
                }
                files.AddRange(addFiles);

                foreach (string file in files)
                {
                    AttachedPictureFrame frame = new AttachedPictureFrame("APIC", "Attached picture frame", null, 0);//id doesn't matter now..
                    frame.Description = "";
                    frame.PictureType = "Other";
                    frame.MIME = MIME.MimeManager.GetMime(Path.GetExtension(file));
                    Stream stream = new FileStream(file, FileMode.Open, FileAccess.Read);
                    byte[] buffer = new byte[stream.Length];
                    stream.Read(buffer, 0, buffer.Length);
                    stream.Dispose();
                    stream.Close();

                    frame.PictureData = buffer;

                    if (!IsImageExist(frame))
                    {
                        ManagedListViewItem item = new ManagedListViewItem();
                        item.DrawMode = ManagedListViewItemDrawMode.UserDraw;
                        item.Tag = frame;
                        managedListView1.Items.Add(item);
                    }
                    managedListView1.Invalidate();
                }
            }
        }

        private void managedListView1_DragEnter(object sender, DragEventArgs e)
        {
            if (isItemsDrag)
            {
                e.Effect = DragDropEffects.None;
                return;
            }
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                e.Effect = DragDropEffects.Copy;
            }
            else
            {
                e.Effect = DragDropEffects.None;
            }
        }

        private void managedListView1_DragOver(object sender, DragEventArgs e)
        {
            if (isItemsDrag)
            {
                e.Effect = DragDropEffects.None;
                return;
            }
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                e.Effect = DragDropEffects.Copy;
            }
            else
            {
                e.Effect = DragDropEffects.None;
            }
        }

        private void managedListView1_ItemsDrag(object sender, EventArgs e)
        {
            if (managedListView1.SelectedItems.Count == 0)
                return;
            // create files for drag operation
            List<string> files = new List<string>();
            Directory.CreateDirectory(Path.GetTempPath() + "\\AITE\\");
            foreach (ManagedListViewItem item in managedListView1.SelectedItems)
            {
                int i = 1;
                string fileName = Path.GetTempPath() + "\\AITE\\Image_" + i + ".bmp";
                while (File.Exists(fileName))
                {
                    i++;
                    fileName = Path.GetTempPath() + "\\AITE\\Image_" + i + ".bmp";
                }
                // save the image
                AttachedPictureFrame frame = (AttachedPictureFrame)managedListView1.SelectedItems[0].Tag;
                try
                {
                    System.IO.Stream stream = new System.IO.MemoryStream(frame.PictureData);
                    Bitmap img = new Bitmap(stream);
                    img.Save(fileName);
                    files.Add(fileName);
                }
                catch
                {
                }
            }
            isItemsDrag = true;
            DoDragDrop(new DataObject(DataFormats.FileDrop, files.ToArray()), DragDropEffects.Move);
            isItemsDrag = false;
            foreach (string file in files)
            {
                try
                {
                    File.Delete(file);
                }
                catch { }
            }
        }
    }
}
