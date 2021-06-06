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
    public partial class C_Popularimeter : EditorControl
    {
        public C_Popularimeter()
        {
            InitializeComponent();

            textEditorControl_email.textBox1.TextChanged += textBox1_TextChanged;
            numberControl_rating.numericUpDown1.ValueChanged += numericUpDown1_ValueChanged;
            numberControl_counter.numericUpDown1.ValueChanged += numericUpDown1Counter_ValueChanged;
            textEditorControl_email.textBox1.Validated += textBox1_Validated;
            numberControl_rating.numericUpDown1.Validated += textBox1_Validated;
            numberControl_rating.MaximumNumber = 255;
            numberControl_counter.numericUpDown1.Validated += textBox1_Validated;
            numberControl_counter.MaximumNumber = int.MaxValue;

            DisableControls();
        }
        public override void DisableSaving()
        {
            base.DisableSaving();
            toolStripButton1.Enabled = false;
        }
        public override void ClearFields()
        {
            ComboBox_frames.Items.Clear();
            textEditorControl_email.PropertyValue = "";
            numberControl_counter.PropertyValue = numberControl_rating.PropertyValue = 0;
            ratingControl1.Rating = 0;
        }
        public override string[] SelectedFiles
        {
            get
            {
                return base.SelectedFiles;
            }
            set
            {
                base.SelectedFiles = value; ReloadFrames(this, null);
            }
        }
        private void DisableControls()
        {
            textEditorControl_email.Enabled = toolStrip1.Enabled = numberControl_rating.Enabled = numberControl_counter.Enabled =
                ComboBox_frames.Enabled = ratingControl1.Enabled = false;
            Label1.Text = "";
        }
        private void EnableControls()
        {
            textEditorControl_email.Enabled = toolStrip1.Enabled = numberControl_rating.Enabled = numberControl_counter.Enabled =
                ComboBox_frames.Enabled = ratingControl1.Enabled = true;
            Label1.Text = "";
            ComboBox_frames.SelectedIndex = -1;
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
                if (frame is PopularimeterFrame)
                {
                    ComboBox_frames.Items.Add(frame);
                }
            }
            if (ComboBox_frames.Items.Count > 0)
                ComboBox_frames.SelectedIndex = 0;
            else
            {
                textEditorControl_email.Enabled = false;
                numberControl_counter.Enabled = false;
                numberControl_rating.Enabled = false;
                ratingControl1.Enabled = false;

                textEditorControl_email.PropertyValue = "";
                numberControl_counter.PropertyValue = 0;
                numberControl_rating.PropertyValue = 0;
                ratingControl1.Rating = 0;
            }
        }
        public void SaveFramesToTag(ID3v2 v2)
        {
 
            // remove all comment frames
            v2.RemoveFrameAll("POP");
            v2.RemoveFrameAll("POPM");
            // add frames we have
            foreach (PopularimeterFrame frame in ComboBox_frames.Items)
            {
                if (v2.TagVersion.Major == 2)
                    frame.ID = "POP";
                else
                    frame.ID = "POPM";
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
        private void RefreshSelectedItem()
        {
            if (ComboBox_frames.SelectedIndex >= 0)
            {
                PopularimeterFrame frame = (PopularimeterFrame)ComboBox_frames.SelectedItem;
                int index = ComboBox_frames.SelectedIndex;
                ComboBox_frames.Items.RemoveAt(index);
                ComboBox_frames.Items.Insert(index, frame);
                ComboBox_frames.SelectedIndex = index;
            }
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
        private void AddFrame(object sender, EventArgs e)
        {
            PopularimeterFrame frame = new PopularimeterFrame("POPM", "Popularimeter", null, 0);// id doesn't matter now..
            ComboBox_frames.Items.Add(frame);
            ComboBox_frames.SelectedItem = frame;
        }
        private void RemoveSelected(object sender, EventArgs e)
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
                textEditorControl_email.Enabled = true;
                numberControl_counter.Enabled = true;
                numberControl_rating.Enabled = true;
                ratingControl1.Enabled = true;

                PopularimeterFrame frame = (PopularimeterFrame)ComboBox_frames.SelectedItem;
                textEditorControl_email.PropertyValue = frame.Email;
                numberControl_counter.PropertyValue = frame.Counter;
                numberControl_rating.PropertyValue = frame.Rating;
                ratingControl1.Rating = frame.Rating / 51;
            }
            else
            {
                textEditorControl_email.Enabled = false;
                numberControl_counter.Enabled = false;
                numberControl_rating.Enabled = false;
                ratingControl1.Enabled = false;

                textEditorControl_email.PropertyValue = "";
                numberControl_counter.PropertyValue = 0;
                numberControl_rating.PropertyValue = 0;
                ratingControl1.Rating = 0;
            }
        }
        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            if (ComboBox_frames.SelectedIndex >= 0)
            {
                PopularimeterFrame frame = (PopularimeterFrame)ComboBox_frames.SelectedItem;
                frame.Rating = (byte)numberControl_rating.PropertyValue;
                ratingControl1.Rating = frame.Rating / 51;
            }
        }
        private void numericUpDown1Counter_ValueChanged(object sender, EventArgs e)
        {
            if (ComboBox_frames.SelectedIndex >= 0)
            {
                PopularimeterFrame frame = (PopularimeterFrame)ComboBox_frames.SelectedItem;
                frame.Counter = (int)numberControl_counter.PropertyValue;
            }
        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (ComboBox_frames.SelectedIndex >= 0)
            {
                PopularimeterFrame frame = (PopularimeterFrame)ComboBox_frames.SelectedItem;
                frame.Email = textEditorControl_email.PropertyValue;
            }
        }
        private void ratingControl1_RatingChanged(object sender, EventArgs e)
        {
            numberControl_rating.PropertyValue = ratingControl1.Rating * 51;
        }
        private void textBox1_Validated(object sender, EventArgs e)
        {
            RefreshSelectedItem();
        }
    }
}
