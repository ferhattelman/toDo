using System;
using System.Collections.Generic;

namespace Todo
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                string secim = Board.secim();
                if (secim == "1")
                {
                    Board.Listele();
                }
                else if (secim == "2")
                {
                    Card newCard = Board.kartOlustur();
                    Board.kartEkle(newCard);
                }
                else if (secim == "3")
                {
                    Card newCard = Board.kartOlustur();
                    Board.kartGuncelle(newCard);
                }
                else if (secim == "4")
                {
                    Board.kartSil();
                }
                else if (secim == "5")
                {
                    Board.kartTaşı();
                }
                else if (secim == "6")
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Hatalı giriş yaptınız.");
                }
            }
            Console.ReadLine();
        }
    }
    class Card
    {
        private string baslik;
        private string icerik;
        private string atananKisi;
        private string buyukluk;

        public Card(string baslik, string ıcerik, string atananKisi, string buyukluk)
        {
            Baslik = baslik;
            Icerik = ıcerik;
            AtananKisi = atananKisi;
            Buyukluk = buyukluk;
        }

        public string Baslik { get => baslik; set => baslik = value; }
        public string Icerik { get => icerik; set => icerik = value; }
        public string AtananKisi { get => atananKisi; set => atananKisi = value; }
        public string Buyukluk { get => buyukluk; set => buyukluk = value; }

    }

    static class Board
    {
        private static List<Card> todo = new List<Card>();
        private static List<Card> progress = new List<Card>();
        private static List<Card> done = new List<Card>();

        public static string secim()
        {
            Console.WriteLine("Lütfen yapmak istediğiniz işlemi seçiniz :) ");
            Console.WriteLine("******************************************* ");
            Console.WriteLine("(1) Board Listelemek ");
            Console.WriteLine("(2) Board'a Kart Eklemek ");
            Console.WriteLine("(3) Kart Güncelle ");
            Console.WriteLine("(4) Board'dan Kart Silmek ");
            Console.WriteLine("(5) Kart Taşımak ");
            Console.WriteLine("(6) Çıkış ");
            string secim = Console.ReadLine();
            return secim;
        }
        public static Card kartOlustur()
        {
            Console.Write("Başlık Giriniz                                  : ");
            string baslik = Console.ReadLine();
            Console.Write("İçerik Giriniz                                  :");
            string icerik = Console.ReadLine();
            Console.Write("Büyüklük Seçiniz -> XS(1),S(2),M(3),L(4),XL(5)  :");
            string buyukluk = Console.ReadLine();
            Console.Write("Kişi Seçiniz                                    :");
            string kisi = Console.ReadLine();

            Card newCard = new Card(baslik, icerik, buyukluk, kisi);
            return newCard;
        }
        public static void boardListele(string boardLine)
        {
            Console.WriteLine("{0} Line", boardLine);
            Console.WriteLine("************************");

            (boardLine == "TODO" ? todo : boardLine == "PROGRESS" ? progress : done).ForEach(item =>
            {
                Console.WriteLine(" Başlık      : {0}", item.Baslik);
                Console.WriteLine(" İçerik      : {0}", item.Icerik);
                Console.WriteLine(" Atanan Kişi : {0}", item.AtananKisi);
                Console.WriteLine(" Büyüklük    : {0}", item.Buyukluk);
                Console.WriteLine("----------------");
            });
        }
        public static void Listele()
        {
            boardListele("TODO");
            boardListele("PROGRESS");
            boardListele("DONE");
        }

        public static void kartEkle(Card record)
        {
            todo.Add(record);
        }
        public static void kartGuncelle(Card record)
        {
            Card toUpdateCard = todo.Find(item => item.Baslik == record.Baslik);
            toUpdateCard.Icerik = record.Icerik;
            toUpdateCard.Buyukluk = record.Buyukluk;
            toUpdateCard.AtananKisi = record.AtananKisi;
        }
        public static void kartSil()
        {
            Console.WriteLine(" Öncelikle silmek istediğiniz kartı seçmeniz gerekiyor.");
            Console.Write("Lütfen kart başlığını yazınız:  ");
            string baslik = Console.ReadLine();
            Card toDeleteCard = todo.Find(card => card.Baslik == baslik);
            todo.Remove(toDeleteCard);
            progress.Remove(toDeleteCard);
            done.Remove(toDeleteCard);
        }
        public static void kartTaşı()
        {
            Console.WriteLine(" Öncelikle silmek istediğiniz kartı seçmeniz gerekiyor.");
            Console.Write("Lütfen kart başlığını yazınız:  ");
            string baslik = Console.ReadLine();
            Card toMoveCard = todo.Find(card => card.Baslik == baslik);
            if (toMoveCard == null)
            {
                toMoveCard = progress.Find(card => card.Baslik == baslik);
                progress.Remove(toMoveCard);
                done.Add(toMoveCard);
            }
            else
            {
                todo.Remove(toMoveCard);
                progress.Add(toMoveCard);
            }
        }
    }

    enum Buyuklukler
    {
        XS,
        S,
        M,
        L,
        XL
    }
}
