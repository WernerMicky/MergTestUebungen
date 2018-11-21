﻿using System;
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
            Console.WriteLine();
            Console.WriteLine($"Hier ist der eine  currid { ein.currid} , name { ein.name} ");
            Console.WriteLine();



            List<Ergebnis> innerJo = LiefertDenJoin();

            foreach (var item in innerJo)
            {
                Console.WriteLine($"{item.compname} contact: {item.contact} city: {item.city} country: {item.country} currid: {item.currid}");

            }

            Ergebnis zwei = LiefertDenJoinMitWhere();

            Console.WriteLine($"compname: {zwei.compname} contact: {zwei.contact} city: {zwei.city} country: {zwei.country} currid: {zwei.currid}");

            Console.WriteLine(getTheUserName());

            List<string> c = new List<string>();

            c.AddRange(getTheUserListNameList());

            foreach (var item in c)
            {
                Console.WriteLine(item);
            }

            var y = getTheUserListName();

            List<string> k = new List<string>();
            k.AddRange(y.Take(5));

            Console.WriteLine("hallo " + k[1]);


            Console.WriteLine("ToLookup");

            var cut = GetAllCustomers();
            cut.ToLookup(l => l.Countryname);

            foreach (var item in cut)
            {
                Console.WriteLine($"ID {item.ID} und   Name: {item.Countryname}");
            }

            string z = "hallo ich wollte nur mal fragen, hallo hier ist ein Test";

            int i = z.WordCount();

            z = z.UppercaseFirstLetter();
            Console.WriteLine(z);
            Console.WriteLine();
            Console.WriteLine(i);
            Console.WriteLine();

            string a = "eins", b = "20", f = "30", d = "1.080,10", m= "80,3";
            Console.WriteLine(a.TryToIntager());
            Console.WriteLine(b.TryToIntager());
            Console.WriteLine(f.TryToIntager());
            Console.WriteLine(d.TryToIntager());
            Console.WriteLine();
            Console.WriteLine(b.TryToDouble());
            Console.WriteLine(a.TryToDouble());
            Console.WriteLine(m.TryToDouble());
            Console.WriteLine(d.TryToDouble());

            double w = 2.4;
            Console.WriteLine(w);

            string[] values = { "1,643.57", "$1,643.57", "-1.643e6",
                          "-168934617882109132", "123AE6",
                          null, String.Empty, "ABCDEF" };
            double number;

            foreach (var value in values)
            {
                if (Double.TryParse(value, out number))
                    Console.WriteLine("'{0}' --> {1}", value, number);
                else
                    Console.WriteLine("Unable to parse '{0}'.", value);
            }

            string h = "344372505920619";

            if (h.IsACreditcard())
            {
                Console.WriteLine("Es ist eine Kreditkarte");
            }
            string x = "34437250592061";

            if (x.IsACreditcard())
            {
                Console.WriteLine("Es ist eine Kreditkarte");
            }
            else
            {
                Console.WriteLine("Es ist keine Kreditkarte");
            }

            Console.ReadKey();

        }

        static string getTheUserName()
        {
            string x = string.Empty;
            using (SalesEntities e = new SalesEntities())
            {
                x = e.customers.Where(m => m.currid == "EUR").Select(m => m.compname).FirstOrDefault();
            }
            return x;
        }

        static IEnumerable<string> getTheUserListName()
        {
            var x = new List<string>();
            using (SalesEntities e = new SalesEntities())
            {

                x = e.customers.Where(m => m.currid == "EUR").Select(m => m.compname).ToList();          
                
            }
            return x;
        }

        static List<string> getTheUserListNameList()
        {
            List<string> x = null;
            using (SalesEntities e = new SalesEntities())
            {
                x = new List<string>();
                x = e.customers.Where(m => m.currid == "EUR").Select(m => m.compname).DefaultIfEmpty().ToList();
            }
            return x;
        }

        static IEnumerable<Name> GetAllCustomers()
        {
            var y = new List<Name>();        
            using (SalesEntities e = new SalesEntities())
            {
                y = e.customers.Select(s => new Name { Countryname = s.compname, ID = (int)s.custid}).ToList();
            }
            return y;

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
                all = e.currencies.Take(5).ToList();
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

    class Name
    {
        public int ID { get; set; }
        public string  Countryname { get; set; }
    }
}
