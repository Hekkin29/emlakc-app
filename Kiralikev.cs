using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace emlakcıapp
{
    class kiralikev : ev
    {
        double kira;
        double depozito;

        public double Kira
        {
            get { return kira; }
            set { kira = Math.Abs(value); }
        }

        public double Depozito
        {
            get { return depozito; }
            set { depozito = Math.Abs(value); }
        }

        public override string ToString()
        {
            return base.ToString() + $", Kira Fiyatı: {kira}, Depozito: {Depozito}";
        }
    }
}
