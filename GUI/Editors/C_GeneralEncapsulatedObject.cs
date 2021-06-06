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
using System.Runtime.InteropServices;
using System.IO;
using AHD.ID3;
using AHD.ID3.Types;
using AHD.ID3.Frames;
using AHD.ID3.Editor.Base;
using AHD.ID3.MIME;
namespace AHD.ID3.Editor.GUI
{
    public partial class C_GeneralEncapsulatedObject : EditorControl
    {
        public C_GeneralEncapsulatedObject()
        {
            InitializeComponent();
            DisableControls();
            textEditorControl_contentDescriptor.textBox1.TextChanged += textEditorControl_contentDescriptor_TextChanged;
            textEditorControl_contentDescriptor.textBox1.Validated += textEditorControl_contentDescriptor_Validated;

            textEditorControl_fileName.textBox1.TextChanged += textEditorControl_fileName_TextChanged;
            textEditorControl_fileName.textBox1.Validated += textEditorControl_fileName_Validated;
        }

        private void DisableControls()
        {
            toolStrip1.Enabled = textEditorControl_contentDescriptor.Enabled = textEditorControl_fileName.Enabled =
            label_fileInfo.Enabled = false;
            Label1.Text = "";
        }
        private void EnableControls()
        {
            toolStrip1.Enabled = textEditorControl_contentDescriptor.Enabled = textEditorControl_fileName.Enabled =
              label_fileInfo.Enabled = true;
            Label1.Text = "";
        }
        public override void DisableSaving()
        {
            base.DisableSaving();
            toolStripButton1.Enabled = false;
        }
        public override string[] SelectedFiles
        {
            get
            {
                return base.SelectedFiles;
            }
            set
            {
                base.SelectedFiles = value; ReloadFrames(null, null);
            }
        }
        public override void ClearFields()
        {
            ComboBox_frames.Items.Clear();

            textEditorControl_contentDescriptor.PropertyValue = "";
            textEditorControl_fileName.PropertyValue = "";
            label_fileInfo.Text = "No file slected.";
            label_icon.Image = Properties.Resources.File_unkown;
        }

        private void ReloadFrames(object sender, EventArgs e)
        {
            ClearFields();
            if (files == null)
            {
                DisableControls();
                return;
            }
            if (files.Length == 0)
            {
                DisableControls();
                return;
            }
            if (files.Length > 1)
            {
                DisableControls();
                Label1.Text = "You can only edit 1 file at a time.";
                return;
            }
            //load frames
            LoadFrames(files[0]);
        }
        /// <summary>
        /// Fill fields from file
        /// </summary>
        /// <param name="file">The file to load</param>
        public void LoadFrames(string file)
        {
            ID3v2 v2 = new ID3v2();
            if (v2.Load(file) == Result.Success)
            {
                LoadFrames(v2);
            }
        }
        /// <summary>
        /// Fill fields using ID3V2 object.
        /// </summary>
        /// <param name="v2">The ID3V2 object (MUST be loaded a file with load success status)</param>
        public void LoadFrames(ID3v2 v2)
        {
            EnableControls();
            foreach (ID3TagFrame frame in v2.Frames)
            {
                if (frame is GeneralEncapsulatedObjectFrame)
                {
                    ComboBox_frames.Items.Add(frame);
                }
            }
            if (ComboBox_frames.Items.Count > 0)
                ComboBox_frames.SelectedIndex = 0;
            else
            {
                textEditorControl_contentDescriptor.Enabled = textEditorControl_fileName.Enabled =
       label_fileInfo.Enabled = false;
                textEditorControl_contentDescriptor.PropertyValue = "";
                textEditorControl_fileName.PropertyValue = "";
                label_fileInfo.Text = "No file slected.";
                label_icon.Image = Properties.Resources.File_unkown;
            }
        }
        public void SaveFramesToTag(ID3v2 v2)
        {

            // remove all comment frames
            v2.RemoveFrameAll("GEO");
            v2.RemoveFrameAll("GEOB");
            // add frames we have
            foreach (GeneralEncapsulatedObjectFrame frame in ComboBox_frames.Items)
            {
                if (v2.TagVersion.Major == 2)
                    frame.ID = "GEO";
                else
                    frame.ID = "GEOB";
                v2.Frames.Add(frame);
            }
        }
        public override void LoadTag(ID3v2 v2)
        {
            LoadFrames(v2);
        }
        public override void SaveTag(ID3v2 v2)
        {
            SaveFramesToTag(v2);
        }
        private void SaveChanges(object sender, EventArgs e)
        {
            if (files == null)
            {
                MessageBox.Show("No file selected.");
                return;
            }
            if (files.Length == 0)
            {
                MessageBox.Show("No file selected.");
                return;
            }
            if (files.Length > 1)
            {
                MessageBox.Show("Only one file can be saved at a time");
                return;
            }
            // stop media and clear it
            OnClearMediaRequest();
            // load the original file. Success or not doesn't matter.
            ID3v2 v2 = new ID3v2();
            bool hadTag = v2.Load(files[0]) == Result.Success;

            // we need to make sure about version. If we are creating id3v2, use default version.
            if (!hadTag)
                v2.TagVersion = new ID3Version((byte)ID3TagSettings.ID3V2Version, 0);

            // set flags
            v2.Compression = false;
            v2.Experimental = false;
            if (ID3TagSettings.DropExtendedHeader)
                v2.ExtendedHeader = false;
            v2.Footer = ID3TagSettings.WriteFooter;
            v2.SavePadding = ID3TagSettings.KeepPadding;
            v2.Unsynchronisation = ID3TagSettings.UseUnsynchronisation;
            //save frames
            SaveFramesToTag(v2);

            // Add events
            v2.SaveStart += v2_SaveStart;
            v2.SaveFinished += v2_SaveFinished;
            v2.Progress += v2_Progress;
            // save !
            v2.Save(files[0]);

            OnUpdateRequired();

            // reload media
            OnReloadMediaRequest();
        }
        private void RefreshSelectedItem()
        {
            if (ComboBox_frames.SelectedIndex >= 0)
            {
                GeneralEncapsulatedObjectFrame frame = (GeneralEncapsulatedObjectFrame)ComboBox_frames.SelectedItem;
                int index = ComboBox_frames.SelectedIndex;
                ComboBox_frames.Items.RemoveAt(index);
                ComboBox_frames.Items.Insert(index, frame);
                ComboBox_frames.SelectedIndex = index;
            }
        }
        private void AddFrame(object sender, EventArgs e)
        {
            OpenFileDialog op = new OpenFileDialog();
            op.Filter = "All files (*.*)|*.*";
            op.Title = "Add general encapsulated object frame file";
            if (op.ShowDialog(this) == DialogResult.OK)
            {
                FileInfo inf = new FileInfo(op.FileName);
                int size = (int)inf.Length;
                if (inf.Length > 0xFF00000)// 255 mb allowed
                {
                    MessageBox.Show("This file is too large (more than 255 MB).");
                    return;
                }
                else if (inf.Length == 0)
                {
                    MessageBox.Show("This file is empty !!");
                    return;
                }
                GeneralEncapsulatedObjectFrame frame = new GeneralEncapsulatedObjectFrame("GEOB", "General encapsulated object", null, 0);// id doesn't matter now..
                // load data
                Stream str = new FileStream(op.FileName, FileMode.Open, FileAccess.Read);
                frame.FileData = new byte[size];
                str.Read(frame.FileData, 0, size);
                str.Close();
                str.Dispose();
                // fields
                frame.FileName = Path.GetFileName(op.FileName);
                frame.MIME = MimeManager.GetMime(Path.GetExtension(op.FileName));
                ComboBox_frames.Items.Add(frame);
                ComboBox_frames.SelectedItem = frame;
            }
        }
        private void RemoveFrame(object sender, EventArgs e)
        {
            if (ComboBox_frames.SelectedIndex >= 0)
            {
                ComboBox_frames.Items.RemoveAt(ComboBox_frames.SelectedIndex);
            }
        }
        private void v2_Progress(object sender, ProgressArg e)
        {
            OnProgress(e.Status, e.Progress);
        }
        private void v2_SaveFinished(object sender, EventArgs e)
        {
            OnProgress("Saved.", 100);
            OnProgressFinish();
        }
        private void v2_SaveStart(object sender, EventArgs e)
        {
            OnProgressStart();
        }
        private void ComboBox_frames_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ComboBox_frames.SelectedIndex >= 0)
            {
                textEditorControl_contentDescriptor.Enabled = textEditorControl_fileName.Enabled =
label_fileInfo.Enabled = true;

                GeneralEncapsulatedObjectFrame frame = (GeneralEncapsulatedObjectFrame)ComboBox_frames.SelectedItem;
                textEditorControl_contentDescriptor.PropertyValue = frame.Description;
                textEditorControl_fileName.PropertyValue = frame.FileName;

                label_fileInfo.Text = "Size = " + Helper.GetSize(frame.FileData.Length) + "\nMIME: " + frame.MIME;
                try { label_icon.Image = GetIconFromExtension(Path.GetExtension(frame.FileName)).ToBitmap(); }
                catch { label_icon.Image = Properties.Resources.File_unkown; }
            }
            else
            {
                textEditorControl_contentDescriptor.Enabled = textEditorControl_fileName.Enabled =
label_fileInfo.Enabled = false;
                textEditorControl_contentDescriptor.PropertyValue = "";
                textEditorControl_fileName.PropertyValue = "";
                label_fileInfo.Text = "No file slected.";
                label_icon.Image = Properties.Resources.File_unkown;
            }
        }
        private void textEditorControl_contentDescriptor_TextChanged(object sender, EventArgs e)
        {
            if (ComboBox_frames.SelectedIndex >= 0)
            {
                GeneralEncapsulatedObjectFrame frame = (GeneralEncapsulatedObjectFrame)ComboBox_frames.SelectedItem;
                frame.Description = textEditorControl_contentDescriptor.PropertyValue;
            }
        }
        private void textEditorControl_contentDescriptor_Validated(object sender, EventArgs e)
        {
            RefreshSelectedItem();
        }
        private void textEditorControl_fileName_TextChanged(object sender, EventArgs e)
        {
            if (ComboBox_frames.SelectedIndex >= 0)
            {
                GeneralEncapsulatedObjectFrame frame = (GeneralEncapsulatedObjectFrame)ComboBox_frames.SelectedItem;
                frame.FileName = textEditorControl_fileName.PropertyValue;
            }
        }
        private void textEditorControl_fileName_Validated(object sender, EventArgs e)
        {
            RefreshSelectedItem();
        }
        private static Icon GetIconFromExtension(string Extension)
        {
            SHFILEINFO shinfo = new SHFILEINFO();
            IntPtr hImgSmall = SHGetFileInfo(Extension, 0, ref shinfo, (uint)Marshal.SizeOf(shinfo), 0x100 | 16);
            return System.Drawing.Icon.FromHandle(shinfo.hIcon);
        }

        [DllImport("shell32.dll")]
        private static extern IntPtr SHGetFileInfo(string pszPath,
            uint dwFileAttributes, ref SHFILEINFO psfi, uint cbSizeFileInfo,
            uint uFlags);

        [StructLayout(LayoutKind.Sequential)]
        struct SHFILEINFO
        {
            public IntPtr hIcon;
            public int iIcon;
            public uint dwAttributes;
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 260)]
            public string szDisplayName;
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 80)]
            public string szTypeName;
        }

        private void C_GeneralEncapsulatedObject_DragDrop(object sender, DragEventArgs e)
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
                    FileInfo inf = new FileInfo(file);
                    int size = (int)inf.Length;
                    if (inf.Length > 0xFF00000)// 255 mb allowed
                    {
                        MessageBox.Show(file + "\nThis file is too large (more than 255 MB).");
                        return;
                    }
                    else if (inf.Length == 0)
                    {
                        MessageBox.Show(file + "\nThis file is empty !!");
                        return;
                    }
                    GeneralEncapsulatedObjectFrame frame = new GeneralEncapsulatedObjectFrame("GEOB", "General encapsulated object", null, 0);// id doesn't matter now..
                    // load data
                    Stream str = new FileStream(file, FileMode.Open, FileAccess.Read);
                    frame.FileData = new byte[size];
                    str.Read(frame.FileData, 0, size);
                    str.Close();
                    str.Dispose();
                    // fields
                    frame.FileName = Path.GetFileName(file);
                    frame.MIME = MimeManager.GetMime(Path.GetExtension(file));
                    ComboBox_frames.Items.Add(frame);
                    ComboBox_frames.SelectedItem = frame;
                }
            }
        }

        private void C_GeneralEncapsulatedObject_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                e.Effect = DragDropEffects.Copy;
            }
            else
            {
                e.Effect = DragDropEffects.None;
            }
        }

        private void C_GeneralEncapsulatedObject_DragOver(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                e.Effect = DragDropEffects.Copy;
            }
            else
            {
                e.Effect = DragDropEffects.None;
            }
        }
    }
}
