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

namespace AHD.ID3.Editor.GUI
{
    public partial class ComboBoxControl : UserControl
    {
        public ComboBoxControl()
        {
            InitializeComponent();
        }
        public string PropertyName
        { get { return label1.Text; } set { label1.Text = value; } }
        public string PropertyValue
        { get { return comboBox1.Text; } set { comboBox1.Text = value; } }
        /// <summary>
        /// Get the compobox collection
        /// </summary>
        public ComboBox.ObjectCollection Items
        { get { return comboBox1.Items; } }

        public bool LinkVisible
        { get { return linkLabel1.Visible; } set { linkLabel1.Visible = value; } }
        public string LinkValue
        {
            get { return linkLabel1.Text; }
            set
            {
                linkLabel1.Text = value;
                linkLabel1.Location = new Point(this.Width - linkLabel1.Width - 6, linkLabel1.Location.Y);
            }
        }
        public string LinkTooltip
        {
            get { return toolTip1.GetToolTip(linkLabel1); }
            set { toolTip1.SetToolTip(linkLabel1, value); }
        }

        public event EventHandler<LinkLabelLinkClickedEventArgs> LinkClicked;

        private void CompoBoxControl_Resize(object sender, EventArgs e)
        {
            this.comboBox1.Width = this.Width - 6;
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (LinkClicked != null)
                LinkClicked(this, e);
        }
    }
}
