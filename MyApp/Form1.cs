using System.Diagnostics;
using System;
using System.Security.Policy;
using System.Windows.Forms;
using MyApp.DataProcessing;

namespace MyApp
{
    public partial class Form1 : Form
    {
        private void FillInDropDowns()
        {
            List<string> boltPatternList = new List<string> { "Rozstaw", "5x112", "5x100", "5x120", "5x108", "5x110", "4x114.3", "5x115", "4x100", "4x108" };
            boltPatternDropDown.DataSource = boltPatternList;boltPatternDropDown.SelectedIndex = 0;
            List<string> DiameterList = new List<string> { "Œrednica","13","14","15","16","17","18","19","20" };
            diameterDropDown.DataSource=DiameterList; diameterDropDown.SelectedIndex = 0;
        }
        private List<RimModel> rims = new List<RimModel>();
        private void CreateSampleData()
        {
            rims.Add(new RimModel("1", "alu", "B", "5", "120", "18", "8.5", "52", "2500", "4000", "255/35R18", "5020"));
            rims.Add(new RimModel("2", "alu", "MWs", "53", "1230", "18", "8.35", "532", "25030", "40030", "2355/35R18", "35020"));
            rims.Add(new RimModel("2", "alu", "MWs", "5", "112", "16", "8.35", "532", "25030", "40030", "2355/35R18", "35020"));
        }
        private void CreateColumns()
        {
            rimListView.View = View.Details;
            rimListView.GridLines = true;
            rimListView.FullRowSelect = true;

            List<string> columnsNames = new List<string> { "ID", "Typ", "Marka", "Rozstaw", "Wymiary", "ET", "Cena", "Zdjêcia" };
            foreach (var columnName in columnsNames)
                rimListView.Columns.Add(columnName);

            int columnWidth = rimListView.ClientSize.Width / rimListView.Columns.Count;
            foreach (ColumnHeader column in rimListView.Columns)
                column.Width = columnWidth;
        }
        private void FillInForm(List<RimModel> givenRims)
        {
            Font hyperlinkFont = new Font(rimListView.Font, FontStyle.Underline | FontStyle.Bold);
            Color hyperlinkColor = Color.Blue;
            int numberOfRims = givenRims.Count;
            if (numberOfRims < 1)
            {
                MessageBox.Show("Brak felg o podanych wymiarach!");
                return;
            }
            for (int i = 0; i < numberOfRims; i++)
            {
                ListViewItem rowInListView = new ListViewItem(givenRims[i].Id.ToString());
                rowInListView.SubItems.Add(givenRims[i].Type);
                rowInListView.SubItems.Add(givenRims[i].Make);
                rowInListView.SubItems.Add(givenRims[i].ScrewsQuantity.ToString() + "x" + givenRims[i].ScrewsSpacing.ToString());
                rowInListView.SubItems.Add(givenRims[i].Diameter.ToString() + "\"x" + givenRims[i].Width.ToString());
                rowInListView.SubItems.Add(givenRims[i].Offset.ToString());
                rowInListView.SubItems.Add(givenRims[i].Price.ToString());
                rowInListView.SubItems.Add("Klik!");
                rimListView.Items.Add(rowInListView);
                rimListView.Items[i].UseItemStyleForSubItems = false;
                rimListView.Items[i].SubItems[7].Font = hyperlinkFont;
                rimListView.Items[i].SubItems[7].ForeColor = hyperlinkColor;
            }
        }
        public Form1()
        {
            InitializeComponent();
            CreateSampleData();
            FillInDropDowns();
            CreateColumns();
            FillInForm(DataProcessor.FilterRimsByBoth(rims, 13, 5, 112));
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            LogoPicture.BackColor = Color.Transparent;
        }

        private void button1_Click(object sender, EventArgs e)
        {
        }

        private void rimListView_MouseClick(object sender, MouseEventArgs e)
        {
            int selectedIndex = 0;
            int subItemIndex = 0;
            if (rimListView.SelectedItems.Count > 0)
            {
                selectedIndex = rimListView.SelectedIndices[0];
                ListViewHitTestInfo hitTest = rimListView.HitTest(e.Location);
                subItemIndex = hitTest.Item.SubItems.IndexOf(hitTest.SubItem);
                if (subItemIndex == 7)
                {
                    string url = "https://oponymajcher.pl/baza/felgi.php?id=" + rims[selectedIndex].Id.ToString(); ; ;
                    Process.Start(new ProcessStartInfo(url) { UseShellExecute = true });
                }
            }
            //MessageBox.Show("clicked " + subItemIndex + " subitem if "+selectedIndex+" Item");
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}