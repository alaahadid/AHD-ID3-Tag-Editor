/* This file is part of AHD ID3 Tag Editor (AITE)
 * A program that edit and create ID3 Tag.
 *
 * Copyright © Ala Ibrahim Hadid 2009 - 2015
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
using AHD.ID3;
using AHD.ID3.Types;
using AHD.ID3.Frames;
using AHD.ID3.Editor.Base;
namespace AHD.ID3.Editor.GUI
{
    public partial class EventTimingCodesPanel : Control
    {
        public EventTimingCodesPanel()
        {
            InitializeComponent();
            ControlStyles flag = ControlStyles.OptimizedDoubleBuffer | ControlStyles.AllPaintingInWmPaint;
            this.SetStyle(flag, true);

            stringFormat = new StringFormat(StringFormatFlags.NoWrap);
            stringFormat.Trimming = StringTrimming.EllipsisWord;
        }
        EventTimingCodesFrame frame;
        double mediaDuration = 0;
        public double MediaDuration
        {
            get { return mediaDuration; }
            set
            {
                mediaDuration = value;
                ViewPortOffset = 0;
            }
        }
        public EventTimingCodesFrame EventTimingCodesFrame
        {
            get { return frame; }
            set
            {
                frame = value;
            }
        }
        public Color MediaRectangleColor = Color.MediumAquamarine;
        public Color MediaHeaderRectangleColor = Color.MediumSeaGreen;
        public bool isScrolling = false;
        bool moveTimeMode = false;
        bool moveItemMode = false;
        int itemToMove = 0;
        bool showStatus = false;
        private StringFormat stringFormat = new StringFormat();
        public event EventHandler<TimeChangedArgs> TimeChangeRequest;
        public event EventHandler<TimeChangedArgs> ItemTimeChanged;
        public bool CanAutoScroll = false;
        #region Drawing Values
        public Color TickColor = Color.White;
        public int TimeSpace = 1000;//the pixels of time space
        public int ViewPortOffset = 0;//the pixel of viewport, view port is the panel_timeline width
        public int MilliPixel = 10;//how milli each pixel presents
        public string MediaText = "Media";
        double currentTime = 0;
        public double CurrentTime
        {
            get { return currentTime; }
            set
            {
                if (!isScrolling)
                    currentTime = value;
                if (CanAutoScroll)
                {
                    int mediaDx = GetPixelOftime(currentTime);
                    if (mediaDx >= ViewPortOffset && mediaDx > 0)
                    {
                        if (mediaDx - ViewPortOffset > this.Width)
                        {
                            ViewPortOffset = mediaDx;
                        }
                    }
                }
            }
        }
        #endregion
        /// <summary>
        /// Calculate time using pixel
        /// </summary>
        /// <param name="x">The pixel to calculate time for, this pixel should be the real pixel of time space, not from view port</param>
        /// <returns>The time in Sec.Milli format</returns>
        double GetTime(int x)
        {
            double tas = TimeSpace * MilliPixel;
            double milli = (x * tas) / TimeSpace;
            return milli / 1000;
        }
        int GetPixelOftime(double time)
        {
            double tas = TimeSpace * MilliPixel;
            return (int)(((time * 1000) * TimeSpace) / tas);
        }
        string To_TimeSpan_Milli(double time)
        {
            string returnValue = TimeSpan.FromSeconds(time).ToString().Substring(0, 8);
            int milli = TimeSpan.FromSeconds(time).Milliseconds;
            returnValue += "." + milli.ToString("D3").Substring(0, 3);
            return returnValue;
        }

        protected override void OnPaint(PaintEventArgs pe)
        {
            base.OnPaint(pe);

            Graphics gr = pe.Graphics;

            //calculate tick space
            int ticPixels = (1000 / MilliPixel);
            ticPixels = ((ticPixels % 10) + 10);
            int secPixels = ticPixels * 10;
            //Draw ticks
            for (int x = 0; x < this.Width; x++)
            {
                //calculate which pixel we are at in the TimeSpace
                int pix = ViewPortOffset + x;
                //each ticksSpace pixels, draw small tick
                if (pix % ticPixels == 0)
                {
                    gr.DrawLine(new Pen(new SolidBrush(TickColor), 2), x, 25, x, 30);
                }
                //each secPixels pixels, draw big tick and time
                if (pix % secPixels == 0)
                {
                    gr.DrawLine(new Pen(new SolidBrush(TickColor), 2), x, 20, x, 30);
                    //calculate the time of this pixel
                    string time = To_TimeSpan_Milli(GetTime(pix));
                    gr.DrawString(time, new Font("Tahoma", 8, FontStyle.Regular),
                         new SolidBrush(TickColor), new PointF(x - 32, 5), stringFormat);
                }
            }
            // draw media
            int mediaDx = GetPixelOftime(mediaDuration);
            if (mediaDx >= ViewPortOffset && mediaDx > 0)
            {
                if (mediaDx - ViewPortOffset < this.Width)
                {
                    pe.Graphics.FillRectangle(new SolidBrush(MediaRectangleColor), 0, 30, mediaDx - ViewPortOffset,
                        40);
                    pe.Graphics.FillRectangle(new SolidBrush(MediaHeaderRectangleColor), 0, 30, mediaDx - ViewPortOffset, 15);
                    //draw string
                    pe.Graphics.DrawString(MediaText,
                               new Font("Tahoma", 8, FontStyle.Regular), new SolidBrush(Color.Black),
                               new RectangleF(0, 30, mediaDx - ViewPortOffset, 13), stringFormat);
                    pe.Graphics.DrawRectangle(new Pen(new SolidBrush(Color.Black)),
                        new Rectangle((ViewPortOffset == 0) ? 0 : -1, 30, mediaDx - ViewPortOffset,
                        40));
                }
                else
                {
                    pe.Graphics.FillRectangle(new SolidBrush(MediaRectangleColor), 0, 30, this.Width,
                          40);
                    pe.Graphics.FillRectangle(new SolidBrush(MediaHeaderRectangleColor), 0, 30, this.Width, 15);
                    //draw string
                    pe.Graphics.DrawString(MediaText,
                               new Font("Tahoma", 8, FontStyle.Regular), new SolidBrush(Color.Black),
                               new RectangleF(0, 30, this.Width, 13), stringFormat);
                    pe.Graphics.DrawRectangle(new Pen(new SolidBrush(Color.Black)),
                        new Rectangle((ViewPortOffset == 0) ? 0 : -1, 30, this.Width + 1,
                          40));
                }
            }
            //draw items
            if (frame != null)
            {
                foreach (EventTimingItem item in frame.Items)
                {
                    int x = GetPixelOftime((double)item.Time / 1000);
                    if (x > ViewPortOffset + this.Width)
                        break;
                    if (x >= ViewPortOffset)
                    {
                        gr.DrawLine(new Pen(new SolidBrush(Color.White)), x - ViewPortOffset, 15, x - ViewPortOffset,
                            this.Height);
                    }
                }
            }
            //Draw time line
            int timeX = GetPixelOftime(currentTime);
            string timeText = To_TimeSpan_Milli(GetTime(timeX));
            if (timeX >= ViewPortOffset)
            {
                timeX -= ViewPortOffset;
                gr.DrawLine(new Pen(new SolidBrush(Color.Blue)),
                    timeX, 15, timeX, this.Height);
                if (showStatus && moveTimeMode)
                {
                    gr.FillRectangle(new SolidBrush(Color.Blue),
                        new Rectangle(timeX - 32, 5, 69, 15));
                    gr.DrawString(timeText, new Font("Tahoma", 8, FontStyle.Regular),
                         new SolidBrush(TickColor), new PointF(timeX - 32, 5), stringFormat);
                }
            }
            //draw item move status
            if (showStatus && moveItemMode)
            {
                timeX = GetPixelOftime((double)frame.Items[itemToMove].Time / 1000);
                timeX -= ViewPortOffset;
                string tooltip = To_TimeSpan_Milli((double)frame.Items[itemToMove].Time / 1000);
                tooltip += ":\n" + ID3FrameConsts.GetEventTimingEvent(frame.Items[itemToMove].EventType);
                Size size = TextRenderer.MeasureText(tooltip, new Font("Tahoma", 8, FontStyle.Regular));

                gr.FillRectangle(new SolidBrush(Color.White),
                   new Rectangle(timeX - 35, 5, size.Width, size.Height));
                gr.DrawString(tooltip, new Font("Tahoma", 8, FontStyle.Regular),
                     new SolidBrush(Color.Black), new PointF(timeX - 35, 5), stringFormat);
            }
        }
        protected override void OnPaintBackground(PaintEventArgs pevent)
        {
            base.OnPaintBackground(pevent);
            pevent.Graphics.FillRectangle(new SolidBrush(Color.LightSteelBlue),
                 new Rectangle(0, 0, this.Width, this.Height));
            pevent.Graphics.FillRectangle(new SolidBrush(Color.LightSlateGray),
         new Rectangle(0, 0, this.Width, 30));
        }
        protected override void OnMouseClick(MouseEventArgs e)
        {
            base.OnMouseClick(e);
            if (!moveTimeMode && !moveItemMode)
            {
                if (TimeChangeRequest != null)
                    TimeChangeRequest(this, new TimeChangedArgs(0, GetTime(e.X + ViewPortOffset)));
            }
        }
        protected override void OnMouseUp(MouseEventArgs e)
        {
            base.OnMouseUp(e);
            if (moveTimeMode)
            {
                if (TimeChangeRequest != null)
                    TimeChangeRequest(this, new TimeChangedArgs(0, GetTime(e.X + ViewPortOffset)));
            }
            if (moveItemMode)
            {
                if (ItemTimeChanged != null)
                    ItemTimeChanged(this, new TimeChangedArgs(0, (double)frame.Items[itemToMove].Time / 1000));
            }
            isScrolling = false;
        }
        protected override void OnMouseMove(MouseEventArgs e)
        {
            base.OnMouseMove(e);
            if (e.Button == System.Windows.Forms.MouseButtons.Left)
            {
                isScrolling = moveTimeMode;
                if (moveTimeMode)
                {
                    currentTime = GetTime(e.X + ViewPortOffset);
                }
                else if (moveItemMode)
                {
                    frame.Items[itemToMove].Time = (int)(GetTime(e.X + ViewPortOffset) * 1000);
                }
            }
            else
            {
                //time
                int timeX = GetPixelOftime(currentTime) - ViewPortOffset;
                int max = timeX + 3;
                int min = timeX - 3;

                if (min <= e.X && e.X <= max)
                {
                    showStatus = moveTimeMode = true;
                    Cursor = Cursors.VSplit;
                    return;
                }
                //item !
                if (frame != null)
                {
                    int i = 0;
                    foreach (EventTimingItem item in frame.Items)
                    {
                        int x = GetPixelOftime((double)item.Time / 1000);
                        if (x > ViewPortOffset + this.Width)
                            break;
                        max = x - ViewPortOffset + 3;
                        min = x - ViewPortOffset - 3;
                        if (min <= e.X && e.X <= max)
                        {
                            showStatus = moveItemMode = true;
                            itemToMove = i;
                            Cursor = Cursors.SizeWE;
                            return;
                        }
                        i++;
                    }
                }
                Cursor = Cursors.Default;
                moveTimeMode = moveItemMode = showStatus = false;
                itemToMove = -1;
            }
        }
    }
}
