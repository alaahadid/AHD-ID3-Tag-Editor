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
    partial class st_ID3V2
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(st_ID3V2));
            this.label1 = new System.Windows.Forms.Label();
            this.comboBox_tagVersion = new System.Windows.Forms.ComboBox();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.checkBox_unsynchronisation = new System.Windows.Forms.CheckBox();
            this.checkBox_footer = new System.Windows.Forms.CheckBox();
            this.checkBox_dropExtendedHeader = new System.Windows.Forms.CheckBox();
            this.checkBox_keepPadding = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 6);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(118, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Default Tag version: 2.";
            // 
            // comboBox_tagVersion
            // 
            this.comboBox_tagVersion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_tagVersion.FormattingEnabled = true;
            this.comboBox_tagVersion.Location = new System.Drawing.Point(119, 3);
            this.comboBox_tagVersion.Name = "comboBox_tagVersion";
            this.comboBox_tagVersion.Size = new System.Drawing.Size(42, 21);
            this.comboBox_tagVersion.TabIndex = 1;
            this.toolTip1.SetToolTip(this.comboBox_tagVersion, resources.GetString("comboBox_tagVersion.ToolTip"));
            // 
            // checkBox_unsynchronisation
            // 
            this.checkBox_unsynchronisation.AutoSize = true;
            this.checkBox_unsynchronisation.Location = new System.Drawing.Point(3, 46);
            this.checkBox_unsynchronisation.Name = "checkBox_unsynchronisation";
            this.checkBox_unsynchronisation.Size = new System.Drawing.Size(259, 17);
            this.checkBox_unsynchronisation.TabIndex = 2;
            this.checkBox_unsynchronisation.Text = "Use &unsynchronisation (All ID3 Tag versions 2.x)";
            this.toolTip1.SetToolTip(this.checkBox_unsynchronisation, "To use \'unsynchronisation scheme\' in saving id3 tag data.\r\nSee http://id3.org/id3" +
        "v2.3.0 for more information (or version2/3 page).");
            this.checkBox_unsynchronisation.UseVisualStyleBackColor = true;
            // 
            // checkBox_footer
            // 
            this.checkBox_footer.AutoSize = true;
            this.checkBox_footer.Location = new System.Drawing.Point(3, 115);
            this.checkBox_footer.Name = "checkBox_footer";
            this.checkBox_footer.Size = new System.Drawing.Size(218, 17);
            this.checkBox_footer.TabIndex = 3;
            this.checkBox_footer.Text = "Write &footer. (ID3 Tag version 2.4 only)";
            this.toolTip1.SetToolTip(this.checkBox_footer, "Write the footer.");
            this.checkBox_footer.UseVisualStyleBackColor = true;
            // 
            // checkBox_dropExtendedHeader
            // 
            this.checkBox_dropExtendedHeader.AutoSize = true;
            this.checkBox_dropExtendedHeader.Location = new System.Drawing.Point(3, 92);
            this.checkBox_dropExtendedHeader.Name = "checkBox_dropExtendedHeader";
            this.checkBox_dropExtendedHeader.Size = new System.Drawing.Size(281, 17);
            this.checkBox_dropExtendedHeader.TabIndex = 4;
            this.checkBox_dropExtendedHeader.Text = "Drop &extended header (ID3 Tag version 2.3 and 2.4)";
            this.toolTip1.SetToolTip(this.checkBox_dropExtendedHeader, "If extended header is presented when loading id3 tag v2\r\nfrom file, drop the exte" +
        "nded header hance i\'t optional \r\nwhen saving that file.");
            this.checkBox_dropExtendedHeader.UseVisualStyleBackColor = true;
            // 
            // checkBox_keepPadding
            // 
            this.checkBox_keepPadding.AutoSize = true;
            this.checkBox_keepPadding.Location = new System.Drawing.Point(3, 69);
            this.checkBox_keepPadding.Name = "checkBox_keepPadding";
            this.checkBox_keepPadding.Size = new System.Drawing.Size(216, 17);
            this.checkBox_keepPadding.TabIndex = 5;
            this.checkBox_keepPadding.Text = "&Keep padding (All ID3 Tag versions 2.x)";
            this.toolTip1.SetToolTip(this.checkBox_keepPadding, "If a loaded id3 tag v2 from file include padding, keep the\r\nsame padding when sav" +
        "ing.");
            this.checkBox_keepPadding.UseVisualStyleBackColor = true;
            // 
            // st_ID3V2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.checkBox_keepPadding);
            this.Controls.Add(this.checkBox_dropExtendedHeader);
            this.Controls.Add(this.checkBox_footer);
            this.Controls.Add(this.checkBox_unsynchronisation);
            this.Controls.Add(this.comboBox_tagVersion);
            this.Controls.Add(this.label1);
            this.Name = "st_ID3V2";
            this.Size = new System.Drawing.Size(297, 157);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboBox_tagVersion;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.CheckBox checkBox_unsynchronisation;
        private System.Windows.Forms.CheckBox checkBox_footer;
        private System.Windows.Forms.CheckBox checkBox_dropExtendedHeader;
        private System.Windows.Forms.CheckBox checkBox_keepPadding;
    }
}
