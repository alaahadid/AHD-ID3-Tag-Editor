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
namespace AHD.ID3.Editor.GUI
{
    partial class C_TagExplorer
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.toolStripButton_delete = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton_save = new System.Windows.Forms.ToolStripButton();
            this.managedListView1 = new MLV.ManagedListView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.checkBox_footer = new System.Windows.Forms.CheckBox();
            this.checkBox_compression = new System.Windows.Forms.CheckBox();
            this.checkBox_experimental = new System.Windows.Forms.CheckBox();
            this.checkBox_unsynchronisation = new System.Windows.Forms.CheckBox();
            this.checkBox_extenderHeaderPresented = new System.Windows.Forms.CheckBox();
            this.textBox_tagVersion = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox_tagSize = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStrip1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripLabel1,
            this.toolStripButton_delete,
            this.toolStripButton_save});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(320, 25);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(0, 22);
            // 
            // toolStripButton_delete
            // 
            this.toolStripButton_delete.Image = global::AHD.ID3.Editor.GUI.Properties.Resources.cross;
            this.toolStripButton_delete.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton_delete.Name = "toolStripButton_delete";
            this.toolStripButton_delete.Size = new System.Drawing.Size(60, 22);
            this.toolStripButton_delete.Text = "Delete";
            this.toolStripButton_delete.ToolTipText = "Delete selected frames.";
            this.toolStripButton_delete.Click += new System.EventHandler(this.toolStripButton_delete_Click);
            // 
            // toolStripButton_save
            // 
            this.toolStripButton_save.Image = global::AHD.ID3.Editor.GUI.Properties.Resources.disk;
            this.toolStripButton_save.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton_save.Name = "toolStripButton_save";
            this.toolStripButton_save.Size = new System.Drawing.Size(51, 22);
            this.toolStripButton_save.Text = "Save";
            this.toolStripButton_save.ToolTipText = "Save changes";
            this.toolStripButton_save.Click += new System.EventHandler(this.toolStripButton_save_Click);
            // 
            // managedListView1
            // 
            this.managedListView1.AllowColumnsReorder = false;
            this.managedListView1.AllowItemsDragAndDrop = false;
            this.managedListView1.AutoSetWheelScrollSpeed = true;
            this.managedListView1.BackgroundRenderMode = MLV.ManagedListViewBackgroundRenderMode.NormalStretchNoAspectRatio;
            this.managedListView1.ChangeColumnSortModeWhenClick = false;
            this.managedListView1.ColumnClickColor = System.Drawing.Color.PaleVioletRed;
            this.managedListView1.ColumnColor = System.Drawing.Color.Silver;
            this.managedListView1.ColumnHighlightColor = System.Drawing.Color.LightSkyBlue;
            this.managedListView1.ContextMenuStrip = this.contextMenuStrip1;
            this.managedListView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.managedListView1.DrawHighlight = true;
            this.managedListView1.ItemHighlightColor = System.Drawing.Color.LightSkyBlue;
            this.managedListView1.ItemMouseOverColor = System.Drawing.Color.LightGray;
            this.managedListView1.ItemSpecialColor = System.Drawing.Color.YellowGreen;
            this.managedListView1.Location = new System.Drawing.Point(0, 25);
            this.managedListView1.Name = "managedListView1";
            this.managedListView1.ShowSubItemToolTip = true;
            this.managedListView1.Size = new System.Drawing.Size(320, 249);
            this.managedListView1.StretchThumbnailsToFit = false;
            this.managedListView1.TabIndex = 1;
            this.managedListView1.ThunmbnailsHeight = 36;
            this.managedListView1.ThunmbnailsWidth = 36;
            this.managedListView1.ViewMode = MLV.ManagedListViewViewMode.Details;
            this.managedListView1.WheelScrollSpeed = 19;
            this.managedListView1.ColumnClicked += new System.EventHandler<MLV.ManagedListViewColumnClickArgs>(this.managedListView1_ColumnClicked);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.checkBox_footer);
            this.panel1.Controls.Add(this.checkBox_compression);
            this.panel1.Controls.Add(this.checkBox_experimental);
            this.panel1.Controls.Add(this.checkBox_unsynchronisation);
            this.panel1.Controls.Add(this.checkBox_extenderHeaderPresented);
            this.panel1.Controls.Add(this.textBox_tagVersion);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.textBox_tagSize);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 274);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(320, 104);
            this.panel1.TabIndex = 2;
            // 
            // checkBox_footer
            // 
            this.checkBox_footer.AutoSize = true;
            this.checkBox_footer.Enabled = false;
            this.checkBox_footer.Location = new System.Drawing.Point(183, 55);
            this.checkBox_footer.Name = "checkBox_footer";
            this.checkBox_footer.Size = new System.Drawing.Size(58, 17);
            this.checkBox_footer.TabIndex = 8;
            this.checkBox_footer.Text = "Footer";
            this.checkBox_footer.UseVisualStyleBackColor = true;
            // 
            // checkBox_compression
            // 
            this.checkBox_compression.AutoSize = true;
            this.checkBox_compression.Enabled = false;
            this.checkBox_compression.Location = new System.Drawing.Point(183, 32);
            this.checkBox_compression.Name = "checkBox_compression";
            this.checkBox_compression.Size = new System.Drawing.Size(87, 17);
            this.checkBox_compression.TabIndex = 7;
            this.checkBox_compression.Text = "Compression";
            this.checkBox_compression.UseVisualStyleBackColor = true;
            // 
            // checkBox_experimental
            // 
            this.checkBox_experimental.AutoSize = true;
            this.checkBox_experimental.Enabled = false;
            this.checkBox_experimental.Location = new System.Drawing.Point(3, 78);
            this.checkBox_experimental.Name = "checkBox_experimental";
            this.checkBox_experimental.Size = new System.Drawing.Size(88, 17);
            this.checkBox_experimental.TabIndex = 6;
            this.checkBox_experimental.Text = "Experimental";
            this.checkBox_experimental.UseVisualStyleBackColor = true;
            // 
            // checkBox_unsynchronisation
            // 
            this.checkBox_unsynchronisation.AutoSize = true;
            this.checkBox_unsynchronisation.Enabled = false;
            this.checkBox_unsynchronisation.Location = new System.Drawing.Point(3, 55);
            this.checkBox_unsynchronisation.Name = "checkBox_unsynchronisation";
            this.checkBox_unsynchronisation.Size = new System.Drawing.Size(114, 17);
            this.checkBox_unsynchronisation.TabIndex = 5;
            this.checkBox_unsynchronisation.Text = "Unsynchronisation";
            this.checkBox_unsynchronisation.UseVisualStyleBackColor = true;
            // 
            // checkBox_extenderHeaderPresented
            // 
            this.checkBox_extenderHeaderPresented.AutoSize = true;
            this.checkBox_extenderHeaderPresented.Enabled = false;
            this.checkBox_extenderHeaderPresented.Location = new System.Drawing.Point(3, 32);
            this.checkBox_extenderHeaderPresented.Name = "checkBox_extenderHeaderPresented";
            this.checkBox_extenderHeaderPresented.Size = new System.Drawing.Size(159, 17);
            this.checkBox_extenderHeaderPresented.TabIndex = 4;
            this.checkBox_extenderHeaderPresented.Text = "Extender header presented";
            this.checkBox_extenderHeaderPresented.UseVisualStyleBackColor = true;
            // 
            // textBox_tagVersion
            // 
            this.textBox_tagVersion.Location = new System.Drawing.Point(55, 6);
            this.textBox_tagVersion.Name = "textBox_tagVersion";
            this.textBox_tagVersion.ReadOnly = true;
            this.textBox_tagVersion.Size = new System.Drawing.Size(66, 20);
            this.textBox_tagVersion.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(46, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Version:";
            // 
            // textBox_tagSize
            // 
            this.textBox_tagSize.Location = new System.Drawing.Point(183, 6);
            this.textBox_tagSize.Name = "textBox_tagSize";
            this.textBox_tagSize.ReadOnly = true;
            this.textBox_tagSize.Size = new System.Drawing.Size(66, 20);
            this.textBox_tagSize.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(127, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(50, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Tag size:";
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.deleteToolStripMenuItem,
            this.saveToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(108, 48);
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Image = global::AHD.ID3.Editor.GUI.Properties.Resources.disk;
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(107, 22);
            this.saveToolStripMenuItem.Text = "Save";
            this.saveToolStripMenuItem.Click += new System.EventHandler(this.toolStripButton_save_Click);
            // 
            // deleteToolStripMenuItem
            // 
            this.deleteToolStripMenuItem.Image = global::AHD.ID3.Editor.GUI.Properties.Resources.cross;
            this.deleteToolStripMenuItem.Name = "deleteToolStripMenuItem";
            this.deleteToolStripMenuItem.Size = new System.Drawing.Size(107, 22);
            this.deleteToolStripMenuItem.Text = "Delete";
            this.deleteToolStripMenuItem.Click += new System.EventHandler(this.toolStripButton_delete_Click);
            // 
            // C_TagExplorer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.managedListView1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.toolStrip1);
            this.Name = "C_TagExplorer";
            this.Size = new System.Drawing.Size(320, 378);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private MLV.ManagedListView managedListView1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox textBox_tagVersion;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox_tagSize;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox checkBox_extenderHeaderPresented;
        private System.Windows.Forms.CheckBox checkBox_unsynchronisation;
        private System.Windows.Forms.CheckBox checkBox_experimental;
        private System.Windows.Forms.CheckBox checkBox_compression;
        private System.Windows.Forms.CheckBox checkBox_footer;
        private System.Windows.Forms.ToolStripButton toolStripButton_delete;
        private System.Windows.Forms.ToolStripButton toolStripButton_save;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem deleteToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
    }
}
