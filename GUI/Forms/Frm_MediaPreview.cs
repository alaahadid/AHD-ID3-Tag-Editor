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
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AHD.ID3.Editor.GUI
{
    public partial class Frm_MediaPreview : Form
    {
        public Frm_MediaPreview(string mediaPath, AHD.ID3.Frames.SynchronisedLyricsFrame[] frames)
        {
            InitializeComponent();
            mediaPlayer = new C_MediaPlayer(false);
            this.Controls.Add(mediaPlayer);
            mediaPlayer.Dock = DockStyle.Fill;

            // load file
            mediaPlayer.SelectedFiles = new string[] { mediaPath };
            // load synch lyrics frames
            mediaPlayer.LoadFrames(frames);
            mediaPlayer.PlayMedia();
        }
        private C_MediaPlayer mediaPlayer;

        private void Frm_MediaPreview_FormClosing(object sender, FormClosingEventArgs e)
        {
            mediaPlayer.Dispose();
        }
    }
}
