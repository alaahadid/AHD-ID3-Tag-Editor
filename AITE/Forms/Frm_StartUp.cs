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
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AHD.ID3;

namespace AHD.ID3.Editor
{
    public partial class Frm_StartUp : Form
    {
        public Frm_StartUp(string[] Args)
        {
            InitializeComponent();
            label_version.Text = "Version " + Program.Version; 
            this.Args = Args;
        }

        private string[] Args;

        private void Frm_StartUp_Shown(object sender, EventArgs e)
        {
            timer1.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Stop();
            // Load settings
            Program.Settings.Reload();
            // First run ?
            if (!Program.Settings.FirstRun)
            {
                Program.Settings.FirstRun = true;
                Program.Settings.DefaultLayout = new LayoutPresent();
                Program.Settings.DefaultLayout.BuildDefaultLayout();

                Program.Settings.ColumnsManager = new Base.ColumnsManager();
                Program.Settings.ColumnsManager.BuildDefaultCollection();
            }
            // Apply settings for id3v2 
            Program.LoadID3V2Settings();
            // Load database
            Program.DatabaseManager = new Base.BDatabaseManager();
            System.IO.Directory.CreateDirectory(System.Environment.GetFolderPath(System.Environment.SpecialFolder.MyDocuments) + "\\AITE\\");
            Program.DatabaseManager.FilePath = 
                System.Environment.GetFolderPath(System.Environment.SpecialFolder.MyDocuments) + "\\AITE\\folders.aite";
            Program.DatabaseManager.Load();

            // Main form
            Program.MainForm = new Frm_Main(Args);
            Program.MainForm.Show();

            Close();
        }

        private void Frm_StartUp_Load(object sender, EventArgs e)
        {

        }
    }
}
