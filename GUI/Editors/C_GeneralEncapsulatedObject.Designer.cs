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
    partial class C_GeneralEncapsulatedObject
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(C_GeneralEncapsulatedObject));
            this.textEditorControl_contentDescriptor = new AHD.ID3.Editor.GUI.TextEditorControl();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton2 = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButton3 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton4 = new System.Windows.Forms.ToolStripButton();
            this.ComboBox_frames = new System.Windows.Forms.ToolStripComboBox();
            this.Label1 = new System.Windows.Forms.ToolStripLabel();
            this.textEditorControl_fileName = new AHD.ID3.Editor.GUI.TextEditorControl();
            this.label_fileInfo = new System.Windows.Forms.Label();
            this.label_icon = new System.Windows.Forms.Label();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // textEditorControl_contentDescriptor
            // 
            this.textEditorControl_contentDescriptor.Dock = System.Windows.Forms.DockStyle.Top;
            this.textEditorControl_contentDescriptor.LinkTooltip = "";
            this.textEditorControl_contentDescriptor.LinkValue = "linkLabel1";
            this.textEditorControl_contentDescriptor.LinkVisible = false;
            this.textEditorControl_contentDescriptor.Location = new System.Drawing.Point(0, 23);
            this.textEditorControl_contentDescriptor.MaximumCharsCount = 32767;
            this.textEditorControl_contentDescriptor.Name = "textEditorControl_contentDescriptor";
            this.textEditorControl_contentDescriptor.PropertyName = "Content descriptor:";
            this.textEditorControl_contentDescriptor.PropertyValue = "";
            this.textEditorControl_contentDescriptor.Size = new System.Drawing.Size(359, 39);
            this.textEditorControl_contentDescriptor.TabIndex = 5;
            // 
            // toolStrip1
            // 
            this.toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButton1,
            this.toolStripButton2,
            this.toolStripSeparator2,
            this.toolStripButton3,
            this.toolStripButton4,
            this.ComboBox_frames,
            this.Label1});
            this.toolStrip1.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.Flow;
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(359, 23);
            this.toolStrip1.TabIndex = 4;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton1.Image")));
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(23, 20);
            this.toolStripButton1.Text = "toolStripButton1";
            this.toolStripButton1.ToolTipText = "Save changes to file.";
            this.toolStripButton1.Click += new System.EventHandler(this.SaveChanges);
            // 
            // toolStripButton2
            // 
            this.toolStripButton2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton2.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton2.Image")));
            this.toolStripButton2.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton2.Name = "toolStripButton2";
            this.toolStripButton2.Size = new System.Drawing.Size(23, 20);
            this.toolStripButton2.Text = "toolStripButton2";
            this.toolStripButton2.ToolTipText = "Reload";
            this.toolStripButton2.Click += new System.EventHandler(this.ReloadFrames);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 23);
            // 
            // toolStripButton3
            // 
            this.toolStripButton3.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton3.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton3.Image")));
            this.toolStripButton3.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton3.Name = "toolStripButton3";
            this.toolStripButton3.Size = new System.Drawing.Size(23, 20);
            this.toolStripButton3.Text = "toolStripButton3";
            this.toolStripButton3.ToolTipText = "Add general encapsulated object frame";
            this.toolStripButton3.Click += new System.EventHandler(this.AddFrame);
            // 
            // toolStripButton4
            // 
            this.toolStripButton4.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton4.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton4.Image")));
            this.toolStripButton4.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton4.Name = "toolStripButton4";
            this.toolStripButton4.Size = new System.Drawing.Size(23, 20);
            this.toolStripButton4.Text = "toolStripButton4";
            this.toolStripButton4.ToolTipText = "Remove selected frame";
            this.toolStripButton4.Click += new System.EventHandler(this.RemoveFrame);
            // 
            // ComboBox_frames
            // 
            this.ComboBox_frames.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ComboBox_frames.Name = "ComboBox_frames";
            this.ComboBox_frames.Size = new System.Drawing.Size(200, 23);
            this.ComboBox_frames.ToolTipText = "General Encapsulated Object frames";
            this.ComboBox_frames.SelectedIndexChanged += new System.EventHandler(this.ComboBox_frames_SelectedIndexChanged);
            // 
            // Label1
            // 
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(0, 0);
            // 
            // textEditorControl_fileName
            // 
            this.textEditorControl_fileName.Dock = System.Windows.Forms.DockStyle.Top;
            this.textEditorControl_fileName.LinkTooltip = "";
            this.textEditorControl_fileName.LinkValue = "linkLabel1";
            this.textEditorControl_fileName.LinkVisible = false;
            this.textEditorControl_fileName.Location = new System.Drawing.Point(0, 62);
            this.textEditorControl_fileName.MaximumCharsCount = 32767;
            this.textEditorControl_fileName.Name = "textEditorControl_fileName";
            this.textEditorControl_fileName.PropertyName = "File name:";
            this.textEditorControl_fileName.PropertyValue = "";
            this.textEditorControl_fileName.Size = new System.Drawing.Size(359, 39);
            this.textEditorControl_fileName.TabIndex = 6;
            // 
            // label_fileInfo
            // 
            this.label_fileInfo.AutoSize = true;
            this.label_fileInfo.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label_fileInfo.Location = new System.Drawing.Point(46, 113);
            this.label_fileInfo.Name = "label_fileInfo";
            this.label_fileInfo.Size = new System.Drawing.Size(63, 26);
            this.label_fileInfo.TabIndex = 8;
            this.label_fileInfo.Text = "Size = 0 KB\r\nMIME = null";
            this.label_fileInfo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label_icon
            // 
            this.label_icon.Image = global::AHD.ID3.Editor.GUI.Properties.Resources.File_unkown;
            this.label_icon.Location = new System.Drawing.Point(3, 104);
            this.label_icon.Name = "label_icon";
            this.label_icon.Size = new System.Drawing.Size(37, 42);
            this.label_icon.TabIndex = 9;
            // 
            // C_GeneralEncapsulatedObject
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.label_icon);
            this.Controls.Add(this.label_fileInfo);
            this.Controls.Add(this.textEditorControl_fileName);
            this.Controls.Add(this.textEditorControl_contentDescriptor);
            this.Controls.Add(this.toolStrip1);
            this.Name = "C_GeneralEncapsulatedObject";
            this.Size = new System.Drawing.Size(359, 337);
            this.DragDrop += new System.Windows.Forms.DragEventHandler(this.C_GeneralEncapsulatedObject_DragDrop);
            this.DragEnter += new System.Windows.Forms.DragEventHandler(this.C_GeneralEncapsulatedObject_DragEnter);
            this.DragOver += new System.Windows.Forms.DragEventHandler(this.C_GeneralEncapsulatedObject_DragOver);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private TextEditorControl textEditorControl_contentDescriptor;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
        private System.Windows.Forms.ToolStripButton toolStripButton2;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton toolStripButton3;
        private System.Windows.Forms.ToolStripButton toolStripButton4;
        private System.Windows.Forms.ToolStripComboBox ComboBox_frames;
        private System.Windows.Forms.ToolStripLabel Label1;
        private TextEditorControl textEditorControl_fileName;
        private System.Windows.Forms.Label label_fileInfo;
        private System.Windows.Forms.Label label_icon;
    }
}
