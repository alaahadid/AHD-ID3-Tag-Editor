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
using System.Collections.Specialized;
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
    public partial class C_QuickTagEditorV1 : EditorControl
    {
        public C_QuickTagEditorV1(StringCollection artistsMemory, StringCollection albumsMemory)
        {
            InitializeComponent();
            this.Enabled = false;

            // fill genre
            foreach (string genre in ID3FrameConsts.Genres)
                comboBoxControl_genre.comboBox1.Items.Add(genre);
            comboBoxControl_genre.comboBox1.SelectedIndex = 0;
            comboBoxControl_genre.comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
            // artists
            this.ArtistsMemory = artistsMemory;
            comboBoxControl_artist.comboBox1.Validated += comboBoxArtists_Validated;
            // albums
            this.AlbumsMemory = albumsMemory;
            comboBoxControl_album.comboBox1.Validated += comboBoxAlbums_Validated;

            // set maximum chars count
            textEditorControl_comment.textBox1.MaxLength = 30;
            textEditorControl_title.textBox1.MaxLength = 30;
            comboBoxControl_album.comboBox1.MaxLength = 30;
            comboBoxControl_artist.comboBox1.MaxLength = 30;
        }

        public override string[] SelectedFiles
        {
            get
            {
                return base.SelectedFiles;
            }
            set
            {
                base.SelectedFiles = value; ReloadValues();
            }
        }

        private void ClearValues()
        {
            textEditorControl_comment.PropertyValue =
                comboBoxControl_album.PropertyValue =
                comboBoxControl_artist.PropertyValue =
                textEditorControl_title.PropertyValue = "";
            textEditorControl_track.PropertyValue = "";
            comboBoxControl_genre.comboBox1.SelectedIndex = -1;
            numberControl_year.PropertyValue = 2013;
            Label1.Text = "";
        }
        public void ReloadValues()
        {
            ClearValues();
            if (files == null)
            {
                this.Enabled = false;
                return;
            }
            if (files.Length == 0)
            {
                this.Enabled = false;
                return;
            }
            this.Enabled = true;
            bool first = false;
            Label1.Text = "Edit " + files.Length + " file(s)";
            foreach (string file in files)
            {
                if (!first)
                {
                    first = true;
                    ID3v1 v1 = new ID3v1();
                    if (v1.Load(file) == Result.Success)
                    {
                        textEditorControl_comment.PropertyValue = v1.Comment;
                        textEditorControl_title.PropertyValue = v1.Title;
                        comboBoxControl_album.PropertyValue = v1.Album;
                        comboBoxControl_artist.PropertyValue = v1.Artist;
                        comboBoxControl_genre.PropertyValue = v1.Genre;
                        textEditorControl_track.PropertyValue = v1.Track.ToString();
                        int year = 0;
                        if (int.TryParse(v1.Year, out year))
                            numberControl_year.PropertyValue = year;
                        else
                            numberControl_year.PropertyValue = 0;
                    }
                }
                else
                {
                    ID3v1 v1 = new ID3v1();
                    if (v1.Load(file) == Result.Success)
                    {
                        if (v1.Comment != textEditorControl_comment.PropertyValue)
                            textEditorControl_comment.PropertyValue = "<Varies>";
                        if (v1.Title != textEditorControl_title.PropertyValue)
                            textEditorControl_title.PropertyValue = "<Varies>";
                        if (v1.Album != comboBoxControl_album.PropertyValue)
                            comboBoxControl_album.PropertyValue = "<Varies>";
                        if (v1.Artist != comboBoxControl_artist.PropertyValue)
                            comboBoxControl_artist.PropertyValue = "<Varies>";
                        if (v1.Genre != comboBoxControl_genre.PropertyValue)
                            comboBoxControl_genre.PropertyValue = "<Varies>";
                        if (v1.Track.ToString() != textEditorControl_track.PropertyValue)
                            textEditorControl_track.PropertyValue = "<Varies>";
                        int year = 0;
                        if (int.TryParse(v1.Year, out year))
                        {
                            if (year != numberControl_year.PropertyValue)
                                numberControl_year.PropertyValue = 0;
                        }
                    }
                }
            }
        }
        private void SaveChanges(object sender, EventArgs e)
        {
            if (files == null)
            {
                MessageBox.Show("No file selected !!");
                return;
            }
            if (files.Length == 0)
            {
                MessageBox.Show("No file selected !!");
                return;
            }
            OnProgressStart();
            // stop media and clear it
            OnClearMediaRequest();
            for (int i = 0; i < files.Length; i++)
            {
                ID3v1 v1 = new ID3v1();
                v1.Load(files[i]);// load file first for feilds

                //save values
                if (textEditorControl_comment.PropertyValue != "<Varies>")
                    v1.Comment = textEditorControl_comment.PropertyValue;
                if (textEditorControl_title.PropertyValue != "<Varies>")
                {
                    if (textEditorControl_title.PropertyValue.ToLower() == "<filename>")
                        v1.Title = Path.GetFileNameWithoutExtension(files[i]);
                    else
                        v1.Title = textEditorControl_title.PropertyValue;
                }
                if (comboBoxControl_album.PropertyValue != "<Varies>")
                    v1.Album = comboBoxControl_album.PropertyValue;
                if (comboBoxControl_artist.PropertyValue != "<Varies>")
                    v1.Artist = comboBoxControl_artist.PropertyValue;
                v1.Genre = comboBoxControl_genre.PropertyValue;
                if (textEditorControl_track.PropertyValue != "<Varies>")
                {
                    if (textEditorControl_track.PropertyValue.ToLower() == "<sequence>")
                        v1.Track = (byte)(i + 1);
                    else if (textEditorControl_track.PropertyValue.ToLower().Contains("<sequencestartwith>"))
                    {
                        string[] code = textEditorControl_track.PropertyValue.Split(new char[] { '(', ')' });
                        if (code.Length > 1)
                        {
                            int val = 0;
                            if (int.TryParse(code[1], out val))
                            {
                                v1.Track = (byte)(i + 1 + val);
                            }
                            else
                            {
                                byte trk = 0;
                                if (byte.TryParse(textEditorControl_track.PropertyValue, out trk))
                                    v1.Track = trk;
                            }
                        }
                        else
                        {
                            byte trk = 0;
                            if (byte.TryParse(textEditorControl_track.PropertyValue, out trk))
                                v1.Track = trk;
                        }
                    }
                    else
                    {
                        byte trk = 0;
                        if (byte.TryParse(textEditorControl_track.PropertyValue, out trk))
                            v1.Track = trk;
                    }
                }
                v1.Year = ((int)numberControl_year.PropertyValue).ToString("D4");

                v1.Save(files[i]);
                int x = ((i + 1) * 100) / files.Length;
                OnProgress("Saving .. " + x + "%", x);
            }
            OnProgress("Changes saved successfuly.", 100);
            OnProgressFinish();

            OnUpdateRequired();

            OnReloadMediaRequest();
        }
        public void DeleteSelected()
        { }
        public StringCollection ArtistsMemory
        {
            get
            {
                StringCollection collection = new StringCollection();

                foreach (string artist in comboBoxControl_artist.comboBox1.Items)
                    collection.Add(artist);

                return collection;
            }
            set
            {
                comboBoxControl_artist.comboBox1.Items.Clear();
                if (value != null)
                    foreach (string artist in value)
                        comboBoxControl_artist.comboBox1.Items.Add(artist);
            }
        }
        public StringCollection AlbumsMemory
        {
            get
            {
                StringCollection collection = new StringCollection();

                foreach (string album in comboBoxControl_album.comboBox1.Items)
                    collection.Add(album);

                return collection;
            }
            set
            {
                comboBoxControl_album.comboBox1.Items.Clear();
                if (value != null)
                    foreach (string album in value)
                        comboBoxControl_album.comboBox1.Items.Add(album);
            }
        }
        public override void DisableSaving()
        {
            base.DisableSaving();
            toolStripButton1.Enabled = false;
        }
        public override void LoadTag(ID3v1 v1)
        {
            this.Enabled = true; 
            Label1.Text = "";
            textEditorControl_comment.PropertyValue = v1.Comment;
            textEditorControl_title.PropertyValue = v1.Title;
            comboBoxControl_album.PropertyValue = v1.Album;
            comboBoxControl_artist.PropertyValue = v1.Artist;
            comboBoxControl_genre.PropertyValue = v1.Genre;
            textEditorControl_track.PropertyValue = v1.Track.ToString();
            int year = 0;
            if (int.TryParse(v1.Year, out year))
                numberControl_year.PropertyValue = year;
            else
                numberControl_year.PropertyValue = 0;
        }
        public override void SaveTag(ID3v1 v1)
        {
            //save values
            if (textEditorControl_comment.PropertyValue != "<Varies>")
                v1.Comment = textEditorControl_comment.PropertyValue;
            if (textEditorControl_title.PropertyValue != "<Varies>")
            {
                if (textEditorControl_title.PropertyValue.ToLower() == "<filename>")
                    v1.Title = Path.GetFileNameWithoutExtension(files[0]);
                else
                    v1.Title = textEditorControl_title.PropertyValue;
            }
            if (comboBoxControl_album.PropertyValue != "<Varies>")
                v1.Album = comboBoxControl_album.PropertyValue;
            if (comboBoxControl_artist.PropertyValue != "<Varies>")
                v1.Artist = comboBoxControl_artist.PropertyValue;
            v1.Genre = comboBoxControl_genre.PropertyValue;
            if (textEditorControl_track.PropertyValue != "<Varies>")
            {
                if (textEditorControl_track.PropertyValue.ToLower() == "<sequence>")
                    v1.Track = (byte)(0 + 1);
                else if (textEditorControl_track.PropertyValue.ToLower().Contains("<sequencestartwith>"))
                {
                    string[] code = textEditorControl_track.PropertyValue.Split(new char[] { '(', ')' });
                    if (code.Length > 1)
                    {
                        int val = 0;
                        if (int.TryParse(code[1], out val))
                        {
                            v1.Track = (byte)(0 + 1 + val);
                        }
                        else
                        {
                            byte trk = 0;
                            if (byte.TryParse(textEditorControl_track.PropertyValue, out trk))
                                v1.Track = trk;
                        }
                    }
                    else
                    {
                        byte trk = 0;
                        if (byte.TryParse(textEditorControl_track.PropertyValue, out trk))
                            v1.Track = trk;
                    }
                }
                else
                {
                    byte trk = 0;
                    if (byte.TryParse(textEditorControl_track.PropertyValue, out trk))
                        v1.Track = trk;
                }
            }
            v1.Year = ((int)numberControl_year.PropertyValue).ToString("D4");
        }
        private void comboBoxArtists_Validated(object sender, EventArgs e)
        {
            if (comboBoxControl_artist.PropertyValue == "<Varies>" ||
             comboBoxControl_artist.PropertyValue == "")
                return;
            if (!comboBoxControl_artist.comboBox1.Items.Contains(comboBoxControl_artist.PropertyValue))
            {
                comboBoxControl_artist.comboBox1.Items.Add(comboBoxControl_artist.PropertyValue);
                OnMemoryUpdate();
            }
        }
        private void comboBoxAlbums_Validated(object sender, EventArgs e)
        {
            if (comboBoxControl_album.PropertyValue == "<Varies>" ||
            comboBoxControl_album.PropertyValue == "")
                return;
            if (!comboBoxControl_album.comboBox1.Items.Contains(comboBoxControl_album.PropertyValue))
            {
                comboBoxControl_album.comboBox1.Items.Add(comboBoxControl_album.PropertyValue);
                OnMemoryUpdate();
            }
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            ReloadValues();
        }
        private void fileNameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            textEditorControl_title.PropertyValue = "<FileName>";
        }
        private void sequenceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            textEditorControl_track.PropertyValue = "<Sequence>";
        }
        private void sequenceStartWithxToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Frm_EnterNumber frm = new Frm_EnterNumber();
            frm.Location = new Point(Cursor.Position.X - frm.Width, Cursor.Position.Y - frm.Height);
            frm.numericUpDown1.Maximum = 255;
            if (frm.ShowDialog(this) == DialogResult.OK)
            {
                textEditorControl_track.PropertyValue = "<SequenceStartWith>(" + frm.EnteredNumber + ")";
            }
        }

        private void textEditorControl_title_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (files == null)
            {
                return;
            }
            if (files.Length == 0)
            {
                return;
            }
            if (files.Length == 1)
            {
                ID3v2 v2 = new ID3v2();
                if (v2.Load(files[0]) == Result.Success)
                {
                    ID3v2QuickWrapper wr = new ID3v2QuickWrapper(v2);
                    textEditorControl_title.PropertyValue = wr.Title;
                }
                else
                {
                    MessageBox.Show("No id3v2 for this file.");
                }
            }
            else
            {
                Frm_SelectFile frm = new Frm_SelectFile(files);
                if (frm.ShowDialog(this) == DialogResult.OK)
                {
                    ID3v2 v2 = new ID3v2();
                    if (v2.Load(frm.SelectedFile) == Result.Success)
                    {
                        ID3v2QuickWrapper wr = new ID3v2QuickWrapper(v2);
                        textEditorControl_title.PropertyValue = wr.Title;
                    }
                    else
                    {
                        MessageBox.Show("No id3v2 for this file.");
                    }
                }
            }
        }
        private void comboBoxControl_artist_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (files == null)
            {
                return;
            }
            if (files.Length == 0)
            {
                return;
            }
            if (files.Length == 1)
            {
                ID3v2 v2 = new ID3v2();
                if (v2.Load(files[0]) == Result.Success)
                {
                    ID3v2QuickWrapper wr = new ID3v2QuickWrapper(v2);
                    comboBoxControl_artist.PropertyValue = wr.Artist;
                }
                else
                {
                    MessageBox.Show("No id3v2 for this file.");
                }
            }
            else
            {
                Frm_SelectFile frm = new Frm_SelectFile(files);
                if (frm.ShowDialog(this) == DialogResult.OK)
                {
                    ID3v2 v2 = new ID3v2();
                    if (v2.Load(frm.SelectedFile) == Result.Success)
                    {
                        ID3v2QuickWrapper wr = new ID3v2QuickWrapper(v2);
                        comboBoxControl_artist.PropertyValue = wr.Artist;
                    }
                    else
                    {
                        MessageBox.Show("No id3v2 for this file.");
                    }
                }
            }
        }
        private void comboBoxControl_album_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (files == null)
            {
                return;
            }
            if (files.Length == 0)
            {
                return;
            }
            if (files.Length == 1)
            {
                ID3v2 v2 = new ID3v2();
                if (v2.Load(files[0]) == Result.Success)
                {
                    ID3v2QuickWrapper wr = new ID3v2QuickWrapper(v2);
                    comboBoxControl_album.PropertyValue = wr.Album;
                }
                else
                {
                    MessageBox.Show("No id3v2 for this file.");
                }
            }
            else
            {
                Frm_SelectFile frm = new Frm_SelectFile(files);
                if (frm.ShowDialog(this) == DialogResult.OK)
                {
                    ID3v2 v2 = new ID3v2();
                    if (v2.Load(frm.SelectedFile) == Result.Success)
                    {
                        ID3v2QuickWrapper wr = new ID3v2QuickWrapper(v2);
                        comboBoxControl_album.PropertyValue = wr.Album;
                    }
                    else
                    {
                        MessageBox.Show("No id3v2 for this file.");
                    }
                }
            }
        }
        private void comboBoxControl_genre_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (files == null)
            {
                return;
            }
            if (files.Length == 0)
            {
                return;
            }
            if (files.Length == 1)
            {
                ID3v2 v2 = new ID3v2();
                if (v2.Load(files[0]) == Result.Success)
                {
                    ID3v2QuickWrapper wr = new ID3v2QuickWrapper(v2);
                    comboBoxControl_genre.PropertyValue = wr.Genre;
                }
                else
                {
                    MessageBox.Show("No id3v2 for this file.");
                }
            }
            else
            {
                Frm_SelectFile frm = new Frm_SelectFile(files);
                if (frm.ShowDialog(this) == DialogResult.OK)
                {
                    ID3v2 v2 = new ID3v2();
                    if (v2.Load(frm.SelectedFile) == Result.Success)
                    {
                        ID3v2QuickWrapper wr = new ID3v2QuickWrapper(v2);
                        comboBoxControl_genre.PropertyValue = wr.Genre;
                    }
                    else
                    {
                        MessageBox.Show("No id3v2 for this file.");
                    }
                }
            }
        }
        private void numberControl_year_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (files == null)
            {
                return;
            }
            if (files.Length == 0)
            {
                return;
            }
            if (files.Length == 1)
            {
                ID3v2 v2 = new ID3v2();
                if (v2.Load(files[0]) == Result.Success)
                {
                    ID3v2QuickWrapper wr = new ID3v2QuickWrapper(v2);
                    int year = 0;
                    if (int.TryParse(wr.Year, out year))
                        numberControl_year.PropertyValue = year;
                }
                else
                {
                    MessageBox.Show("No id3v2 for this file.");
                }
            }
            else
            {
                Frm_SelectFile frm = new Frm_SelectFile(files);
                if (frm.ShowDialog(this) == DialogResult.OK)
                {
                    ID3v2 v2 = new ID3v2();
                    if (v2.Load(frm.SelectedFile) == Result.Success)
                    {
                        ID3v2QuickWrapper wr = new ID3v2QuickWrapper(v2);
                        int year = 0;
                        if (int.TryParse(wr.Year, out year))
                            numberControl_year.PropertyValue = year;
                    }
                    else
                    {
                        MessageBox.Show("No id3v2 for this file.");
                    }
                }
            }
        }
        private void textEditorControl_track_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (files == null)
            {
                return;
            }
            if (files.Length == 0)
            {
                return;
            }
            if (files.Length == 1)
            {
                ID3v2 v2 = new ID3v2();
                if (v2.Load(files[0]) == Result.Success)
                {
                    ID3v2QuickWrapper wr = new ID3v2QuickWrapper(v2);
                    textEditorControl_track.PropertyValue = wr.Track;
                }
                else
                {
                    MessageBox.Show("No id3v2 for this file.");
                }
            }
            else
            {
                Frm_SelectFile frm = new Frm_SelectFile(files);
                if (frm.ShowDialog(this) == DialogResult.OK)
                {
                    ID3v2 v2 = new ID3v2();
                    if (v2.Load(frm.SelectedFile) == Result.Success)
                    {
                        ID3v2QuickWrapper wr = new ID3v2QuickWrapper(v2);
                        textEditorControl_track.PropertyValue = wr.Track;
                    }
                    else
                    {
                        MessageBox.Show("No id3v2 for this file.");
                    }
                }
            }
        }
        private void textEditorControl_comment_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (files == null)
            {
                return;
            }
            if (files.Length == 0)
            {
                return;
            }
            if (files.Length == 1)
            {
                ID3v2 v2 = new ID3v2();
                if (v2.Load(files[0]) == Result.Success)
                {
                    ID3v2QuickWrapper wr = new ID3v2QuickWrapper(v2);
                    textEditorControl_comment.PropertyValue = wr.Comment;
                }
                else
                {
                    MessageBox.Show("No id3v2 for this file.");
                }
            }
            else
            {
                Frm_SelectFile frm = new Frm_SelectFile(files);
                if (frm.ShowDialog(this) == DialogResult.OK)
                {
                    ID3v2 v2 = new ID3v2();
                    if (v2.Load(frm.SelectedFile) == Result.Success)
                    {
                        ID3v2QuickWrapper wr = new ID3v2QuickWrapper(v2);
                        textEditorControl_comment.PropertyValue = wr.Comment;
                    }
                    else
                    {
                        MessageBox.Show("No id3v2 for this file.");
                    }
                }
            }
        }
        // fill fields from id3v2
        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            if (files == null)
            {
                return;
            }
            if (files.Length == 0)
            {
                return;
            }
            if (files.Length == 1)
            {
                ID3v2 v2 = new ID3v2();
                if (v2.Load(files[0]) == Result.Success)
                {
                    ID3v2QuickWrapper wr = new ID3v2QuickWrapper(v2);
                    textEditorControl_title.PropertyValue = wr.Title;
                    textEditorControl_comment.PropertyValue = wr.Comment;
                    comboBoxControl_artist.PropertyValue = wr.Artist;
                    comboBoxControl_album.PropertyValue = wr.Album;
                    comboBoxControl_genre.PropertyValue = wr.Genre;
                    int year = 0;
                    if (int.TryParse(wr.Year, out year))
                        numberControl_year.PropertyValue = year;
                    textEditorControl_track.PropertyValue = wr.Track;
                }
                else
                {
                    MessageBox.Show("No id3v2 for this file.");
                }
            }
            else
            {
                Frm_SelectFile frm = new Frm_SelectFile(files);
                if (frm.ShowDialog(this) == DialogResult.OK)
                {
                    ID3v2 v2 = new ID3v2();
                    if (v2.Load(frm.SelectedFile) == Result.Success)
                    {
                        ID3v2QuickWrapper wr = new ID3v2QuickWrapper(v2);
                        textEditorControl_title.PropertyValue = wr.Title;
                        textEditorControl_comment.PropertyValue = wr.Comment;
                        comboBoxControl_artist.PropertyValue = wr.Artist;
                        comboBoxControl_album.PropertyValue = wr.Album;
                        comboBoxControl_genre.PropertyValue = wr.Genre;
                        int year = 0;
                        if (int.TryParse(wr.Year, out year))
                            numberControl_year.PropertyValue = year;
                        textEditorControl_track.PropertyValue = wr.Track;
                    }
                    else
                    {
                        MessageBox.Show("No id3v2 for this file.");
                    }
                }
            }
        }
    }
}
