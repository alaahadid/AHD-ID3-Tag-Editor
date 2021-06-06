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
using System.Drawing;
using System.Windows.Forms;
using AHD.ID3;
namespace AHD.ID3.Editor.GUI
{
    public partial class LogPanel : Control
    {
        public LogPanel()
        {
            InitializeComponent();

            ControlStyles flag = ControlStyles.OptimizedDoubleBuffer | ControlStyles.AllPaintingInWmPaint;
            this.SetStyle(flag, true);

            DebugLogger.LineWritten += (sender, e) => WriteLine(e.Text, e.Code);
            DebugLogger.UpdateLastLine += (sender, e) => UpdateLastLine(e.Text, e.Code);

            charHeight = CharHeight;
        }
        private static Dictionary<DebugCode, Brush> CodeColors = new Dictionary<DebugCode, Brush>()
        {
            { DebugCode.Error,   Brushes.Red   },
            { DebugCode.Good,    Brushes.Green },
            { DebugCode.None,    Brushes.Black },
            { DebugCode.Warning, Brushes.Gold  },
        };

        public List<DebugLine> debugLines = new List<DebugLine>();

        public int ScrollOffset = 0;
        private int charHeight = 0;
        public event EventHandler DebugLinesUpdated;

        public int StringHeight
        {
            get
            {
                Size CharSize = TextRenderer.MeasureText("TEST", this.Font);

                return (CharSize.Height - 1) * debugLines.Count;
            }
        }
        public int CharHeight
        {
            get { return TextRenderer.MeasureText("TEST", this.Font).Height; }
        }

     

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            int lines = (base.Height / charHeight) + 2;
            int lineIndex = ScrollOffset / charHeight;
            int offset = ScrollOffset % charHeight;

            for (int i = 0; i < lines; i++, lineIndex++)
            {
                if (lineIndex < debugLines.Count)
                {
                    var line = debugLines[lineIndex];

                    e.Graphics.DrawString(
                        line.Text,
                        this.Font,
                        CodeColors[line.Code],
                        1,
                        (i * charHeight) - offset);
                }
            }
        }

        public void WriteLine(string line, DebugCode status = DebugCode.None)
        {
            debugLines.Add(new DebugLine(line, status));
            //limit lines to 1000 lines
            if (debugLines.Count == 1000)
                debugLines.RemoveAt(0);

            if (DebugLinesUpdated != null)
                DebugLinesUpdated(this, EventArgs.Empty);

            if (status == DebugCode.Error || status == DebugCode.Warning)
                DebugLogger.CallLogWindow();

            base.Invalidate();
        }
        public void UpdateLastLine(string line, DebugCode status = DebugCode.None)
        {
            debugLines[debugLines.Count - 1] = new DebugLine(line, status);

            if (DebugLinesUpdated != null)
                DebugLinesUpdated(this, EventArgs.Empty);

            base.Invalidate();
        }
    }
    public struct DebugLine
    {
        public DebugLine(string debugLine, DebugCode status)
        {
            this.debugLine = debugLine;
            this.status = status;
        }
        string debugLine;
        DebugCode status;

        public string Text
        { get { return debugLine; } set { debugLine = value; } }
        public DebugCode Code
        { get { return status; } set { status = value; } }
    }
}