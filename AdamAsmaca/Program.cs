using System;
using System.Linq;

namespace AdamAsmaca
{
    class Program
    {
        static void Main(string[] args)
        {
            // Türkiye şehirleri listesi
            string[] sehirler = { "Ankara", "İstanbul", "İzmir", "Bursa", // ... diğer şehirler
                                  "Antalya", "Adana", "Konya", "Gaziantep",
                                  "Samsun", "Trabzon" };

            // Rastgele bir şehir seç
            Random random = new Random();
            string gizliKelime = sehirler[random.Next(sehirler.Length)].ToLower(); // Tüm kelimeyi küçük harfe çevir

            // Tahmin edilecek kelimeyi boşluklarla başlat
            char[] tahminEdilenKelime = new char[gizliKelime.Length];
            for (int i = 0; i < gizliKelime.Length; i++)
            {
                tahminEdilenKelime[i] = '_';
            }

            // Oyuncuya verilen can sayısı
            int kalanCan = 5;

            while (kalanCan > 0 && tahminEdilenKelime.Contains('_'))
            {
                Console.WriteLine("Kelime: " + new string(tahminEdilenKelime));

                // Kullanıcıdan tahmin al ve küçük harfe çevir
                Console.Write("Bir harf tahmin et: ");
                char tahmin = Console.ReadLine().ToLower()[0];

                // Tahmini kontrol et ve kelimeyi güncelle
                bool tahminDogruMu = false;
                for (int i = 0; i < gizliKelime.Length; i++)
                {
                    if (gizliKelime[i] == tahmin)
                    {
                        tahminEdilenKelime[i] = tahmin;
                        tahminDogruMu = true;
                    }
                }

                // Sonucu oyuncuya bildir
                if (tahminDogruMu)
                {
                    Console.WriteLine("Doğru tahmin!");
                }
                else
                {
                    kalanCan--;
                    Console.WriteLine("Yanlış tahmin! Kalan canın: " + kalanCan);
                }
            }

            // Oyunun sonucu
            if (tahminEdilenKelime.Contains('_'))
            {
                Console.WriteLine("Üzgünüz, oyunu kaybettiniz. Kelime: " + gizliKelime);
                Console.ReadLine();
            }
            else
            {
                Console.WriteLine("Tebrikler, kelimeyi buldunuz! Kelime: " + gizliKelime);
                Console.ReadLine();
            }
        }
    }
}