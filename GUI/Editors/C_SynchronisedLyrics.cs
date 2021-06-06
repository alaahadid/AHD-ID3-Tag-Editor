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
using System.Diagnostics;
using AHD.ID3;
using AHD.ID3.Types;
using AHD.ID3.Frames;
using AHD.ID3.Editor.Base;
using AHD.SM.Formats;
using AHD.SM.ASMP;
namespace AHD.ID3.Editor.GUI
{
    public partial class C_SynchronisedLyrics : EditorControl
    {
        public C_SynchronisedLyrics()
        {
            InitializeComponent();
            // language
            comboBoxControl_language.comboBox1.Items.Add("");
            foreach (string lang in ID3FrameConsts.Languages)
                comboBoxControl_language.comboBox1.Items.Add(lang);
            comboBoxControl_language.comboBox1.SelectedItem = ID3FrameConsts.GetLanguage("ENG");
            comboBoxControl_language.comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
            // content type
            comboBoxControl_ContentType.comboBox1.Items.Add("");
            foreach (string typ in ID3FrameConsts.SynchronisedLyricsContentTypes)
                comboBoxControl_ContentType.comboBox1.Items.Add(typ);
            comboBoxControl_ContentType.comboBox1.SelectedIndex = 0;
            comboBoxControl_ContentType.comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
            // 
            textEditorControl_ContentDescriptor.textBox1.Validated += textBox1_Validated;
            textEditorControl_ContentDescriptor.textBox1.TextChanged += textBox1_TextChanged;
            comboBoxControl_ContentType.comboBox1.Validated += textBox1_Validated;
            comboBoxControl_ContentType.comboBox1.SelectedIndexChanged += comboBox1ContentType_SelectedIndexChanged;
            comboBoxControl_language.comboBox1.Validated += textBox1_Validated;
            comboBoxControl_language.comboBox1.SelectedIndexChanged += comboBoxLanguage_SelectedIndexChanged;

            DisableControls();
            // detect supported formats
            SubtitleFormats.DetectSupportedFormats(true, true);

            directPlayer = new DirectMediaPlayer();
            this.playerControl1.DirectMediaPlayer = directPlayer;
        }
        private DirectMediaPlayer directPlayer;
        public DirectMediaPlayer DirectMediaPlayer
        {
            get { return directPlayer; }
        }
        private void textBox1_Validated(object sender, EventArgs e)
        {
            RefreshSelectedItem();
        }
        private void RefreshSelectedItem()
        {
            if (ComboBox_frames.SelectedIndex >= 0)
            {
                SynchronisedLyricsFrame frame = (SynchronisedLyricsFrame)ComboBox_frames.SelectedItem;
                int index = ComboBox_frames.SelectedIndex;
                ComboBox_frames.Items.RemoveAt(index);
                ComboBox_frames.Items.Insert(index, frame);
                ComboBox_frames.SelectedIndex = index;
            }
        }
        private void DisableControls()
        {
            textEditorControl_ContentDescriptor.Enabled = comboBoxControl_ContentType.Enabled = comboBoxControl_language.Enabled
                = panel1.Enabled = panel2.Enabled = synchronisedLyricsCodesPanel1.Enabled = dataGridView1.Enabled =
                ComboBox_frames.Enabled = toolStrip1.Enabled = false;
            Label1.Text = "";
        }
        private void EnableControls()
        {
            textEditorControl_ContentDescriptor.Enabled = comboBoxControl_ContentType.Enabled = comboBoxControl_language.Enabled
                 = panel1.Enabled = panel2.Enabled = synchronisedLyricsCodesPanel1.Enabled = dataGridView1.Enabled =
                 ComboBox_frames.Enabled = toolStrip1.Enabled = true;
            Label1.Text = "";
        }
        private void RefreshItems()
        {
            if (synchronisedLyricsCodesPanel1.SynchronisedLyricsFrame != null)
            {
                dataGridView1.Rows.Clear();
                foreach (SynchronisedLyricsItem item in
                  synchronisedLyricsCodesPanel1.SynchronisedLyricsFrame.Items)
                {
                    dataGridView1.Rows.Add(new object[] { item, item.Text });
                }
            }
        }
        public override void ClearMedia()
        {
            //  axWindowsMediaPlayer1.Ctlcontrols.stop();
            // axWindowsMediaPlayer1.currentPlaylist.clear();
            // axWindowsMediaPlayer1.URL = null;
            directPlayer.ClearMedia();
            synchronisedLyricsCodesPanel1.MediaText = "";
            this.playerControl1.DirectMediaPlayer = directPlayer;
        }
        public override void ReloadMedia()
        {
            if (files != null)
            {
                if (files.Length > 0)
                {
                    if (File.Exists(files[0]))
                    {
                        synchronisedLyricsCodesPanel1.MediaText = Path.GetFileName(files[0]);
                        //WMPLib.IWMPMedia m1 = axWindowsMediaPlayer1.newMedia(files[0]);
                        //axWindowsMediaPlayer1.currentPlaylist.appendItem(m1);
                        directPlayer.LoadFile(files[0]);
                        //media
                        synchronisedLyricsCodesPanel1.MediaDuration = directPlayer.Duration;
                        hScrollBar1.Value = 0;
                        trackBar1.Value = 190;
                        trackBar1_Scroll(this, new EventArgs());
                        this.playerControl1.DirectMediaPlayer = directPlayer;
                    }
                }
            }
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
            comboBoxControl_language.comboBox1.SelectedItem = ID3FrameConsts.GetLanguage("ENG");
            comboBoxControl_ContentType.comboBox1.SelectedIndex = 0;
            textEditorControl_ContentDescriptor.PropertyValue = "";
            dataGridView1.Rows.Clear();
            ClearMedia();
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
                if (frame is SynchronisedLyricsFrame)
                {
                    ComboBox_frames.Items.Add(frame);
                }
            }
            if (ComboBox_frames.Items.Count > 0)
                ComboBox_frames.SelectedIndex = 0;
            else
            {
                textEditorControl_ContentDescriptor.Enabled = comboBoxControl_ContentType.Enabled = comboBoxControl_language.Enabled
                     = panel1.Enabled = panel2.Enabled = synchronisedLyricsCodesPanel1.Enabled = dataGridView1.Enabled =
                     ComboBox_frames.Enabled = false;
                comboBoxControl_language.comboBox1.SelectedItem = ID3FrameConsts.GetLanguage("ENG");
                comboBoxControl_ContentType.comboBox1.SelectedIndex = 0;
                textEditorControl_ContentDescriptor.PropertyValue = "";
                dataGridView1.Rows.Clear();
                synchronisedLyricsCodesPanel1.SynchronisedLyricsFrame = null;
            }
            ReloadMedia();
        }
        public void SaveFramesToTag(ID3v2 v2)
        {
            // remove all comment frames
            v2.RemoveFrameAll("SLT");
            v2.RemoveFrameAll("SYLT");
            // add frames we have
            foreach (SynchronisedLyricsFrame frame in ComboBox_frames.Items)
            {
                if (v2.TagVersion.Major == 2)
                    frame.ID = "SLT";
                else
                    frame.ID = "SYLT";
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
        private void AddFrame(object sender, EventArgs e)
        {
            SynchronisedLyricsFrame frame = new SynchronisedLyricsFrame("SYLT", "Synchronized lyrics", null, 0);// id doesn't matter now..
            frame.LanguageID = "eng";
            frame.Items = new List<SynchronisedLyricsItem>();
            frame.ContentType = ID3FrameConsts.SynchronisedLyricsContentTypes[0];
            ComboBox_frames.Items.Add(frame);
            ComboBox_frames.SelectedItem = frame;
        }
        private void RemoveFrame(object sender, EventArgs e)
        {
            if (ComboBox_frames.SelectedIndex >= 0)
            {
                ComboBox_frames.Items.RemoveAt(ComboBox_frames.SelectedIndex);
            }
            ComboBox_frames_SelectedIndexChanged(this, null);
        }
        private void AddItemHere()
        {
            //axWindowsMediaPlayer1.Ctlcontrols.pause();
            directPlayer.Pause();
            //check
            foreach (SynchronisedLyricsItem item in
            synchronisedLyricsCodesPanel1.SynchronisedLyricsFrame.Items)
            {
                // if (axWindowsMediaPlayer1.Ctlcontrols.currentPosition ==
                //           ((double)item.Time / 1000))
                if (directPlayer.Position == ((double)item.Time / 1000))
                {
                    MessageBox.Show("An item already exists at player's time");
                    return;
                }
            }
            //add
            SynchronisedLyricsItem newItem = new SynchronisedLyricsItem((int)(directPlayer.Position * 1000), "<NewText>");
            synchronisedLyricsCodesPanel1.SynchronisedLyricsFrame.Items.Add(newItem);
            synchronisedLyricsCodesPanel1.SynchronisedLyricsFrame.Items.Sort(new SynchronisedLyricsItemComparer());
            RefreshItems();
            //view added
            dataGridView1.Rows[dataGridView1.RowCount - 1].Selected = true;
            dataGridView1.FirstDisplayedScrollingRowIndex = dataGridView1.RowCount - 1;
        }
        private void DeleteSelected()
        {
            foreach (DataGridViewRow row in dataGridView1.SelectedRows)
            {
                synchronisedLyricsCodesPanel1.SynchronisedLyricsFrame.Items.Remove((SynchronisedLyricsItem)row.Cells[0].Value);
            }
            RefreshItems();
            //view
            timer1_Tick(this, null);
        }
        public override void DisableSaving()
        {
            base.DisableSaving();
            toolStripButton1.Enabled = false;
        }
        // the timer
        private void timer1_Tick(object sender, EventArgs e)
        {
            if (synchronisedLyricsCodesPanel1.SynchronisedLyricsFrame == null)
                return;
            synchronisedLyricsCodesPanel1.CanAutoScroll = (directPlayer.IsPlaying);
            synchronisedLyricsCodesPanel1.CurrentTime = directPlayer.Position;
            synchronisedLyricsCodesPanel1.Invalidate();
            string text = "";
            if (directPlayer.IsPlaying)
            {
                //preview
                int index = -1;
                foreach (SynchronisedLyricsItem item in
                    synchronisedLyricsCodesPanel1.SynchronisedLyricsFrame.Items)
                {
                    if (directPlayer.Position < ((double)item.Time / 1000))
                    {
                        break;
                    }
                    index++;
                }
                if (index >= 0)
                {
                    text = synchronisedLyricsCodesPanel1.SynchronisedLyricsFrame.Items[index].Text;
                    dataGridView1.FirstDisplayedScrollingRowIndex = index;
                }
            }
            if (files == null)
            {
                return;
            }
            if (files.Length == 0)
            {
                return;
            }
            if (files.Length > 1)
            {
                return;
            }
            // update time text
            // if (axWindowsMediaPlayer1.currentMedia == null)
            //     return;
            if (!directPlayer.Initialized)
                return;
            string current = TimeSpan.FromSeconds(directPlayer.Position).ToString();
            string duration = TimeSpan.FromSeconds(directPlayer.Duration).ToString();
            if (current.Length < 12)
                current = current + ".000";
            else
                current = current.Substring(0, 12);
            if (duration.Length < 12)
                duration = duration + ".000";
            else
                duration = duration.Substring(0, 12);
          //  label_time.Text = current + " / " + duration + " [" + text + "]";
        }

        private void ComboBox_frames_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ComboBox_frames.SelectedIndex >= 0)
            {
                textEditorControl_ContentDescriptor.Enabled = comboBoxControl_ContentType.Enabled = comboBoxControl_language.Enabled
            = panel1.Enabled = panel2.Enabled = synchronisedLyricsCodesPanel1.Enabled = dataGridView1.Enabled =
            ComboBox_frames.Enabled = toolStrip1.Enabled = true;

                synchronisedLyricsCodesPanel1.SynchronisedLyricsFrame = (SynchronisedLyricsFrame)ComboBox_frames.SelectedItem;
                comboBoxControl_language.comboBox1.SelectedItem = ID3FrameConsts.GetLanguage(synchronisedLyricsCodesPanel1.SynchronisedLyricsFrame.LanguageID);
                comboBoxControl_ContentType.comboBox1.SelectedItem =
                    synchronisedLyricsCodesPanel1.SynchronisedLyricsFrame.ContentType;
                textEditorControl_ContentDescriptor.PropertyValue = synchronisedLyricsCodesPanel1.SynchronisedLyricsFrame.ContentDescriptor;

                RefreshItems();
            }
            else
            {
                textEditorControl_ContentDescriptor.Enabled = comboBoxControl_ContentType.Enabled = comboBoxControl_language.Enabled
                    = panel1.Enabled = panel2.Enabled = synchronisedLyricsCodesPanel1.Enabled = dataGridView1.Enabled =
                    ComboBox_frames.Enabled = false;
                comboBoxControl_language.comboBox1.SelectedItem = ID3FrameConsts.GetLanguage("ENG");
                comboBoxControl_ContentType.comboBox1.SelectedIndex = 0;
                textEditorControl_ContentDescriptor.PropertyValue = "";
                dataGridView1.Rows.Clear();
                synchronisedLyricsCodesPanel1.SynchronisedLyricsFrame = null;
            }
        }
        private void comboBoxLanguage_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ComboBox_frames.SelectedIndex >= 0)
            {
                SynchronisedLyricsFrame frame = (SynchronisedLyricsFrame)ComboBox_frames.SelectedItem;
                frame.LanguageID = ID3FrameConsts.GetLanguageID(comboBoxControl_language.comboBox1.SelectedItem.ToString());
            }
        }
        private void comboBox1ContentType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ComboBox_frames.SelectedIndex >= 0)
            {
                SynchronisedLyricsFrame frame = (SynchronisedLyricsFrame)ComboBox_frames.SelectedItem;
                frame.ContentType = comboBoxControl_ContentType.comboBox1.SelectedItem.ToString();
            }
        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (ComboBox_frames.SelectedIndex >= 0)
            {
                SynchronisedLyricsFrame frame = (SynchronisedLyricsFrame)ComboBox_frames.SelectedItem;
                frame.ContentDescriptor = textEditorControl_ContentDescriptor.PropertyValue;
            }
        }
        private void UpdateHScroll()
        {
            hScrollBar1.Maximum = synchronisedLyricsCodesPanel1.TimeSpace + 100 -
                synchronisedLyricsCodesPanel1.Width;
        }
        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            int v = trackBar1.Maximum - trackBar1.Value;
            synchronisedLyricsCodesPanel1.MilliPixel = v - (v % 5);
            if (synchronisedLyricsCodesPanel1.MilliPixel < 5)
                synchronisedLyricsCodesPanel1.MilliPixel = 5;
            synchronisedLyricsCodesPanel1.TimeSpace = (int)((synchronisedLyricsCodesPanel1.MediaDuration * 1000) / synchronisedLyricsCodesPanel1.MilliPixel) + 100;
            synchronisedLyricsCodesPanel1.Invalidate();
            UpdateHScroll();
        }
        private void hScrollBar1_Scroll(object sender, ScrollEventArgs e)
        {
            synchronisedLyricsCodesPanel1.ViewPortOffset = hScrollBar1.Value;
            synchronisedLyricsCodesPanel1.Invalidate();
        }
        private void synchronisedLyricsCodesPanel1_ItemTimeChanged(object sender, TimeChangedArgs e)
        {
            //sort items of frame
            synchronisedLyricsCodesPanel1.SynchronisedLyricsFrame.Items.Sort(new SynchronisedLyricsItemComparer());
            RefreshItems();
        }
        private void synchronisedLyricsCodesPanel1_TimeChangeRequest(object sender, TimeChangedArgs e)
        {
            //axWindowsMediaPlayer1.Ctlcontrols.currentPosition = e.NewTime;
            directPlayer.Position = e.NewTime;
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
        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            AddItemHere();
        }
        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            DeleteSelected();
        }
        // clear all
        private void linkLabel3_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            synchronisedLyricsCodesPanel1.SynchronisedLyricsFrame.Items.Clear();
            RefreshItems();
        }
        private void dataGridView1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            SynchronisedLyricsItem item = (SynchronisedLyricsItem)dataGridView1.Rows[e.RowIndex].Cells[0].Value;
            if (dataGridView1.Rows[e.RowIndex].Cells[1].Value != null)
                item.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            else
                dataGridView1.Rows[e.RowIndex].Cells[1].Value = item.Text;//cancel edit
        }
        private void dataGridView1_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            // axWindowsMediaPlayer1.Ctlcontrols.pause();
            directPlayer.Pause();
        }
        private void C_SynchronisedLyrics_VisibleChanged(object sender, EventArgs e)
        {
            if (!this.Visible)
            {
                //  axWindowsMediaPlayer1.Ctlcontrols.stop(); 
                directPlayer.Stop();
            }
        }
        private void dataGridView1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Delete)
            {
                DeleteSelected();
            }
            else if ((e.KeyData & Keys.Space) == Keys.Space && ModifierKeys == Keys.Control)//add
            {
                AddItemHere();
            }
            else if ((e.KeyData & Keys.A) == Keys.A && ModifierKeys == Keys.Control)//select all
            {
                dataGridView1.SelectAll();
            }
        }
        private void CloneFrame(object sender, EventArgs e)
        {
            if (ComboBox_frames.SelectedIndex < 0)
                return;
            SynchronisedLyricsFrame oldFrame = (SynchronisedLyricsFrame)ComboBox_frames.SelectedItem;
            SynchronisedLyricsFrame frame = new SynchronisedLyricsFrame("SYLT", "Synchronised lyrics", null, 0);// id doesn't matter now..
            frame.LanguageID = oldFrame.LanguageID;
            frame.ContentType = oldFrame.ContentType;
            frame.ContentDescriptor = "Copy of " + oldFrame.ContentDescriptor;
            // clone items
            frame.Items = new List<SynchronisedLyricsItem>();
            foreach (SynchronisedLyricsItem oldItem in oldFrame.Items)
                frame.Items.Add(oldItem);
            // add it
            ComboBox_frames.Items.Add(frame);
            ComboBox_frames.SelectedItem = frame;
        }
        // subtitles format
        private void ImportSubtitlesFormat(object sender, EventArgs e)
        {
            OpenFileDialog op = new OpenFileDialog();
            op.Title = "Import subtitles format";
            op.Filter = SubtitleFormats.GetFilter();
            if (op.ShowDialog(this) == DialogResult.OK)
            {
                Frm_ImportSubtitlesFormat frm = new Frm_ImportSubtitlesFormat(op.FileName);
                if (frm.ShowDialog(this) == DialogResult.OK)
                {
                    if (ComboBox_frames.SelectedIndex >= 0)
                    {
                        DialogResult result = MessageBox.Show("Are you sure you want to replace these lines ?\n\nYes= replace lines with imported subtitles\nNo= create new frame with imported subtitles\nCancel= cancel import", "Import subtitles format", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
                        if (result == DialogResult.Yes)
                        {
                            synchronisedLyricsCodesPanel1.SynchronisedLyricsFrame.Items = new List<SynchronisedLyricsItem>();
                            foreach (Subtitle sub in frm.ImportedFormat.SubtitleTrack.Subtitles)
                            {
                                synchronisedLyricsCodesPanel1.SynchronisedLyricsFrame.Items.Add(new SynchronisedLyricsItem((int)(sub.StartTime * 1000), sub.Text.ToString()));
                            }
                            RefreshItems();
                        }
                        else if (result == DialogResult.No)
                        {
                            // add new
                            SynchronisedLyricsFrame frame = new SynchronisedLyricsFrame("SYLT", "Synchronised lyrics", null, 0);// id doesn't matter now..
                            frame.LanguageID = "eng";
                            frame.ContentType = ID3FrameConsts.SynchronisedLyricsContentTypes[0];
                            frame.Items = new List<SynchronisedLyricsItem>();
                            foreach (Subtitle sub in frm.ImportedFormat.SubtitleTrack.Subtitles)
                            {
                                frame.Items.Add(new SynchronisedLyricsItem((int)(sub.StartTime * 1000), sub.Text.ToString()));
                            }

                            ComboBox_frames.Items.Add(frame);
                            ComboBox_frames.SelectedItem = frame;
                        }
                    }
                    else//create new anyway
                    {
                        SynchronisedLyricsFrame frame = new SynchronisedLyricsFrame("SYLT", "Synchronised lyrics", null, 0);// id doesn't matter now..
                        frame.LanguageID = "eng";
                        frame.ContentType = ID3FrameConsts.SynchronisedLyricsContentTypes[0];
                        frame.Items = new List<SynchronisedLyricsItem>();
                        foreach (Subtitle sub in frm.ImportedFormat.SubtitleTrack.Subtitles)
                        {
                            frame.Items.Add(new SynchronisedLyricsItem((int)(sub.StartTime * 1000), sub.Text.ToString()));
                        }

                        ComboBox_frames.Items.Add(frame);
                        ComboBox_frames.SelectedItem = frame;
                    }
                }
            }
        }
        private void ExportSubtitlesFormat(object sender, EventArgs e)
        {
            if (ComboBox_frames.SelectedIndex >= 0)
            {
                SynchronisedLyricsFrame frame = (SynchronisedLyricsFrame)ComboBox_frames.SelectedItem;
                Frm_ExportSubtitlesFormat frm = new Frm_ExportSubtitlesFormat(frame);
                frm.ShowDialog(this);
            }
        }

        public override bool IsPlaying
        {
            get
            {
                return directPlayer.IsPlaying;
            }
        }
        public override void PlayMedia()
        {
            directPlayer.Play();
        }
        public override void StopMedia()
        {
            directPlayer.Stop();
        }
        private void Preview(object sender, EventArgs e)
        {
            if (files == null)
            {
                return;
            }
            if (files.Length == 0)
            {
                return;
            }
            if (files.Length > 1)
            {
                return;
            }
            if (ComboBox_frames.Items.Count == 0)
            {
                MessageBox.Show("No frame !!");
                return;
            }
            List<SynchronisedLyricsFrame> frames = new List<SynchronisedLyricsFrame>();
            foreach (SynchronisedLyricsFrame frm in ComboBox_frames.Items)
                frames.Add(frm);
            Frm_MediaPreview form = new Frm_MediaPreview(files[0], frames.ToArray());
            form.ShowDialog(this);
        }
    }
}
