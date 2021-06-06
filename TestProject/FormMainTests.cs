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
 * 
 * Author email: mailto:alaahadidfreeware@gmail.com
 * 
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
using AHD.ID3;
using AHD.ID3.Frames;
using AHD.ID3.Types;
using AHD.MP3;
namespace TestProject
{
    public partial class FormMainTests : Form
    {
        public FormMainTests(string[] args)
        {
            InitializeComponent();
            foreach (string genre in ID3v1.GenreList)
                comboBox1.Items.Add(genre);
            comboBox_newVersion.Items.Add((byte)2);
            comboBox_newVersion.Items.Add((byte)3);
            comboBox_newVersion.Items.Add((byte)4);
            comboBox_newVersion.SelectedIndex = 0;
            FramesManager.InstallFrames();
            foreach (string frame in FramesManager.FramesV2.Keys)
            {
                if (!comboBox_new_frame.Items.Contains(frame))
                    comboBox_new_frame.Items.Add(frame);
            }
            foreach (string frame in FramesManager.FramesV3.Keys)
            {
                if (!comboBox_new_frame.Items.Contains(frame))
                    comboBox_new_frame.Items.Add(frame);
            }
            foreach (string frame in FramesManager.FramesV4.Keys)
            {
                if (!comboBox_new_frame.Items.Contains(frame))
                    comboBox_new_frame.Items.Add(frame);
            }
            comboBox_new_frame.SelectedIndex = 0;
        }
        ID3v2 v2;
        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog op = new OpenFileDialog();
            op.Filter = "mp3 (*mp3)|*.mp3";
            if (op.ShowDialog(this) == System.Windows.Forms.DialogResult.OK)
            {
                ID3v1 v1 = new ID3v1();
                v1.Progress += v1_Progress;
                Result result = v1.Load(op.FileName);
                switch (result)
                {
                    case Result.Failed: MessageBox.Show("Unable to load this file"); break;
                    case Result.NoID3Exist: MessageBox.Show("No ID3v1 found in this file"); break;
                    case Result.Success:
                        textBox_album.Text = v1.Album;
                        textBox_artist.Text = v1.Artist;
                        textBox_comment.Text = v1.Comment;
                        textBox_title.Text = v1.Title;
                        textBox_year.Text = v1.Year;
                        numericUpDown1.Value = v1.Track;
                        comboBox1.SelectedItem = v1.Genre;
                        break;
                }
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            SaveFileDialog sav = new SaveFileDialog();
            sav.Filter = "mp3 (*mp3)|*.mp3";
            if (sav.ShowDialog(this) == System.Windows.Forms.DialogResult.OK)
            {
                ID3v1 v1 = new ID3v1();
                v1.Progress += v1_Progress;
                v1.Album = textBox_album.Text;
                v1.Artist = textBox_artist.Text;
                v1.Comment = textBox_comment.Text;
                v1.Title = textBox_title.Text;
                v1.Year = textBox_year.Text;
                v1.Track = (byte)numericUpDown1.Value;
                v1.Genre = comboBox1.SelectedItem.ToString();
                switch (v1.Save(sav.FileName))
                {
                    case Result.Failed: MessageBox.Show("Unable to save this file"); break;
                }
            }
        }
        void v1_Progress(object sender, ProgressArg e)
        {
            label_status.Text = e.Status; label_status.Refresh();
            progressBar1.Value = e.Progress; progressBar1.Refresh();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            OpenFileDialog op = new OpenFileDialog();
            op.Filter = "mp3 (*mp3)|*.mp3";
            if (op.ShowDialog(this) == System.Windows.Forms.DialogResult.OK)
            {
                ID3v1.Clear(op.FileName);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            OpenFileDialog op = new OpenFileDialog();
            op.Filter = "mp3 (*mp3)|*.mp3";
            if (op.ShowDialog(this) == System.Windows.Forms.DialogResult.OK)
            {
                v2 = new ID3v2();
                v2.Progress += v1_Progress;
                switch (v2.Load(op.FileName))
                {
                    case Result.Failed: MessageBox.Show("Unable to load this file"); break;
                    case Result.NoID3Exist: MessageBox.Show("No ID3v2 found in this file"); break;
                    case Result.NotCompatibleVersion: MessageBox.Show("This version of ID3v2 is not compatible with this library."); break;
                    case Result.Success:
                        listView1.Items.Clear();
                        textBox_tagsize.Text = v2.TagSize.ToString() + " Bytes";
                        textBox1.Text = v2.TagVersion.ToString();
                        textBox_padding.Text = v2.PaddingSize.ToString() + " Bytes";
                        checkBox_extendedheader.Checked = v2.ExtendedHeader;
                        checkBox_unsynchronisation.Checked = v2.Unsynchronisation;
                        checkBox_Experimental.Checked = v2.Experimental;
                        foreach (ID3TagFrame frame in v2.Frames)
                        {
                            ListViewItem item = new ListViewItem();
                            item.Text = frame.Name;
                            item.SubItems.Add(frame.ID);
                            item.SubItems.Add(frame.Type);
                            item.SubItems.Add(frame.Size.ToString() + " Bytes");
                            if (frame is TextFrame)
                                item.SubItems.Add(((TextFrame)frame).Text);
                            listView1.Items.Add(item);
                        }
                        break;
                }
                // mp3 header test
                MP3Info info = new MP3Info(op.FileName);
                propertyGrid1.SelectedObject = info;
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            SaveFileDialog sav = new SaveFileDialog();
            sav.Filter = "mp3 (*mp3)|*.mp3";
            if (sav.ShowDialog(this) == System.Windows.Forms.DialogResult.OK)
            {
                v2.ExtendedHeader = checkBox_extendedheader.Checked;
                v2.Experimental = checkBox_Experimental.Checked;
                v2.Unsynchronisation = checkBox_unsynchronisation.Checked;
                switch (v2.Save(sav.FileName))
                {
                    case Result.Failed: MessageBox.Show("Unable to save this file"); break;
                }
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count != 1) return;
            if (v2.Frames[listView1.SelectedItems[0].Index] is TextFrame)
            { 
                ((TextFrame)v2.Frames[listView1.SelectedItems[0].Index]).Text = textBox2.Text;
                listView1.SelectedItems[0].SubItems[4].Text = textBox2.Text;
            }
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count != 1) return;
            if (v2.Frames[listView1.SelectedItems[0].Index] is TextFrame)
            {
                textBox2.Visible = true;
                textBox2.Text = ((TextFrame)v2.Frames[listView1.SelectedItems[0].Index]).Text;
            }
            else
            {
                textBox2.Visible = false;
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            SaveFileDialog sav = new SaveFileDialog();
            sav.Filter = "mp3 (*mp3)|*.mp3";
            if (sav.ShowDialog(this) == System.Windows.Forms.DialogResult.OK)
            {
                v2 = new ID3v2();
                v2.Progress += v1_Progress;
                v2.TagVersion = new ID3Version((byte)comboBox_newVersion.SelectedItem, 0);
                v2.ExtendedHeader = checkBox_new_extended.Checked;
                v2.Experimental = checkBox_new_Experimental.Checked;
                v2.Unsynchronisation = checkBox_new_Unsynchronisation.Checked;
                v2.Frames = new List<ID3TagFrame>();
                foreach (ListViewItem item in listView_newFrames.Items)
                {
                    v2.Frames.Add((ID3TagFrame)item.Tag);
                }
                switch (v2.Save(sav.FileName))
                {
                    case Result.Failed: MessageBox.Show("Unable to save this file"); break;
                }
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            TextFrame frame = new TextFrame(comboBox_new_frame.SelectedItem.ToString(), "??", null, 0);
            frame.Text = textBox_new_Text.Text;

            ListViewItem item = new ListViewItem();
            item.Tag = frame;
            item.Text = "New frame";
            item.SubItems.Add(comboBox_new_frame.SelectedItem.ToString());
            item.SubItems.Add(frame.Size.ToString()); 
            item.SubItems.Add("Text frame");
            item.SubItems.Add(textBox_new_Text.Text);
            listView_newFrames.Items.Add(item);
        }
    }
}
