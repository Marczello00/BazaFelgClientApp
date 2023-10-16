using System.Diagnostics;
using System;
using System.Security.Policy;
using System.Windows.Forms;
using MyApp.DataProcessing;
using System.Configuration;

namespace MyApp
{
    public partial class MainApplicationForm : Form
    {
        private bool blockFilling = false;
        private int selectedBoltPattern = 0;
        private int selectedDiameter = 0;
        private List<RimModel> rims = new List<RimModel>();
        private void FillInDropDowns()
        {
            blockFilling = true;
            boltPatternDropDown.DataSource = RimModel.boltPatternList; boltPatternDropDown.SelectedIndex = 0;
            diameterDropDown.DataSource = RimModel.DiameterList; diameterDropDown.SelectedIndex = 0;
            blockFilling = false;
        }
        private void CreateSampleData()
        {
            rims.Add(new RimModel("1", "alu", "B", "5", "120", "18", "8.5", "52", "2500", "4000", "255/35R18", "5020"));
            rims.Add(new RimModel("2", "alu", "MWs", "53", "1230", "18", "8.35", "532", "25030", "40030", "2355/35R18", "35020"));
            rims.Add(new RimModel("2", "alu", "MWs", "5", "112", "16", "8.35", "532", "25030", "40030", "2355/35R18", "35020"));
        }
        private void CreateColumns()
        {
            //LogoPicture.Visible = false;
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
        private void FillInForm()
        {
            if (blockFilling)
                return;
            ClearListView();
            Font hyperlinkFont = new Font(rimListView.Font, FontStyle.Underline | FontStyle.Bold);
            Color hyperlinkColor = Color.Blue;
            List<RimModel> givenRims = new List<RimModel>();
            givenRims = rims;
            if (selectedDiameter != 0)
                givenRims = DataProcessor.FilterRimsByDiameter(rims, selectedDiameter);
            if (selectedBoltPattern != 0)
                givenRims = DataProcessor.FilterRimsByScrews(givenRims, selectedBoltPattern);
            int numberOfRims = givenRims.Count;
            if (numberOfRims < 1)
            {
                ShowNoMatchingRims();
                return;
            }
            for (int i = 0; i < numberOfRims; i++)
            {
                ListViewItem rowInListView = new ListViewItem(givenRims[i].Id.ToString());
                rowInListView.SubItems.Add(givenRims[i].Type);
                rowInListView.SubItems.Add(givenRims[i].Make);
                rowInListView.SubItems.Add(givenRims[i].ScrewsQuantity.ToString() + "x" + givenRims[i].ScrewsSpacing.ToString());
                rowInListView.SubItems.Add(givenRims[i].Diameter.ToString() + "\"x" + givenRims[i].Width.ToString() + "J");
                rowInListView.SubItems.Add(givenRims[i].Offset.ToString());
                rowInListView.SubItems.Add(givenRims[i].Price.ToString());
                rowInListView.SubItems.Add("Klik!");
                rimListView.Items.Add(rowInListView);
                rimListView.Items[i].UseItemStyleForSubItems = false;
                rimListView.Items[i].SubItems[7].Font = hyperlinkFont;
                rimListView.Items[i].SubItems[7].ForeColor = hyperlinkColor;
            }
            rimsCountLabel.Text = "£¹czna liczba kompletów felg: " + givenRims.Count.ToString();
        }
        public MainApplicationForm()
        {
            InitializeComponent();
            FillInDropDowns();
            CreateColumns();
            versionLabel.Text = "Marcel Majcher wersja: " + ConfigurationManager.AppSettings["AppVersion"];
        }

        private void ShowNoMatchingRims()
        {
            rimListView.Items.Clear();
            noMatchingRimsLabel.Visible = true;
            rimsCountLabel.Text = "£¹czna liczba kompletów felg: 0";
        }
        private void ClearListView()
        {
            noMatchingRimsLabel.Visible = false;
            rimListView.Items.Clear();
        }
        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            LogoPicture.BackColor = Color.Transparent;
        }

        private async void downloadDataButton_Click(object sender, EventArgs e)
        {
            downloadDataProgressBar.Visible = true;
            downloadDataProgressBar.Value = 50;
            rims = await Task.Run(() => SqlConnectionApp.GetDatabaseDataAsync());
            downloadDataProgressBar.Value = 100;
            //CreateSampleData();
            FillInForm();
            downloadDataProgressBar.Visible = false;
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

        private void boltPatternDropDown_SelectedIndexChanged(object sender, EventArgs e)
        {
            selectedBoltPattern = boltPatternDropDown.SelectedIndex;
            FillInForm();

        }

        private void diameterDropDown_SelectedIndexChanged(object sender, EventArgs e)
        {
            selectedDiameter = diameterDropDown.SelectedIndex;
            FillInForm();
        }
        public static string GetConnectionString(string connectionStringName)
        {
            return ConfigurationManager.ConnectionStrings[connectionStringName].ConnectionString;
        }
    }
}