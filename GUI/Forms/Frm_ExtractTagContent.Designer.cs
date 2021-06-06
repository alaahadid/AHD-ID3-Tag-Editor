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
    partial class Frm_ExtractTagContent
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
            this.checkBox_extractAttachedPictures = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox_folder = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.checkBox_GeneralEncapsulatedObject = new System.Windows.Forms.CheckBox();
            this.checkBox_ExtractUnsychronisedLyrics = new System.Windows.Forms.CheckBox();
            this.button_start = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.checkBox_includeSubFolders = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // checkBox_extractAttachedPictures
            // 
            this.checkBox_extractAttachedPictures.AutoSize = true;
            this.checkBox_extractAttachedPictures.Checked = true;
            this.checkBox_extractAttachedPictures.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox_extractAttachedPictures.Location = new System.Drawing.Point(12, 74);
            this.checkBox_extractAttachedPictures.Name = "checkBox_extractAttachedPictures";
            this.checkBox_extractAttachedPictures.Size = new System.Drawing.Size(148, 17);
            this.checkBox_extractAttachedPictures.TabIndex = 0;
            this.checkBox_extractAttachedPictures.Text = "Extract attached pictures";
            this.checkBox_extractAttachedPictures.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(110, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Extract to this folder:";
            // 
            // textBox_folder
            // 
            this.textBox_folder.Location = new System.Drawing.Point(12, 25);
            this.textBox_folder.Name = "textBox_folder";
            this.textBox_folder.ReadOnly = true;
            this.textBox_folder.Size = new System.Drawing.Size(353, 20);
            this.textBox_folder.TabIndex = 2;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(371, 23);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(49, 23);
            this.button1.TabIndex = 3;
            this.button1.Text = "...";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // checkBox_GeneralEncapsulatedObject
            // 
            this.checkBox_GeneralEncapsulatedObject.AutoSize = true;
            this.checkBox_GeneralEncapsulatedObject.Location = new System.Drawing.Point(12, 97);
            this.checkBox_GeneralEncapsulatedObject.Name = "checkBox_GeneralEncapsulatedObject";
            this.checkBox_GeneralEncapsulatedObject.Size = new System.Drawing.Size(235, 17);
            this.checkBox_GeneralEncapsulatedObject.TabIndex = 4;
            this.checkBox_GeneralEncapsulatedObject.Text = "Extract general encapsulated objects (files)";
            this.checkBox_GeneralEncapsulatedObject.UseVisualStyleBackColor = true;
            // 
            // checkBox_ExtractUnsychronisedLyrics
            // 
            this.checkBox_ExtractUnsychronisedLyrics.AutoSize = true;
            this.checkBox_ExtractUnsychronisedLyrics.Location = new System.Drawing.Point(12, 120);
            this.checkBox_ExtractUnsychronisedLyrics.Name = "checkBox_ExtractUnsychronisedLyrics";
            this.checkBox_ExtractUnsychronisedLyrics.Size = new System.Drawing.Size(219, 17);
            this.checkBox_ExtractUnsychronisedLyrics.TabIndex = 5;
            this.checkBox_ExtractUnsychronisedLyrics.Text = "Extract unsychronised lyrics as text files";
            this.checkBox_ExtractUnsychronisedLyrics.UseVisualStyleBackColor = true;
            // 
            // button_start
            // 
            this.button_start.Location = new System.Drawing.Point(345, 168);
            this.button_start.Name = "button_start";
            this.button_start.Size = new System.Drawing.Size(75, 23);
            this.button_start.TabIndex = 6;
            this.button_start.Text = "&Start";
            this.button_start.UseVisualStyleBackColor = true;
            this.button_start.Click += new System.EventHandler(this.button_start_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(264, 168);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 9;
            this.button2.Text = "&Cancel";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // checkBox_includeSubFolders
            // 
            this.checkBox_includeSubFolders.AutoSize = true;
            this.checkBox_includeSubFolders.Location = new System.Drawing.Point(12, 51);
            this.checkBox_includeSubFolders.Name = "checkBox_includeSubFolders";
            this.checkBox_includeSubFolders.Size = new System.Drawing.Size(117, 17);
            this.checkBox_includeSubFolders.TabIndex = 10;
            this.checkBox_includeSubFolders.Text = "Include sub folders";
            this.checkBox_includeSubFolders.UseVisualStyleBackColor = true;
            // 
            // Frm_ExtractTagContent
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(432, 203);
            this.Controls.Add(this.checkBox_includeSubFolders);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button_start);
            this.Controls.Add(this.checkBox_ExtractUnsychronisedLyrics);
            this.Controls.Add(this.checkBox_GeneralEncapsulatedObject);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.textBox_folder);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.checkBox_extractAttachedPictures);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Frm_ExtractTagContent";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Extract Tag Content";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Frm_ExtractTagContent_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox checkBox_extractAttachedPictures;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox_folder;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.CheckBox checkBox_GeneralEncapsulatedObject;
        private System.Windows.Forms.CheckBox checkBox_ExtractUnsychronisedLyrics;
        private System.Windows.Forms.Button button_start;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.CheckBox checkBox_includeSubFolders;
    }
}