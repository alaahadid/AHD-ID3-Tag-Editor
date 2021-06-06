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
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Reflection;
using AHD.ID3.Editor.Base;
using AHD.ID3.MIME;

namespace AHD.ID3.Editor
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        /// <param name="Args">The command lines</param>
        [STAThread]
        static void Main(string[] Args)
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // We need to install frames here for one time.
            FramesManager.InstallFrames();
            MimeManager.Refresh();

            //show splash and load things
            Frm_StartUp startUp = new Frm_StartUp(Args);
            startUp.Show();

            //run !!
            Application.Run();
        }

        private static Properties.Settings settings = new Properties.Settings();
        private static Frm_Main frmMain;
        private static BDatabaseManager manager;

        public static string Version
        {
            get { return Assembly.GetExecutingAssembly().GetName().Version.ToString(); }
        }
        public static Properties.Settings Settings
        { get { return settings; } }
        public static Frm_Main MainForm
        { get { return frmMain; } set { frmMain = value; } }
        public static BDatabaseManager DatabaseManager
        { get { return manager; } set { manager = value; } }
        public static void LoadID3V2Settings()
        {
            ID3TagSettings.DropExtendedHeader = settings.ID3V2_DropExtendedHeader;
            ID3TagSettings.ID3V2Version = settings.DefaultID3V2Version;
            ID3TagSettings.KeepPadding = settings.ID3V2_KeepPadding;
            ID3TagSettings.UseUnsynchronisation = settings.ID3V2_UseUnsynchronisation;
            ID3TagSettings.WriteFooter = settings.ID3V2_WriteFooter;
        }
    }
}