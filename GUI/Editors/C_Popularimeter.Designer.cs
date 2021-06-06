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
    partial class C_Popularimeter
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(C_Popularimeter));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton2 = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButton3 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton4 = new System.Windows.Forms.ToolStripButton();
            this.ComboBox_frames = new System.Windows.Forms.ToolStripComboBox();
            this.Label1 = new System.Windows.Forms.ToolStripLabel();
            this.textEditorControl_email = new AHD.ID3.Editor.GUI.TextEditorControl();
            this.numberControl_rating = new AHD.ID3.Editor.GUI.NumberControl();
            this.numberControl_counter = new AHD.ID3.Editor.GUI.NumberControl();
            this.ratingControl1 = new AHD.ID3.Editor.GUI.RatingControl();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButton1,
            this.toolStripButton2,
            this.toolStripSeparator1,
            this.toolStripButton3,
            this.toolStripButton4,
            this.ComboBox_frames,
            this.Label1});
            this.toolStrip1.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.Flow;
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(404, 23);
            this.toolStrip1.TabIndex = 3;
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
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 23);
            // 
            // toolStripButton3
            // 
            this.toolStripButton3.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton3.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton3.Image")));
            this.toolStripButton3.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton3.Name = "toolStripButton3";
            this.toolStripButton3.Size = new System.Drawing.Size(23, 20);
            this.toolStripButton3.Text = "toolStripButton3";
            this.toolStripButton3.ToolTipText = "Add popularimeter frame";
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
            this.toolStripButton4.Click += new System.EventHandler(this.RemoveSelected);
            // 
            // ComboBox_frames
            // 
            this.ComboBox_frames.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ComboBox_frames.Name = "ComboBox_frames";
            this.ComboBox_frames.Size = new System.Drawing.Size(200, 23);
            this.ComboBox_frames.ToolTipText = "Popularimeter frames";
            this.ComboBox_frames.SelectedIndexChanged += new System.EventHandler(this.ComboBox_frames_SelectedIndexChanged);
            // 
            // Label1
            // 
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(0, 0);
            // 
            // textEditorControl_email
            // 
            this.textEditorControl_email.Dock = System.Windows.Forms.DockStyle.Top;
            this.textEditorControl_email.LinkTooltip = "";
            this.textEditorControl_email.LinkValue = "linkLabel1";
            this.textEditorControl_email.LinkVisible = false;
            this.textEditorControl_email.Location = new System.Drawing.Point(0, 23);
            this.textEditorControl_email.MaximumCharsCount = 32767;
            this.textEditorControl_email.Name = "textEditorControl_email";
            this.textEditorControl_email.PropertyName = "E-mail:";
            this.textEditorControl_email.PropertyValue = "";
            this.textEditorControl_email.Size = new System.Drawing.Size(404, 39);
            this.textEditorControl_email.TabIndex = 5;
            // 
            // numberControl_rating
            // 
            this.numberControl_rating.Dock = System.Windows.Forms.DockStyle.Top;
            this.numberControl_rating.LinkTooltip = "";
            this.numberControl_rating.LinkValue = "linkLabel1";
            this.numberControl_rating.LinkVisible = false;
            this.numberControl_rating.Location = new System.Drawing.Point(0, 101);
            this.numberControl_rating.MaximumNumber = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.numberControl_rating.MinimumNumber = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.numberControl_rating.Name = "numberControl_rating";
            this.numberControl_rating.PropertyName = "Rating value (0-255):";
            this.numberControl_rating.PropertyValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.numberControl_rating.Size = new System.Drawing.Size(404, 39);
            this.numberControl_rating.TabIndex = 6;
            // 
            // numberControl_counter
            // 
            this.numberControl_counter.Dock = System.Windows.Forms.DockStyle.Top;
            this.numberControl_counter.LinkTooltip = "";
            this.numberControl_counter.LinkValue = "linkLabel1";
            this.numberControl_counter.LinkVisible = false;
            this.numberControl_counter.Location = new System.Drawing.Point(0, 62);
            this.numberControl_counter.MaximumNumber = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.numberControl_counter.MinimumNumber = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.numberControl_counter.Name = "numberControl_counter";
            this.numberControl_counter.PropertyName = "Counter:";
            this.numberControl_counter.PropertyValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.numberControl_counter.Size = new System.Drawing.Size(404, 39);
            this.numberControl_counter.TabIndex = 7;
            // 
            // ratingControl1
            // 
            this.ratingControl1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ratingControl1.Location = new System.Drawing.Point(3, 148);
            this.ratingControl1.Name = "ratingControl1";
            this.ratingControl1.Rating = 0;
            this.ratingControl1.Size = new System.Drawing.Size(116, 24);
            this.ratingControl1.TabIndex = 8;
            this.ratingControl1.RatingChanged += new System.EventHandler(this.ratingControl1_RatingChanged);
            // 
            // C_Popularimeter
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.ratingControl1);
            this.Controls.Add(this.numberControl_rating);
            this.Controls.Add(this.numberControl_counter);
            this.Controls.Add(this.textEditorControl_email);
            this.Controls.Add(this.toolStrip1);
            this.Name = "C_Popularimeter";
            this.Size = new System.Drawing.Size(404, 378);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton toolStripButton3;
        private System.Windows.Forms.ToolStripButton toolStripButton4;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
        private System.Windows.Forms.ToolStripButton toolStripButton2;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripLabel Label1;
        private TextEditorControl textEditorControl_email;
        private NumberControl numberControl_rating;
        private NumberControl numberControl_counter;
        private RatingControl ratingControl1;
        private System.Windows.Forms.ToolStripComboBox ComboBox_frames;
    }
}
