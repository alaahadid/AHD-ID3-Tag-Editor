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
using AHD.SM.Formats;
using AHD.SM.ASMP;
using AHD.ID3;
using AHD.ID3.Types;
using AHD.ID3.Frames;
using AHD.ID3.Editor.Base;

namespace AHD.ID3.Editor.GUI
{
    public partial class Frm_ExportSubtitlesFormat : Form
    {
        public Frm_ExportSubtitlesFormat(SynchronisedLyricsFrame frame)
        {
            this.frame = frame;
            InitializeComponent();
            // install supported formats
            SubtitleFormats.DetectSupportedFormats(true, true);
            foreach (SubtitlesFormat format in SubtitleFormats.Formats)
            {
                listBox1.Items.Add(format);
            }
            listBox1.SelectedIndex = 0;
            // setup encodings
            infos = Encoding.GetEncodings();
            foreach (EncodingInfo inf in infos)
            {
                comboBox1.Items.Add(inf.DisplayName + " (" + inf.Name + ") [" + inf.CodePage + "]");
            }
            comboBox1.SelectedIndex = comboBox1.Items.Count - 1;
        }
        private SynchronisedLyricsFrame frame;
        private EncodingInfo[] infos;
        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            richTextBox1.Text = "";
            panel1.Controls.Clear();
            if (listBox1.SelectedIndex < 0)
                return;
            SubtitlesFormat format = (SubtitlesFormat)listBox1.SelectedItem;
            richTextBox1.Text = format.Description;
            if (format.HasOptions)
            {
                format.OptionsControl.Location = new Point(0, 0);
                panel1.Controls.Add(format.OptionsControl);
            }
        }
        // save
        private void button1_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex < 0)
            {
                MessageBox.Show("Please select subtitles format first");
                return;
            }
            if (comboBox1.SelectedIndex < 0)
            {
                MessageBox.Show("Please select write encoding first");
                return;
            }
            SubtitlesFormat format = (SubtitlesFormat)listBox1.SelectedItem;
            SaveFileDialog sav = new SaveFileDialog();
            sav.Title = "Export to " + format.Name + " format";
            sav.Filter = format.GetFilter();
            if (sav.ShowDialog(this) == System.Windows.Forms.DialogResult.OK)
            {
                Encoding enc = Encoding.GetEncoding(infos[comboBox1.SelectedIndex].CodePage);
                // create a track with subtitles
                SubtitlesTrack track = new SubtitlesTrack("");
                for (int i = 0; i < frame.Items.Count;i++ )
                {
                    Subtitle sub = new Subtitle();
                    sub.StartTime = (double)frame.Items[i].Time / 1000;
                    if (i != frame.Items.Count - 1)
                    {
                        sub.EndTime = ((double)frame.Items[i + 1].Time / 1000) - 0.001;
                    }
                    else
                        sub.EndTime = sub.StartTime + 2;
                    sub.Text = SubtitleText.FromString(frame.Items[i].Text);
                    track.Subtitles.Add(sub);
                }
                format.SubtitleTrack = track;
                format.Save(sav.FileName, enc);
                MessageBox.Show("Done !");
                this.Close();
            }
        }
    }
}
