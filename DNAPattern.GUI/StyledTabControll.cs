using System;
using System.Drawing;
using System.Windows.Forms;
using System.Drawing.Drawing2D;

namespace DNAPattern.GUI
{
    public partial class StyledTabControll : TabControl
    {
        private int hoveringIndex = -1;
        private bool hoveringCloseBtn = false;

        private Brush bgBrush;
        public Brush BackBrush
        {
            get { return bgBrush; }
            set { bgBrush = value; }
        }

        public delegate void OnHeaderCloseDelegate(object sender, EventArgs e);
        public event System.EventHandler OnClose;


        public StyledTabControll()
        {
            // Initialize and hide control.
            InitializeComponent();
            this.Visible = false;
            // Activate double buffering mode for better look (no flimmering).
            this.SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.UserPaint | ControlStyles.DoubleBuffer, true);
            this.SizeMode = TabSizeMode.Fixed;
            this.ForeColor = Color.FromArgb(64, 64, 64);
            this.Multiline = true;
            bgBrush = SystemBrushes.ControlDarkDark;
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            SolidBrush active = new SolidBrush(this.ForeColor),
                hover = new SolidBrush(Color.FromArgb(65, 150, 255)),
                hoverClose = new SolidBrush(Color.FromArgb(150, 200, 255));
            
            StringFormat centeredStringFormat = new StringFormat();
            centeredStringFormat.LineAlignment = StringAlignment.Center;
            Rectangle standardArea = Rectangle.Empty, tabTextArea = Rectangle.Empty, closeBtnArea = Rectangle.Empty;

            // Draw background
            e.Graphics.FillRectangle(bgBrush, new Rectangle(0, 0, this.Width, this.Height));
            // Draw tabpage
            int tabHeadBorder = this.ItemSize.Height * this.RowCount + 2;
            e.Graphics.FillRectangle(active, new Rectangle(2, tabHeadBorder, this.Width - 4, this.Height - tabHeadBorder));

            // Iterate each tab for painting
            for (int nIndex = 0; nIndex < this.TabCount; nIndex++)
            {
                standardArea = this.GetTabRect(nIndex);
                closeBtnArea = new Rectangle(standardArea.Right - 15, standardArea.Top + 3, 12, standardArea.Height - 6);
                tabTextArea = new Rectangle(standardArea.Left, standardArea.Top, standardArea.Width - 15, standardArea.Height);
                if (nIndex == this.SelectedIndex)
                {
                    e.Graphics.FillRectangle(active, standardArea);
                    if (hoveringIndex == nIndex && hoveringCloseBtn)
                        e.Graphics.FillRectangle(hoverClose, closeBtnArea);
                    e.Graphics.DrawString("X", this.Font, Brushes.White, closeBtnArea, centeredStringFormat);
                }
                else if (nIndex == hoveringIndex)
                {
                    // Highlight hovered item and close button
                    e.Graphics.FillRectangle(hover, standardArea);
                    if (hoveringCloseBtn)
                    {
                        e.Graphics.FillRectangle(hoverClose, closeBtnArea);
                    }
                    e.Graphics.DrawString("X", this.Font, Brushes.White, closeBtnArea, centeredStringFormat);
                }

                // Draw strings on tabs
                string str = this.TabPages[nIndex].Text;
                e.Graphics.DrawString(str, this.Font, Brushes.White, tabTextArea, centeredStringFormat);
            }
            active.Dispose();
            hover.Dispose();
            hoverClose.Dispose();
        }

        protected override void OnMouseMove(MouseEventArgs e)
        {
            Point loc = e.Location;
            Rectangle standardArea = Rectangle.Empty, closeBtnArea = Rectangle.Empty;
            // Check if a tabheader is hovered by the mouse
            for (int nIndex = 0; nIndex < this.TabCount; nIndex++)
            {
                standardArea = this.GetTabRect(nIndex);
                if (this.GetTabRect(nIndex).Contains(loc) && nIndex != hoveringIndex)
                {
                    // Set hovered tab and repaint the conrol
                    hoveringIndex = nIndex;
                    closeBtnArea = new Rectangle(standardArea.Right - 15, standardArea.Top + 3, 12, standardArea.Height - 6);
                    hoveringCloseBtn = closeBtnArea.Contains(loc);
                    this.Refresh();
                    return;
                }
            }
            hoveringIndex = -1;
        }

        protected override void OnMouseLeave(EventArgs e)
        {
            // Reset all hovered tab headers and repaint the control
            hoveringIndex = -1;
            this.Refresh();
        }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            if (!DesignMode)
            {
                if (this.TabCount > 0)
                {
                    // Test if the user clicked a close button
                    Point loc = new Point(e.Location.X, e.Location.Y % this.ItemSize.Height + (this.RowCount - 1) * this.ItemSize.Height);
                    Rectangle standardArea = Rectangle.Empty, closeBtnArea = Rectangle.Empty;
                    for (int nIndex = 0; nIndex < this.TabCount; nIndex++)
                    {
                        standardArea = this.GetTabRect(nIndex);
                        closeBtnArea = new Rectangle(standardArea.Right - 15, standardArea.Top + 3, 12, standardArea.Height - 6);
                        if (closeBtnArea.Contains(loc))
                        {
                            // Close the tabpage if the user confirms the action
                            if (MessageBox.Show("You are about to close " + this.TabPages[nIndex].Text.TrimEnd() +
                                    " tab. Are you sure you want to continue?", "Confirm close", MessageBoxButtons.YesNo) == DialogResult.No)
                                return;
                            if (this.SelectedIndex == nIndex && this.SelectedIndex + 1 < this.TabCount) this.SelectedIndex++;
                            this.TabPages.RemoveAt(nIndex);
                            if (this.TabCount == 0) this.Visible = false;
                            hoveringIndex = -1;
                            // Fire close event
                            if (OnClose != null)
                            {
                                OnClose(this, new EventArgs());
                            }
                        }
                    }
                }
            }
        }
    }
}
