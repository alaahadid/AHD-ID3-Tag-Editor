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
    public partial class C_MediaPlayer : EditorControl
    {
        public C_MediaPlayer(bool autoStart)
        {
            InitializeComponent();
            imagePanel1.DrawDefaultImageWhenViewImageIsNull = false;
            // axWindowsMediaPlayer1.settings.autoStart = autoStart;
            this.AutoStart = autoStart;
            this.directPlayer = new DirectMediaPlayer();
            this.playerControl1.DirectMediaPlayer = directPlayer;
        }
        public SynchronisedLyricsFrame currentFrameInDisplay = null;
        private DirectMediaPlayer directPlayer;
        public DirectMediaPlayer DirectMediaPlayer
        {
            get { return directPlayer; }
        }
        public bool AutoStart
        {
            // get { return axWindowsMediaPlayer1.settings.autoStart; }
            // set { axWindowsMediaPlayer1.settings.autoStart = value; }
            get;
            set;
        }
        public override void ClearMedia()
        {
            // axWindowsMediaPlayer1.Ctlcontrols.stop();
            // axWindowsMediaPlayer1.currentPlaylist.clear();
            //  axWindowsMediaPlayer1.URL = null;
            directPlayer.ClearMedia();
            this.playerControl1.DirectMediaPlayer = directPlayer;
        }
        public override void ClearFields()
        {
            currentFrameInDisplay = null;
            lyricsLanguageToolStripMenuItem.DropDownItems.Clear();
            ClearMedia();
            label1.Text = "";
            imagePanel1.ImageToView = null;
            imagePanel1.Invalidate();
        }
        public override string[] SelectedFiles
        {
            get
            {
                return base.SelectedFiles;
            }
            set
            {
                base.SelectedFiles = value; LoadFiles();
            }
        }
        private void LoadFiles()
        {
            ClearFields();
            if (files == null) return;
            if (files.Length == 1)
            {
                // load image
                ID3v2 v2 = new ID3v2();
                if (v2.Load(files[0]) == Result.Success)
                {
                    AttachedPictureFrame frame;
                    if (v2.TagVersion.Major == 2)
                        frame = (AttachedPictureFrame)v2.GetFrameLoaded("PIC");
                    else
                        frame = (AttachedPictureFrame)v2.GetFrameLoaded("APIC");

                    if (frame != null)
                    {
                        try
                        {
                            System.IO.Stream stream = new System.IO.MemoryStream(frame.PictureData);
                            imagePanel1.ImageToView = new Bitmap(stream);
                            imagePanel1.Invalidate();
                        }
                        catch
                        {
                            imagePanel1.ImageToView = null;
                            imagePanel1.Invalidate();
                        }
                    }
                    // load synchronized lyrics item
                    lyricsLanguageToolStripMenuItem.DropDownItems.Clear();
                    bool isFirst = true;
                    foreach (ID3TagFrame sframe in v2.Frames)
                    {
                        if (sframe is SynchronisedLyricsFrame)
                        {
                            ToolStripMenuItem item = new ToolStripMenuItem();
                            item.Text = ID3FrameConsts.GetLanguage(((SynchronisedLyricsFrame)sframe).LanguageID);
                            if (item.Text == "")
                                item.Text = "Unknown";
                            item.Tag = sframe;
                            if (isFirst)
                            {
                                isFirst = false;
                                item.Checked = true;
                                currentFrameInDisplay = (SynchronisedLyricsFrame)sframe;
                            }
                            lyricsLanguageToolStripMenuItem.DropDownItems.Add(item);
                        }
                    }
                }
                ReloadMedia();
            }
        }
        public override void ReloadMedia()
        {
            if (files != null)
            {
                if (files.Length > 0)
                {
                    if (File.Exists(files[0]))
                    {
                        //   WMPLib.IWMPMedia m1 = axWindowsMediaPlayer1.newMedia(files[0]);
                        //   axWindowsMediaPlayer1.currentPlaylist.appendItem(m1);
                        directPlayer.LoadFile(files[0]);
                        if (this.AutoStart)
                            directPlayer.Play();
                        this.playerControl1.DirectMediaPlayer = directPlayer;
                    }
                }
            }
        }
        public void ChooseLyricsLanguage(int index)
        {
            foreach (ToolStripMenuItem item in lyricsLanguageToolStripMenuItem.DropDownItems)
            {
                item.Checked = false;
            }
            currentFrameInDisplay = (SynchronisedLyricsFrame)lyricsLanguageToolStripMenuItem.DropDownItems[index].Tag;
            ((ToolStripMenuItem)lyricsLanguageToolStripMenuItem.DropDownItems[index]).Checked = true;
        }
        public void LoadFrames(SynchronisedLyricsFrame[] frames)
        {
            lyricsLanguageToolStripMenuItem.DropDownItems.Clear();
            bool isFirst = true;
            foreach (SynchronisedLyricsFrame sframe in frames)
            {
                ToolStripMenuItem item = new ToolStripMenuItem();
                item.Text = ID3FrameConsts.GetLanguage(sframe.LanguageID);
                if (item.Text == "")
                    item.Text = "Unknown";
                item.Tag = sframe;
                if (isFirst)
                {
                    isFirst = false;
                    item.Checked = true;
                    currentFrameInDisplay = (SynchronisedLyricsFrame)sframe;
                }
                lyricsLanguageToolStripMenuItem.DropDownItems.Add(item);
            }
        }
        public override void PlayMedia()
        {
            // axWindowsMediaPlayer1.Ctlcontrols.play();
            directPlayer.Play();
        }
        public override void StopMedia()
        {
            // axWindowsMediaPlayer1.Ctlcontrols.stop();
            directPlayer.Stop();
        }
        public override bool IsPlaying
        {
            get
            {
                // return axWindowsMediaPlayer1.playState == WMPLib.WMPPlayState.wmppsPlaying;
                return directPlayer.IsPlaying;
            }
        }
        // the timer
        private void timer1_Tick(object sender, EventArgs e)
        {
            if (currentFrameInDisplay == null)
            {
                label1.Text = "";
                return;
            }
            string text = "";
            int index = -1;
            foreach (SynchronisedLyricsItem item in currentFrameInDisplay.Items)
            {
                // if (axWindowsMediaPlayer1.Ctlcontrols.currentPosition <
                //     ((double)item.Time / 1000))
                if (directPlayer.Position < ((double)item.Time / 1000))
                {
                    break;
                }
                index++;
            }
            if (index >= 0)
            {
                text = currentFrameInDisplay.Items[index].Text;
            }
            label1.Text = text;
        }

        private void label1_TextChanged(object sender, EventArgs e)
        {
            label1.Visible = label1.Text.Length > 0;
        }
        private void lyricsLanguageToolStripMenuItem_DropDownItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            foreach (ToolStripMenuItem item in lyricsLanguageToolStripMenuItem.DropDownItems)
            {
                item.Checked = false;
                if (item == e.ClickedItem)
                {
                    item.Checked = true;
                    currentFrameInDisplay = (SynchronisedLyricsFrame)item.Tag;
                }
            }
        }
        private void C_MediaPlayer_VisibleChanged(object sender, EventArgs e)
        {
            if (this.Visible) StopMedia();
        }
        private void C_MediaPlayer_Paint(object sender, PaintEventArgs e)
        {
            imagePanel1.Invalidate();
        }
        private void C_MediaPlayer_Resize(object sender, EventArgs e)
        {
            imagePanel1.Invalidate();
        }
    }
}
