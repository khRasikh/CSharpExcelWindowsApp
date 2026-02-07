using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace TestAddIn.orders
{
    public class Order
    {
        public string KNr { get; set; }
        public string Anz { get; set; }
        public string Nr { get; set; }
        public string Bez { get; set; }
        public string Size { get; set; }
        public string Extra { get; set; }
        public string Price { get; set; }
        public string Rabbat { get; set; }
    }

    public static class OrdersManager
    {
        private static List<Order> orders = new List<Order>();

        public static void LoadOrders(string filePath)
        {
            orders.Clear();

            if (!File.Exists(filePath))
            {
                MessageBox.Show("File not found: " + filePath);
                return;
            }

            try
            {
                var lines = File.ReadAllLines(filePath);

                foreach (var line in lines.Skip(1)) // Skip header
                {
                    if (string.IsNullOrWhiteSpace(line))
                        continue;

                    // Normalize whitespace: Replace tabs with single space, then split
                    var normalizedLine = Regex.Replace(line.Trim(), @"\s+", "\t");
                    var columns = normalizedLine.Split('\t');

                    if (columns.Length >= 8)
                    {
                        var order = new Order
                        {
                            KNr = columns[0],
                            Anz = columns[1],
                            Nr = columns[2],
                            Bez = columns[3],
                            Size = columns[4].ToUpper(),
                            Extra = columns[5].Replace("€", "").Trim(),
                            Price = columns[6].Replace("€", "").Trim(),
                            Rabbat = columns[7].Replace("%", "").Trim()
                        };

                        orders.Add(order);
                    }
                    else
                    {
                        MessageBox.Show($"Invalid line format:\n{line}");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading orders: " + ex.Message);
            }
        }


        public static void SaveOrders(string filePath, string knr, IEnumerable<Order> ordersForKnr)
        {
            if (string.IsNullOrWhiteSpace(knr))
            {
                MessageBox.Show("KNr darf nicht leer sein.");
                return;
            }

            var list = (ordersForKnr ?? Enumerable.Empty<Order>()).ToList();
            if (list.Count == 0)
            {
                //MessageBox.Show("Keine Bestellungen zum Speichern vorhanden.");
                return;
            }

            if (list.Any(o => !string.Equals(o.KNr, knr, StringComparison.Ordinal)))
            {
                //MessageBox.Show("Alle Bestellzeilen müssen die gleiche KNr besitzen.");
                return;
            }

            if (list.Any(o => string.IsNullOrWhiteSpace(o.Rabbat)))
            {
                MessageBox.Show("Rabbat darf nicht leer sein.");
                return;
            }

            try
            {
                // Datei laden und ALLE bisherigen Zeilen dieser KNr entfernen (robust über Spaltenvergleich)
                var lines = File.Exists(filePath)
                    ? File.ReadAllLines(filePath)
                          .Where(l =>
                          {
                              if (string.IsNullOrWhiteSpace(l)) return false; // leere raus
                              var cols = l.Split('\t');
                              if (cols.Length == 0) return true;
                              var firstCol = cols[0].Trim();
                              return !string.Equals(firstCol, knr, StringComparison.Ordinal);
                          })
                          .ToList()
                    : new List<string>();

                // Neue Zeilen anhängen (eine oder mehrere)
                foreach (var o in list)
                    lines.Add(ToLine(o));

                // Datei überschreiben
                File.WriteAllLines(filePath, lines);

                // In-Memory aktualisieren
                orders.RemoveAll(o => string.Equals(o.KNr, knr, StringComparison.Ordinal));
                orders.AddRange(list);

                //MessageBox.Show("Die Bestellung(en) wurden erfolgreich gespeichert/ersetzt.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Fehler beim Speichern: " + ex.Message);
            }
        }

        // Komfort-Overload: Einzelzeile -> ersetzt alle Zeilen dieser KNr durch genau diese eine
        public static void SaveOrder(string filePath, Order order)
        {
            if (order == null)
            {
                MessageBox.Show("Order ist null.");
                return;
            }
            SaveOrders(filePath, order.KNr, new[] { order });
        }

        private static string ToLine(Order o)
        {
            string S(string s) => (s ?? "").Replace("\t", " "); // Tabs entschärfen
            string N(object n) => n?.ToString() ?? "";

            return string.Join("\t", new[]
            {
            S(o.KNr),
            N(o.Anz),
            N(o.Nr),
            S(o.Bez),
            S(o.Size),
            S(o.Extra),
            S(o.Price),
            S(o.Rabbat)
        });
        }
        public static void FocusCursorOnAnz(DataGridView lastOrdersTable)
        {
            if (lastOrdersTable.Rows.Count > 0)
            {
                // Skip the new row at the bottom
                int rowIndex = lastOrdersTable.Rows.Count - 1;
                if (lastOrdersTable.Rows[rowIndex].IsNewRow && rowIndex > 0)
                    rowIndex--;

                // Focus the first cell of the row
                lastOrdersTable.CurrentCell = lastOrdersTable.Rows[rowIndex].Cells[0];
                lastOrdersTable.Focus();
            }
        }

        public static int GetLastDiscount(string KNr, string filePath)
        {
            int discount = 0;

            if (!File.Exists(filePath))
            {
                MessageBox.Show("File not found: " + filePath);
                return discount;
            }

            try
            {
                var lines = File.ReadAllLines(filePath);

                foreach (var line in lines.Skip(1)) // Skip header
                {
                    if (string.IsNullOrWhiteSpace(line))
                        continue;

                    // Normalize whitespace and split by tab
                    var normalizedLine = Regex.Replace(line.Trim(), @"\s+", "\t");
                    var columns = normalizedLine.Split('\t');

                    if (columns.Length >= 8)
                    {
                        string rowKNr = columns[0];
                        string rabbatStr = columns[7].Replace("%", "").Trim();

                        if (rowKNr == KNr && !string.IsNullOrWhiteSpace(rabbatStr))
                        {
                            int.TryParse(rabbatStr, out discount);
                            break; // Found the first match, exit
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error getting last discount: " + ex.Message);
            }

            return discount;
        }

        public static List<Order> GetAll()
        {
            return orders;
        }

        public static void Clear()
        {
            orders.Clear();
        }


        public static void DeleteOrder(string knr, string anz, string nr, string bez)
        {
            var lines = File.ReadAllLines("orders.txt").ToList();

            lines = lines.Where(line =>
            {
                var parts = line.Split('\t');
                if (parts.Length < 7) return true;

                // Compare exact row
                return !(parts[0] == knr &&
                         parts[1] == anz &&
                         parts[2] == nr &&
                         parts[3] == bez);
            }).ToList();

            File.WriteAllLines("orders.txt", lines);
        }
    }
}
