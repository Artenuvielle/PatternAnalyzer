using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using DNAPattern.Base;
using DNAPattern.Base.ScanResults;

namespace DNAPattern.GUI
{
    public partial class DNATabPage : TabPage
    {
        private DNASequence sequenceInThisTab;
        private RichTextBox DNAOutput;
        private StyledTabControll scannerTabControl;

        public DNASequence DNASequence
        {
            get { return sequenceInThisTab; }
        }

        public int scannerTabControlSelectedIndex
        {
            get { return scannerTabControl.SelectedIndex; }
            set { scannerTabControl.SelectedIndex = Math.Max(0,Math.Min(value,scannerTabControl.TabCount)); }
        }

        public DNATabPage(DNASequence inputSequence, string tabName)
        {
            InitializeComponent();
            this.Text = tabName;
            this.Dock = DockStyle.Fill;
            this.BackColor = Color.FromArgb(64, 64, 64);
            sequenceInThisTab = inputSequence;
            setUpComponents();
        }

        private void setUpComponents()
        {
            TableLayoutPanel container = new TableLayoutPanel();
            DNAOutput = new RichTextBox();
            DNAOutput.ScrollBars = RichTextBoxScrollBars.Both;
            DNAOutput.Text = sequenceInThisTab.getSequenceForOutput;
            DNAOutput.Dock = DockStyle.Fill;
            DNAOutput.WordWrap = false;
            DNAOutput.ReadOnly = true;
            scannerTabControl = new StyledTabControll();
            scannerTabControl.Dock = DockStyle.Fill;
            scannerTabControl.ForeColor = Color.Black;
            scannerTabControl.BackBrush = new SolidBrush(Color.FromArgb(64, 64, 64));
            container.ColumnCount = 2;
            container.RowCount = 1;
            container.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 40F));
            container.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 60F));
            container.Controls.Add(DNAOutput, 0, 0);
            container.Controls.Add(scannerTabControl, 1, 0);
            container.Dock = DockStyle.Fill;
            this.Controls.Add(container);
        }

        public void addScanResultPage(DNAScanResult resultToAdd, DNAScan finishedScan)
        {
            Font displayFont = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            TabPage newTabPageToBeAdded = new TabPage(finishedScan.GetType().Name);
            TableLayoutPanel container = new TableLayoutPanel();
            container.Dock = DockStyle.Fill;
            newTabPageToBeAdded.Dock = DockStyle.Fill;
            newTabPageToBeAdded.BackColor = Color.Black;
            Label answerLabel = new Label(), questionLabel = new Label();
            answerLabel.Text = "Answer:\n" + resultToAdd.getAnswer();
            answerLabel.TextAlign = ContentAlignment.MiddleLeft;
            answerLabel.ForeColor = Color.White;
            answerLabel.Dock = DockStyle.Fill;
            answerLabel.Font = displayFont;
            questionLabel.Text = "Question:\n" + finishedScan.getQuestion();
            questionLabel.TextAlign = ContentAlignment.MiddleLeft;
            questionLabel.ForeColor = Color.White;
            questionLabel.Dock = DockStyle.Fill;
            questionLabel.Font = displayFont;
            container.ColumnCount = 1;
            container.RowCount = 2;
            container.Controls.Add(questionLabel, 0, 0);
            container.Controls.Add(answerLabel, 0, 1);

            if ((resultToAdd.GetType() == typeof(TextResult)))
            {
                container.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 40F));
                container.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 60F));
            }
            else if ((resultToAdd.GetType() == typeof(AbsoluteNumberResult)))
            {
                container.RowCount = 3;
                container.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
                container.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
                container.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
                Chart chartToDisplayData = new Chart();
                chartToDisplayData.BackColor = Color.Black;
                chartToDisplayData.ForeColor = Color.White;
                Series chartSerie = new Series();
                chartSerie.ChartType = SeriesChartType.Pie;
                System.Collections.Generic.Dictionary<string, int> valuesToAdd = ((AbsoluteNumberResult)resultToAdd).getValues();
                int sumOfAllValues = ((AbsoluteNumberResult)resultToAdd).getSumOfAllValues();
                foreach (string key in valuesToAdd.Keys)
                {
                    chartSerie.Points.AddY(valuesToAdd[key]);
                    chartSerie.Points[chartSerie.Points.Count - 1].Label = Math.Round((double)valuesToAdd[key] / sumOfAllValues * 100, 2) + "%\n (" + valuesToAdd[key] + ")";
                    chartSerie.Points[chartSerie.Points.Count - 1].LegendText = key;
                }
                chartToDisplayData.Series.Add(chartSerie);
                Legend legendForTheGivenChart = new Legend();
                legendForTheGivenChart.Font = displayFont;
                legendForTheGivenChart.BackColor = Color.Black;
                legendForTheGivenChart.ForeColor = Color.White;
                chartToDisplayData.Legends.Add(legendForTheGivenChart);
                ChartArea chartAreaFor3DStyle = new ChartArea();
                chartAreaFor3DStyle.BackColor = Color.Black;
                chartAreaFor3DStyle.Area3DStyle.Enable3D = true;
                chartAreaFor3DStyle.Area3DStyle.Inclination = 50;
                chartToDisplayData.ChartAreas.Add(chartAreaFor3DStyle);
                chartToDisplayData.Dock = DockStyle.Fill;
                container.Controls.Add(chartToDisplayData, 0, 2);
            }
            else if ((resultToAdd.GetType() == typeof(DNASequenceResult)))
            {
                container.RowCount = 3;
                container.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
                container.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 15F));
                container.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 60F));
                RichTextBox textBoxForResultSequence = new RichTextBox();
                textBoxForResultSequence.Dock = DockStyle.Fill;
                textBoxForResultSequence.ReadOnly = true;
                textBoxForResultSequence.Text = ((DNASequenceResult)resultToAdd).getSequence().getSequenceForOutput;
                container.Controls.Add(textBoxForResultSequence, 0, 2);
            }
            
            newTabPageToBeAdded.Controls.Add(container);
            scannerTabControl.TabPages.Add(newTabPageToBeAdded);
            scannerTabControl.SelectedIndex = scannerTabControl.TabCount - 1;
            scannerTabControl.Visible = true;
        }
    }
}
