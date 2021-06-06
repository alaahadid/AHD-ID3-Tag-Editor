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
using AHD.ID3;
using AHD.ID3.Types;
using AHD.ID3.Frames;
using AHD.ID3.Editor.Base;

namespace AHD.ID3.Editor.GUI
{
    public partial class C_Commercial : EditorControl
    {
        public C_Commercial()
        {
            InitializeComponent();
            comboBoxControl_ReceivedAs.comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
            foreach (string type in ID3FrameConsts.CommercialReceivedAs)
                comboBoxControl_ReceivedAs.comboBox1.Items.Add(type);
            comboBoxControl_ReceivedAs.comboBox1.SelectedIndex = comboBox_price.SelectedIndex = 0;

            dateControl_ValidUntil.dateTimePicker1.Format = DateTimePickerFormat.Custom;
            dateControl_ValidUntil.dateTimePicker1.CustomFormat = "yyyy/MM/dd";

            DisableControls();
        }
        private CommercialFrame frame;

        private void DisableControls()
        {
            textEditorControl_ContactURL.Enabled = textEditorControl_NameOfSeller.Enabled = textEditorControl_price.Enabled =
                comboBoxControl_ReceivedAs.Enabled = comboBox_price.Enabled = dateControl_ValidUntil.Enabled = imagePanel1.Enabled =
                label_picInfo.Enabled = richTextControl_Description.Enabled= toolStrip1.Enabled =
                  linkLabel1.Enabled=linkLabel2.Enabled=linkLabel3.Enabled= false;
            label_picInfo.Text = toolStripLabel1.Text = "";
            imagePanel1.ImageToView = null;
            imagePanel1.Invalidate();
        }
        private void EnableControls()
        {
            textEditorControl_ContactURL.Enabled = textEditorControl_NameOfSeller.Enabled = textEditorControl_price.Enabled =
             comboBoxControl_ReceivedAs.Enabled = comboBox_price.Enabled = dateControl_ValidUntil.Enabled = imagePanel1.Enabled =
             label_picInfo.Enabled = richTextControl_Description.Enabled = toolStrip1.Enabled =
               linkLabel1.Enabled = linkLabel2.Enabled = linkLabel3.Enabled = true;
            toolStripLabel1.Text = "";
        }

        public override string[] SelectedFiles
        {
            get
            {
                return base.SelectedFiles;
            }
            set
            {
                base.SelectedFiles = value; ReloadFrame(null, null);
            }
        }
        public override void ClearFields()
        {
            toolStripLabel1.Text = "";
            textEditorControl_ContactURL.PropertyValue = textEditorControl_NameOfSeller.PropertyValue
                = richTextControl_Description.PropertyValue = textEditorControl_price.PropertyValue = "";
            dateControl_ValidUntil.PropertyValue = DateTime.Now;
            comboBox_price.SelectedIndex = 0;
            comboBoxControl_ReceivedAs.comboBox1.SelectedIndex = 0;
            imagePanel1.ImageToView = null;
            imagePanel1.Invalidate();
        }
        public override void DisableSaving()
        {
            base.DisableSaving();
            toolStripButton1.Enabled = false;
        }
        private void ReloadFrame(object sender, EventArgs e)
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
                toolStripLabel1.Text = "You can only edit 1 file at a time.";
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
            if (v2.TagVersion.Major == 2)
            {
                DisableControls();
                frame = null;
                toolStripLabel1.Text = "Commercial frame doesn't exist in ID3 Tag version 2.2";
            }
            else
            {
                frame = (CommercialFrame)v2.GetFrameLoaded("COMR"); 
                toolStripLabel1.Text = "";
            }
            ViewData();
        }
        private void ViewData()
        {
            if (frame == null)
            {
                textEditorControl_ContactURL.PropertyValue = textEditorControl_NameOfSeller.PropertyValue
            = textEditorControl_price.PropertyValue =richTextControl_Description.PropertyValue= "";
                dateControl_ValidUntil.PropertyValue = DateTime.Now;
                comboBox_price.SelectedIndex = 0;
                comboBoxControl_ReceivedAs.comboBox1.SelectedIndex = 0;
                imagePanel1.ImageToView = null;
                imagePanel1.Invalidate();

                textEditorControl_ContactURL.Enabled = textEditorControl_NameOfSeller.Enabled = textEditorControl_price.Enabled =
                comboBoxControl_ReceivedAs.Enabled = comboBox_price.Enabled = dateControl_ValidUntil.Enabled = imagePanel1.Enabled =
                label_picInfo.Enabled = richTextControl_Description.Enabled=
                linkLabel1.Enabled=linkLabel2.Enabled=linkLabel3.Enabled= false;
            }
            else
            {
                textEditorControl_price.PropertyValue = frame.Price;
                richTextControl_Description.PropertyValue = frame.Description;
                textEditorControl_NameOfSeller.PropertyValue = frame.NameOfSeller;
                textEditorControl_ContactURL.PropertyValue = frame.ContactURL;
                comboBoxControl_ReceivedAs.comboBox1.SelectedItem = frame.ReceivedAs;
                comboBox_price.SelectedItem = frame.Currency;
                if (frame.ValidUntil.Length >= 6)
                {
                    dateControl_ValidUntil.PropertyValue = new DateTime(int.Parse(frame.ValidUntil.Substring(0, 4)),
                        int.Parse(frame.ValidUntil.Substring(4, 2)), int.Parse(frame.ValidUntil.Substring(6, 2)));
                }
                else
                {
                    dateControl_ValidUntil.PropertyValue = DateTime.Now;
                }
                //image
                imagePanel1.ImageToView = null;
                if (frame.SellerLogoData != null)
                {
                    if (frame.SellerLogoData.Length > 0)
                    {
                        System.IO.Stream stream = new System.IO.MemoryStream(frame.SellerLogoData);
                        imagePanel1.ImageToView = new Bitmap(stream);

                        //pic info
                        label_picInfo.Text = "";
                        label_picInfo.Text += "MIME: " + frame.PictureMIMEType + "\n";
                        label_picInfo.Text += "Size: " + ((double)frame.SellerLogoData.Length / 1024).ToString("F2") + " KB\n";
                        label_picInfo.Text += "Image Size: " + imagePanel1.ImageToView.Size.Width + " x " +
                            imagePanel1.ImageToView.Size.Height + "\n";
                    }
                }
                imagePanel1.Invalidate();
            }
        }
        public void SaveFramesToTag(ID3v2 v2)
        {

            // remove all frames
            v2.RemoveFrameAll("COMR");
            if (frame != null)
            {
                // apply data
                frame.Price = textEditorControl_price.PropertyValue;
                frame.Description = richTextControl_Description.PropertyValue;
                frame.NameOfSeller = textEditorControl_NameOfSeller.PropertyValue;
                frame.ContactURL = textEditorControl_ContactURL.PropertyValue;
                frame.ReceivedAs = comboBoxControl_ReceivedAs.comboBox1.SelectedItem.ToString();
                frame.Currency = comboBox_price.SelectedItem.ToString();
                frame.ValidUntil =
                    dateControl_ValidUntil.PropertyValue.Year.ToString("D4") +
                    dateControl_ValidUntil.PropertyValue.Month.ToString("D2") +
                    dateControl_ValidUntil.PropertyValue.Day.ToString("D2");
                //image should be already set
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
        //change picture
        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            OpenFileDialog op = new OpenFileDialog();
            op.Filter = "Supported image types (*.jpg;*.png;)|*.jpg;*.png;";
            if (op.ShowDialog(this) == DialogResult.OK)
            {
                frame.PictureMIMEType = MIME.MimeManager.GetMime(Path.GetExtension(op.FileName));
                Stream stream = new FileStream(op.FileName, FileMode.Open, FileAccess.Read);
                byte[] buffer = new byte[stream.Length];
                stream.Read(buffer, 0, buffer.Length);
                stream.Dispose();
                stream.Close();

                frame.SellerLogoData = buffer;
                // view
                imagePanel1.ImageToView = null;
                if (frame.SellerLogoData != null)
                {
                    if (frame.SellerLogoData.Length > 0)
                    {
                        System.IO.Stream mstream = new System.IO.MemoryStream(frame.SellerLogoData);
                        imagePanel1.ImageToView = new Bitmap(mstream);

                        //pic info
                        label_picInfo.Text = "";
                        label_picInfo.Text += "MIME: " + frame.PictureMIMEType + "\n";
                        label_picInfo.Text += "Size: " + ((double)frame.SellerLogoData.Length / 1024).ToString("F2") + " KB\n";
                        label_picInfo.Text += "Image Size: " + imagePanel1.ImageToView.Size.Width + " x " +
                            imagePanel1.ImageToView.Size.Height + "\n";
                    }
                }
                imagePanel1.Invalidate();
            }
        }
        // clear
        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frame.PictureMIMEType = "";
            frame.SellerLogoData = null;
            ViewData();
        }
        // save as
        private void linkLabel3_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (imagePanel1.ImageToView != null)
            {
                SaveFileDialog sav = new SaveFileDialog();
                sav.Filter = MIME.MimeManager.GetExtensionsFilter(frame.PictureMIMEType);
                if (sav.ShowDialog(this) == DialogResult.OK)
                {
                    imagePanel1.ImageToView.Save(sav.FileName);
                }
            }
        }
        private void CreateNew(object sender, EventArgs e)
        {
            frame = new CommercialFrame("COMR", "Commercial frame", null, 0);
            EnableControls();
            ViewData();
        }
        private void ClearFrame(object sender, EventArgs e)
        {
            frame = null;
            ViewData();
        }
    }
}
