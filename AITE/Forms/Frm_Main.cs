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
using System.Diagnostics;
using System.IO;
using System.Xml;
using System.Xml.Serialization;
using AHD.ID3.Editor.GUI;
using AHD.ID3.Editor.Base;
using MTC;
namespace AHD.ID3.Editor
{
    public partial class Frm_Main : Form
    {
        public Frm_Main(string[] args)
        {
            InitializeComponent();
            DoCommandlines(args);
            LoadSettings();
            DebugLogger.RequestLogWindow += DebugLogger_RequestLogWindow;
        }

        private bool canDragDrop = false;
        private Point downPoint = Point.Empty;
        private bool saveListRequired = false;
        private ActiveTab ativetab = ActiveTab.Folders;
        private ActiveTab ActiveWindow
        {
            get { return ativetab; }
            set
            {
                ativetab = value;
                switch (value)
                {
                    case ActiveTab.Folders:
                    case ActiveTab.ListsBrowser:
                    case ActiveTab.Files:
                    case ActiveTab.ImagesManager:
                        deleteToolStripMenuItem.Enabled = deleteToolStripMenuItem1.Enabled =
                            deleteToolStripMenuItem2.Enabled = deleteToolStripMenuItem3.Enabled = true;
                        break;
                    default:
                        deleteToolStripMenuItem.Enabled = deleteToolStripMenuItem1.Enabled =
                  deleteToolStripMenuItem2.Enabled = deleteToolStripMenuItem3.Enabled = false;
                        break;
                }
            }
        }
        private C_FoldersBrowser c_foldersBrowser = new C_FoldersBrowser();
        private C_FilesBrowser c_filesBrowser = new C_FilesBrowser(Program.Settings.ColumnsManager);
        private C_QuickTagEditorV2 c_quickTagEditorv2 = new C_QuickTagEditorV2(Program.Settings.GenreMemory, Program.Settings.ArtistsMemory, Program.Settings.AlbumsMemory);
        private C_QuickTagEditorV1 c_quickTagEditorv1 = new C_QuickTagEditorV1(Program.Settings.ArtistsMemory, Program.Settings.AlbumsMemory);
        private C_ImagesManager c_imagesManager = new C_ImagesManager();
        private C_ListsBrowser c_listsBrowser = new C_ListsBrowser();
        private C_FullTextFramesEditor c_allTextFrames = new C_FullTextFramesEditor(Program.Settings.GenreMemory, Program.Settings.ArtistsMemory, Program.Settings.AlbumsMemory);
        private C_UrlLinkEditor c_urlLinkFrames = new C_UrlLinkEditor();
        private C_CommentsEditor c_commentsEditor = new C_CommentsEditor();
        private C_Popularimeter c_popularimeter = new C_Popularimeter();
        private C_InvolvedPeopleList c_involvedPeople = new C_InvolvedPeopleList();
        private C_UnsychronisedLyrics c_unsychronisedLyrics = new C_UnsychronisedLyrics();
        private C_UniqueFileIdentifier c_uniqueFileIdentifier = new C_UniqueFileIdentifier();
        private C_MusicCDIdentifier c_musicCDIdentifier = new C_MusicCDIdentifier();
        private C_GeneralEncapsulatedObject c_generalEncapsulatedObject = new C_GeneralEncapsulatedObject();
        private C_Commercial c_commercial = new C_Commercial();
        private C_PlayCounter c_playCounter = new C_PlayCounter();
        private C_EventTimingCodes c_eventTimingCodes = new C_EventTimingCodes();
        private C_SynchronisedLyrics c_synchronisedLyrics = new C_SynchronisedLyrics();
        private C_MediaPlayer c_mediaPlayer = new C_MediaPlayer(Program.Settings.MediaPlayerAutoStart);
        private LoggerControl loggerControl = new LoggerControl();
        private C_TermsOfUseFrame c_termsOfUse = new C_TermsOfUseFrame();
        private C_TagExplorer c_tagExplorer = new C_TagExplorer();
        private Frm_Log frm_log = new Frm_Log();
        private int counter = 3;
        private bool ReloadMediaAfterUpdate = false;

        private void DoCommandlines(string[] args)
        {
            if (args == null)
                return;
            for (int i = 0; i < args.Length; i++)
            {
                if (File.Exists(args[i]))
                {
                    AddFiles(new string[] { args[i] });
                }
                else
                {
                    switch (args[i].ToLower())
                    {
                        case "/rst"://reset settings
                            Program.Settings.Reset();
                            // First run ?
                            if (!Program.Settings.FirstRun)
                            {
                                Program.Settings.FirstRun = true;
                                Program.Settings.DefaultLayout = new LayoutPresent();
                                Program.Settings.DefaultLayout.BuildDefaultLayout();

                                Program.Settings.ColumnsManager = new Base.ColumnsManager();
                                Program.Settings.ColumnsManager.BuildDefaultCollection();
                            }
                            // Apply settings for id3v2 
                            Program.LoadID3V2Settings();
                            // Load database
                            Program.DatabaseManager = new Base.BDatabaseManager();
                            System.IO.Directory.CreateDirectory(System.Environment.GetFolderPath(System.Environment.SpecialFolder.MyDocuments) + "\\AITE\\");
                            Program.DatabaseManager.FilePath =
                                System.Environment.GetFolderPath(System.Environment.SpecialFolder.MyDocuments) +
                                "\\AITE\\folders.aite";
                            Program.DatabaseManager.Load();
                            break;
                        case "/list":// load list at path, the next arg must be the path
                            i++;
                            if (i < args.Length)
                            { OpenList(args[i]); }
                            break;
                        case "/edit1":// full edit id3v1 for all files in the list. This must be called after adding files.
                            c_filesBrowser.SelectAll();
                            FullEditId3v1(this, null);
                            break;
                        case "/edit2":// full edit id3v2 for all files in the list. This must be called after adding files.
                            c_filesBrowser.SelectAll();
                            FullEditId3v2(this, null);
                            break;
                    }
                }
            }
        }
        private void LoadSettings()
        {
            this.Location = Program.Settings.Win_Location;
            this.Size = Program.Settings.Win_Size;
            splitContainer1.SplitterDistance = Program.Settings.SplitContainer1;
            splitContainer2.SplitterDistance = Program.Settings.SplitContainer2;
            splitContainer3.SplitterDistance = Program.Settings.SplitContainer3;
            splitContainer4.SplitterDistance = Program.Settings.SplitContainer4;
            splitContainer5.SplitterDistance = Program.Settings.SplitContainer5;
            LoadLayout(Program.Settings.DefaultLayout);
            ApplyTabPagesStyle();
        }
        private void ApplyTabPagesStyle()
        {
            managedTabControl_downLeft.TabPageColor = Program.Settings.TabPageColor;
            managedTabControl_downLeft.TabPageHighlightedColor = Program.Settings.TabPageHighlightColor;
            managedTabControl_downLeft.TabPageSelectedColor = Program.Settings.TabPageSelectColor;
            managedTabControl_downLeft.TabPageSplitColor = Program.Settings.TabPageSplitcolor;
            managedTabControl_downLeft.ForeColor = Program.Settings.TabPageTextColor;
            managedTabControl_downLeft.Invalidate();

            managedTabControl_downMiddle.TabPageColor = Program.Settings.TabPageColor;
            managedTabControl_downMiddle.TabPageHighlightedColor = Program.Settings.TabPageHighlightColor;
            managedTabControl_downMiddle.TabPageSelectedColor = Program.Settings.TabPageSelectColor;
            managedTabControl_downMiddle.TabPageSplitColor = Program.Settings.TabPageSplitcolor;
            managedTabControl_downMiddle.ForeColor = Program.Settings.TabPageTextColor;
            managedTabControl_downMiddle.Invalidate();

            managedTabControl_downRight.TabPageColor = Program.Settings.TabPageColor;
            managedTabControl_downRight.TabPageHighlightedColor = Program.Settings.TabPageHighlightColor;
            managedTabControl_downRight.TabPageSelectedColor = Program.Settings.TabPageSelectColor;
            managedTabControl_downRight.TabPageSplitColor = Program.Settings.TabPageSplitcolor;
            managedTabControl_downRight.ForeColor = Program.Settings.TabPageTextColor;
            managedTabControl_downRight.Invalidate();

            managedTabControl_topLeft.TabPageColor = Program.Settings.TabPageColor;
            managedTabControl_topLeft.TabPageHighlightedColor = Program.Settings.TabPageHighlightColor;
            managedTabControl_topLeft.TabPageSelectedColor = Program.Settings.TabPageSelectColor;
            managedTabControl_topLeft.TabPageSplitColor = Program.Settings.TabPageSplitcolor;
            managedTabControl_topLeft.ForeColor = Program.Settings.TabPageTextColor;
            managedTabControl_topLeft.Invalidate();

            managedTabControl_topMiddle.TabPageColor = Program.Settings.TabPageColor;
            managedTabControl_topMiddle.TabPageHighlightedColor = Program.Settings.TabPageHighlightColor;
            managedTabControl_topMiddle.TabPageSelectedColor = Program.Settings.TabPageSelectColor;
            managedTabControl_topMiddle.TabPageSplitColor = Program.Settings.TabPageSplitcolor;
            managedTabControl_topMiddle.ForeColor = Program.Settings.TabPageTextColor;
            managedTabControl_topMiddle.Invalidate();

            managedTabControl_topRight.TabPageColor = Program.Settings.TabPageColor;
            managedTabControl_topRight.TabPageHighlightedColor = Program.Settings.TabPageHighlightColor;
            managedTabControl_topRight.TabPageSelectedColor = Program.Settings.TabPageSelectColor;
            managedTabControl_topRight.TabPageSplitColor = Program.Settings.TabPageSplitcolor;
            managedTabControl_topRight.ForeColor = Program.Settings.TabPageTextColor;
            managedTabControl_topRight.Invalidate();
        }
        private void SaveSettings()
        {
            Program.Settings.Win_Location = this.Location;
            Program.Settings.Win_Size = this.Size;
            Program.Settings.SplitContainer1 = splitContainer1.SplitterDistance;
            Program.Settings.SplitContainer2 = splitContainer2.SplitterDistance;
            Program.Settings.SplitContainer3 = splitContainer3.SplitterDistance;
            Program.Settings.SplitContainer4 = splitContainer4.SplitterDistance;
            Program.Settings.SplitContainer5 = splitContainer5.SplitterDistance;
            // columns
            c_filesBrowser.SaveColumns();
            Program.Settings.ColumnsManager = c_filesBrowser.ColumnsManager;
            SaveToolbars();

            Program.Settings.Save();
        }
        private void OpenFileQuickV2Edit(object sender, EventArgs e)
        {
            OpenFileDialog op = new OpenFileDialog();
            op.Filter = "Mp3 audio file (*.mp3)|*.mp3;*.MP3";
            op.Title = "Open mp3 file(s) for quick id3v2 edit";
            op.Multiselect = true;
            if (op.ShowDialog(this) == System.Windows.Forms.DialogResult.OK)
            {
                Frm_FullID3V2Edit frm = new Frm_FullID3V2Edit(op.FileNames, Program.Settings.GenreMemory,
                   Program.Settings.ArtistsMemory, Program.Settings.AlbumsMemory);
                c_quickTagEditorv2_ClearMediaRequest(this, null);
                if (frm.ShowDialog(this) == System.Windows.Forms.DialogResult.OK)
                {
                    c_filesBrowser.UpdateSelectedFiles(); LoadEditorControls(null);
                }
                //  c_quickTagEditorv2_ReloadMediaRequest(this, null);
                // Reload media
                counter = 2;
                timer1.Start();
            }
        }
        private void OpenFileQuickV1Edit(object sender, EventArgs e)
        {
            OpenFileDialog op = new OpenFileDialog();
            op.Filter = "Mp3 audio file (*.mp3)|*.mp3;*.MP3";
            op.Title = "Open mp3 file(s) for quick id3v1 edit";
            op.Multiselect = true;
            if (op.ShowDialog(this) == System.Windows.Forms.DialogResult.OK)
            {
                c_quickTagEditorv2_ClearMediaRequest(this, null);
                Frm_FullEditV1 frm = new Frm_FullEditV1(op.FileNames,
                    Program.Settings.ArtistsMemory, Program.Settings.AlbumsMemory);
                if (frm.ShowDialog(this) == System.Windows.Forms.DialogResult.OK)
                {
                    c_filesBrowser.UpdateSelectedFiles(); LoadEditorControls(null);
                }
                //c_quickTagEditorv2_ReloadMediaRequest(this, null);
                // Reload media
                counter = 2;
                timer1.Start();
            }
        }
        private void OpenWithTagExplorer(object sender, EventArgs e)
        {
            if (c_filesBrowser.SelectedFilesCount != 1)
            {
                MessageBox.Show("Please select one file first.");
                return;
            }
            // Clear media first
            c_quickTagEditorv2_ClearMediaRequest(this, null);
            Frm_TagExplorer frm = new Frm_TagExplorer(c_filesBrowser.GetSelectedFiles()[0]);
            frm.ShowDialog(this);
            // Reload media
            counter = 2;
            timer1.Start();
        }
        #region List
        private void CreateList(object sender, EventArgs e)
        {
            if (c_filesBrowser.FilesCount == 0)
            {
                MessageBox.Show("There's no file in the files list !");
                return;
            }
            Frm_EnterName frm = new Frm_EnterName("Enter the new list name", "New List", true, false);
            frm.OkPressed += frm_OkPressed;
            if (frm.ShowDialog(this) == System.Windows.Forms.DialogResult.OK)
            {
                BList list = new BList();
                list.Name = frm.EnteredName;
                list.Files = new List<string>(c_filesBrowser.GetFilesList());

                bool found = Program.DatabaseManager.BrowserDatabase.IsListExist(list.Name);

                if (!found)
                    Program.DatabaseManager.BrowserDatabase.Lists.Add(list);
                else
                {
                    // overwrite
                    BList lst = Program.DatabaseManager.BrowserDatabase.GetList(list.Name);
                    lst.Files = new List<string>(c_filesBrowser.GetFilesList());
                }
                c_listsBrowser.RefreshLists(Program.DatabaseManager.BrowserDatabase);
                saveListRequired = false;
                // make sure the lists list is visible
                foreach (ControlPage pg in Program.Settings.DefaultLayout.Pages)
                {
                    if (pg.Type == ControlType.ListsBrowser)
                    {
                        if (!pg.Visible)
                        {
                            // make it visible !
                            pg.Visible = true;
                            AddControlAsTab(pg);
                            CheckForTabsCollapses();
                        }
                        break;
                    }
                }
            }
        }
        private void ExportListAsFile(object sender, EventArgs e)
        {
            foreach (ControlPage pg in Program.Settings.DefaultLayout.Pages)
            {
                if (pg.Type == ControlType.ListsBrowser)
                {
                    if (!pg.Visible)
                    {
                        MessageBox.Show("The lists list is not active.");
                        return;
                    }
                }
            }
            if (c_listsBrowser.SelectedList == null)
            {
                MessageBox.Show("Please select a list first.");
                return;
            }
            SaveFileDialog sav = new SaveFileDialog();
            sav.Filter = "M3U list (*.m3u)|*.m3u";
            sav.Title = "Save M3U list";
            if (sav.ShowDialog(this) == System.Windows.Forms.DialogResult.OK)
            {
                M3UList file = new M3UList();
                file.ProgressStart += c_filesBrowser_ProgressStart;
                file.ProgressFinished += c_filesBrowser_ProgressFinished;
                file.Progress += c_filesBrowser_Progress;

                file.Save(sav.FileName, c_listsBrowser.SelectedList.Files.ToArray());
            }
        }
        private void OpenList(object sender, EventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();
            open.Filter = "M3U list (*.m3u)|*.m3u";
            open.Title = "Open M3U list";
            if (open.ShowDialog(this) == System.Windows.Forms.DialogResult.OK)
            {
                OpenList(open.FileName);
            }
        }
        private void OpenList(string fileName)
        {
            M3UList m3ufile = new M3UList();
            m3ufile.ProgressStart += c_filesBrowser_ProgressStart;
            m3ufile.ProgressFinished += c_filesBrowser_ProgressFinished;
            m3ufile.Progress += c_filesBrowser_Progress;

            bool setSave = c_filesBrowser.FilesCount > 0;

            string[] files = m3ufile.Load(fileName);

            if (files == null)
            {
                MessageBox.Show("Load failed !! the file is not M3U list or damaged.");
                return;
            }

            ProgressBar1.Visible = true;
            int i = 0;
            foreach (string file in files)
            {
                c_filesBrowser.AddFileToList(file);
                int x = (i * 100) / files.Length;
                ProgressBar1.Value = x;
                StatusLabel.Text = "Adding files .." + x + " %";
                statusStrip1.Refresh();
                i++;
            }
            c_filesBrowser.Invalidate();
            if (setSave)
                saveListRequired = true;
            ProgressBar1.Visible = false;
            StatusLabel.Text = "Done.";

            // make sure the files list is visible
            foreach (ControlPage pg in Program.Settings.DefaultLayout.Pages)
            {
                if (pg.Type == ControlType.FilesBrowser)
                {
                    if (!pg.Visible)
                    {
                        // make it visible !
                        pg.Visible = true;
                        AddControlAsTab(pg);
                        CheckForTabsCollapses();
                    }
                    break;
                }
            }
        }
        private void SaveList(object sender, EventArgs e)
        {
            foreach (ControlPage pg in Program.Settings.DefaultLayout.Pages)
            {
                if (pg.Type == ControlType.FilesBrowser)
                {
                    if (!pg.Visible)
                    {
                        MessageBox.Show("No list to save !!");
                        return;
                    }
                }
            }
            SaveFileDialog sav = new SaveFileDialog();
            sav.Filter = "M3U list (*.m3u)|*.m3u";
            sav.Title = "Save M3U list";
            if (sav.ShowDialog(this) == System.Windows.Forms.DialogResult.OK)
            {
                M3UList file = new M3UList();
                file.ProgressStart += c_filesBrowser_ProgressStart;
                file.ProgressFinished += c_filesBrowser_ProgressFinished;
                file.Progress += c_filesBrowser_Progress;

                file.Save(sav.FileName, c_filesBrowser.GetFilesList());
            }
        }
        #endregion
        #region Add and edit
        private void AddFolder(object sender, EventArgs e)
        {
            FolderBrowserDialog folder = new FolderBrowserDialog();
            folder.Description = "Add favorite forlder";

            if (Program.DatabaseManager.BrowserDatabase.Folders.Count > 0)
                folder.SelectedPath = Program.DatabaseManager.BrowserDatabase.Folders
                    [Program.DatabaseManager.BrowserDatabase.Folders.Count - 1].Path;

            if (folder.ShowDialog(this) == System.Windows.Forms.DialogResult.OK)
            {
                // make sure this folder is not existed in the database
                if (!Program.DatabaseManager.BrowserDatabase.IsFolderExist(folder.SelectedPath))
                {
                    BFolder bfolder = new BFolder();
                    bfolder.Path = folder.SelectedPath;
                    //bfolder.RefreshFolders();
                    Program.DatabaseManager.BrowserDatabase.Folders.Add(bfolder);
                    c_foldersBrowser.RefreshFolders(Program.DatabaseManager.BrowserDatabase);

                    // make sure the folders list is visible
                    foreach (ControlPage pg in Program.Settings.DefaultLayout.Pages)
                    {
                        if (pg.Type == ControlType.FoldersBrowser)
                        {
                            if (!pg.Visible)
                            {
                                // make it visible !
                                pg.Visible = true;
                                AddControlAsTab(pg);
                                CheckForTabsCollapses();
                            }
                            break;
                        }
                    }
                }
            }
        }
        private void AddFiles(object sender, EventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();
            open.Filter = "Mp3 file(s) (*.mp3)|*.mp3";
            open.Multiselect = true;
            if (open.ShowDialog(this) == System.Windows.Forms.DialogResult.OK)
            {
                AddFiles(open.FileNames);
            }
        }
        private void AddFiles(string[] files)
        {
            ProgressBar1.Visible = true;
            int i = 0;
            foreach (string file in files)
            {
                c_filesBrowser.AddFileToList(file);
                int x = (i * 100) / files.Length;
                ProgressBar1.Value = x;
                StatusLabel.Text = "Adding files .." + x + " %";
                statusStrip1.Refresh();
                i++;
            }
            c_filesBrowser.Invalidate();
            saveListRequired = true;
            ProgressBar1.Visible = false;
            StatusLabel.Text = "Done.";
            // make sure the files list is visible
            foreach (ControlPage pg in Program.Settings.DefaultLayout.Pages)
            {
                if (pg.Type == ControlType.FilesBrowser)
                {
                    if (!pg.Visible)
                    {
                        // make it visible !
                        pg.Visible = true;
                        AddControlAsTab(pg);
                        CheckForTabsCollapses();
                    }
                    break;
                }
            }
        }
        private void AddFilesFolderScan(object sender, EventArgs e)
        {
            FolderBrowserDialog folder = new FolderBrowserDialog();
            folder.Description = "Scan folder for mp3 files";

            if (Program.DatabaseManager.BrowserDatabase.Folders.Count > 0)
                folder.SelectedPath = Program.DatabaseManager.BrowserDatabase.Folders
                    [Program.DatabaseManager.BrowserDatabase.Folders.Count - 1].Path;

            if (folder.ShowDialog(this) == System.Windows.Forms.DialogResult.OK)
            {
                string[] files;
                if (MessageBox.Show("Scan sub folders too ?", "Add files (folder scan)", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
                { files = Directory.GetFiles(folder.SelectedPath, "*.mp3", SearchOption.AllDirectories); }
                else
                { files = Directory.GetFiles(folder.SelectedPath, "*.mp3"); }

                ProgressBar1.Visible = true;
                int i = 0;
                foreach (string file in files)
                {
                    c_filesBrowser.AddFileToList(file);
                    int x = (i * 100) / files.Length;
                    ProgressBar1.Value = x;
                    StatusLabel.Text = "Adding files .." + x + " %";
                    statusStrip1.Refresh();
                    i++;
                }
                c_filesBrowser.Invalidate();
                saveListRequired = true;
                ProgressBar1.Visible = false;
                StatusLabel.Text = "Done.";

                // make sure the files list is visible
                foreach (ControlPage pg in Program.Settings.DefaultLayout.Pages)
                {
                    if (pg.Type == ControlType.FilesBrowser)
                    {
                        if (!pg.Visible)
                        {
                            // make it visible !
                            pg.Visible = true;
                            AddControlAsTab(pg);
                            CheckForTabsCollapses();
                        }
                        break;
                    }
                }
            }
        }
        private void Delete(object sender, EventArgs e)
        {
            switch (ativetab)
            {
                case ActiveTab.Folders:
                    if (c_foldersBrowser.CanDeleteSelected)
                    {
                        if (MessageBox.Show("Are you sure you want to delete selected folder from the list ?", "Delete",
                            MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
                        {
                            Program.DatabaseManager.BrowserDatabase.Folders.Remove(c_foldersBrowser.SelectedFolder);
                            c_foldersBrowser.RefreshFolders(Program.DatabaseManager.BrowserDatabase);
                        }
                    }
                    break;
                case ActiveTab.ListsBrowser:
                    if (MessageBox.Show("Are you sure you want to delete selected list from the list ?", "Delete",
                           MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
                    {
                        Program.DatabaseManager.BrowserDatabase.Lists.Remove(c_listsBrowser.SelectedList);
                        c_listsBrowser.RefreshLists(Program.DatabaseManager.BrowserDatabase);
                    }
                    break;
                case ActiveTab.Files: c_filesBrowser.DeleteSelected(); break;
                case ActiveTab.ImagesManager: c_imagesManager.DeleteSelected(); break;
            }
        }
        private void FullEditId3v2(object sender, EventArgs e)
        {
            if (c_filesBrowser.SelectedFilesCount == 0)
            {
                MessageBox.Show("Please select file(s) first.");
                return;
            }
            c_quickTagEditorv2_ClearMediaRequest(this, null);
            Frm_FullID3V2Edit frm = new Frm_FullID3V2Edit(c_filesBrowser.GetSelectedFiles(), Program.Settings.GenreMemory,
                Program.Settings.ArtistsMemory, Program.Settings.AlbumsMemory);
            if (frm.ShowDialog(this) == System.Windows.Forms.DialogResult.OK)
            {
                c_filesBrowser.UpdateSelectedFiles(); LoadEditorControls(null);
            }
            //   c_quickTagEditorv2_ReloadMediaRequest(this, null);
            counter = 2;
            timer1.Start();
        }
        private void FullEditId3v1(object sender, EventArgs e)
        {
            if (c_filesBrowser.SelectedFilesCount == 0)
            {
                MessageBox.Show("Please select file(s) first.");
                return;
            }
            c_quickTagEditorv2_ClearMediaRequest(this, null);
            Frm_FullEditV1 frm = new Frm_FullEditV1(c_filesBrowser.GetSelectedFiles(),
                Program.Settings.ArtistsMemory, Program.Settings.AlbumsMemory);
            if (frm.ShowDialog(this) == System.Windows.Forms.DialogResult.OK)
            {
                c_filesBrowser.UpdateSelectedFiles(); LoadEditorControls(null);
            }
            // c_quickTagEditorv2_ReloadMediaRequest(this, null);
            counter = 2;
            timer1.Start();
        }
        private void AddListFromFile(string fileName)
        {
            M3UList m3ufile = new M3UList();
            m3ufile.ProgressStart += c_filesBrowser_ProgressStart;
            m3ufile.ProgressFinished += c_filesBrowser_ProgressFinished;
            m3ufile.Progress += c_filesBrowser_Progress;

            bool setSave = c_filesBrowser.FilesCount > 0;

            string[] files = m3ufile.Load(fileName);

            if (files == null)
            {
                MessageBox.Show("Load failed !! the file is not M3U list or damaged.");
                return;
            }
            Frm_EnterName frm = new Frm_EnterName("Enter the list name", Path.GetFileNameWithoutExtension(fileName), true, false);
            frm.OkPressed += frm_OkPressed;
            if (frm.ShowDialog(this) == System.Windows.Forms.DialogResult.OK)
            {
                BList list = new BList();
                list.Name = frm.EnteredName;
                list.Files = new List<string>(files);

                bool found = Program.DatabaseManager.BrowserDatabase.IsListExist(list.Name);

                if (!found)
                    Program.DatabaseManager.BrowserDatabase.Lists.Add(list);
                else
                {
                    // overwrite
                    BList lst = Program.DatabaseManager.BrowserDatabase.GetList(list.Name);
                    lst.Files = new List<string>(c_filesBrowser.GetFilesList());
                }
                c_listsBrowser.RefreshLists(Program.DatabaseManager.BrowserDatabase);
                saveListRequired = false;
                // make sure the lists list is visible
                foreach (ControlPage pg in Program.Settings.DefaultLayout.Pages)
                {
                    if (pg.Type == ControlType.ListsBrowser)
                    {
                        if (!pg.Visible)
                        {
                            // make it visible !
                            pg.Visible = true;
                            AddControlAsTab(pg);
                            CheckForTabsCollapses();
                        }
                        break;
                    }
                }
            }
        }
        private void ClearV1(object sender, EventArgs e)
        {
            if (c_filesBrowser.SelectedFilesCount == 0)
            {
                MessageBox.Show("Please select file(s) first.");
                return;
            }
            if (MessageBox.Show("Are you sure ? This can't be undone.", "Clear Id3v1 for file(s)",
                MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == System.Windows.Forms.DialogResult.Yes)
            {
                string[] files = c_filesBrowser.GetSelectedFiles();
                foreach (string file in files)
                {
                    ID3v1.Clear(file);
                }
                c_filesBrowser.UpdateSelectedFiles();
                LoadEditorControls(null);
            }
        }
        private void ClearV2(object sender, EventArgs e)
        {
            if (c_filesBrowser.SelectedFilesCount == 0)
            {
                MessageBox.Show("Please select file(s) first.");
                return;
            }
            if (MessageBox.Show("Are you sure ? This can't be undone.", "Clear Id3v2 for file(s)",
                MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == System.Windows.Forms.DialogResult.Yes)
            {
                string[] files = c_filesBrowser.GetSelectedFiles();
                foreach (string file in files)
                {
                    ID3v2.Clear(file);
                }
                c_filesBrowser.UpdateSelectedFiles();
                LoadEditorControls(null);
            }
        }
        #endregion
        #region Layout
        private void LoadLayout(LayoutPresent layout)
        {
            /* TABS*/
            // clear tabs
            managedTabControl_downLeft.TabPages.Clear();
            managedTabControl_downMiddle.TabPages.Clear();
            managedTabControl_downRight.TabPages.Clear();
            managedTabControl_topLeft.TabPages.Clear();
            managedTabControl_topMiddle.TabPages.Clear();
            managedTabControl_topRight.TabPages.Clear();

            foreach (ControlPage pg in layout.Pages)
            {
                if (pg.Visible)
                {
                    AddControlAsTab(pg);
                }
            }
            CheckForTabsCollapses();

            /* TOOLBARS */
            toolStripContainer1.TopToolStripPanel.Controls.Clear();
            toolStripContainer1.LeftToolStripPanel.Controls.Clear();
            toolStripContainer1.RightToolStripPanel.Controls.Clear();
            toolStripContainer1.BottomToolStripPanel.Controls.Clear();

            foreach (ToolBar bar in layout.ToolBars)
            {
                AddToolbar(bar);
            }
        }
        private void AddControlAsTab(ControlPage pg)
        {
            MTCTabPage page = new MTCTabPage();
            page.Text = pg.Name;
            page.Panel = new Panel();
            page.DrawType = MTCTabPageDrawType.TextAndImage;
            switch (pg.Type)
            {
                case ControlType.FoldersBrowser:
                    page.Panel.Controls.Add(c_foldersBrowser = new C_FoldersBrowser());

                    c_foldersBrowser.ContextMenuStrip = contextMenuStrip_folders;

                    c_foldersBrowser.RefreshFolders(Program.DatabaseManager.BrowserDatabase);

                    c_foldersBrowser.Enter += c_foldersBrowser_Enter;
                    c_foldersBrowser.FolderSelected += c_foldersBrowser_FolderSelected;
                    c_foldersBrowser.FolderAddRequest += c_foldersBrowser_FolderAddRequest;

                    page.ImageIndex = 1;
                    break;
                case ControlType.ListsBrowser:
                    page.Panel.Controls.Add(c_listsBrowser = new C_ListsBrowser());

                    c_listsBrowser.RefreshLists(Program.DatabaseManager.BrowserDatabase);

                    c_listsBrowser.ContextMenuStrip = contextMenuStrip_lists;

                    c_listsBrowser.Enter += c_listsBrowser_Enter;
                    c_listsBrowser.ListSelect += c_listsBrowser_ListSelect;
                    c_listsBrowser.ListAddRequest += c_listsBrowser_ListAddRequest;
                    page.ImageIndex = 4;
                    break;
                case ControlType.FilesBrowser:
                    {
                        page.Panel.Controls.Add(c_filesBrowser = new C_FilesBrowser(Program.Settings.ColumnsManager));

                        c_filesBrowser.ContextMenuStrip = contextMenuStrip_files;

                        c_filesBrowser.Enter += c_filesBrowser_Enter;
                        c_filesBrowser.ListChanged += c_filesBrowser_ListChanged;
                        c_filesBrowser.ProgressStart += c_filesBrowser_ProgressStart;
                        c_filesBrowser.ProgressFinished += c_filesBrowser_ProgressFinished;
                        c_filesBrowser.Progress += c_filesBrowser_Progress;
                        c_filesBrowser.SwitchToColumnsMenu += c_filesBrowser_SwitchToColumnsMenu;
                        c_filesBrowser.SwitchToNormalMenu += c_filesBrowser_SwitchToNormalMenu;
                        c_filesBrowser.SelectedFilesChanged += c_filesBrowser_SelectedFilesChanged;
                        c_filesBrowser.UpdateRequired += c_filesBrowser_UpdateRequired;
                        c_filesBrowser.UpdateFinished += c_filesBrowser_UpdateFinished;
                        c_filesBrowser.ItemDoubleClick += c_filesBrowser_ItemDoubleClick;

                        c_filesBrowser.ClearMediaRequest += c_quickTagEditorv2_ClearMediaRequest;
                        c_filesBrowser.ReloadMediaRequest += c_quickTagEditorv2_ReloadMediaRequest;
                        c_filesBrowser.StopMediaRequest += c_quickTagEditorv2_StopMediaRequest;
                        c_filesBrowser.PlayMediaRequest += c_quickTagEditorv2_PlayMediaRequest;
                        page.ImageIndex = 0;
                        break;
                    }
                case ControlType.QuickEditorV2:
                    page.Panel.Controls.Add(c_quickTagEditorv2 = new C_QuickTagEditorV2(Program.Settings.GenreMemory,
                        Program.Settings.ArtistsMemory, Program.Settings.AlbumsMemory));

                    c_quickTagEditorv2.Enter += c_quickTagEditor_Enter;
                    c_quickTagEditorv2.ProgressStart += c_filesBrowser_ProgressStart;
                    c_quickTagEditorv2.ProgressFinished += c_filesBrowser_ProgressFinished;
                    c_quickTagEditorv2.Progress += c_filesBrowser_Progress;
                    c_quickTagEditorv2.UpdateRequired += c_quickTagEditor_UpdateRequired;
                    c_quickTagEditorv2.MemoryUpdated += c_quickTagEditor_MemoryUpdated;
                    c_quickTagEditorv2.ClearMediaRequest += c_quickTagEditorv2_ClearMediaRequest;
                    c_quickTagEditorv2.ReloadMediaRequest += c_quickTagEditorv2_ReloadMediaRequest;
                    c_quickTagEditorv2.StopMediaRequest += c_quickTagEditorv2_StopMediaRequest;
                    c_quickTagEditorv2.PlayMediaRequest += c_quickTagEditorv2_PlayMediaRequest;
                    page.ImageIndex = 3;
                    break;
                case ControlType.QuickEditorV1:
                    page.Panel.Controls.Add(c_quickTagEditorv1 = new C_QuickTagEditorV1(Program.Settings.ArtistsMemory, Program.Settings.AlbumsMemory));

                    c_quickTagEditorv1.Enter += c_quickTagEditorv1_Enter;
                    c_quickTagEditorv1.ProgressStart += c_filesBrowser_ProgressStart;
                    c_quickTagEditorv1.ProgressFinished += c_filesBrowser_ProgressFinished;
                    c_quickTagEditorv1.Progress += c_filesBrowser_Progress;
                    c_quickTagEditorv1.UpdateRequired += c_quickTagEditorv1_UpdateRequired;
                    c_quickTagEditorv1.MemoryUpdated += c_quickTagEditorv1_MemoryUpdated;
                    c_quickTagEditorv1.ClearMediaRequest += c_quickTagEditorv2_ClearMediaRequest;
                    c_quickTagEditorv1.ReloadMediaRequest += c_quickTagEditorv2_ReloadMediaRequest;
                    c_quickTagEditorv1.StopMediaRequest += c_quickTagEditorv2_StopMediaRequest;
                    c_quickTagEditorv1.PlayMediaRequest += c_quickTagEditorv2_PlayMediaRequest;
                    page.ImageIndex = 3;
                    break;
                case ControlType.ImagesManager:
                    page.Panel.Controls.Add(c_imagesManager = new C_ImagesManager());

                    c_imagesManager.Enter += c_imagesManager_Enter;
                    c_imagesManager.ProgressStart += c_filesBrowser_ProgressStart;
                    c_imagesManager.ProgressFinished += c_filesBrowser_ProgressFinished;
                    c_imagesManager.Progress += c_filesBrowser_Progress;
                    c_imagesManager.UpdateRequired += c_imagesManager_UpdateRequired;
                    c_imagesManager.ClearMediaRequest += c_quickTagEditorv2_ClearMediaRequest;
                    c_imagesManager.ReloadMediaRequest += c_quickTagEditorv2_ReloadMediaRequest;
                    c_imagesManager.StopMediaRequest += c_quickTagEditorv2_StopMediaRequest;
                    c_imagesManager.PlayMediaRequest += c_quickTagEditorv2_PlayMediaRequest;
                    page.ImageIndex = 2;
                    break;
                case ControlType.AllTextFrames:
                    page.Panel.Controls.Add(c_allTextFrames = new C_FullTextFramesEditor(Program.Settings.GenreMemory, Program.Settings.ArtistsMemory, Program.Settings.AlbumsMemory));

                    c_allTextFrames.Enter += c_allTextFrames_Enter;
                    c_allTextFrames.ProgressStart += c_filesBrowser_ProgressStart;
                    c_allTextFrames.ProgressFinished += c_filesBrowser_ProgressFinished;
                    c_allTextFrames.Progress += c_filesBrowser_Progress;
                    c_allTextFrames.UpdateRequired += c_allTextFrames_UpdateRequired;
                    c_allTextFrames.MemoryUpdated += c_allTextFrames_MemoryUpdated;
                    c_allTextFrames.ClearMediaRequest += c_quickTagEditorv2_ClearMediaRequest;
                    c_allTextFrames.ReloadMediaRequest += c_quickTagEditorv2_ReloadMediaRequest;
                    c_allTextFrames.StopMediaRequest += c_quickTagEditorv2_StopMediaRequest;
                    c_allTextFrames.PlayMediaRequest += c_quickTagEditorv2_PlayMediaRequest;
                    page.ImageIndex = 5;
                    break;
                case ControlType.URLLinkFrames:
                    page.Panel.Controls.Add(c_urlLinkFrames = new C_UrlLinkEditor());

                    c_urlLinkFrames.Enter += c_urlLinkFrames_Enter;
                    c_urlLinkFrames.ProgressStart += c_filesBrowser_ProgressStart;
                    c_urlLinkFrames.ProgressFinished += c_filesBrowser_ProgressFinished;
                    c_urlLinkFrames.Progress += c_filesBrowser_Progress;
                    c_urlLinkFrames.UpdateRequired += c_urlLinkFrames_UpdateRequired;
                    c_urlLinkFrames.ClearMediaRequest += c_quickTagEditorv2_ClearMediaRequest;
                    c_urlLinkFrames.ReloadMediaRequest += c_quickTagEditorv2_ReloadMediaRequest;
                    c_urlLinkFrames.StopMediaRequest += c_quickTagEditorv2_StopMediaRequest;
                    c_urlLinkFrames.PlayMediaRequest += c_quickTagEditorv2_PlayMediaRequest;
                    page.ImageIndex = 6;
                    break;
                case ControlType.CommentsEditor:
                    page.Panel.Controls.Add(c_commentsEditor = new C_CommentsEditor());

                    c_commentsEditor.Enter += c_commentsEditor_Enter;
                    c_commentsEditor.ProgressStart += c_filesBrowser_ProgressStart;
                    c_commentsEditor.ProgressFinished += c_filesBrowser_ProgressFinished;
                    c_commentsEditor.Progress += c_filesBrowser_Progress;
                    c_commentsEditor.UpdateRequired += c_commentsEditor_UpdateRequired;
                    c_commentsEditor.ClearMediaRequest += c_quickTagEditorv2_ClearMediaRequest;
                    c_commentsEditor.ReloadMediaRequest += c_quickTagEditorv2_ReloadMediaRequest;
                    c_commentsEditor.StopMediaRequest += c_quickTagEditorv2_StopMediaRequest;
                    c_commentsEditor.PlayMediaRequest += c_quickTagEditorv2_PlayMediaRequest;
                    page.ImageIndex = 7;
                    break;
                case ControlType.Popularimeter:
                    page.Panel.Controls.Add(c_popularimeter = new C_Popularimeter());

                    c_popularimeter.Enter += c_popularimeter_Enter;
                    c_popularimeter.ProgressStart += c_filesBrowser_ProgressStart;
                    c_popularimeter.ProgressFinished += c_filesBrowser_ProgressFinished;
                    c_popularimeter.Progress += c_filesBrowser_Progress;
                    c_popularimeter.UpdateRequired += c_popularimeter_UpdateRequired;
                    c_popularimeter.ClearMediaRequest += c_quickTagEditorv2_ClearMediaRequest;
                    c_popularimeter.ReloadMediaRequest += c_quickTagEditorv2_ReloadMediaRequest;
                    c_popularimeter.StopMediaRequest += c_quickTagEditorv2_StopMediaRequest;
                    c_popularimeter.PlayMediaRequest += c_quickTagEditorv2_PlayMediaRequest;
                    page.ImageIndex = 8;
                    break;
                case ControlType.InvolvedPeopleList:
                    page.Panel.Controls.Add(c_involvedPeople = new C_InvolvedPeopleList());

                    c_involvedPeople.Enter += c_involvedPeople_Enter;
                    c_involvedPeople.ProgressStart += c_filesBrowser_ProgressStart;
                    c_involvedPeople.ProgressFinished += c_filesBrowser_ProgressFinished;
                    c_involvedPeople.Progress += c_filesBrowser_Progress;
                    c_involvedPeople.UpdateRequired += c_involvedPeople_UpdateRequired;
                    c_involvedPeople.ClearMediaRequest += c_quickTagEditorv2_ClearMediaRequest;
                    c_involvedPeople.ReloadMediaRequest += c_quickTagEditorv2_ReloadMediaRequest;
                    c_involvedPeople.StopMediaRequest += c_quickTagEditorv2_StopMediaRequest;
                    c_involvedPeople.PlayMediaRequest += c_quickTagEditorv2_PlayMediaRequest;
                    page.ImageIndex = 9;
                    break;
                case ControlType.UnsychronisedLyrics:
                    page.Panel.Controls.Add(c_unsychronisedLyrics = new C_UnsychronisedLyrics());

                    c_unsychronisedLyrics.Enter += c_unsychronisedLyrics_Enter;
                    c_unsychronisedLyrics.ProgressStart += c_filesBrowser_ProgressStart;
                    c_unsychronisedLyrics.ProgressFinished += c_filesBrowser_ProgressFinished;
                    c_unsychronisedLyrics.Progress += c_filesBrowser_Progress;
                    c_unsychronisedLyrics.UpdateRequired += c_unsychronisedLyrics_UpdateRequired;
                    c_unsychronisedLyrics.ClearMediaRequest += c_quickTagEditorv2_ClearMediaRequest;
                    c_unsychronisedLyrics.ReloadMediaRequest += c_quickTagEditorv2_ReloadMediaRequest;
                    c_unsychronisedLyrics.StopMediaRequest += c_quickTagEditorv2_StopMediaRequest;
                    c_unsychronisedLyrics.PlayMediaRequest += c_quickTagEditorv2_PlayMediaRequest;
                    page.ImageIndex = 10;
                    break;
                case ControlType.UniqueFileIdentifier:
                    page.Panel.Controls.Add(c_uniqueFileIdentifier = new C_UniqueFileIdentifier());

                    c_uniqueFileIdentifier.Enter += c_uniqueFileIdentifier_Enter;
                    c_uniqueFileIdentifier.ProgressStart += c_filesBrowser_ProgressStart;
                    c_uniqueFileIdentifier.ProgressFinished += c_filesBrowser_ProgressFinished;
                    c_uniqueFileIdentifier.Progress += c_filesBrowser_Progress;
                    c_uniqueFileIdentifier.UpdateRequired += c_uniqueFileIdentifier_UpdateRequired;
                    c_uniqueFileIdentifier.ClearMediaRequest += c_quickTagEditorv2_ClearMediaRequest;
                    c_uniqueFileIdentifier.ReloadMediaRequest += c_quickTagEditorv2_ReloadMediaRequest;
                    c_uniqueFileIdentifier.StopMediaRequest += c_quickTagEditorv2_StopMediaRequest;
                    c_uniqueFileIdentifier.PlayMediaRequest += c_quickTagEditorv2_PlayMediaRequest;
                    page.ImageIndex = 11;
                    break;
                case ControlType.MusicCDIdentifier:
                    page.Panel.Controls.Add(c_musicCDIdentifier = new C_MusicCDIdentifier());

                    c_musicCDIdentifier.Enter += C_musicCDIdentifier_Enter;
                    c_musicCDIdentifier.ProgressStart += c_filesBrowser_ProgressStart;
                    c_musicCDIdentifier.ProgressFinished += c_filesBrowser_ProgressFinished;
                    c_musicCDIdentifier.Progress += c_filesBrowser_Progress;
                    c_musicCDIdentifier.UpdateRequired += C_musicCDIdentifier_UpdateRequired;
                    c_musicCDIdentifier.ClearMediaRequest += c_quickTagEditorv2_ClearMediaRequest;
                    c_musicCDIdentifier.ReloadMediaRequest += c_quickTagEditorv2_ReloadMediaRequest;
                    c_musicCDIdentifier.StopMediaRequest += c_quickTagEditorv2_StopMediaRequest;
                    c_musicCDIdentifier.PlayMediaRequest += c_quickTagEditorv2_PlayMediaRequest;
                    page.ImageIndex = 12;
                    break;
                case ControlType.GeneralEncapsulatedObject:
                    page.Panel.Controls.Add(c_generalEncapsulatedObject = new C_GeneralEncapsulatedObject());

                    c_generalEncapsulatedObject.Enter += c_generalEncapsulatedObject_Enter;
                    c_generalEncapsulatedObject.ProgressStart += c_filesBrowser_ProgressStart;
                    c_generalEncapsulatedObject.ProgressFinished += c_filesBrowser_ProgressFinished;
                    c_generalEncapsulatedObject.Progress += c_filesBrowser_Progress;
                    c_generalEncapsulatedObject.UpdateRequired += c_generalEncapsulatedObject_UpdateRequired;
                    c_generalEncapsulatedObject.ClearMediaRequest += c_quickTagEditorv2_ClearMediaRequest;
                    c_generalEncapsulatedObject.ReloadMediaRequest += c_quickTagEditorv2_ReloadMediaRequest;
                    c_generalEncapsulatedObject.StopMediaRequest += c_quickTagEditorv2_StopMediaRequest;
                    c_generalEncapsulatedObject.PlayMediaRequest += c_quickTagEditorv2_PlayMediaRequest;
                    page.ImageIndex = 13;
                    break;
                case ControlType.Commercial:
                    page.Panel.Controls.Add(c_commercial = new C_Commercial());

                    c_commercial.Enter += c_commercial_Enter;
                    c_commercial.ProgressStart += c_filesBrowser_ProgressStart;
                    c_commercial.ProgressFinished += c_filesBrowser_ProgressFinished;
                    c_commercial.Progress += c_filesBrowser_Progress;
                    c_commercial.UpdateRequired += c_commercial_UpdateRequired;
                    c_commercial.ClearMediaRequest += c_quickTagEditorv2_ClearMediaRequest;
                    c_commercial.ReloadMediaRequest += c_quickTagEditorv2_ReloadMediaRequest;
                    c_commercial.StopMediaRequest += c_quickTagEditorv2_StopMediaRequest;
                    c_commercial.PlayMediaRequest += c_quickTagEditorv2_PlayMediaRequest;
                    page.ImageIndex = 14;
                    break;
                case ControlType.PlayCounter:
                    page.Panel.Controls.Add(c_playCounter = new C_PlayCounter());

                    c_playCounter.Enter += c_playCounter_Enter;
                    c_playCounter.ProgressStart += c_filesBrowser_ProgressStart;
                    c_playCounter.ProgressFinished += c_filesBrowser_ProgressFinished;
                    c_playCounter.Progress += c_filesBrowser_Progress;
                    c_playCounter.UpdateRequired += c_playCounter_UpdateRequired;
                    c_playCounter.ClearMediaRequest += c_quickTagEditorv2_ClearMediaRequest;
                    c_playCounter.ReloadMediaRequest += c_quickTagEditorv2_ReloadMediaRequest;
                    c_playCounter.StopMediaRequest += c_quickTagEditorv2_StopMediaRequest;
                    c_playCounter.PlayMediaRequest += c_quickTagEditorv2_PlayMediaRequest;
                    page.ImageIndex = 15;
                    break;
                case ControlType.EventTimingCodes:
                    page.Panel.Controls.Add(c_eventTimingCodes = new C_EventTimingCodes());

                    c_eventTimingCodes.Enter += c_eventTimingCodes_Enter;
                    c_eventTimingCodes.ProgressStart += c_filesBrowser_ProgressStart;
                    c_eventTimingCodes.ProgressFinished += c_filesBrowser_ProgressFinished;
                    c_eventTimingCodes.Progress += c_filesBrowser_Progress;
                    c_eventTimingCodes.UpdateRequired += c_eventTimingCodes_UpdateRequired;
                    c_eventTimingCodes.ClearMediaRequest += c_quickTagEditorv2_ClearMediaRequest;
                    c_eventTimingCodes.ReloadMediaRequest += c_quickTagEditorv2_ReloadMediaRequest;
                    c_eventTimingCodes.StopMediaRequest += c_quickTagEditorv2_StopMediaRequest;
                    c_eventTimingCodes.PlayMediaRequest += c_quickTagEditorv2_PlayMediaRequest;
                    page.ImageIndex = 16;
                    break;
                case ControlType.SynchronisedLyrics:
                    page.Panel.Controls.Add(c_synchronisedLyrics = new C_SynchronisedLyrics());

                    c_synchronisedLyrics.Enter += c_synchronisedLyrics_Enter;
                    c_synchronisedLyrics.ProgressStart += c_filesBrowser_ProgressStart;
                    c_synchronisedLyrics.ProgressFinished += c_filesBrowser_ProgressFinished;
                    c_synchronisedLyrics.Progress += c_filesBrowser_Progress;
                    c_synchronisedLyrics.ClearMediaRequest += c_quickTagEditorv2_ClearMediaRequest;
                    c_synchronisedLyrics.ReloadMediaRequest += c_quickTagEditorv2_ReloadMediaRequest;
                    c_synchronisedLyrics.UpdateRequired += c_synchronisedLyrics_UpdateRequired;
                    c_synchronisedLyrics.StopMediaRequest += c_quickTagEditorv2_StopMediaRequest;
                    c_synchronisedLyrics.PlayMediaRequest += c_quickTagEditorv2_PlayMediaRequest;
                    page.ImageIndex = 17;
                    break;
                case ControlType.MediaPlayer:
                    page.Panel.Controls.Add(c_mediaPlayer = new C_MediaPlayer(Program.Settings.MediaPlayerAutoStart));

                    c_mediaPlayer.Enter += c_mediaPlayer_Enter;
                    c_mediaPlayer.ClearMediaRequest += c_quickTagEditorv2_ClearMediaRequest;
                    c_mediaPlayer.ReloadMediaRequest += c_quickTagEditorv2_ReloadMediaRequest;
                    c_mediaPlayer.StopMediaRequest += c_quickTagEditorv2_StopMediaRequest;
                    c_mediaPlayer.PlayMediaRequest += c_quickTagEditorv2_PlayMediaRequest;
                    page.ImageIndex = 18;
                    break;
                case ControlType.Log:
                    page.Panel.Controls.Add(loggerControl = new LoggerControl());

                    loggerControl.Enter += loggerControl_Enter;
                    page.ImageIndex = 19;
                    break;
                case ControlType.TermsOfUseFrame:
                    page.Panel.Controls.Add(c_termsOfUse = new C_TermsOfUseFrame());

                    c_termsOfUse.Enter += c_termsOfUse_Enter;
                    c_termsOfUse.ProgressStart += c_filesBrowser_ProgressStart;
                    c_termsOfUse.ProgressFinished += c_filesBrowser_ProgressFinished;
                    c_termsOfUse.Progress += c_filesBrowser_Progress;
                    c_termsOfUse.UpdateRequired += c_termsOfUse_UpdateRequired;
                    c_termsOfUse.ClearMediaRequest += c_quickTagEditorv2_ClearMediaRequest;
                    c_termsOfUse.ReloadMediaRequest += c_quickTagEditorv2_ReloadMediaRequest;
                    c_termsOfUse.StopMediaRequest += c_quickTagEditorv2_StopMediaRequest;
                    c_termsOfUse.PlayMediaRequest += c_quickTagEditorv2_PlayMediaRequest;
                    page.ImageIndex = 20;
                    break;
                case ControlType.TagExplorer:
                    page.Panel.Controls.Add(c_tagExplorer = new C_TagExplorer());

                    c_tagExplorer.Enter += c_tagExplorer_Enter;
                    c_tagExplorer.StopMediaRequest += c_quickTagEditorv2_StopMediaRequest;
                    c_tagExplorer.PlayMediaRequest += c_quickTagEditorv2_PlayMediaRequest;
                    c_tagExplorer.ClearMediaRequest += c_quickTagEditorv2_ClearMediaRequest;
                    c_tagExplorer.ReloadMediaRequest += c_quickTagEditorv2_ReloadMediaRequest;
                    c_tagExplorer.StopMediaRequest += c_quickTagEditorv2_StopMediaRequest;
                    c_tagExplorer.PlayMediaRequest += c_quickTagEditorv2_PlayMediaRequest;
                    page.ImageIndex = 21;
                    break;
            }
            page.Panel.Controls[0].Dock = DockStyle.Fill;
            switch (pg.Location)
            {
                case ControlLocation.DownLeft: managedTabControl_downLeft.TabPages.Add(page); break;
                case ControlLocation.DownMiddle: managedTabControl_downMiddle.TabPages.Add(page); break;
                case ControlLocation.DownRight: managedTabControl_downRight.TabPages.Add(page); break;
                case ControlLocation.TopLeft: managedTabControl_topLeft.TabPages.Add(page); break;
                case ControlLocation.TopMiddle: managedTabControl_topMiddle.TabPages.Add(page); break;
                case ControlLocation.TopRight: managedTabControl_topRight.TabPages.Add(page); break;
            }
        }
        private void AddToolbar(ToolBar bar)
        {
            switch (bar.Type)
            {
                case ToolBarType.Main:
                    toolStrip_main.Location = bar.Position;
                    toolStrip_main.Visible = bar.Visible;
                    switch (bar.Location)
                    {
                        case ToolBarLocation.Bottom: toolStripContainer1.BottomToolStripPanel.Controls.Add(toolStrip_main); break;
                        case ToolBarLocation.Left: toolStripContainer1.LeftToolStripPanel.Controls.Add(toolStrip_main); break;
                        case ToolBarLocation.Right: toolStripContainer1.RightToolStripPanel.Controls.Add(toolStrip_main); break;
                        case ToolBarLocation.Top: toolStripContainer1.TopToolStripPanel.Controls.Add(toolStrip_main); break;
                    }
                    break;
            }
        }
        private void SaveToolbars()
        {
            foreach (ToolBar bar in Program.Settings.DefaultLayout.ToolBars)
            {
                switch (bar.Type)
                {
                    case ToolBarType.Main:
                        bar.Position = toolStrip_main.Location;
                        bar.Visible = toolStrip_main.Visible;
                        if (toolStrip_main.Parent == toolStripContainer1.BottomToolStripPanel)
                            bar.Location = ToolBarLocation.Bottom;
                        if (toolStrip_main.Parent == toolStripContainer1.LeftToolStripPanel)
                            bar.Location = ToolBarLocation.Left;
                        if (toolStrip_main.Parent == toolStripContainer1.RightToolStripPanel)
                            bar.Location = ToolBarLocation.Right;
                        if (toolStrip_main.Parent == toolStripContainer1.TopToolStripPanel)
                            bar.Location = ToolBarLocation.Top;
                        break;
                }
            }
        }
        private void ExpandTabs()
        {
            splitContainer1.Panel1Collapsed = splitContainer1.Panel2Collapsed = false;
            splitContainer2.Panel1Collapsed = splitContainer2.Panel2Collapsed = false;
            splitContainer3.Panel1Collapsed = splitContainer3.Panel2Collapsed = false;
            splitContainer4.Panel1Collapsed = splitContainer4.Panel2Collapsed = false;
            splitContainer5.Panel1Collapsed = splitContainer5.Panel2Collapsed = false;
        }
        private void CheckForTabsCollapses()
        {
            ExpandTabs();
            //clear view tab
            if (managedTabControl_downLeft.TabPages.Count > 0)
                if (managedTabControl_downLeft.TabPages[0].Text == "")
                    managedTabControl_downLeft.TabPages.RemoveAt(0);
            if (managedTabControl_downMiddle.TabPages.Count > 0)
                if (managedTabControl_downMiddle.TabPages[0].Text == "")
                    managedTabControl_downMiddle.TabPages.RemoveAt(0);
            if (managedTabControl_downRight.TabPages.Count > 0)
                if (managedTabControl_downRight.TabPages[0].Text == "")
                    managedTabControl_downRight.TabPages.RemoveAt(0);
            if (managedTabControl_topLeft.TabPages.Count > 0)
                if (managedTabControl_topLeft.TabPages[0].Text == "")
                    managedTabControl_topLeft.TabPages.RemoveAt(0);
            if (managedTabControl_topMiddle.TabPages.Count > 0)
                if (managedTabControl_topMiddle.TabPages[0].Text == "")
                    managedTabControl_topMiddle.TabPages.RemoveAt(0);
            if (managedTabControl_topRight.TabPages.Count > 0)
                if (managedTabControl_topRight.TabPages[0].Text == "")
                    managedTabControl_topRight.TabPages.RemoveAt(0);

            //Right Area
            if (managedTabControl_topRight.TabPages.Count == 0)
                splitContainer5.Panel1Collapsed = true;
            if (managedTabControl_downRight.TabPages.Count == 0)
                splitContainer5.Panel2Collapsed = true;
            if ((managedTabControl_topRight.TabPages.Count == 0) & (managedTabControl_downRight.TabPages.Count == 0))
                splitContainer2.Panel2Collapsed = true;
            //Middle area
            if (managedTabControl_topMiddle.TabPages.Count == 0)
                splitContainer4.Panel1Collapsed = true;
            if (managedTabControl_downMiddle.TabPages.Count == 0)
                splitContainer4.Panel2Collapsed = true;
            if ((managedTabControl_topMiddle.TabPages.Count == 0) & (managedTabControl_downMiddle.TabPages.Count == 0))
                splitContainer2.Panel1Collapsed = true;
            //Left area
            if (managedTabControl_topLeft.TabPages.Count == 0)
                splitContainer3.Panel1Collapsed = true;
            if (managedTabControl_downLeft.TabPages.Count == 0)
                splitContainer3.Panel2Collapsed = true;
            if ((managedTabControl_topLeft.TabPages.Count == 0) & (managedTabControl_downLeft.TabPages.Count == 0))
                splitContainer1.Panel1Collapsed = true;
            //
            if ((managedTabControl_topMiddle.TabPages.Count == 0) & (managedTabControl_topLeft.TabPages.Count == 0) &
                (managedTabControl_downMiddle.TabPages.Count == 0) & (managedTabControl_downLeft.TabPages.Count == 0))
                splitContainer1.Panel1Collapsed = true;
        }
        private void CheckDragAndDrop()
        {
            if (managedTabControl_downLeft.TabPages.Count == 0)
                managedTabControl_downLeft.TabPages.Add(new MTCTabPage("", ""));
            if (managedTabControl_downMiddle.TabPages.Count == 0)
                managedTabControl_downMiddle.TabPages.Add(new MTCTabPage("", ""));
            if (managedTabControl_downRight.TabPages.Count == 0)
                managedTabControl_downRight.TabPages.Add(new MTCTabPage("", ""));
            if (managedTabControl_topLeft.TabPages.Count == 0)
                managedTabControl_topLeft.TabPages.Add(new MTCTabPage("", ""));
            if (managedTabControl_topMiddle.TabPages.Count == 0)
                managedTabControl_topMiddle.TabPages.Add(new MTCTabPage("", ""));
            if (managedTabControl_topRight.TabPages.Count == 0)
                managedTabControl_topRight.TabPages.Add(new MTCTabPage("", ""));
        }
        private void SaveTabParent(string name, ControlLocation location)
        {
            foreach (ControlPage pg in Program.Settings.DefaultLayout.Pages)
            {
                if (pg.Name == name)
                {
                    pg.Location = location;
                    AddControlAsTab(pg);
                    break;
                }
            }
        }
        private void resetLayoutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Program.Settings.DefaultLayout.BuildDefaultLayout();
            LoadLayout(Program.Settings.DefaultLayout);
        }
        private void SaveLayout(string fileName, LayoutPresent layout)
        {
            try
            {
                SaveToolbars();
                Stream str = new FileStream(fileName, FileMode.Create, FileAccess.Write);
                XmlSerializer ser = new XmlSerializer(typeof(LayoutPresent));
                ser.Serialize(str, layout);
                str.Close();
            }
            catch
            { }
        }
        private void LoadLayout(string fileName)
        {
            try
            {
                LayoutPresent layout;
                Stream str = new FileStream(fileName, FileMode.Open, FileAccess.Read);
                XmlSerializer ser = new XmlSerializer(typeof(LayoutPresent));
                layout = (LayoutPresent)ser.Deserialize(str);
                str.Close();

                LoadLayout(layout);
            }
            catch
            { }
        }
        #endregion
        #region Columns
        private void ShowHideColumn(string columnName)
        {
            foreach (ColumnItem cl in c_filesBrowser.ColumnsManager.Columns)
            {
                if (cl.ColumnName == columnName)
                {
                    cl.Visible = !cl.Visible;
                    c_filesBrowser.RefreshColumns();
                    break;
                }
            }
        }
        #endregion
        private void RenameFilesUsingTag(object sender, EventArgs e)
        {
            if (c_filesBrowser.SelectedFilesCount == 0)
            {
                MessageBox.Show("Please select file(s) first.");
                return;
            }
            Frm_RenameUsingTag frm = new Frm_RenameUsingTag();
            if (frm.ShowDialog(this) == System.Windows.Forms.DialogResult.OK)
            {
                c_quickTagEditorv2_ClearMediaRequest(this, null);
                string[] codes = frm.EnteredCode.Split(new char[] { '<', '>' }, StringSplitOptions.RemoveEmptyEntries);
                string[] files = c_filesBrowser.GetSelectedFiles();
                List<string> newPaths = new List<string>();
                ProgressBar1.Visible = true;
                int i = 0;
                foreach (string file in files)
                {
                    // decode
                    ID3v2 v2 = new ID3v2();
                    v2.Load(file);
                    ID3v2QuickWrapper wr = new ID3v2QuickWrapper(v2);
                    string newFileName = "";
                    for (int j = 0; j < codes.Length; j++)
                    {
                        switch (codes[j])
                        {
                            case "Title": newFileName += wr.Title; break;
                            case "Artist": newFileName += wr.Artist; break;
                            case "Album": newFileName += wr.Album; break;
                            case "Comment": newFileName += wr.Comment; break;
                            case "Track":
                                {
                                    newFileName += wr.Track.Replace("/", "-");
                                    break;
                                }
                            case "Track2":
                            case "Track3":
                            case "Track4":
                            case "Track5":
                            case "Track6":
                            case "Track7":
                            case "Track8":
                            case "Track9":
                                {
                                    int val = 0;
                                    string trk = wr.Track;
                                    if (int.TryParse(trk, out val))
                                    {
                                        newFileName += val.ToString(string.Format("D{0}", codes[j].Substring(codes[j].Length - 1, 1)));
                                    }
                                    else
                                        newFileName += wr.Track.Replace("/", "-");
                                    break;
                                }
                            case "Year": newFileName += wr.Year; break;
                            case "FileName": newFileName += Path.GetFileNameWithoutExtension(file); break;
                            default: newFileName += codes[j]; break;
                        }
                    }
                    // rename
                    newFileName += ".mp3";
                    newFileName = newFileName.Replace("\0", "");
                    if (newFileName == Path.GetFileName(file))
                        continue;

                    string directory = Path.GetDirectoryName(file);
                    if (directory == "")
                        directory = Path.GetPathRoot(file);

                    File.Copy(file, directory + "\\" + newFileName);
                    newPaths.Add(directory + "\\" + newFileName);
                    FileInfo inf = new FileInfo(file);
                    inf.IsReadOnly = false;
                    File.Delete(file);
                    // advance progress
                    int x = (i * 100) / files.Length;
                    ProgressBar1.Value = x;
                    StatusLabel.Text = "Renaming .." + x + " %";
                    statusStrip1.Refresh();
                    i++;
                }
                c_filesBrowser.Invalidate();
                saveListRequired = true;
                ProgressBar1.Visible = false;
                StatusLabel.Text = "Done.";
                // delete these files from the browser
                c_filesBrowser.DeleteSelected(false);
                // add the new ones
                foreach (string ff in newPaths)
                    c_filesBrowser.AddFileToList(ff);
                if (c_filesBrowser.managedListView1.Items.Count > 0)
                    c_filesBrowser.managedListView1.ScrollToItem(c_filesBrowser.managedListView1.Items.Count - 1);
                c_filesBrowser.managedListView1.Invalidate();
                c_quickTagEditorv2_ReloadMediaRequest(this, null);
            }
        }

        // load editor controls with files selection. Call this when files selection changed
        private void LoadEditorControls(UserControl controlToExclude)
        {
            string[] files = c_filesBrowser.GetSelectedFiles();
            if (controlToExclude != null)
            {
                if (!(controlToExclude is C_FullTextFramesEditor))
                    if (IsControlVisible(ControlType.AllTextFrames))
                        c_allTextFrames.SelectedFiles = files;
                if (!(controlToExclude is C_QuickTagEditorV1))
                    if (IsControlVisible(ControlType.QuickEditorV1))
                        c_quickTagEditorv1.SelectedFiles = files;
                if (!(controlToExclude is C_ImagesManager))
                    if (IsControlVisible(ControlType.ImagesManager))
                        c_imagesManager.SelectedFiles = files;
                if (!(controlToExclude is C_QuickTagEditorV2))
                    if (IsControlVisible(ControlType.QuickEditorV2))
                        c_quickTagEditorv2.SelectedFiles = files;
                if (!(controlToExclude is C_UrlLinkEditor))
                    if (IsControlVisible(ControlType.URLLinkFrames))
                        c_urlLinkFrames.SelectedFiles = files;
                if (!(controlToExclude is C_CommentsEditor))
                    if (IsControlVisible(ControlType.CommentsEditor))
                        c_commentsEditor.SelectedFiles = files;
                if (!(controlToExclude is C_Popularimeter))
                    if (IsControlVisible(ControlType.Popularimeter))
                        c_popularimeter.SelectedFiles = files;
                if (!(controlToExclude is C_InvolvedPeopleList))
                    if (IsControlVisible(ControlType.InvolvedPeopleList))
                        c_involvedPeople.SelectedFiles = files;
                if (!(controlToExclude is C_UnsychronisedLyrics))
                    if (IsControlVisible(ControlType.UnsychronisedLyrics))
                        c_unsychronisedLyrics.SelectedFiles = files;
                if (!(controlToExclude is C_UniqueFileIdentifier))
                    if (IsControlVisible(ControlType.UniqueFileIdentifier))
                        c_uniqueFileIdentifier.SelectedFiles = files;
                if (!(controlToExclude is C_MusicCDIdentifier))
                    if (IsControlVisible(ControlType.MusicCDIdentifier))
                        c_musicCDIdentifier.SelectedFiles = files;
                if (!(controlToExclude is C_GeneralEncapsulatedObject))
                    if (IsControlVisible(ControlType.GeneralEncapsulatedObject))
                        c_generalEncapsulatedObject.SelectedFiles = files;
                if (!(controlToExclude is C_Commercial))
                    if (IsControlVisible(ControlType.Commercial))
                        c_commercial.SelectedFiles = files;
                if (!(controlToExclude is C_PlayCounter))
                    if (IsControlVisible(ControlType.PlayCounter))
                        c_playCounter.SelectedFiles = files;
                if (!(controlToExclude is C_EventTimingCodes))
                    if (IsControlVisible(ControlType.EventTimingCodes))
                        c_eventTimingCodes.SelectedFiles = files;
                if (!(controlToExclude is C_SynchronisedLyrics))
                    if (IsControlVisible(ControlType.SynchronisedLyrics))
                        c_synchronisedLyrics.SelectedFiles = files;
                if (!(controlToExclude is C_MediaPlayer))
                    if (IsControlVisible(ControlType.MediaPlayer))
                        c_mediaPlayer.SelectedFiles = files;
                if (!(controlToExclude is C_TermsOfUseFrame))
                    if (IsControlVisible(ControlType.TermsOfUseFrame))
                        c_termsOfUse.SelectedFiles = files;
                if (!(controlToExclude is C_TagExplorer))
                    if (IsControlVisible(ControlType.TagExplorer))
                        c_tagExplorer.SelectedFiles = files;
            }
            else
            {
                if (IsControlVisible(ControlType.AllTextFrames))
                    c_allTextFrames.SelectedFiles = files;
                if (IsControlVisible(ControlType.QuickEditorV1))
                    c_quickTagEditorv1.SelectedFiles = files;
                if (IsControlVisible(ControlType.ImagesManager))
                    c_imagesManager.SelectedFiles = files;
                if (IsControlVisible(ControlType.QuickEditorV2))
                    c_quickTagEditorv2.SelectedFiles = files;
                if (IsControlVisible(ControlType.URLLinkFrames))
                    c_urlLinkFrames.SelectedFiles = files;
                if (IsControlVisible(ControlType.CommentsEditor))
                    c_commentsEditor.SelectedFiles = files;
                if (IsControlVisible(ControlType.Popularimeter))
                    c_popularimeter.SelectedFiles = files;
                if (IsControlVisible(ControlType.InvolvedPeopleList))
                    c_involvedPeople.SelectedFiles = files;
                if (IsControlVisible(ControlType.UnsychronisedLyrics))
                    c_unsychronisedLyrics.SelectedFiles = files;
                if (IsControlVisible(ControlType.UniqueFileIdentifier))
                    c_uniqueFileIdentifier.SelectedFiles = files;
                if (IsControlVisible(ControlType.MusicCDIdentifier))
                    c_musicCDIdentifier.SelectedFiles = files;
                if (IsControlVisible(ControlType.GeneralEncapsulatedObject))
                    c_generalEncapsulatedObject.SelectedFiles = files;
                if (IsControlVisible(ControlType.Commercial))
                    c_commercial.SelectedFiles = files;
                if (IsControlVisible(ControlType.PlayCounter))
                    c_playCounter.SelectedFiles = files;
                if (IsControlVisible(ControlType.EventTimingCodes))
                    c_eventTimingCodes.SelectedFiles = files;
                if (IsControlVisible(ControlType.SynchronisedLyrics))
                    c_synchronisedLyrics.SelectedFiles = files;
                if (IsControlVisible(ControlType.MediaPlayer))
                    c_mediaPlayer.SelectedFiles = files;
                if (IsControlVisible(ControlType.TermsOfUseFrame))
                    c_termsOfUse.SelectedFiles = files;
                if (IsControlVisible(ControlType.TagExplorer))
                    c_tagExplorer.SelectedFiles = files;
            }
            // Auto start
            if (Program.Settings.MediaPlayerAutoStart && IsControlVisible(ControlType.MediaPlayer)
                && c_filesBrowser.SelectedFilesCount == 1)
                c_quickTagEditorv2_PlayMediaRequest(this, null);
        }
        private void ClearEditorControls()
        {
            if (IsControlVisible(ControlType.AllTextFrames))
                c_allTextFrames.SelectedFiles = null;
            if (IsControlVisible(ControlType.QuickEditorV1))
                c_quickTagEditorv1.SelectedFiles = null;
            if (IsControlVisible(ControlType.ImagesManager))
                c_imagesManager.SelectedFiles = null;
            if (IsControlVisible(ControlType.QuickEditorV2))
                c_quickTagEditorv2.SelectedFiles = null;
            if (IsControlVisible(ControlType.URLLinkFrames))
                c_urlLinkFrames.SelectedFiles = null;
            if (IsControlVisible(ControlType.CommentsEditor))
                c_commentsEditor.SelectedFiles = null;
            if (IsControlVisible(ControlType.Popularimeter))
                c_popularimeter.SelectedFiles = null;
            if (IsControlVisible(ControlType.InvolvedPeopleList))
                c_involvedPeople.SelectedFiles = null;
            if (IsControlVisible(ControlType.UnsychronisedLyrics))
                c_unsychronisedLyrics.SelectedFiles = null;
            if (IsControlVisible(ControlType.UniqueFileIdentifier))
                c_uniqueFileIdentifier.SelectedFiles = null;
            if (IsControlVisible(ControlType.MusicCDIdentifier))
                c_musicCDIdentifier.SelectedFiles = null;
            if (IsControlVisible(ControlType.GeneralEncapsulatedObject))
                c_generalEncapsulatedObject.SelectedFiles = null;
            if (IsControlVisible(ControlType.Commercial))
                c_commercial.SelectedFiles = null;
            if (IsControlVisible(ControlType.PlayCounter))
                c_playCounter.SelectedFiles = null;
            if (IsControlVisible(ControlType.EventTimingCodes))
                c_eventTimingCodes.SelectedFiles = null;
            if (IsControlVisible(ControlType.SynchronisedLyrics))
                c_synchronisedLyrics.SelectedFiles = null;
            if (IsControlVisible(ControlType.MediaPlayer))
                c_mediaPlayer.SelectedFiles = null;
            if (IsControlVisible(ControlType.TermsOfUseFrame))
                c_termsOfUse.SelectedFiles = null;
            if (IsControlVisible(ControlType.TagExplorer))
                c_tagExplorer.SelectedFiles = null;
        }
        private bool IsControlVisible(ControlType type)
        {
            foreach (ControlPage pg in Program.Settings.DefaultLayout.Pages)
            {
                if (pg.Type == type)
                    return pg.Visible;
            }
            return false;
        }

        private void Frm_Main_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
        private void Frm_Main_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (saveListRequired)
            {
                if (MessageBox.Show("You've modified the files list. Are you sure you want to close the program and discard files list ? You still can save the files list as list.\n\nYes= discard files list and exit program.\nNo= ignore closing.", "Exit", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == System.Windows.Forms.DialogResult.No)
                {
                    e.Cancel = true;
                    return;
                }
            }
            SaveSettings();
            // save the database
            System.IO.Directory.CreateDirectory(System.Environment.GetFolderPath(System.Environment.SpecialFolder.MyDocuments) + "\\AITE\\");
            Program.DatabaseManager.Save();
        }
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }
        private void viewToolStripMenuItem_DropDownOpening(object sender, EventArgs e)
        {
            // tabs
            tabsToolStripMenuItem.DropDownItems.Clear();
            foreach (ControlPage pg in Program.Settings.DefaultLayout.Pages)
            {
                ToolStripMenuItem item = new ToolStripMenuItem();
                item.Text = pg.Name;
                item.Checked = pg.Visible;
                item.Enabled = pg.Type != ControlType.FilesBrowser;// we can't hide this control
                tabsToolStripMenuItem.DropDownItems.Add(item);
            }
            // columns
            columnsToolStripMenuItem.DropDownItems.Clear();
            foreach (ColumnItem cl in c_filesBrowser.ColumnsManager.Columns)
            {
                ToolStripMenuItem item = new ToolStripMenuItem();
                item.Text = cl.ColumnName;
                item.Checked = cl.Visible;
                item.Enabled = cl.ColumnID != "name";// we can't hide this columns
                columnsToolStripMenuItem.DropDownItems.Add(item);
            }
            // toolbars
            toolbarsToolStripMenuItem.DropDownItems.Clear();
            foreach (ToolBar bar in Program.Settings.DefaultLayout.ToolBars)
            {
                ToolStripMenuItem item = new ToolStripMenuItem();
                item.Text = bar.Name;
                item.Checked = bar.Visible;
                toolbarsToolStripMenuItem.DropDownItems.Add(item);
            }
        }
        //After selecting a folder
        private void c_foldersBrowser_FolderSelected(object sender, FolderSelectArgs e)
        {
            if (!saveListRequired)
            {
                c_filesBrowser.RefreshFiles(e.BFolder);
                ClearEditorControls();// clear control with no selection
            }
            else
            {
                if (MessageBox.Show("You've modified the files list and selecting a folder from the favorite folders list will clear the list before loading the folder files. Are you sure you want to load selected folder and discard files list ? You still can save the files list as list.\n\nYes= discard files list and load folder.\nNo= ignore folder selection.", "Folder selected", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == System.Windows.Forms.DialogResult.Yes)
                {
                    c_filesBrowser.RefreshFiles(e.BFolder);
                    ClearEditorControls();// clear control with no selection
                    saveListRequired = false;
                }
            }
        }
        private void c_foldersBrowser_FolderAddRequest(object sender, FolderSelectArgs e)
        {
            if (!Program.DatabaseManager.BrowserDatabase.IsFolderExist(e.BFolder.Path))
            {
                BFolder bfolder = new BFolder();
                bfolder.Path = e.BFolder.Path;
                bfolder.RefreshFolders();
                Program.DatabaseManager.BrowserDatabase.Folders.Add(bfolder);
                c_foldersBrowser.RefreshFolders(Program.DatabaseManager.BrowserDatabase);

                // make sure the folders list is visible
                foreach (ControlPage pg in Program.Settings.DefaultLayout.Pages)
                {
                    if (pg.Type == ControlType.FoldersBrowser)
                    {
                        if (!pg.Visible)
                        {
                            // make it visible !
                            pg.Visible = true;
                            AddControlAsTab(pg);
                            CheckForTabsCollapses();
                        }
                        break;
                    }
                }
            }
        }
        private void c_listsBrowser_ListAddRequest(object sender, FileAddArgs e)
        {
            AddListFromFile(e.FilePath);
        }
        private void c_filesBrowser_ItemDoubleClick(object sender, MLV.ManagedListViewItemDoubleClickArgs e)
        {
            switch (Program.Settings.DoubleClickActionIndex)
            {
                case 0: break;// Do nothnig...
                case 1:
                    {
                        if (c_filesBrowser.SelectedFilesCount == 0)
                        {
                            MessageBox.Show("Please select file(s) first.");
                            return;
                        }
                        c_quickTagEditorv2_ClearMediaRequest(this, null);
                        Frm_FullEditV1 frm = new Frm_FullEditV1(c_filesBrowser.GetSelectedFiles(),
                            Program.Settings.ArtistsMemory, Program.Settings.AlbumsMemory);
                        if (frm.ShowDialog(this) == System.Windows.Forms.DialogResult.OK)
                        {
                            c_filesBrowser.UpdateSelectedFiles(); LoadEditorControls(null);
                        }
                        // c_quickTagEditorv2_ReloadMediaRequest(this, null);
                        counter = 2;
                        timer1.Start();
                        break;// Full edit ID3 Tag v1
                    }
                case 2: // Full edit ID3 Tag v2
                    {
                        if (c_filesBrowser.SelectedFilesCount == 0)
                        {
                            MessageBox.Show("Please select file(s) first.");
                            return;
                        }
                        c_quickTagEditorv2_ClearMediaRequest(this, null);
                        Frm_FullID3V2Edit frm = new Frm_FullID3V2Edit(c_filesBrowser.GetSelectedFiles(), Program.Settings.GenreMemory,
                            Program.Settings.ArtistsMemory, Program.Settings.AlbumsMemory);
                        if (frm.ShowDialog(this) == System.Windows.Forms.DialogResult.OK)
                        {
                            c_filesBrowser.UpdateSelectedFiles();
                        }
                        //  c_quickTagEditorv2_ReloadMediaRequest(this, null);   
                        counter = 2;
                        timer1.Start();
                        break;
                    }
                case 3:// Open file
                    try
                    {
                        Process.Start("explorer.exe", @"/select, " + c_filesBrowser.GetSelectedFiles()[0]);
                    }
                    catch { }
                    break;
                case 4: // Play in media player
                    if (IsControlVisible(ControlType.MediaPlayer))
                    {
                        c_mediaPlayer.PlayMedia();
                    }
                    break;
                case 5:// Locate file in disk
                    try
                    {
                        Process.Start(c_filesBrowser.GetSelectedFiles()[0]);
                    }
                    catch { }
                    break;
            }
        }
        private void c_listsBrowser_ListSelect(object sender, ListSelectArgs e)
        {
            if (!saveListRequired)
            {
                c_filesBrowser.RefreshFiles(e.BList);
            }
            else
            {
                if (MessageBox.Show("You've modified the files list and selecting a list from the lists list will clrear the list before loading the folder files. Are you sure you want to load selected list and discard files list ? You still can save the files list as list.\n\nYes= discard files list and load list.\nNo= ignore list selection.", "List selected", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == System.Windows.Forms.DialogResult.Yes)
                {
                    c_filesBrowser.RefreshFiles(e.BList);
                    saveListRequired = false;
                }
            }
        }
        private void c_filesBrowser_ListChanged(object sender, EventArgs e)
        {
            saveListRequired = true;
        }
        private void c_foldersBrowser_Enter(object sender, EventArgs e)
        {
            ActiveWindow = ActiveTab.Folders;
        }
        private void c_filesBrowser_Enter(object sender, EventArgs e)
        {
            ActiveWindow = ActiveTab.Files;
        }
        private void c_quickTagEditor_Enter(object sender, EventArgs e)
        {
            ActiveWindow = ActiveTab.QuickEditorV2;
        }
        private void c_imagesManager_Enter(object sender, EventArgs e)
        {
            ActiveWindow = ActiveTab.ImagesManager;
        }
        private void c_listsBrowser_Enter(object sender, EventArgs e)
        {
            ActiveWindow = ActiveTab.ListsBrowser;
        }
        private void c_allTextFrames_Enter(object sender, EventArgs e)
        {
            ActiveWindow = ActiveTab.AllTextFrames;
        }
        private void c_urlLinkFrames_Enter(object sender, EventArgs e)
        {
            ActiveWindow = ActiveTab.URLLinkFrames;
        }
        private void c_commentsEditor_Enter(object sender, EventArgs e)
        {
            ActiveWindow = ActiveTab.CommentsEditor;
        }
        private void c_popularimeter_Enter(object sender, EventArgs e)
        {
            ActiveWindow = ActiveTab.Popularimeter;
        }
        private void c_involvedPeople_Enter(object sender, EventArgs e)
        {
            ActiveWindow = ActiveTab.InvolvedPeopleList;
        }
        private void C_musicCDIdentifier_Enter(object sender, EventArgs e)
        {
            ActiveWindow = ActiveTab.MusicCDIdentifier;
        }
        private void c_uniqueFileIdentifier_Enter(object sender, EventArgs e)
        {
            ActiveWindow = ActiveTab.UniqueFileIdentifier;
        }
        private void c_unsychronisedLyrics_Enter(object sender, EventArgs e)
        {
            ActiveWindow = ActiveTab.UnsychronisedLyrics;
        }
        private void c_commercial_Enter(object sender, EventArgs e)
        {
            ActiveWindow = ActiveTab.Commercial;
        }
        private void c_playCounter_Enter(object sender, EventArgs e)
        {
            ActiveWindow = ActiveTab.PlayCounter;
        }
        private void c_mediaPlayer_Enter(object sender, EventArgs e)
        {
            ActiveWindow = ActiveTab.MediaPlayer;
        }
        private void loggerControl_Enter(object sender, EventArgs e)
        {
            ActiveWindow = ActiveTab.Log;
        }
        private void c_termsOfUse_Enter(object sender, EventArgs e)
        {
            ActiveWindow = ActiveTab.TermsOfUseFrame;
        }
        private void c_tagExplorer_Enter(object sender, EventArgs e)
        {
            ActiveWindow = ActiveTab.TagExplorer;
        }
        private void c_synchronisedLyrics_Enter(object sender, EventArgs e)
        {
            ActiveWindow = ActiveTab.SynchronisedLyrics;
        }
        private void c_eventTimingCodes_Enter(object sender, EventArgs e)
        {
            ActiveWindow = ActiveTab.EventTimingCodes;
        }
        private void c_generalEncapsulatedObject_Enter(object sender, EventArgs e)
        {
            ActiveWindow = ActiveTab.GeneralEncapsulatedObject;
        }
        private void c_filesBrowser_ProgressFinished(object sender, EventArgs e)
        {
            ProgressBar1.Visible = false;
        }
        private void c_quickTagEditorv1_Enter(object sender, EventArgs e)
        {
            ActiveWindow = ActiveTab.QuickEditorV1;
        }
        private void c_filesBrowser_ProgressStart(object sender, EventArgs e)
        {
            ProgressBar1.Visible = true;
        }
        private void c_filesBrowser_Progress(object sender, ProgressArgs e)
        {
            StatusLabel.Text = e.Status;
            ProgressBar1.Value = e.Complete;
            statusStrip1.Refresh();
        }
        private void frm_OkPressed(object sender, EnterNameFormOkPressedArgs e)
        {
            if (Program.DatabaseManager.BrowserDatabase.IsListExist(e.NameEntered))
            {
                if (MessageBox.Show("Name already exists, overwrite the list ?", "Create list",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.No)
                {
                    e.Cancel = true;
                }
            }
        }
        private void c_filesBrowser_SwitchToNormalMenu(object sender, EventArgs e)
        {
            c_filesBrowser.ContextMenuStrip = contextMenuStrip_files;
        }
        private void c_filesBrowser_SwitchToColumnsMenu(object sender, EventArgs e)
        {
            c_filesBrowser.ContextMenuStrip = contextMenuStrip_columns;
        }
        private void c_filesBrowser_SelectedFilesChanged(object sender, EventArgs e)
        {
            counter = 2;
            timer1.Start();
        }
        // on update required
        private void c_quickTagEditor_UpdateRequired(object sender, EventArgs e)
        {
            c_filesBrowser.UpdateSelectedFiles();
        }
        private void c_imagesManager_UpdateRequired(object sender, EventArgs e)
        {
            LoadEditorControls(null);
        }
        private void c_filesBrowser_UpdateRequired(object sender, EventArgs e)
        {
            LoadEditorControls(null);
        }
        private void c_quickTagEditorv1_UpdateRequired(object sender, EventArgs e)
        {
            c_filesBrowser.UpdateSelectedFiles();
            LoadEditorControls(c_filesBrowser);
        }
        private void c_allTextFrames_UpdateRequired(object sender, EventArgs e)
        {
            c_filesBrowser.UpdateSelectedFiles();
            LoadEditorControls(c_allTextFrames);
        }
        private void c_urlLinkFrames_UpdateRequired(object sender, EventArgs e)
        {
            c_filesBrowser.UpdateSelectedFiles();
            LoadEditorControls(c_urlLinkFrames);
        }
        private void c_commentsEditor_UpdateRequired(object sender, EventArgs e)
        {
            c_filesBrowser.UpdateSelectedFiles();
            LoadEditorControls(c_commentsEditor);
        }
        private void c_popularimeter_UpdateRequired(object sender, EventArgs e)
        {
            c_filesBrowser.UpdateSelectedFiles();
            LoadEditorControls(c_popularimeter);
        }
        private void c_involvedPeople_UpdateRequired(object sender, EventArgs e)
        {
            c_filesBrowser.UpdateSelectedFiles();
            LoadEditorControls(c_involvedPeople);
        }
        private void c_unsychronisedLyrics_UpdateRequired(object sender, EventArgs e)
        {
            c_filesBrowser.UpdateSelectedFiles();
            LoadEditorControls(c_unsychronisedLyrics);
        }
        private void c_uniqueFileIdentifier_UpdateRequired(object sender, EventArgs e)
        {
            LoadEditorControls(c_uniqueFileIdentifier);
        }
        private void C_musicCDIdentifier_UpdateRequired(object sender, EventArgs e)
        {
            LoadEditorControls(c_musicCDIdentifier);
        }
        private void c_generalEncapsulatedObject_UpdateRequired(object sender, EventArgs e)
        {
            LoadEditorControls(c_generalEncapsulatedObject);
        }
        private void c_commercial_UpdateRequired(object sender, EventArgs e)
        {
            LoadEditorControls(c_commercial);
        }
        private void c_playCounter_UpdateRequired(object sender, EventArgs e)
        {
            LoadEditorControls(c_playCounter);
        }
        private void c_eventTimingCodes_UpdateRequired(object sender, EventArgs e)
        {
            LoadEditorControls(c_eventTimingCodes);
        }
        private void c_synchronisedLyrics_UpdateRequired(object sender, EventArgs e)
        {
            LoadEditorControls(c_synchronisedLyrics);
        }
        private void c_termsOfUse_UpdateRequired(object sender, EventArgs e)
        {
            LoadEditorControls(c_termsOfUse);
        }
        // memory updates (memory of artists, albums...etc)
        private void c_quickTagEditor_MemoryUpdated(object sender, EventArgs e)
        {
            c_allTextFrames.AlbumsMemory = c_quickTagEditorv1.AlbumsMemory =
                Program.Settings.AlbumsMemory = c_quickTagEditorv2.AlbumsMemory;
            c_allTextFrames.ArtistsMemory = c_quickTagEditorv1.ArtistsMemory =
                Program.Settings.ArtistsMemory = c_quickTagEditorv2.ArtistsMemory;
            c_allTextFrames.GenreMemory = Program.Settings.GenreMemory = c_quickTagEditorv2.GenreMemory;
        }
        private void c_quickTagEditorv1_MemoryUpdated(object sender, EventArgs e)
        {
            c_allTextFrames.AlbumsMemory = c_quickTagEditorv2.AlbumsMemory = Program.Settings.AlbumsMemory = c_quickTagEditorv1.AlbumsMemory;
            c_allTextFrames.ArtistsMemory = c_quickTagEditorv2.ArtistsMemory = Program.Settings.ArtistsMemory = c_quickTagEditorv1.ArtistsMemory;
        }
        private void c_allTextFrames_MemoryUpdated(object sender, EventArgs e)
        {
            c_quickTagEditorv1.AlbumsMemory =
                       Program.Settings.AlbumsMemory = c_quickTagEditorv2.AlbumsMemory = c_allTextFrames.AlbumsMemory;
            c_quickTagEditorv1.ArtistsMemory =
                Program.Settings.ArtistsMemory = c_quickTagEditorv2.ArtistsMemory = c_allTextFrames.ArtistsMemory;
            Program.Settings.GenreMemory = c_quickTagEditorv2.GenreMemory = c_allTextFrames.GenreMemory;
        }
        // media stuff
        private void c_filesBrowser_UpdateFinished(object sender, EventArgs e)
        {
            if (ReloadMediaAfterUpdate)
            {
                c_mediaPlayer.ReloadMedia();
                c_eventTimingCodes.ReloadMedia();
                c_synchronisedLyrics.ReloadMedia();
                ReloadMediaAfterUpdate = false;
            }
        }
        private void c_quickTagEditorv2_ReloadMediaRequest(object sender, EventArgs e)
        {
            ReloadMediaAfterUpdate = true;
        }
        private void c_quickTagEditorv2_ClearMediaRequest(object sender, EventArgs e)
        {
            // only these controls have media
            c_quickTagEditorv2_StopMediaRequest(this, null);// stop
            c_mediaPlayer.ClearMedia();
            c_eventTimingCodes.ClearMedia();
            c_synchronisedLyrics.ClearMedia();
            // make sure the file is accessable
            if (c_filesBrowser.SelectedFilesCount == 1)
            {
                string file = c_filesBrowser.GetSelectedFiles()[0];
                bool ok = false;
                while (!ok)
                {
                    try
                    {
                        Stream str = new FileStream(file, FileMode.Open, FileAccess.Read);
                        str.Close();
                        str.Dispose();
                        ok = true;
                    }
                    catch { }
                }
            }
        }
        private void c_quickTagEditorv2_PlayMediaRequest(object sender, EventArgs e)
        {
            if (IsControlVisible(ControlType.EventTimingCodes))
                c_eventTimingCodes.PlayMedia();
            if (IsControlVisible(ControlType.MediaPlayer))
                c_mediaPlayer.PlayMedia();
            if (IsControlVisible(ControlType.SynchronisedLyrics))
                c_synchronisedLyrics.PlayMedia();
        }
        private void c_quickTagEditorv2_StopMediaRequest(object sender, EventArgs e)
        {
            c_eventTimingCodes.StopMedia();
            c_mediaPlayer.StopMedia();
            c_synchronisedLyrics.StopMedia();
        }
        private void tabsToolStripMenuItem_DropDownItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            ((ToolStripMenuItem)e.ClickedItem).Checked = !((ToolStripMenuItem)e.ClickedItem).Checked;
            // we need to do this first
            c_filesBrowser.SaveColumns();
            Program.Settings.ColumnsManager = c_filesBrowser.ColumnsManager;

            if (((ToolStripMenuItem)e.ClickedItem).Checked)
            {
                // search for the tab
                foreach (ControlPage pg in Program.Settings.DefaultLayout.Pages)
                {
                    if (pg.Name == e.ClickedItem.Text)
                    {
                        pg.Visible = true;
                        // add it !
                        AddControlAsTab(pg);
                        CheckForTabsCollapses();

                        break;
                    }
                }
            }
            else
            {
                foreach (ControlPage pg in Program.Settings.DefaultLayout.Pages)
                {
                    if (pg.Name == e.ClickedItem.Text)
                    {
                        pg.Visible = false;
                        switch (pg.Location)
                        {
                            case ControlLocation.DownLeft:
                                foreach (MTCTabPage page in managedTabControl_downLeft.TabPages)
                                {
                                    if (page.Text == pg.Name)
                                    {
                                        managedTabControl_downLeft.TabPages.Remove(page);
                                        break;
                                    }
                                }
                                break;
                            case ControlLocation.DownMiddle:
                                foreach (MTCTabPage page in managedTabControl_downMiddle.TabPages)
                                {
                                    if (page.Text == pg.Name)
                                    {
                                        managedTabControl_downMiddle.TabPages.Remove(page);
                                        break;
                                    }
                                }
                                break;
                            case ControlLocation.DownRight:
                                foreach (MTCTabPage page in managedTabControl_downRight.TabPages)
                                {
                                    if (page.Text == pg.Name)
                                    {
                                        managedTabControl_downRight.TabPages.Remove(page);
                                        break;
                                    }
                                }
                                break;
                            case ControlLocation.TopLeft:
                                foreach (MTCTabPage page in managedTabControl_topLeft.TabPages)
                                {
                                    if (page.Text == pg.Name)
                                    {
                                        managedTabControl_topLeft.TabPages.Remove(page);
                                        break;
                                    }
                                }
                                break;
                            case ControlLocation.TopMiddle:
                                foreach (MTCTabPage page in managedTabControl_topMiddle.TabPages)
                                {
                                    if (page.Text == pg.Name)
                                    {
                                        managedTabControl_topMiddle.TabPages.Remove(page);
                                        break;
                                    }
                                }
                                break;
                            case ControlLocation.TopRight:
                                foreach (MTCTabPage page in managedTabControl_topRight.TabPages)
                                {
                                    if (page.Text == pg.Name)
                                    {
                                        managedTabControl_topRight.TabPages.Remove(page);
                                        break;
                                    }
                                }
                                break;
                        }
                    }
                }
            }
            CheckForTabsCollapses();
            LoadEditorControls(null);
        }
        private void saveLayoutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog save = new SaveFileDialog();
            save.Title = "Save layout present";
            save.Filter = "AHD ID3 Tag Editor layout file (*.lo)|*.lo";
            if (save.ShowDialog(this) == System.Windows.Forms.DialogResult.OK)
            {
                SaveLayout(save.FileName, Program.Settings.DefaultLayout);
            }
        }
        private void loadLayoutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();
            open.Title = "Open layout present";
            open.Filter = "AHD ID3 Tag Editor layout file (*.lo)|*.lo";
            if (open.ShowDialog(this) == System.Windows.Forms.DialogResult.OK)
            {
                LoadLayout(open.FileName);
            }
        }
        private void contextMenuStrip_folders_Opening(object sender, CancelEventArgs e)
        {
            deleteToolStripMenuItem1.Enabled = c_foldersBrowser.CanDeleteSelected;
        }
        // columns
        private void contextMenuStrip_columns_Opening(object sender, CancelEventArgs e)
        {
            contextMenuStrip_columns.Items.Clear();
            foreach (ColumnItem cl in c_filesBrowser.ColumnsManager.Columns)
            {
                ToolStripMenuItem item = new ToolStripMenuItem();
                item.Text = cl.ColumnName;
                item.Checked = cl.Visible;
                item.Enabled = cl.ColumnID != "name";// we can't hide this columns
                contextMenuStrip_columns.Items.Add(item);
            }
        }
        private void contextMenuStrip_columns_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            ShowHideColumn(e.ClickedItem.Text);
        }
        private void columnsToolStripMenuItem_DropDownItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            ShowHideColumn(e.ClickedItem.Text);
        }
        // toolbars
        private void toolbarsToolStripMenuItem_DropDownItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            ((ToolStripMenuItem)e.ClickedItem).Checked = !((ToolStripMenuItem)e.ClickedItem).Checked;
            foreach (ToolBar bar in Program.Settings.DefaultLayout.ToolBars)
            {
                if (bar.Name == e.ClickedItem.Text)
                {
                    bar.Visible = ((ToolStripMenuItem)e.ClickedItem).Checked;
                    switch (bar.Type)
                    {
                        case ToolBarType.Main: toolStrip_main.Visible = bar.Visible; break;
                    }
                    break;
                }
            }
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            if (counter > 0)
                counter--;
            else
            {
                LoadEditorControls(null);
                timer1.Stop();
            }
        }
        private void selectAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            c_filesBrowser.SelectAll();
        }
        private void settingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Frm_Settings frm = new Frm_Settings();
            frm.ShowDialog(this);
            ApplyTabPagesStyle();
            c_mediaPlayer.AutoStart = Program.Settings.MediaPlayerAutoStart;
        }
        private void deleteToolStripMenuItem_EnabledChanged(object sender, EventArgs e)
        {
            toolStripButton5.Enabled = deleteToolStripMenuItem.Enabled;
        }
        private void logWindowToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (frm_log == null)
                frm_log = new Frm_Log();
            if (!frm_log.Visible)
            {
                frm_log = new Frm_Log();
                frm_log.Show();
            }
        }
        private void DebugLogger_RequestLogWindow(object sender, EventArgs e)
        {
            logWindowToolStripMenuItem_Click(this, e);
        }
        private void addFromFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();
            open.Filter = "M3U list (*.m3u)|*.m3u";
            open.Title = "Add lisr from file";
            if (open.ShowDialog(this) == System.Windows.Forms.DialogResult.OK)
            {
                AddListFromFile(open.FileName);
            }
        }
        private void aboutAHDID3TagEditorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Frm_About frm = new Frm_About();
            frm.ShowDialog(this);
        }
        private void viewhelpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Help.ShowHelp(this, ".\\Help.chm", HelpNavigator.TableOfContents);
        }
        private void refreshToolStripMenuItem_Click(object sender, EventArgs e)
        {
            c_foldersBrowser.RefreshSelectedFolder();
        }

        /*Tabs drag and drop*/
        private void tabControl_TopLeft_MouseDown(object sender, MouseEventArgs e)
        {
            downPoint = e.Location;
            canDragDrop = true;
        }
        private void tabControl_TopLeft_MouseUp(object sender, MouseEventArgs e)
        {
            canDragDrop = false;
        }
        private void tabControl_TopLeft_MouseMove(object sender, MouseEventArgs e)
        {
            if (canDragDrop & ((e.X - downPoint.X) > 10 | (e.Y - downPoint.Y) > 10))
            {
                ExpandTabs();
                CheckDragAndDrop();
                DoDragDrop(managedTabControl_topLeft.TabPages[managedTabControl_topLeft.SelectedTabPageIndex],
                    DragDropEffects.Move);
                CheckForTabsCollapses();
            }
        }
        private void tabControl_DownLeft_MouseMove(object sender, MouseEventArgs e)
        {
            if (canDragDrop & ((e.X - downPoint.X) > 10 | (e.Y - downPoint.Y) > 10))
            {
                ExpandTabs();
                CheckDragAndDrop();
                DoDragDrop(managedTabControl_downLeft.TabPages[managedTabControl_downLeft.SelectedTabPageIndex], DragDropEffects.Move);
                CheckForTabsCollapses();
            }
        }
        private void tabControl_TopMiddle_MouseMove(object sender, MouseEventArgs e)
        {
            if (canDragDrop & ((e.X - downPoint.X) > 10 | (e.Y - downPoint.Y) > 10))
            {
                ExpandTabs();
                CheckDragAndDrop();
                DoDragDrop(managedTabControl_topMiddle.TabPages[managedTabControl_topMiddle.SelectedTabPageIndex], DragDropEffects.Move);
                CheckForTabsCollapses();
            }
        }
        private void tabControl_DownMiddle_MouseMove(object sender, MouseEventArgs e)
        {
            if (canDragDrop & ((e.X - downPoint.X) > 10 | (e.Y - downPoint.Y) > 10))
            {
                ExpandTabs();
                CheckDragAndDrop();
                DoDragDrop(managedTabControl_downMiddle.TabPages[managedTabControl_downMiddle.SelectedTabPageIndex], DragDropEffects.Move);
                CheckForTabsCollapses();
            }
        }
        private void tabControl_TopRight_MouseMove(object sender, MouseEventArgs e)
        {
            if (canDragDrop & ((e.X - downPoint.X) > 10 | (e.Y - downPoint.Y) > 10))
            {
                ExpandTabs();
                CheckDragAndDrop();
                DoDragDrop(managedTabControl_topRight.TabPages[managedTabControl_topRight.SelectedTabPageIndex], DragDropEffects.Move);
                CheckForTabsCollapses();
            }
        }
        private void tabControl_DownRight_MouseMove(object sender, MouseEventArgs e)
        {
            if (canDragDrop & ((e.X - downPoint.X) > 10 | (e.Y - downPoint.Y) > 10))
            {
                ExpandTabs();
                CheckDragAndDrop();
                DoDragDrop(managedTabControl_downRight.TabPages[managedTabControl_downRight.SelectedTabPageIndex], DragDropEffects.Move);
                CheckForTabsCollapses();
            }
        }
        private void tabControl_TopLeft_DragDrop(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(typeof(MTCTabPage)))
            {
                ((TabPage)e.Data.GetData(typeof(TabPage))).Parent = managedTabControl_topLeft;
                SaveTabParent(((TabPage)e.Data.GetData(typeof(TabPage))).Text, ControlLocation.TopLeft);
                canDragDrop = false;
            }
        }
        private void tabControl_DownLeft_DragDrop(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(typeof(TabPage)))
            {
                ((TabPage)e.Data.GetData(typeof(TabPage))).Parent = managedTabControl_downLeft;
                SaveTabParent(((TabPage)e.Data.GetData(typeof(TabPage))).Text, ControlLocation.DownLeft);
                canDragDrop = false;
            }
        }
        private void tabControl_TopMiddle_DragDrop(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(typeof(TabPage)))
            {
                ((TabPage)e.Data.GetData(typeof(TabPage))).Parent = managedTabControl_topMiddle;
                SaveTabParent(((TabPage)e.Data.GetData(typeof(TabPage))).Text, ControlLocation.TopMiddle);
                canDragDrop = false;
            }
        }
        private void tabControl_DownMiddle_DragDrop(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(typeof(TabPage)))
            {
                ((TabPage)e.Data.GetData(typeof(TabPage))).Parent = managedTabControl_downMiddle;
                SaveTabParent(((TabPage)e.Data.GetData(typeof(TabPage))).Text, ControlLocation.DownMiddle);
                canDragDrop = false;
            }
        }
        private void tabControl_TopRight_DragDrop(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(typeof(TabPage)))
            {
                ((TabPage)e.Data.GetData(typeof(TabPage))).Parent = managedTabControl_topRight;
                SaveTabParent(((TabPage)e.Data.GetData(typeof(TabPage))).Text, ControlLocation.TopRight);
                canDragDrop = false;
            }
        }
        private void tabControl_DownRight_DragDrop(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(typeof(TabPage)))
            {
                ((TabPage)e.Data.GetData(typeof(TabPage))).Parent = managedTabControl_downRight;
                SaveTabParent(((TabPage)e.Data.GetData(typeof(TabPage))).Text, ControlLocation.DownRight);
                canDragDrop = false;
            }
        }

        // After tab reorder
        private void managedTabControl_topLeft_AfterTabPageReorder(object sender, EventArgs e)
        {
            // Remove all tabs of this location
            List<ControlPage> ly = new List<ControlPage>();
            for (int i = 0; i < Program.Settings.DefaultLayout.Pages.Count; i++)
            {
                if (Program.Settings.DefaultLayout.Pages[i].Location == ControlLocation.TopLeft && Program.Settings.DefaultLayout.Pages[i].Visible)
                {
                    ly.Add(Program.Settings.DefaultLayout.Pages[i]);
                    Program.Settings.DefaultLayout.Pages.RemoveAt(i);
                    i--;
                }
            }
            // Resort
            foreach (MTCTabPage page in managedTabControl_topLeft.TabPages)
            {
                foreach (ControlPage lyitem in ly)
                {
                    if (lyitem.Name == page.Text)
                    {
                        Program.Settings.DefaultLayout.Pages.Add(lyitem);
                        break;
                    }
                }
            }
        }
        private void managedTabControl_downLeft_AfterTabPageReorder(object sender, EventArgs e)
        {
            // Remove all tabs of this location
            List<ControlPage> ly = new List<ControlPage>();
            for (int i = 0; i < Program.Settings.DefaultLayout.Pages.Count; i++)
            {
                if (Program.Settings.DefaultLayout.Pages[i].Location == ControlLocation.DownLeft && Program.Settings.DefaultLayout.Pages[i].Visible)
                {
                    ly.Add(Program.Settings.DefaultLayout.Pages[i]);
                    Program.Settings.DefaultLayout.Pages.RemoveAt(i);
                    i--;
                }
            }
            // Resort
            foreach (MTCTabPage page in managedTabControl_downLeft.TabPages)
            {
                foreach (ControlPage lyitem in ly)
                {
                    if (lyitem.Name == page.Text)
                    {
                        Program.Settings.DefaultLayout.Pages.Add(lyitem);
                        break;
                    }
                }
            }
        }
        private void managedTabControl_topMiddle_AfterTabPageReorder(object sender, EventArgs e)
        {
            // Remove all tabs of this location
            List<ControlPage> ly = new List<ControlPage>();
            for (int i = 0; i < Program.Settings.DefaultLayout.Pages.Count; i++)
            {
                if (Program.Settings.DefaultLayout.Pages[i].Location == ControlLocation.TopMiddle && Program.Settings.DefaultLayout.Pages[i].Visible)
                {
                    ly.Add(Program.Settings.DefaultLayout.Pages[i]);
                    Program.Settings.DefaultLayout.Pages.RemoveAt(i);
                    i--;
                }
            }
            // Resort
            foreach (MTCTabPage page in managedTabControl_topMiddle.TabPages)
            {
                foreach (ControlPage lyitem in ly)
                {
                    if (lyitem.Name == page.Text)
                    {
                        Program.Settings.DefaultLayout.Pages.Add(lyitem);
                        break;
                    }
                }
            }
        }
        private void managedTabControl_downMiddle_AfterTabPageReorder(object sender, EventArgs e)
        {
            // Remove all tabs of this location
            List<ControlPage> ly = new List<ControlPage>();
            for (int i = 0; i < Program.Settings.DefaultLayout.Pages.Count; i++)
            {
                if (Program.Settings.DefaultLayout.Pages[i].Location == ControlLocation.DownMiddle && Program.Settings.DefaultLayout.Pages[i].Visible)
                {
                    ly.Add(Program.Settings.DefaultLayout.Pages[i]);
                    Program.Settings.DefaultLayout.Pages.RemoveAt(i);
                    i--;
                }
            }
            // Resort
            foreach (MTCTabPage page in managedTabControl_downMiddle.TabPages)
            {
                foreach (ControlPage lyitem in ly)
                {
                    if (lyitem.Name == page.Text)
                    {
                        Program.Settings.DefaultLayout.Pages.Add(lyitem);
                        break;
                    }
                }
            }
        }
        private void managedTabControl_topRight_AfterTabPageReorder(object sender, EventArgs e)
        {
            // Remove all tabs of this location
            List<ControlPage> ly = new List<ControlPage>();
            for (int i = 0; i < Program.Settings.DefaultLayout.Pages.Count; i++)
            {
                if (Program.Settings.DefaultLayout.Pages[i].Location == ControlLocation.TopRight && Program.Settings.DefaultLayout.Pages[i].Visible)
                {
                    ly.Add(Program.Settings.DefaultLayout.Pages[i]);
                    Program.Settings.DefaultLayout.Pages.RemoveAt(i);
                    i--;
                }
            }
            // Resort
            foreach (MTCTabPage page in managedTabControl_topRight.TabPages)
            {
                foreach (ControlPage lyitem in ly)
                {
                    if (lyitem.Name == page.Text)
                    {
                        Program.Settings.DefaultLayout.Pages.Add(lyitem);
                        break;
                    }
                }
            }
        }
        private void managedTabControl_downRight_AfterTabPageReorder(object sender, EventArgs e)
        {
            // Remove all tabs of this location
            List<ControlPage> ly = new List<ControlPage>();
            for (int i = 0; i < Program.Settings.DefaultLayout.Pages.Count; i++)
            {
                if (Program.Settings.DefaultLayout.Pages[i].Location == ControlLocation.DownRight && Program.Settings.DefaultLayout.Pages[i].Visible)
                {
                    ly.Add(Program.Settings.DefaultLayout.Pages[i]);
                    Program.Settings.DefaultLayout.Pages.RemoveAt(i);
                    i--;
                }
            }
            // Resort
            foreach (MTCTabPage page in managedTabControl_downRight.TabPages)
            {
                foreach (ControlPage lyitem in ly)
                {
                    if (lyitem.Name == page.Text)
                    {
                        Program.Settings.DefaultLayout.Pages.Add(lyitem);
                        break;
                    }
                }
            }
        }
        // After tab close
        private void managedTabControl_topLeft_TabPageClose(object sender, MTCTabPageCloseArgs e)
        {
            // we need to do this first
            c_filesBrowser.SaveColumns();
            Program.Settings.ColumnsManager = c_filesBrowser.ColumnsManager;

            foreach (ControlPage pg in Program.Settings.DefaultLayout.Pages)
            {
                if (pg.Name == managedTabControl_topLeft.TabPages[e.TabPageIndex].Text)
                {
                    pg.Visible = false;
                    foreach (ToolStripMenuItem item in tabsToolStripMenuItem.DropDownItems)
                    {
                        if (item.Text == pg.Name) { item.Checked = false; }
                    }
                    break;
                }
            }
            LoadEditorControls(null);
        }
        private void managedTabControl_downLeft_TabPageClose(object sender, MTCTabPageCloseArgs e)
        {
            // we need to do this first
            c_filesBrowser.SaveColumns();
            Program.Settings.ColumnsManager = c_filesBrowser.ColumnsManager;

            foreach (ControlPage pg in Program.Settings.DefaultLayout.Pages)
            {
                if (pg.Name == managedTabControl_downLeft.TabPages[e.TabPageIndex].Text)
                {
                    pg.Visible = false;
                    foreach (ToolStripMenuItem item in tabsToolStripMenuItem.DropDownItems)
                    {
                        if (item.Text == pg.Name) { item.Checked = false; }
                    }
                    break;
                }
            }
            LoadEditorControls(null);
        }
        private void managedTabControl_topMiddle_TabPageClose(object sender, MTCTabPageCloseArgs e)
        {
            // we need to do this first
            c_filesBrowser.SaveColumns();
            Program.Settings.ColumnsManager = c_filesBrowser.ColumnsManager;

            foreach (ControlPage pg in Program.Settings.DefaultLayout.Pages)
            {
                if (pg.Name == managedTabControl_topMiddle.TabPages[e.TabPageIndex].Text)
                {
                    pg.Visible = false;
                    foreach (ToolStripMenuItem item in tabsToolStripMenuItem.DropDownItems)
                    {
                        if (item.Text == pg.Name) { item.Checked = false; }
                    }
                    break;
                }
            }
            LoadEditorControls(null);
        }
        private void managedTabControl_downMiddle_TabPageClose(object sender, MTCTabPageCloseArgs e)
        {
            // we need to do this first
            c_filesBrowser.SaveColumns();
            Program.Settings.ColumnsManager = c_filesBrowser.ColumnsManager;

            foreach (ControlPage pg in Program.Settings.DefaultLayout.Pages)
            {
                if (pg.Name == managedTabControl_downMiddle.TabPages[e.TabPageIndex].Text)
                {
                    pg.Visible = false;
                    foreach (ToolStripMenuItem item in tabsToolStripMenuItem.DropDownItems)
                    {
                        if (item.Text == pg.Name) { item.Checked = false; }
                    }
                    break;
                }
            }
            LoadEditorControls(null);
        }
        private void managedTabControl_topRight_TabPageClose(object sender, MTCTabPageCloseArgs e)
        {
            // we need to do this first
            c_filesBrowser.SaveColumns();
            Program.Settings.ColumnsManager = c_filesBrowser.ColumnsManager;

            foreach (ControlPage pg in Program.Settings.DefaultLayout.Pages)
            {
                if (pg.Name == managedTabControl_topRight.TabPages[e.TabPageIndex].Text)
                {
                    pg.Visible = false;
                    foreach (ToolStripMenuItem item in tabsToolStripMenuItem.DropDownItems)
                    {
                        if (item.Text == pg.Name) { item.Checked = false; }
                    }
                    break;
                }
            }
            LoadEditorControls(null);
        }
        private void managedTabControl_downRight_TabPageClose(object sender, MTCTabPageCloseArgs e)
        {
            // we need to do this first
            c_filesBrowser.SaveColumns();
            Program.Settings.ColumnsManager = c_filesBrowser.ColumnsManager;

            foreach (ControlPage pg in Program.Settings.DefaultLayout.Pages)
            {
                if (pg.Name == managedTabControl_downRight.TabPages[e.TabPageIndex].Text)
                {
                    pg.Visible = false;
                    foreach (ToolStripMenuItem item in tabsToolStripMenuItem.DropDownItems)
                    {
                        if (item.Text == pg.Name) { item.Checked = false; }
                    }
                    break;
                }
            }
            LoadEditorControls(null);
        }
        // Tabs drag drop
        private void managedTabControl_topLeft_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(typeof(MTCTabPage)))
                e.Effect = DragDropEffects.Move;
            else
                e.Effect = DragDropEffects.None;
        }
        private void managedTabControl_topLeft_BeforeAutoTabDragAndDrop(object sender, EventArgs e)
        {
            ExpandTabs();
            CheckDragAndDrop();
        }
        private void managedTabControl_topLeft_AfterAutoTabDragAndDrop(object sender, EventArgs e)
        {
            CheckForTabsCollapses();
        }
        private void managedTabControl_topLeft_DragDrop(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(typeof(MTCTabPage)))
            {
                MTCTabPage draggedPage = (MTCTabPage)e.Data.GetData(typeof(MTCTabPage));
                // Get the original tab
                foreach (ControlPage pg in Program.Settings.DefaultLayout.Pages)
                {
                    if (pg.Name == draggedPage.Text)
                    {
                        // Remove it from page control
                        switch (pg.Location)
                        {
                            case ControlLocation.DownLeft: managedTabControl_downLeft.TabPages.Remove(draggedPage); break;
                            case ControlLocation.DownMiddle: managedTabControl_downMiddle.TabPages.Remove(draggedPage); break;
                            case ControlLocation.DownRight: managedTabControl_downRight.TabPages.Remove(draggedPage); break;
                            case ControlLocation.TopLeft: managedTabControl_topLeft.TabPages.Remove(draggedPage); break;
                            case ControlLocation.TopMiddle: managedTabControl_topMiddle.TabPages.Remove(draggedPage); break;
                            case ControlLocation.TopRight: managedTabControl_topRight.TabPages.Remove(draggedPage); break;
                        }
                        break;
                    }
                }
                SaveTabParent(draggedPage.Text, ControlLocation.TopLeft);
            }
        }
        private void managedTabControl_downLeft_DragDrop(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(typeof(MTCTabPage)))
            {
                MTCTabPage draggedPage = (MTCTabPage)e.Data.GetData(typeof(MTCTabPage));
                // Get the original tab
                foreach (ControlPage pg in Program.Settings.DefaultLayout.Pages)
                {
                    if (pg.Name == draggedPage.Text)
                    {
                        // Remove it from page control
                        switch (pg.Location)
                        {
                            case ControlLocation.DownLeft: managedTabControl_downLeft.TabPages.Remove(draggedPage); break;
                            case ControlLocation.DownMiddle: managedTabControl_downMiddle.TabPages.Remove(draggedPage); break;
                            case ControlLocation.DownRight: managedTabControl_downRight.TabPages.Remove(draggedPage); break;
                            case ControlLocation.TopLeft: managedTabControl_topLeft.TabPages.Remove(draggedPage); break;
                            case ControlLocation.TopMiddle: managedTabControl_topMiddle.TabPages.Remove(draggedPage); break;
                            case ControlLocation.TopRight: managedTabControl_topRight.TabPages.Remove(draggedPage); break;
                        }
                        break;
                    }
                }
                SaveTabParent(draggedPage.Text, ControlLocation.DownLeft);
            }
        }
        private void managedTabControl_topMiddle_DragDrop(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(typeof(MTCTabPage)))
            {
                MTCTabPage draggedPage = (MTCTabPage)e.Data.GetData(typeof(MTCTabPage));
                // Get the original tab
                foreach (ControlPage pg in Program.Settings.DefaultLayout.Pages)
                {
                    if (pg.Name == draggedPage.Text)
                    {
                        // Remove it from page control
                        switch (pg.Location)
                        {
                            case ControlLocation.DownLeft: managedTabControl_downLeft.TabPages.Remove(draggedPage); break;
                            case ControlLocation.DownMiddle: managedTabControl_downMiddle.TabPages.Remove(draggedPage); break;
                            case ControlLocation.DownRight: managedTabControl_downRight.TabPages.Remove(draggedPage); break;
                            case ControlLocation.TopLeft: managedTabControl_topLeft.TabPages.Remove(draggedPage); break;
                            case ControlLocation.TopMiddle: managedTabControl_topMiddle.TabPages.Remove(draggedPage); break;
                            case ControlLocation.TopRight: managedTabControl_topRight.TabPages.Remove(draggedPage); break;
                        }
                        break;
                    }
                }
                SaveTabParent(draggedPage.Text, ControlLocation.TopMiddle);
            }
        }
        private void managedTabControl_downMiddle_DragDrop(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(typeof(MTCTabPage)))
            {
                MTCTabPage draggedPage = (MTCTabPage)e.Data.GetData(typeof(MTCTabPage));
                // Get the original tab
                foreach (ControlPage pg in Program.Settings.DefaultLayout.Pages)
                {
                    if (pg.Name == draggedPage.Text)
                    {
                        // Remove it from page control
                        switch (pg.Location)
                        {
                            case ControlLocation.DownLeft: managedTabControl_downLeft.TabPages.Remove(draggedPage); break;
                            case ControlLocation.DownMiddle: managedTabControl_downMiddle.TabPages.Remove(draggedPage); break;
                            case ControlLocation.DownRight: managedTabControl_downRight.TabPages.Remove(draggedPage); break;
                            case ControlLocation.TopLeft: managedTabControl_topLeft.TabPages.Remove(draggedPage); break;
                            case ControlLocation.TopMiddle: managedTabControl_topMiddle.TabPages.Remove(draggedPage); break;
                            case ControlLocation.TopRight: managedTabControl_topRight.TabPages.Remove(draggedPage); break;
                        }
                        break;
                    }
                }
                SaveTabParent(draggedPage.Text, ControlLocation.DownMiddle);
            }
        }
        private void managedTabControl_topRight_DragDrop(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(typeof(MTCTabPage)))
            {
                MTCTabPage draggedPage = (MTCTabPage)e.Data.GetData(typeof(MTCTabPage));
                // Get the original tab
                foreach (ControlPage pg in Program.Settings.DefaultLayout.Pages)
                {
                    if (pg.Name == draggedPage.Text)
                    {
                        // Remove it from page control
                        switch (pg.Location)
                        {
                            case ControlLocation.DownLeft: managedTabControl_downLeft.TabPages.Remove(draggedPage); break;
                            case ControlLocation.DownMiddle: managedTabControl_downMiddle.TabPages.Remove(draggedPage); break;
                            case ControlLocation.DownRight: managedTabControl_downRight.TabPages.Remove(draggedPage); break;
                            case ControlLocation.TopLeft: managedTabControl_topLeft.TabPages.Remove(draggedPage); break;
                            case ControlLocation.TopMiddle: managedTabControl_topMiddle.TabPages.Remove(draggedPage); break;
                            case ControlLocation.TopRight: managedTabControl_topRight.TabPages.Remove(draggedPage); break;
                        }
                        break;
                    }
                }
                SaveTabParent(draggedPage.Text, ControlLocation.TopRight);
            }
        }
        private void managedTabControl_downRight_DragDrop(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(typeof(MTCTabPage)))
            {
                MTCTabPage draggedPage = (MTCTabPage)e.Data.GetData(typeof(MTCTabPage));
                // Get the original tab
                foreach (ControlPage pg in Program.Settings.DefaultLayout.Pages)
                {
                    if (pg.Name == draggedPage.Text)
                    {
                        // Remove it from page control
                        switch (pg.Location)
                        {
                            case ControlLocation.DownLeft: managedTabControl_downLeft.TabPages.Remove(draggedPage); break;
                            case ControlLocation.DownMiddle: managedTabControl_downMiddle.TabPages.Remove(draggedPage); break;
                            case ControlLocation.DownRight: managedTabControl_downRight.TabPages.Remove(draggedPage); break;
                            case ControlLocation.TopLeft: managedTabControl_topLeft.TabPages.Remove(draggedPage); break;
                            case ControlLocation.TopMiddle: managedTabControl_topMiddle.TabPages.Remove(draggedPage); break;
                            case ControlLocation.TopRight: managedTabControl_topRight.TabPages.Remove(draggedPage); break;
                        }
                        break;
                    }
                }
                SaveTabParent(draggedPage.Text, ControlLocation.DownRight);
            }
        }
        private void managedTabControl_topLeft_TabPagesCleared(object sender, EventArgs e)
        {
            CheckForTabsCollapses();
        }

        private void extractTagContentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (c_filesBrowser.SelectedFilesCount == 0)
            {
                MessageBox.Show("Please select file(s) first.");
                return;
            }
            c_quickTagEditorv2_ClearMediaRequest(this, null);
            Frm_ExtractTagContent frm = new Frm_ExtractTagContent(c_filesBrowser.GetSelectedFiles());
            if (frm.ShowDialog(this) == System.Windows.Forms.DialogResult.OK)
            {
                //
            }
            c_quickTagEditorv2_ReloadMediaRequest(this, null);
        }

        private void extractTagFolderinFoldersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folder = new FolderBrowserDialog();
            folder.Description = "Select the folder which contain the mp3 files";
            if (c_foldersBrowser.SelectedFolder != null)
                folder.SelectedPath = c_foldersBrowser.SelectedFolder.Path;
            if (folder.ShowDialog(this) == System.Windows.Forms.DialogResult.OK)
            {
                c_quickTagEditorv2_ClearMediaRequest(this, null);
                Frm_ExtractTagContent frm = new Frm_ExtractTagContent(folder.SelectedPath);
                if (frm.ShowDialog(this) == System.Windows.Forms.DialogResult.OK)
                {
                    //
                }
                c_quickTagEditorv2_ReloadMediaRequest(this, null);
            }
        }
        private void websiteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try { Process.Start("https://github.com/alaahadid/AHD-ID3-Tag-Editor"); }
            catch { }
        }
        private void wikiOnlineHelpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try { Process.Start("https://github.com/alaahadid/AHD-ID3-Tag-Editor/wiki"); }
            catch { }
        }
    }
    public enum ActiveTab
    {
        Folders, Files, QuickEditorV1, QuickEditorV2, ImagesManager, ListsBrowser,
        AllTextFrames, URLLinkFrames, CommentsEditor, Popularimeter, InvolvedPeopleList,
        UnsychronisedLyrics, UniqueFileIdentifier, MusicCDIdentifier, GeneralEncapsulatedObject,
        Commercial, PlayCounter, EventTimingCodes, SynchronisedLyrics, MediaPlayer, Log,
        TermsOfUseFrame, TagExplorer
    }
}
