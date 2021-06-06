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
using System.Windows.Forms;
using System.Threading;
using System.IO;
using System.Runtime.InteropServices;
using AHD.ID3;
using AHD.ID3.Frames;

namespace AHD.ID3.Editor.GUI
{
    public partial class Frm_ExtractTagContent : Form
    {
        public Frm_ExtractTagContent(string[] files)
        {
            InitializeComponent();
            this.files = files; _folderMode = false;
            this.checkBox_includeSubFolders.Enabled = false;
        }
        public Frm_ExtractTagContent(string folder)
        {
            InitializeComponent();
            this._inFolder = folder;
            this.checkBox_includeSubFolders.Enabled = true;
            _folderMode = true;
        }
        private string[] files;
        private Thread mainThread;
        private string _folder;
        private string _inFolder = "";
        private bool _folderMode = false;
        private bool _extractPictures;
        private bool _extractFiles;
        private bool _extractLyrics;
        private bool _includeSubfolders;
        private void Progress()
        {
            DebugLogger.WriteLine("Starting progress ...");
            if (_folderMode)
            {
                if (_includeSubfolders)
                {
                    files = Directory.GetFiles(_inFolder, "*.mp3", SearchOption.AllDirectories);
                }
                else
                {
                    files = Directory.GetFiles(_inFolder, "*.mp3", SearchOption.TopDirectoryOnly);
                }
            }
            foreach (string file in files)
            {
                // Read id3v2 of file
                DebugLogger.WriteLine("Reading ID3v2 of file: " + file);
                ID3v2 v2 = new ID3v2();
                Result result = v2.Load(file);
                if (result == Result.Success)
                {
                    string fileFolder = _folder;
                    if (_folderMode)
                    {
                        string f = Path.GetDirectoryName(file);
                        if (f == "")
                            f = Path.GetPathRoot(file);
                        f = f.Replace(_inFolder, _folder);

                        fileFolder = f;
                    }
                    // Get attached pictures
                    int pictureIndex = 0;
                    int fileIndex = 0;
                    int lyricsIndex = 0;
                    foreach (ID3TagFrame frame in v2.Frames)
                    {
                        if (frame is AttachedPictureFrame && _extractPictures)
                        {
                            Directory.CreateDirectory(fileFolder);
                            AttachedPictureFrame pictureFrame = (AttachedPictureFrame)frame;
                            string[] extensions = MIME.MimeManager.GetExtensions(pictureFrame.MIME);
                            string extension = "";
                            if (extensions.Length > 0)
                                extension = extensions[0];
                            else
                                extension = ".jpg";
                            // Create picture file name
                            string pFileName = fileFolder + "\\" + Path.GetFileNameWithoutExtension(file) +
                                "_AttachedPicture" + "[" + pictureFrame.PictureType + "]" + pictureIndex + extension;
                            // Save file ..
                            System.IO.Stream stream = new System.IO.MemoryStream(pictureFrame.PictureData);
                            Bitmap img = new Bitmap(stream);
                            img.Save(pFileName);
                            stream.Close();
                            DebugLogger.WriteLine("Attached Picture saved: " + pFileName, DebugCode.Good);
                            pictureIndex++;
                        }
                        else if (frame is GeneralEncapsulatedObjectFrame && _extractFiles)
                        {
                            Directory.CreateDirectory(fileFolder);
                            GeneralEncapsulatedObjectFrame gFrame = (GeneralEncapsulatedObjectFrame)frame;
                            string[] extensions = MIME.MimeManager.GetExtensions(gFrame.MIME);
                            string extension = "";
                            if (extensions.Length > 0)
                                extension = extensions[0];
                            else
                                extension = ".bin";
                            // Create picture file name
                            string pFileName = fileFolder + "\\" + Path.GetFileNameWithoutExtension(file) +
                                "_GeneralEncapsulatedObject" + fileIndex + extension;
                            // Save file ..
                            System.IO.Stream stream = new System.IO.FileStream(pFileName, FileMode.Create, FileAccess.Write);
                            stream.Write(gFrame.FileData, 0, gFrame.FileData.Length);
                            stream.Close();
                            DebugLogger.WriteLine("General Encapsulated Object saved: " + pFileName, DebugCode.Good);
                            fileIndex++;
                        }
                        else if (frame is UnsychronisedLyricsFrame && _extractLyrics)
                        {
                            Directory.CreateDirectory(fileFolder);
                            UnsychronisedLyricsFrame lFrame = (UnsychronisedLyricsFrame)frame;

                            // Create picture file name
                            string pFileName = fileFolder + "\\" + Path.GetFileNameWithoutExtension(file) +
                                "_UnsychronisedLyrics" + lyricsIndex + ".txt";
                            // Save file ..
                            System.IO.Stream stream = new System.IO.FileStream(pFileName, FileMode.Create, FileAccess.Write);
                            byte[] data = lFrame.Encoding.GetBytes(lFrame.LyricsText);
                            stream.Write(data, 0, data.Length);
                            stream.Close();
                            DebugLogger.WriteLine("Unsychronised Lyrics saved: " + pFileName, DebugCode.Good);
                            lyricsIndex++;
                        }
                    }
                }
                else
                {
                    switch (result)
                    {
                        case Result.Failed: DebugLogger.WriteLine("Failed to read file, file damaged or not mp3.", DebugCode.Error); break;
                        case Result.NoID3Exist: DebugLogger.WriteLine("Can't load this file, no ID3 Tag v2 exist in this file.", DebugCode.Error); break;
                        case Result.NotCompatibleVersion: DebugLogger.WriteLine("Can't load this file, not compatible version of ID3 Tag", DebugCode.Error); break;
                    }
                }
            }
            EnableControls();
            DebugLogger.WriteLine("Done !", DebugCode.Good);
        }
        private void EnableControls()
        {
            if (!this.InvokeRequired)
            {
                EnableControls1();
            }
            else
            {
                this.Invoke(new Action(EnableControls1));
            }
        }
        private void EnableControls1()
        {
            button_start.Enabled = checkBox_extractAttachedPictures.Enabled = checkBox_ExtractUnsychronisedLyrics.Enabled =
          button1.Enabled = checkBox_GeneralEncapsulatedObject.Enabled = checkBox_includeSubFolders.Enabled = true;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folder = new FolderBrowserDialog();
            folder.Description = "Browse where to save extracted files";
            folder.SelectedPath = textBox_folder.Text;
            if (folder.ShowDialog(this) == System.Windows.Forms.DialogResult.OK)
            {
                textBox_folder.Text = folder.SelectedPath;
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }
        // Start
        private void button_start_Click(object sender, EventArgs e)
        {
            if (mainThread != null)
            {
                if (mainThread.IsAlive)
                {
                    if (MessageBox.Show("Are you sure you want to stop current process ?", "Extract Tag content",
                        MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
                    {
                        mainThread.Abort();
                    }
                    else
                    {
                        return;
                    }
                }
            }
            if (textBox_folder.Text == "")
            {
                MessageBox.Show("Please browse for target folder first.");
                return;
            }
            if (!Directory.Exists(textBox_folder.Text))
            {
                MessageBox.Show("Please browse for target folder first, This folder is not exist.");
                return;
            }
            if (!checkBox_extractAttachedPictures.Checked && !checkBox_ExtractUnsychronisedLyrics.Checked
                && !checkBox_GeneralEncapsulatedObject.Checked)
            {
                MessageBox.Show("Please select one option at least .");
                return;
            }
            _folder = textBox_folder.Text;
            _extractFiles = checkBox_GeneralEncapsulatedObject.Checked;
            _extractLyrics = checkBox_ExtractUnsychronisedLyrics.Checked;
            _extractPictures = checkBox_extractAttachedPictures.Checked;
            _includeSubfolders = checkBox_includeSubFolders.Checked;

            button_start.Enabled = checkBox_extractAttachedPictures.Enabled = checkBox_ExtractUnsychronisedLyrics.Enabled =
            button1.Enabled = checkBox_GeneralEncapsulatedObject.Enabled = checkBox_includeSubFolders.Enabled = false;

            DebugLogger.CallLogWindow();

            // Start thread
            mainThread = new Thread(new ThreadStart(Progress));
            mainThread.Start();
        }
        private void Frm_ExtractTagContent_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (mainThread != null)
            {
                if (mainThread.IsAlive)
                {
                    if (MessageBox.Show("Are you sure you want to stop current process ?", "Extract Tag content",
                        MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.No)
                    {
                        e.Cancel = true;
                    }
                    else
                    {
                        mainThread.Abort();
                    }
                }
            }
        }
    }
}
