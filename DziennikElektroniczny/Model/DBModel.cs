using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DziennikElektroniczny.Model
{
    public class Klasy
    {
        [Key]
        public int k_id { get; set; }
        public string SymbolKlasy { get; set; }
        public string Wychowawca { get; set; }
        public string Profil { get; set; }

        // --- relacje ---
        public virtual List<DaneUczniów> DaneUczniów { get; set; }
    }

    public class DaneUczniów
    {
        [Key]
        public int u_id { get; set; }
        public string Imię { get; set; }
        public DateTime DataUrodzenia { get; set; }
        public string AdresZamieszkania { get; set; }
        public byte[] Zdjęcie { get; set; }
        public int k_id { get; set; }
        public DateTime DataRozpoczęciaNauki { get; set; }

        // --- relacje ---
        public virtual Klasy Klasa { get; set; }

        public virtual List<Frekwencja> Frekwencja { get; set; }
        public virtual List<OcenyCząstkowe> OcenyCząstkowe { get; set; }
        public virtual List<StatystykaKońcowa> StatystykaKońcowa { get; set; }
    }

    public class Frekwencja
    {
        [Key]
        public int f_id { get; set; }
        public DateTime DataZajęć { get; set; }
        public int u_id { get; set; }
        public bool Obecność { get; set; }

        // --- relacje ---
        public virtual DaneUczniów Uczeń { get; set; }
    }

    public class OcenyCząstkowe
    {
        [Key]
        public int oc_id { get; set; }
        public DateTime DataOceny { get; set; }
        public int u_id { get; set; }
        public int Ocena { get; set; }
        public string RodzajOceny { get; set; }

        // --- relacje ---
        public virtual DaneUczniów Uczeń { get; set; }
    }

    public class StatystykaKońcowa
    {
        [Key]
        public int s_id { get; set; }
        public int u_id { get; set; }
        public decimal Średnia { get; set; }
        public int Frekwencja { get; set; }
        public int OcenaKońcowa { get; set; }

        // --- relacje ---
        public virtual DaneUczniów Uczeń { get; set; }
    }

    public class DziennikContext : DbContext
    {
        public DbSet<Klasy> Klasy { get; set; }
        public DbSet<DaneUczniów> DaneUczniów { get; set; }
        public DbSet<OcenyCząstkowe> OcenyCząstkowe { get; set; }
        public DbSet<Frekwencja> Frekwencja { get; set; }
        public DbSet<StatystykaKońcowa> StatystykaKońcowa { get; set; }
    }
}
