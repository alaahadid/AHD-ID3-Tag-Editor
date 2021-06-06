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
    public partial class C_EventTimingCodes : EditorControl
    {
        public C_EventTimingCodes()
        {
            InitializeComponent();
            DisableControls();
            foreach (string ev in ID3FrameConsts.EventTimingCodesEvents)
                Column_event.Items.Add(ev);
            directPlayer = new DirectMediaPlayer();
            this.playerControl1.DirectMediaPlayer = directPlayer;
        }
      
        private DirectMediaPlayer directPlayer;
        public DirectMediaPlayer DirectMediaPlayer
        {
            get { return directPlayer; }
        }

        private void DisableControls()
        {
            dataGridView1.Enabled = panel1.Enabled = panel2.Enabled = eventTimingCodesPanel1.Enabled = toolStrip1.Enabled = false;
            Label1.Text = "";
        }
        private void EnableControls()
        {
            dataGridView1.Enabled = panel1.Enabled = panel2.Enabled = eventTimingCodesPanel1.Enabled = toolStrip1.Enabled = true;
            Label1.Text = "";
        }
        public override void DisableSaving()
        {
            base.DisableSaving();
            toolStripButton1.Enabled = false;
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
                Label1.Text = "You can only edit 1 file at a time.";
                return;
            }
            //load frames
            LoadFrames(files[0]);
        }
        public override void ClearMedia()
        {
            // axWindowsMediaPlayer1.Ctlcontrols.stop();
            // axWindowsMediaPlayer1.currentPlaylist.clear();
            // axWindowsMediaPlayer1.URL = null;
            directPlayer.ClearMedia();
            eventTimingCodesPanel1.MediaText = "";
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
                        eventTimingCodesPanel1.MediaText = Path.GetFileName(files[0]);
                        // WMPLib.IWMPMedia m1 = axWindowsMediaPlayer1.newMedia(files[0]);
                        // axWindowsMediaPlayer1.currentPlaylist.appendItem(m1);
                        directPlayer.LoadFile(files[0]);
                        //media
                        eventTimingCodesPanel1.MediaDuration = directPlayer.Duration;
                        hScrollBar1.Value = 0;
                        trackBar1.Value = 190;
                        trackBar1_Scroll(this, new EventArgs());

                        this.playerControl1.DirectMediaPlayer = directPlayer;
                    }
                }
            }
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
                eventTimingCodesPanel1.EventTimingCodesFrame = (EventTimingCodesFrame)v2.GetFrameLoaded("ETC");
            else
                eventTimingCodesPanel1.EventTimingCodesFrame = (EventTimingCodesFrame)v2.GetFrameLoaded("ETCO");

            if (eventTimingCodesPanel1.EventTimingCodesFrame == null)
                eventTimingCodesPanel1.EventTimingCodesFrame = new EventTimingCodesFrame("ETCO", "Event timing codes", null, 0);
            if (eventTimingCodesPanel1.EventTimingCodesFrame.Items == null)
                eventTimingCodesPanel1.EventTimingCodesFrame.Items = new List<EventTimingItem>();

            ReloadMedia();

            RefreshItems();
        }
        public void SaveFramesToTag(ID3v2 v2)
        {
            // remove all comment frames
            v2.RemoveFrameAll("ETC");
            v2.RemoveFrameAll("ETCO");
            // add frames we have
            if (eventTimingCodesPanel1.EventTimingCodesFrame == null)
                eventTimingCodesPanel1.EventTimingCodesFrame = new EventTimingCodesFrame("ETCO", "Event timing codes", null, 0);
            if (eventTimingCodesPanel1.EventTimingCodesFrame.Items == null)
                eventTimingCodesPanel1.EventTimingCodesFrame.Items = new List<EventTimingItem>();
            if (eventTimingCodesPanel1.EventTimingCodesFrame.Items.Count > 0)
            {
                if (v2.TagVersion.Major == 2)
                    eventTimingCodesPanel1.EventTimingCodesFrame.ID = "ETC";
                else
                    eventTimingCodesPanel1.EventTimingCodesFrame.ID = "ETCO";
                v2.Frames.Add(eventTimingCodesPanel1.EventTimingCodesFrame);
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
        private void AddItemHere()
        {
            //  axWindowsMediaPlayer1.Ctlcontrols.pause();
            directPlayer.Pause();
            //check
            foreach (EventTimingItem item in
            eventTimingCodesPanel1.EventTimingCodesFrame.Items)
            {
                if (directPlayer.Position ==
                          ((double)item.Time / 1000))
                {
                    MessageBox.Show("An item already exists at player's time");
                    return;
                }
            }
            //add
            EventTimingItem newItem = new EventTimingItem((int)(directPlayer.Position * 1000), 0);
            eventTimingCodesPanel1.EventTimingCodesFrame.Items.Add(newItem);
            eventTimingCodesPanel1.EventTimingCodesFrame.Items.Sort(new EventTimingItemComparer());
            RefreshItems();
            //view added
            dataGridView1.Rows[dataGridView1.RowCount - 1].Selected = true;
            dataGridView1.FirstDisplayedScrollingRowIndex = dataGridView1.RowCount - 1;
        }
        private void DeleteSelected()
        {
            foreach (DataGridViewRow row in dataGridView1.SelectedRows)
            {
                eventTimingCodesPanel1.EventTimingCodesFrame.Items.Remove((EventTimingItem)row.Cells[0].Value);
            }
            RefreshItems();
            //view
            timer1_Tick(this, null);
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
            dataGridView1.Rows.Clear();
            ClearMedia();
        }
        private void RefreshItems()
        {
            if (eventTimingCodesPanel1.EventTimingCodesFrame != null)
            {
                dataGridView1.Rows.Clear();
                foreach (EventTimingItem item in
                  eventTimingCodesPanel1.EventTimingCodesFrame.Items)
                {
                    dataGridView1.Rows.Add(new object[] { item, ID3FrameConsts.GetEventTimingEvent(item.EventType) });
                }
            }
        }

        private void UpdateHScroll()
        {
            hScrollBar1.Maximum = eventTimingCodesPanel1.TimeSpace + 100 -
                eventTimingCodesPanel1.Width;
        }
        private void addHereToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddItemHere();
        }
        private void deleteSelectedToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DeleteSelected();
        }
        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            AddItemHere();
        }
        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            DeleteSelected();
        }
        private void C_EventTimingCodes_KeyDown(object sender, KeyEventArgs e)
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

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            int v = trackBar1.Maximum - trackBar1.Value;
            eventTimingCodesPanel1.MilliPixel = v - (v % 5);
            if (eventTimingCodesPanel1.MilliPixel < 5)
                eventTimingCodesPanel1.MilliPixel = 5;
            eventTimingCodesPanel1.TimeSpace = (int)((eventTimingCodesPanel1.MediaDuration * 1000) / eventTimingCodesPanel1.MilliPixel) + 100;
            eventTimingCodesPanel1.Invalidate();
            UpdateHScroll();
        }
        // the timer
        private void timer1_Tick(object sender, EventArgs e)
        {
            if (eventTimingCodesPanel1.EventTimingCodesFrame == null)
                return;
            eventTimingCodesPanel1.CanAutoScroll = directPlayer.IsPlaying;
            eventTimingCodesPanel1.CurrentTime = directPlayer.Position;
            eventTimingCodesPanel1.Invalidate();
            string text = "";
            if (directPlayer.IsPlaying)
            {
                //preview
                int index = -1;
                foreach (EventTimingItem item in
                    eventTimingCodesPanel1.EventTimingCodesFrame.Items)
                {
                    if (directPlayer.Position <
                        ((double)item.Time / 1000))
                    {
                        break;
                    }
                    index++;
                }
                if (index >= 0)
                {
                    text = ID3FrameConsts.GetEventTimingEvent(eventTimingCodesPanel1.EventTimingCodesFrame.Items[index].EventType);
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
            if (!directPlayer.Initialized)
                return;
            // update time text
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
           // label_time.Text = current + " / " + duration + " [" + text + "]";
        }
        private void C_EventTimingCodes_VisibleChanged(object sender, EventArgs e)
        {
            if (!this.Visible)
            { directPlayer.Stop(); }
        }

        private void dataGridView1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            EventTimingItem item = (EventTimingItem)dataGridView1.Rows[e.RowIndex].Cells[0].Value;
            if (dataGridView1.Rows[e.RowIndex].Cells[1].Value != null)
                item.EventType = ID3FrameConsts.GetEventTimingEventIndex(dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString());
            else
                dataGridView1.Rows[e.RowIndex].Cells[1].Value = ID3FrameConsts.GetEventTimingEvent(item.EventType);//cancel edit
        }

        private void dataGridView1_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            directPlayer.Stop();
        }

        private void eventTimingCodesPanel1_ItemTimeChanged(object sender, TimeChangedArgs e)
        {
            //sort items of frame
            eventTimingCodesPanel1.EventTimingCodesFrame.Items.Sort(new EventTimingItemComparer());
            RefreshItems();
        }

        private void eventTimingCodesPanel1_TimeChangeRequest(object sender, TimeChangedArgs e)
        {
            directPlayer.Position = e.NewTime;
        }

        private void hScrollBar1_Scroll(object sender, ScrollEventArgs e)
        {
            eventTimingCodesPanel1.ViewPortOffset = hScrollBar1.Value;
            eventTimingCodesPanel1.Invalidate();
        }
        // clear all
        private void linkLabel3_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            eventTimingCodesPanel1.EventTimingCodesFrame.Items.Clear();
            RefreshItems();
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
    }
}
