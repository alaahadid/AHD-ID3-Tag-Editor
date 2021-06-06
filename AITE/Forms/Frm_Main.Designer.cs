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
namespace AHD.ID3.Editor
{
    partial class Frm_Main
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frm_Main));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.folderToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.filesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.filesfolderScanToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
            this.createListToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addListFromFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator8 = new System.Windows.Forms.ToolStripSeparator();
            this.openfilequickEditToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openFilequickEditId3v1ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openListToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator16 = new System.Windows.Forms.ToolStripSeparator();
            this.saveListToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator10 = new System.Windows.Forms.ToolStripSeparator();
            this.fullEditId3v1ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fullEditId3v2ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator20 = new System.Windows.Forms.ToolStripSeparator();
            this.clearId3v1ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.clearId3v2ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator22 = new System.Windows.Forms.ToolStripSeparator();
            this.selectAllToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.viewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.columnsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tabsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolbarsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.resetLayoutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveLayoutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loadLayoutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator18 = new System.Windows.Forms.ToolStripSeparator();
            this.logWindowToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.renameFileUsingTagToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tagExplorerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.extractTagContentToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.extractTagFolderinFoldersToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator25 = new System.Windows.Forms.ToolStripSeparator();
            this.settingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.viewhelpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.wikiOnlineHelpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.websiteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator28 = new System.Windows.Forms.ToolStripSeparator();
            this.aboutAHDID3TagEditorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.StatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.ProgressBar1 = new System.Windows.Forms.ToolStripProgressBar();
            this.toolStripContainer1 = new System.Windows.Forms.ToolStripContainer();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.splitContainer3 = new System.Windows.Forms.SplitContainer();
            this.managedTabControl_topLeft = new MTC.ManagedTabControl();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.managedTabControl_downLeft = new MTC.ManagedTabControl();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.splitContainer4 = new System.Windows.Forms.SplitContainer();
            this.managedTabControl_topMiddle = new MTC.ManagedTabControl();
            this.managedTabControl_downMiddle = new MTC.ManagedTabControl();
            this.splitContainer5 = new System.Windows.Forms.SplitContainer();
            this.managedTabControl_topRight = new MTC.ManagedTabControl();
            this.managedTabControl_downRight = new MTC.ManagedTabControl();
            this.toolStrip_main = new System.Windows.Forms.ToolStrip();
            this.toolStripButton2 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton3 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton4 = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator7 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButton8 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton12 = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator17 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButton11 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton7 = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator12 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButton6 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton9 = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButton5 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton17 = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator26 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButton13 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton10 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton14 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton15 = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator24 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButton16 = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.contextMenuStrip_folders = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.addFolderToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator9 = new System.Windows.Forms.ToolStripSeparator();
            this.refreshToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator14 = new System.Windows.Forms.ToolStripSeparator();
            this.deleteToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator27 = new System.Windows.Forms.ToolStripSeparator();
            this.extractTagContentToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuStrip_lists = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.addFromFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator19 = new System.Windows.Forms.ToolStripSeparator();
            this.createListToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.exportAsFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator11 = new System.Windows.Forms.ToolStripSeparator();
            this.deleteToolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuStrip_files = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.addFilesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addFilesfolderScanToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator13 = new System.Windows.Forms.ToolStripSeparator();
            this.deleteToolStripMenuItem3 = new System.Windows.Forms.ToolStripMenuItem();
            this.renameUsingTagToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator15 = new System.Windows.Forms.ToolStripSeparator();
            this.fullEditId3v1ToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.fullEditId3v2ToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator21 = new System.Windows.Forms.ToolStripSeparator();
            this.clearId3v1ToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.clearId3v2ToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator23 = new System.Windows.Forms.ToolStripSeparator();
            this.tagExplorerToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuStrip_columns = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.menuStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.toolStripContainer1.ContentPanel.SuspendLayout();
            this.toolStripContainer1.TopToolStripPanel.SuspendLayout();
            this.toolStripContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).BeginInit();
            this.splitContainer3.Panel1.SuspendLayout();
            this.splitContainer3.Panel2.SuspendLayout();
            this.splitContainer3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer4)).BeginInit();
            this.splitContainer4.Panel1.SuspendLayout();
            this.splitContainer4.Panel2.SuspendLayout();
            this.splitContainer4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer5)).BeginInit();
            this.splitContainer5.Panel1.SuspendLayout();
            this.splitContainer5.Panel2.SuspendLayout();
            this.splitContainer5.SuspendLayout();
            this.toolStrip_main.SuspendLayout();
            this.contextMenuStrip_folders.SuspendLayout();
            this.contextMenuStrip_lists.SuspendLayout();
            this.contextMenuStrip_files.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.GripMargin = new System.Windows.Forms.Padding(2, 2, 0, 2);
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.editToolStripMenuItem,
            this.viewToolStripMenuItem,
            this.toolsToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1162, 33);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addToolStripMenuItem,
            this.toolStripSeparator6,
            this.createListToolStripMenuItem,
            this.addListFromFileToolStripMenuItem,
            this.toolStripSeparator8,
            this.openfilequickEditToolStripMenuItem,
            this.openFilequickEditId3v1ToolStripMenuItem,
            this.openListToolStripMenuItem,
            this.toolStripSeparator16,
            this.saveListToolStripMenuItem,
            this.exportToolStripMenuItem,
            this.toolStripSeparator5,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(54, 29);
            this.fileToolStripMenuItem.Text = "&File";
            // 
            // addToolStripMenuItem
            // 
            this.addToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.folderToolStripMenuItem,
            this.filesToolStripMenuItem,
            this.filesfolderScanToolStripMenuItem});
            this.addToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("addToolStripMenuItem.Image")));
            this.addToolStripMenuItem.Name = "addToolStripMenuItem";
            this.addToolStripMenuItem.Size = new System.Drawing.Size(440, 34);
            this.addToolStripMenuItem.Text = "&Add";
            // 
            // folderToolStripMenuItem
            // 
            this.folderToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("folderToolStripMenuItem.Image")));
            this.folderToolStripMenuItem.Name = "folderToolStripMenuItem";
            this.folderToolStripMenuItem.Size = new System.Drawing.Size(250, 34);
            this.folderToolStripMenuItem.Text = "&Folder";
            this.folderToolStripMenuItem.ToolTipText = "Add folder to the favorite folders list";
            this.folderToolStripMenuItem.Click += new System.EventHandler(this.AddFolder);
            // 
            // filesToolStripMenuItem
            // 
            this.filesToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("filesToolStripMenuItem.Image")));
            this.filesToolStripMenuItem.Name = "filesToolStripMenuItem";
            this.filesToolStripMenuItem.Size = new System.Drawing.Size(250, 34);
            this.filesToolStripMenuItem.Text = "Fi&les";
            this.filesToolStripMenuItem.ToolTipText = "Add files to the list";
            this.filesToolStripMenuItem.Click += new System.EventHandler(this.AddFiles);
            // 
            // filesfolderScanToolStripMenuItem
            // 
            this.filesfolderScanToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("filesfolderScanToolStripMenuItem.Image")));
            this.filesfolderScanToolStripMenuItem.Name = "filesfolderScanToolStripMenuItem";
            this.filesfolderScanToolStripMenuItem.Size = new System.Drawing.Size(250, 34);
            this.filesfolderScanToolStripMenuItem.Text = "Files (folder scan)";
            this.filesfolderScanToolStripMenuItem.Click += new System.EventHandler(this.AddFilesFolderScan);
            // 
            // toolStripSeparator6
            // 
            this.toolStripSeparator6.Name = "toolStripSeparator6";
            this.toolStripSeparator6.Size = new System.Drawing.Size(437, 6);
            // 
            // createListToolStripMenuItem
            // 
            this.createListToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("createListToolStripMenuItem.Image")));
            this.createListToolStripMenuItem.Name = "createListToolStripMenuItem";
            this.createListToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.N)));
            this.createListToolStripMenuItem.Size = new System.Drawing.Size(440, 34);
            this.createListToolStripMenuItem.Text = "&Create list";
            this.createListToolStripMenuItem.ToolTipText = "Create a list using files in the files list.\r\nThe list that created will be liste" +
    "d in the lists list.";
            this.createListToolStripMenuItem.Click += new System.EventHandler(this.CreateList);
            // 
            // addListFromFileToolStripMenuItem
            // 
            this.addListFromFileToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("addListFromFileToolStripMenuItem.Image")));
            this.addListFromFileToolStripMenuItem.Name = "addListFromFileToolStripMenuItem";
            this.addListFromFileToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Alt) 
            | System.Windows.Forms.Keys.N)));
            this.addListFromFileToolStripMenuItem.Size = new System.Drawing.Size(440, 34);
            this.addListFromFileToolStripMenuItem.Text = "Add list from file";
            this.addListFromFileToolStripMenuItem.ToolTipText = "Create internal list (in the lists list) from file";
            this.addListFromFileToolStripMenuItem.Click += new System.EventHandler(this.addFromFileToolStripMenuItem_Click);
            // 
            // toolStripSeparator8
            // 
            this.toolStripSeparator8.Name = "toolStripSeparator8";
            this.toolStripSeparator8.Size = new System.Drawing.Size(437, 6);
            // 
            // openfilequickEditToolStripMenuItem
            // 
            this.openfilequickEditToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("openfilequickEditToolStripMenuItem.Image")));
            this.openfilequickEditToolStripMenuItem.Name = "openfilequickEditToolStripMenuItem";
            this.openfilequickEditToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
            this.openfilequickEditToolStripMenuItem.Size = new System.Drawing.Size(440, 34);
            this.openfilequickEditToolStripMenuItem.Text = "Open &file (quick edit id3v2)";
            this.openfilequickEditToolStripMenuItem.ToolTipText = "Open mp3 file(s), edit id3 tag then save changes.";
            this.openfilequickEditToolStripMenuItem.Click += new System.EventHandler(this.OpenFileQuickV2Edit);
            // 
            // openFilequickEditId3v1ToolStripMenuItem
            // 
            this.openFilequickEditId3v1ToolStripMenuItem.Name = "openFilequickEditId3v1ToolStripMenuItem";
            this.openFilequickEditId3v1ToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift) 
            | System.Windows.Forms.Keys.O)));
            this.openFilequickEditId3v1ToolStripMenuItem.Size = new System.Drawing.Size(440, 34);
            this.openFilequickEditId3v1ToolStripMenuItem.Text = "Open file (quick edit id3v1)";
            this.openFilequickEditId3v1ToolStripMenuItem.Click += new System.EventHandler(this.OpenFileQuickV1Edit);
            // 
            // openListToolStripMenuItem
            // 
            this.openListToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("openListToolStripMenuItem.Image")));
            this.openListToolStripMenuItem.Name = "openListToolStripMenuItem";
            this.openListToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Alt) 
            | System.Windows.Forms.Keys.O)));
            this.openListToolStripMenuItem.Size = new System.Drawing.Size(440, 34);
            this.openListToolStripMenuItem.Text = "&Open list";
            this.openListToolStripMenuItem.ToolTipText = "Open list file then add the files to the list.\r\nIf the list is not empty, the ope" +
    "ned list file(s) will be added\r\nwithout clrearing the list.";
            this.openListToolStripMenuItem.Click += new System.EventHandler(this.OpenList);
            // 
            // toolStripSeparator16
            // 
            this.toolStripSeparator16.Name = "toolStripSeparator16";
            this.toolStripSeparator16.Size = new System.Drawing.Size(437, 6);
            // 
            // saveListToolStripMenuItem
            // 
            this.saveListToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("saveListToolStripMenuItem.Image")));
            this.saveListToolStripMenuItem.Name = "saveListToolStripMenuItem";
            this.saveListToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.saveListToolStripMenuItem.Size = new System.Drawing.Size(440, 34);
            this.saveListToolStripMenuItem.Text = "&Save list";
            this.saveListToolStripMenuItem.ToolTipText = "Save current files in the files list as list file.";
            this.saveListToolStripMenuItem.Click += new System.EventHandler(this.SaveList);
            // 
            // exportToolStripMenuItem
            // 
            this.exportToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("exportToolStripMenuItem.Image")));
            this.exportToolStripMenuItem.Name = "exportToolStripMenuItem";
            this.exportToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Alt) 
            | System.Windows.Forms.Keys.X)));
            this.exportToolStripMenuItem.Size = new System.Drawing.Size(440, 34);
            this.exportToolStripMenuItem.Text = "E&xport list as file";
            this.exportToolStripMenuItem.ToolTipText = "Export selected list from the lists browser\r\nas a file.";
            this.exportToolStripMenuItem.Click += new System.EventHandler(this.ExportListAsFile);
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(437, 6);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("exitToolStripMenuItem.Image")));
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.F4)));
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(440, 34);
            this.exitToolStripMenuItem.Text = "&Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.deleteToolStripMenuItem,
            this.toolStripSeparator10,
            this.fullEditId3v1ToolStripMenuItem,
            this.fullEditId3v2ToolStripMenuItem,
            this.toolStripSeparator20,
            this.clearId3v1ToolStripMenuItem,
            this.clearId3v2ToolStripMenuItem,
            this.toolStripSeparator22,
            this.selectAllToolStripMenuItem});
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            this.editToolStripMenuItem.Size = new System.Drawing.Size(58, 29);
            this.editToolStripMenuItem.Text = "&Edit";
            // 
            // deleteToolStripMenuItem
            // 
            this.deleteToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("deleteToolStripMenuItem.Image")));
            this.deleteToolStripMenuItem.Name = "deleteToolStripMenuItem";
            this.deleteToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.Delete;
            this.deleteToolStripMenuItem.Size = new System.Drawing.Size(294, 34);
            this.deleteToolStripMenuItem.Text = "&Delete";
            this.deleteToolStripMenuItem.Click += new System.EventHandler(this.Delete);
            this.deleteToolStripMenuItem.EnabledChanged += new System.EventHandler(this.deleteToolStripMenuItem_EnabledChanged);
            // 
            // toolStripSeparator10
            // 
            this.toolStripSeparator10.Name = "toolStripSeparator10";
            this.toolStripSeparator10.Size = new System.Drawing.Size(291, 6);
            // 
            // fullEditId3v1ToolStripMenuItem
            // 
            this.fullEditId3v1ToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("fullEditId3v1ToolStripMenuItem.Image")));
            this.fullEditId3v1ToolStripMenuItem.Name = "fullEditId3v1ToolStripMenuItem";
            this.fullEditId3v1ToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.W)));
            this.fullEditId3v1ToolStripMenuItem.Size = new System.Drawing.Size(294, 34);
            this.fullEditId3v1ToolStripMenuItem.Text = "Full edit Id3v1";
            this.fullEditId3v1ToolStripMenuItem.Click += new System.EventHandler(this.FullEditId3v1);
            // 
            // fullEditId3v2ToolStripMenuItem
            // 
            this.fullEditId3v2ToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("fullEditId3v2ToolStripMenuItem.Image")));
            this.fullEditId3v2ToolStripMenuItem.Name = "fullEditId3v2ToolStripMenuItem";
            this.fullEditId3v2ToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.E)));
            this.fullEditId3v2ToolStripMenuItem.Size = new System.Drawing.Size(294, 34);
            this.fullEditId3v2ToolStripMenuItem.Text = "Full &edit Id3v2";
            this.fullEditId3v2ToolStripMenuItem.Click += new System.EventHandler(this.FullEditId3v2);
            // 
            // toolStripSeparator20
            // 
            this.toolStripSeparator20.Name = "toolStripSeparator20";
            this.toolStripSeparator20.Size = new System.Drawing.Size(291, 6);
            // 
            // clearId3v1ToolStripMenuItem
            // 
            this.clearId3v1ToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("clearId3v1ToolStripMenuItem.Image")));
            this.clearId3v1ToolStripMenuItem.Name = "clearId3v1ToolStripMenuItem";
            this.clearId3v1ToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F4;
            this.clearId3v1ToolStripMenuItem.Size = new System.Drawing.Size(294, 34);
            this.clearId3v1ToolStripMenuItem.Text = "Clear id3v1";
            this.clearId3v1ToolStripMenuItem.ToolTipText = "Clear id3 tag version 1 for selected files";
            this.clearId3v1ToolStripMenuItem.Click += new System.EventHandler(this.ClearV1);
            // 
            // clearId3v2ToolStripMenuItem
            // 
            this.clearId3v2ToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("clearId3v2ToolStripMenuItem.Image")));
            this.clearId3v2ToolStripMenuItem.Name = "clearId3v2ToolStripMenuItem";
            this.clearId3v2ToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F5;
            this.clearId3v2ToolStripMenuItem.Size = new System.Drawing.Size(294, 34);
            this.clearId3v2ToolStripMenuItem.Text = "Clear id3v2";
            this.clearId3v2ToolStripMenuItem.ToolTipText = "Clear id3 tag version 2 for selected files";
            this.clearId3v2ToolStripMenuItem.Click += new System.EventHandler(this.ClearV2);
            // 
            // toolStripSeparator22
            // 
            this.toolStripSeparator22.Name = "toolStripSeparator22";
            this.toolStripSeparator22.Size = new System.Drawing.Size(291, 6);
            // 
            // selectAllToolStripMenuItem
            // 
            this.selectAllToolStripMenuItem.Name = "selectAllToolStripMenuItem";
            this.selectAllToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.A)));
            this.selectAllToolStripMenuItem.Size = new System.Drawing.Size(294, 34);
            this.selectAllToolStripMenuItem.Text = "&Select all";
            this.selectAllToolStripMenuItem.Click += new System.EventHandler(this.selectAllToolStripMenuItem_Click);
            // 
            // viewToolStripMenuItem
            // 
            this.viewToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.columnsToolStripMenuItem,
            this.tabsToolStripMenuItem,
            this.toolbarsToolStripMenuItem,
            this.toolStripSeparator2,
            this.resetLayoutToolStripMenuItem,
            this.saveLayoutToolStripMenuItem,
            this.loadLayoutToolStripMenuItem,
            this.toolStripSeparator18,
            this.logWindowToolStripMenuItem});
            this.viewToolStripMenuItem.Name = "viewToolStripMenuItem";
            this.viewToolStripMenuItem.Size = new System.Drawing.Size(65, 29);
            this.viewToolStripMenuItem.Text = "&View";
            this.viewToolStripMenuItem.DropDownOpening += new System.EventHandler(this.viewToolStripMenuItem_DropDownOpening);
            // 
            // columnsToolStripMenuItem
            // 
            this.columnsToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("columnsToolStripMenuItem.Image")));
            this.columnsToolStripMenuItem.Name = "columnsToolStripMenuItem";
            this.columnsToolStripMenuItem.Size = new System.Drawing.Size(306, 34);
            this.columnsToolStripMenuItem.Text = "&Columns";
            this.columnsToolStripMenuItem.DropDownItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.columnsToolStripMenuItem_DropDownItemClicked);
            // 
            // tabsToolStripMenuItem
            // 
            this.tabsToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("tabsToolStripMenuItem.Image")));
            this.tabsToolStripMenuItem.Name = "tabsToolStripMenuItem";
            this.tabsToolStripMenuItem.Size = new System.Drawing.Size(306, 34);
            this.tabsToolStripMenuItem.Text = "&Tab pages";
            this.tabsToolStripMenuItem.DropDownItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.tabsToolStripMenuItem_DropDownItemClicked);
            // 
            // toolbarsToolStripMenuItem
            // 
            this.toolbarsToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("toolbarsToolStripMenuItem.Image")));
            this.toolbarsToolStripMenuItem.Name = "toolbarsToolStripMenuItem";
            this.toolbarsToolStripMenuItem.Size = new System.Drawing.Size(306, 34);
            this.toolbarsToolStripMenuItem.Text = "Tool&bars";
            this.toolbarsToolStripMenuItem.DropDownItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.toolbarsToolStripMenuItem_DropDownItemClicked);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(303, 6);
            // 
            // resetLayoutToolStripMenuItem
            // 
            this.resetLayoutToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("resetLayoutToolStripMenuItem.Image")));
            this.resetLayoutToolStripMenuItem.Name = "resetLayoutToolStripMenuItem";
            this.resetLayoutToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Alt) 
            | System.Windows.Forms.Keys.R)));
            this.resetLayoutToolStripMenuItem.Size = new System.Drawing.Size(306, 34);
            this.resetLayoutToolStripMenuItem.Text = "&Reset layout";
            this.resetLayoutToolStripMenuItem.Click += new System.EventHandler(this.resetLayoutToolStripMenuItem_Click);
            // 
            // saveLayoutToolStripMenuItem
            // 
            this.saveLayoutToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("saveLayoutToolStripMenuItem.Image")));
            this.saveLayoutToolStripMenuItem.Name = "saveLayoutToolStripMenuItem";
            this.saveLayoutToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Alt) 
            | System.Windows.Forms.Keys.S)));
            this.saveLayoutToolStripMenuItem.Size = new System.Drawing.Size(306, 34);
            this.saveLayoutToolStripMenuItem.Text = "&Save layout";
            this.saveLayoutToolStripMenuItem.Click += new System.EventHandler(this.saveLayoutToolStripMenuItem_Click);
            // 
            // loadLayoutToolStripMenuItem
            // 
            this.loadLayoutToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("loadLayoutToolStripMenuItem.Image")));
            this.loadLayoutToolStripMenuItem.Name = "loadLayoutToolStripMenuItem";
            this.loadLayoutToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Alt) 
            | System.Windows.Forms.Keys.O)));
            this.loadLayoutToolStripMenuItem.Size = new System.Drawing.Size(306, 34);
            this.loadLayoutToolStripMenuItem.Text = "&Load layout";
            this.loadLayoutToolStripMenuItem.Click += new System.EventHandler(this.loadLayoutToolStripMenuItem_Click);
            // 
            // toolStripSeparator18
            // 
            this.toolStripSeparator18.Name = "toolStripSeparator18";
            this.toolStripSeparator18.Size = new System.Drawing.Size(303, 6);
            // 
            // logWindowToolStripMenuItem
            // 
            this.logWindowToolStripMenuItem.Name = "logWindowToolStripMenuItem";
            this.logWindowToolStripMenuItem.Size = new System.Drawing.Size(306, 34);
            this.logWindowToolStripMenuItem.Text = "Log window";
            this.logWindowToolStripMenuItem.Click += new System.EventHandler(this.logWindowToolStripMenuItem_Click);
            // 
            // toolsToolStripMenuItem
            // 
            this.toolsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.renameFileUsingTagToolStripMenuItem,
            this.tagExplorerToolStripMenuItem,
            this.extractTagContentToolStripMenuItem,
            this.extractTagFolderinFoldersToolStripMenuItem,
            this.toolStripSeparator25,
            this.settingsToolStripMenuItem});
            this.toolsToolStripMenuItem.Name = "toolsToolStripMenuItem";
            this.toolsToolStripMenuItem.Size = new System.Drawing.Size(69, 29);
            this.toolsToolStripMenuItem.Text = "&Tools";
            // 
            // renameFileUsingTagToolStripMenuItem
            // 
            this.renameFileUsingTagToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("renameFileUsingTagToolStripMenuItem.Image")));
            this.renameFileUsingTagToolStripMenuItem.Name = "renameFileUsingTagToolStripMenuItem";
            this.renameFileUsingTagToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.F2)));
            this.renameFileUsingTagToolStripMenuItem.Size = new System.Drawing.Size(366, 34);
            this.renameFileUsingTagToolStripMenuItem.Text = "Rename files using tag";
            this.renameFileUsingTagToolStripMenuItem.Click += new System.EventHandler(this.RenameFilesUsingTag);
            // 
            // tagExplorerToolStripMenuItem
            // 
            this.tagExplorerToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("tagExplorerToolStripMenuItem.Image")));
            this.tagExplorerToolStripMenuItem.Name = "tagExplorerToolStripMenuItem";
            this.tagExplorerToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F5;
            this.tagExplorerToolStripMenuItem.Size = new System.Drawing.Size(366, 34);
            this.tagExplorerToolStripMenuItem.Text = "Tag explorer";
            this.tagExplorerToolStripMenuItem.Click += new System.EventHandler(this.OpenWithTagExplorer);
            // 
            // extractTagContentToolStripMenuItem
            // 
            this.extractTagContentToolStripMenuItem.Name = "extractTagContentToolStripMenuItem";
            this.extractTagContentToolStripMenuItem.Size = new System.Drawing.Size(366, 34);
            this.extractTagContentToolStripMenuItem.Text = "&Extract tag content";
            this.extractTagContentToolStripMenuItem.Click += new System.EventHandler(this.extractTagContentToolStripMenuItem_Click);
            // 
            // extractTagFolderinFoldersToolStripMenuItem
            // 
            this.extractTagFolderinFoldersToolStripMenuItem.Name = "extractTagFolderinFoldersToolStripMenuItem";
            this.extractTagFolderinFoldersToolStripMenuItem.Size = new System.Drawing.Size(366, 34);
            this.extractTagFolderinFoldersToolStripMenuItem.Text = "Extract tag contet (from folders)";
            this.extractTagFolderinFoldersToolStripMenuItem.Click += new System.EventHandler(this.extractTagFolderinFoldersToolStripMenuItem_Click);
            // 
            // toolStripSeparator25
            // 
            this.toolStripSeparator25.Name = "toolStripSeparator25";
            this.toolStripSeparator25.Size = new System.Drawing.Size(363, 6);
            // 
            // settingsToolStripMenuItem
            // 
            this.settingsToolStripMenuItem.Name = "settingsToolStripMenuItem";
            this.settingsToolStripMenuItem.Size = new System.Drawing.Size(366, 34);
            this.settingsToolStripMenuItem.Text = "&Settings";
            this.settingsToolStripMenuItem.Click += new System.EventHandler(this.settingsToolStripMenuItem_Click);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.viewhelpToolStripMenuItem,
            this.wikiOnlineHelpToolStripMenuItem,
            this.toolStripSeparator1,
            this.websiteToolStripMenuItem,
            this.toolStripSeparator28,
            this.aboutAHDID3TagEditorToolStripMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(65, 29);
            this.helpToolStripMenuItem.Text = "&Help";
            // 
            // viewhelpToolStripMenuItem
            // 
            this.viewhelpToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("viewhelpToolStripMenuItem.Image")));
            this.viewhelpToolStripMenuItem.Name = "viewhelpToolStripMenuItem";
            this.viewhelpToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F1;
            this.viewhelpToolStripMenuItem.Size = new System.Drawing.Size(326, 34);
            this.viewhelpToolStripMenuItem.Text = "View &help";
            this.viewhelpToolStripMenuItem.Click += new System.EventHandler(this.viewhelpToolStripMenuItem_Click);
            // 
            // wikiOnlineHelpToolStripMenuItem
            // 
            this.wikiOnlineHelpToolStripMenuItem.Name = "wikiOnlineHelpToolStripMenuItem";
            this.wikiOnlineHelpToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.F1)));
            this.wikiOnlineHelpToolStripMenuItem.Size = new System.Drawing.Size(326, 34);
            this.wikiOnlineHelpToolStripMenuItem.Text = "Wiki (Online Help)";
            this.wikiOnlineHelpToolStripMenuItem.Click += new System.EventHandler(this.wikiOnlineHelpToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(323, 6);
            // 
            // websiteToolStripMenuItem
            // 
            this.websiteToolStripMenuItem.Name = "websiteToolStripMenuItem";
            this.websiteToolStripMenuItem.Size = new System.Drawing.Size(326, 34);
            this.websiteToolStripMenuItem.Text = "&Website";
            this.websiteToolStripMenuItem.Click += new System.EventHandler(this.websiteToolStripMenuItem_Click);
            // 
            // toolStripSeparator28
            // 
            this.toolStripSeparator28.Name = "toolStripSeparator28";
            this.toolStripSeparator28.Size = new System.Drawing.Size(323, 6);
            // 
            // aboutAHDID3TagEditorToolStripMenuItem
            // 
            this.aboutAHDID3TagEditorToolStripMenuItem.Image = global::AHD.ID3.Editor.Properties.Resources.AITE1;
            this.aboutAHDID3TagEditorToolStripMenuItem.Name = "aboutAHDID3TagEditorToolStripMenuItem";
            this.aboutAHDID3TagEditorToolStripMenuItem.Size = new System.Drawing.Size(326, 34);
            this.aboutAHDID3TagEditorToolStripMenuItem.Text = "&About AHD ID3 Tag Editor";
            this.aboutAHDID3TagEditorToolStripMenuItem.Click += new System.EventHandler(this.aboutAHDID3TagEditorToolStripMenuItem_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.StatusLabel,
            this.ProgressBar1});
            this.statusStrip1.Location = new System.Drawing.Point(0, 628);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Padding = new System.Windows.Forms.Padding(2, 0, 21, 0);
            this.statusStrip1.Size = new System.Drawing.Size(1162, 32);
            this.statusStrip1.TabIndex = 1;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // StatusLabel
            // 
            this.StatusLabel.Name = "StatusLabel";
            this.StatusLabel.Size = new System.Drawing.Size(64, 25);
            this.StatusLabel.Text = "Ready.";
            // 
            // ProgressBar1
            // 
            this.ProgressBar1.Name = "ProgressBar1";
            this.ProgressBar1.Size = new System.Drawing.Size(150, 24);
            this.ProgressBar1.Visible = false;
            // 
            // toolStripContainer1
            // 
            // 
            // toolStripContainer1.ContentPanel
            // 
            this.toolStripContainer1.ContentPanel.Controls.Add(this.splitContainer1);
            this.toolStripContainer1.ContentPanel.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.toolStripContainer1.ContentPanel.Size = new System.Drawing.Size(1162, 562);
            this.toolStripContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.toolStripContainer1.Location = new System.Drawing.Point(0, 33);
            this.toolStripContainer1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.toolStripContainer1.Name = "toolStripContainer1";
            this.toolStripContainer1.Size = new System.Drawing.Size(1162, 595);
            this.toolStripContainer1.TabIndex = 2;
            this.toolStripContainer1.Text = "toolStripContainer1";
            // 
            // toolStripContainer1.TopToolStripPanel
            // 
            this.toolStripContainer1.TopToolStripPanel.Controls.Add(this.toolStrip_main);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.splitContainer3);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.splitContainer2);
            this.splitContainer1.Size = new System.Drawing.Size(1162, 562);
            this.splitContainer1.SplitterDistance = 205;
            this.splitContainer1.SplitterWidth = 6;
            this.splitContainer1.TabIndex = 0;
            // 
            // splitContainer3
            // 
            this.splitContainer3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer3.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.splitContainer3.Location = new System.Drawing.Point(0, 0);
            this.splitContainer3.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.splitContainer3.Name = "splitContainer3";
            this.splitContainer3.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer3.Panel1
            // 
            this.splitContainer3.Panel1.Controls.Add(this.managedTabControl_topLeft);
            // 
            // splitContainer3.Panel2
            // 
            this.splitContainer3.Panel2.Controls.Add(this.managedTabControl_downLeft);
            this.splitContainer3.Size = new System.Drawing.Size(205, 562);
            this.splitContainer3.SplitterDistance = 366;
            this.splitContainer3.SplitterWidth = 6;
            this.splitContainer3.TabIndex = 0;
            // 
            // managedTabControl_topLeft
            // 
            this.managedTabControl_topLeft.AllowAutoTabPageDragAndDrop = true;
            this.managedTabControl_topLeft.AllowDrop = true;
            this.managedTabControl_topLeft.AllowTabPageDragAndDrop = true;
            this.managedTabControl_topLeft.AllowTabPagesReorder = true;
            this.managedTabControl_topLeft.AutoSelectAddedTabPageAfterAddingIt = false;
            this.managedTabControl_topLeft.CloseBoxAlwaysVisible = false;
            this.managedTabControl_topLeft.CloseBoxOnEachPageVisible = true;
            this.managedTabControl_topLeft.CloseTabOnCloseButtonClick = true;
            this.managedTabControl_topLeft.Dock = System.Windows.Forms.DockStyle.Fill;
            this.managedTabControl_topLeft.DrawStyle = MTC.MTCDrawStyle.Normal;
            this.managedTabControl_topLeft.DrawTabPageHighlight = true;
            this.managedTabControl_topLeft.ImagesList = this.imageList1;
            this.managedTabControl_topLeft.Location = new System.Drawing.Point(0, 0);
            this.managedTabControl_topLeft.Margin = new System.Windows.Forms.Padding(6, 8, 6, 8);
            this.managedTabControl_topLeft.Name = "managedTabControl_topLeft";
            this.managedTabControl_topLeft.SelectedTabPageIndex = 0;
            this.managedTabControl_topLeft.ShowTabPageToolTip = true;
            this.managedTabControl_topLeft.ShowTabPageToolTipAlways = false;
            this.managedTabControl_topLeft.Size = new System.Drawing.Size(205, 366);
            this.managedTabControl_topLeft.TabIndex = 0;
            this.managedTabControl_topLeft.TabPageColor = System.Drawing.Color.Silver;
            this.managedTabControl_topLeft.TabPageHighlightedColor = System.Drawing.Color.Khaki;
            this.managedTabControl_topLeft.TabPageMaxWidth = 500;
            this.managedTabControl_topLeft.TabPageSelectedColor = System.Drawing.Color.BurlyWood;
            this.managedTabControl_topLeft.TabPageSplitColor = System.Drawing.Color.Gray;
            this.managedTabControl_topLeft.TabPageClose += new System.EventHandler<MTC.MTCTabPageCloseArgs>(this.managedTabControl_topLeft_TabPageClose);
            this.managedTabControl_topLeft.AfterTabPageReorder += new System.EventHandler(this.managedTabControl_topLeft_AfterTabPageReorder);
            this.managedTabControl_topLeft.BeforeAutoTabDragAndDrop += new System.EventHandler(this.managedTabControl_topLeft_BeforeAutoTabDragAndDrop);
            this.managedTabControl_topLeft.AfterAutoTabDragAndDrop += new System.EventHandler(this.managedTabControl_topLeft_AfterAutoTabDragAndDrop);
            this.managedTabControl_topLeft.TabPagesCleared += new System.EventHandler(this.managedTabControl_topLeft_TabPagesCleared);
            this.managedTabControl_topLeft.DragDrop += new System.Windows.Forms.DragEventHandler(this.managedTabControl_topLeft_DragDrop);
            this.managedTabControl_topLeft.DragEnter += new System.Windows.Forms.DragEventHandler(this.managedTabControl_topLeft_DragEnter);
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "application_view_detail.png");
            this.imageList1.Images.SetKeyName(1, "folder_explore.png");
            this.imageList1.Images.SetKeyName(2, "images.png");
            this.imageList1.Images.SetKeyName(3, "note_edit.png");
            this.imageList1.Images.SetKeyName(4, "application_view_list.png");
            this.imageList1.Images.SetKeyName(5, "page_white_edit.png");
            this.imageList1.Images.SetKeyName(6, "link.png");
            this.imageList1.Images.SetKeyName(7, "comments.png");
            this.imageList1.Images.SetKeyName(8, "star.png");
            this.imageList1.Images.SetKeyName(9, "user_suit.png");
            this.imageList1.Images.SetKeyName(10, "text_signature.png");
            this.imageList1.Images.SetKeyName(11, "page_white_cd.png");
            this.imageList1.Images.SetKeyName(12, "cd.png");
            this.imageList1.Images.SetKeyName(13, "page_white_stack.png");
            this.imageList1.Images.SetKeyName(14, "money_dollar.png");
            this.imageList1.Images.SetKeyName(15, "chart_bar.png");
            this.imageList1.Images.SetKeyName(16, "hourglass.png");
            this.imageList1.Images.SetKeyName(17, "report.png");
            this.imageList1.Images.SetKeyName(18, "wmpp.ico");
            this.imageList1.Images.SetKeyName(19, "monitor.png");
            this.imageList1.Images.SetKeyName(20, "asterisk_yellow.png");
            this.imageList1.Images.SetKeyName(21, "id3v2.ico");
            // 
            // managedTabControl_downLeft
            // 
            this.managedTabControl_downLeft.AllowAutoTabPageDragAndDrop = true;
            this.managedTabControl_downLeft.AllowDrop = true;
            this.managedTabControl_downLeft.AllowTabPageDragAndDrop = true;
            this.managedTabControl_downLeft.AllowTabPagesReorder = true;
            this.managedTabControl_downLeft.AutoSelectAddedTabPageAfterAddingIt = false;
            this.managedTabControl_downLeft.CloseBoxAlwaysVisible = false;
            this.managedTabControl_downLeft.CloseBoxOnEachPageVisible = true;
            this.managedTabControl_downLeft.CloseTabOnCloseButtonClick = true;
            this.managedTabControl_downLeft.Dock = System.Windows.Forms.DockStyle.Fill;
            this.managedTabControl_downLeft.DrawStyle = MTC.MTCDrawStyle.Normal;
            this.managedTabControl_downLeft.DrawTabPageHighlight = true;
            this.managedTabControl_downLeft.ImagesList = this.imageList1;
            this.managedTabControl_downLeft.Location = new System.Drawing.Point(0, 0);
            this.managedTabControl_downLeft.Margin = new System.Windows.Forms.Padding(6, 8, 6, 8);
            this.managedTabControl_downLeft.Name = "managedTabControl_downLeft";
            this.managedTabControl_downLeft.SelectedTabPageIndex = 0;
            this.managedTabControl_downLeft.ShowTabPageToolTip = true;
            this.managedTabControl_downLeft.ShowTabPageToolTipAlways = false;
            this.managedTabControl_downLeft.Size = new System.Drawing.Size(205, 190);
            this.managedTabControl_downLeft.TabIndex = 0;
            this.managedTabControl_downLeft.TabPageColor = System.Drawing.Color.Silver;
            this.managedTabControl_downLeft.TabPageHighlightedColor = System.Drawing.Color.Khaki;
            this.managedTabControl_downLeft.TabPageMaxWidth = 500;
            this.managedTabControl_downLeft.TabPageSelectedColor = System.Drawing.Color.BurlyWood;
            this.managedTabControl_downLeft.TabPageSplitColor = System.Drawing.Color.Gray;
            this.managedTabControl_downLeft.TabPageClose += new System.EventHandler<MTC.MTCTabPageCloseArgs>(this.managedTabControl_downLeft_TabPageClose);
            this.managedTabControl_downLeft.AfterTabPageReorder += new System.EventHandler(this.managedTabControl_downLeft_AfterTabPageReorder);
            this.managedTabControl_downLeft.BeforeAutoTabDragAndDrop += new System.EventHandler(this.managedTabControl_topLeft_BeforeAutoTabDragAndDrop);
            this.managedTabControl_downLeft.AfterAutoTabDragAndDrop += new System.EventHandler(this.managedTabControl_topLeft_AfterAutoTabDragAndDrop);
            this.managedTabControl_downLeft.TabPagesCleared += new System.EventHandler(this.managedTabControl_topLeft_TabPagesCleared);
            this.managedTabControl_downLeft.DragDrop += new System.Windows.Forms.DragEventHandler(this.managedTabControl_downLeft_DragDrop);
            this.managedTabControl_downLeft.DragEnter += new System.Windows.Forms.DragEventHandler(this.managedTabControl_topLeft_DragEnter);
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.splitContainer2.Name = "splitContainer2";
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.splitContainer4);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.splitContainer5);
            this.splitContainer2.Size = new System.Drawing.Size(951, 562);
            this.splitContainer2.SplitterDistance = 771;
            this.splitContainer2.SplitterWidth = 6;
            this.splitContainer2.TabIndex = 0;
            // 
            // splitContainer4
            // 
            this.splitContainer4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer4.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.splitContainer4.Location = new System.Drawing.Point(0, 0);
            this.splitContainer4.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.splitContainer4.Name = "splitContainer4";
            this.splitContainer4.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer4.Panel1
            // 
            this.splitContainer4.Panel1.Controls.Add(this.managedTabControl_topMiddle);
            // 
            // splitContainer4.Panel2
            // 
            this.splitContainer4.Panel2.Controls.Add(this.managedTabControl_downMiddle);
            this.splitContainer4.Size = new System.Drawing.Size(771, 562);
            this.splitContainer4.SplitterDistance = 439;
            this.splitContainer4.SplitterWidth = 6;
            this.splitContainer4.TabIndex = 0;
            // 
            // managedTabControl_topMiddle
            // 
            this.managedTabControl_topMiddle.AllowAutoTabPageDragAndDrop = true;
            this.managedTabControl_topMiddle.AllowDrop = true;
            this.managedTabControl_topMiddle.AllowTabPageDragAndDrop = true;
            this.managedTabControl_topMiddle.AllowTabPagesReorder = true;
            this.managedTabControl_topMiddle.AutoSelectAddedTabPageAfterAddingIt = false;
            this.managedTabControl_topMiddle.CloseBoxAlwaysVisible = false;
            this.managedTabControl_topMiddle.CloseBoxOnEachPageVisible = true;
            this.managedTabControl_topMiddle.CloseTabOnCloseButtonClick = true;
            this.managedTabControl_topMiddle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.managedTabControl_topMiddle.DrawStyle = MTC.MTCDrawStyle.Normal;
            this.managedTabControl_topMiddle.DrawTabPageHighlight = true;
            this.managedTabControl_topMiddle.ImagesList = this.imageList1;
            this.managedTabControl_topMiddle.Location = new System.Drawing.Point(0, 0);
            this.managedTabControl_topMiddle.Margin = new System.Windows.Forms.Padding(6, 8, 6, 8);
            this.managedTabControl_topMiddle.Name = "managedTabControl_topMiddle";
            this.managedTabControl_topMiddle.SelectedTabPageIndex = 0;
            this.managedTabControl_topMiddle.ShowTabPageToolTip = true;
            this.managedTabControl_topMiddle.ShowTabPageToolTipAlways = false;
            this.managedTabControl_topMiddle.Size = new System.Drawing.Size(771, 439);
            this.managedTabControl_topMiddle.TabIndex = 0;
            this.managedTabControl_topMiddle.TabPageColor = System.Drawing.Color.Silver;
            this.managedTabControl_topMiddle.TabPageHighlightedColor = System.Drawing.Color.Khaki;
            this.managedTabControl_topMiddle.TabPageMaxWidth = 500;
            this.managedTabControl_topMiddle.TabPageSelectedColor = System.Drawing.Color.BurlyWood;
            this.managedTabControl_topMiddle.TabPageSplitColor = System.Drawing.Color.Gray;
            this.managedTabControl_topMiddle.TabPageClose += new System.EventHandler<MTC.MTCTabPageCloseArgs>(this.managedTabControl_topMiddle_TabPageClose);
            this.managedTabControl_topMiddle.AfterTabPageReorder += new System.EventHandler(this.managedTabControl_topMiddle_AfterTabPageReorder);
            this.managedTabControl_topMiddle.BeforeAutoTabDragAndDrop += new System.EventHandler(this.managedTabControl_topLeft_BeforeAutoTabDragAndDrop);
            this.managedTabControl_topMiddle.AfterAutoTabDragAndDrop += new System.EventHandler(this.managedTabControl_topLeft_AfterAutoTabDragAndDrop);
            this.managedTabControl_topMiddle.TabPagesCleared += new System.EventHandler(this.managedTabControl_topLeft_TabPagesCleared);
            this.managedTabControl_topMiddle.DragDrop += new System.Windows.Forms.DragEventHandler(this.managedTabControl_topMiddle_DragDrop);
            this.managedTabControl_topMiddle.DragEnter += new System.Windows.Forms.DragEventHandler(this.managedTabControl_topLeft_DragEnter);
            // 
            // managedTabControl_downMiddle
            // 
            this.managedTabControl_downMiddle.AllowAutoTabPageDragAndDrop = true;
            this.managedTabControl_downMiddle.AllowDrop = true;
            this.managedTabControl_downMiddle.AllowTabPageDragAndDrop = true;
            this.managedTabControl_downMiddle.AllowTabPagesReorder = true;
            this.managedTabControl_downMiddle.AutoSelectAddedTabPageAfterAddingIt = false;
            this.managedTabControl_downMiddle.CloseBoxAlwaysVisible = false;
            this.managedTabControl_downMiddle.CloseBoxOnEachPageVisible = true;
            this.managedTabControl_downMiddle.CloseTabOnCloseButtonClick = true;
            this.managedTabControl_downMiddle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.managedTabControl_downMiddle.DrawStyle = MTC.MTCDrawStyle.Normal;
            this.managedTabControl_downMiddle.DrawTabPageHighlight = true;
            this.managedTabControl_downMiddle.ImagesList = this.imageList1;
            this.managedTabControl_downMiddle.Location = new System.Drawing.Point(0, 0);
            this.managedTabControl_downMiddle.Margin = new System.Windows.Forms.Padding(6, 8, 6, 8);
            this.managedTabControl_downMiddle.Name = "managedTabControl_downMiddle";
            this.managedTabControl_downMiddle.SelectedTabPageIndex = 0;
            this.managedTabControl_downMiddle.ShowTabPageToolTip = true;
            this.managedTabControl_downMiddle.ShowTabPageToolTipAlways = false;
            this.managedTabControl_downMiddle.Size = new System.Drawing.Size(771, 117);
            this.managedTabControl_downMiddle.TabIndex = 0;
            this.managedTabControl_downMiddle.TabPageColor = System.Drawing.Color.Silver;
            this.managedTabControl_downMiddle.TabPageHighlightedColor = System.Drawing.Color.Khaki;
            this.managedTabControl_downMiddle.TabPageMaxWidth = 500;
            this.managedTabControl_downMiddle.TabPageSelectedColor = System.Drawing.Color.BurlyWood;
            this.managedTabControl_downMiddle.TabPageSplitColor = System.Drawing.Color.Gray;
            this.managedTabControl_downMiddle.TabPageClose += new System.EventHandler<MTC.MTCTabPageCloseArgs>(this.managedTabControl_downMiddle_TabPageClose);
            this.managedTabControl_downMiddle.AfterTabPageReorder += new System.EventHandler(this.managedTabControl_downMiddle_AfterTabPageReorder);
            this.managedTabControl_downMiddle.BeforeAutoTabDragAndDrop += new System.EventHandler(this.managedTabControl_topLeft_BeforeAutoTabDragAndDrop);
            this.managedTabControl_downMiddle.AfterAutoTabDragAndDrop += new System.EventHandler(this.managedTabControl_topLeft_AfterAutoTabDragAndDrop);
            this.managedTabControl_downMiddle.TabPagesCleared += new System.EventHandler(this.managedTabControl_topLeft_TabPagesCleared);
            this.managedTabControl_downMiddle.DragDrop += new System.Windows.Forms.DragEventHandler(this.managedTabControl_downMiddle_DragDrop);
            this.managedTabControl_downMiddle.DragEnter += new System.Windows.Forms.DragEventHandler(this.managedTabControl_topLeft_DragEnter);
            // 
            // splitContainer5
            // 
            this.splitContainer5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer5.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.splitContainer5.Location = new System.Drawing.Point(0, 0);
            this.splitContainer5.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.splitContainer5.Name = "splitContainer5";
            this.splitContainer5.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer5.Panel1
            // 
            this.splitContainer5.Panel1.Controls.Add(this.managedTabControl_topRight);
            // 
            // splitContainer5.Panel2
            // 
            this.splitContainer5.Panel2.Controls.Add(this.managedTabControl_downRight);
            this.splitContainer5.Size = new System.Drawing.Size(174, 562);
            this.splitContainer5.SplitterDistance = 373;
            this.splitContainer5.SplitterWidth = 6;
            this.splitContainer5.TabIndex = 0;
            // 
            // managedTabControl_topRight
            // 
            this.managedTabControl_topRight.AllowAutoTabPageDragAndDrop = true;
            this.managedTabControl_topRight.AllowDrop = true;
            this.managedTabControl_topRight.AllowTabPageDragAndDrop = true;
            this.managedTabControl_topRight.AllowTabPagesReorder = true;
            this.managedTabControl_topRight.AutoSelectAddedTabPageAfterAddingIt = false;
            this.managedTabControl_topRight.CloseBoxAlwaysVisible = false;
            this.managedTabControl_topRight.CloseBoxOnEachPageVisible = true;
            this.managedTabControl_topRight.CloseTabOnCloseButtonClick = true;
            this.managedTabControl_topRight.Dock = System.Windows.Forms.DockStyle.Fill;
            this.managedTabControl_topRight.DrawStyle = MTC.MTCDrawStyle.Normal;
            this.managedTabControl_topRight.DrawTabPageHighlight = true;
            this.managedTabControl_topRight.ImagesList = this.imageList1;
            this.managedTabControl_topRight.Location = new System.Drawing.Point(0, 0);
            this.managedTabControl_topRight.Margin = new System.Windows.Forms.Padding(6, 8, 6, 8);
            this.managedTabControl_topRight.Name = "managedTabControl_topRight";
            this.managedTabControl_topRight.SelectedTabPageIndex = 0;
            this.managedTabControl_topRight.ShowTabPageToolTip = true;
            this.managedTabControl_topRight.ShowTabPageToolTipAlways = false;
            this.managedTabControl_topRight.Size = new System.Drawing.Size(174, 373);
            this.managedTabControl_topRight.TabIndex = 0;
            this.managedTabControl_topRight.TabPageColor = System.Drawing.Color.Silver;
            this.managedTabControl_topRight.TabPageHighlightedColor = System.Drawing.Color.Khaki;
            this.managedTabControl_topRight.TabPageMaxWidth = 500;
            this.managedTabControl_topRight.TabPageSelectedColor = System.Drawing.Color.BurlyWood;
            this.managedTabControl_topRight.TabPageSplitColor = System.Drawing.Color.Gray;
            this.managedTabControl_topRight.TabPageClose += new System.EventHandler<MTC.MTCTabPageCloseArgs>(this.managedTabControl_topRight_TabPageClose);
            this.managedTabControl_topRight.AfterTabPageReorder += new System.EventHandler(this.managedTabControl_topRight_AfterTabPageReorder);
            this.managedTabControl_topRight.BeforeAutoTabDragAndDrop += new System.EventHandler(this.managedTabControl_topLeft_BeforeAutoTabDragAndDrop);
            this.managedTabControl_topRight.AfterAutoTabDragAndDrop += new System.EventHandler(this.managedTabControl_topLeft_AfterAutoTabDragAndDrop);
            this.managedTabControl_topRight.TabPagesCleared += new System.EventHandler(this.managedTabControl_topLeft_TabPagesCleared);
            this.managedTabControl_topRight.DragDrop += new System.Windows.Forms.DragEventHandler(this.managedTabControl_topRight_DragDrop);
            this.managedTabControl_topRight.DragEnter += new System.Windows.Forms.DragEventHandler(this.managedTabControl_topLeft_DragEnter);
            // 
            // managedTabControl_downRight
            // 
            this.managedTabControl_downRight.AllowAutoTabPageDragAndDrop = true;
            this.managedTabControl_downRight.AllowDrop = true;
            this.managedTabControl_downRight.AllowTabPageDragAndDrop = true;
            this.managedTabControl_downRight.AllowTabPagesReorder = true;
            this.managedTabControl_downRight.AutoSelectAddedTabPageAfterAddingIt = false;
            this.managedTabControl_downRight.CloseBoxAlwaysVisible = false;
            this.managedTabControl_downRight.CloseBoxOnEachPageVisible = true;
            this.managedTabControl_downRight.CloseTabOnCloseButtonClick = true;
            this.managedTabControl_downRight.Dock = System.Windows.Forms.DockStyle.Fill;
            this.managedTabControl_downRight.DrawStyle = MTC.MTCDrawStyle.Normal;
            this.managedTabControl_downRight.DrawTabPageHighlight = true;
            this.managedTabControl_downRight.ImagesList = this.imageList1;
            this.managedTabControl_downRight.Location = new System.Drawing.Point(0, 0);
            this.managedTabControl_downRight.Margin = new System.Windows.Forms.Padding(6, 8, 6, 8);
            this.managedTabControl_downRight.Name = "managedTabControl_downRight";
            this.managedTabControl_downRight.SelectedTabPageIndex = 0;
            this.managedTabControl_downRight.ShowTabPageToolTip = true;
            this.managedTabControl_downRight.ShowTabPageToolTipAlways = false;
            this.managedTabControl_downRight.Size = new System.Drawing.Size(174, 183);
            this.managedTabControl_downRight.TabIndex = 0;
            this.managedTabControl_downRight.TabPageColor = System.Drawing.Color.Silver;
            this.managedTabControl_downRight.TabPageHighlightedColor = System.Drawing.Color.Khaki;
            this.managedTabControl_downRight.TabPageMaxWidth = 500;
            this.managedTabControl_downRight.TabPageSelectedColor = System.Drawing.Color.BurlyWood;
            this.managedTabControl_downRight.TabPageSplitColor = System.Drawing.Color.Gray;
            this.managedTabControl_downRight.TabPageClose += new System.EventHandler<MTC.MTCTabPageCloseArgs>(this.managedTabControl_downRight_TabPageClose);
            this.managedTabControl_downRight.AfterTabPageReorder += new System.EventHandler(this.managedTabControl_downRight_AfterTabPageReorder);
            this.managedTabControl_downRight.BeforeAutoTabDragAndDrop += new System.EventHandler(this.managedTabControl_topLeft_BeforeAutoTabDragAndDrop);
            this.managedTabControl_downRight.AfterAutoTabDragAndDrop += new System.EventHandler(this.managedTabControl_topLeft_AfterAutoTabDragAndDrop);
            this.managedTabControl_downRight.TabPagesCleared += new System.EventHandler(this.managedTabControl_topLeft_TabPagesCleared);
            this.managedTabControl_downRight.DragDrop += new System.Windows.Forms.DragEventHandler(this.managedTabControl_downRight_DragDrop);
            this.managedTabControl_downRight.DragEnter += new System.Windows.Forms.DragEventHandler(this.managedTabControl_topLeft_DragEnter);
            // 
            // toolStrip_main
            // 
            this.toolStrip_main.Dock = System.Windows.Forms.DockStyle.None;
            this.toolStrip_main.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.toolStrip_main.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButton2,
            this.toolStripButton3,
            this.toolStripButton4,
            this.toolStripSeparator7,
            this.toolStripButton8,
            this.toolStripButton12,
            this.toolStripSeparator17,
            this.toolStripButton11,
            this.toolStripButton7,
            this.toolStripSeparator12,
            this.toolStripButton6,
            this.toolStripButton9,
            this.toolStripSeparator4,
            this.toolStripButton5,
            this.toolStripButton17,
            this.toolStripSeparator26,
            this.toolStripButton13,
            this.toolStripButton10,
            this.toolStripButton14,
            this.toolStripButton15,
            this.toolStripSeparator24,
            this.toolStripButton16,
            this.toolStripSeparator3,
            this.toolStripButton1});
            this.toolStrip_main.Location = new System.Drawing.Point(4, 0);
            this.toolStrip_main.Name = "toolStrip_main";
            this.toolStrip_main.Size = new System.Drawing.Size(638, 33);
            this.toolStrip_main.TabIndex = 0;
            // 
            // toolStripButton2
            // 
            this.toolStripButton2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton2.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton2.Image")));
            this.toolStripButton2.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton2.Name = "toolStripButton2";
            this.toolStripButton2.Size = new System.Drawing.Size(34, 28);
            this.toolStripButton2.Text = "toolStripButton2";
            this.toolStripButton2.ToolTipText = "Add folder to the favorite folders list";
            this.toolStripButton2.Click += new System.EventHandler(this.AddFolder);
            // 
            // toolStripButton3
            // 
            this.toolStripButton3.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton3.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton3.Image")));
            this.toolStripButton3.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton3.Name = "toolStripButton3";
            this.toolStripButton3.Size = new System.Drawing.Size(34, 28);
            this.toolStripButton3.Text = "toolStripButton3";
            this.toolStripButton3.ToolTipText = "Add files to the list";
            this.toolStripButton3.Click += new System.EventHandler(this.AddFiles);
            // 
            // toolStripButton4
            // 
            this.toolStripButton4.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton4.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton4.Image")));
            this.toolStripButton4.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton4.Name = "toolStripButton4";
            this.toolStripButton4.Size = new System.Drawing.Size(34, 28);
            this.toolStripButton4.Text = "toolStripButton4";
            this.toolStripButton4.ToolTipText = "Add files to the list (folder scan)";
            this.toolStripButton4.Click += new System.EventHandler(this.AddFilesFolderScan);
            // 
            // toolStripSeparator7
            // 
            this.toolStripSeparator7.Name = "toolStripSeparator7";
            this.toolStripSeparator7.Size = new System.Drawing.Size(6, 33);
            // 
            // toolStripButton8
            // 
            this.toolStripButton8.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton8.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton8.Image")));
            this.toolStripButton8.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton8.Name = "toolStripButton8";
            this.toolStripButton8.Size = new System.Drawing.Size(34, 28);
            this.toolStripButton8.Text = "toolStripButton8";
            this.toolStripButton8.ToolTipText = "Create a list using files in the files list.\r\nThe list will be created will be li" +
    "sted in the lists list \r\n(not a file).";
            this.toolStripButton8.Click += new System.EventHandler(this.CreateList);
            // 
            // toolStripButton12
            // 
            this.toolStripButton12.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton12.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton12.Image")));
            this.toolStripButton12.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton12.Name = "toolStripButton12";
            this.toolStripButton12.Size = new System.Drawing.Size(34, 28);
            this.toolStripButton12.Text = "toolStripButton12";
            this.toolStripButton12.ToolTipText = "Create internal list (in the lists list) from file";
            this.toolStripButton12.Click += new System.EventHandler(this.addFromFileToolStripMenuItem_Click);
            // 
            // toolStripSeparator17
            // 
            this.toolStripSeparator17.Name = "toolStripSeparator17";
            this.toolStripSeparator17.Size = new System.Drawing.Size(6, 33);
            // 
            // toolStripButton11
            // 
            this.toolStripButton11.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton11.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton11.Image")));
            this.toolStripButton11.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton11.Name = "toolStripButton11";
            this.toolStripButton11.Size = new System.Drawing.Size(34, 28);
            this.toolStripButton11.Text = "toolStripButton11";
            this.toolStripButton11.ToolTipText = "Quick edit:\r\nOpen mp3 file(s), full edit id3 tag then save changes.";
            this.toolStripButton11.Click += new System.EventHandler(this.OpenFileQuickV2Edit);
            // 
            // toolStripButton7
            // 
            this.toolStripButton7.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton7.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton7.Image")));
            this.toolStripButton7.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton7.Name = "toolStripButton7";
            this.toolStripButton7.Size = new System.Drawing.Size(34, 28);
            this.toolStripButton7.Text = "toolStripButton7";
            this.toolStripButton7.ToolTipText = "Open list file then add the files to the list.\r\nIf the list is not empty, the ope" +
    "ned list file(s) will be added\r\nwithout clrearing the list.";
            this.toolStripButton7.Click += new System.EventHandler(this.OpenList);
            // 
            // toolStripSeparator12
            // 
            this.toolStripSeparator12.Name = "toolStripSeparator12";
            this.toolStripSeparator12.Size = new System.Drawing.Size(6, 33);
            // 
            // toolStripButton6
            // 
            this.toolStripButton6.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton6.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton6.Image")));
            this.toolStripButton6.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton6.Name = "toolStripButton6";
            this.toolStripButton6.Size = new System.Drawing.Size(34, 28);
            this.toolStripButton6.Text = "toolStripButton6";
            this.toolStripButton6.ToolTipText = "Save the files list as playlist file";
            this.toolStripButton6.Click += new System.EventHandler(this.SaveList);
            // 
            // toolStripButton9
            // 
            this.toolStripButton9.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton9.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton9.Image")));
            this.toolStripButton9.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton9.Name = "toolStripButton9";
            this.toolStripButton9.Size = new System.Drawing.Size(34, 28);
            this.toolStripButton9.Text = "toolStripButton9";
            this.toolStripButton9.ToolTipText = "Export selected list from the lists browser\r\nas a file.";
            this.toolStripButton9.Click += new System.EventHandler(this.ExportListAsFile);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(6, 33);
            // 
            // toolStripButton5
            // 
            this.toolStripButton5.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton5.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton5.Image")));
            this.toolStripButton5.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton5.Name = "toolStripButton5";
            this.toolStripButton5.Size = new System.Drawing.Size(34, 28);
            this.toolStripButton5.Text = "toolStripButton5";
            this.toolStripButton5.ToolTipText = "Delete";
            this.toolStripButton5.Click += new System.EventHandler(this.Delete);
            // 
            // toolStripButton17
            // 
            this.toolStripButton17.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton17.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton17.Image")));
            this.toolStripButton17.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton17.Name = "toolStripButton17";
            this.toolStripButton17.Size = new System.Drawing.Size(34, 28);
            this.toolStripButton17.Text = "toolStripButton17";
            this.toolStripButton17.ToolTipText = "Rename selected files using tag";
            this.toolStripButton17.Click += new System.EventHandler(this.RenameFilesUsingTag);
            // 
            // toolStripSeparator26
            // 
            this.toolStripSeparator26.Name = "toolStripSeparator26";
            this.toolStripSeparator26.Size = new System.Drawing.Size(6, 33);
            // 
            // toolStripButton13
            // 
            this.toolStripButton13.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton13.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton13.Image")));
            this.toolStripButton13.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton13.Name = "toolStripButton13";
            this.toolStripButton13.Size = new System.Drawing.Size(34, 28);
            this.toolStripButton13.Text = "toolStripButton13";
            this.toolStripButton13.ToolTipText = "Full edit id3v1";
            this.toolStripButton13.Click += new System.EventHandler(this.FullEditId3v1);
            // 
            // toolStripButton10
            // 
            this.toolStripButton10.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton10.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton10.Image")));
            this.toolStripButton10.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton10.Name = "toolStripButton10";
            this.toolStripButton10.Size = new System.Drawing.Size(34, 28);
            this.toolStripButton10.Text = "toolStripButton10";
            this.toolStripButton10.ToolTipText = "Full edit Id3v2 for selected file(s) in the list";
            this.toolStripButton10.Click += new System.EventHandler(this.FullEditId3v2);
            // 
            // toolStripButton14
            // 
            this.toolStripButton14.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton14.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton14.Image")));
            this.toolStripButton14.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton14.Name = "toolStripButton14";
            this.toolStripButton14.Size = new System.Drawing.Size(34, 28);
            this.toolStripButton14.Text = "toolStripButton14";
            this.toolStripButton14.ToolTipText = "Clear id3v1";
            this.toolStripButton14.Click += new System.EventHandler(this.ClearV1);
            // 
            // toolStripButton15
            // 
            this.toolStripButton15.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton15.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton15.Image")));
            this.toolStripButton15.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton15.Name = "toolStripButton15";
            this.toolStripButton15.Size = new System.Drawing.Size(34, 28);
            this.toolStripButton15.Text = "toolStripButton15";
            this.toolStripButton15.ToolTipText = "Clear id3v2";
            this.toolStripButton15.Click += new System.EventHandler(this.ClearV2);
            // 
            // toolStripSeparator24
            // 
            this.toolStripSeparator24.Name = "toolStripSeparator24";
            this.toolStripSeparator24.Size = new System.Drawing.Size(6, 33);
            // 
            // toolStripButton16
            // 
            this.toolStripButton16.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton16.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton16.Image")));
            this.toolStripButton16.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton16.Name = "toolStripButton16";
            this.toolStripButton16.Size = new System.Drawing.Size(34, 28);
            this.toolStripButton16.Text = "toolStripButton16";
            this.toolStripButton16.ToolTipText = "Tag explorer";
            this.toolStripButton16.Click += new System.EventHandler(this.OpenWithTagExplorer);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 33);
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton1.Image")));
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(34, 28);
            this.toolStripButton1.Text = "toolStripButton1";
            this.toolStripButton1.ToolTipText = "View help";
            this.toolStripButton1.Click += new System.EventHandler(this.viewhelpToolStripMenuItem_Click);
            // 
            // contextMenuStrip_folders
            // 
            this.contextMenuStrip_folders.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.contextMenuStrip_folders.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addFolderToolStripMenuItem,
            this.toolStripSeparator9,
            this.refreshToolStripMenuItem,
            this.toolStripSeparator14,
            this.deleteToolStripMenuItem1,
            this.toolStripSeparator27,
            this.extractTagContentToolStripMenuItem1});
            this.contextMenuStrip_folders.Name = "contextMenuStrip_folders";
            this.contextMenuStrip_folders.Size = new System.Drawing.Size(241, 150);
            this.contextMenuStrip_folders.Opening += new System.ComponentModel.CancelEventHandler(this.contextMenuStrip_folders_Opening);
            // 
            // addFolderToolStripMenuItem
            // 
            this.addFolderToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("addFolderToolStripMenuItem.Image")));
            this.addFolderToolStripMenuItem.Name = "addFolderToolStripMenuItem";
            this.addFolderToolStripMenuItem.Size = new System.Drawing.Size(240, 32);
            this.addFolderToolStripMenuItem.Text = "Add folder";
            this.addFolderToolStripMenuItem.Click += new System.EventHandler(this.AddFolder);
            // 
            // toolStripSeparator9
            // 
            this.toolStripSeparator9.Name = "toolStripSeparator9";
            this.toolStripSeparator9.Size = new System.Drawing.Size(237, 6);
            // 
            // refreshToolStripMenuItem
            // 
            this.refreshToolStripMenuItem.Name = "refreshToolStripMenuItem";
            this.refreshToolStripMenuItem.Size = new System.Drawing.Size(240, 32);
            this.refreshToolStripMenuItem.Text = "&Refresh";
            this.refreshToolStripMenuItem.Click += new System.EventHandler(this.refreshToolStripMenuItem_Click);
            // 
            // toolStripSeparator14
            // 
            this.toolStripSeparator14.Name = "toolStripSeparator14";
            this.toolStripSeparator14.Size = new System.Drawing.Size(237, 6);
            // 
            // deleteToolStripMenuItem1
            // 
            this.deleteToolStripMenuItem1.Image = ((System.Drawing.Image)(resources.GetObject("deleteToolStripMenuItem1.Image")));
            this.deleteToolStripMenuItem1.Name = "deleteToolStripMenuItem1";
            this.deleteToolStripMenuItem1.Size = new System.Drawing.Size(240, 32);
            this.deleteToolStripMenuItem1.Text = "Delete";
            this.deleteToolStripMenuItem1.Click += new System.EventHandler(this.Delete);
            // 
            // toolStripSeparator27
            // 
            this.toolStripSeparator27.Name = "toolStripSeparator27";
            this.toolStripSeparator27.Size = new System.Drawing.Size(237, 6);
            // 
            // extractTagContentToolStripMenuItem1
            // 
            this.extractTagContentToolStripMenuItem1.Name = "extractTagContentToolStripMenuItem1";
            this.extractTagContentToolStripMenuItem1.Size = new System.Drawing.Size(240, 32);
            this.extractTagContentToolStripMenuItem1.Text = "Extract tag content";
            this.extractTagContentToolStripMenuItem1.Click += new System.EventHandler(this.extractTagFolderinFoldersToolStripMenuItem_Click);
            // 
            // contextMenuStrip_lists
            // 
            this.contextMenuStrip_lists.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.contextMenuStrip_lists.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addFromFileToolStripMenuItem,
            this.toolStripSeparator19,
            this.createListToolStripMenuItem1,
            this.exportAsFileToolStripMenuItem,
            this.toolStripSeparator11,
            this.deleteToolStripMenuItem2});
            this.contextMenuStrip_lists.Name = "contextMenuStrip_lists";
            this.contextMenuStrip_lists.Size = new System.Drawing.Size(199, 144);
            // 
            // addFromFileToolStripMenuItem
            // 
            this.addFromFileToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("addFromFileToolStripMenuItem.Image")));
            this.addFromFileToolStripMenuItem.Name = "addFromFileToolStripMenuItem";
            this.addFromFileToolStripMenuItem.Size = new System.Drawing.Size(198, 32);
            this.addFromFileToolStripMenuItem.Text = "Add from file";
            this.addFromFileToolStripMenuItem.Click += new System.EventHandler(this.addFromFileToolStripMenuItem_Click);
            // 
            // toolStripSeparator19
            // 
            this.toolStripSeparator19.Name = "toolStripSeparator19";
            this.toolStripSeparator19.Size = new System.Drawing.Size(195, 6);
            // 
            // createListToolStripMenuItem1
            // 
            this.createListToolStripMenuItem1.Image = ((System.Drawing.Image)(resources.GetObject("createListToolStripMenuItem1.Image")));
            this.createListToolStripMenuItem1.Name = "createListToolStripMenuItem1";
            this.createListToolStripMenuItem1.Size = new System.Drawing.Size(198, 32);
            this.createListToolStripMenuItem1.Text = "Create list";
            this.createListToolStripMenuItem1.Click += new System.EventHandler(this.CreateList);
            // 
            // exportAsFileToolStripMenuItem
            // 
            this.exportAsFileToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("exportAsFileToolStripMenuItem.Image")));
            this.exportAsFileToolStripMenuItem.Name = "exportAsFileToolStripMenuItem";
            this.exportAsFileToolStripMenuItem.Size = new System.Drawing.Size(198, 32);
            this.exportAsFileToolStripMenuItem.Text = "Export as file";
            this.exportAsFileToolStripMenuItem.Click += new System.EventHandler(this.ExportListAsFile);
            // 
            // toolStripSeparator11
            // 
            this.toolStripSeparator11.Name = "toolStripSeparator11";
            this.toolStripSeparator11.Size = new System.Drawing.Size(195, 6);
            // 
            // deleteToolStripMenuItem2
            // 
            this.deleteToolStripMenuItem2.Image = ((System.Drawing.Image)(resources.GetObject("deleteToolStripMenuItem2.Image")));
            this.deleteToolStripMenuItem2.Name = "deleteToolStripMenuItem2";
            this.deleteToolStripMenuItem2.Size = new System.Drawing.Size(198, 32);
            this.deleteToolStripMenuItem2.Text = "Delete";
            this.deleteToolStripMenuItem2.Click += new System.EventHandler(this.Delete);
            // 
            // contextMenuStrip_files
            // 
            this.contextMenuStrip_files.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.contextMenuStrip_files.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addFilesToolStripMenuItem,
            this.addFilesfolderScanToolStripMenuItem,
            this.toolStripSeparator13,
            this.deleteToolStripMenuItem3,
            this.renameUsingTagToolStripMenuItem,
            this.toolStripSeparator15,
            this.fullEditId3v1ToolStripMenuItem1,
            this.fullEditId3v2ToolStripMenuItem1,
            this.toolStripSeparator21,
            this.clearId3v1ToolStripMenuItem1,
            this.clearId3v2ToolStripMenuItem1,
            this.toolStripSeparator23,
            this.tagExplorerToolStripMenuItem1});
            this.contextMenuStrip_files.Name = "contextMenuStrip_files";
            this.contextMenuStrip_files.Size = new System.Drawing.Size(265, 316);
            // 
            // addFilesToolStripMenuItem
            // 
            this.addFilesToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("addFilesToolStripMenuItem.Image")));
            this.addFilesToolStripMenuItem.Name = "addFilesToolStripMenuItem";
            this.addFilesToolStripMenuItem.Size = new System.Drawing.Size(264, 32);
            this.addFilesToolStripMenuItem.Text = "Add files";
            this.addFilesToolStripMenuItem.Click += new System.EventHandler(this.AddFiles);
            // 
            // addFilesfolderScanToolStripMenuItem
            // 
            this.addFilesfolderScanToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("addFilesfolderScanToolStripMenuItem.Image")));
            this.addFilesfolderScanToolStripMenuItem.Name = "addFilesfolderScanToolStripMenuItem";
            this.addFilesfolderScanToolStripMenuItem.Size = new System.Drawing.Size(264, 32);
            this.addFilesfolderScanToolStripMenuItem.Text = "Add files (folder scan)";
            this.addFilesfolderScanToolStripMenuItem.Click += new System.EventHandler(this.AddFilesFolderScan);
            // 
            // toolStripSeparator13
            // 
            this.toolStripSeparator13.Name = "toolStripSeparator13";
            this.toolStripSeparator13.Size = new System.Drawing.Size(261, 6);
            // 
            // deleteToolStripMenuItem3
            // 
            this.deleteToolStripMenuItem3.Image = ((System.Drawing.Image)(resources.GetObject("deleteToolStripMenuItem3.Image")));
            this.deleteToolStripMenuItem3.Name = "deleteToolStripMenuItem3";
            this.deleteToolStripMenuItem3.Size = new System.Drawing.Size(264, 32);
            this.deleteToolStripMenuItem3.Text = "Delete";
            this.deleteToolStripMenuItem3.Click += new System.EventHandler(this.Delete);
            // 
            // renameUsingTagToolStripMenuItem
            // 
            this.renameUsingTagToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("renameUsingTagToolStripMenuItem.Image")));
            this.renameUsingTagToolStripMenuItem.Name = "renameUsingTagToolStripMenuItem";
            this.renameUsingTagToolStripMenuItem.Size = new System.Drawing.Size(264, 32);
            this.renameUsingTagToolStripMenuItem.Text = "Rename using tag";
            this.renameUsingTagToolStripMenuItem.Click += new System.EventHandler(this.RenameFilesUsingTag);
            // 
            // toolStripSeparator15
            // 
            this.toolStripSeparator15.Name = "toolStripSeparator15";
            this.toolStripSeparator15.Size = new System.Drawing.Size(261, 6);
            // 
            // fullEditId3v1ToolStripMenuItem1
            // 
            this.fullEditId3v1ToolStripMenuItem1.Image = ((System.Drawing.Image)(resources.GetObject("fullEditId3v1ToolStripMenuItem1.Image")));
            this.fullEditId3v1ToolStripMenuItem1.Name = "fullEditId3v1ToolStripMenuItem1";
            this.fullEditId3v1ToolStripMenuItem1.Size = new System.Drawing.Size(264, 32);
            this.fullEditId3v1ToolStripMenuItem1.Text = "Full edit id3v1";
            this.fullEditId3v1ToolStripMenuItem1.Click += new System.EventHandler(this.FullEditId3v1);
            // 
            // fullEditId3v2ToolStripMenuItem1
            // 
            this.fullEditId3v2ToolStripMenuItem1.Image = ((System.Drawing.Image)(resources.GetObject("fullEditId3v2ToolStripMenuItem1.Image")));
            this.fullEditId3v2ToolStripMenuItem1.Name = "fullEditId3v2ToolStripMenuItem1";
            this.fullEditId3v2ToolStripMenuItem1.Size = new System.Drawing.Size(264, 32);
            this.fullEditId3v2ToolStripMenuItem1.Text = "Full edit Id3v2";
            this.fullEditId3v2ToolStripMenuItem1.Click += new System.EventHandler(this.FullEditId3v2);
            // 
            // toolStripSeparator21
            // 
            this.toolStripSeparator21.Name = "toolStripSeparator21";
            this.toolStripSeparator21.Size = new System.Drawing.Size(261, 6);
            // 
            // clearId3v1ToolStripMenuItem1
            // 
            this.clearId3v1ToolStripMenuItem1.Image = ((System.Drawing.Image)(resources.GetObject("clearId3v1ToolStripMenuItem1.Image")));
            this.clearId3v1ToolStripMenuItem1.Name = "clearId3v1ToolStripMenuItem1";
            this.clearId3v1ToolStripMenuItem1.Size = new System.Drawing.Size(264, 32);
            this.clearId3v1ToolStripMenuItem1.Text = "Clear id3v1";
            this.clearId3v1ToolStripMenuItem1.ToolTipText = "Clear id3 tag version 1 for selected files";
            this.clearId3v1ToolStripMenuItem1.Click += new System.EventHandler(this.ClearV1);
            // 
            // clearId3v2ToolStripMenuItem1
            // 
            this.clearId3v2ToolStripMenuItem1.Image = ((System.Drawing.Image)(resources.GetObject("clearId3v2ToolStripMenuItem1.Image")));
            this.clearId3v2ToolStripMenuItem1.Name = "clearId3v2ToolStripMenuItem1";
            this.clearId3v2ToolStripMenuItem1.Size = new System.Drawing.Size(264, 32);
            this.clearId3v2ToolStripMenuItem1.Text = "Clear id3v2";
            this.clearId3v2ToolStripMenuItem1.ToolTipText = "Clear id3 tag version 2 for selected files";
            this.clearId3v2ToolStripMenuItem1.Click += new System.EventHandler(this.ClearV2);
            // 
            // toolStripSeparator23
            // 
            this.toolStripSeparator23.Name = "toolStripSeparator23";
            this.toolStripSeparator23.Size = new System.Drawing.Size(261, 6);
            // 
            // tagExplorerToolStripMenuItem1
            // 
            this.tagExplorerToolStripMenuItem1.Image = ((System.Drawing.Image)(resources.GetObject("tagExplorerToolStripMenuItem1.Image")));
            this.tagExplorerToolStripMenuItem1.Name = "tagExplorerToolStripMenuItem1";
            this.tagExplorerToolStripMenuItem1.Size = new System.Drawing.Size(264, 32);
            this.tagExplorerToolStripMenuItem1.Text = "Tag explorer";
            this.tagExplorerToolStripMenuItem1.Click += new System.EventHandler(this.OpenWithTagExplorer);
            // 
            // contextMenuStrip_columns
            // 
            this.contextMenuStrip_columns.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.contextMenuStrip_columns.Name = "contextMenuStrip_columns";
            this.contextMenuStrip_columns.Size = new System.Drawing.Size(61, 4);
            this.contextMenuStrip_columns.Opening += new System.ComponentModel.CancelEventHandler(this.contextMenuStrip_columns_Opening);
            this.contextMenuStrip_columns.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.contextMenuStrip_columns_ItemClicked);
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // Frm_Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1162, 660);
            this.Controls.Add(this.toolStripContainer1);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "Frm_Main";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "AHD ID3 Tag Editor";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Frm_Main_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Frm_Main_FormClosed);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.toolStripContainer1.ContentPanel.ResumeLayout(false);
            this.toolStripContainer1.TopToolStripPanel.ResumeLayout(false);
            this.toolStripContainer1.TopToolStripPanel.PerformLayout();
            this.toolStripContainer1.ResumeLayout(false);
            this.toolStripContainer1.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.splitContainer3.Panel1.ResumeLayout(false);
            this.splitContainer3.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).EndInit();
            this.splitContainer3.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.splitContainer4.Panel1.ResumeLayout(false);
            this.splitContainer4.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer4)).EndInit();
            this.splitContainer4.ResumeLayout(false);
            this.splitContainer5.Panel1.ResumeLayout(false);
            this.splitContainer5.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer5)).EndInit();
            this.splitContainer5.ResumeLayout(false);
            this.toolStrip_main.ResumeLayout(false);
            this.toolStrip_main.PerformLayout();
            this.contextMenuStrip_folders.ResumeLayout(false);
            this.contextMenuStrip_lists.ResumeLayout(false);
            this.contextMenuStrip_files.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem viewhelpToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem aboutAHDID3TagEditorToolStripMenuItem;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel StatusLabel;
        private System.Windows.Forms.ToolStripProgressBar ProgressBar1;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripContainer toolStripContainer1;
        private System.Windows.Forms.ToolStrip toolStrip_main;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.SplitContainer splitContainer3;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.SplitContainer splitContainer4;
        private System.Windows.Forms.SplitContainer splitContainer5;
        private System.Windows.Forms.ToolStripMenuItem viewToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tabsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolbarsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem resetLayoutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveLayoutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem loadLayoutToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.ToolStripMenuItem addToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator6;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator7;
        private System.Windows.Forms.ToolStripMenuItem folderToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem filesToolStripMenuItem;
        private System.Windows.Forms.ToolStripButton toolStripButton2;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deleteToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem filesfolderScanToolStripMenuItem;
        private System.Windows.Forms.ToolStripButton toolStripButton3;
        private System.Windows.Forms.ToolStripButton toolStripButton4;
        private System.Windows.Forms.ToolStripButton toolStripButton5;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripMenuItem saveListToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.ToolStripButton toolStripButton6;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripMenuItem openListToolStripMenuItem;
        private System.Windows.Forms.ToolStripButton toolStripButton7;
        private System.Windows.Forms.ToolStripMenuItem createListToolStripMenuItem;
        private System.Windows.Forms.ToolStripButton toolStripButton8;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip_folders;
        private System.Windows.Forms.ToolStripMenuItem addFolderToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator9;
        private System.Windows.Forms.ToolStripMenuItem deleteToolStripMenuItem1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip_lists;
        private System.Windows.Forms.ToolStripMenuItem createListToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem deleteToolStripMenuItem2;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator11;
        private System.Windows.Forms.ToolStripMenuItem exportAsFileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exportToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator12;
        private System.Windows.Forms.ToolStripButton toolStripButton9;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip_files;
        private System.Windows.Forms.ToolStripMenuItem addFilesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addFilesfolderScanToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator13;
        private System.Windows.Forms.ToolStripMenuItem deleteToolStripMenuItem3;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip_columns;
        private System.Windows.Forms.ToolStripMenuItem columnsToolStripMenuItem;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator10;
        private System.Windows.Forms.ToolStripMenuItem selectAllToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem settingsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem fullEditId3v2ToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator15;
        private System.Windows.Forms.ToolStripMenuItem fullEditId3v2ToolStripMenuItem1;
        private System.Windows.Forms.ToolStripButton toolStripButton10;
        private System.Windows.Forms.ToolStripMenuItem openfilequickEditToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator16;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator8;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator17;
        private System.Windows.Forms.ToolStripButton toolStripButton11;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator18;
        private System.Windows.Forms.ToolStripMenuItem logWindowToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addFromFileToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator19;
        private System.Windows.Forms.ToolStripMenuItem addListFromFileToolStripMenuItem;
        private System.Windows.Forms.ToolStripButton toolStripButton12;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator20;
        private System.Windows.Forms.ToolStripMenuItem clearId3v1ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem clearId3v2ToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator21;
        private System.Windows.Forms.ToolStripMenuItem clearId3v1ToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem clearId3v2ToolStripMenuItem1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator22;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator23;
        private System.Windows.Forms.ToolStripMenuItem tagExplorerToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem fullEditId3v1ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openFilequickEditId3v1ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem fullEditId3v1ToolStripMenuItem1;
        private System.Windows.Forms.ToolStripButton toolStripButton13;
        private System.Windows.Forms.ToolStripButton toolStripButton14;
        private System.Windows.Forms.ToolStripButton toolStripButton15;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator24;
        private System.Windows.Forms.ToolStripButton toolStripButton16;
        private System.Windows.Forms.ToolStripMenuItem renameFileUsingTagToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator25;
        private System.Windows.Forms.ToolStripMenuItem renameUsingTagToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tagExplorerToolStripMenuItem;
        private System.Windows.Forms.ToolStripButton toolStripButton17;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator26;
        private System.Windows.Forms.ToolStripMenuItem refreshToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator14;
        private MTC.ManagedTabControl managedTabControl_topLeft;
        private MTC.ManagedTabControl managedTabControl_downLeft;
        private MTC.ManagedTabControl managedTabControl_topMiddle;
        private MTC.ManagedTabControl managedTabControl_downMiddle;
        private MTC.ManagedTabControl managedTabControl_topRight;
        private MTC.ManagedTabControl managedTabControl_downRight;
        private System.Windows.Forms.ToolStripMenuItem extractTagContentToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem extractTagFolderinFoldersToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator27;
        private System.Windows.Forms.ToolStripMenuItem extractTagContentToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem wikiOnlineHelpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem websiteToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator28;
    }
}

