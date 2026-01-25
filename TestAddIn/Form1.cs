using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Printing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices; 
using System.Text;
using System.Text.Json;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using TestAddIn.article;
using TestAddIn.customer;
using TestAddIn.extras;
using TestAddIn.orders;
using TestAddIn.shared;


namespace TestAddIn
{
    


    public partial class Form1 : Form
    {
        private CultureInfo currentCulture = CultureInfo.CurrentCulture;
        private bool useGermanFormat = true; // Default to German
        private ListBox customerListBox;
        private Tools tools;
        private List<Article> articles;
        private List<Extras> extras = new List<Extras>();
        private ListBox searchListBox;
        private Timer driveCheckTimer;
        private bool isUserTypingStreet = false;
        private string monitoredDriveRoot;

        [DllImport("user32.dll")]
        private static extern IntPtr GetKeyboardLayout(uint idThread);
        
        [DllImport("user32.dll")]
        private static extern uint GetWindowThreadProcessId(IntPtr hWnd, IntPtr ProcessId);
        
        [DllImport("user32.dll")]
        private static extern IntPtr GetForegroundWindow();
        
        private bool IsGermanKeyboard()
        {
            try
            {
                IntPtr foregroundWindow = GetForegroundWindow();
                uint foregroundProcess = GetWindowThreadProcessId(foregroundWindow, IntPtr.Zero);
                IntPtr keyboardLayout = GetKeyboardLayout(foregroundProcess);
                
                // German keyboard layouts typically have these IDs
                int layoutId = keyboardLayout.ToInt32() & 0xFFFF;
                return layoutId == 0x0407 || layoutId == 0x0807 || layoutId == 0x0C07 || 
                    layoutId == 0x1007 || layoutId == 0x1407;
            }
            catch
            {
                return false; // Default to English if detection fails
            }
        }


        public Form1()
        {
            InitializeComponent();
            useGermanFormat = IsGermanKeyboard();
            
            // Add ListBox programmatically with professional attributes
            customerListBox = new ListBox
            {
                Name = "customerListBox",
                Visible = false,
                Font = new System.Drawing.Font("Segoe UI", 22F, System.Drawing.FontStyle.Bold), // Professional, readable font
                ForeColor = Color.Yellow, // Consistent with your choice
                BackColor = Color.FromArgb(192, 0, 192), // Subtle background for contrast
                BorderStyle = BorderStyle.FixedSingle, // Clean border
                Height = 400, // Set height to 400px as specified
                ScrollAlwaysVisible = true, // Visible vertical scrollbar for overflow
                IntegralHeight = false, // Allow exact height
                MultiColumn = false, // Single-column display
                SelectionMode = SelectionMode.One, // Single item selection
                ItemHeight = 20, // Adjust item height to fit font
            };
            this.Controls.Add(customerListBox);
            customerListBox.SelectedIndexChanged += customerListBox_SelectedIndexChanged;

            // Load customer file as db
            Customer.LoadCustomers("customers.txt");
            this.knr.KeyDown += Input_KeyDown;
            this.name.KeyDown += Input_KeyDown;
            this.phone.KeyDown += Input_KeyDown;
            this.str.KeyDown += Input_KeyDown;
            this.ort.KeyDown += Input_KeyDown;
            this.str.KeyDown += str_KeyDown;

            // Load orders file as a db
            OrdersManager.LoadOrders("orders.txt");
            LoadOrdersForCustomer(this.knr.Text);

            // lastOrdersTable cell navigation 
            /*override method used ProcessCmdKey*/

            textBoxDiscount.KeyDown += OrderTextBox_KeyDown;
            textBoxDiscount.KeyPress += (sender, e) =>
            {
                // Convert dot to comma for German format
                if (e.KeyChar == '.')
                {
                    e.KeyChar = ',';
                }
            };

            // focus cursor on search box when form loads
            this.Load += (s, e) => search.Focus();

            // beam cursor default custom size
            tools = new Tools();
            tools.HookAllTextBoxes(this.Controls);
            // Custom beam for cells in lastORdersTable 
            lastOrdersTable.EditingControlShowing += LastOrdersTable_EditingControlShowing;


            // Handle cell edit end to auto-fill "Bez" based on "Nr"
            labelPRValue.Text = "1";
            LoadArticlesForCurrentKasse();
            lastOrdersTable.CellValueChanged += lastOrdersTable_CellValueChanged;

            //handle extra list 
            ExtrasManager.LoadExtras("extra.json");

            try
            {
                var customersFullPath = Path.GetFullPath("customers.txt");
                monitoredDriveRoot = Path.GetPathRoot(customersFullPath);  // e.g. "E:\"
                                                                           // Optional debug:
                                                                           // MessageBox.Show("Monitoring drive: " + monitoredDriveRoot);
            }
            catch
            {
                monitoredDriveRoot = null; // if file not found, don't crash
            }

            // Start timer that checks the drive every second
            driveCheckTimer = new Timer();
            driveCheckTimer.Interval = 1000;
            driveCheckTimer.Tick += Timer_Tick;
            driveCheckTimer.Start();

            labelPRValue.Text = "1";

            //popup
            searchListBox = new ListBox();
            searchListBox.Visible = false;
            searchListBox.Height = 200;
            searchListBox.Width = search.Width;
            searchListBox.Left = search.Left;
            searchListBox.Top = search.Bottom;
            searchListBox.Font = new Font("Segoe UI", 10);
            searchListBox.BringToFront();
            this.Controls.Add(searchListBox);

            // Event handlers
            searchListBox.KeyDown += SearchListBox_KeyDown;
            searchListBox.Click += SearchListBox_Click;

        }

        private void LoadArticlesForCurrentKasse()
        {
            if (labelPRValue.Text == "2")
                articles = Article.LoadArticles("article2.json");
            else
                articles = Article.LoadArticles("article.json");
        }

        private void SearchListBox_Click(object sender, EventArgs e)
        {
            SelectCustomerFromPopup();
        }


        private void SelectCustomerFromPopup()
        {
            // Always hide BOTH popups
            customerListBox.Visible = false;
            searchListBox.Visible = false;

            if (!(searchListBox.Tag is List<Customer> matches))
                return;

            int index = searchListBox.SelectedIndex;

            if (index <= 1) return;

            int customerIndex = index - 2;

            if (customerIndex >= 0 && customerIndex < matches.Count)
            {
                var selectedCustomer = matches[customerIndex];
                PopulateCustomerFields(selectedCustomer);
            }

            // Always take focus AFTER hiding
            lastOrdersTable.Focus();
        }

        private void PopulateCustomerFields(Customer found)
        {
            // disable popup logic triggered by TextChanged
            isUserTypingStreet = false;

            knr.Text = found.KNr;
            name.Text = found.Name;
            phone.Text = found.Tel;
            str.Text = found.Str;
            ort.Text = found.Ort;

            // re-enable typing logic after assignment
            isUserTypingStreet = true;
        }


        private void Timer_Tick(object sender, EventArgs e)
        {
            if (useGermanFormat)
            {
                labelDate.Text = DateTime.Now.ToString("dd.MM.yyyy    HH:mm:ss");
            }
            else
            {
                labelDate.Text = DateTime.Now.ToString("MM/dd/yyyy    hh:mm:ss tt");
            }
            // update date and time every second
            labelDate.Text = DateTime.Now.ToString("dd.MM.yyyy    HH:mm:ss");

            // If we couldn't detect a drive, don't do anything
            if (string.IsNullOrEmpty(monitoredDriveRoot))
                return;

            // Check if that drive still exists (e.g. "E:\")
            bool driveExists = DriveInfo.GetDrives()
                .Any(d => string.Equals(d.Name, monitoredDriveRoot, StringComparison.OrdinalIgnoreCase));

            if (!driveExists)
            {
                driveCheckTimer.Stop();
                Application.Exit();
            }
        }

        private void LastOrdersTable_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (lastOrdersTable.IsCurrentCellDirty)
                lastOrdersTable.CommitEdit(DataGridViewDataErrorContexts.Commit);
        }

        private void lastOrdersTable_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0) return;

            var dgv = sender as DataGridView;
            var editedCell = dgv.Rows[e.RowIndex].Cells[e.ColumnIndex];
            string articlID = editedCell.Value?.ToString() ?? "";

            if (dgv.Columns[e.ColumnIndex].Name == "lastOrderNr")
            {
                var bezCell = dgv.Rows[e.RowIndex].Cells["lastOrderName"];
                var article = articles.FirstOrDefault(a => a.CompNum == articlID);
                if (article != null)
                    bezCell.Value = article.Name;
                else
                    bezCell.Value = "";

                // Move focus to lastOrderSize
                dgv.CurrentCell = dgv.Rows[e.RowIndex].Cells["lastOrderSize"];
                dgv.BeginEdit(true);
            }
        }


        private void LastOrdersTable_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0) return;

            var dgv = sender as DataGridView;
            var editedCell = dgv.Rows[e.RowIndex].Cells[e.ColumnIndex];
            string articlID = editedCell.Value?.ToString() ?? "";

            if (dgv.Columns[e.ColumnIndex].Name == "lastOrderNr")
            {
                var bezCell = dgv.Rows[e.RowIndex].Cells["lastOrderName"];
                if (bezCell != null)
                {
                    // Lookup in JSON
                    var article = articles.FirstOrDefault(a => a.CompNum == articlID);
                    if (article != null)
                        bezCell.Value = article.Name;
                    else
                        bezCell.Value = "";

                    // Move focus to lastOrderSize
                    dgv.CurrentCell = dgv.Rows[e.RowIndex].Cells["lastOrderSize"];
                    dgv.BeginEdit(true);
                }
            }
        }

        private void LastOrderSize_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (lastOrdersTable.CurrentCell == null) return;

            var dgv = lastOrdersTable;
            int rowIndex = dgv.CurrentCell.RowIndex;

            var anzCell = dgv.Rows[rowIndex].Cells["lastOrderAnz"];
            var nrCell = dgv.Rows[rowIndex].Cells["lastOrderNr"];
            var priceCell = dgv.Rows[rowIndex].Cells["lastOrderPrice"];
            var sizeCell = dgv.Rows[rowIndex].Cells["lastOrderSize"];

            string articlID = nrCell.Value?.ToString() ?? "";
            var article = articles.FirstOrDefault(a => a.CompNum == articlID);

            if (article == null) return;

            // Parse the quantity safely
            decimal quantity = ParseDecimal(anzCell.Value?.ToString() ?? "1");
            if (quantity == 0) quantity = 1; // Default to 1 if not specified

            char keyChar = char.ToUpper(e.KeyChar);

            switch (keyChar)
            {
                case 'S':
                    // Parse the price properly and multiply
                    decimal singlePrice = ParseDecimal(article.SinglPreis?.ToString() ?? "0");
                    priceCell.Value = (singlePrice * quantity).ToString("F2").Replace(".", ",");
                    break;
                case 'J':
                    decimal jumboPrice = ParseDecimal(article.JumboPreis?.ToString() ?? "0");
                    priceCell.Value = (jumboPrice * quantity).ToString("F2").Replace(".", ",");
                    break;
                case 'F':
                    decimal familyPrice = ParseDecimal(article.FamilyPreis?.ToString() ?? "0");
                    priceCell.Value = (familyPrice * quantity).ToString("F2").Replace(".", ",");
                    break;
                case 'P':
                    decimal partyPrice = ParseDecimal(article.PartyPreis?.ToString() ?? "0");
                    priceCell.Value = (partyPrice * quantity).ToString("F2").Replace(".", ",");
                    break;
                default:
                    break;
            }
        }


        private void LastOrdersTable_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            if (e.Control is TextBox tb)
            {
                // --- Existing GotFocus handler ---
                tb.GotFocus -= Tb_GotFocus;
                tb.GotFocus += Tb_GotFocus;

                // --- Add KeyPress handlers for size and extra ---
                int colIndex = lastOrdersTable.CurrentCell.ColumnIndex;
                string colName = lastOrdersTable.Columns[colIndex].Name;

                // Remove previous KeyPress handlers
                tb.KeyPress -= LastOrderSize_KeyPress;

                if (colName == "lastOrderSize")
                {
                    tb.KeyPress += LastOrderSize_KeyPress;
                    tb.TextChanged += LastOrderSize_TextChanged;
                }
                else if (colName == "lastOrderExtra") //TODO: update extra
                                                      //tb.KeyPress += LastOrderExtra_KeyPress;
                {
                    //
                    // MessageBox.Show("KNr is required." + colName, "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

                UpdateTotals();
            }
        }

        private void LastOrderSize_TextChanged(object sender, EventArgs e)
        {

            if (!(sender is TextBox tb)) return;

            // Only enforce uppercase / single letter if current cell is lastOrderSize
            if (lastOrdersTable.CurrentCell?.OwningColumn.Name != "lastOrderSize")
                return;

            if (!string.IsNullOrEmpty(tb.Text))
                tb.Text = tb.Text.Substring(0, 1).ToUpper();

            tb.SelectionStart = tb.Text.Length;
            tb.SelectionLength = 0;
        }

        private void Tb_GotFocus(object sender, EventArgs e)
        {

            if (sender is TextBox tb)
            {
                tools.ApplyCustomCaret(tb);
            }
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {   
            if (keyData == (Keys.Control | Keys.L)) // Ctrl+L to toggle language
            {
                useGermanFormat = !useGermanFormat;
                
                // Update display immediately
                Timer_Tick(null, EventArgs.Empty);
                UpdateTotals();
                
                MessageBox.Show(useGermanFormat ? "German format activated" : "English format activated", 
                            "Language", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return true;
            }

            var dgv = lastOrdersTable;
            bool gridHasFocus =
                dgv != null &&
                (dgv.Focused || (dgv.EditingControl != null && dgv.EditingControl.Focused));

            if (!gridHasFocus)
                return base.ProcessCmdKey(ref msg, keyData);

            var key = keyData & Keys.KeyCode;

            if (key == Keys.Enter)
            {
                if (dgv.CurrentCell == null) return true;

                int curCol = dgv.CurrentCell.ColumnIndex;
                int curRow = dgv.CurrentCell.RowIndex;

                // Get column indexes safely
                int colLastOrderAnz = dgv.Columns.Contains("lastOrderAnz") ? dgv.Columns["lastOrderAnz"].Index : -1;
                int colLastOrderNr = dgv.Columns.Contains("lastOrderNr") ? dgv.Columns["lastOrderNr"].Index : -1;
                int colLastOrderBez = dgv.Columns.Contains("lastOrderBez") ? dgv.Columns["lastOrderBez"].Index : -1;
                int colLastOrderSize = dgv.Columns.Contains("lastOrderSize") ? dgv.Columns["lastOrderSize"].Index : -1;
                int colLastOrderExtra = dgv.Columns.Contains("lastOrderExtra") ? dgv.Columns["lastOrderExtra"].Index : dgv.Columns.Count - 1;
                //case 1: Enter on lastOrderAnz
                if (curCol == colLastOrderAnz)
                {
                    dgv.EndEdit();
                    dgv.CommitEdit(DataGridViewDataErrorContexts.Commit);

                    string anzID = dgv.Rows[curRow].Cells["lastOrderAnz"].Value?.ToString()?.Trim() ?? "";
                    var anz = articles.FirstOrDefault(a => a.CompNum == anzID);

                    if (anzID == "")
                    {
                        dgv.Rows[curRow].Cells["lastOrderAnz"].Value = 1;
                    }
                    dgv.CurrentCell = dgv.Rows[curRow].Cells["lastOrderNr"];
                    dgv.BeginEdit(true);
                    return true;
                }
                // --- Case 2: Enter on lastOrderNr ---
                else if (curCol == colLastOrderNr)
                {
                    dgv.EndEdit();
                    dgv.CommitEdit(DataGridViewDataErrorContexts.Commit);

                    string articlID = dgv.Rows[curRow].Cells["lastOrderNr"].Value?.ToString()?.Trim() ?? "";

                    // --- NEW: Diverse case (Nr == 0) ---
                    if (articlID == "0")
                    {
                        dgv.Rows[curRow].Cells["lastOrderExtra"].Value = "Diverse#";

                        dgv.CurrentCell = dgv.Rows[curRow].Cells[colLastOrderExtra];
                        dgv.BeginEdit(true);

                        if (dgv.EditingControl is TextBox tb)
                            tb.SelectionStart = tb.Text.Length; // cursor after #

                        return true;
                    }

                    var article = articles.FirstOrDefault(a => a.CompNum == articlID);
                    
                    if (article != null)
                    {
                        dgv.Rows[curRow].Cells["lastOrderName"].Value = article.Name;
                        dgv.CurrentCell = dgv.Rows[curRow].Cells["lastOrderSize"];
                    }
                    else
                    {
                        MessageBox.Show(
                            "Artikel nicht gefunden. Bitte prüfen!" + article + "," + curCol,
                            "Fehler",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Warning
                        );
                    }

                    dgv.BeginEdit(true);
                    return true;
                }
                else if (curCol == colLastOrderSize)
                {
                    dgv.EndEdit();
                    dgv.CommitEdit(DataGridViewDataErrorContexts.Commit);

                    string anzID = dgv.Rows[curRow].Cells["lastOrderSize"].Value?.ToString()?.Trim() ?? "";

                    if (anzID == "")
                    {
                        dgv.Rows[curRow].Cells["lastOrderSize"].Value = 'S';
                        LastOrderSize_KeyPress(dgv.EditingControl, new KeyPressEventArgs('S'));
                    }  
                }
                // --- Case 2: Enter on LastOrderExtra ---
                // TODO: extra update
                else if (curCol == colLastOrderExtra)
                {
                    dgv.EndEdit();
                    dgv.CommitEdit(DataGridViewDataErrorContexts.Commit);

                    string extraInput = dgv.Rows[curRow].Cells[colLastOrderExtra].Value?.ToString()?.Trim();
                    string sizeText = dgv.Rows[curRow].Cells["lastOrderSize"].Value?.ToString()?.Trim();
                    char sizeCode = !string.IsNullOrEmpty(sizeText)
                        ? char.ToUpper(sizeText[0])
                        : 'S';

                    if (!string.IsNullOrEmpty(extraInput))
                    {
                        try
                        {
                            string expr = extraInput.Replace(" ", "");

                            if (!expr.StartsWith("+") && !expr.StartsWith("-"))
                                expr = "+" + expr;

                            var matches = System.Text.RegularExpressions.Regex.Matches(
                                expr,
                                @"[+-](?:\d+|Diverse#\d+(?:[.,]\d+)?)",
                                System.Text.RegularExpressions.RegexOptions.IgnoreCase
                            );

                            decimal totalExtraValue = 0;
                            decimal diverseValueTotal = 0;

                            var newExtraIds = new List<int>();

                            foreach (System.Text.RegularExpressions.Match match in matches)
                            {
                                string token = match.Value;
                                bool isPositive = token.StartsWith("+");
                                string valuePart = token.Substring(1);

                                // --- CASE 1: Diverse ---
                                if (valuePart.StartsWith("Diverse#", StringComparison.OrdinalIgnoreCase))
                                {
                                    string amountStr = valuePart
                                        .Substring("Diverse#".Length)
                                        .Replace(",", ".");

                                    if (decimal.TryParse(
                                            amountStr,
                                            System.Globalization.NumberStyles.Any,
                                            System.Globalization.CultureInfo.InvariantCulture,
                                            out decimal diverseValue))
                                    {
                                        diverseValueTotal += isPositive ? diverseValue : -diverseValue;
                                    }

                                    continue;
                                }

                                // --- CASE 2: Extra ID ---
                                if (int.TryParse(valuePart, out int id))
                                {
                                    var extraItem = TestAddIn.extras.ExtrasManager
                                        .GetExtraByIdCode(id, sizeCode);

                                    if (extraItem != null)
                                    {
                                        newExtraIds.Add(extraItem.Id);
                                        totalExtraValue += isPositive
                                            ? extraItem.Price
                                            : -extraItem.Price;
                                    }
                                    else
                                    {
                                        MessageBox.Show(
                                            $"Extra ID {id} not found!",
                                            "Warning",
                                            MessageBoxButtons.OK,
                                            MessageBoxIcon.Warning
                                        );
                                    }
                                }
                            }

                            // --- APPLY Diverse logic ---
                            if (diverseValueTotal != 0)
                            {
                                dgv.Rows[curRow].Cells["lastOrderPrice"].Value =
                                    diverseValueTotal.ToString("F2").Replace(".", ",");

                                // Clear extras because Diverse is a direct price
                                extras.Clear();
                            }
                            else
                            {
                                // --- Update extras list normally ---
                                extras.RemoveAll(e => !newExtraIds.Contains(e.Id));

                                foreach (int id in newExtraIds)
                                {
                                    if (!extras.Any(e => e.Id == id))
                                    {
                                        var extraItem = TestAddIn.extras.ExtrasManager
                                            .GetExtraByIdCode(id, sizeCode);

                                        if (extraItem != null)
                                            extras.Add(extraItem);
                                    }
                                }
                            }

                            // Persist input + tag
                            dgv.Rows[curRow].Cells[colLastOrderExtra].Value = extraInput;
                            dgv.Rows[curRow].Cells[colLastOrderExtra].Tag =
                                newExtraIds.LastOrDefault();
                        }
                        catch
                        {
                            dgv.Rows[curRow].Cells[colLastOrderExtra].Value = 0;
                        }
                    }
                    else
                    {
                        dgv.Rows[curRow].Cells[colLastOrderExtra].Value = 0;
                    }

                    // Move to next row
                    int nextRow = curRow + 1;
                    int firstColIndex = 0;

                    if (nextRow >= dgv.Rows.Count - 1 && dgv.AllowUserToAddRows)
                        dgv.CurrentCell = dgv.Rows[dgv.NewRowIndex].Cells[firstColIndex];
                    else
                        dgv.CurrentCell = dgv.Rows[nextRow].Cells[firstColIndex];

                    dgv.BeginEdit(true);
                    return true;
                }


                    // --- Case 3: Other columns → Enter acts like Tab ---
                    SendKeys.Send("{TAB}");
                return true;
            }
            else if (key == Keys.F6)
            {
                this.textBoxDiscount.Focus();
                return true;
            }
            else if (key == Keys.F2)
            {
                dgv.Rows.Clear();
                extras.Clear();
                this.search.Focus();
            }
            else if (key == Keys.F3)
            {
                dgv.Rows.Clear();
                extras.Clear();
                this.name.Focus();
            }
            else if (key == Keys.Tab)
            {
                return base.ProcessCmdKey(ref msg, keyData);
            }
            else if (key == Keys.F1)
            {
                // Clear all rows
                dgv.Rows.Clear();
                extras.Clear();

                // Ensure at least one row exists
                if (!dgv.AllowUserToAddRows || dgv.Rows.Count == 0)
                    dgv.Rows.Add();

                // Focus on the "Anz" column (or first column if missing)
                int anzIndex = dgv.Columns.Contains("Anz") ? dgv.Columns["Anz"].Index : 0;
                int targetRowIndex = dgv.Rows.Count - 1; // last row (or the newly added one)

                // Set the current cell and begin edit immediately
                dgv.CurrentCell = dgv.Rows[targetRowIndex].Cells[anzIndex];
                dgv.BeginEdit(true);

                return true; // handled
            }
            else if (key == Keys.Back)
            {
                if (dgv.CurrentCell != null)
                {
                    var tb = dgv.EditingControl as TextBox;

                    // If user is typing (text box active)
                    if (tb != null)
                    {
                        // CASE 1 — Textbox has characters → let normal backspace delete one char
                        if (tb.TextLength > 0)
                        {
                            // Let the TextBox handle Backspace normally
                            return base.ProcessCmdKey(ref msg, keyData);
                        }

                        // CASE 2 — Textbox is empty → move to previous cell
                        MoveToPreviousCell(dgv);
                        return true;
                    }

                    // If no editing control (not editing cell)
                    return base.ProcessCmdKey(ref msg, keyData);
                }
            }
            else if (key == Keys.F9)
            {
                var customer = Customer.FindByKNr(this.knr.Text);
                PrintOrder(lastOrdersTable, customer); // pass your customer and DGV
                return true;
            }else if (keyData == Keys.F10)
            {
                this.Close();
                return true;
            }

            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void MoveToPreviousCell(DataGridView dgv)
        {
            int curRow = dgv.CurrentCell.RowIndex;
            int curCol = dgv.CurrentCell.ColumnIndex;

            int prevCol = curCol - 1;
            int prevRow = curRow;

            // If we're at the start of a row, jump to previous row
            if (prevCol < 0)
            {
                prevRow--;
                if (prevRow < 0)
                    return; // at very beginning — do nothing

                prevCol = dgv.Columns.Count - 1;
            }

            dgv.CurrentCell = dgv.Rows[prevRow].Cells[prevCol];
            dgv.BeginEdit(true);
        }

        private decimal ParseDecimal(string input)
        {
            if (string.IsNullOrWhiteSpace(input))
                return 0;

            // Remove any currency symbols, whitespace, and unwanted characters
            input = input.Trim()
                        .Replace("€", "")
                        .Replace("$", "")
                        .Replace(" ", "")
                        .Trim();

            // If empty after cleaning, return 0
            if (string.IsNullOrEmpty(input))
                return 0;

            // Original logic from HTML version:
            // "keep digits, comma, dot, and minus for parsing, then normalize comma→dot"
            string cleanInput = System.Text.RegularExpressions.Regex.Replace(input, @"[^\d\-,\.]", "");

            // Handle multiple minus signs or plus signs
            if (cleanInput.StartsWith("--")) cleanInput = cleanInput.Substring(1);
            if (cleanInput.StartsWith("++")) cleanInput = cleanInput.Substring(1);

            // Handle empty after cleaning
            if (string.IsNullOrEmpty(cleanInput))
                return 0;

            // Handle cases like "-" or "+" alone
            if (cleanInput == "-" || cleanInput == "+" || cleanInput == "," || cleanInput == ".")
                return 0;

            // Original logic: normalize comma to dot for parsing
            cleanInput = cleanInput.Replace(',', '.');

            // Handle multiple dots (only keep first as decimal separator)
            int dotCount = cleanInput.Count(c => c == '.');
            if (dotCount > 1)
            {
                int firstDot = cleanInput.IndexOf('.');
                cleanInput = cleanInput.Substring(0, firstDot + 1) +
                            cleanInput.Substring(firstDot + 1).Replace(".", "");
            }

            // Handle trailing dot or minus
            if (cleanInput.EndsWith("."))
                cleanInput = cleanInput.TrimEnd('.');
            if (cleanInput.EndsWith("-"))
                cleanInput = cleanInput.TrimEnd('-');

            // Special case: input is just a minus sign
            if (cleanInput == "-")
                return 0;

            // Try parsing with invariant culture
            if (decimal.TryParse(cleanInput,
                System.Globalization.NumberStyles.Any,
                System.Globalization.CultureInfo.InvariantCulture,
                out decimal result))
            {
                return result;
            }

            // Fallback: try with current culture
            if (decimal.TryParse(cleanInput, out result))
            {
                return result;
            }

            return 0;
        }
        //TODO> update this vlue 
        private void PrintOrder(DataGridView dgv, Customer customer)
        {
            // First, collect order data like in the original method
            var orderList = new List<dynamic>();
            decimal totalBrutto = 0;

            foreach (DataGridViewRow row in dgv.Rows)
            {
                if (row.IsNewRow) continue;

                // FIXED: Use correct DataGridView column names based on original code
                // Read extra input expression (can contain +10-5+2 etc.)
                string extraInput = row.Cells["LastOrderExtra"].Value?.ToString()?.Trim() ?? "";

                // Get size - use original logic from HTML version
                string sizeStr = row.Cells["lastOrderSize"].Value?.ToString() ?? "";
                string size = !string.IsNullOrWhiteSpace(sizeStr) ? sizeStr.ToUpper() : "-";

                // Parse quantity
                string countText = row.Cells["lastOrderAnz"].Value?.ToString() ?? "0";
                decimal countValue = ParseDecimal(countText);

                // Parse price
                string priceText = row.Cells["lastOrderPrice"].Value?.ToString() ?? "0";
                decimal priceValue = ParseDecimal(priceText);

                // Get item name - use original logic
                string rawName = row.Cells["lastOrderName"].Value?.ToString() ?? "";
                string name = (rawName == "-") ? "Diverse#" : rawName;

                // Get item ID
                string id = row.Cells["lastOrderNr"].Value?.ToString() ?? "";

                // Parse multiple extras (like +10-5+2) - FIXED: use sizeCode for extras lookup
                var extrasList = new List<dynamic>();
                if (!string.IsNullOrEmpty(extraInput))
                {
                    string expr = extraInput.Replace(" ", "");
                    if (!expr.StartsWith("+") && !expr.StartsWith("-"))
                        expr = "+" + expr;

                    var matches = System.Text.RegularExpressions.Regex.Matches(expr, @"[+-]\d+");

                    foreach (System.Text.RegularExpressions.Match match in matches)
                    {
                        string token = match.Value;
                        bool isPositive = token.StartsWith("+");
                        int extraId = int.Parse(token.Substring(1));

                        // FIXED: Use size code (first char) for extras lookup
                        char sizeCode = !string.IsNullOrEmpty(sizeStr) && sizeStr.Length > 0
                            ? char.ToUpper(sizeStr[0])
                            : 'S';

                        var extraObj = ExtrasManager.GetExtraByIdCode(extraId, sizeCode);
                        if (extraObj != null)
                        {
                            // Use proper minus sign (en dash) like in second image
                            var extraDisplayName = (isPositive ? "+" : "–") + extraObj.Name;
                            var extraDisplayPrice = isPositive ? extraObj.Price : -extraObj.Price;

                            extrasList.Add(new
                            {
                                id = extraId.ToString(),
                                name = extraDisplayName,
                                price = extraDisplayPrice
                            });
                        }
                    }
                }

                // Calculate totals
                decimal itemTotal = priceValue;
                foreach (var extra in extrasList)
                {
                    itemTotal += Convert.ToDecimal(extra.price);
                }
                totalBrutto += itemTotal;

                // Build order entry - FIXED: Include all necessary fields
                var order = new
                {
                    count = countText,
                    id = id,
                    name = name,
                    price = priceValue,  // Base price without extras
                    size = size,
                    extras = extrasList,
                    totalWithExtras = itemTotal  // For verification
                };

                orderList.Add(order);
            }

            // Parse discount like in original - FIXED: Use same logic
            string rabText = this.labelLastDiscountValue.Text ?? "0";
            rabText = System.Text.RegularExpressions.Regex.Replace(rabText, @"[^\d\-,\.]", "").Replace(',', '.');

            decimal rabatt = 0;
            if (decimal.TryParse(rabText, System.Globalization.NumberStyles.Any, System.Globalization.CultureInfo.InvariantCulture, out decimal parsedRabatt))
            {
                rabatt = Math.Abs(parsedRabatt);
            }

            decimal netto = totalBrutto - rabatt;
            if (netto < 0) netto = 0;

            // Debug output
            Console.WriteLine($"Total Brutto: {totalBrutto}, Rabatt: {rabatt}, Netto: {netto}");
            Console.WriteLine($"Order count: {orderList.Count}");

            // Now print with the style from second image
            PrintDocument pd = new PrintDocument();
            
            pd.PrintPage += (s, e) => PrintPageHandler(e, orderList, customer, totalBrutto, rabatt, netto);

            try
            {
                pd.Print();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Fehler beim Drucken: " + ex.Message);
            }
        }

        private void PrintPageHandler(PrintPageEventArgs e, List<dynamic> orderList, Customer customer, decimal brutto, decimal rabatt, decimal netto)
        {
            // Margins
            int topMargin = 10;
            int leftMargin = 6;
            int rightMargin = e.MarginBounds.Right - 5;
            int bottomMargin = 8;

            using (Font font = new Font("Arial", 12))
            using (Font smallFont = new Font("Arial", 10))
            using (Font boldFont = new Font("Arial", 12, FontStyle.Bold)) // For totals
            {
                int lineHeight = (int)font.GetHeight(e.Graphics) + 4;
                int smallLineHeight = (int)smallFont.GetHeight(e.Graphics) + 3;
                int yPos = topMargin;

                // Define column widths - adjusted for better spacing
                int col1Width = 60;   // Anz
                int col2Width = 50;   // Nr.
                int col3Width = 280;  // Bez. (wider for long names)
                int col4Width = 50;   // Size

                int colStart = leftMargin;

                // Header - FIXED: Use "KNr:" without space
                e.Graphics.DrawString($"Datum: {DateTime.Now:dd.MM.yyyy HH:mm:ss}", font, Brushes.Black, leftMargin, yPos);
                yPos += lineHeight;

                string nameTelLine = $"KNr: {customer.KNr} - Name: {customer.Name}"; // NO SPACE in "KNr:"
                if (!string.IsNullOrEmpty(customer.Tel) && customer.Tel != "0")
                {
                    nameTelLine += $" - Tel: {customer.Tel}";
                }
                e.Graphics.DrawString(nameTelLine, font, Brushes.Black, leftMargin, yPos);
                yPos += lineHeight;

                e.Graphics.DrawString($"Add: {customer.Str}, {customer.Ort}", font, Brushes.Black, leftMargin, yPos);
                yPos += lineHeight * 2;

                // Table header - FIXED: Proper column separation
                // Draw vertical separators like in first image
                float headerY = yPos - 2; // Slightly above the line

                e.Graphics.DrawString("Anz", font, Brushes.Black, colStart, yPos);
                e.Graphics.DrawLine(Pens.Black, colStart + col1Width, headerY, colStart + col1Width, yPos + lineHeight);

                e.Graphics.DrawString("Nr.", font, Brushes.Black, colStart + col1Width + 2, yPos);
                e.Graphics.DrawLine(Pens.Black, colStart + col1Width + col2Width, headerY, colStart + col1Width + col2Width, yPos + lineHeight);

                e.Graphics.DrawString("Bez.", font, Brushes.Black, colStart + col1Width + col2Width + 2, yPos);
                e.Graphics.DrawLine(Pens.Black, colStart + col1Width + col2Width + col3Width, headerY, colStart + col1Width + col2Width + col3Width, yPos + lineHeight);

                e.Graphics.DrawString("Size", font, Brushes.Black, colStart + col1Width + col2Width + col3Width + 2, yPos);
                e.Graphics.DrawLine(Pens.Black, colStart + col1Width + col2Width + col3Width + col4Width, headerY, colStart + col1Width + col2Width + col3Width + col4Width, yPos + lineHeight);

                e.Graphics.DrawString("Preise", font, Brushes.Black, colStart + col1Width + col2Width + col3Width + col4Width + 2, yPos);

                yPos += lineHeight;

                // Draw horizontal line under header
                e.Graphics.DrawLine(Pens.Black, leftMargin, yPos, rightMargin, yPos);
                yPos += 4;

                // Table rows
                foreach (var order in orderList)
                {
                    // Main item row
                    float xPos = colStart;
                    e.Graphics.DrawString($"{order.count}x", font, Brushes.Black, xPos, yPos);

                    xPos += col1Width;
                    e.Graphics.DrawString($"{order.id}", font, Brushes.Black, xPos, yPos);

                    xPos += col2Width;
                    e.Graphics.DrawString($"{order.name}", font, Brushes.Black, xPos, yPos);

                    xPos += col3Width;
                    e.Graphics.DrawString($"{order.size}", font, Brushes.Black, xPos, yPos);

                    xPos += col4Width;
                    string formattedPrice = $"€{order.price.ToString("F2").Replace(".", ",")}";
                    e.Graphics.DrawString(formattedPrice, font, Brushes.Black, xPos, yPos);

                    yPos += lineHeight;

                    // Extras rows - FIXED: Match first image format
                    foreach (var extra in order.extras)
                    {
                        // Format: Empty Anz, ID in Nr., Name in Bez., "-" in Size, Price in Preise
                        xPos = colStart;
                        e.Graphics.DrawString("", font, Brushes.Black, xPos, yPos); // Empty Anz

                        xPos += col1Width;
                        e.Graphics.DrawString($"{extra.id}", smallFont, Brushes.Black, xPos, yPos); // ID

                        xPos += col2Width;
                        e.Graphics.DrawString($"{extra.name}", smallFont, Brushes.Black, xPos, yPos); // Name

                        xPos += col3Width;
                        e.Graphics.DrawString("-", smallFont, Brushes.Black, xPos, yPos); // Size = "-"

                        xPos += col4Width;
                        string extraFormattedPrice = $"€{Convert.ToDecimal(extra.price).ToString("F2").Replace(".", ",")}";
                        e.Graphics.DrawString(extraFormattedPrice, smallFont, Brushes.Black, xPos, yPos); // Price

                        yPos += smallLineHeight;
                    }
                }

                // Totals section
                yPos += lineHeight / 2;

                // Draw line before totals
                e.Graphics.DrawLine(Pens.Black, leftMargin, yPos, rightMargin, yPos);
                yPos += 8;

                // Format totals
                string bruttoFormatted = $"€{brutto.ToString("F2").Replace(".", ",")}";
                string rabattFormatted = $"- €{rabatt.ToString("F2").Replace(".", ",")}";
                string nettoFormatted = $"€{netto.ToString("F2").Replace(".", ",")}";

                // Calculate positions - FIXED: Make totals more prominent
                float labelX = leftMargin + 10;

                // Calculate right position for prices
                SizeF bruttoSize = e.Graphics.MeasureString(bruttoFormatted, boldFont);
                SizeF rabattSize = e.Graphics.MeasureString(rabattFormatted, boldFont);
                SizeF nettoSize = e.Graphics.MeasureString(nettoFormatted, boldFont);

                float maxPriceWidth = Math.Max(Math.Max(bruttoSize.Width, rabattSize.Width), nettoSize.Width);
                float priceX = rightMargin - maxPriceWidth;

                // Draw totals with bold font
                e.Graphics.DrawString($"Brutto:", boldFont, Brushes.Black, labelX, yPos);
                e.Graphics.DrawString(bruttoFormatted, boldFont, Brushes.Black, priceX, yPos);
                yPos += lineHeight;

                e.Graphics.DrawString($"Rabatt:", boldFont, Brushes.Black, labelX, yPos);
                e.Graphics.DrawString(rabattFormatted, boldFont, Brushes.Black, priceX, yPos);
                yPos += lineHeight;

                e.Graphics.DrawString($"Netto:", boldFont, Brushes.Black, labelX, yPos);
                e.Graphics.DrawString(nettoFormatted, boldFont, Brushes.Black, priceX, yPos);

                // Footer
                yPos += lineHeight * 2;
                e.Graphics.DrawString("Vielen Dank für Ihre Bestellung", font, Brushes.Black, leftMargin, yPos);

                // Check if we need another page
                e.HasMorePages = (yPos + bottomMargin > e.MarginBounds.Bottom);
            }
        }
        private void OrderTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true; // Prevent the ding sound

                Control current = (Control)sender;

                //calculate Sum and Count 
                UpdateTotals();

                if (current == textBoxDiscount)
                {
                    SaveTableOrdersToFile();
                }
            }
        }
        private void SaveTableOrdersToFile()
        {
            if (string.IsNullOrWhiteSpace(knr.Text))
            {
                MessageBox.Show("KNr is required.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                search.Focus();
                return;
            }

            try
            {
                var ordersForKnr = new List<Order>();

                foreach (DataGridViewRow row in lastOrdersTable.Rows)
                {
                    if (row.IsNewRow) continue;

                    var order = new Order
                    {
                        KNr = knr.Text.Trim(),
                        Anz = row.Cells[0].Value?.ToString()?.Trim() ?? "",
                        Nr = row.Cells[1].Value?.ToString()?.Trim() ?? "",
                        Bez = row.Cells[2].Value?.ToString()?.Trim() ?? "Diverse#",
                        Size = row.Cells[3].Value?.ToString()?.Trim() ?? "-",
                        Extra = row.Cells[4].Value?.ToString()?.Trim() ?? "",
                        Price = row.Cells[5].Value?.ToString()?.Trim() ?? "",
                        Rabbat = this.textBoxDiscount.Text.Trim()
                    };

                    if (!string.IsNullOrWhiteSpace(order.Anz) &&
                         !string.IsNullOrWhiteSpace(order.Nr) &&
                         !string.IsNullOrWhiteSpace(order.Bez) &&
                         !string.IsNullOrWhiteSpace(order.Size) &&
                         !string.IsNullOrWhiteSpace(order.Price))
                    {
                        ordersForKnr.Add(order);
                    }
                }

                // 👉 einmal speichern mit allen Orders für diese KNr
                OrdersManager.SaveOrders("orders.txt", knr.Text, ordersForKnr);

                // MessageBox.Show("Alle Bestellungen aus der Tabelle wurden erfolgreich gespeichert.",
                //"Success",
                // MessageBoxButtons.OK,
                // MessageBoxIcon.Information);

                LoadOrdersForCustomer(knr.Text);
                Customer.LoadCustomers("customers.txt");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error saving table orders: {ex.Message}\n\n{ex.StackTrace}",
                                "Error",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
            }
        }


        private void SearchListBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SelectCustomerFromPopup();
                e.Handled = true; // optional
            }
            else if (e.KeyCode == Keys.Escape)
            {
                searchListBox.Visible = false; // hide the popup
                e.Handled = true;
                this.search.Focus();
            }
        }

        private void LoadOrdersForCustomer(string customerId)
        {
            var filteredOrders = OrdersManager
                .GetAll()
                .Where(o => o.KNr.Trim() == customerId.Trim())
                .ToList();

            lastOrdersTable.Rows.Clear();

            foreach (var order in filteredOrders)
            {
                lastOrdersTable.Rows.Add(order.Anz, order.Nr, order.Bez, order.Size, order.Extra, order.Price, order.Rabbat);
            }

            UpdateTotals();
        }

        private string GetStreetNumber(string street)
        {
            if (string.IsNullOrWhiteSpace(street))
                return "";

            // Extract first number found in the street string
            var match = System.Text.RegularExpressions.Regex.Match(street, @"\d+");
            return match.Success ? match.Value : "";
        }

        private string GetStreetName(string street)
        {
            if (string.IsNullOrWhiteSpace(street))
                return "";

            // Remove the street number part
            return System.Text.RegularExpressions.Regex.Replace(street, @"\d+", "").Trim();
        }

        private void search_KeyDown(object sender, KeyEventArgs e)
        {
            // change kasset 
            change_kasset(sender, e);
            if (e.KeyCode == Keys.Enter)
            {
                Customer.LoadCustomers("customers.txt");
                var input = search.Text.Trim();
                if (string.IsNullOrEmpty(input)) return;

                if (input == "0")
                {
                    search.Text = "Abholer 1";
                    this.knr.Text = "0";
                    this.name.Text = "Abholer 1";
                    this.lastOrdersTable.Focus();
                    return;
                }

                if (input == "00")
                {
                    search.Text = "Abholer 2";
                    this.knr.Text = "00";
                    this.lastOrdersTable.Focus();
                    return;
                }

                // ➤ 1) Check if input is a positive number (KNr search)
                if (System.Text.RegularExpressions.Regex.IsMatch(input, @"^\d{1,5}$"))
                {

                    var found = Customer.FindByKNr(input);

                    if (found != null)
                    {
                        
                        int lastDiscountPercentage = OrdersManager.GetLastDiscount(found.KNr, "orders.txt");
                        textBoxDiscount.Text = lastDiscountPercentage.ToString() ?? "0";
                        PopulateCustomerFields(found);
                        
                        this.lastOrdersTable.Focus();
                        if (customerListBox.Items.Count > 0)
                        {
                            this.customerListBox.Focus();
                        }
                        return;
                    }

                    else
                    {

                        // Customert found → offer to create
                        knr.Text = "";
                        name.Text = "";
                        phone.Text = "";
                        str.Text = "";
                        ort.Text = "";

                        var result = MessageBox.Show(
                            "Kunde nicht gefunden. Möchten Sie einen neuen Kunden anlegen?",
                            "Kunde anlegen",
                            MessageBoxButtons.YesNo,
                            MessageBoxIcon.Question);

                        if (result == DialogResult.Yes)
                        {
                            var allCustomers = Customer.GetAll();
                            int maxKnr = allCustomers
                                .Select(c => int.TryParse(c.KNr, out int num) ? num : 0)
                                .DefaultIfEmpty(0)
                                .Max();

                            knr.ReadOnly = true;
                            knr.Text = (maxKnr + 1).ToString();
                            name.Focus();
                        }
                        return;
                    }
                }

                // ➤ 2) Input is NOT a pure positive number → search name/street/city/phone
                var matches = Customer.GetByAddress(input);

                searchListBox.Items.Clear();
                searchListBox.Visible = false;


                if (matches.Count == 1)
                {
                    // Directly populate if only one match
                    customerListBox.Visible = false;
                    PopulateCustomerFields(matches[0]);
                    this.lastOrdersTable.Focus();
                    return;
                }
                else if (matches.Count > 0)
                {
                    searchListBox.Items.Clear();

                    // Set styles BEFORE adding items
                    searchListBox.BackColor = Color.Black;
                    searchListBox.ForeColor = Color.Yellow;
                    searchListBox.Font = new Font(FontFamily.GenericMonospace, 18, FontStyle.Regular);
                    searchListBox.ItemHeight = 32; // Should match your font size
                    searchListBox.BorderStyle = BorderStyle.FixedSingle;
                    searchListBox.Width = 1250;

                    // Header
                    searchListBox.Items.Add(
                        string.Format("  {0,-5} {1,-25} {2,-30} {3,-35}      ",
                            "NO", "Name", "Str", "Tel")
                    );
                    searchListBox.Items.Add(new string('-', 120));

                    int index = 1;
                    foreach (var customer in matches)
                    {

                        searchListBox.Items.Add(
                            string.Format("  {0,-5} {1,-25} {2,-30} {3,-35}     ",
                                index,
                                customer.Name,
                                customer.Str,
                                customer.Tel
                            )
                        );
                        index++;
                    }

                    searchListBox.Tag = matches;

                    // Calculate height based on number of items
                    int totalItems = matches.Count + 2; // +2 for header and separator line
                    searchListBox.Height = Math.Min(600, totalItems * searchListBox.ItemHeight + 10);

                    searchListBox.Margin = new Padding(4);

                    searchListBox.Left = (this.ClientSize.Width - searchListBox.Width) / 2;
                    searchListBox.Top = (this.ClientSize.Height - searchListBox.Height) / 2;

                    searchListBox.BringToFront();
                    searchListBox.Visible = true;
                    searchListBox.Focus();
                }
                else
                {
                    // Customer not found → offer to create
                    knr.Text = "";
                    name.Text = "";
                    phone.Text = "";
                    str.Text = "";
                    ort.Text = "";

                    var result = MessageBox.Show(
                        "Kunde nicht gefunden. Möchten Sie einen neuen Kunden anlegen?",
                        "Kunde anlegen",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Question);

                    if (result == DialogResult.Yes)
                    {
                        var allCustomers = Customer.GetAll();
                        int maxKnr = allCustomers
                            .Select(c => int.TryParse(c.KNr, out int num) ? num : 0)
                            .DefaultIfEmpty(0)
                            .Max();

                        knr.ReadOnly = true;
                        knr.Text = (maxKnr + 1).ToString();
                        name.Focus();
                    }
                    return;
                }
            }

        }


        private void Input_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true; // prevent ding sound

                Control current = (Control)sender;

                if (current == knr)
                    name.Focus();
                else if (current == name)
                    phone.Focus();
                else if (current == phone)
                    str.Focus();
                else if (current == str)
                    ort.Focus();
                else if (current == ort)
                {
                    // Last field - submit data
                    SaveCustomerToFile();
                    Customer.LoadCustomers("customers.txt");
                }
            }
            change_kasset(sender, e);
        }

        private void SaveCustomerToFile()
        {
            // Validate required fields in logical order
            if (string.IsNullOrWhiteSpace(knr.Text))
            {
                MessageBox.Show("KNR is required.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                knr.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(name.Text))
            {
                MessageBox.Show("Name is required.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                name.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(phone.Text))
            {
                MessageBox.Show("Phone number is required.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                phone.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(str.Text))
            {
                MessageBox.Show("Street is required.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                str.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(ort.Text))
            {
                MessageBox.Show("City is required.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                ort.Focus();
                return;
            }

            // Fill optional fields with defaults
            string bemerkung = "";
            string seit = DateTime.Now.ToString("dd.MM.yy");
            string mal = "1";
            string dm = "0,00";
            string letzte = DateTime.Now.ToString("dd.MM.yy");
            string rabatt = "0";

            string line = $"{knr.Text}\t{name.Text}\t{phone.Text}\t{str.Text}\t{ort.Text}\t{bemerkung}\t{phone.Text}\t{seit}\t{mal}\t{dm}\t{letzte}\t{rabatt}";
            string path = "customers.txt";


            try
            {
                // Check if the KNR already exists in the file
                if (File.Exists(path))
                {
                    var existingLines = File.ReadAllLines(path).ToList();

                    for (int i = 0; i < existingLines.Count; i++)
                    {
                        var fields = existingLines[i].Split('\t');
                        if (fields.Length > 0 && fields[0] == knr.Text)
                        {
                            existingLines[i] = line; // update the existing record
                            File.WriteAllLines(path, existingLines); // save changes
                            //focus on the first cell of lastOrdersTable 
                            OrdersManager.FocusCursorOnAnz(lastOrdersTable);
                            Customer.LoadCustomers("customers.txt");
                            return;
                        }
                    }
                }

                // add the record to file 
                File.AppendAllText(path, line + Environment.NewLine);
                MessageBox.Show("Kunde erfolgreich gespeichert.00", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);

                /* TODO:
                 * update the last order table by calling 
                 * move cursor on the first input box of CreateOrderForm
                 */
                OrdersManager.FocusCursorOnAnz(lastOrdersTable);
                Customer.LoadCustomers("customers.txt");

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error saving customer: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        /*menu button click*/
        private void menuButton_Click(object sender, EventArgs e)
        {
            contextMenu.Show(menuButton, new System.Drawing.Point(0, menuButton.Height));
        }

        private void menuItem1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Option 1 selected");
        }

        private void menuItem2_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Option 2 selected");
        }

        private void menuItem3_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Option 3 selected");
        }

        private void search_TextChanged(object sender, EventArgs e)
        {
            // You can leave this empty or handle other search-related functionality here

        }

        private void label4_Click(object sender, EventArgs e)
        {
            // Optional: You can remove this if it's not needed
        }

        // Optional: Remove empty label click handlers
        private void labelPhoneValue_Click(object sender, EventArgs e) { }
        private void label1_Click(object sender, EventArgs e) { }
        private void labelOrtValue_Click(object sender, EventArgs e) { }
        private void label1_Click_1(object sender, EventArgs e) { }
        private void label2_Click(object sender, EventArgs e) { }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void createOrderForm_Load(object sender, EventArgs e)
        {

        }

        private void phone_TextChanged(object sender, EventArgs e)
        {

        }

        private void knr_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(knr.Text))
            {
                LoadOrdersForCustomer(knr.Text);
            }
            else
            {
                lastOrdersTable.Rows.Clear();
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
        private void customerListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (customerListBox == null) return;

            // Prevent selecting the header (index 0)
            if (customerListBox.SelectedIndex == 0)
            {
                // Move selection to first actual item
                if (customerListBox.Items.Count > 1)
                {
                    customerListBox.SelectedIndex = 1;
                }
                else
                {
                    customerListBox.SelectedIndex = -1;
                }
                return;
            }

            if (customerListBox.SelectedIndex < 1) return;

            var input = str.Text.Trim().ToLower();
            var customers = Customer.GetAll();
            // Group customers by Name and take the first occurrence
            var filteredCustomers = customers
                .Where(c => c.Str != null && c.Str.ToLower().StartsWith(input))
                .GroupBy(c => c.Name)
                .Select(g => g.First())
                .ToList();
        }

        private int FindStreetNumberIndex(string street)
        {
            for (int i = 0; i < street.Length; i++)
            {
                if (char.IsDigit(street[i]))
                {
                    if (i > 0 && (street[i - 1] == ' ' || street[i - 1] == '-' || street[i - 1] == '.'))
                    {
                        return i;
                    }
                    else if (i == 0)
                    {
                        return i;
                    }
                }
            }
            return -1;
        }


        string ExtractStreetNameOnly(string fullStreet)
        {
            if (string.IsNullOrWhiteSpace(fullStreet))
                return "";

            fullStreet = fullStreet.Trim();

            // Find the first occurrence of a digit
            for (int i = 0; i < fullStreet.Length; i++)
            {
                if (char.IsDigit(fullStreet[i]))
                {
                    // We found the first number
                    // Return everything BEFORE this position
                    if (i == 0)
                    {
                        return ""; // Starts with a number - not a valid street name
                    }

                    string streetName = fullStreet.Substring(0, i).Trim();

                    // Clean up any trailing special characters
                    streetName = streetName.TrimEnd(' ', '.', ',', '-', '/', '\\', ':');

                    return streetName;
                }
            }

            // No numbers found - return the whole string
            return fullStreet.TrimEnd(' ', '.', ',', '-', '/', '\\', ':');
        }

        private void str_TextChanged(object sender, EventArgs e)
        {
            if (!isUserTypingStreet)
                return;

            if (customerListBox == null) return; // Safety check

            var input = str.Text.Trim();
            // If user started typing a street number, do NOT show popup
            if (input.Any(char.IsDigit))
            {
                customerListBox.Visible = false;
                return;
            }

            customerListBox.Items.Clear();
            customerListBox.Visible = false;

            if (input.Length >= 2) // Only process if at least 2 characters
            {
                var customers = Customer.GetAll();

                string Normalize(string text)
                {
                    if (string.IsNullOrWhiteSpace(text))
                        return string.Empty;

                    return new string(
                        text
                        .Trim()
                        .Normalize(NormalizationForm.FormC)
                        .Where(ch => !char.IsControl(ch)) // remove hidden chars
                        .ToArray()
                    ).ToLowerInvariant(); // case-insensitive comparison
                }
                // Group customers by Name and take the first occurrence
                var matches = customers
                    .Where(c => c.Str != null && c.Str.StartsWith(input, StringComparison.OrdinalIgnoreCase))
                    .GroupBy(c => Normalize(c.Str)) // remove duplicated addresses 
                    .Select(g => g.First())
                    .ToList();

                // Filter by input first
                var filteredCustomers = customers
                    .Where(c => c.Str != null && !string.IsNullOrWhiteSpace(c.Str) &&
                                c.Str.StartsWith(input, StringComparison.OrdinalIgnoreCase))
                    .ToList();

                // Extract street name ONLY text part (letters, spaces, dots, special chars) until first number
                

                // Group by street name only (without any numbers)
                var streetGroups = filteredCustomers
                    .Select(c => new
                    {
                        Customer = c,
                        StreetNameOnly = ExtractStreetNameOnly(c.Str)
                    })
                    .Where(x => !string.IsNullOrWhiteSpace(x.StreetNameOnly)) // Filter out empty street names
                    .GroupBy(x => x.StreetNameOnly.ToLowerInvariant()) // Case-insensitive grouping
                    .Select(g => new
                    {
                        StreetNameOnly = g.First().StreetNameOnly, // Original case from first
                        Count = g.Count(), // Number of addresses with this street name
                        FirstFullAddress = g.First().Customer.Str, // First full address
                        FirstCustomer = g.First().Customer
                    })
                    .OrderBy(g => g.StreetNameOnly) // Sort alphabetically
                    .ToList();

                // Clear and display
                customerListBox.Items.Clear();

                int index = 1;
                customerListBox.Items.Add(
                    string.Format("  {0,-8} {1,-8} {2,-35}  ",
                        "ESC=Abbruch",
                        "Eingabetaste=wählen",
                        "gefunden=" + streetGroups.Count
                    )
                );
                foreach (var group in streetGroups)
                {
                    // Format: index, count, street name (text only)
                    customerListBox.Items.Add(
                        string.Format("  {0,-8} {1,-8} {2,-35}  ",
                            index,
                            "Z="+group.Count,
                            group.StreetNameOnly
                            )
                    );
                    index++;
                }

                if (matches.Count > 0)
                {

                    customerListBox.Visible = true;

                    // Make the popup wider
                    int popupWidth = (str?.Width ?? 100) * 2;
                    customerListBox.Width = popupWidth;
                    customerListBox.Height = Math.Min(400, matches.Count * customerListBox.ItemHeight + 8); // Adjust height dynamically

                    // Center the popup on the form instead of positioning below str
                    customerListBox.Left = (this.ClientSize.Width - customerListBox.Width) / 2;
                    customerListBox.Top = (this.ClientSize.Height - customerListBox.Height) / 2;
                    customerListBox.BackColor = Color.Black;
                    customerListBox.ForeColor = Color.Yellow;
                    customerListBox.Margin = new Padding(4);
                    customerListBox.Font = new Font(FontFamily.GenericMonospace, 18, FontStyle.Bold);

                    customerListBox.BringToFront(); // Ensure highest display priority

                    if (matches.Count == 1)
                    {
                        var customer = matches[0];

                        // remove street number
                        string street = customer.Str;
                        int streetNumberIndex = FindStreetNumberIndex(street);

                        if (streetNumberIndex >= 0)
                        {
                            street = street.Substring(0, streetNumberIndex).TrimEnd() + " ";
                        }

                        str.Text = ExtractStreetNameOnly(street);
                        ort.Text = customer.Ort;
                        customerListBox.Visible = false;

                        // cursor at end (after space)
                        str.SelectionStart = str.Text.Length;
                        str.SelectionLength = 0;

                    }
                }
            }
        }

            private void str_KeyDown(object sender, KeyEventArgs e)
            {
                isUserTypingStreet = true;
                change_kasset(sender, e);
            
                if (customerListBox.Visible && customerListBox.Items.Count > 0)
                {
                
                    if (e.KeyCode == Keys.Down)
                    {
                        e.Handled = true;
                        if (customerListBox.SelectedIndex < customerListBox.Items.Count - 1)
                            customerListBox.SelectedIndex++;
                    }
                    else if (e.KeyCode == Keys.Up)
                    {
                        e.Handled = true;
                        if (customerListBox.SelectedIndex > 0)
                            customerListBox.SelectedIndex--;
                    }
                else if (e.KeyCode == Keys.Enter)
                {
                    e.Handled = true;

                    var input = str.Text.Trim().ToLower();
                    var customers = Customer.GetAll();

                    var filteredCustomers = customers
                        .Where(c => c.Str != null && !string.IsNullOrWhiteSpace(c.Str) &&
                                    c.Str.StartsWith(input, StringComparison.OrdinalIgnoreCase))
                        .ToList();

                    var streetGroups = filteredCustomers
                        .Select(c => new
                        {
                            Customer = c,
                            StreetNameOnly = ExtractStreetNameOnly(c.Str)
                        })
                        .Where(x => !string.IsNullOrWhiteSpace(x.StreetNameOnly)) // Filter out empty street names
                        .GroupBy(x => x.StreetNameOnly.ToLowerInvariant()) // Case-insensitive grouping
                        .Select(g => new
                        {
                            StreetNameOnly = g.First().StreetNameOnly, // Original case from first
                            Count = g.Count(), // Number of addresses with this street name
                            FirstFullAddress = g.First().Customer.Str, // First full address
                            FirstCustomer = g.First().Customer
                        })
                        .OrderBy(g => g.StreetNameOnly) // Sort alphabetically
                        .ToList();

                    // Adjust index for header (index 0 is header, so subtract 1)
                    int groupIndex = customerListBox.SelectedIndex - 1;

                    // Compare with streetGroups.Count (not filteredCustomers.Count)
                    if (groupIndex >= 0 && groupIndex < streetGroups.Count)
                    {
                        // Get the customer from streetGroups
                        var selectedGroup = streetGroups[groupIndex];
                        var selectedCustomer = selectedGroup.FirstCustomer;

                        str.Text = selectedCustomer.Str;
                        ort.Text = selectedCustomer.Ort;
                        customerListBox.Visible = false;

                        str.Focus();
                        // Set cursor to the street number
                        int streetNumberIndex = FindStreetNumberIndex(selectedCustomer.Str);

                        if (streetNumberIndex >= 0)
                        {
                            int endIndex = streetNumberIndex;
                            while (endIndex < selectedCustomer.Str.Length &&
                                   (char.IsLetterOrDigit(selectedCustomer.Str[endIndex]) || selectedCustomer.Str[endIndex] == ' '))
                            {
                                endIndex++;
                            }

                            // Remove the street number part
                            string updatedText =
                                selectedCustomer.Str.Remove(streetNumberIndex, endIndex - streetNumberIndex);

                            str.Text = updatedText.TrimStart();

                            // Place cursor where the number was
                            str.SelectionStart = streetNumberIndex;
                        }
                        else
                        {
                            // If no number found, place cursor at the end
                            str.SelectionStart = str.TextLength;
                        }

                    }
                }
                else if (e.KeyCode == Keys.Escape)
                    {
                        customerListBox.Visible = false;
                        e.Handled = true;
                    }
                }
            }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void personalInfoPanel_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label1_Click_2(object sender, EventArgs e)
        {

        }

        private void orderBez_TextChanged(object sender, EventArgs e)
        {

        }

        private void UpdateTotals()
        {
            try
            {
                int totalCount = 0;
                decimal totalSum = 0;
                decimal totalExtra = 0;
                decimal lastTotalDiscountValue = 0;

                // Get discount percentage using ParseDecimal
                string discountText = textBoxDiscount.Text.Trim();
                decimal lastDiscountPercentage = ParseDecimal(discountText);

                foreach (DataGridViewRow row in lastOrdersTable.Rows)
                {
                    if (row.IsNewRow) continue;

                    // --- Count items ---
                    string anzText = row.Cells["lastOrderAnz"].Value?.ToString() ?? "0";
                    int anz = (int)ParseDecimal(anzText);
                    totalCount += anz;

                    // --- Base price ---
                    string priceText = row.Cells["lastOrderPrice"].Value?.ToString() ?? "0";
                    decimal basePrice = ParseDecimal(priceText);
                    totalSum += basePrice;

                    // --- Extras per row ---
                    string extraInput = row.Cells["LastOrderExtra"].Value?.ToString()?.Trim() ?? "";
                    string sizeStr = row.Cells["lastOrderSize"].Value?.ToString() ?? "";
                    char sizeCode = !string.IsNullOrWhiteSpace(sizeStr)
                        ? char.ToUpper(sizeStr[0])
                        : 'S';

                    if (!string.IsNullOrEmpty(extraInput))
                    {
                        string expr = extraInput.Replace(" ", "");
                        if (!expr.StartsWith("+") && !expr.StartsWith("-"))
                            expr = "+" + expr;

                        var matches = System.Text.RegularExpressions.Regex.Matches(expr, @"[+-]\d+");

                        foreach (System.Text.RegularExpressions.Match match in matches)
                        {
                            string token = match.Value;
                            bool isPositive = token.StartsWith("+");
                            int extraId = int.Parse(token.Substring(1));

                            var extraObj = ExtrasManager.GetExtraByIdCode(extraId, sizeCode);
                            if (extraObj != null)
                            {
                                if (isPositive)
                                    totalExtra += (decimal)extraObj.Price;
                                else
                                    totalExtra -= (decimal)extraObj.Price;
                            }
                        }
                    }
                }

                // --- Calculate discount ---
                lastTotalDiscountValue = ((totalSum + totalExtra) * lastDiscountPercentage) / 100;

                // --- Update labels with German format (1,20) ---
                labelCountValue.Text = totalCount.ToString();

                decimal brutto = totalSum + totalExtra;
                decimal netto = brutto - lastTotalDiscountValue;

                // Always display with German format: 1,20
                labelSumValue.Text = $"€{netto.ToString("F2").Replace(".", ",")}";
                labelLastDiscountValue.Text = $"(- €{Math.Abs(lastTotalDiscountValue).ToString("F2").Replace(".", ",")})";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error calculating totals: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void textBoxDiscount_TextChanged(object sender, EventArgs e)
        {
            UpdateTotals();
        }

        private void change_kasset(object sender, KeyEventArgs e)
        {
            if (e.Control && (e.KeyCode == Keys.NumPad1 || e.KeyCode == Keys.D1))
            {
                //var result = MessageBox.Show(
                //    "Möchten Sie wirklich zur Kasse 1 wechseln? Y/N",
                //    "Bestätigen",
                //    MessageBoxButtons.YesNo,
                //    MessageBoxIcon.Question
                //);

                //if (result == DialogResult.Yes)
                //{
                labelPRValue.Text = "1";
                LoadArticlesForCurrentKasse();
                //}
            }
            else if (e.Control && (e.KeyCode == Keys.NumPad2 || e.KeyCode == Keys.D2))
            {
                //var result = MessageBox.Show(
                //    "Möchten Sie wirklich zur Kasse 2 wechseln? Y/N",
                //    "Bestätigen",
                //    MessageBoxButtons.YesNo,
                //    MessageBoxIcon.Question
                //);

                //if (result == DialogResult.Yes)
                //{
                    labelPRValue.Text = "2";
                    LoadArticlesForCurrentKasse();
                //}
            }
        }


        private void hanle_keys(object sender, KeyEventArgs e)
        {
            // change kasset
            change_kasset(sender, e);
            // all keys should work 
            var key = e.KeyCode;
            if (key == Keys.F2)
            {
                ClearAllStoredData();
                this.search.Focus();
            }
            else if (key == Keys.F3)
            {
                extras.Clear();
                this.name.Focus();
            }
            else if (key == Keys.Back)
            {
                // Check if sender is a TextBox
                if (sender is TextBox tb)
                {
                    // If textbox still has content → do nothing
                    if (!string.IsNullOrEmpty(tb.Text))
                        return;
                }
                this.textBoxDiscount.Clear();
                this.textBoxDiscount.Text = "0";
                this.labelLastDiscountValue.Text = "0";
                this.extras.Clear();
                this.lastOrdersTable.Focus();
            }
            else if (key == Keys.F1)
            {
                extras.Clear();
                this.lastOrdersTable.Focus();
            }
            else if (key == Keys.F9)
            {
                var customer = Customer.FindByKNr(this.knr.Text);
                PrintOrder(lastOrdersTable, customer); // pass your customer and DGV
            } else if (key == Keys.Escape)
            {
                customerListBox.Visible = false;
            }
        }

        private void ClearAllStoredData()
        {
            // Clear search field
            search.Text = "";

            // Clear discount fields
            textBoxDiscount.Text = "0";
            labelLastDiscountValue.Text = "0";
            labelSumValue.Text = "€0.00";
            labelCountValue.Text = "0";

            // Clear extras list
            extras.Clear();

            // Clear orders table
            lastOrdersTable.Rows.Clear();

            // Hide popups
            customerListBox.Visible = false;
            searchListBox.Visible = false;

            // Clear tags
            searchListBox.Tag = null;

            // Reset totals
            UpdateTotals();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FormDatabaseManager f = new FormDatabaseManager();
            f.ShowDialog(); // modal popup
        }

        private void mouse_enter(object sender, EventArgs e)
        {
            btnMenu.Cursor = Cursors.Hand;
            btnMenu.BackColor = Color.FromArgb(192, 0, 192);
            btnMenu.ForeColor = Color.Cyan;
        }

        private void mouse_leave(object sender, EventArgs e)
        {
            btnMenu.BackColor = Color.White;
            btnMenu.ForeColor = Color.Black;
        }
    }
}
