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
namespace TestProject
{
    public partial class FormFrameTests : Form
    {
        public FormFrameTests(string[] args)
        {
            InitializeComponent();
            comboBox_tagVersion.Items.Add((byte)2);
            comboBox_tagVersion.Items.Add((byte)3);
            comboBox_tagVersion.Items.Add((byte)4);

            comboBox_tagVersion.SelectedIndex = 1;//3

            tabControl1.SelectedIndex = tabControl1.TabCount - 1;// select the latest frame we are working on

            // events
            foreach (string code in ID3FrameConsts.EventTimingCodesEvents)
            {
                Column_EventTimingCodes.Items.Add(code);
            }
            // language
            foreach (string lang in ID3FrameConsts.Languages)
            {
                comboBox_UnsynchronisedLyrics_language.Items.Add(lang);
                comboBox_syncLyrics_Language.Items.Add(lang); 
                comboBox_comments_language.Items.Add(lang);
            }  
            // content type
            foreach (string type in ID3FrameConsts.SynchronisedLyricsContentTypes)
            {
                comboBox_syncLyrics_contentType.Items.Add(type);
            }  
            // picture types
            foreach (string type in ID3FrameConsts.PictureTypes)
            {
                comboBox_picType.Items.Add(type);
            }

            foreach (string type in ID3FrameConsts.CommercialReceivedAs)
                comboBox_ReceivedAs.Items.Add(type);
            comboBox_ReceivedAs.SelectedIndex = comboBox_price.SelectedIndex = 0;
        }
        CommercialFrame Cframe;
        void RefreshFrames(byte version)
        {
            dataGridView1.Rows.Clear();
            dataGridView_UserDefinedTextInformationFrames.Rows.Clear();
            listBox_OwnerIdentifierFrames.Items.Clear();

            dataGridView_urlFrames.Rows.Clear();
            switch (version)
            {
                case 2:
                    foreach (ID3TagFrame frame in FramesManager.FramesV2.Values)
                    {
                        if (frame is TextFrame)
                            dataGridView1.Rows.Add(new object[] { FramesManager.GetFrameVersion2(frame.ID,null),
                                ((TextFrame)frame).Text });
                        if (frame is URLLinkFrame)
                            dataGridView_urlFrames.Rows.Add(new object[] { FramesManager.GetFrameVersion2(frame.ID,null),
                                ((URLLinkFrame)frame).URL });
                    }
                    break;
                case 3:
                    foreach (ID3TagFrame frame in FramesManager.FramesV3.Values)
                    {
                        if (frame is TextFrame)
                            dataGridView1.Rows.Add(new object[] { FramesManager.GetFrameVersion3(frame.ID,null,0),
                                ((TextFrame)frame).Text });
                        if (frame is URLLinkFrame)
                            dataGridView_urlFrames.Rows.Add(new object[] { FramesManager.GetFrameVersion3(frame.ID,null,0),
                                ((URLLinkFrame)frame).URL });
                    }
                    break;
                case 4:
                    foreach (ID3TagFrame frame in FramesManager.FramesV4.Values)
                    {
                        if (frame is TextFrame)
                            dataGridView1.Rows.Add(new object[] { FramesManager.GetFrameVersion4(frame.ID,null,0),
                                ((TextFrame)frame).Text });
                        if (frame is URLLinkFrame)
                            dataGridView_urlFrames.Rows.Add(new object[] { FramesManager.GetFrameVersion4(frame.ID,null,0),
                                ((URLLinkFrame)frame).URL });
                    }
                    break;
            }
        }

        private void comboBox_tagVersion_SelectedIndexChanged(object sender, EventArgs e)
        {
            RefreshFrames((byte)comboBox_tagVersion.SelectedItem);
            checkBox_Experimental.Enabled = checkBox_extendedheader.Enabled = (byte)comboBox_tagVersion.SelectedItem > 2;
        }

        private void dataGridView1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            TextFrame frame = ((TextFrame)dataGridView1.Rows[e.RowIndex].Cells[0].Value);
            if (dataGridView1.Rows[e.RowIndex].Cells[1].Value == null)
            {
                frame.Text = "";
            }
            else
            {
                frame.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            }
        }
        // open
        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog op = new OpenFileDialog();
            op.Filter = "mp3 (*mp3)|*.mp3";
            if (op.ShowDialog(this) == System.Windows.Forms.DialogResult.OK)
            {
                ID3v2 v2 = new ID3v2();
                switch (v2.Load(op.FileName))
                {
                    case Result.Failed:
                        MessageBox.Show("Unable to load this file");
                        listBox1.Items.Add("Unable to load this file");
                        break;
                    case Result.NoID3Exist:
                        MessageBox.Show("No ID3v2 found in this file");
                        listBox1.Items.Add("No ID3v2 found in this file");
                        break;
                    case Result.NotCompatibleVersion:
                        MessageBox.Show("This version of ID3v2 is not compatible with this library.");
                        listBox1.Items.Add("This version of ID3v2 is not compatible with this library.");
                        break;
                    case Result.Success:
                        // set version
                        comboBox_tagVersion.SelectedItem = v2.TagVersion.Major;
                        // values
                        numericUpDown_tagsize.Value = v2.TagSize;
                        numericUpDown_padding.Value = v2.PaddingSize;
                        checkBox_extendedheader.Checked = v2.ExtendedHeader;
                        checkBox_unsynchronisation.Checked = v2.Unsynchronisation;
                        checkBox_Experimental.Checked = v2.Experimental;
                        listBox1.Items.Add("Warning: Extended header dropped. if you want to include extended header, you should create a new one.");
                        listBox1.Items.Add("Load success..");
                        // now frames installed, refresh ..
                        // text frames ...
                        for (int i = 0; i < dataGridView1.Rows.Count; i++)
                        {
                            TextFrame frameInGrid = ((TextFrame)dataGridView1.Rows[i].Cells[0].Value);
                            for (int j = 0; j < v2.Frames.Count; j++)
                            {
                                if (v2.Frames[j] is TextFrame)
                                {
                                    if (v2.Frames[j].ID == frameInGrid.ID)
                                    {
                                        frameInGrid.Text = ((TextFrame)v2.Frames[j]).Text;
                                        dataGridView1.Rows[i].Cells[1].Value = ((TextFrame)v2.Frames[j]).Text;
                                        v2.Frames.RemoveAt(j);// we don't need this anymore ...
                                        j--;
                                    }
                                }
                            }
                        }
                        // Owner Identifier frames, User defined text information, User defined url link frames, involved people list
                        // Event timings codes, Unsynchronised lyrics
                        listBox_OwnerIdentifierFrames.Items.Clear();
                        listBox_musicCD.Items.Clear();
                        dataGridView_UserDefinedTextInformationFrames.Rows.Clear();
                        dataGridView_UserDefinedURLLinkFrames.Rows.Clear();
                        dataGridView_involvedPeopleList.Rows.Clear();
                        dataGridView_eventTimingCode.Rows.Clear();
                        listBox_UnsynchronisedLyrics.Items.Clear();
                        listBox_syncLyrics.Items.Clear();
                        listBox_comments.Items.Clear();
                        listBox_pic.Items.Clear();
                        listBox_GEOB.Items.Clear();
                        listBox_Popularimeter.Items.Clear();
                        for (int i = 0; i < v2.Frames.Count; i++)
                        {
                            if (v2.Frames[i] is CommercialFrame)
                            {
                                Cframe = (CommercialFrame)v2.Frames[i];
                                v2.Frames.RemoveAt(i);
                                i--;
                                // load data
                                if (Cframe != null)
                                {
                                    textBox_price.Text = Cframe.Price;
                                    textBox_Description.Text = Cframe.Description;
                                    textBox_NameOfSeller.Text = Cframe.NameOfSeller;
                                    textBox_url.Text = Cframe.ContactURL;
                                    comboBox_ReceivedAs.SelectedItem = Cframe.ReceivedAs;
                                    comboBox_price.SelectedItem = Cframe.Currency;
                                    dateTimePicker1.Value = new DateTime(int.Parse(Cframe.ValidUntil.Substring(0, 4)),
                                        int.Parse(Cframe.ValidUntil.Substring(4, 2)), int.Parse(Cframe.ValidUntil.Substring(6, 2)));
                                    //image
                                    if (Cframe.SellerLogoData != null)
                                    {
                                        if (Cframe.SellerLogoData.Length > 0)
                                        {
                                            System.IO.Stream stream = new System.IO.MemoryStream(Cframe.SellerLogoData);
                                            pictureBox2.Image = new Bitmap(stream);

                                            //pic info
                                            label_picInfo.Text = "";
                                            label_picInfo.Text += "MIME: " + Cframe.PictureMIMEType + "\n";
                                            label_picInfo.Text += "Size: " + ((double)Cframe.SellerLogoData.Length / 1024).ToString("F2") + " KB\n";
                                            label_picInfo.Text += "Image Size: " + pictureBox2.Image.Size.Width + " x " + pictureBox2.Image.Size.Height + "\n";
                                        }
                                    }
                                }
                            }
                            else if (v2.Frames[i] is UniqueFileIdentifierFrame)
                            {
                                listBox_OwnerIdentifierFrames.Items.Add(v2.Frames[i]);
                                v2.Frames.RemoveAt(i);
                                i--;
                            }
                            else if (v2.Frames[i] is MusicCDIdentifierFrame)
                            {
                                listBox_musicCD.Items.Add(v2.Frames[i]);
                                v2.Frames.RemoveAt(i);
                                i--;
                            }
                            else if (v2.Frames[i] is PopularimeterFrame)
                            {
                                listBox_Popularimeter.Items.Add(v2.Frames[i]);
                                v2.Frames.RemoveAt(i);
                                i--;
                            }
                            else if (v2.Frames[i] is GeneralEncapsulatedObjectFrame)
                            {
                                listBox_GEOB.Items.Add(v2.Frames[i]);
                                v2.Frames.RemoveAt(i);
                                i--;
                            }
                            else if (v2.Frames[i] is UnsychronisedLyricsFrame)
                            {
                                listBox_UnsynchronisedLyrics.Items.Add(v2.Frames[i]);
                                v2.Frames.RemoveAt(i);
                                i--;
                            }
                            else if (v2.Frames[i] is SynchronisedLyricsFrame)
                            {
                                listBox_syncLyrics.Items.Add(v2.Frames[i]);
                                v2.Frames.RemoveAt(i);
                                i--;
                            }
                            else if (v2.Frames[i] is CommentsFrame)
                            {
                                listBox_comments.Items.Add(v2.Frames[i]);
                                v2.Frames.RemoveAt(i);
                                i--;
                            }
                            else if (v2.Frames[i] is AttachedPictureFrame)
                            {
                                listBox_pic.Items.Add(v2.Frames[i]);
                                v2.Frames.RemoveAt(i);
                                i--;
                            }
                            else if (v2.Frames[i] is UserDefinedTextInformationFrame)
                            {
                                UserDefinedTextInformationFrame frm = (UserDefinedTextInformationFrame)v2.Frames[i];
                                dataGridView_UserDefinedTextInformationFrames.Rows.Add(new object[] { frm.Description, frm.Text });
                                v2.Frames.RemoveAt(i);
                                i--;
                            }
                            else if (v2.Frames[i] is UserDefinedURLLinkFrame)
                            {
                                UserDefinedURLLinkFrame frm = (UserDefinedURLLinkFrame)v2.Frames[i];
                                dataGridView_UserDefinedURLLinkFrames.Rows.Add(new object[] { frm.Description, frm.URL });
                                v2.Frames.RemoveAt(i);
                                i--;
                            }
                            else if (v2.Frames[i] is InvolvedPeopleListFrame)
                            {
                                InvolvedPeopleListFrame frm = (InvolvedPeopleListFrame)v2.Frames[i];
                                foreach (InvolvedPeopleItem item in frm.PeopleList)
                                    dataGridView_involvedPeopleList.Rows.Add(new object[] { item.Involvement, item.Involvee });
                                v2.Frames.RemoveAt(i);
                                i--;
                            }
                            else if (v2.Frames[i] is EventTimingCodesFrame)
                            {
                                EventTimingCodesFrame frm = (EventTimingCodesFrame)v2.Frames[i];
                                foreach (EventTimingItem item in frm.Items)
                                {
                                    double time = item.Time;
                                    string timeText = time.ToString();
                                    if (frm.TimeStamp == TimeStampFormat.AbsoluteMilliseconds)
                                    {
                                        time /= 1000;
                                        timeText = time.ToString("F3");
                                    }
                                    dataGridView_eventTimingCode.Rows.Add(new object[] { timeText,
                                        ID3FrameConsts.GetEventTimingEvent( item.EventType) });
                                }
                                v2.Frames.RemoveAt(i);
                                i--;
                            }
                        }
                        // urls
                        for (int i = 0; i < dataGridView_urlFrames.Rows.Count; i++)
                        {
                            URLLinkFrame frameInGrid = ((URLLinkFrame)dataGridView_urlFrames.Rows[i].Cells[0].Value);
                            for (int j = 0; j < v2.Frames.Count; j++)
                            {
                                if (v2.Frames[j] is URLLinkFrame)
                                {
                                    if (v2.Frames[j].ID == frameInGrid.ID)
                                    {
                                        frameInGrid.URL = ((URLLinkFrame)v2.Frames[j]).URL;
                                        dataGridView_urlFrames.Rows[i].Cells[1].Value = ((URLLinkFrame)v2.Frames[j]).URL;
                                        v2.Frames.RemoveAt(j);// we don't need this anymore ...
                                        j--;
                                    }
                                }
                            }
                        }
                        break;
                }
            }
        }
        // save
        private void button2_Click(object sender, EventArgs e)
        {
            SaveFileDialog sav = new SaveFileDialog();
            sav.Filter = "mp3 (*mp3)|*.mp3";
            if (sav.ShowDialog(this) == System.Windows.Forms.DialogResult.OK)
            {
                ID3v2 v2 = new ID3v2();
                v2.TagVersion = new ID3Version((byte)comboBox_tagVersion.SelectedItem, 0);
                v2.PaddingSize = (int)numericUpDown_padding.Value;
                v2.ExtendedHeader = checkBox_extendedheader.Checked;
                v2.Experimental = checkBox_Experimental.Checked;
                v2.Unsynchronisation = checkBox_unsynchronisation.Checked;
                // add frames
                v2.Frames = new List<ID3TagFrame>();
                // text frames
                for (int i = 0; i < dataGridView1.Rows.Count; i++)
                {
                    TextFrame frameInGrid = ((TextFrame)dataGridView1.Rows[i].Cells[0].Value);
                    if (frameInGrid != null)
                        if (frameInGrid.Text != "")
                            v2.Frames.Add(frameInGrid);
                }
                // url frames
                for (int i = 0; i < dataGridView_urlFrames.Rows.Count; i++)
                {
                    URLLinkFrame frameInGrid = ((URLLinkFrame)dataGridView_urlFrames.Rows[i].Cells[0].Value);
                    if (frameInGrid != null)
                        if (frameInGrid.URL != "")
                            v2.Frames.Add(frameInGrid);
                }
                // Owner Identifier frames
                for (int i = 0; i < listBox_OwnerIdentifierFrames.Items.Count; i++)
                {
                    v2.Frames.Add((UniqueFileIdentifierFrame)listBox_OwnerIdentifierFrames.Items[i]);
                }
                // General Encapsulated Object Frame
                for (int i = 0; i < listBox_GEOB.Items.Count; i++)
                {
                    v2.Frames.Add((GeneralEncapsulatedObjectFrame)listBox_GEOB.Items[i]);
                }
                // Music CD Identifier Frame
                for (int i = 0; i < listBox_musicCD.Items.Count; i++)
                {
                    v2.Frames.Add((MusicCDIdentifierFrame)listBox_musicCD.Items[i]);
                }
                // Popularimeter Frame
                for (int i = 0; i < listBox_Popularimeter.Items.Count; i++)
                {
                    v2.Frames.Add((PopularimeterFrame)listBox_Popularimeter.Items[i]);
                }
                // Unsychronised Lyrics Frame
                for (int i = 0; i < listBox_UnsynchronisedLyrics.Items.Count; i++)
                {
                    v2.Frames.Add((UnsychronisedLyricsFrame)listBox_UnsynchronisedLyrics.Items[i]);
                }
                // Synchronised Lyrics Frame
                for (int i = 0; i < listBox_syncLyrics.Items.Count; i++)
                {
                    v2.Frames.Add((SynchronisedLyricsFrame)listBox_syncLyrics.Items[i]);
                }
                // Comments
                for (int i = 0; i < listBox_comments.Items.Count; i++)
                {
                    v2.Frames.Add((CommentsFrame)listBox_comments.Items[i]);
                }
                // Attached Picture Frame
                for (int i = 0; i < listBox_pic.Items.Count; i++)
                {
                    v2.Frames.Add((AttachedPictureFrame)listBox_pic.Items[i]);
                }
                // user defined text information
                for (int i = 0; i < dataGridView_UserDefinedTextInformationFrames.Rows.Count; i++)
                {
                    if (dataGridView_UserDefinedTextInformationFrames.Rows[i].Cells[0].Value != null &&
                        dataGridView_UserDefinedTextInformationFrames.Rows[i].Cells[1].Value != null)
                    {
                        //UserDefinedTextInformationFrame frame = new UserDefinedTextInformationFrame("TXXX", "", null, 0);
                        UserDefinedTextInformationFrame frame = (UserDefinedTextInformationFrame)FramesManager.GetFrame(v2.TagVersion,
                            typeof(UserDefinedTextInformationFrame));
                        frame.Description = dataGridView_UserDefinedTextInformationFrames.Rows[i].Cells[0].Value.ToString();
                        frame.Text = dataGridView_UserDefinedTextInformationFrames.Rows[i].Cells[1].Value.ToString();

                        v2.Frames.Add(frame);
                    }
                }
                // user defined url link frames
                for (int i = 0; i < dataGridView_UserDefinedURLLinkFrames.Rows.Count; i++)
                {
                    if (dataGridView_UserDefinedURLLinkFrames.Rows[i].Cells[0].Value != null &&
                        dataGridView_UserDefinedURLLinkFrames.Rows[i].Cells[1].Value != null)
                    {
                        //UserDefinedURLLinkFrame frame = new UserDefinedURLLinkFrame("WXXX", "", null, 0);
                        UserDefinedURLLinkFrame frame = (UserDefinedURLLinkFrame)FramesManager.GetFrame(v2.TagVersion,
                        typeof(UserDefinedURLLinkFrame));
                        frame.Description = dataGridView_UserDefinedURLLinkFrames.Rows[i].Cells[0].Value.ToString();
                        frame.URL = dataGridView_UserDefinedURLLinkFrames.Rows[i].Cells[1].Value.ToString();

                        v2.Frames.Add(frame);
                    }
                }
                //involved people list
                if (dataGridView_involvedPeopleList.Rows.Count > 0)
                {
                    //InvolvedPeopleListFrame frame = new InvolvedPeopleListFrame("IPLS", "", null, 0);
                    InvolvedPeopleListFrame frame = (InvolvedPeopleListFrame)FramesManager.GetFrame(v2.TagVersion,
                 typeof(InvolvedPeopleListFrame));
                    frame.PeopleList = new List<InvolvedPeopleItem>();
                    for (int i = 0; i < dataGridView_involvedPeopleList.Rows.Count; i++)
                    {
                        if (dataGridView_involvedPeopleList.Rows[i].Cells[0].Value != null &&
                            dataGridView_involvedPeopleList.Rows[i].Cells[1].Value != null)
                        {
                            frame.PeopleList.Add(new InvolvedPeopleItem(dataGridView_involvedPeopleList.Rows[i].Cells[0].Value.ToString(),
                                dataGridView_involvedPeopleList.Rows[i].Cells[1].Value.ToString()));
                        }
                    }
                    v2.Frames.Add(frame);
                }
                //event timing codes
                if (dataGridView_eventTimingCode.Rows.Count > 0)
                {
                    EventTimingCodesFrame frame = (EventTimingCodesFrame)FramesManager.GetFrame(v2.TagVersion,
                 typeof(EventTimingCodesFrame));
                    frame.TimeStamp = TimeStampFormat.AbsoluteMilliseconds;
                    frame.Items = new List<EventTimingItem>();
                    for (int i = 0; i < dataGridView_eventTimingCode.Rows.Count; i++)
                    {
                        if (dataGridView_eventTimingCode.Rows[i].Cells[0].Value != null &&
                            dataGridView_eventTimingCode.Rows[i].Cells[1].Value != null)
                        {
                            double time = double.Parse(dataGridView_eventTimingCode.Rows[i].Cells[0].Value.ToString());
                            time *= 1000;
                            frame.Items.Add(new EventTimingItem((int)time,
                             ID3FrameConsts.GetEventTimingEventIndex(dataGridView_eventTimingCode.Rows[i].Cells[1].Value.ToString())));
                        }
                    }
                    v2.Frames.Add(frame);
                }
                if (Cframe != null)
                    v2.Frames.Add(Cframe);
                // save
                switch (v2.Save(sav.FileName))
                {
                    case Result.Failed:
                        MessageBox.Show("Unable to save this file");
                        listBox1.Items.Add("Unable to save this file");
                        break;
                    case Result.Success: listBox1.Items.Add("Save success.."); break;
                }
            }
        }

        private void listBox_OwnerIdentifierFrames_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBox_OwnerIdentifierFrames.SelectedIndex < 0)
                return;
            UniqueFileIdentifierFrame frame = (UniqueFileIdentifierFrame)listBox_OwnerIdentifierFrames.SelectedItem;
            textBox_OwnerIdentifier.Text = frame.OwnerIdentifier;
            string text = "";
            for (int i = 0; i < frame.Identifier.Length; i++)
            {
                text += string.Format("{0:X}", frame.Identifier[i]);
            }
            richTextBox_ownerIdentfierData.Text = text;
        }

        private void textBox_OwnerIdentifier_TextChanged(object sender, EventArgs e)
        {
            if (listBox_OwnerIdentifierFrames.SelectedIndex < 0)
                return;
            UniqueFileIdentifierFrame frame = (UniqueFileIdentifierFrame)listBox_OwnerIdentifierFrames.SelectedItem;
            frame.OwnerIdentifier = textBox_OwnerIdentifier.Text;
            listBox_OwnerIdentifierFrames.Refresh();
        }

        private void dataGridView_urlFrames_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            URLLinkFrame frame = ((URLLinkFrame)dataGridView_urlFrames.Rows[e.RowIndex].Cells[0].Value);
            if (dataGridView_urlFrames.Rows[e.RowIndex].Cells[1].Value == null)
            {
                frame.URL = "";
            }
            else
            {
                frame.URL = dataGridView_urlFrames.Rows[e.RowIndex].Cells[1].Value.ToString();
            }
        }

        private void listBox_musicCD_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBox_musicCD.SelectedIndex < 0)
                return;
            MusicCDIdentifierFrame frame = (MusicCDIdentifierFrame)listBox_musicCD.SelectedItem;
            string text = "";
            for (int i = 0; i < frame.Data.Length; i++)
            {
                text += string.Format("{0:X}", frame.Data[i]);
            }
            richTextBox_musicCD.Text = text;
        }

        private void listBox_UnsynchronisedLyrics_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBox_UnsynchronisedLyrics.SelectedIndex < 0)
                return;
            UnsychronisedLyricsFrame frame = (UnsychronisedLyricsFrame)listBox_UnsynchronisedLyrics.SelectedItem;

            comboBox_UnsynchronisedLyrics_language.SelectedItem = ID3FrameConsts.GetLanguage(frame.LanguageID.ToUpper());
            textBox_UnsynchronisedLyrics_ContentDescriptor.Text = frame.ContentDescriptor;
            richTextBox_unsncLyrics_text.Text = frame.LyricsText;
        }

        private void textBox_UnsynchronisedLyrics_ContentDescriptor_TextChanged(object sender, EventArgs e)
        {
            if (listBox_UnsynchronisedLyrics.SelectedIndex < 0)
                return;
            UnsychronisedLyricsFrame frame = (UnsychronisedLyricsFrame)listBox_UnsynchronisedLyrics.SelectedItem;
            frame.ContentDescriptor = textBox_UnsynchronisedLyrics_ContentDescriptor.Text;
        }

        private void comboBox_UnsynchronisedLyrics_language_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBox_UnsynchronisedLyrics.SelectedIndex < 0)
                return;
            if (comboBox_UnsynchronisedLyrics_language.SelectedIndex < 0)
                return;
            UnsychronisedLyricsFrame frame = (UnsychronisedLyricsFrame)listBox_UnsynchronisedLyrics.SelectedItem;
            frame.LanguageID = ID3FrameConsts.GetLanguageID(comboBox_UnsynchronisedLyrics_language.SelectedItem.ToString());
        }

        private void button10_Click(object sender, EventArgs e)
        {
            UnsychronisedLyricsFrame frame = (UnsychronisedLyricsFrame)FramesManager.GetFrame(new ID3Version((byte)comboBox_tagVersion.SelectedItem, 0), 
                typeof(UnsychronisedLyricsFrame));
            frame.LanguageID = "ENG";
            listBox_UnsynchronisedLyrics.Items.Add(frame);
        }

        private void button11_Click(object sender, EventArgs e)
        {
            if (listBox_UnsynchronisedLyrics.SelectedIndex>=0)
            listBox_UnsynchronisedLyrics.Items.RemoveAt(listBox_UnsynchronisedLyrics.SelectedIndex);
        }

        private void richTextBox_unsncLyrics_text_TextChanged(object sender, EventArgs e)
        {
            if (listBox_UnsynchronisedLyrics.SelectedIndex < 0)
                return;
            UnsychronisedLyricsFrame frame = (UnsychronisedLyricsFrame)listBox_UnsynchronisedLyrics.SelectedItem;
            frame.LyricsText = richTextBox_unsncLyrics_text.Text;
        }

        private void listBox_syncLyrics_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBox_syncLyrics.SelectedIndex < 0)
                return;
            SynchronisedLyricsFrame frame = (SynchronisedLyricsFrame)listBox_syncLyrics.SelectedItem;

            comboBox_syncLyrics_Language.SelectedItem = ID3FrameConsts.GetLanguage(frame.LanguageID.ToUpper());
            textBox_syncLyrics_contentDescriptor.Text = frame.ContentDescriptor;
            comboBox_syncLyrics_contentType.SelectedItem = frame.ContentType;

            dataGridView_syncLyrics_items.Rows.Clear();
            foreach (SynchronisedLyricsItem item in frame.Items)
            {
                double time = item.Time;
                time /= 1000;
                dataGridView_syncLyrics_items.Rows.Add(new object[] { time.ToString("F3"), item.Text });
            }
        }

        private void listBox_comments_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBox_comments.SelectedIndex < 0)
                return;
            CommentsFrame frame = (CommentsFrame)listBox_comments.SelectedItem;

            comboBox_comments_language.SelectedItem = ID3FrameConsts.GetLanguage(frame.LanguageID.ToUpper());
            textBox_comments_descr.Text = frame.ContentDescriptor;
            richTextBox_comments_text.Text = frame.Text;
        }

        private void listBox_pic_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBox_pic.SelectedIndex < 0)
                return;
            AttachedPictureFrame frame = (AttachedPictureFrame)listBox_pic.SelectedItem;

            textBox_pic_mime.Text = frame.MIME;
            textBox_pic_Description.Text = frame.Description;
            comboBox_picType.SelectedItem = frame.PictureType;

            System.IO.Stream stream = new System.IO.MemoryStream(frame.PictureData);
            pictureBox1.Image = new Bitmap(stream);
        }

        private void listBox_GEOB_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBox_GEOB.SelectedIndex < 0)
                return;
            GeneralEncapsulatedObjectFrame frame = (GeneralEncapsulatedObjectFrame)listBox_GEOB.SelectedItem;

            textBox_geob_contentDescription.Text = frame.Description;
            textBox_geob_filename.Text = frame.FileName;
            textBox_geob_mime.Text = frame.MIME;

            string text = "";
            for (int i = 0; i < frame.FileData.Length; i++)
            {
                text += string.Format("{0:X}", frame.FileData[i]);
            }
            richTextBox_geob_data.Text = text;
        }

        private void listBox_Popularimeter_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBox_Popularimeter.SelectedIndex < 0)
                return;
            PopularimeterFrame frame = (PopularimeterFrame)listBox_Popularimeter.SelectedItem;

            textBox_Popularimeter_counter.Text = frame.Counter.ToString();
            textBox_Popularimeter_email.Text = frame.Email;
            textBox_Popularimeter_rate.Text = frame.Rating.ToString();
        }

        private void button7_Click(object sender, EventArgs e)
        {

        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

        }
    }
}
