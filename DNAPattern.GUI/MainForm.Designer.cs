namespace DNAPattern.GUI
{
    partial class MainForm
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripProgressBar1 = new System.Windows.Forms.ToolStripProgressBar();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fILEToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sCANSToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.styledTabControll1 = new DNAPattern.GUI.StyledTabControll();
            this.statusStrip1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // statusStrip1
            // 
            this.statusStrip1.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1,
            this.toolStripProgressBar1});
            this.statusStrip1.Location = new System.Drawing.Point(0, 419);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(684, 22);
            this.statusStrip1.TabIndex = 0;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(39, 17);
            this.toolStripStatusLabel1.Text = "Ready";
            // 
            // toolStripProgressBar1
            // 
            this.toolStripProgressBar1.Name = "toolStripProgressBar1";
            this.toolStripProgressBar1.Size = new System.Drawing.Size(100, 16);
            this.toolStripProgressBar1.Visible = false;
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fILEToolStripMenuItem,
            this.sCANSToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.menuStrip1.Size = new System.Drawing.Size(684, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fILEToolStripMenuItem
            // 
            this.fILEToolStripMenuItem.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.fILEToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.fILEToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.fILEToolStripMenuItem.Name = "fILEToolStripMenuItem";
            this.fILEToolStripMenuItem.Size = new System.Drawing.Size(40, 20);
            this.fILEToolStripMenuItem.Text = "FILE";
            this.fILEToolStripMenuItem.DropDownClosed += new System.EventHandler(this.MenuItem_DropDownClosed);
            this.fILEToolStripMenuItem.DropDownOpened += new System.EventHandler(this.MenuItem_DropDownOpened);
            this.fILEToolStripMenuItem.MouseLeave += new System.EventHandler(this.MenuItem_MouseLeave);
            this.fILEToolStripMenuItem.MouseMove += new System.Windows.Forms.MouseEventHandler(this.MenuItem_MouseMove);
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.Size = new System.Drawing.Size(103, 22);
            this.openToolStripMenuItem.Text = "Open";
            this.openToolStripMenuItem.Click += new System.EventHandler(this.openToolStripMenuItem_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(103, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // sCANSToolStripMenuItem
            // 
            this.sCANSToolStripMenuItem.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.sCANSToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.sCANSToolStripMenuItem.Name = "sCANSToolStripMenuItem";
            this.sCANSToolStripMenuItem.Size = new System.Drawing.Size(56, 20);
            this.sCANSToolStripMenuItem.Text = "SCANS";
            this.sCANSToolStripMenuItem.Visible = false;
            this.sCANSToolStripMenuItem.DropDownClosed += new System.EventHandler(this.MenuItem_DropDownClosed);
            this.sCANSToolStripMenuItem.DropDownOpened += new System.EventHandler(this.MenuItem_DropDownOpened);
            this.sCANSToolStripMenuItem.MouseLeave += new System.EventHandler(this.MenuItem_MouseLeave);
            this.sCANSToolStripMenuItem.MouseMove += new System.Windows.Forms.MouseEventHandler(this.MenuItem_MouseMove);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.Filter = "DNA strand files|*.txt";
            this.openFileDialog1.Multiselect = true;
            // 
            // styledTabControll1
            // 
            this.styledTabControll1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.styledTabControll1.DrawMode = System.Windows.Forms.TabDrawMode.OwnerDrawFixed;
            this.styledTabControll1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.styledTabControll1.ItemSize = new System.Drawing.Size(130, 24);
            this.styledTabControll1.Location = new System.Drawing.Point(0, 24);
            this.styledTabControll1.Margin = new System.Windows.Forms.Padding(10);
            this.styledTabControll1.Multiline = true;
            this.styledTabControll1.Name = "styledTabControll1";
            this.styledTabControll1.SelectedIndex = 0;
            this.styledTabControll1.Size = new System.Drawing.Size(684, 395);
            this.styledTabControll1.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
            this.styledTabControll1.TabIndex = 3;
            this.styledTabControll1.TabStop = false;
            this.styledTabControll1.Visible = false;
            // 
            // MainForm
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.ClientSize = new System.Drawing.Size(684, 441);
            this.Controls.Add(this.styledTabControll1);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.MinimumSize = new System.Drawing.Size(700, 480);
            this.Name = "MainForm";
            this.Text = "DNAPattern Analzer";
            this.DragDrop += new System.Windows.Forms.DragEventHandler(this.MainForm_DragDrop);
            this.DragEnter += new System.Windows.Forms.DragEventHandler(this.MainForm_DragEnter);
            this.Resize += new System.EventHandler(this.MainForm_Resize);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fILEToolStripMenuItem;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripProgressBar toolStripProgressBar1;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private StyledTabControll styledTabControll1;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.ToolStripMenuItem sCANSToolStripMenuItem;
    }
}

