using System;
using System.Collections.Generic;
using System.IO;
namespace emlakcıapp
{
    class Program
    {
        static List<kiralikev> kiralikEvler = new List<kiralikev>();
        static List<Satilikev> satilikEvler = new List<Satilikev>();

        static void Main(string[] args)
        {
            Console.WriteLine("---Emlakçı Uygulamasına Hoşgeldiniz---\n");
            while (true)
            {

                MenuGetir();
            }

        }
        public static void MenuGetir()
        {

            Console.WriteLine("1. Kiralık Ev Giriş\n2. Satılık Ev Giriş\n3. Kayıtlı Ev Bilgileri Getir\n4. Çıkış");
            byte menuSecim = byte.Parse(Console.ReadLine());

            switch (menuSecim)
            {
                case 1:
                    EvBilgiGiris<kiralikev>();
                    break;
                case 2:
                    EvBilgiGiris<Satilikev>();
                    break;
                case 3:

                    KayitliEvBilgileriGoster();
                    Console.WriteLine("Menüye Dönmek için bir tuşa basınız!");
                    Console.ReadKey();
                    Console.Clear();
                    break;
                case 4:
                    Console.Clear();
                    Console.WriteLine("Program Kapatılıyor...");
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("Hatalı Seçim Yaptınız !!!");
                    break;
            }
        }

        public static void EvBilgiGiris<T>() where T : ev, new()
        {
            var ev = new T();

            Console.WriteLine("Semt Bilgisi Giriniz:");
            ev.Semt = Console.ReadLine();

            Console.WriteLine("Kat Numarasını Giriniz:");
            ev.KatNo = int.Parse(Console.ReadLine());

            Console.WriteLine("Oda Sayısını Giriniz:");
            ev.OdaSayisi = int.Parse(Console.ReadLine());

            Console.WriteLine("Alan Bilgisini Giriniz:");
            ev.Alan = int.Parse(Console.ReadLine());

            if (ev is kiralikev kiralikEv)
            {
                Console.WriteLine("Kira Bedelini Giriniz : ");
                kiralikEv.Kira = double.Parse(Console.ReadLine());

                Console.WriteLine("Depozito Bedelini Giriniz : ");
                kiralikEv.Depozito = double.Parse(Console.ReadLine());

                kiralikEvler.Add(kiralikEv);
                DosyayaYaz(kiralikEv.ToString(), "kiralik_evler.txt");
            }
            else if (ev is Satilikev satilikEv)
            {
                Console.WriteLine("Satış Fiyatını Giriniz : ");
                satilikEv.SatisFiyati = double.Parse(Console.ReadLine());

                satilikEvler.Add(satilikEv);
                DosyayaYaz(satilikEv.ToString(), "satilik_evler.txt");
            }
            
            Console.WriteLine("Aidat giriniz: ");
            ev.Aidat=int.Parse(Console.ReadLine());

            Console.WriteLine("Ev girişi başarılı! Devam etmek istiyor musunuz? (E/H)");
            string cevap = Console.ReadLine();
            if (cevap.ToUpper() == "e")
            {
                EvBilgiGiris<T>();
            }
            else
            {
                MenuGetir();
            }
        }


        public static void KayitliEvBilgileriGoster()
        {
            Console.WriteLine("hangi tip ev istersin: (k/s)");
            string tip = Console.ReadLine();
            if (tip == "k")
            {
                Console.WriteLine("Kiralık Evler:");
                Console.WriteLine(File.ReadAllText("kiralik_evler.txt"));
            }
            else if (tip == "s")
            {
                Console.WriteLine("\nSatılık Evler:");
                Console.WriteLine(File.ReadAllText("satilik_evler.txt"));
            }
        }

        public static void DosyayaYaz(string veri, string dosyaYolu)
        {
            using (StreamWriter sw = new StreamWriter(dosyaYolu, true))
            {
                sw.WriteLine(veri);
            }
        }

    }
}