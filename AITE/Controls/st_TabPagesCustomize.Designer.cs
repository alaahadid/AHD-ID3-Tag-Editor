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
    partial class st_TabPagesCustomize
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
            this.button_tabPageColor = new System.Windows.Forms.Button();
            this.button_tabPageHighlightColor = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.button_tabPageSelectColor = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.button_tabPageSplitColor = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.managedTabControl1 = new MTC.ManagedTabControl();
            this.button_tabPageTextColor = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(82, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Tab page color:";
            // 
            // button_tabPageColor
            // 
            this.button_tabPageColor.BackColor = System.Drawing.Color.Silver;
            this.button_tabPageColor.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_tabPageColor.Location = new System.Drawing.Point(134, 3);
            this.button_tabPageColor.Name = "button_tabPageColor";
            this.button_tabPageColor.Size = new System.Drawing.Size(128, 23);
            this.button_tabPageColor.TabIndex = 1;
            this.button_tabPageColor.UseVisualStyleBackColor = false;
            this.button_tabPageColor.Click += new System.EventHandler(this.button_tabPageColor_Click);
            // 
            // button_tabPageHighlightColor
            // 
            this.button_tabPageHighlightColor.BackColor = System.Drawing.Color.Silver;
            this.button_tabPageHighlightColor.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_tabPageHighlightColor.Location = new System.Drawing.Point(134, 32);
            this.button_tabPageHighlightColor.Name = "button_tabPageHighlightColor";
            this.button_tabPageHighlightColor.Size = new System.Drawing.Size(128, 23);
            this.button_tabPageHighlightColor.TabIndex = 3;
            this.button_tabPageHighlightColor.UseVisualStyleBackColor = false;
            this.button_tabPageHighlightColor.Click += new System.EventHandler(this.button_tabPageColor_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 37);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(125, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Tab page highlight color:";
            // 
            // button_tabPageSelectColor
            // 
            this.button_tabPageSelectColor.BackColor = System.Drawing.Color.Silver;
            this.button_tabPageSelectColor.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_tabPageSelectColor.Location = new System.Drawing.Point(134, 61);
            this.button_tabPageSelectColor.Name = "button_tabPageSelectColor";
            this.button_tabPageSelectColor.Size = new System.Drawing.Size(128, 23);
            this.button_tabPageSelectColor.TabIndex = 5;
            this.button_tabPageSelectColor.UseVisualStyleBackColor = false;
            this.button_tabPageSelectColor.Click += new System.EventHandler(this.button_tabPageColor_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 66);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(113, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Tab page select color:";
            // 
            // button_tabPageSplitColor
            // 
            this.button_tabPageSplitColor.BackColor = System.Drawing.Color.Silver;
            this.button_tabPageSplitColor.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_tabPageSplitColor.Location = new System.Drawing.Point(134, 90);
            this.button_tabPageSplitColor.Name = "button_tabPageSplitColor";
            this.button_tabPageSplitColor.Size = new System.Drawing.Size(128, 23);
            this.button_tabPageSplitColor.TabIndex = 7;
            this.button_tabPageSplitColor.UseVisualStyleBackColor = false;
            this.button_tabPageSplitColor.Click += new System.EventHandler(this.button_tabPageColor_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(3, 95);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(104, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Tab page split color:";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.managedTabControl1);
            this.groupBox1.Location = new System.Drawing.Point(6, 148);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(256, 61);
            this.groupBox1.TabIndex = 8;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Preview";
            // 
            // managedTabControl1
            // 
            this.managedTabControl1.AllowAutoTabPageDragAndDrop = true;
            this.managedTabControl1.AllowTabPageDragAndDrop = true;
            this.managedTabControl1.AllowTabPagesReorder = true;
            this.managedTabControl1.AutoSelectAddedTabPageAfterAddingIt = false;
            this.managedTabControl1.CloseBoxAlwaysVisible = false;
            this.managedTabControl1.CloseBoxOnEachPageVisible = true;
            this.managedTabControl1.CloseTabOnCloseButtonClick = true;
            this.managedTabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.managedTabControl1.DrawStyle = MTC.MTCDrawStyle.Normal;
            this.managedTabControl1.DrawTabPageHighlight = true;
            this.managedTabControl1.Location = new System.Drawing.Point(3, 16);
            this.managedTabControl1.Name = "managedTabControl1";
            this.managedTabControl1.SelectedTabPageIndex = 0;
            this.managedTabControl1.ShowTabPageToolTip = true;
            this.managedTabControl1.ShowTabPageToolTipAlways = false;
            this.managedTabControl1.Size = new System.Drawing.Size(250, 42);
            this.managedTabControl1.TabIndex = 0;
            this.managedTabControl1.TabPageColor = System.Drawing.Color.Silver;
            this.managedTabControl1.TabPageHighlightedColor = System.Drawing.Color.LightBlue;
            this.managedTabControl1.TabPageMaxWidth = 250;
            this.managedTabControl1.TabPageSelectedColor = System.Drawing.Color.SkyBlue;
            this.managedTabControl1.TabPageSplitColor = System.Drawing.Color.Gray;
            // 
            // button_tabPageTextColor
            // 
            this.button_tabPageTextColor.BackColor = System.Drawing.Color.Silver;
            this.button_tabPageTextColor.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_tabPageTextColor.Location = new System.Drawing.Point(134, 119);
            this.button_tabPageTextColor.Name = "button_tabPageTextColor";
            this.button_tabPageTextColor.Size = new System.Drawing.Size(128, 23);
            this.button_tabPageTextColor.TabIndex = 10;
            this.button_tabPageTextColor.UseVisualStyleBackColor = false;
            this.button_tabPageTextColor.Click += new System.EventHandler(this.button_tabPageColor_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(3, 124);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(105, 13);
            this.label5.TabIndex = 9;
            this.label5.Text = "Tab page text color:";
            // 
            // st_TabPagesCustomize
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.button_tabPageTextColor);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.button_tabPageSplitColor);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.button_tabPageSelectColor);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.button_tabPageHighlightColor);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.button_tabPageColor);
            this.Controls.Add(this.label1);
            this.Name = "st_TabPagesCustomize";
            this.Size = new System.Drawing.Size(275, 215);
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button_tabPageColor;
        private System.Windows.Forms.Button button_tabPageHighlightColor;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button_tabPageSelectColor;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button button_tabPageSplitColor;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.GroupBox groupBox1;
        private MTC.ManagedTabControl managedTabControl1;
        private System.Windows.Forms.Button button_tabPageTextColor;
        private System.Windows.Forms.Label label5;
    }
}
