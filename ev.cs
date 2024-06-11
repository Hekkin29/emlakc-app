using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace emlakcıapp
{
    class ev
    {
        string semt;
        int katNo;
        int odaSayisi;
        double alan;
        int aidat;

        public string Semt
        {
            get { return semt; }
            set { semt = value.ToUpper(); }
        }

        public int KatNo
        {
            get { return katNo; }
            set { katNo = Math.Abs(value); }
        }

        public int OdaSayisi
        {
            get { return odaSayisi; }
            set { odaSayisi = Math.Abs(value); }
        }

        public double Alan
        {
            get { return alan; }
            set { alan = Math.Abs(value); }
        }
        public int Aidat
        {
            get { return aidat; } 
            set { aidat = Math.Abs(value);}  
        }
        
        public virtual string ToString()
        {
            return $"Semt: {Semt}, Kat No: {KatNo}, Oda Sayısı: {OdaSayisi}, Alan: {Alan} ";
        }
    }
}
