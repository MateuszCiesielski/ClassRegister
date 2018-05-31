namespace DziennikElektroniczny.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using DziennikElektroniczny.Model;
    using System.Drawing;
    using System.IO;

    internal sealed class Configuration : DbMigrationsConfiguration<DziennikElektroniczny.Model.DziennikContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        public byte[] ImageToByteArray (Image img)
        {
            MemoryStream ms = new MemoryStream();
            img.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
            return ms.ToArray();
        }

        protected override void Seed(DziennikElektroniczny.Model.DziennikContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //

            Image imgB = Image.FromFile("C:\\Users\\Mateusz\\Desktop\\DziennikElektroniczny\\blue.jpg");
            Image imgG = Image.FromFile("C:\\Users\\Mateusz\\Desktop\\DziennikElektroniczny\\green.jpg");
            Image imgR = Image.FromFile("C:\\Users\\Mateusz\\Desktop\\DziennikElektroniczny\\red.jpg");
            
            /*context.Klasy.AddOrUpdate(
                new Klasy { SymbolKlasy = "5A", Profil = "zwykly", Wychowawca = "Jaroslaw Nowak" },
                new Klasy { SymbolKlasy = "5B", Profil = "matematyczny", Wychowawca = "Jan Kowalski" },
                new Klasy { SymbolKlasy = "5C", Profil = "informatyczny", Wychowawca = "Marcin Marcinski" }
                );

            context.DaneUczniów.AddOrUpdate(
                new DaneUczniów { Imiê = "Adam Nowak", AdresZamieszkania = "Dworcowa 7, 11-111 Poznan", DataUrodzenia = new DateTime(1995, 02, 22), DataRozpoczêciaNauki = new DateTime(2015, 09, 01), k_id = 2, Zdjêcie = ImageToByteArray(imgB) },
                new DaneUczniów { Imiê = "Jacek Jan", AdresZamieszkania = "Dluga 8, 11-121 Poznan", DataUrodzenia = new DateTime(1995, 10, 24), DataRozpoczêciaNauki = new DateTime(2015, 09, 01), k_id = 2, Zdjêcie = ImageToByteArray(imgR) },
                new DaneUczniów { Imiê = "Marcin Wawel", AdresZamieszkania = "Elitarna 7, 11-134 Poznan", DataUrodzenia = new DateTime(1995, 06, 12), DataRozpoczêciaNauki = new DateTime(2015, 09, 01), k_id = 2, Zdjêcie = ImageToByteArray(imgG) },
                new DaneUczniów { Imiê = "Karol Pawlacz", AdresZamieszkania = "Dworcowa 16, 11-111 Poznan", DataUrodzenia = new DateTime(1995, 08, 15), DataRozpoczêciaNauki = new DateTime(2015, 09, 01), k_id = 1, Zdjêcie = ImageToByteArray(imgR) },
                new DaneUczniów { Imiê = "Wawrzyniec Aloes", AdresZamieszkania = "Krotka 8, 11-101 Poznan", DataUrodzenia = new DateTime(1995, 06, 13), DataRozpoczêciaNauki = new DateTime(2015, 09, 01), k_id = 1, Zdjêcie = ImageToByteArray(imgG) },
                new DaneUczniów { Imiê = "Waldemar Trymski", AdresZamieszkania = "Szkocka 6, 11-134 Poznan", DataUrodzenia = new DateTime(1995, 06, 12), DataRozpoczêciaNauki = new DateTime(2015, 09, 01), k_id = 1, Zdjêcie = ImageToByteArray(imgB) }
                );*/

            /*context.Frekwencja.AddOrUpdate(
                new Frekwencja { DataZajêæ = new DateTime(2017, 03, 02), u_id = 1, Obecnoœæ = true },
                new Frekwencja { DataZajêæ = new DateTime(2017, 03, 02), u_id = 2, Obecnoœæ = true },
                new Frekwencja { DataZajêæ = new DateTime(2017, 03, 02), u_id = 3, Obecnoœæ = false },
                new Frekwencja { DataZajêæ = new DateTime(2017, 03, 02), u_id = 4, Obecnoœæ = false },
                new Frekwencja { DataZajêæ = new DateTime(2017, 03, 02), u_id = 5, Obecnoœæ = true },
                new Frekwencja { DataZajêæ = new DateTime(2017, 03, 02), u_id = 6, Obecnoœæ = true },
                //---
                new Frekwencja { DataZajêæ = new DateTime(2017, 03, 03), u_id = 1, Obecnoœæ = true },
                new Frekwencja { DataZajêæ = new DateTime(2017, 03, 03), u_id = 2, Obecnoœæ = true },
                new Frekwencja { DataZajêæ = new DateTime(2017, 03, 03), u_id = 3, Obecnoœæ = true },
                new Frekwencja { DataZajêæ = new DateTime(2017, 03, 03), u_id = 4, Obecnoœæ = false },
                new Frekwencja { DataZajêæ = new DateTime(2017, 03, 03), u_id = 5, Obecnoœæ = true },
                new Frekwencja { DataZajêæ = new DateTime(2017, 03, 03), u_id = 6, Obecnoœæ = false },
                //---
                new Frekwencja { DataZajêæ = new DateTime(2017, 03, 04), u_id = 1, Obecnoœæ = true },
                new Frekwencja { DataZajêæ = new DateTime(2017, 03, 04), u_id = 2, Obecnoœæ = true },
                new Frekwencja { DataZajêæ = new DateTime(2017, 03, 04), u_id = 3, Obecnoœæ = false },
                new Frekwencja { DataZajêæ = new DateTime(2017, 03, 04), u_id = 4, Obecnoœæ = true },
                new Frekwencja { DataZajêæ = new DateTime(2017, 03, 04), u_id = 5, Obecnoœæ = false },
                new Frekwencja { DataZajêæ = new DateTime(2017, 03, 04), u_id = 6, Obecnoœæ = true }
                );

            context.OcenyCz¹stkowe.AddOrUpdate(
                new OcenyCz¹stkowe { DataOceny = new DateTime(2017, 03, 02), u_id = 1, Ocena = 4, RodzajOceny = "sprawdzian" },
                new OcenyCz¹stkowe { DataOceny = new DateTime(2017, 03, 02), u_id = 2, Ocena = 5, RodzajOceny = "sprawdzian" },
                new OcenyCz¹stkowe { DataOceny = new DateTime(2017, 03, 02), u_id = 3, Ocena = 4, RodzajOceny = "sprawdzian" },
                new OcenyCz¹stkowe { DataOceny = new DateTime(2017, 03, 02), u_id = 4, Ocena = 3, RodzajOceny = "sprawdzian" },
                new OcenyCz¹stkowe { DataOceny = new DateTime(2017, 03, 02), u_id = 5, Ocena = 2, RodzajOceny = "sprawdzian" },
                new OcenyCz¹stkowe { DataOceny = new DateTime(2017, 03, 02), u_id = 6, Ocena = 1, RodzajOceny = "sprawdzian" },
                //---
                new OcenyCz¹stkowe { DataOceny = new DateTime(2017, 02, 02), u_id = 1, Ocena = 4, RodzajOceny = "kartkowka" },
                new OcenyCz¹stkowe { DataOceny = new DateTime(2017, 02, 02), u_id = 2, Ocena = 5, RodzajOceny = "kartkowka" },
                new OcenyCz¹stkowe { DataOceny = new DateTime(2017, 02, 02), u_id = 3, Ocena = 4, RodzajOceny = "kartkowka" },
                new OcenyCz¹stkowe { DataOceny = new DateTime(2017, 02, 01), u_id = 4, Ocena = 3, RodzajOceny = "kartkowka" },
                new OcenyCz¹stkowe { DataOceny = new DateTime(2017, 02, 01), u_id = 5, Ocena = 2, RodzajOceny = "kartkowka" },
                new OcenyCz¹stkowe { DataOceny = new DateTime(2017, 02, 01), u_id = 6, Ocena = 1, RodzajOceny = "kartkowka" },
                //---
                new OcenyCz¹stkowe { DataOceny = new DateTime(2017, 02, 01), u_id = 1, Ocena = 5, RodzajOceny = "aktywnosc" },
                new OcenyCz¹stkowe { DataOceny = new DateTime(2017, 02, 01), u_id = 4, Ocena = 5, RodzajOceny = "aktywnosc" },
                new OcenyCz¹stkowe { DataOceny = new DateTime(2017, 02, 01), u_id = 6, Ocena = 5, RodzajOceny = "aktywnosc" }
                );*/
        }
    }
}
