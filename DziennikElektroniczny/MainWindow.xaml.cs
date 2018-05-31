using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using DziennikElektroniczny.Model;
using System.IO;

namespace DziennikElektroniczny
{
    /// <summary>
    /// Logika interakcji dla klasy MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            var db = new DziennikContext();
            StreamWriter file = new StreamWriter("log.txt");
            db.Database.Log = (s) => file.WriteLine(s);
            //file.WriteLine(db.Database.Log);
        }

        private void zapiszOceneCzastkowa_Click(object sender, RoutedEventArgs e)
        {
            if (wyborUcznia.SelectedItem != null)
            {
                using (var db = new DziennikContext())
                {
                    var id = (from u in db.DaneUczniów
                              where u.Imię == wyborUcznia.SelectedItem
                              select u.u_id).First();
                    db.OcenyCząstkowe.Add(
                        new OcenyCząstkowe { DataOceny = DateTime.Now, Ocena = Int32.Parse(ocenaCzastkowa.Text), u_id = id, RodzajOceny = rodzajOceny.Text }
                        );
                    db.SaveChanges();
                }
            }
        }

        private void nieobecny_Click(object sender, RoutedEventArgs e)
        {
            if (wyborUcznia.SelectedItem != null)
            {
                using (var db = new DziennikContext())
                {
                    var id = (from u in db.DaneUczniów
                              where u.Imię == wyborUcznia.SelectedItem
                              select u.u_id).First();
                    db.Frekwencja.Add(
                        new Frekwencja { u_id = id, DataZajęć = DateTime.Now, Obecność = false }
                        );
                    db.SaveChanges();
                }
            }       
        }

        private void obecny_Click(object sender, RoutedEventArgs e)
        {
            if (wyborUcznia.SelectedItem != null)
            {
                using (var db = new DziennikContext())
                {
                    var id = (from u in db.DaneUczniów
                              where u.Imię == wyborUcznia.SelectedItem
                              select u.u_id).First();
                    db.Frekwencja.Add(
                        new Frekwencja { u_id = id, DataZajęć = DateTime.Now, Obecność = true }
                        );
                    db.SaveChanges();
                }
            }     
        }

        private void zapiszOcenęKońcową_Click(object sender, RoutedEventArgs e)
        {
            if (wyborUcznia.SelectedItem != null)
            {
                using (var db = new DziennikContext())
                {
                    var id = (from u in db.DaneUczniów
                              where u.Imię == wyborUcznia.SelectedItem
                              select u.u_id).First();
                    var query = (from s in db.StatystykaKońcowa
                                where s.u_id == id
                                select s);
                    if (query == null)
                    {
                        db.StatystykaKońcowa.Add(
                        new StatystykaKońcowa { u_id = id, OcenaKońcowa = Int32.Parse(ocenaKońcowa.Text), Średnia = Convert.ToDecimal(średnia.Text), Frekwencja = Int32.Parse(frekwencja.Text) }
                        );
                    }
                    else
                    {
                        query.First().OcenaKońcowa = Int32.Parse(ocenaKońcowa.Text);
                        query.First().Średnia = Convert.ToDecimal(średnia.Text);
                        query.First().Frekwencja = Int32.Parse(frekwencja.Text);
                    }
                    db.SaveChanges();
                }
            }        
        }
    }
}
