using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using DziennikElektroniczny.Model;
using System.Windows.Media.Imaging;
using System.IO;

namespace DziennikElektroniczny
{
    public class NameToImageConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
                if (value != null)
                {
                     using (var db = new DziennikContext())
                     {
                         var query = (from u in db.DaneUczniów
                                      where u.Imię == (string)value
                                      select u.Zdjęcie).First();
                         MemoryStream ms = new MemoryStream(query);
                         BitmapImage bmp = new BitmapImage();
                         bmp.BeginInit();
                         ms.Seek(0, SeekOrigin.Begin);
                         bmp.StreamSource = ms;
                         bmp.EndInit();
                         return (BitmapImage)bmp;
                     }  
                }
                else return null;
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }

    public class SelectedLoginToNameConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (value != null)
            {
                using (var db = new DziennikContext())
                {
                    var query = (from u in db.DaneUczniów
                                 join k in db.Klasy on u.k_id equals k.k_id
                                 where k.Wychowawca == (string)value
                                 select u.Imię.ToString()).ToList();            
                    return (List<string>)query;
                }
            }
            else return null;
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }

    public class SelectedNameToData : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (value != null)
            {
                using (var db = new DziennikContext())
                {
                    string ret = (string)value;
                    ret += "\nAdres zamieszkania: ";
                    var query = (from u in db.DaneUczniów
                                 where u.Imię == (string)value
                                 select u.AdresZamieszkania.ToString()).First();
                    ret += query + "\nData urodzenia: ";
                    query = (from u in db.DaneUczniów
                             where u.Imię == (string)value
                             select u.DataUrodzenia.ToString()).First();
                    ret += query + "\nData rozpoczecia nauki: ";
                    query = (from u in db.DaneUczniów
                             where u.Imię == (string)value
                             select u.DataRozpoczęciaNauki.ToString()).First();
                    ret += query;
                    return ret;
                }
            }
            else return null;
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }

    public class SelectedNameToAverage : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (value != null)
            {
                using (var db = new DziennikContext())
                {
                    var query = (from u in db.DaneUczniów
                                 join o in db.OcenyCząstkowe on u.u_id equals o.u_id
                                 where u.Imię == (string)value
                                 group o by o.u_id into g
                                 select g.Average(x => x.Ocena)).First();
                    return Math.Round(System.Convert.ToDouble(query), 2).ToString();
                }
            }
            else return null;
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }

    public class SelectedNameToFrek : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (value != null)
            {
                using (var db = new DziennikContext())
                {
                    var query = (from u in db.DaneUczniów
                                 join f in db.Frekwencja on u.u_id equals f.u_id
                                 where (u.Imię == (string)value && f.Obecność == true)
                                 group f by f.u_id into g
                                 select g.Count()).First().ToString();
                    return query;
                }
            }
            else return null;
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }

    public class SelectedNameToFrekMax : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (value != null)
            {
                using (var db = new DziennikContext())
                {
                    var query = (from u in db.DaneUczniów
                             join f in db.Frekwencja on u.u_id equals f.u_id
                             where u.Imię == (string)value
                             group f by f.u_id into g
                             select g.Count()).First().ToString();
                    return "/ " + query;
                }
            }
            else return null;
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }

    public class SelectedNameToColumn1 : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (value != null)
            {
                using (var db = new DziennikContext())
                {
                    var query = from u in db.DaneUczniów
                                 join o in db.OcenyCząstkowe on u.u_id equals o.u_id
                                 where u.Imię == (string)value
                                 select o;
                    return query.ToList();
                }
            }
            else return null;
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }

    public class SelectedNameToColumn2 : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (value != null)
            {
                using (var db = new DziennikContext())
                {
                    var query = (from u in db.DaneUczniów
                                 join o in db.OcenyCząstkowe on u.u_id equals o.u_id
                                 where u.Imię == (string)value
                                 select o.Ocena.ToString()).ToList();
                    return (List<string>)query;
                }
            }
            else return null;
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }

    public class SelectedNameToColumn3 : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (value != null)
            {
                using (var db = new DziennikContext())
                {
                    var query = (from u in db.DaneUczniów
                                 join o in db.OcenyCząstkowe on u.u_id equals o.u_id
                                 where u.Imię == (string)value
                                 select o.RodzajOceny.ToString()).ToList();
                    return (List<string>)query;
                }
            }
            else return null;
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }


}
