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
    public partial class C_QuickTagEditorV2 : EditorControl
    {
        public C_QuickTagEditorV2(StringCollection genreMemory, StringCollection artistsMemory, StringCollection albumsMemory)
        {
            InitializeComponent();
            DisableControls();
            // fill genre
            this.GenreMemory = genreMemory;
            comboBoxControl_Genre.comboBox1.Validated += comboBoxGenre_Validated;
            // artists
            this.ArtistsMemory = artistsMemory;
            comboBoxControl_artist.comboBox1.Validated += comboBoxArtists_Validated;
            // albums
            this.AlbumsMemory = albumsMemory;
            comboBoxControl_album.comboBox1.Validated += comboBoxAlbums_Validated;

            dateControl_year.dateTimePicker1.CustomFormat = "yyyy";
        }

        private bool SaveRatingRequired;

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

        private int ParseIntValue(string text)
        {
            int val = 0;
            if (int.TryParse(text, out val))
                return val;
            return 0;
        }
        private DateTime GetFromTimeStamp(string timeStamp)
        {
            /*The timestamp fields are based on a subset of ISO 8601. When being as
       precise as possible the format of a time string is
       yyyy-MM-ddTHH:mm:ss (year, "-", month, "-", day, "T", hour (out of
       24), ":", minutes, ":", seconds), but the precision may be reduced by
       removing as many time indicators as wanted. Hence valid timestamps
       are
       yyyy, yyyy-MM, yyyy-MM-dd, yyyy-MM-ddTHH, yyyy-MM-ddTHH:mm and
       yyyy-MM-ddTHH:mm:ss. All time stamps are UTC. For durations, use
       the slash character as described in 8601, and for multiple non-
       contiguous dates, use multiple strings, if allowed by the frame
       definition.*/
            int year = DateTime.Now.Year;
            int month = DateTime.Now.Month;
            int day = DateTime.Now.Day;
            int hour = DateTime.Now.Hour;
            int minute = DateTime.Now.Minute;
            int sec = DateTime.Now.Second;
            string[] code = timeStamp.Split(new char[] { '-', 'T', ':' }, StringSplitOptions.RemoveEmptyEntries);

            if (code.Length == 1)//yyyy
            {
                year = ParseIntValue(code[0]);
            }
            else if (code.Length == 2)//yyyy-MM
            {
                year = ParseIntValue(code[0]);
                month = ParseIntValue(code[1]);
            }
            else if (code.Length == 3)//yyyy-MM-dd
            {
                year = ParseIntValue(code[0]);
                month = ParseIntValue(code[1]);
                day = ParseIntValue(code[2]);
            }
            else if (code.Length == 4)//yyyy-MM-ddTHH
            {
                year = ParseIntValue(code[0]);
                month = ParseIntValue(code[1]);
                day = ParseIntValue(code[2]);
                hour = ParseIntValue(code[3]);
            }
            else if (code.Length == 5)//yyyy-MM-ddTHH:mm
            {
                year = ParseIntValue(code[0]);
                month = ParseIntValue(code[1]);
                day = ParseIntValue(code[2]);
                hour = ParseIntValue(code[3]);
                minute = ParseIntValue(code[4]);
            }
            else if (code.Length == 6)//yyyy-MM-ddTHH:mm:ss
            {
                year = ParseIntValue(code[0]);
                month = ParseIntValue(code[1]);
                day = ParseIntValue(code[2]);
                hour = ParseIntValue(code[3]);
                minute = ParseIntValue(code[4]);
                sec = ParseIntValue(code[5]);
            }
            try
            {
                return new DateTime(year, month, day, hour, minute, sec);
            }
            catch 
            {
                return DateTime.Now;
            }
        }
        private string GetTimeStampValue(DateTime time)
        {
            /*The timestamp fields are based on a subset of ISO 8601. When being as
       precise as possible the format of a time string is
       yyyy-MM-ddTHH:mm:ss (year, "-", month, "-", day, "T", hour (out of
       24), ":", minutes, ":", seconds), but the precision may be reduced by
       removing as many time indicators as wanted. Hence valid timestamps
       are
       yyyy, yyyy-MM, yyyy-MM-dd, yyyy-MM-ddTHH, yyyy-MM-ddTHH:mm and
       yyyy-MM-ddTHH:mm:ss. All time stamps are UTC. For durations, use
       the slash character as described in 8601, and for multiple non-
       contiguous dates, use multiple strings, if allowed by the frame
       definition.*/
            // let's use the full format yyyy-MM-ddTHH:mm:ss
            return time.Year.ToString("D4") + "-" + time.Month.ToString("D2") + "-" + time.Day.ToString("D2") + "T" +
                time.Hour.ToString("D2") + ":" + time.Minute.ToString("D2") + ":" + time.Second.ToString("D2");
        }
        private void ClearValues()
        {
            comboBoxControl_album.PropertyValue =
                comboBoxControl_artist.PropertyValue =
                textEditorControl_title.PropertyValue = "";
            textEditorControl_track.PropertyValue = "";
            dateControl_year.PropertyValue = DateTime.Now;
            ratingControl1.Rating = 0;
            richTextControl1.PropertyValue = "";
            imagePanel1.ImageToView = null;
            imagePanel1.DefaultStringToDraw = "No image.";
            imagePanel1.Invalidate();
            SaveRatingRequired = false;
            Label1.Text = "";
        }
        private void DisableControls()
        {
            ClearValues();
            toolStrip1.Enabled = panel1.Enabled = panel2.Enabled = false;
        }
        private void EnableControls()
        {
            toolStrip1.Enabled = panel1.Enabled = panel2.Enabled = true;
        }
        public void ReloadValues()
        {
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
            EnableControls();
            ClearValues();
            Label1.Text = "Edit " + files.Length+" file(s)";
            if (files.Length == 1)
            {
                // load id3 v2
                ID3v2 v2 = new ID3v2();
                if (v2.Load(files[0]) == Result.Success)
                {
                    if (v2.TagVersion.Major < 4)
                        dateControl_year.dateTimePicker1.CustomFormat = "yyyy";
                    else
                        dateControl_year.dateTimePicker1.CustomFormat = "yyyy-MM-dd; HH:mm:ss";
                    ID3v2QuickWrapper wr = new ID3v2QuickWrapper(v2);
                    comboBoxControl_album.PropertyValue = wr.Album;
                    comboBoxControl_artist.PropertyValue = wr.Artist;
                    comboBoxControl_Genre.PropertyValue = wr.Genre;
                    textEditorControl_title.PropertyValue = wr.Title;
                    textEditorControl_track.PropertyValue = wr.Track;
                    dateControl_year.PropertyValue = GetFromTimeStamp(wr.Year);
                    richTextControl1.PropertyValue = wr.Comment;
                    //rating
                    ratingControl1.Rating = wr.Rating / 51;
                    //image
                    AttachedPictureFrame frame;
                    if (v2.TagVersion.Major == 2)
                        frame = (AttachedPictureFrame)v2.GetFrameLoaded("PIC");
                    else
                        frame = (AttachedPictureFrame)v2.GetFrameLoaded("APIC");

                    if (frame == null)
                    {
                        imagePanel1.ImageToView = null;
                        imagePanel1.DefaultStringToDraw = "No image.";
                        imagePanel1.Invalidate();
                    }
                    else
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
                            imagePanel1.DefaultStringToDraw = "ERROR !";
                            imagePanel1.Invalidate();
                        }
                    }
                }
            }
            else
            {
                byte[] firstImageBuffer = new byte[0];
                for (int i = 0; i < files.Length; i++)
                {
                    ID3v2 v2 = new ID3v2();
                    if (v2.Load(files[i]) == Result.Success)
                    {
                        ID3v2QuickWrapper wr = new ID3v2QuickWrapper(v2);
                        if (i == 0)
                        {
                            if (v2.TagVersion.Major < 4)
                                dateControl_year.dateTimePicker1.CustomFormat = "yyyy";
                            else
                                dateControl_year.dateTimePicker1.CustomFormat = "yyyy-MM-dd; HH:mm:ss";
                            comboBoxControl_album.PropertyValue = wr.Album;
                            comboBoxControl_artist.PropertyValue = wr.Artist;
                            comboBoxControl_Genre.PropertyValue = wr.Genre;
                            textEditorControl_title.PropertyValue = wr.Title;
                            textEditorControl_track.PropertyValue = wr.Track;
                            dateControl_year.PropertyValue = GetFromTimeStamp(wr.Year);
                            richTextControl1.PropertyValue = wr.Comment;
                            //rating
                            ratingControl1.Rating = wr.Rating / 51;
                            //image
                            AttachedPictureFrame frame;
                            if (v2.TagVersion.Major == 2)
                                frame = (AttachedPictureFrame)v2.GetFrameLoaded("PIC");
                            else
                                frame = (AttachedPictureFrame)v2.GetFrameLoaded("APIC");

                            if (frame == null)
                            {
                                imagePanel1.ImageToView = null;
                                imagePanel1.DefaultStringToDraw = "No image.";
                                imagePanel1.Invalidate();
                            }
                            else
                            {
                                try
                                {
                                    firstImageBuffer = frame.PictureData;
                                    System.IO.Stream stream = new System.IO.MemoryStream(frame.PictureData);
                                    imagePanel1.ImageToView = new Bitmap(stream);
                                    imagePanel1.Invalidate();
                                }
                                catch
                                {
                                    imagePanel1.ImageToView = null;
                                    imagePanel1.DefaultStringToDraw = "ERROR !!";
                                    imagePanel1.Invalidate();
                                }
                            }
                        }
                        else
                        {
                            if (wr.Album != comboBoxControl_album.PropertyValue)
                                comboBoxControl_album.PropertyValue = "<Varies>";
                            if (wr.Artist != comboBoxControl_artist.PropertyValue)
                                comboBoxControl_artist.PropertyValue = "<Varies>";
                            if (wr.Genre != comboBoxControl_Genre.PropertyValue)
                                comboBoxControl_Genre.PropertyValue = "<Varies>";
                            if (wr.Title != textEditorControl_title.PropertyValue)
                                textEditorControl_title.PropertyValue = "<Varies>";
                            if (wr.Track != textEditorControl_track.PropertyValue)
                                textEditorControl_track.PropertyValue = "<Varies>";
                            if (wr.Comment != richTextControl1.PropertyValue)
                                richTextControl1.PropertyValue = "<Varies>";
                            if (wr.Rating / 51 != ratingControl1.Rating)
                                ratingControl1.Rating = 0;
                            // year field get filled once
                            dateControl_year.PropertyValue = GetFromTimeStamp(wr.Year);
                            AttachedPictureFrame frame;
                            if (v2.TagVersion.Major == 2)
                                frame = (AttachedPictureFrame)v2.GetFrameLoaded("PIC");
                            else
                                frame = (AttachedPictureFrame)v2.GetFrameLoaded("APIC");

                            if (frame == null)
                            {
                                imagePanel1.ImageToView = null;
                                imagePanel1.DefaultStringToDraw = "Multiple Images !!\nClick to manage.";
                                imagePanel1.Invalidate();
                            }
                            else
                            {
                                try
                                {
                                    if (firstImageBuffer.Length != frame.PictureData.Length)
                                    {
                                        imagePanel1.ImageToView = null;
                                        imagePanel1.DefaultStringToDraw = "Multiple Images !!\nClick to manage.";
                                        imagePanel1.Invalidate();
                                    }
                                    else
                                    {
                                        for (int j = 0; j < firstImageBuffer.Length; j++)
                                        {
                                            if (firstImageBuffer[j] != frame.PictureData[j])
                                            {
                                                imagePanel1.ImageToView = null;
                                                imagePanel1.DefaultStringToDraw = "Multiple Images !!\nClick to manage.";
                                                imagePanel1.Invalidate();
                                                break;
                                            }
                                        }
                                    }

                                    imagePanel1.Invalidate();
                                }
                                catch
                                {
                                    imagePanel1.ImageToView = null;
                                    imagePanel1.DefaultStringToDraw = "ERROR !!";
                                    imagePanel1.Invalidate();
                                }
                            }
                        }
                    }
                }
            }
        }
        private void SaveChanges(object sender, EventArgs e)
        {  
            // stop media and clear it
            OnClearMediaRequest();
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
            DebugLogger.WriteLine("Starting saving progress..");
            for (int i = 0; i < files.Length; i++)
            {
                DebugLogger.WriteLine("Saving file: " + files[i]);
                // load the original file. Success or not doesn't matter.
                ID3v2 v2 = new ID3v2();
                bool hadTag = v2.Load(files[i]) == Result.Success;

                // we need to make sure about version. If we are creating id3v2, use default version.
                if (!hadTag)
                    v2.TagVersion = new ID3Version((byte)ID3TagSettings.ID3V2Version, 0);
                // update/create values
                ID3v2QuickWrapper wr = new ID3v2QuickWrapper(v2);
                if (comboBoxControl_album.PropertyValue != "<Varies>")
                    wr.Album = comboBoxControl_album.PropertyValue;
                if (comboBoxControl_artist.PropertyValue != "<Varies>")
                    wr.Artist = comboBoxControl_artist.PropertyValue;
                if (richTextControl1.PropertyValue != "<Varies>")
                    wr.Comment = richTextControl1.PropertyValue;
                if (comboBoxControl_Genre.PropertyValue != "<Varies>")
                    wr.Genre = comboBoxControl_Genre.PropertyValue;
                if (textEditorControl_title.PropertyValue != "<Varies>")
                {
                    if (textEditorControl_title.PropertyValue.ToLower() == "<filename>")
                        wr.Title = Path.GetFileNameWithoutExtension(files[i]);
                    else
                        wr.Title = textEditorControl_title.PropertyValue;
                }
                if (textEditorControl_track.PropertyValue != "<Varies>")
                {
                    if (textEditorControl_track.PropertyValue.ToLower() == "<sequence>")
                        wr.Track = (i + 1).ToString();
                    else if (textEditorControl_track.PropertyValue.ToLower() == "<n/t>")
                        wr.Track = (i + 1).ToString() + "/" + files.Length;
                    else if (textEditorControl_track.PropertyValue.ToLower().Contains("<sequencestartwith>"))
                    {
                        string[] code = textEditorControl_track.PropertyValue.Split(new char[] { '(', ')' });
                        if (code.Length > 1)
                        {
                            int val = 0;
                            if (int.TryParse(code[1], out val))
                            {
                                wr.Track = (i + 1 + val).ToString();
                            }
                            else
                            {
                                wr.Track = textEditorControl_track.PropertyValue;
                            }
                        }
                        else
                        {
                            wr.Track = textEditorControl_track.PropertyValue;
                        }
                    }
                    else if (textEditorControl_track.PropertyValue.ToLower().Contains("<sn/t>"))
                    {
                        string[] code = textEditorControl_track.PropertyValue.Split(new char[] { '(', ')' });
                        if (code.Length > 1)
                        {
                            int val = 0;
                            if (int.TryParse(code[1], out val))
                            {
                                wr.Track = (i + 1 + val).ToString() + "/" + files.Length;
                            }
                            else
                            {
                                wr.Track = textEditorControl_track.PropertyValue;
                            }
                        }
                        else
                        {
                            wr.Track = textEditorControl_track.PropertyValue;
                        }
                    }
                    else
                        wr.Track = textEditorControl_track.PropertyValue;
                }
                if (v2.TagVersion.Major<4)
                    wr.Year = dateControl_year.PropertyValue.Year.ToString("D4");
                else
                    wr.Year =GetTimeStampValue( dateControl_year.PropertyValue);//this is the release time, not year so use full timestamp value
                //update rating
                if (SaveRatingRequired)
                {
                    wr.Rating = (byte)(ratingControl1.Rating * 51);
                }
                // save it !!
                // set flags
                v2.Compression = false;
                v2.Experimental = false;
                if (ID3TagSettings.DropExtendedHeader)
                    v2.ExtendedHeader = false;
                v2.Footer = ID3TagSettings.WriteFooter;
                v2.SavePadding = ID3TagSettings.KeepPadding;
                v2.Unsynchronisation = ID3TagSettings.UseUnsynchronisation;

                switch (v2.Save(files[i]))
                {
                    case Result.Failed: DebugLogger.WriteLine("Save failed !", DebugCode.Error); break;
                    case Result.Success: DebugLogger.WriteLine("Save success.", DebugCode.Good); break;
                }
                int x = ((i + 1) * 100) / files.Length;
                OnProgress("Saving .. " + x + "%", x);
            }
            OnProgress("Changes saved successfully.", 100);
            OnProgressFinish();

            OnUpdateRequired();

            OnReloadMediaRequest();
        }
        private void FullEdit(object sender, EventArgs e)
        {
            if (files == null)
            {
                MessageBox.Show("Please select file(s) first.");
                return;
            }
            if (files.Length == 0)
            {
                MessageBox.Show("Please select file(s) first.");
                return;
            }

            Frm_FullID3V2Edit edit = new Frm_FullID3V2Edit(files, GenreMemory, ArtistsMemory, AlbumsMemory);
            if (edit.ShowDialog(this)== DialogResult.OK)
            {
                OnUpdateRequired();
            }
        }
        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            ReloadValues();
        }
        public void DeleteSelected()
        { }
        public override void DisableSaving()
        {
            base.DisableSaving();
            toolStripButton1.Enabled = false;
        }
        public StringCollection GenreMemory
        {
            get
            {
                StringCollection collection = new StringCollection();

                foreach (string genre in comboBoxControl_Genre.comboBox1.Items)
                    collection.Add(genre);

                return collection;
            }
            set
            {
                comboBoxControl_Genre.comboBox1.Items.Clear();
                if (value != null)
                {
                    if (value.Count == 0)
                    {
                        foreach (string genre in ID3FrameConsts.Genres)
                            comboBoxControl_Genre.comboBox1.Items.Add(genre);
                    }
                    else
                    {
                        foreach (string genre in value)
                            comboBoxControl_Genre.comboBox1.Items.Add(genre);
                    }
                }
                else
                {
                    foreach (string genre in ID3FrameConsts.Genres)
                        comboBoxControl_Genre.comboBox1.Items.Add(genre);
                }
            }
        }
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

        private void ratingControl1_RatingChanged(object sender, EventArgs e)
        {
            SaveRatingRequired = true;
        }
        private void fileNameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            textEditorControl_title.PropertyValue = "<FileName>";
        }
        private void sequenceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            textEditorControl_track.PropertyValue = "<Sequence>";
        }
        private void nTToolStripMenuItem_Click(object sender, EventArgs e)
        {
            textEditorControl_track.PropertyValue = "<N/T>";
        }
        private void sequenceStartWithxToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Frm_EnterNumber frm = new Frm_EnterNumber();
            frm.Location = new Point(Cursor.Position.X - frm.Width, Cursor.Position.Y - frm.Height);

            if (frm.ShowDialog(this) == DialogResult.OK)
            {
                textEditorControl_track.PropertyValue = "<SequenceStartWith>(" + frm.EnteredNumber + ")";
            }
        }
        private void sNTxToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Frm_EnterNumber frm = new Frm_EnterNumber();
            frm.Location = new Point(Cursor.Position.X - frm.Width, Cursor.Position.Y - frm.Height);
            if (frm.ShowDialog(this) == DialogResult.OK)
            {
                textEditorControl_track.PropertyValue = "<SN/T>(" + frm.EnteredNumber + ")";
            }
        }
        private void comboBoxGenre_Validated(object sender, EventArgs e)
        {
            if (comboBoxControl_Genre.PropertyValue == "<Varies>" ||
                comboBoxControl_Genre.PropertyValue == "")
                return;

            if (!comboBoxControl_Genre.comboBox1.Items.Contains(comboBoxControl_Genre.PropertyValue))
            {
                comboBoxControl_Genre.comboBox1.Items.Add(comboBoxControl_Genre.PropertyValue);
                OnMemoryUpdate();
            }
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
        private void imagePanel1_Click(object sender, EventArgs e)
        {
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
            OnStopMediaRequest();
            Frm_ImagesManager frm = new Frm_ImagesManager(files);
            frm.ClearMediaRequest += frm_ClearMediaRequest;
            if (frm.ShowDialog(this) == DialogResult.OK)
            {
                // load image from first file since all file should had the same images
                // load id3 v2
                ID3v2 v2 = new ID3v2();
                if (v2.Load(files[0]) == Result.Success)
                {
                    //image
                    AttachedPictureFrame frame;
                    if (v2.TagVersion.Major == 2)
                        frame = (AttachedPictureFrame)v2.GetFrameLoaded("PIC");
                    else
                        frame = (AttachedPictureFrame)v2.GetFrameLoaded("APIC");

                    if (frame == null)
                        imagePanel1.ImageToView = null;
                    else
                    {
                        try
                        {
                            System.IO.Stream stream = new System.IO.MemoryStream(frame.PictureData);
                            imagePanel1.ImageToView = new Bitmap(stream);
                            imagePanel1.Invalidate();
                        }
                        catch { imagePanel1.ImageToView = null; }
                    }
                }
            }
        }
        private void frm_ClearMediaRequest(object sender, EventArgs e)
        {
            OnClearMediaRequest();
        }
        // fill fields from file
        private void toolStripLabel1_Click(object sender, EventArgs e)
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
                ID3v1 v1 = new ID3v1();
                if (v1.Load(files[0]) == Result.Success)
                {
                    textEditorControl_title.PropertyValue = v1.Title;
                    richTextControl1.PropertyValue = v1.Comment;
                    comboBoxControl_artist.PropertyValue = v1.Artist;
                    comboBoxControl_album.PropertyValue = v1.Album;
                    comboBoxControl_Genre.PropertyValue = v1.Genre;
                    dateControl_year.PropertyValue = GetFromTimeStamp(v1.Year);
                    textEditorControl_track.PropertyValue = v1.Track.ToString();
                }
                else
                {
                    MessageBox.Show("No id3v1 for this file.");
                }
            }
            else
            {
                Frm_SelectFile frm = new Frm_SelectFile(files);
                if (frm.ShowDialog(this) == DialogResult.OK)
                {
                    ID3v1 v1 = new ID3v1();
                    if (v1.Load(frm.SelectedFile) == Result.Success)
                    {
                        textEditorControl_title.PropertyValue = v1.Title;
                        richTextControl1.PropertyValue = v1.Comment;
                        comboBoxControl_artist.PropertyValue = v1.Artist;
                        comboBoxControl_album.PropertyValue = v1.Album;
                        comboBoxControl_Genre.PropertyValue = v1.Genre;
                        dateControl_year.PropertyValue = GetFromTimeStamp(v1.Year);
                        textEditorControl_track.PropertyValue = v1.Track.ToString();
                    }
                    else
                    {
                        MessageBox.Show("No id3v1 for this file.");
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
                ID3v1 v1 = new ID3v1();
                if (v1.Load(files[0]) == Result.Success)
                {
                    textEditorControl_track.PropertyValue = v1.Track.ToString();
                }
                else
                {
                    MessageBox.Show("No id3v1 for this file.");
                }
            }
            else
            {
                Frm_SelectFile frm = new Frm_SelectFile(files);
                if (frm.ShowDialog(this) == DialogResult.OK)
                {
                    ID3v1 v1 = new ID3v1();
                    if (v1.Load(frm.SelectedFile) == Result.Success)
                    {
                        textEditorControl_track.PropertyValue = v1.Track.ToString();
                    }
                    else
                    {
                        MessageBox.Show("No id3v1 for this file.");
                    }
                }
            }
        }
        private void textEditorControl_year_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
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
                ID3v1 v1 = new ID3v1();
                if (v1.Load(files[0]) == Result.Success)
                {
                    dateControl_year.PropertyValue = GetFromTimeStamp(v1.Year);
                }
                else
                {
                    MessageBox.Show("No id3v1 for this file.");
                }
            }
            else
            {
                Frm_SelectFile frm = new Frm_SelectFile(files);
                if (frm.ShowDialog(this) == DialogResult.OK)
                {
                    ID3v1 v1 = new ID3v1();
                    if (v1.Load(frm.SelectedFile) == Result.Success)
                    {
                        dateControl_year.PropertyValue = GetFromTimeStamp(v1.Year);
                    }
                    else
                    {
                        MessageBox.Show("No id3v1 for this file.");
                    }
                }
            }
        }
        private void comboBoxControl_Genre_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
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
                ID3v1 v1 = new ID3v1();
                if (v1.Load(files[0]) == Result.Success)
                {
                    comboBoxControl_Genre.PropertyValue = v1.Genre;
                }
                else
                {
                    MessageBox.Show("No id3v1 for this file.");
                }
            }
            else
            {
                Frm_SelectFile frm = new Frm_SelectFile(files);
                if (frm.ShowDialog(this) == DialogResult.OK)
                {
                    ID3v1 v1 = new ID3v1();
                    if (v1.Load(frm.SelectedFile) == Result.Success)
                    {
                        comboBoxControl_Genre.PropertyValue = v1.Genre;
                    }
                    else
                    {
                        MessageBox.Show("No id3v1 for this file.");
                    }
                }
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
                ID3v1 v1 = new ID3v1();
                if (v1.Load(files[0]) == Result.Success)
                {
                    textEditorControl_title.PropertyValue = v1.Title;
                }
                else
                {
                    MessageBox.Show("No id3v1 for this file.");
                }
            }
            else
            {
                Frm_SelectFile frm = new Frm_SelectFile(files);
                if (frm.ShowDialog(this) == DialogResult.OK)
                {
                    ID3v1 v1 = new ID3v1();
                    if (v1.Load(frm.SelectedFile) == Result.Success)
                    {
                        textEditorControl_title.PropertyValue = v1.Title;
                    }
                    else
                    {
                        MessageBox.Show("No id3v1 for this file.");
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
                ID3v1 v1 = new ID3v1();
                if (v1.Load(files[0]) == Result.Success)
                {
                    comboBoxControl_artist.PropertyValue = v1.Artist;
                }
                else
                {
                    MessageBox.Show("No id3v1 for this file.");
                }
            }
            else
            {
                Frm_SelectFile frm = new Frm_SelectFile(files);
                if (frm.ShowDialog(this) == DialogResult.OK)
                {
                    ID3v1 v1 = new ID3v1();
                    if (v1.Load(frm.SelectedFile) == Result.Success)
                    {
                        comboBoxControl_artist.PropertyValue = v1.Artist;
                    }
                    else
                    {
                        MessageBox.Show("No id3v1 for this file.");
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
                ID3v1 v1 = new ID3v1();
                if (v1.Load(files[0]) == Result.Success)
                {
                    comboBoxControl_album.PropertyValue = v1.Album;
                }
                else
                {
                    MessageBox.Show("No id3v1 for this file.");
                }
            }
            else
            {
                Frm_SelectFile frm = new Frm_SelectFile(files);
                if (frm.ShowDialog(this) == DialogResult.OK)
                {
                    ID3v1 v1 = new ID3v1();
                    if (v1.Load(frm.SelectedFile) == Result.Success)
                    {
                        comboBoxControl_album.PropertyValue = v1.Album;
                    }
                    else
                    {
                        MessageBox.Show("No id3v1 for this file.");
                    }
                }
            }
        }
        private void richTextControl1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
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
                ID3v1 v1 = new ID3v1();
                if (v1.Load(files[0]) == Result.Success)
                {
                    richTextControl1.PropertyValue = v1.Comment;
                }
                else
                {
                    MessageBox.Show("No id3v1 for this file.");
                }
            }
            else
            {
                Frm_SelectFile frm = new Frm_SelectFile(files);
                if (frm.ShowDialog(this) == DialogResult.OK)
                {
                    ID3v1 v1 = new ID3v1();
                    if (v1.Load(frm.SelectedFile) == Result.Success)
                    {
                        richTextControl1.PropertyValue = v1.Comment;
                    }
                    else
                    {
                        MessageBox.Show("No id3v1 for this file.");
                    }
                }
            }
        }
    }
}
