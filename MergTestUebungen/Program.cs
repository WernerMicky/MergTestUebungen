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

            List<currencies> all = LiefereMirAlleWährungen();
            foreach (var item in all)
            {
                Console.WriteLine($" currid { item.currid} , name {item.name}");
            }



            string lk = "GBP";
            currencies ein = LiefereMirDieWährung(lk);
            Console.WriteLine($"currid { ein.currid} , name { ein.name} ");

            List<Ergebnis> innerJo = LiefertDenJoin();

            foreach (var item in innerJo)
            {
                Console.WriteLine($"compname: {item.compname} contact: {item.contact} city: {item.city} country: {item.country} currid: {item.currid}");

            }

            Ergebnis zwei = LiefertDenJoinMitWhere();

            Console.WriteLine($"compname: {zwei.compname} contact: {zwei.contact} city: {zwei.city} country: {zwei.country} currid: {zwei.currid}");

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

        static currencies LiefereMirDieWährung(string lk)
        {
            currencies all;
            using (SalesEntities e = new SalesEntities())
            {
                all = e.currencies.Where(m => m.currid == lk).FirstOrDefault();
            }
            return all;
        }


        static List<currencies> LiefereMirAlleWährungen()
        {
            List<currencies> all;
            using (SalesEntities e = new SalesEntities())
            {
                all = e.currencies.Take(10).ToList();
            }
            return all;
        }


        static List<Ergebnis> LiefertDenJoin()
        {
            List<Ergebnis> innerJoin;
            using (SalesEntities e = new SalesEntities())
            {
                Ergebnis c = new Ergebnis();
                innerJoin = (from ku in e.customers
                             join w in e.currencies
                             on ku.currid equals w.currid
                             select new Ergebnis
                             {
                                 contact = ku.contact,
                                 compname = ku.compname,
                                 country = ku.country,
                                 city = ku.city,
                                 currid = w.currid
                             }).ToList();
            }
            return innerJoin;
        }

        static Ergebnis LiefertDenJoinMitWhere()
        {
            Ergebnis ein;
            using (SalesEntities e = new SalesEntities())
            {

                Ergebnis c = new Ergebnis();
                ein = (from ku in e.customers
                       join w in e.currencies
                       on ku.currid equals w.currid
                       select new Ergebnis
                       {
                           contact = ku.contact,
                           compname = ku.compname,
                           country = ku.country,
                           city = ku.city,
                           currid = w.currid
                       }).Where(m => m.currid == "GBP").FirstOrDefault();
            }
            return ein;
        }
    }
    class Ergebnis
    {
        public string compname { get; set; }
        public string contact { get; set; }
        public string city { get; set; }
        public string country { get; set; }
        public string currid { get; set; }
    }
}
