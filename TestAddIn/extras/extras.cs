using System;
using System.Collections.Generic;
using System.Linq;

namespace TestAddIn.extras
{
    // Represents one item in extra.json
    public class Extras
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
    }

    public class ExtraItem
    {
        public int id { get; set; }
        public string name { get; set; }
        public decimal SinglPreis { get; set; }
        public decimal JumboPreis { get; set; }
        public decimal FamilyPreis { get; set; }
        public decimal PartyPreis { get; set; }
    }

    // Helper class to manage all extras
    public static class ExtrasManager
    {
        private static readonly object _lock = new object();
        private static List<ExtraItem> _extras = new List<ExtraItem>();

        public static void LoadExtras(string jsonFilePath)
        {
            lock (_lock)
            {
                if (!System.IO.File.Exists(jsonFilePath)) return;

                string json = System.IO.File.ReadAllText(jsonFilePath);
                _extras = Newtonsoft.Json.JsonConvert.DeserializeObject<List<ExtraItem>>(json) ?? new List<ExtraItem>();
            }
        }

        // Get an extra by ID
        public static Extras GetExtraByIdCode(int id, char sizeCode)
        {
            lock (_lock)
            {
                var ob = _extras.Find(x => x.id == id);
                if (ob == null) return null;

                decimal price;
                switch (char.ToUpper(sizeCode))
                {
                    case 'S':
                        price = ob.SinglPreis;
                        break;
                    case 'J':
                        price = ob.JumboPreis;
                        break;
                    case 'F':
                        price = ob.FamilyPreis;
                        break;
                    case 'P':
                        price = ob.PartyPreis;
                        break;
                    default:
                        price = ob.SinglPreis; // fallback to Single price
                        break;
                }

                return new Extras
                {
                    Id = ob.id,
                    Name = ob.name,
                    Price = price
                };
            }
        }

        // Optional: Get price by size code
        public static decimal GetPrice(ExtraItem item, char sizeCode)
        {
            lock (_lock)
            {
                switch (char.ToUpper(sizeCode))
                {
                    case 'S': return item.SinglPreis;
                    case 'J': return item.JumboPreis;
                    case 'F': return item.FamilyPreis;
                    case 'P': return item.PartyPreis;
                    default: return item.SinglPreis; // default to Single
                }
            }
        }

        // Optional: Get all extras
        public static List<ExtraItem> GetAllExtras()
        {
            lock (_lock)
            {
                return _extras;
            }
        }

        public static List<dynamic> GetAll()
        {
            lock (_lock)
            {
                return _extras.Select(x => new
                {
                    Id = x.id,
                    Code = x.id,             // Code = id (your JSON structure has no separate "code")
                    Name = x.name,
                    SinglPreis = x.SinglPreis,
                    JumboPreis = x.JumboPreis,
                    FamilyPreis = x.FamilyPreis,
                    PartyPreis = x.PartyPreis
                }).ToList<dynamic>();
            }
        }
    }
}