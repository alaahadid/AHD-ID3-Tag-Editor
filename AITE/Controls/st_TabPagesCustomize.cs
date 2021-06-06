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
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MTC;
namespace AHD.ID3.Editor
{
    public partial class st_TabPagesCustomize : SettingsControl
    {
        public st_TabPagesCustomize()
        {
            InitializeComponent();
            // load preview
            MTCTabPage page = new MTCTabPage("Tab Page", "");
            managedTabControl1.TabPages.Add(page);
            page = new MTCTabPage("Tab Page", "");
            managedTabControl1.TabPages.Add(page);
            page = new MTCTabPage("Tab Page", "");
            managedTabControl1.TabPages.Add(page);

            button_tabPageColor.BackColor = Program.Settings.TabPageColor;
            button_tabPageHighlightColor.BackColor = Program.Settings.TabPageHighlightColor;
            button_tabPageSelectColor.BackColor = Program.Settings.TabPageSelectColor;
            button_tabPageSplitColor.BackColor = Program.Settings.TabPageSplitcolor;
            button_tabPageTextColor.BackColor = Program.Settings.TabPageTextColor;
            RefreshPreview();
        }
        private void RefreshPreview()
        {
            managedTabControl1.TabPageColor = button_tabPageColor.BackColor;
            managedTabControl1.TabPageHighlightedColor = button_tabPageHighlightColor.BackColor;
            managedTabControl1.TabPageSelectedColor = button_tabPageSelectColor.BackColor;
            managedTabControl1.TabPageSplitColor = button_tabPageSplitColor.BackColor;
            managedTabControl1.ForeColor = button_tabPageTextColor.BackColor;
        }
        public override string ToString()
        {
            return "Tab pages style";
        }
        public override void SaveSettings()
        {
            Program.Settings.TabPageColor = button_tabPageColor.BackColor;
            Program.Settings.TabPageHighlightColor = button_tabPageHighlightColor.BackColor;
            Program.Settings.TabPageSelectColor = button_tabPageSelectColor.BackColor;
            Program.Settings.TabPageSplitcolor = button_tabPageSplitColor.BackColor;
            Program.Settings.TabPageTextColor = button_tabPageTextColor.BackColor;
        }
        public override void DefaultSettings()
        {
            button_tabPageColor.BackColor = Color.Silver;
            button_tabPageHighlightColor.BackColor = Color.LightGoldenrodYellow;
            button_tabPageSelectColor.BackColor = Color.White;
            button_tabPageSplitColor.BackColor = Color.LightGray;
            button_tabPageTextColor.BackColor = Color.Black;
            RefreshPreview();
        }

        private void button_tabPageColor_Click(object sender, EventArgs e)
        {
            ColorDialog frm = new ColorDialog();
            frm.Color = ((Button)sender).BackColor;
            if (frm.ShowDialog(this) == DialogResult.OK)
            {
                ((Button)sender).BackColor = frm.Color;
                RefreshPreview();
            }
        }
    }
}
