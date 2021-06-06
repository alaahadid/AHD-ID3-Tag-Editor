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
using System.IO;
using AHD.SM.Formats;
using AHD.SM.ASMP;
using AHD.ID3;
using AHD.ID3.Types;
using AHD.ID3.Frames;
using AHD.ID3.Editor.Base;
namespace AHD.ID3.Editor.GUI
{
    public partial class Frm_ImportSubtitlesFormat : Form
    {
        public Frm_ImportSubtitlesFormat(string fileName)
        {
            this.fileName = fileName;
            InitializeComponent();
            // install supported formats
            SubtitleFormats.DetectSupportedFormats(true, true);
            SubtitlesFormat[] importFormats = SubtitleFormats.CheckFile(fileName, false, Encoding.Default);
            foreach (SubtitlesFormat format in SubtitleFormats.EnabledFormats)
            {
                TreeNode tr = new TreeNode();
                tr.Text = format.Name;
                tr.Tag = format;
                tr.ImageIndex = tr.SelectedImageIndex = importFormats.Contains(format) ? 1 : 0;

                treeView1.Nodes.Add(tr);

                if (importFormats.Contains(format))
                    treeView1.SelectedNode = tr;
            }
            // setup encodings
            infos = Encoding.GetEncodings();
            foreach (EncodingInfo inf in infos)
            {
                comboBox1.Items.Add(inf.DisplayName + " (" + inf.Name + ") [" + inf.CodePage + "]");
            }
            comboBox1.SelectedIndex = comboBox1.Items.Count - 1;
        }
        private string fileName;
        private EncodingInfo[] infos;
        private SubtitlesFormat importedFormat;

        public SubtitlesFormat ImportedFormat
        { get { return importedFormat; } }
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex < 0)
                return;
            Encoding enc = Encoding.GetEncoding(infos[comboBox1.SelectedIndex].CodePage);
            richTextBox2.Lines = File.ReadAllLines(fileName, enc);
        }
        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            // clear
            richTextBox1.Text = "";
            if (treeView1.SelectedNode == null)
                return;
            SubtitlesFormat format = (SubtitlesFormat)treeView1.SelectedNode.Tag;
            richTextBox1.Text = format.Description;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (treeView1.SelectedNode == null)
            {
                MessageBox.Show("Please select subtitles format first");
                return;
            }
            if (comboBox1.SelectedIndex < 0)
            {
                MessageBox.Show("Please select write encoding first");
                return;
            }
            importedFormat = (SubtitlesFormat)treeView1.SelectedNode.Tag; 
            Encoding enc = Encoding.GetEncoding(infos[comboBox1.SelectedIndex].CodePage);
            importedFormat.Load(fileName, enc);

            this.DialogResult = System.Windows.Forms.DialogResult.OK;
            Close();
        }
    }
}
