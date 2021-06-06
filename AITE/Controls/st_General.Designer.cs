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
    partial class st_General
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
            this.label1 = new System.Windows.Forms.Label();
            this.comboBox_doubleClickAction = new System.Windows.Forms.ComboBox();
            this.checkBox_mediaPlayerAutostart = new System.Windows.Forms.CheckBox();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(204, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "When I double-click on file in the files list:";
            // 
            // comboBox_doubleClickAction
            // 
            this.comboBox_doubleClickAction.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_doubleClickAction.FormattingEnabled = true;
            this.comboBox_doubleClickAction.Items.AddRange(new object[] {
            "Do nothnig...",
            "Full edit ID3 Tag v1",
            "Full edit ID3 Tag v2",
            "Open file",
            "Play in media player",
            "Locate file in disk"});
            this.comboBox_doubleClickAction.Location = new System.Drawing.Point(3, 16);
            this.comboBox_doubleClickAction.Name = "comboBox_doubleClickAction";
            this.comboBox_doubleClickAction.Size = new System.Drawing.Size(202, 21);
            this.comboBox_doubleClickAction.TabIndex = 1;
            // 
            // checkBox_mediaPlayerAutostart
            // 
            this.checkBox_mediaPlayerAutostart.AutoSize = true;
            this.checkBox_mediaPlayerAutostart.Location = new System.Drawing.Point(3, 53);
            this.checkBox_mediaPlayerAutostart.Name = "checkBox_mediaPlayerAutostart";
            this.checkBox_mediaPlayerAutostart.Size = new System.Drawing.Size(138, 17);
            this.checkBox_mediaPlayerAutostart.TabIndex = 2;
            this.checkBox_mediaPlayerAutostart.Text = "&Media player auto start";
            this.toolTip1.SetToolTip(this.checkBox_mediaPlayerAutostart, "When checked, the media player control (if visible)\r\nwill auto play the selected " +
        "file.");
            this.checkBox_mediaPlayerAutostart.UseVisualStyleBackColor = true;
            // 
            // st_General
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.checkBox_mediaPlayerAutostart);
            this.Controls.Add(this.comboBox_doubleClickAction);
            this.Controls.Add(this.label1);
            this.Name = "st_General";
            this.Size = new System.Drawing.Size(229, 86);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboBox_doubleClickAction;
        private System.Windows.Forms.CheckBox checkBox_mediaPlayerAutostart;
        private System.Windows.Forms.ToolTip toolTip1;
    }
}
