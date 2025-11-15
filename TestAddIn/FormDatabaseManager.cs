using Newtonsoft.Json;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using TestAddIn.article;
using TestAddIn.extras;
using TestAddIn.orders;

namespace TestAddIn
{
    public class FormDatabaseManager : Form
    {
        private TabControl tabs;
        private DataGridView dgvCustomers;
        private DataGridView dgvOrders;
        private DataGridView dgvArticles;
        private DataGridView dgvArticlesTwo;
        private DataGridView dgvExtras; 

        private List<Article> articles; // store loaded articles
        private List<Article> articlesTwo; // store loaded articles 2

        private Label lblOrdersSummary;
        private Label lblKasse1Summary;
        private Label lblKasse2Summary;
        private Label lblExtrasSummary;



        public FormDatabaseManager()
        {
            BuildUI();

            LoadAllOrders(); // bestellungen
            LoadAllArticlesCheckoutOne(); // kasse 1 articles
            LoadAllArticlesCheckoutTwo(); // kasse 2 articles
            LoadAllExtras(); // extras
        }

        private void BuildUI()
        {
            this.Width = 1500;
            this.Height = 800;
            this.Text = "Database Manager";

            tabs = new TabControl
            {
                Dock = DockStyle.Fill,
                Font = new System.Drawing.Font("Segoe UI", 14),
            };

            var tabOrders = new TabPage("Bestellungen");
            var tabArticles = new TabPage("Kasset 1");
            var tabArticlesTwo = new TabPage("Kasset 2");
            var tabCustomers = new TabPage("Kunden");
            var tabExtras = new TabPage("Extras"); 


            dgvOrders = new DataGridView
            {
                Dock = DockStyle.Fill,
                MultiSelect = true,
                AllowUserToAddRows = false,
                ReadOnly = true
            };

            dgvCustomers = new DataGridView
            {
                Dock = DockStyle.Fill,
                MultiSelect = true,
                AllowUserToAddRows = false,
                ReadOnly = true
            };

            dgvArticles = new DataGridView
            {
                Dock = DockStyle.Fill,
                MultiSelect = true,
                AllowUserToAddRows = false,
                ReadOnly = true
            };

            dgvArticlesTwo = new DataGridView
            {
                Dock = DockStyle.Fill,
                MultiSelect = true,
                AllowUserToAddRows = false,
                ReadOnly = true
            };
            dgvExtras = new DataGridView
            {
                Dock = DockStyle.Fill,
                MultiSelect = true,
                AllowUserToAddRows = false,
                ReadOnly = true
            };

            tabOrders.Controls.Add(dgvOrders);
            tabCustomers.Controls.Add(dgvCustomers);
            tabArticles.Controls.Add(dgvArticles);
            tabArticlesTwo.Controls.Add(dgvArticlesTwo);
            tabExtras.Controls.Add(dgvExtras);

            tabs.TabPages.Add(tabOrders);
            tabs.TabPages.Add(tabCustomers);
            tabs.TabPages.Add(tabArticles);
            tabs.TabPages.Add(tabArticlesTwo);
            tabs.TabPages.Add(tabExtras);

            this.Controls.Add(tabs);

            // Key handling
            dgvOrders.KeyDown += DgvOrders_KeyDown;
            dgvArticles.KeyDown += DgvArticles_KeyDown;
            dgvArticlesTwo.KeyDown += DgvArticles_KeyDown;
            dgvExtras.KeyDown += DgvArticles_KeyDown;



            lblOrdersSummary = CreateSummaryLabel(tabOrders);
            lblKasse1Summary = CreateSummaryLabel(tabArticles);
            lblKasse2Summary = CreateSummaryLabel(tabArticlesTwo);
            lblExtrasSummary = CreateSummaryLabel(tabExtras);
        }


        private void LoadAllOrders()
        {
            ApplyDarkTheme(dgvOrders);

            dgvOrders.Rows.Clear();
            dgvOrders.Columns.Clear();

            dgvOrders.Columns.Add("KNr", "KNr");
            dgvOrders.Columns.Add("Anz", "Anz");
            dgvOrders.Columns.Add("Nr", "Nr");
            dgvOrders.Columns.Add("Bez", "Bez");
            dgvOrders.Columns.Add("Size", "Size");
            dgvOrders.Columns.Add("Extra", "Extra");
            dgvOrders.Columns.Add("Price", "Preis");
            dgvOrders.Columns.Add("Rabbat", "Rabbat");


            dgvOrders.Columns["Bez"].Width = 300;
            foreach (var o in OrdersManager.GetAll())
            {
                dgvOrders.Rows.Add(o.KNr, o.Anz, o.Nr, o.Bez, o.Size, "€" + o.Extra, "€" + o.Price, "€" + o.Rabbat);
            }

            UpdateOrdersSummary();
        }

        private void DgvOrders_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
                DeleteSelectedOrders();
        }

        private void DeleteSelectedOrders()
        {
            if (dgvOrders.SelectedRows.Count == 0) return;

            if (MessageBox.Show("Ausgewählte Bestellungen löschen?", "Bestatigung",
                MessageBoxButtons.YesNo, MessageBoxIcon.Warning) != DialogResult.Yes)
                return;

            foreach (DataGridViewRow row in dgvOrders.SelectedRows)
            {
                string knr = row.Cells["KNr"].Value?.ToString() ?? "";
                string anz = row.Cells["Anz"].Value?.ToString() ?? "";
                string nr = row.Cells["Nr"].Value?.ToString() ?? "";
                string bez = row.Cells["Bez"].Value?.ToString() ?? ""; 

                OrdersManager.DeleteOrder(knr, anz, nr, bez);
            }

            OrdersManager.LoadOrders("orders.txt");
            LoadAllOrders();
        }


        // ---------------------------
        //   ARTICLES (NEW TAB)
        // ---------------------------
        private void UpdateKasse1Summary()
        {
            int count = dgvArticles.Rows.Count;
            lblKasse1Summary.Text = $"Artikel (Kasse 1): {count} geladen";
        }

        private void LoadAllArticlesCheckoutOne()
        {
            ApplyDarkTheme(dgvArticles);

            dgvArticles.Rows.Clear();
            dgvArticles.Columns.Clear();

            dgvArticles.Columns.Add("CompNum", "Number");
            dgvArticles.Columns.Add("Name", "Name");
            dgvArticles.Columns["Name"].Width = 300;
            dgvArticles.Columns.Add("SinglPreis", "Single");
            dgvArticles.Columns.Add("JumboPreis", "Jumbo");
            dgvArticles.Columns.Add("FamilyPreis", "Family");
            dgvArticles.Columns.Add("PartyPreis", "Party");

            articles = Article.LoadArticles("article.json");

            foreach (var a in articles)
            {
                dgvArticles.Rows.Add(
                    a.CompNum,
                    a.Name,
                    "€" + a.SinglPreis,
                    "€" + a.JumboPreis,
                    "€" + a.FamilyPreis,
                    "€" + a.PartyPreis
                );
            }

            UpdateKasse1Summary();

        }

        private void UpdateKasse2Summary()
        {
            int count = dgvArticlesTwo.Rows.Count;
            lblKasse2Summary.Text = $"Artikel (Kasse 2): {count} geladen";
        }

        private void LoadAllArticlesCheckoutTwo()
        {

            ApplyDarkTheme(dgvArticlesTwo);

            dgvArticlesTwo.Rows.Clear();
            dgvArticlesTwo.Columns.Clear();

            dgvArticlesTwo.Columns.Add("CompNum", "Number");
            dgvArticlesTwo.Columns.Add("Name", "Name");
            dgvArticlesTwo.Columns["Name"].Width = 300;

            dgvArticlesTwo.Columns.Add("SinglPreis", "Single");
            dgvArticlesTwo.Columns.Add("JumboPreis", "Jumbo");
            dgvArticlesTwo.Columns.Add("FamilyPreis", "Family");
            dgvArticlesTwo.Columns.Add("PartyPreis", "Party");

            articlesTwo = Article.LoadArticles("article2.json");

            foreach (var a in articlesTwo)
            {
                dgvArticlesTwo.Rows.Add(
                    a.CompNum,
                    a.Name,
                    "€" + a.SinglPreis,
                    "€" + a.JumboPreis,
                    "€" + a.FamilyPreis,
                    "€" + a.PartyPreis
                );
            }
            UpdateKasse2Summary();

        }

        private void DgvArticles_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
                DeleteSelectedArticles();
        }

        private void DeleteSelectedArticles()
        {
            if (dgvArticles.SelectedRows.Count == 0) return;

            if (MessageBox.Show("Ausgewählte Artikle löschen??", "Bestatigung",
                MessageBoxButtons.YesNo, MessageBoxIcon.Warning) != DialogResult.Yes)
                return;

            foreach (DataGridViewRow row in dgvArticles.SelectedRows)
            {
                string compNum = row.Cells["CompNum"].Value.ToString();

                var article = articles.FirstOrDefault(a => a.CompNum == compNum);
                if (article != null)
                    articles.Remove(article);
            }

            // Save updated JSON
            File.WriteAllText("article.json", JsonConvert.SerializeObject(articles, Formatting.Indented));

            LoadAllArticlesCheckoutOne();
            LoadAllArticlesCheckoutTwo();
        }

        private Label CreateSummaryLabel(TabPage tab)
        {
            var lbl = new Label
            {
                Dock = DockStyle.Bottom,
                Height = 35,
                TextAlign = ContentAlignment.MiddleCenter,
                Font = new Font("Segoe UI", 12, FontStyle.Bold),
                ForeColor = Color.Yellow,
                BackColor = Color.FromArgb(255, 0, 204)
            };

            tab.Controls.Add(lbl);
            return lbl;
        }

        string ExtractNumber(string input)
{
    if (string.IsNullOrWhiteSpace(input)) return "0";

    // remove € and spaces
    input = input.Replace("€", "").Trim();

    // keep only digits, comma, and dot
    var filtered = new string(input.Where(c => char.IsDigit(c) || c == ',' || c == '.').ToArray());

    return string.IsNullOrWhiteSpace(filtered) ? "0" : filtered;
}


        private void UpdateOrdersSummary()
        {
            int totalOrders = dgvOrders.Rows.Count;
            decimal totalPrice = 0;
            decimal totalRabbat = 0;

            foreach (DataGridViewRow row in dgvOrders.Rows)
            {
                if (!row.IsNewRow)
                {
                    decimal price = 0;
                    decimal rabbat = 0;

                    var priceText = (row.Cells["Price"].Value?.ToString() ?? "").Replace("€", "").Trim();
                    var rabbatText = (row.Cells["Rabbat"].Value?.ToString() ?? "").Replace("€", "").Trim();

                    decimal.TryParse(
                        (row.Cells["Price"].Value?.ToString() ?? "").Replace("€", "").Trim(),
                        System.Globalization.NumberStyles.Any,
                        System.Globalization.CultureInfo.InvariantCulture,
                        out price
                    );

                    decimal.TryParse(
                        (row.Cells["Rabbat"].Value?.ToString() ?? "").Replace("€", "").Trim(),
                        System.Globalization.NumberStyles.Any,
                        System.Globalization.CultureInfo.InvariantCulture,
                        out rabbat
                    );

                    totalPrice += price;
                    totalRabbat += rabbat;
                }
            }


            lblOrdersSummary.Text = $"Bestellungen: {totalOrders} | Gesamtpreis: {totalPrice:0.00} € | Rabatt gesamt: {totalRabbat:0.00} €";
        }


        private void UpdateExtrasSummary()
        {
            int count = dgvExtras.Rows.Count;
            lblExtrasSummary.Text = $"Extras: {count} vorhanden";
        }

        private void LoadAllExtras()
        {
            ApplyDarkTheme(dgvExtras);

            dgvExtras.Rows.Clear();
            dgvExtras.Columns.Clear();

            dgvExtras.Columns.Add("Id", "ID");
            dgvExtras.Columns.Add("Code", "Code");
            dgvExtras.Columns.Add("Name", "Name");
            dgvExtras.Columns.Add("SPrice", "Singl");
            dgvExtras.Columns.Add("JPrice", "Jumbo");
            dgvExtras.Columns.Add("FPrice", "Family");
            dgvExtras.Columns.Add("PPrice", "Party");

            dgvExtras.Columns["Name"].Width = 300;
            var list = ExtrasManager.GetAll();  // returns dynamic objects

            foreach (var ex in list)
            {
                dgvExtras.Rows.Add(
                    ex.Id,
                    ex.Code,
                    ex.Name,
                    "€" + ex.SinglPreis,
                    "€" + ex.JumboPreis,
                    "€" + ex.FamilyPreis,
                    "€" + ex.PartyPreis
                );
            }
            UpdateExtrasSummary();
        }

        private void ApplyDarkTheme(DataGridView dgv)
        {
            dgv.EnableHeadersVisualStyles = false;

            // Backgrounds
            dgv.BackgroundColor = Color.MediumBlue;
            dgv.GridColor = Color.MediumBlue;
            dgv.DefaultCellStyle.BackColor = Color.MediumBlue;

            // 🔥 Selection Color (Requested)
            dgv.DefaultCellStyle.SelectionBackColor = Color.FromArgb(255, 0, 204);  // bright magenta/pink
            dgv.DefaultCellStyle.SelectionForeColor = Color.FromArgb(255, 255, 0);  // neon yellow


            // Text colors
            dgv.DefaultCellStyle.ForeColor = Color.Yellow;
            dgv.DefaultCellStyle.Font = new Font("Segoe UI", 14, FontStyle.Regular);


            // Header styling
            dgv.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(255, 0, 204);
            dgv.ColumnHeadersDefaultCellStyle.ForeColor = Color.FromArgb(255, 255, 0);
            dgv.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 14, FontStyle.Bold);
            dgv.ColumnHeadersHeight = 42;

            dgv.RowHeadersDefaultCellStyle.BackColor = Color.MediumBlue;
            dgv.RowHeadersDefaultCellStyle.ForeColor = Color.Yellow;

            dgv.RowTemplate.Height = 38;
            dgv.BorderStyle = BorderStyle.FixedSingle;
        }
    }
}
