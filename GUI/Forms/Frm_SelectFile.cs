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
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AHD.ID3.Editor.Base;

namespace AHD.ID3.Editor.GUI
{
    public partial class Frm_SelectFile : Form
    {
        public Frm_SelectFile(string[] files)
        {
            InitializeComponent();

            // add files browser
            ColumnsManager manager = new ColumnsManager();
            manager.BuildDefaultCollection();
            foreach (ColumnItem cl in manager.Columns)
            {
                if (cl.ColumnID == "rating")
                {
                    cl.Visible = false;
                    break;
                }
            }
            browser = new C_FilesBrowser(manager);

            browser.RefreshFiles(files);

            browser.SelectedFilesChanged += browser_SelectedFilesChanged;

            browser.Parent = this;
            browser.Dock = DockStyle.Fill;
            browser.BringToFront();
        }

        void browser_SelectedFilesChanged(object sender, EventArgs e)
        {
            button1.Enabled = browser.SelectedFilesCount == 1;
        }
        private C_FilesBrowser browser;

        public string SelectedFile
        { get { return browser.GetSelectedFiles()[0]; } }

        private void button1_Click(object sender, EventArgs e)
        {
            if (browser.SelectedFilesCount != 1)
            {
                MessageBox.Show("Please select one file first.");
                return;
            }
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
            Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
