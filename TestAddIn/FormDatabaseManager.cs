using Newtonsoft.Json;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using TestAddIn.article;
using TestAddIn.extras;
using TestAddIn.orders;
using System;

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

        private List<Article> articles;
        private List<Article> articlesTwo;

        private Label lblOrdersSummary;
        private Label lblKasse1Summary;
        private Label lblKasse2Summary;
        private Label lblExtrasSummary;

        // New UI Elements
        private Button btnExportOrders;
        private Button btnRefreshAll;
        private Button btnPrintSummary;
        private TextBox txtSearchOrders;
        private TextBox txtSearchArticles;
        private ContextMenuStrip contextMenuOrders;
        private StatusStrip statusStrip;
        private ToolStripStatusLabel statusLabel;
        private ToolStripProgressBar progressBar;

        public FormDatabaseManager()
        {
            BuildUI();
            LoadAllData();
        }

        private void BuildUI()
        {
            this.Width = 1500;
            this.Height = 850;
            this.Text = "Database Manager - Enhanced";
            this.StartPosition = FormStartPosition.CenterScreen;

            // Main layout panel
            var mainPanel = new Panel { Dock = DockStyle.Fill };
            var topPanel = new Panel { Dock = DockStyle.Top, Height = 80, BackColor = Color.MediumBlue };
            var contentPanel = new Panel { Dock = DockStyle.Fill };

            // Top panel with controls
            BuildTopPanel(topPanel);

            // Tab control
            tabs = new TabControl
            {
                Dock = DockStyle.Fill,
                Font = new Font("Segoe UI", 12),
                ItemSize = new Size(120, 30)
            };

            // Create tabs
            var tabOrders = new TabPage("📋 Bestellungen");
            var tabArticles = new TabPage("💰 Kasse 1");
            var tabArticlesTwo = new TabPage("💰 Kasse 2");
            var tabCustomers = new TabPage("👥 Kunden");
            var tabExtras = new TabPage("➕ Extras");

            // Initialize DataGridViews with enhanced settings
            dgvOrders = CreateEnhancedDataGridView();
            dgvCustomers = CreateEnhancedDataGridView();
            dgvArticles = CreateEnhancedDataGridView();
            dgvArticlesTwo = CreateEnhancedDataGridView();
            dgvExtras = CreateEnhancedDataGridView();

            // Add search boxes to relevant tabs
            AddSearchBoxToTab(tabOrders, "Suche Bestellungen...", txtSearchOrders, dgvOrders);
            AddSearchBoxToTab(tabArticles, "Suche Artikel...", txtSearchArticles, dgvArticles);

            tabOrders.Controls.Add(dgvOrders);
            tabCustomers.Controls.Add(dgvCustomers);
            tabArticles.Controls.Add(dgvArticles);
            tabArticlesTwo.Controls.Add(dgvArticlesTwo);
            tabExtras.Controls.Add(dgvExtras);

            tabs.TabPages.AddRange(new[] { tabOrders, tabCustomers, tabArticles, tabArticlesTwo, tabExtras });

            // Create context menu
            CreateContextMenu();

            // Status bar
            statusStrip = new StatusStrip();
            statusLabel = new ToolStripStatusLabel("Bereit");
            progressBar = new ToolStripProgressBar { Visible = false };
            statusStrip.Items.AddRange(new ToolStripItem[] { statusLabel, progressBar });

            // Assemble UI
            contentPanel.Controls.Add(tabs);
            mainPanel.Controls.AddRange(new Control[] { contentPanel, topPanel });
            this.Controls.AddRange(new Control[] { mainPanel, statusStrip });

            // Event handlers
            tabs.SelectedIndexChanged += Tabs_SelectedIndexChanged;
            this.Load += FormDatabaseManager_Load;

            // Key handling
            dgvOrders.KeyDown += DgvOrders_KeyDown;
            dgvArticles.KeyDown += DgvArticles_KeyDown;
            dgvArticlesTwo.KeyDown += DgvArticles_KeyDown;
            dgvExtras.KeyDown += DgvArticles_KeyDown;

            // Double-click events
            dgvOrders.CellDoubleClick += DgvOrders_CellDoubleClick;
            dgvArticles.CellDoubleClick += DgvArticles_CellDoubleClick;

            lblOrdersSummary = CreateEnhancedSummaryLabel(tabOrders, Color.FromArgb(0, 120, 215));
            lblKasse1Summary = CreateEnhancedSummaryLabel(tabArticles, Color.FromArgb(40, 167, 69));
            lblKasse2Summary = CreateEnhancedSummaryLabel(tabArticlesTwo, Color.FromArgb(220, 53, 69));
            lblExtrasSummary = CreateEnhancedSummaryLabel(tabExtras, Color.FromArgb(255, 193, 7));
        }

        private void BuildTopPanel(Panel panel)
        {
            // Refresh button
            btnRefreshAll = new Button
            {
                Text = "🔄 Aktualisieren",
                Font = new Font("Segoe UI", 10, FontStyle.Bold),
                ForeColor = Color.White,
                BackColor = Color.FromArgb(0, 123, 255),
                FlatStyle = FlatStyle.Flat,
                Width = 150,
                Height = 40,
                Location = new Point(20, 20),
                Cursor = Cursors.Hand
            };
            btnRefreshAll.Click += BtnRefreshAll_Click;
            btnRefreshAll.FlatAppearance.BorderSize = 0;

            // Export button
            btnExportOrders = new Button
            {
                Text = "💾 Export CSV",
                Font = new Font("Segoe UI", 10, FontStyle.Bold),
                ForeColor = Color.White,
                BackColor = Color.FromArgb(40, 167, 69),
                FlatStyle = FlatStyle.Flat,
                Width = 150,
                Height = 40,
                Location = new Point(180, 20),
                Cursor = Cursors.Hand
            };
            btnExportOrders.Click += BtnExportOrders_Click;
            btnExportOrders.FlatAppearance.BorderSize = 0;

            // Print summary button
            btnPrintSummary = new Button
            {
                Text = "🖨️ Zusammenfassung",
                Font = new Font("Segoe UI", 10, FontStyle.Bold),
                ForeColor = Color.White,
                BackColor = Color.FromArgb(255, 193, 7),
                FlatStyle = FlatStyle.Flat,
                Width = 170,
                Height = 40,
                Location = new Point(340, 20),
                Cursor = Cursors.Hand
            };
            btnPrintSummary.Click += BtnPrintSummary_Click;
            btnPrintSummary.FlatAppearance.BorderSize = 0;

            // Statistics label
            var statsLabel = new Label
            {
                Text = "📊",
                Font = new Font("Segoe UI", 14),
                ForeColor = Color.White,
                AutoSize = true,
                Location = new Point(530, 28)
            };

            panel.Controls.AddRange(new Control[] { btnRefreshAll, btnExportOrders, btnPrintSummary, statsLabel });
        }

        private DataGridView CreateEnhancedDataGridView()
        {
            var dgv = new DataGridView
            {
                Dock = DockStyle.Fill,
                MultiSelect = true,
                AllowUserToAddRows = false,
                AllowUserToDeleteRows = false,
                ReadOnly = true,
                SelectionMode = DataGridViewSelectionMode.FullRowSelect,
                AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill,
                RowHeadersVisible = false,
                EnableHeadersVisualStyles = false,
                ScrollBars = ScrollBars.Both,
                AllowDrop = false
            };

            // Apply enhanced dark theme
            ApplyEnhancedDarkTheme(dgv);

            // Add right-click context menu
            dgv.MouseClick += (s, e) =>
            {
                if (e.Button == MouseButtons.Right)
                {
                    var hit = dgv.HitTest(e.X, e.Y);
                    if (hit.RowIndex >= 0)
                    {
                        dgv.ClearSelection();
                        dgv.Rows[hit.RowIndex].Selected = true;
                        contextMenuOrders.Show(dgv, e.Location);
                    }
                }
            };

            return dgv;
        }

        private void ApplyEnhancedDarkTheme(DataGridView dgv)
        {
            dgv.BackgroundColor = Color.FromArgb(21, 21, 235);
            dgv.GridColor = Color.FromArgb(17, 17, 214);
            dgv.DefaultCellStyle.BackColor = Color.FromArgb(21, 21, 235);
            dgv.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(21, 21, 235);

            // Selection colors
            dgv.DefaultCellStyle.SelectionBackColor = Color.FromArgb(255, 0, 204);
            dgv.DefaultCellStyle.SelectionForeColor = Color.FromArgb(255, 255, 0);
            dgv.AlternatingRowsDefaultCellStyle.SelectionBackColor = Color.FromArgb(230, 0, 180);
            dgv.AlternatingRowsDefaultCellStyle.SelectionForeColor = Color.Yellow;

            // Text colors
            dgv.DefaultCellStyle.ForeColor = Color.FromArgb(220, 220, 220);
            dgv.DefaultCellStyle.Font = new Font("Segoe UI", 18);
            dgv.AlternatingRowsDefaultCellStyle.ForeColor = Color.FromArgb(240, 240, 240);

            // Header styling
            dgv.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(0, 120, 215);
            dgv.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgv.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 18, FontStyle.Bold);
            dgv.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgv.ColumnHeadersHeight = 40;
            dgv.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;

            // Row styling
            dgv.RowTemplate.Height = 36;
            dgv.RowTemplate.DefaultCellStyle.Padding = new Padding(2);
            dgv.BorderStyle = BorderStyle.FixedSingle;

            // Grid lines
            dgv.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgv.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
        }

        private void AddSearchBoxToTab(TabPage tab, string placeholder, TextBox searchBox, DataGridView dgv)
        {
            var searchPanel = new Panel
            {
                Dock = DockStyle.Top,
                Height = 50,
                BackColor = Color.FromArgb(21, 21, 235)
            };

            searchBox = new TextBox
            {
                PlaceholderText = placeholder,
                Font = new Font("Segoe UI", 18),
                ForeColor = Color.White,
                BackColor = Color.FromArgb(21, 21, 235),
                BorderStyle = BorderStyle.FixedSingle,
                Width = 300,
                Height = 35,
                Location = new Point(20, 7)
            };

            var searchLabel = new Label
            {
                Text = "🔍",
                Font = new Font("Segoe UI", 16),
                ForeColor = Color.White,
                AutoSize = true,
                Location = new Point(searchBox.Right + 10, 12)
            };

            searchBox.TextChanged += (s, e) => FilterDataGridView(dgv, searchBox.Text);

            searchPanel.Controls.AddRange(new Control[] { searchBox, searchLabel });
            tab.Controls.Add(searchPanel);
            tab.Controls.SetChildIndex(searchPanel, 0);
        }

        private void CreateContextMenu()
        {
            contextMenuOrders = new ContextMenuStrip();
            contextMenuOrders.Font = new Font("Segoe UI", 14);

            var copyItem = new ToolStripMenuItem("Kopieren");
            copyItem.Click += (s, e) => CopySelectedRows();
            contextMenuOrders.Items.Add(copyItem);

            var deleteItem = new ToolStripMenuItem("Löschen");
            deleteItem.Click += (s, e) => DeleteSelectedRows();
            contextMenuOrders.Items.Add(deleteItem);

            contextMenuOrders.Items.Add(new ToolStripSeparator());

            var selectAllItem = new ToolStripMenuItem("Alle auswählen");
            selectAllItem.Click += (s, e) => SelectAllRows();
            contextMenuOrders.Items.Add(selectAllItem);
        }

        private Label CreateEnhancedSummaryLabel(TabPage tab, Color backColor)
        {
            var lbl = new Label
            {
                Dock = DockStyle.Bottom,
                Height = 40,
                TextAlign = ContentAlignment.MiddleCenter,
                Font = new Font("Segoe UI", 14, FontStyle.Bold),
                ForeColor = Color.White,
                BackColor = backColor,
                Padding = new Padding(5)
            };

            tab.Controls.Add(lbl);
            return lbl;
        }

        private void LoadAllData()
        {
            ShowProgress("Lade Daten...", true);

            try
            {
                LoadAllOrders();
                LoadAllArticlesCheckoutOne();
                LoadAllArticlesCheckoutTwo();
                LoadAllExtras();
                // LoadCustomers(); // Uncomment if you have customer loading

                ShowProgress("Daten erfolgreich geladen", false);
                UpdateStatus("Bereit");
            }
            catch (Exception ex)
            {
                ShowProgress("Fehler beim Laden", false);
                UpdateStatus($"Fehler: {ex.Message}");
                MessageBox.Show($"Fehler beim Laden der Daten:\n{ex.Message}", "Fehler",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadAllOrders()
        {
            ApplyEnhancedDarkTheme(dgvOrders);

            dgvOrders.Rows.Clear();
            dgvOrders.Columns.Clear();

            dgvOrders.Columns.Add("KNr", "KNr");
            dgvOrders.Columns.Add("Anz", "Anz");
            dgvOrders.Columns.Add("Nr", "Nr");
            dgvOrders.Columns.Add("Bez", "Bez");
            dgvOrders.Columns.Add("Size", "Size");
            dgvOrders.Columns.Add("Extra", "Extra");
            dgvOrders.Columns.Add("Price", "Preis");
            dgvOrders.Columns.Add("Rabbat", "Rabatt");

            dgvOrders.Columns["Bez"].Width = 250;
            dgvOrders.Columns["Price"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvOrders.Columns["Rabbat"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            foreach (var o in OrdersManager.GetAll())
            {
                dgvOrders.Rows.Add(o.KNr, o.Anz, o.Nr, o.Bez, o.Size, "€" + o.Extra, "€" + o.Price, "%" + o.Rabbat);
            }

            UpdateOrdersSummary();
            HighlightExpensiveOrders();
        }

        private void LoadAllArticlesCheckoutOne()
        {
            ApplyEnhancedDarkTheme(dgvArticles);

            dgvArticles.Rows.Clear();
            dgvArticles.Columns.Clear();

            dgvArticles.Columns.Add("CompNum", "Nummer");
            dgvArticles.Columns.Add("Name", "Name");
            dgvArticles.Columns["Name"].Width = 300;
            dgvArticles.Columns.Add("SinglPreis", "Single");
            dgvArticles.Columns.Add("JumboPreis", "Jumbo");
            dgvArticles.Columns.Add("FamilyPreis", "Family");
            dgvArticles.Columns.Add("PartyPreis", "Party");

            // Price columns right aligned
            for (int i = 2; i < dgvArticles.Columns.Count; i++)
            {
                dgvArticles.Columns[i].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            }

            articles = Article.LoadArticles("article.json");

            foreach (var a in articles)
            {
                dgvArticles.Rows.Add(
                    a.CompNum,
                    a.Name,
                    FormatPrice(a.SinglPreis),
                    FormatPrice(a.JumboPreis),
                    FormatPrice(a.FamilyPreis),
                    FormatPrice(a.PartyPreis)
                );
            }

            UpdateKasse1Summary();
        }

        private void LoadAllArticlesCheckoutTwo()
        {
            ApplyEnhancedDarkTheme(dgvArticlesTwo);

            dgvArticlesTwo.Rows.Clear();
            dgvArticlesTwo.Columns.Clear();

            dgvArticlesTwo.Columns.Add("CompNum", "Nummer");
            dgvArticlesTwo.Columns.Add("Name", "Name");
            dgvArticlesTwo.Columns["Name"].Width = 300;
            dgvArticlesTwo.Columns.Add("SinglPreis", "Single");
            dgvArticlesTwo.Columns.Add("JumboPreis", "Jumbo");
            dgvArticlesTwo.Columns.Add("FamilyPreis", "Family");
            dgvArticlesTwo.Columns.Add("PartyPreis", "Party");

            for (int i = 2; i < dgvArticlesTwo.Columns.Count; i++)
            {
                dgvArticlesTwo.Columns[i].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            }

            articlesTwo = Article.LoadArticles("article2.json");

            foreach (var a in articlesTwo)
            {
                dgvArticlesTwo.Rows.Add(
                    a.CompNum,
                    a.Name,
                    FormatPrice(a.SinglPreis),
                    FormatPrice(a.JumboPreis),
                    FormatPrice(a.FamilyPreis),
                    FormatPrice(a.PartyPreis)
                );
            }

            UpdateKasse2Summary();
        }

        private void LoadAllExtras()
        {
            ApplyEnhancedDarkTheme(dgvExtras);

            dgvExtras.Rows.Clear();
            dgvExtras.Columns.Clear();

            dgvExtras.Columns.Add("Id", "ID");
            dgvExtras.Columns.Add("Code", "Code");
            dgvExtras.Columns.Add("Name", "Name");
            dgvExtras.Columns.Add("SPrice", "Single");
            dgvExtras.Columns.Add("JPrice", "Jumbo");
            dgvExtras.Columns.Add("FPrice", "Family");
            dgvExtras.Columns.Add("PPrice", "Party");

            dgvExtras.Columns["Name"].Width = 300;

            for (int i = 3; i < dgvExtras.Columns.Count; i++)
            {
                dgvExtras.Columns[i].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            }

            var list = ExtrasManager.GetAll();

            foreach (var ex in list)
            {
                dgvExtras.Rows.Add(
                    ex.Id,
                    ex.Code,
                    ex.Name,
                    FormatPrice(ex.SinglPreis),
                    FormatPrice(ex.JumboPreis),
                    FormatPrice(ex.FamilyPreis),
                    FormatPrice(ex.PartyPreis)
                );
            }

            UpdateExtrasSummary();
        }

        // ENHANCED: Better price formatting
        private string FormatPrice(object price)
        {
            if (price == null) return "€0,00";

            string priceStr = price.ToString();
            if (decimal.TryParse(priceStr, out decimal priceDec))
            {
                return $"€{priceDec:F2}".Replace(".", ",");
            }
            return $"€{priceStr}";
        }

        // ENHANCED: Improved summary with better parsing
        private void UpdateOrdersSummary()
        {
            int totalOrders = dgvOrders.Rows.Count;
            decimal totalPrice = 0;
            decimal totalRabbat = 0;

            foreach (DataGridViewRow row in dgvOrders.Rows)
            {
                if (!row.IsNewRow)
                {
                    decimal price = ParseCellValue(row.Cells["Price"]);
                    decimal rabbat = ParseCellValue(row.Cells["Rabbat"]);

                    totalPrice += price;
                    totalRabbat += rabbat;
                }
            }

            string formattedPrice = $"€{totalPrice:F2}".Replace(".", ",");
            string formattedRabatt = $"€{totalRabbat:F2}".Replace(".", ",");

            lblOrdersSummary.Text = $"📊 Bestellungen: {totalOrders} | Gesamtpreis: {formattedPrice} | Rabatt gesamt: {formattedRabatt}";
        }

        private decimal ParseCellValue(DataGridViewCell cell)
        {
            if (cell.Value == null) return 0;

            string text = cell.Value.ToString()
                .Replace("€", "")
                .Replace("%", "")
                .Trim();

            // Handle German decimal format
            if (text.Contains(","))
            {
                // Handle thousand separators
                if (text.Contains("."))
                {
                    text = text.Replace(".", "");
                }
                text = text.Replace(",", ".");
            }

            if (decimal.TryParse(text,
                System.Globalization.NumberStyles.Any,
                System.Globalization.CultureInfo.InvariantCulture,
                out decimal result))
            {
                return result;
            }

            return 0;
        }

        private void UpdateKasse1Summary()
        {
            int count = dgvArticles.Rows.Count;
            decimal totalValue = CalculateTotalArticlesValue(dgvArticles);
            lblKasse1Summary.Text = $"💰 Artikel (Kasse 1): {count} Artikel | Gesamtwert: €{totalValue:F2}".Replace(".", ",");
        }

        private void UpdateKasse2Summary()
        {
            int count = dgvArticlesTwo.Rows.Count;
            decimal totalValue = CalculateTotalArticlesValue(dgvArticlesTwo);
            lblKasse2Summary.Text = $"💰 Artikel (Kasse 2): {count} Artikel | Gesamtwert: €{totalValue:F2}".Replace(".", ",");
        }

        private void UpdateExtrasSummary()
        {
            int count = dgvExtras.Rows.Count;
            lblExtrasSummary.Text = $"➕ Extras: {count} verfügbar";
        }

        private decimal CalculateTotalArticlesValue(DataGridView dgv)
        {
            decimal total = 0;
            foreach (DataGridViewRow row in dgv.Rows)
            {
                if (!row.IsNewRow && row.Cells["SinglPreis"].Value != null)
                {
                    total += ParseCellValue(row.Cells["SinglPreis"]);
                }
            }
            return total;
        }

        // ENHANCED: Highlight expensive orders
        private void HighlightExpensiveOrders()
        {
            foreach (DataGridViewRow row in dgvOrders.Rows)
            {
                if (!row.IsNewRow)
                {
                    decimal price = ParseCellValue(row.Cells["Price"]);
                    if (price > 50)
                    {
                        row.DefaultCellStyle.BackColor = Color.FromArgb(255, 220, 220);
                        row.DefaultCellStyle.ForeColor = Color.DarkRed;
                    }
                    else if (price > 20)
                    {
                        row.DefaultCellStyle.BackColor = Color.FromArgb(255, 240, 220);
                        row.DefaultCellStyle.ForeColor = Color.DarkOrange;
                    }
                }
            }
        }

        // ENHANCED: Filter functionality
        private void FilterDataGridView(DataGridView dgv, string searchText)
        {
            if (string.IsNullOrWhiteSpace(searchText))
            {
                foreach (DataGridViewRow row in dgv.Rows)
                {
                    row.Visible = true;
                }
                return;
            }

            searchText = searchText.ToLower();
            foreach (DataGridViewRow row in dgv.Rows)
            {
                if (row.IsNewRow) continue;

                bool visible = false;
                foreach (DataGridViewCell cell in row.Cells)
                {
                    if (cell.Value != null && cell.Value.ToString().ToLower().Contains(searchText))
                    {
                        visible = true;
                        break;
                    }
                }
                row.Visible = visible;
            }
        }

        // ENHANCED: Event handlers for new features
        private void BtnRefreshAll_Click(object sender, EventArgs e)
        {
            LoadAllData();
            UpdateStatus("Alle Daten aktualisiert");
        }

        private void BtnExportOrders_Click(object sender, EventArgs e)
        {
            using (var saveDialog = new SaveFileDialog())
            {
                saveDialog.Filter = "CSV Dateien (*.csv)|*.csv|Alle Dateien (*.*)|*.*";
                saveDialog.Title = "Bestellungen exportieren";
                saveDialog.FileName = $"Bestellungen_{DateTime.Now:yyyyMMdd_HHmmss}.csv";

                if (saveDialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        ExportToCsv(dgvOrders, saveDialog.FileName);
                        UpdateStatus($"Export abgeschlossen: {saveDialog.FileName}");
                        MessageBox.Show("Export erfolgreich abgeschlossen!", "Erfolg",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Fehler beim Export: {ex.Message}", "Fehler",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void BtnPrintSummary_Click(object sender, EventArgs e)
        {
            string summary = GenerateSummaryReport();
            MessageBox.Show(summary, "Zusammenfassung", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void Tabs_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateStatus($"Aktiver Tab: {tabs.SelectedTab.Text}");
        }

        private void FormDatabaseManager_Load(object sender, EventArgs e)
        {
            UpdateStatus("Anwendung gestartet");
        }

        private void DgvOrders_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                var cell = dgvOrders.Rows[e.RowIndex].Cells[e.ColumnIndex];
                if (cell.Value != null)
                {
                    Clipboard.SetText(cell.Value.ToString());
                    UpdateStatus("Zelleninhalt kopiert");
                }
            }
        }

        private void DgvArticles_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                var cell = ((DataGridView)sender).Rows[e.RowIndex].Cells[e.ColumnIndex];
                if (cell.Value != null)
                {
                    Clipboard.SetText(cell.Value.ToString());
                    UpdateStatus("Artikelinformation kopiert");
                }
            }
        }

        // ENHANCED: Context menu actions
        private void CopySelectedRows()
        {
            if (dgvOrders.SelectedRows.Count > 0)
            {
                var sb = new System.Text.StringBuilder();
                foreach (DataGridViewRow row in dgvOrders.SelectedRows)
                {
                    if (!row.IsNewRow)
                    {
                        foreach (DataGridViewCell cell in row.Cells)
                        {
                            sb.Append(cell.Value?.ToString() ?? "");
                            sb.Append("\t");
                        }
                        sb.AppendLine();
                    }
                }
                Clipboard.SetText(sb.ToString());
                UpdateStatus($"{dgvOrders.SelectedRows.Count} Zeilen kopiert");
            }
        }

        private void DeleteSelectedRows()
        {
            DeleteSelectedOrders();
        }

        private void SelectAllRows()
        {
            dgvOrders.SelectAll();
        }

        // Original delete functionality (enhanced with confirmation)
        private void DeleteSelectedOrders()
        {
            if (dgvOrders.SelectedRows.Count == 0)
            {
                MessageBox.Show("Bitte wählen Sie Zeilen zum Löschen aus.", "Information",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var result = MessageBox.Show($"Möchten Sie {dgvOrders.SelectedRows.Count} ausgewählte Bestellungen löschen?",
                "Bestätigung", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (result == DialogResult.Yes)
            {
                ShowProgress("Lösche Bestellungen...", true);

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

                ShowProgress("", false);
                UpdateStatus($"{dgvOrders.SelectedRows.Count} Bestellungen gelöscht");
            }
        }

        // ENHANCED: Export to CSV
        private void ExportToCsv(DataGridView dgv, string filePath)
        {
            using (var writer = new StreamWriter(filePath, false, System.Text.Encoding.UTF8))
            {
                // Write headers
                var headers = dgv.Columns.Cast<DataGridViewColumn>()
                    .Select(col => QuoteCsvField(col.HeaderText));
                writer.WriteLine(string.Join(";", headers));

                // Write data
                foreach (DataGridViewRow row in dgv.Rows)
                {
                    if (!row.IsNewRow)
                    {
                        var fields = row.Cells.Cast<DataGridViewCell>()
                            .Select(cell => QuoteCsvField(cell.Value?.ToString() ?? ""));
                        writer.WriteLine(string.Join(";", fields));
                    }
                }
            }
        }

        private string QuoteCsvField(string field)
        {
            if (string.IsNullOrEmpty(field)) return "\"\"";

            if (field.Contains(";") || field.Contains("\"") || field.Contains("\n") || field.Contains("\r"))
            {
                return "\"" + field.Replace("\"", "\"\"") + "\"";
            }
            return field;
        }

        // ENHANCED: Summary report
        private string GenerateSummaryReport()
        {
            var sb = new System.Text.StringBuilder();
            sb.AppendLine("===== ZUSAMMENFASSUNG =====");
            sb.AppendLine($"Generiert am: {DateTime.Now:dd.MM.yyyy HH:mm:ss}");
            sb.AppendLine();

            // Orders summary
            int totalOrders = dgvOrders.Rows.Count;
            decimal totalPrice = 0;
            foreach (DataGridViewRow row in dgvOrders.Rows)
            {
                if (!row.IsNewRow)
                {
                    totalPrice += ParseCellValue(row.Cells["Price"]);
                }
            }
            sb.AppendLine($"📋 BESTELLUNGEN:");
            sb.AppendLine($"   Gesamt: {totalOrders} Bestellungen");
            sb.AppendLine($"   Umsatz: €{totalPrice:F2}".Replace(".", ","));
            sb.AppendLine();

            // Articles summary
            sb.AppendLine($"💰 ARTIKEL:");
            sb.AppendLine($"   Kasse 1: {dgvArticles.Rows.Count} Artikel");
            sb.AppendLine($"   Kasse 2: {dgvArticlesTwo.Rows.Count} Artikel");
            sb.AppendLine($"   Extras: {dgvExtras.Rows.Count} verfügbar");
            sb.AppendLine();

            // Statistics
            sb.AppendLine($"📊 STATISTIKEN:");
            sb.AppendLine($"   Durchschnittlicher Bestellwert: €{(totalOrders > 0 ? totalPrice / totalOrders : 0):F2}".Replace(".", ","));
            sb.AppendLine($"   Aktive Kassen: 2");
            sb.AppendLine($"   Letzte Aktualisierung: {DateTime.Now:HH:mm:ss}");

            return sb.ToString();
        }

        // ENHANCED: Status management
        private void UpdateStatus(string message)
        {
            statusLabel.Text = $" {message}";
        }

        private void ShowProgress(string message, bool showProgressBar)
        {
            statusLabel.Text = $" {message}";
            progressBar.Visible = showProgressBar;
            if (showProgressBar)
            {
                progressBar.Style = ProgressBarStyle.Marquee;
            }
            Application.DoEvents();
        }

        // Original key handlers
        private void DgvOrders_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
                DeleteSelectedOrders();
            else if (e.KeyCode == Keys.C && e.Control)
                CopySelectedRows();
            else if (e.KeyCode == Keys.A && e.Control)
                SelectAllRows();
        }

        private void DgvArticles_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
                DeleteSelectedArticles();
        }

        // Original article delete functionality
        private void DeleteSelectedArticles()
        {
            var dgv = tabs.SelectedTab == tabs.TabPages["💰 Kasse 1"] ? dgvArticles : dgvArticlesTwo;

            if (dgv.SelectedRows.Count == 0) return;

            if (MessageBox.Show("Ausgewählte Artikel löschen?", "Bestätigung",
                MessageBoxButtons.YesNo, MessageBoxIcon.Warning) != DialogResult.Yes)
                return;

            foreach (DataGridViewRow row in dgv.SelectedRows)
            {
                string compNum = row.Cells["CompNum"].Value.ToString();

                if (dgv == dgvArticles)
                {
                    var article = articles.FirstOrDefault(a => a.CompNum == compNum);
                    if (article != null)
                        articles.Remove(article);
                    File.WriteAllText("article.json", JsonConvert.SerializeObject(articles, Formatting.Indented));
                }
                else
                {
                    var article = articlesTwo.FirstOrDefault(a => a.CompNum == compNum);
                    if (article != null)
                        articlesTwo.Remove(article);
                    File.WriteAllText("article2.json", JsonConvert.SerializeObject(articlesTwo, Formatting.Indented));
                }
            }

            LoadAllArticlesCheckoutOne();
            LoadAllArticlesCheckoutTwo();
            UpdateStatus("Artikel gelöscht");
        }

        // Utility method for extracting numbers (kept for compatibility)
        private string ExtractNumber(string input)
        {
            if (string.IsNullOrWhiteSpace(input)) return "0";
            input = input.Replace("€", "").Trim();
            var filtered = new string(input.Where(c => char.IsDigit(c) || c == ',' || c == '.').ToArray());
            return string.IsNullOrWhiteSpace(filtered) ? "0" : filtered;
        }
    }
}