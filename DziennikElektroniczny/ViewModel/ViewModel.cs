using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;
using DziennikElektroniczny.Model;

namespace DziennikElektroniczny.ViewModel
{
    public class Model
    {
        public string DataAktualna;
        public List<string> Login;
        public string SelectedLogin;
        public string SelectedWybórUcznia;
        public string OcenaCząstkowa;
        public string RodzajOceny;
        public string OcenaKońcowa;

        public Model()
        {
            DataAktualna = DateTime.Now.ToString();
            SelectedLogin = null;
            SelectedWybórUcznia = null;
            using (var db = new DziennikContext())
            {
                var query = (from k in db.Klasy
                             select k.Wychowawca.ToString()).ToList();
                Login = query;
            }
        }
    }

    public class ViewModel : INotifyPropertyChanged
    {
        Model model = new Model();

        public string DataAktualna
        {
            get
            {
                return model.DataAktualna;
            }
            set
            {
                model.DataAktualna = value;
                if (PropertyChanged != null) PropertyChanged(this, new PropertyChangedEventArgs("DataAktualna"));
            }
        }

        public List<string> Login
        {
            get
            {
                return model.Login;
            }
            set
            {
                model.Login = value;
                if (PropertyChanged != null) PropertyChanged(this, new PropertyChangedEventArgs("Login"));
            }
        }

        public string SelectedLogin
        {
            get
            {
                return model.SelectedLogin;
            }
            set
            {
                model.SelectedLogin = value;
                if (PropertyChanged != null) PropertyChanged(this, new PropertyChangedEventArgs("SelectedLogin"));
            }
        }

        public string SelectedWybórUcznia
        {
            get
            {
                return model.SelectedWybórUcznia;
            }
            set
            {
                model.SelectedWybórUcznia = value;
                if (PropertyChanged != null) PropertyChanged(this, new PropertyChangedEventArgs("SelectedWybórUcznia"));
            }
        }

        public string OcenaCząstkowa
        {
            get
            {
                return model.OcenaCząstkowa;
            }
            set
            {
                model.OcenaCząstkowa = value;
                if (PropertyChanged != null) PropertyChanged(this, new PropertyChangedEventArgs("OcenaCząstkowa"));
            }
        }

        public string RodzajOceny
        {
            get
            {
                return model.RodzajOceny;
            }
            set
            {
                model.RodzajOceny = value;
                if (PropertyChanged != null) PropertyChanged(this, new PropertyChangedEventArgs("RodzajOceny"));
            }
        }

        public string OcenaKońcowa
        {
            get
            {
                return model.OcenaKońcowa;
            }
            set
            {
                model.OcenaKońcowa = value;
                if (PropertyChanged != null) PropertyChanged(this, new PropertyChangedEventArgs("OcenaKońcowa"));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
