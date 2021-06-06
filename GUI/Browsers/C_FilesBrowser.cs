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
using AHD.ID3.Editor.Base;
using AHD.ID3;
using MLV;

namespace AHD.ID3.Editor.GUI
{
    public partial class C_FilesBrowser : UserControl
    {
        public C_FilesBrowser(ColumnsManager cmanager)
        {
            InitializeComponent();
            this.cmanager = cmanager;
            RefreshColumns();
        }

        private ColumnsManager cmanager;
        /// <summary>
        /// Raised when the user edit the list (add or delete)
        /// </summary>
        public event EventHandler ListChanged;
        /// <summary>
        /// Raised when a progress starts
        /// </summary>
        public event EventHandler ProgressStart;
        /// <summary>
        /// Raised when a progress finishes
        /// </summary>
        public event EventHandler ProgressFinished;
        /// <summary>
        /// Raised in progress
        /// </summary>
        public event EventHandler<ProgressArgs> Progress;

        public event EventHandler<ManagedListViewItemDoubleClickArgs> ItemDoubleClick;
        public event EventHandler SwitchToNormalMenu;
        public event EventHandler SwitchToColumnsMenu;
        public event EventHandler SelectedFilesChanged;
        public event EventHandler UpdateRequired;
        public event EventHandler UpdateFinished;
        /// <summary>
        /// Raised when the control request a media stop
        /// </summary>
        public event EventHandler StopMediaRequest;
        /// <summary>
        /// Raised when the control request a media play
        /// </summary>
        public event EventHandler PlayMediaRequest;
        /// <summary>
        /// Raised when the control need to save and the media must be stopped (or unloaded)
        /// </summary>
        public event EventHandler ClearMediaRequest;
        /// <summary>
        /// Raised when the control need to reload the media
        /// </summary>
        public event EventHandler ReloadMediaRequest;
        private bool isItemsDrag = false;

        public ColumnsManager ColumnsManager
        { get { return cmanager; } set { cmanager = value; RefreshColumns(); } }

        public void RefreshColumns()
        {
            managedListView1.Columns = new ManagedListViewColumnsCollection();

            foreach (ColumnItem item in cmanager.Columns)
            {
                if (item.Visible)
                {
                    ManagedListViewColumn column = new ManagedListViewColumn();
                    column.HeaderText = item.ColumnName;
                    column.ID = item.ColumnID;
                    column.Width = item.Width;
                    column.SortMode = ManagedListViewSortMode.None;
                    managedListView1.Columns.Add(column);
                }
            }
            managedListView1.UpdateScrollBars();
        }
        public void SaveColumns()
        {
            List<ColumnItem> oldCollection = cmanager.Columns;
            //create new, save the visible columns first
            cmanager.Columns = new List<ColumnItem>();
            foreach (ManagedListViewColumn column in managedListView1.Columns)
            {
                ColumnItem item = new ColumnItem();
                item.ColumnID = column.ID;
                item.ColumnName = column.HeaderText;
                item.Visible = true;
                item.Width = column.Width;

                cmanager.Columns.Add(item);
                //look for the same item in the old collection then remove it
                foreach (ColumnItem olditem in oldCollection)
                {
                    if (olditem.ColumnID == column.ID)
                    {
                        oldCollection.Remove(olditem);
                        break;
                    }
                }
            }
            //now add the rest of the items (not visible)
            foreach (ColumnItem olditem in oldCollection)
            {
                ColumnItem item = new ColumnItem();
                item.ColumnID = olditem.ColumnID;
                item.ColumnName = olditem.ColumnName;
                item.Visible = false;
                item.Width = olditem.Width;
                cmanager.Columns.Add(item);
            }
        }
        /// <summary>
        /// Refresh files from folder
        /// </summary>
        /// <param name="folder"></param>
        public void RefreshFiles(BFolder folder)
        {
            OnProgressStart();
            string[] files = Directory.GetFiles(folder.Path, "*.mp3");
            managedListView1.Items.Clear();
            int i = 0;
            foreach (string file in files)
            {
                AddFileToList(file);
                int x = (i * 100) / files.Length;
                OnProgress("Loading files .. " + x + "%", x);
                i++;
            }
            OnProgress("Done.", 100);
            OnProgressFinish();
            UpdateStatus();

            managedListView1.RefreshScrollBarsView();
        }
        /// <summary>
        /// Get files from list
        /// </summary>
        /// <param name="list"><see cref="BList"/> to load files from</param>
        public void RefreshFiles(BList list)
        {
            OnProgressStart();
            managedListView1.Items.Clear();
            int i = 0;
            foreach (string file in list.Files)
            {
                AddFileToList(file);
                int x = (i * 100) / list.Files.Count;
                OnProgress("Loading files from list .. " + x + "%", x);
                i++;
            }
            managedListView1.Invalidate();
            OnProgress("Done.", 100);
            OnProgressFinish();
            UpdateStatus();
        }
        /// <summary>
        /// Get files from array
        /// </summary>
        /// <param name="files">The files array</param>
        public void RefreshFiles(string[] files)
        {
            OnProgressStart();
            managedListView1.Items.Clear();
            int i = 0;
            foreach (string file in files)
            {
                AddFileToList(file);
                int x = (i * 100) / files.Length;
                OnProgress("Loading files .. " + x + "%", x);
                i++;
            }
            managedListView1.Invalidate();
            OnProgress("Done.", 100);
            OnProgressFinish();
            UpdateStatus();
        }
        /// <summary>
        /// Add file to the list. Skip this file if another one in the list with the same path.
        /// </summary>
        /// <param name="file">The complete file path</param>
        public void AddFileToList(string file)
        {
            AddFileToList(file, true);
        }
        /// <summary>
        /// Add file to the list
        /// </summary>
        /// <param name="file">The complete file path</param>
        /// <param name="IgnoreIfAlreadyExist">If true, the file will skipped if the path is already in the list.</param>
        public void AddFileToList(string file, bool IgnoreIfAlreadyExist)
        {
            if (IgnoreIfAlreadyExist)
            {
                foreach (ManagedListViewItem_MP3File oldFile in managedListView1.Items)
                {
                    if (oldFile.Tag.ToString() == file)
                        return;
                }
            }
            ID3TagWrapper id3 = new ID3TagWrapper(file, true);
            ManagedListViewItem_MP3File item = new ManagedListViewItem_MP3File();
            item.DrawMode = ManagedListViewItemDrawMode.Text;
            item.Tag = file;
            //add subitems
            //name
            ManagedListViewSubItem subitem = new ManagedListViewSubItem();
            subitem.ColumnID = "name";
            subitem.ImageIndex = 0;
            subitem.DrawMode = ManagedListViewItemDrawMode.TextAndImage;
            subitem.Text = Path.GetFileName(file);
            item.SubItems.Add(subitem);
            //file size
            subitem = new ManagedListViewSubItem();
            subitem.ColumnID = "size";
            subitem.DrawMode = ManagedListViewItemDrawMode.Text;
            subitem.Text = Helper.GetFileSize(file);
            item.SubItems.Add(subitem);
            //path
            subitem = new ManagedListViewSubItem();
            subitem.ColumnID = "path";
            subitem.DrawMode = ManagedListViewItemDrawMode.Text;
            subitem.Text = file;
            item.SubItems.Add(subitem);

            //TAG
            //title
            subitem = new ManagedListViewSubItem();
            subitem.ColumnID = "title";
            subitem.DrawMode = ManagedListViewItemDrawMode.Text;
            subitem.Text = id3.HasID3V2 ? id3.ID3v2QuickWrapper.Title : id3.ID3v1.Title;
            item.SubItems.Add(subitem);
            //artist
            subitem = new ManagedListViewSubItem();
            subitem.ColumnID = "artist";
            subitem.DrawMode = ManagedListViewItemDrawMode.Text;
            subitem.Text = id3.HasID3V2 ? id3.ID3v2QuickWrapper.Artist : id3.ID3v1.Artist;
            item.SubItems.Add(subitem);
            //album
            subitem = new ManagedListViewSubItem();
            subitem.ColumnID = "album";
            subitem.DrawMode = ManagedListViewItemDrawMode.Text;
            subitem.Text = id3.HasID3V2 ? id3.ID3v2QuickWrapper.Album : id3.ID3v1.Album;
            item.SubItems.Add(subitem);
            //genre
            subitem = new ManagedListViewSubItem();
            subitem.ColumnID = "genre";
            subitem.DrawMode = ManagedListViewItemDrawMode.Text;
            subitem.Text = id3.HasID3V2 ? id3.ID3v2QuickWrapper.Genre : id3.ID3v1.Genre;
            item.SubItems.Add(subitem);
            //genre
            subitem = new ManagedListViewSubItem();
            subitem.ColumnID = "track";
            subitem.DrawMode = ManagedListViewItemDrawMode.Text;
            subitem.Text = id3.HasID3V2 ? id3.ID3v2QuickWrapper.Track : id3.ID3v1.Track.ToString();
            item.SubItems.Add(subitem);
            //year
            subitem = new ManagedListViewSubItem();
            subitem.ColumnID = "year";
            subitem.DrawMode = ManagedListViewItemDrawMode.Text;
            subitem.Text = id3.HasID3V2 ? id3.ID3v2QuickWrapper.Year : id3.ID3v1.Year;
            item.SubItems.Add(subitem);
            //comment
            subitem = new ManagedListViewSubItem();
            subitem.ColumnID = "comment";
            subitem.DrawMode = ManagedListViewItemDrawMode.Text;
            subitem.Text = id3.HasID3V2 ? id3.ID3v2QuickWrapper.Comment : id3.ID3v1.Comment;
            item.SubItems.Add(subitem);
            //rating
            ManagedListViewRatingSubItem ratingSubitem = new ManagedListViewRatingSubItem();
            ratingSubitem.ColumnID = "rating";
            ratingSubitem.Rating = id3.ID3v2QuickWrapper.Rating / 51;
            ratingSubitem.RatingChanged += ratingSubitem_RatingChanged;
            item.SubItems.Add(ratingSubitem);
            //id3 version
            subitem = new ManagedListViewSubItem();
            subitem.ColumnID = "id3";
            subitem.DrawMode = ManagedListViewItemDrawMode.Text;
            string text = id3.HasID3V1 ? "1.1, " : "";
            text += id3.HasID3V2 ? ("2." + id3.ID3v2.TagVersion) : "";
            subitem.Text = text;
            item.SubItems.Add(subitem);
            //add the item !
            managedListView1.Items.AddNoEvent(item);
        }
        /// <summary>
        /// Reload item with information from file
        /// </summary>
        /// <param name="item"></param>
        public void ReloadItem(ManagedListViewItem item)
        {
            string path = item.Tag.ToString();
            ID3TagWrapper id3 = new ID3TagWrapper(path, true);
            item.SubItems.Clear();
            //add subitems
            //name
            ManagedListViewSubItem subitem = new ManagedListViewSubItem();
            subitem.ColumnID = "name";
            subitem.ImageIndex = 0;
            subitem.DrawMode = ManagedListViewItemDrawMode.TextAndImage;
            subitem.Text = Path.GetFileName(path);
            item.SubItems.Add(subitem);
            //file size
            subitem = new ManagedListViewSubItem();
            subitem.ColumnID = "size";
            subitem.DrawMode = ManagedListViewItemDrawMode.Text;
            subitem.Text = Helper.GetFileSize(path);
            item.SubItems.Add(subitem);
            //path
            subitem = new ManagedListViewSubItem();
            subitem.ColumnID = "path";
            subitem.DrawMode = ManagedListViewItemDrawMode.Text;
            subitem.Text = path;
            item.SubItems.Add(subitem);

            //TAG
            //title
            subitem = new ManagedListViewSubItem();
            subitem.ColumnID = "title";
            subitem.DrawMode = ManagedListViewItemDrawMode.Text;
            subitem.Text = id3.HasID3V2 ? id3.ID3v2QuickWrapper.Title : id3.ID3v1.Title;
            item.SubItems.Add(subitem);
            //artist
            subitem = new ManagedListViewSubItem();
            subitem.ColumnID = "artist";
            subitem.DrawMode = ManagedListViewItemDrawMode.Text;
            subitem.Text = id3.HasID3V2 ? id3.ID3v2QuickWrapper.Artist : id3.ID3v1.Artist;
            item.SubItems.Add(subitem);
            //album
            subitem = new ManagedListViewSubItem();
            subitem.ColumnID = "album";
            subitem.DrawMode = ManagedListViewItemDrawMode.Text;
            subitem.Text = id3.HasID3V2 ? id3.ID3v2QuickWrapper.Album : id3.ID3v1.Album;
            item.SubItems.Add(subitem);
            //genre
            subitem = new ManagedListViewSubItem();
            subitem.ColumnID = "genre";
            subitem.DrawMode = ManagedListViewItemDrawMode.Text;
            subitem.Text = id3.HasID3V2 ? id3.ID3v2QuickWrapper.Genre : id3.ID3v1.Genre;
            item.SubItems.Add(subitem);
            //genre
            subitem = new ManagedListViewSubItem();
            subitem.ColumnID = "track";
            subitem.DrawMode = ManagedListViewItemDrawMode.Text;
            subitem.Text = id3.HasID3V2 ? id3.ID3v2QuickWrapper.Track : id3.ID3v1.Track.ToString();
            item.SubItems.Add(subitem);
            //year
            subitem = new ManagedListViewSubItem();
            subitem.ColumnID = "year";
            subitem.DrawMode = ManagedListViewItemDrawMode.Text;
            subitem.Text = id3.HasID3V2 ? id3.ID3v2QuickWrapper.Year : id3.ID3v1.Year;
            item.SubItems.Add(subitem);
            //comment
            subitem = new ManagedListViewSubItem();
            subitem.ColumnID = "comment";
            subitem.DrawMode = ManagedListViewItemDrawMode.Text;
            subitem.Text = id3.HasID3V2 ? id3.ID3v2QuickWrapper.Comment : id3.ID3v1.Comment;
            item.SubItems.Add(subitem);
            //rating
            ManagedListViewRatingSubItem ratingSubitem = new ManagedListViewRatingSubItem();
            ratingSubitem.ColumnID = "rating";
            ratingSubitem.Rating = id3.ID3v2QuickWrapper.Rating / 51;
            ratingSubitem.RatingChanged += ratingSubitem_RatingChanged;
            item.SubItems.Add(ratingSubitem);
            //id3 version
            subitem = new ManagedListViewSubItem();
            subitem.ColumnID = "id3";
            subitem.DrawMode = ManagedListViewItemDrawMode.Text;
            string text = id3.HasID3V1 ? "1.1, " : "";
            text += id3.HasID3V2 ? ("2." + id3.ID3v2.TagVersion) : "";
            subitem.Text = text;
            item.SubItems.Add(subitem);
        }
        /// <summary>
        /// Delete selected files from the list (after asking the user with a message box)
        /// </summary>
        public void DeleteSelected()
        {
            DeleteSelected(true);
        }
        /// <summary>
        /// Delete selected files from the list
        /// </summary>
        /// <param name="AskBeforDelete">Indicate whether to ask the user before deleting the file(s) from the list</param>
        public void DeleteSelected(bool AskBeforDelete)
        {
            if (managedListView1.SelectedItems.Count == 0)
                return;
            if (AskBeforDelete)
            {
                if (MessageBox.Show("Are you sure you want to delete these files from the list ?", "Delete files",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                {
                    return;
                }
            }
            OnProgressStart();
            for (int i = 0; i < managedListView1.Items.Count; i++)
            {
                if (managedListView1.Items[i].Selected)
                {
                    int x = (i * 100) / managedListView1.Items.Count;
                    OnProgress("Deleting .. " + x + "%", x);
                    managedListView1.Items.Remove(managedListView1.Items[i]);

                    i--;
                }
            }
            if (ListChanged != null)
                ListChanged(this, new EventArgs());
            OnProgress("Done.", 100);
            OnProgressFinish();
            UpdateStatus();
        }
        public void SelectAll()
        {
            foreach (ManagedListViewItem_MP3File item in managedListView1.Items)
            {
                item.Selected = true;
            }
            managedListView1.Invalidate();

            if (SelectedFilesChanged != null)
                SelectedFilesChanged(this, new EventArgs());
            UpdateStatus();
        }

        /// <summary>
        /// Get all files that listed
        /// </summary>
        /// <returns>All files list</returns>
        public string[] GetFilesList()
        {
            List<string> files = new List<string>();

            foreach (ManagedListViewItem_MP3File item in managedListView1.Items)
            {
                files.Add(item.Tag.ToString());
            }

            return files.ToArray();
        }
        /// <summary>
        /// Get selected files list
        /// </summary>
        /// <returns>Selected files list files list</returns>
        public string[] GetSelectedFiles()
        {
            List<string> files = new List<string>();

            foreach (ManagedListViewItem_MP3File item in managedListView1.Items)
            {
                if (item.Selected)
                    files.Add(item.Tag.ToString());
            }

            return files.ToArray();
        }
        /// <summary>
        /// Get the items count of the list
        /// </summary>
        public int FilesCount
        { get { return managedListView1.Items.Count; } }
        /// <summary>
        /// Get the selected files count
        /// </summary>
        public int SelectedFilesCount
        { get { return managedListView1.SelectedItems.Count; } }
        /// <summary>
        /// Update the information of selected files
        /// </summary>
        public void UpdateSelectedFiles()
        {
            foreach (ManagedListViewItem item in managedListView1.SelectedItems)
            {
                ReloadItem(item);
            }
            managedListView1.Invalidate();

            if (UpdateFinished != null)
                UpdateFinished(this, new EventArgs());
        }

        private void UpdateStatus()
        {
            toolStripStatusLabel1.Text = managedListView1.SelectedItems.Count + " selected of "
                + managedListView1.Items.Count + " total.";
            if (managedListView1.SelectedItems.Count > 0)
                StatusLabel2.Text = "Index= " + (managedListView1.Items.IndexOf(managedListView1.SelectedItems[0]) + 1).ToString();
            else
                StatusLabel2.Text = "No item selected.";
        }
        public void OnProgressStart()
        { if (ProgressStart != null)ProgressStart(this, new EventArgs()); }
        public void OnProgressFinish()
        { if (ProgressFinished != null)ProgressFinished(this, new EventArgs()); }
        public void OnProgress(string status, int complete)
        { if (Progress != null)Progress(this, new ProgressArgs(complete, status)); }
        private void managedListView1_SwitchToNormalContextMenu(object sender, EventArgs e)
        {
            if (SwitchToNormalMenu != null) SwitchToNormalMenu(this, e);
        }
        private void managedListView1_SwitchToColumnsContextMenu(object sender, EventArgs e)
        {
            if (SwitchToColumnsMenu != null) SwitchToColumnsMenu(this, e);
        }
        private void ratingSubitem_RatingChanged(object sender, ManagedListViewRatingChangedArgs e)
        {
            // stop media and clear it
            OnClearMediaRequest();
            // get the file path
            string path = managedListView1.Items[e.ItemIndex].Tag.ToString();
            // load id3v2
            ID3v2 v2 = new ID3v2();
            v2.Load(path);
            // set rating
            ID3v2QuickWrapper wr = new ID3v2QuickWrapper(v2);
            wr.Rating = (byte)(e.Rating * 51);
            // save !
            v2.Save(path);
            // event
            if (managedListView1.Items[e.ItemIndex].Selected)
            {
                if (UpdateRequired != null)
                    UpdateRequired(this, new EventArgs());
            }
            // reload media
            OnReloadMediaRequest();
        }
        // sort
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
            // sort (we need to add a compare class for comparing in the project, see ItemsComparer.cs)
            // Since the items is List<> collection, we can sort using comparer directly.
            // Or you can use information given to sort external collection then to apply it here.
            managedListView1.Items.Sort(new ItemsComparer(az, e.ColumnID));
            // Reverse sort mode.
            if (az)
                column.SortMode = ManagedListViewSortMode.AtoZ;
            else
                column.SortMode = ManagedListViewSortMode.ZtoA;

            managedListView1.Invalidate();

            if (ListChanged != null)
                ListChanged(this, new EventArgs());
        }
        private void managedListView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (SelectedFilesChanged != null)
                SelectedFilesChanged(this, new EventArgs());
            UpdateStatus();
        }
        private void managedListView1_ItemDoubleClick(object sender, ManagedListViewItemDoubleClickArgs e)
        {
            if (ItemDoubleClick != null)
                ItemDoubleClick(this, e);
        }
        private void managedListView1_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Left)
            {
                if (SelectedFilesChanged != null)
                    SelectedFilesChanged(this, new EventArgs());
                UpdateStatus();
            }
        }
        private void managedListView1_DragDrop(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                List<string> files = new List<string>((string[])e.Data.GetData(DataFormats.FileDrop));
                List<string> addFiles = new List<string>();
                for (int i = 0; i < files.Count; i++)
                {
                    if (Directory.Exists(files[i]))
                    {
                        addFiles.AddRange(Directory.GetFiles(files[i], "*", SearchOption.AllDirectories));
                    }
                }
                files.AddRange(addFiles);

                OnProgressStart();
                int j = 0;
                foreach (string file in files)
                {
                    if (Path.GetExtension(file).ToLower() == ".mp3")
                        AddFileToList(file);
                    int x = (j * 100) / files.Count;
                    OnProgress("Loading files .. " + x + "%", x);
                    j++;
                }
                managedListView1.Invalidate();
                managedListView1.ScrollToItem(managedListView1.Items.Count - 1);
                OnProgress("Done.", 100);
                OnProgressFinish();
                UpdateStatus();
            }
        }
        private void managedListView1_ItemsDrag(object sender, EventArgs e)
        {
            if (managedListView1.SelectedItems.Count == 0)
                return;

            isItemsDrag = true;
            DoDragDrop(new DataObject(DataFormats.FileDrop, GetSelectedFiles()), DragDropEffects.Copy | DragDropEffects.Move);
            isItemsDrag = false;
        }
        private void managedListView1_DragEnter(object sender, DragEventArgs e)
        {
            if (isItemsDrag)
            {
                e.Effect = DragDropEffects.None;
                return;
            }
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                e.Effect = DragDropEffects.Copy;
            }
            else
            {
                e.Effect = DragDropEffects.None;
            }
        }
        private void managedListView1_DragOver(object sender, DragEventArgs e)
        {
            if (isItemsDrag)
            {
                e.Effect = DragDropEffects.None;
                return;
            }
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                e.Effect = DragDropEffects.Copy;
            }
            else
            {
                e.Effect = DragDropEffects.None;
            }
        }
        public virtual void OnClearMediaRequest()
        {
            if (ClearMediaRequest != null)
                ClearMediaRequest(this, new EventArgs());
        }
        public virtual void OnReloadMediaRequest()
        {
            if (ReloadMediaRequest != null)
                ReloadMediaRequest(this, new EventArgs());
        }
        public virtual void OnStopMediaRequest()
        {
            if (StopMediaRequest != null)
                StopMediaRequest(this, new EventArgs());
        }
        public virtual void OnPlayMediaRequest()
        {
            if (PlayMediaRequest != null)
                PlayMediaRequest(this, new EventArgs());
        }
    }
}
