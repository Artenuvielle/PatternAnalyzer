using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;
using DNAPattern.Base;
using DNAPattern.Base.Scans;

namespace DNAPattern.GUI
{
    public partial class MainForm : Form
    {
        private Dictionary<string,Type> scannerList;

        public MainForm()
        {
            InitializeComponent();
            styledTabControll1.OnClose += new System.EventHandler(this.styledTabControll1_OnClose);

            string nameSpace = "DNAPattern.Base.Scans";
            scannerList = new Dictionary<string, Type>();
            
            // Load all scans
            Assembly asm = Assembly.GetAssembly(typeof(DNAScan));
            foreach (Type type in asm.GetTypes())
            {
                if (type.Namespace == nameSpace)
                    scannerList.Add(type.Name, type);
            }

            ToolStripMenuItem[] scannerToolStripItems = new ToolStripMenuItem[scannerList.Count];
            int i = 0;
            foreach(string typeName in scannerList.Keys.Reverse())
            {
                scannerToolStripItems[i] = new ToolStripMenuItem(typeName);
                scannerToolStripItems[i].Click += new System.EventHandler(scannerToolStripMenuItem_Click);
                sCANSToolStripMenuItem.DropDownItems.Add(scannerToolStripItems[i]);
                i++;
            }
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to quit?", "Confirm exit", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                this.Close();
                Application.Exit();
            }
        }

        private void scannerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Add requested scan type to current DNATabPage
            if (sender.GetType() == typeof(ToolStripMenuItem))
            {
                ToolStripMenuItem clickedItem = (ToolStripMenuItem)sender;
                if (scannerList.Keys.Contains<string>(clickedItem.Text))
                    addScanOfGivenTypeToCurrentDNATab(scannerList[clickedItem.Text]);
                else
                    MessageBox.Show("The scanner for the clicked menu item seems not to be available.");
            }
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                foreach (string filePath in openFileDialog1.FileNames)
                {
                    openDNASequenceFile(filePath);
                }
            }
        }

        private void styledTabControll1_OnClose(object sender, EventArgs e)
        {
            if (styledTabControll1.TabCount == 0)
                sCANSToolStripMenuItem.Visible = false;
        }

        private void MainForm_Resize(object sender, EventArgs e)
        {
            foreach (TabPage tp in styledTabControll1.TabPages)
            {
                tp.Invalidate();
            }
        }

        private void addDNATabPageFromSequenceToTabControl(DNASequence sequence, string name)
        {
            // Create new DNATabPage
            DNATabPage fileTabPage = new DNATabPage(sequence, name);
            styledTabControll1.TabPages.Add(fileTabPage);
            styledTabControll1.Visible = true;
            sCANSToolStripMenuItem.Visible = true;
            styledTabControll1.SelectedIndex = styledTabControll1.TabCount - 1;

            // Run all available scans for the just created tabpage
            runAllScansOnCurrentDNATab();
        }

        private void openDNASequenceFile(string pathToFile)
        {
            try
            {
                addDNATabPageFromSequenceToTabControl(DNASequence.LoadFromFile(pathToFile), Path.GetFileName(pathToFile));
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error opening \"" + pathToFile + "\".\n\nDetails: \n" + ex.Message, "Error on loading file");
            }
        }

        private void runAllScansOnCurrentDNATab()
        {
            foreach (Type t in scannerList.Values.Reverse())
            {
                addScanOfGivenTypeToCurrentDNATab(t);
            }
            ((DNATabPage)styledTabControll1.SelectedTab).scannerTabControlSelectedIndex-=scannerList.Count;
        }

        private void addScanOfGivenTypeToCurrentDNATab(Type scannerType)
        {
            DNAScan instance = null;
            try
            {
                instance = (DNAScan)Activator.CreateInstance(scannerType, new object[] { ((DNATabPage)styledTabControll1.SelectedTab).DNASequence });
            }
            catch (Exception e)
            {
                MessageBox.Show("Error while instantiating object of type " + scannerType + ".", "Error");
                return;
            }
            if (instance != null)
            {
                instance.RunScan();
                ((DNATabPage)styledTabControll1.SelectedTab).addScanResultPage(instance.getScanResult(), instance);
            }
        }

        //
        //  ONLY DRAG AND DROP STUFF FOLLOWING
        //

        private bool dropDownActivated = false;

        private void MenuItem_MouseMove(object sender, MouseEventArgs e)
        {
            ((ToolStripMenuItem)sender).ForeColor = System.Drawing.Color.Black;
        }

        private void MenuItem_MouseLeave(object sender, EventArgs e)
        {
            if (!dropDownActivated)
                ((ToolStripMenuItem)sender).ForeColor = System.Drawing.Color.White;
        }

        private void MenuItem_DropDownClosed(object sender, EventArgs e)
        {
            ((ToolStripMenuItem)sender).ForeColor = System.Drawing.Color.White;
            dropDownActivated = false;
        }

        private void MenuItem_DropDownOpened(object sender, EventArgs e)
        {
            dropDownActivated = true;
        }

        private void MainForm_DragDrop(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.Text))
            {
                string possibleDNAsequence = (string)e.Data.GetData(DataFormats.Text, false);

                if (DNASequence.TestIfStringIsSequence(possibleDNAsequence))
                    addDNATabPageFromSequenceToTabControl(new DNASequence(possibleDNAsequence), "dragdrop");
            }
            else
            {
                string[] FileList = (string[])e.Data.GetData(DataFormats.FileDrop, false);

                foreach (string file in FileList)
                    openDNASequenceFile(file);
            }
        }

        private void MainForm_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop) || e.Data.GetDataPresent(DataFormats.Text))
                e.Effect = DragDropEffects.Copy;
            else
                e.Effect = DragDropEffects.None;
        }
    }
}
