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
using System.Text;
using System.Threading.Tasks;

namespace AHD.ID3.Editor
{
    /// <summary>
    /// The layout present
    /// </summary>
    [Serializable()]
    public class LayoutPresent
    {
        private string name = "";
        private List<ControlPage> pages = new List<ControlPage>();
        private List<ToolBar> bars = new List<ToolBar>();

        /// <summary>
        /// Get or set the layout name
        /// </summary>
        public string Name
        { get { return name; } set { name = value; } }
        /// <summary>
        /// Get or set the pages collection
        /// </summary>
        public List<ControlPage> Pages
        { get { return pages; } set { pages = value; } }
        /// <summary>
        /// Get or set the toolbars collection
        /// </summary>
        public List<ToolBar> ToolBars
        { get { return bars; } set { bars = value; } }
        /// <summary>
        /// Build the default layout present.
        /// </summary>
        public void BuildDefaultLayout()
        {
            pages = new List<ControlPage>();

            ControlPage page = new ControlPage();
            page.Location = ControlLocation.TopMiddle;
            page.Name = "Files list";
            page.Type = ControlType.FilesBrowser;
            page.Visible = true;
            pages.Add(page);

            page = new ControlPage();
            page.Location = ControlLocation.TopLeft;
            page.Name = "Favorite Folders";
            page.Type = ControlType.FoldersBrowser;
            page.Visible = true;
            pages.Add(page);

            page = new ControlPage();
            page.Location = ControlLocation.DownLeft;
            page.Name = "Lists";
            page.Type = ControlType.ListsBrowser;
            page.Visible = true;
            pages.Add(page);

            page = new ControlPage();
            page.Location = ControlLocation.DownLeft;
            page.Name = "Log";
            page.Type = ControlType.Log;
            page.Visible = true;
            pages.Add(page);

            page = new ControlPage();
            page.Location = ControlLocation.TopRight;
            page.Name = "Quick edit V2";
            page.Type = ControlType.QuickEditorV2;
            page.Visible = true;
            pages.Add(page);

            page = new ControlPage();
            page.Location = ControlLocation.TopRight;
            page.Name = "Quick edit V1";
            page.Type = ControlType.QuickEditorV1;
            page.Visible = true;
            pages.Add(page);

            page = new ControlPage();
            page.Location = ControlLocation.DownMiddle;
            page.Name = "Media player";
            page.Type = ControlType.MediaPlayer;
            page.Visible = true;
            pages.Add(page);

            page = new ControlPage();
            page.Location = ControlLocation.DownMiddle;
            page.Name = "Pictures";
            page.Type = ControlType.ImagesManager;
            page.Visible = true;
            pages.Add(page);

            page = new ControlPage();
            page.Location = ControlLocation.DownMiddle;
            page.Name = "Unsynchronized lyrics";
            page.Type = ControlType.UnsychronisedLyrics;
            page.Visible = true;
            pages.Add(page);

            page = new ControlPage();
            page.Location = ControlLocation.DownMiddle;
            page.Name = "All text frames";
            page.Type = ControlType.AllTextFrames;
            page.Visible = false;
            pages.Add(page);

            page = new ControlPage();
            page.Location = ControlLocation.DownMiddle;
            page.Name = "URL Link frames";
            page.Type = ControlType.URLLinkFrames;
            page.Visible = false;
            pages.Add(page);

            page = new ControlPage();
            page.Location = ControlLocation.DownMiddle;
            page.Name = "Comments";
            page.Type = ControlType.CommentsEditor;
            page.Visible = false;
            pages.Add(page);

            page = new ControlPage();
            page.Location = ControlLocation.DownMiddle;
            page.Name = "Popularimeter (rating)";
            page.Type = ControlType.Popularimeter;
            page.Visible = false;
            pages.Add(page);

            page = new ControlPage();
            page.Location = ControlLocation.DownMiddle;
            page.Name = "Involved people list";
            page.Type = ControlType.InvolvedPeopleList;
            page.Visible = false;
            pages.Add(page);

            page = new ControlPage();
            page.Location = ControlLocation.DownMiddle;
            page.Name = "Unique file identifier";
            page.Type = ControlType.UniqueFileIdentifier;
            page.Visible = false;
            pages.Add(page);

            page = new ControlPage();
            page.Location = ControlLocation.DownMiddle;
            page.Name = "Music CD identifier";
            page.Type = ControlType.MusicCDIdentifier;
            page.Visible = false;
            pages.Add(page);

            page = new ControlPage();
            page.Location = ControlLocation.DownMiddle;
            page.Name = "General encapsulated object (attached files)";
            page.Type = ControlType.GeneralEncapsulatedObject;
            page.Visible = false;
            pages.Add(page);

            page = new ControlPage();
            page.Location = ControlLocation.TopRight;
            page.Name = "Commercial";
            page.Type = ControlType.Commercial;
            page.Visible = false;
            pages.Add(page);

            page = new ControlPage();
            page.Location = ControlLocation.DownMiddle;
            page.Name = "Play counter";
            page.Type = ControlType.PlayCounter;
            page.Visible = false;
            pages.Add(page);

            page = new ControlPage();
            page.Location = ControlLocation.DownMiddle;
            page.Name = "Event timing codes";
            page.Type = ControlType.EventTimingCodes;
            page.Visible = false;
            pages.Add(page);

            page = new ControlPage();
            page.Location = ControlLocation.TopRight;
            page.Name = "Synchronized lyrics";
            page.Type = ControlType.SynchronisedLyrics;
            page.Visible = false;
            pages.Add(page);

            page = new ControlPage();
            page.Location = ControlLocation.DownMiddle;
            page.Name = "Terms of use";
            page.Type = ControlType.TermsOfUseFrame;
            page.Visible = false;
            pages.Add(page);

            page = new ControlPage();
            page.Location = ControlLocation.TopRight;
            page.Name = "Tag explorer";
            page.Type = ControlType.TagExplorer;
            page.Visible = true;
            pages.Add(page);

            //toolbars
            bars = new List<ToolBar>();

            ToolBar bar = new ToolBar();
            bar.Location = ToolBarLocation.Top;
            bar.Name = "Main";
            bar.Position = new System.Drawing.Point(0, 0);
            bar.Type = ToolBarType.Main;
            bar.Visible = true;
            bars.Add(bar);
        }
    }
}
