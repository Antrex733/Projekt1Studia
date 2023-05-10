using System;

namespace Projekt_1
{
    class Program
    {
        static void Main(string[] args)
        {
            //Tytół programu 
            Console.WriteLine("\t\tProgram umożliwia wielokrotne obliczanie wartości wybranych wielkośni matematycznych\n\n");

            //Menu
            Console.WriteLine("\tMENU funkcjonalne programu:");

            Console.WriteLine("\n\tA.Obliczanie średniej geometrycznej wyrazów ciągu liczbowego");
            Console.WriteLine("\n\tB.Obliczanie średniej harmonicznej wyrazów ciągu liczbowego");
            Console.WriteLine("\n\tC.Obliczanie średniej kwadratowej wyrazów ciągu liczbowego");
            Console.WriteLine("\n\tD.Obliczanie średniej potęgowej (sredniej uogólnionej) wyrazów ciągu liczbowego");
            Console.WriteLine("\n\tE.Obliczanie ceny jednostki paszy (wegług średniej ważonej)");
            Console.WriteLine("\n\tF.Obliczanie wartości wielomianu n-tego stopnia");
            Console.WriteLine("\n\tG.Konwersja znakowego zapisu liczby stałoprzecinkowej z systemu 2-16 na liczbę zapisaną znakowo\n\t  w innym systemie liczbowym (2-16)");
            Console.WriteLine("\n\tX.Zakończenie (wyjście z) programu");

            //Deklaracja zmiennej operacja 
            ConsoleKeyInfo anoperacja;


            ushort ann;
            while (true)
            {
                
                Console.Write("\n\tPodaj znak operacji: ");
                anoperacja = Console.ReadKey();

                if (anoperacja.Key == ConsoleKey.A)
                {
                    ann = anPobieranieN("Podaj liczbę elementów, z których zostanie policzona wybrana operacja: ");
                    Console.WriteLine("\n\t\tWynik to: {0}", anSredniaGeometryczna(ann));


                }
                else if (anoperacja.Key == ConsoleKey.B)
                {
                    ann = anPobieranieN("Podaj liczbę elementów, z których zostanie policzona wybrana operacja: ");
                    Console.WriteLine("\n\t\tWynik to: {0}", anSredniaHarmoniczna(ann));
                }
                else if (anoperacja.Key == ConsoleKey.C)
                {
                    ann = anPobieranieN("Podaj liczbę elementów, z których zostanie policzona wybrana operacja: ");
                    Console.WriteLine("\n\t\tWynik to: {0}", anSredniaKwadratowa(ann));
                }
                else if (anoperacja.Key == ConsoleKey.D)
                {
                    ann = anPobieranieN("Podaj liczbę elementów, z których zostanie policzona wybrana operacja: ");
                    Console.WriteLine("\n\t\tWynik to: {0}", anSredniaPotegowa(ann));
                }
                else if (anoperacja.Key == ConsoleKey.E)
                {
                    ann = anPobieranieN("Podaj liczbę produktów: ");
                    Console.WriteLine("\n\t\tWynik to: {0} zł", anCenaPaszy(ann));
                }
                else if (anoperacja.Key == ConsoleKey.F)
                {
                    ann = anPobieranieN("Podaj stopień wielomianu: ");
                    Console.WriteLine("\n\t\tWynik to: {0} ", anWielomian(ann));
                }
                else if (anoperacja.Key == ConsoleKey.G)
                {
                    ushort ansystemB = anPobieranieSystemu("\n\tPodaj  system Twojej liczby: "), ansystemK = anPobieranieSystemu("Podaj  system, na który chcesz zmienić sowją liczbę: ");
                   
                    string anliczbaX = anSprawdzamLiczbeIWczytuje(ansystemB);

                    Console.WriteLine("\n\t\tWynik to: {0} ", anZmZ10NaInny(ansystemK, anZmZ216Na10(anliczbaX, ansystemB)));
                    
                }
                else if (anoperacja.Key == ConsoleKey.X)
                {
                    Console.WriteLine("\n\tKoniec programu");
                    break;
                }
                else
                    Console.WriteLine("\n\tZły znak");
            }
        }
        //Metoda pobieracjący ilość wyrazów ciągu liczbowego typu ushort
        static ushort anPobieranieN(string antekst)
        {
            ushort ann;

            while (true)
            {
                Console.Write("\n\t{0}", antekst);
                if (!ushort.TryParse(Console.ReadLine(), out ann))
                {
                    Console.WriteLine("\n\tERROR - podano niewłaściwą wartość");
                }
                else
                    return ann;
            }

        }

        //Metoda pobieracjąca system liczbowy (2-16)
        static ushort anPobieranieSystemu(string antekst)
        {
            ushort ann;

            while (true)
            {
                Console.Write("\n\t{0}", antekst);
                string ant = Console.ReadLine();
                if (!ushort.TryParse( ant, out ann) || ushort.Parse(ant) > 16 || ushort.Parse(ant) < 2)
                {
                    Console.WriteLine("\n\tERROR - podano niewłaściwą wartość");
                }
                else
                    return ann;
            }

        }

        //Metoda pobieracjący ilość wyrazów ciągu liczbowego typu double
        static double anPobieranieNd(string antekst)
        {
            double ann;

            while (true)
            {
                Console.Write("\n\t{0}", antekst);
                if (!double.TryParse(Console.ReadLine(), out ann))
                {
                    Console.WriteLine("\n\tERROR - podano niewłaściwą wartość");
                }
                else
                    return ann;
            }

        }

        //Metoda licząca średnią geometryczną
        static double anSredniaGeometryczna(double ann)
        {
            double aniloczyn = 1, anwynik, anx;

            for (int ani = 1; ani <= ann; ani++)
            {
                Console.Write("\n\t\tPodaj {0}-ą liczbę: ", ani);
                string anliczba = Console.ReadLine();

                if (!double.TryParse(anliczba, out anx) || int.Parse(anliczba) < 0 )
                {
                    Console.WriteLine("\n\t\tERROR-podano złą wartość");
                    ani--;
                }
                else
                    aniloczyn *= anx;
            }
            anwynik = Math.Pow(aniloczyn, 1 / ann);

            return anwynik;
        }

        //Metoda licząca średnią harmoniczną
        static double anSredniaHarmoniczna(ushort ann)
        {
            double anwynik, ansuma = 0, anx;

            for (int ani = 1; ani <= ann; ani++)
            {
                Console.Write("\n\t\tPodaj {0}-ą liczbę: ", ani);
                if (!double.TryParse(Console.ReadLine(), out anx))
                {
                    Console.WriteLine("\n\t\tERROR-podano złą wartość");
                    ani--;
                }
                else
                    ansuma = ansuma + 1 / anx;


            }
            anwynik = ann / ansuma;

            return anwynik;
        }

        //Metoda licząca średnią kwadratową
        static double anSredniaKwadratowa(ushort ann)
        {
            double ansuma = 0, anx;
            for (int ani = 1; ani <= ann; ani++)
            {
                Console.Write("\n\t\tPodaj {0}-ą liczbę: ", ani);
                string anliczba = Console.ReadLine();
                if (!double.TryParse( anliczba, out anx) || int.Parse(anliczba) < 0)
                {
                    Console.WriteLine("\n\t\tERROR-podano złą wartość");
                    ani--;
                }
                else
                    ansuma += Math.Pow(anx, 2);
            }
            double anwynik = Math.Sqrt(ansuma / ann);

            return anwynik;
        }

        //Metoda licząca średnią potęgową wybranego rzędu
        static double anSredniaPotegowa(ushort ann)
        {
            double anwynik, ansuma = 0, anx, annrrzedu = anPobieranieN("\n\t\tPodaj numer rzędu: ");
            for (int ani = 1; ani <= ann; ani++)
            {
                Console.Write("\n\t\tPodaj {0}-ą liczbę: ", ani);
                string anliczba = Console.ReadLine();
                if (!double.TryParse(anliczba, out anx) || int.Parse(anliczba) < 0)
                {
                    Console.WriteLine("\n\t\tERROR-podano złą wartość");
                    ani--;
                }
                else
                    ansuma += Math.Pow(anx, annrrzedu);
            }
            anwynik = Math.Pow(ansuma / ann, 1 / annrrzedu);

            return anwynik;
        }

        //Metoda licząca cenę paszy (według średniej ważonej)
        static double anCenaPaszy(ushort ann)
        {
            bool anx;
            ushort anilosc = 0;
            double anwynik, ansuma = 0, ancena = 0, aniloczyn = 0;
            for (int ani = 1; ani <= ann; ani++)
            {
                anx = true;
                Console.Write("\n\t\tPodaj cenę {0}-ej paszy: ", ani);
                string ansprawdzam = Console.ReadLine();
                if (!double.TryParse(ansprawdzam, out ancena) || double.Parse(ansprawdzam) < 0)
                {
                    Console.WriteLine("\n\t\tERROR-podano złą wartość");
                    ani--;
                    anx = false;
                }
                else if (true)
                {
                    Console.Write("\n\t\tPodaj ilość {0}-ej paszy: ", ani);
                    if (!ushort.TryParse(Console.ReadLine(), out anilosc))
                    {
                        Console.WriteLine("\n\t\tERROR-podano złą wartość");
                        ani--;
                        anx = false;
                    }
                }
                if (anx)
                {
                    if (ancena * anilosc < 0)
                        aniloczyn = (-1) * (ancena * anilosc) + aniloczyn;
                    else
                        aniloczyn = ancena * anilosc + aniloczyn;
                    if (anilosc < 0)
                        ansuma = anilosc * (-1);
                    else
                        ansuma += anilosc; ;
                }

            }

            anwynik = aniloczyn / ansuma;

            return anwynik;
        }

        //Metoda licząca wielomian n-stopnia
        static double anWielomian(ushort ann)
        {
            double anwynik = 0, anx = anPobieranieNd("\n\t\tPodaj wartość x: "), anp;
            for (int ani = ann; ani >= 0; ani--)
            {
                Console.Write("\n\t\tPodaj współczynnik nr {0} : ", ani);
                if (!double.TryParse(Console.ReadLine(), out anp))
                {
                    Console.WriteLine("\n\t\tERROR-podano złą wartość");
                    ani--;
                }
                else
                    anwynik = anwynik + anp * Math.Pow(anx, ani);
            }
            return anwynik;
        }

        //Metoda sprawdzająca czy podana liczba jest prawidłowa (słada się z odpoweidnich znaków)
        static string anSprawdzamLiczbeIWczytuje(ushort ansystem)
        {
            string anznaki = "0123456789ABCDEF", anliczbaX="";
            int anl;
            do
            {
                anl = 0;
                Console.Write("\n\tPodaj liczbę: ");
                anliczbaX = Console.ReadLine();

                for (int i = 0; i < anliczbaX.Length; i++)
                {
                    for (int j = 0; j < ansystem; j++)
                    {
                        if (anliczbaX[i] == anznaki[j])
                        {
                            anl++;
                        }
                    }
                }
                if (!(anl == anliczbaX.Length))
                {
                    Console.WriteLine("\tERROR - Podana liczba nie istnieje w podanym systemie");
                }
            } while (!(anl == anliczbaX.Length));

            return anliczbaX;
            
        }

        //Metoda konwertująca liczby z systemu 10 na inny (2-16)
        static string anZmZ10NaInny(ushort ansystemK, ushort anliczba)
        {

            string anwynik = "", anznaki = "0123456789ABCDEF";

            while (anliczba > 0)
            {
                anwynik = anznaki[anliczba%ansystemK] + anwynik;
                anliczba /= ansystemK;
            }

            return anwynik;
        }
        //Metoda konwertująca liczby z systemu 2-16 na  10
        static ushort anZmZ216Na10(string anliczba, ushort ansystemB)
        {
            string anznaki = "0123456789ABCDEF";
            ushort anwynik = 0;
            int anp = 0;

            for (int ani = 0; ani < anliczba.Length; ani++)
            {
                for (int anj = 0; anj < anznaki.Length; anj++)
                {
                    if(anliczba[anliczba.Length-1- ani] == anznaki[anj])
                    {
                        anp = anj;
                        break;
                    }
                }
                anwynik += (ushort)(anp * Math.Pow((double)ansystemB, (double)ani));
            }

            return anwynik;
        }

    }
}
