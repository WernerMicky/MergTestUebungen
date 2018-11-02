using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MergTestUebungen.DatenBank;

namespace MergTestUebungen
{
    class Program
    {
        static void Main(string[] args)
        {
            List<customers> alle = LiefereMirAlleKunden();
            foreach (var item in alle)
            {
                Console.WriteLine($"custid: {item.custid } compname: {item.compname} contact: {item.contact} city: {item.city } country: {item.country}");
            }

            Console.ReadKey();


        }
        static List<customers> LiefereMirAlleKunden()
        {
            List<customers> all = null;
            using (SalesEntities e = new SalesEntities())
            {
                all = new List<customers>();
                all = e.customers.ToList();
            }
            return all;
        }
    }
    class Customers
    {
        public long custid { get; set; }
        public string compname { get; set; }
        public string contact { get; set; }
        public string city { get; set; }
        public string country { get; set; }
        public string currid { get; set; }
        public short discount { get; set; }
    }
}
