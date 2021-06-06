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
using MLV;
using AHD.ID3;
using AHD.ID3.Types;
using AHD.ID3.Frames;
using AHD.ID3.Editor.Base;
namespace AHD.ID3.Editor.GUI
{
    public partial class C_TagExplorer : EditorControl
    {
        public C_TagExplorer()
        {
            InitializeComponent();
            // add columns
            ManagedListViewColumn column = new ManagedListViewColumn();
            column.HeaderText = "#";
            column.ID = "number";
            column.Width = 40;
            managedListView1.Columns.Add(column);
            column = new ManagedListViewColumn();
            column.HeaderText = "Frame id";
            column.ID = "id";
            column.Width = 40;
            managedListView1.Columns.Add(column);
            column = new ManagedListViewColumn();
            column.HeaderText = "Frame name";
            column.ID = "name";
            column.Width = 120;
            managedListView1.Columns.Add(column);
            column = new ManagedListViewColumn();
            column.HeaderText = "Frame type";
            column.ID = "type";
            column.Width = 100;
            managedListView1.Columns.Add(column);
            column = new ManagedListViewColumn();
            column.HeaderText = "Frame value (if available)";
            column.ID = "value";
            column.Width = 100;
            managedListView1.Columns.Add(column);
        }

        private ID3v2 v2;
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
        private void ReloadFrame(object sender, EventArgs e)
        {
            ClearFields();
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
                toolStripLabel1.Text = "You can only edit 1 file at a time.";
                return;
            }
            //load frames
            LoadFrames(files[0]);
        }
        public override void ClearFields()
        {
            managedListView1.Items.Clear();
            toolStripLabel1.Text = "";

            textBox_tagSize.Text = "";
            textBox_tagVersion.Text = "";
            checkBox_compression.Checked = checkBox_experimental.Checked = checkBox_extenderHeaderPresented.Checked =
                checkBox_footer.Checked = checkBox_unsynchronisation.Checked = false;
        }
        public override void DisableSaving()
        {
            base.DisableSaving();
            toolStripButton_delete.Enabled = toolStripButton_save.Enabled = false;
        }
        /// <summary>
        /// Fill fields from file
        /// </summary>
        /// <param name="file">The file to load</param>
        public void LoadFrames(string file)
        {
            v2 = new ID3v2();
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
            textBox_tagSize.Text = Helper.GetSize(v2.TagSize);
            textBox_tagVersion.Text = "2." + v2.TagVersion.ToString();
            checkBox_compression.Checked = v2.Compression;
            checkBox_experimental.Checked = v2.Experimental;
            checkBox_extenderHeaderPresented.Checked = v2.ExtendedHeader;
            checkBox_footer.Checked = v2.Footer;
            checkBox_unsynchronisation.Checked = v2.Unsynchronisation;
            managedListView1.Items.Clear();
            // load frames
            int i = 1;
            foreach (ID3TagFrame frame in v2.Frames)
            {
                ManagedListViewItem item = new ManagedListViewItem();

                item.Tag = frame;// Save the frame as it is !

                ManagedListViewSubItem subItem = new ManagedListViewSubItem();
                subItem.ColumnID = "number";
                subItem.DrawMode = ManagedListViewItemDrawMode.Text;
                subItem.Text = i.ToString(string.Format("D{0}", v2.Frames.Count.ToString().Length));
                item.SubItems.Add(subItem);

                subItem = new ManagedListViewSubItem();
                subItem.ColumnID = "id";
                subItem.DrawMode = ManagedListViewItemDrawMode.Text;
                subItem.Text = frame.ID;
                item.SubItems.Add(subItem);

                subItem = new ManagedListViewSubItem();
                subItem.ColumnID = "name";
                subItem.DrawMode = ManagedListViewItemDrawMode.Text;
                subItem.Text = frame.Name;
                item.SubItems.Add(subItem);

                subItem = new ManagedListViewSubItem();
                subItem.ColumnID = "type";
                subItem.DrawMode = ManagedListViewItemDrawMode.Text;
                subItem.Text = frame.Type;
                item.SubItems.Add(subItem);

                subItem = new ManagedListViewSubItem();
                subItem.ColumnID = "value";
                subItem.DrawMode = ManagedListViewItemDrawMode.Text;
                if (frame is TextFrame)
                    subItem.Text = ((TextFrame)frame).Text;
                else
                    subItem.Text = frame.ToString();
                item.SubItems.Add(subItem);

                managedListView1.Items.Add(item);
                i++;
            }
            managedListView1.Items.Sort(new ItemsComparer(true, "type"));
            managedListView1.Invalidate();
        }
        public override void LoadTag(ID3v2 v2)
        {
            LoadFrames(v2);
        }
        private void managedListView1_ColumnClicked(object sender, ManagedListViewColumnClickArgs e)
        {
            // get the column
            ManagedListViewColumn column = managedListView1.Columns.GetColumnByID(e.ColumnID);
            if (column == null) return;
            bool az = false;
            // now let's see what is the sort mode
            switch (column.SortMode)
            {
                case ManagedListViewSortMode.None:
                case ManagedListViewSortMode.ZtoA: az = true; break;
            }
            // disable sort for all columns
            foreach (ManagedListViewColumn cl in managedListView1.Columns)
                cl.SortMode = ManagedListViewSortMode.None;

            managedListView1.Items.Sort(new ItemsComparer(az, e.ColumnID));
            // Reverse sort mode.
            if (az)
                column.SortMode = ManagedListViewSortMode.AtoZ;
            else
                column.SortMode = ManagedListViewSortMode.ZtoA;

            managedListView1.Invalidate();
        }
        private void toolStripButton_delete_Click(object sender, EventArgs e)
        {
            if (managedListView1.SelectedItems.Count > 0)
            {
                if (MessageBox.Show("Are you sure you want to delete these frames from the list ?\n(You'll need to save to apply changes via 'Save' button)", "Delete frames",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                {
                    return;
                }
                foreach (ManagedListViewItem item in managedListView1.SelectedItems)
                {
                    v2.Frames.Remove((ID3TagFrame)item.Tag);
                }
                // Refresh !
                LoadFrames(v2);
            }
        }
        private void toolStripButton_save_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to save changes ?\nYou will NOT be able to recover deleted frames after this.", "Save",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            {
                return;
            }

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

            DebugLogger.WriteLine("Saving tag frames changes ...");

            // Apply remaining frames to the file
            v2.Frames.Clear();
            foreach (ManagedListViewItem item in managedListView1.Items)
            {
                v2.Frames.Add((ID3TagFrame)item.Tag);
            }
            // Save !
            if (v2.Save(v2.FileName) == Result.Success)
            {
                MessageBox.Show("File saved successfully !\nYou'll need to re-select the file in the list to refresh other browsers.");
                OnProgress("Changes saved successfully.", 100);
            }
            else
            {
                MessageBox.Show("Error saving the file !", "Save Changes", MessageBoxButtons.OK, MessageBoxIcon.Error);
                OnProgress("Changes NOT saved.", 100);
            }

            OnProgressFinish();

            OnUpdateRequired();

            OnReloadMediaRequest();
        }
    }
}
