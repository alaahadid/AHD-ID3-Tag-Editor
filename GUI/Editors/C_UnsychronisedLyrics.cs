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
using AHD.ID3;
using AHD.ID3.Types;
using AHD.ID3.Frames;
using AHD.ID3.Editor.Base;
namespace AHD.ID3.Editor.GUI
{
    public partial class C_UnsychronisedLyrics : EditorControl
    {
        public C_UnsychronisedLyrics()
        {
            InitializeComponent();
            // language
            comboBoxControl1.comboBox1.Items.Add("");
            foreach (string lang in ID3FrameConsts.Languages)
                comboBoxControl1.comboBox1.Items.Add(lang);
            comboBoxControl1.comboBox1.SelectedItem = ID3FrameConsts.GetLanguage("ENG");
            comboBoxControl1.comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;

            DisableControls();

            textEditorControl1.textBox1.TextChanged += textBox1_TextChanged;
            comboBoxControl1.comboBox1.SelectedIndexChanged += comboBox1_SelectedIndexChanged;

            textEditorControl1.textBox1.Validated += textBox1_Validated;
            comboBoxControl1.comboBox1.Validated += comboBox1_Validated;
        }
        private void DisableControls()
        {
            richTextBox1.Enabled = toolStrip1.Enabled = comboBoxControl1.Enabled = textEditorControl1.Enabled = ComboBox1.Enabled = false;
            Label1.Text = "";
        }
        private void EnableControls()
        {
            richTextBox1.Enabled = toolStrip1.Enabled = comboBoxControl1.Enabled = textEditorControl1.Enabled = ComboBox1.Enabled = true;
            Label1.Text = ""; ComboBox1.SelectedIndex = -1;
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
            ComboBox1.Items.Clear();
            comboBoxControl1.comboBox1.SelectedItem = ID3FrameConsts.GetLanguage("ENG");
            textEditorControl1.PropertyValue = "";
            richTextBox1.Text = "";
        }
        public override void DisableSaving()
        {
            base.DisableSaving();
            toolStripButton1.Enabled = false;
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
                if (frame is UnsychronisedLyricsFrame)
                {
                    ComboBox1.Items.Add(frame);
                }
            }
            if (ComboBox1.Items.Count > 0)
                ComboBox1.SelectedIndex = 0;
            else
            {
                comboBoxControl1.Enabled = false;
                textEditorControl1.Enabled = false;
                richTextBox1.Enabled = false;
                comboBoxControl1.comboBox1.SelectedItem = ID3FrameConsts.GetLanguage("ENG");
                textEditorControl1.PropertyValue = "";
                richTextBox1.Text = "";
            }
        }
        public void SaveFramesToTag(ID3v2 v2)
        {
            // remove all comment frames
            v2.RemoveFrameAll("ULT");
            v2.RemoveFrameAll("USLT");
            // add frames we have
            foreach (UnsychronisedLyricsFrame frame in ComboBox1.Items)
            {
                if (v2.TagVersion.Major == 2)
                    frame.ID = "ULT";
                else
                    frame.ID = "USLT";
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

            OnReloadMediaRequest();
        }
        private void RefreshSelectedItem()
        {
            if (ComboBox1.SelectedIndex >= 0)
            {
                UnsychronisedLyricsFrame frame = (UnsychronisedLyricsFrame)ComboBox1.SelectedItem;
                int index = ComboBox1.SelectedIndex;
                ComboBox1.Items.RemoveAt(index);
                ComboBox1.Items.Insert(index, frame);
                ComboBox1.SelectedIndex = index;
            }
        }
        private void AddFrame(object sender, EventArgs e)
        {
            UnsychronisedLyricsFrame frame = new UnsychronisedLyricsFrame("USLT", "Unsychronised lyrics", null, 0);// id doesn't matter now..
            frame.LanguageID = "eng";
            ComboBox1.Items.Add(frame);
            ComboBox1.SelectedItem = frame;
        }
        private void RemoveFrame(object sender, EventArgs e)
        {
            if (ComboBox1.SelectedIndex >= 0)
            {
                ComboBox1.Items.RemoveAt(ComboBox1.SelectedIndex);
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

        private void Combobox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ComboBox1.SelectedIndex >= 0)
            {
                comboBoxControl1.Enabled = true;
                textEditorControl1.Enabled = true;
                richTextBox1.Enabled = true;

                UnsychronisedLyricsFrame frame = (UnsychronisedLyricsFrame)ComboBox1.SelectedItem;
                comboBoxControl1.PropertyValue = ID3FrameConsts.GetLanguage(frame.LanguageID);
                textEditorControl1.PropertyValue = frame.ContentDescriptor;
                richTextBox1.Text = frame.LyricsText;
            }
            else
            {
                comboBoxControl1.Enabled = false;
                textEditorControl1.Enabled = false;
                richTextBox1.Enabled = false;
                comboBoxControl1.comboBox1.SelectedItem = ID3FrameConsts.GetLanguage("ENG");
                textEditorControl1.PropertyValue = "";
                richTextBox1.Text = "";
            }
        }
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ComboBox1.SelectedIndex >= 0)
            {
                UnsychronisedLyricsFrame frame = (UnsychronisedLyricsFrame)ComboBox1.SelectedItem;
                frame.LanguageID = ID3FrameConsts.GetLanguageID(comboBoxControl1.comboBox1.SelectedItem.ToString());
            }
        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (ComboBox1.SelectedIndex >= 0)
            {
                UnsychronisedLyricsFrame frame = (UnsychronisedLyricsFrame)ComboBox1.SelectedItem;
                frame.ContentDescriptor = textEditorControl1.PropertyValue;
            }
        }
        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {
            if (ComboBox1.SelectedIndex >= 0)
            {
                UnsychronisedLyricsFrame frame = (UnsychronisedLyricsFrame)ComboBox1.SelectedItem;
                frame.LyricsText = richTextBox1.Text;
            }
        }

        private void richTextBox1_Validated(object sender, EventArgs e)
        {
            RefreshSelectedItem();
        }
        private void comboBox1_Validated(object sender, EventArgs e)
        {
            RefreshSelectedItem();
        }
        private void textBox1_Validated(object sender, EventArgs e)
        {
            RefreshSelectedItem();
        }
    }
}
