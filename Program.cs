namespace Tombok

{

    internal class Program
    {

        static string[] szavak = { "alma", "körte", "barack", "szilva", "cseresznye", "kutya", "macska", "oroszlán", "elefánt", "zsiráf", "iskola", "tanulás", "füzet", "ceruza", "tábla", "asztal", "szék", "ablak", "ajtó", "lámpa", "autó", "vonat", "repülő", "kerékpár", "hajó", "erdő", "hegy", "folyó", "tenger", "sziget", "napraforgó", "virág", "tulipán", "rózsa", "levél", "kenyér", "sajt", "leves", "palacsinta", "csokoládé", "telefon", "számítógép", "billentyűzet", "monitor", "internet", "labda", "focista", "úszás", "kirándulás", "karácsony" };
        static Random r = new Random();
        static string Kivalasztas()

        {

            int index = r.Next(0, szavak.Length);

            return szavak[index];

        }

        static char BetuBekeres()

        {

            Console.Write("Kérek egy betűt: ");

            char betu = Console.ReadLine()[0];

            Console.Clear();

            return betu;

        }

        static void Akasztofa()

        {

            //Console.SetCursorPosition(15, 20);string kitalalandoSzo = Kivalasztas();
            string kitalalandoSzo = Kivalasztas();
            string eddigiTalalatok = new string('_', kitalalandoSzo.Length);

            int tippekSzama = 0;

            string eddigiBetuk = "";

            Console.WriteLine(eddigiTalalatok);

            while (kitalalandoSzo != eddigiTalalatok)

            {

                char betu = BetuBekeres();

                tippekSzama++;

                if (eddigiBetuk.Contains(betu))

                {

                    Console.WriteLine("Ezt a betűt már próbáltad!");

                    

                }

                else if (kitalalandoSzo.Contains(betu))

                {

                    eddigiBetuk += betu;

                    string seged = "";

                    for (int i = 0; i < kitalalandoSzo.Length; i++)

                    {

                        if (kitalalandoSzo[i] == betu)

                        {

                            seged += betu;

                        }

                        else
                        {
                            seged += eddigiTalalatok[i];
                        }
                    }
                    eddigiTalalatok = seged;
                }
                else
                {
                    Console.WriteLine("Nincs ilyen betű a szóban!");
                }
                Console.WriteLine($"\n{eddigiTalalatok}");
                Console.WriteLine($"\n");

            }
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"Gratulálunk, kitaláltad a szót {tippekSzama} próbálkozásból!");
            Console.ResetColor();
        }

        static string[] NevekLetrehozasa(int db)
        {
            string[] nevekOsszes = {"Daniel", "Ádám", "Bence", "Csaba", "Dávid", "Erik", "Ferenc", "Gábor", "Hunor", "István", "János", "Károly", "Levente", "Márk", "Norbert", "Péter", "Richárd", "Sándor", "Tamás", "Viktor", "Zoltán", "Anna", "Barbara", "Csilla", "Dóra", "Eszter", "Fanni", "Hanna", "Kata", "Lilla", "Zsófia" };
            string[] nevek = new string[db];
            for (int i = 0; i < db; i++)
            {
                nevek[i] = nevekOsszes[i];
            }
            return nevek;
        }
        static void Kiiratas(string[] nevek)
        {
            foreach (string nev in nevek)
            {
                Console.WriteLine(nev);
            }
        }
        static int[] EleteroBeallitasa(int lakossagSzama)
        {
            int[] eleterok = new int[lakossagSzama];
            for (int i = 0; i < lakossagSzama; i++)
            {
                eleterok[i] = 100;
            }
            return eleterok;
        }
        static int[] TamadoEroBeallitasa(int zombikSzama)
        {
            int[] tamadasok = new int[zombikSzama];
            for (int i = 0; i < zombikSzama; i++)
            {
                tamadasok[i] = r.Next(10,25);
            }
            return tamadasok;
        }
        static void KiirSzamok(int[] szamok)
        {
            foreach (var item in szamok)
            {
                Console.Write(item + " ");
            }
            Console.WriteLine();
        }
        static bool VanEEloLakossag(int[] lakossagEletereje)
        {
            foreach (var item in lakossagEletereje)
            {
                if (item > 0)
                {
                    return true;
                }
            }
            return false;
        }
        static void ZombikInvazioja(int[] lakossagEletereje, int[] zombikTamadasa, string[] zombikNevek, string[] lakossag)
        { 
            while (VanEEloLakossag(lakossagEletereje) && zombikTamadasa.Any(x => x > 0))
            {
                for (int i = 0; i < zombikTamadasa.Length; i++)
                {
                    int randomLakosIndex = r.Next(0, lakossagEletereje.Length);
                    if (lakossagEletereje[randomLakosIndex] > 0)
                    {
                        lakossagEletereje[randomLakosIndex] -= zombikTamadasa[i];
                        zombikTamadasa[i] -= r.Next(3, 5);
                        Console.WriteLine($"{zombikNevek[i]} megtámadta {lakossag[randomLakosIndex]}-t, aki {zombikTamadasa[i]} sebzést kapott. Maradék életerő: {Math.Max(lakossagEletereje[randomLakosIndex], 0)}");
                    }
                }
                Console.WriteLine("Jelenlegi lakosság életereje:");
                KiirSzamok(lakossagEletereje);
            }
        }

        static void Main(string[] args)

        {

            //Akasztofa();
            int lakossagSzama = 5;
            int zombikSzama = 3;
            string[] lakossag = NevekLetrehozasa(lakossagSzama);
            string[] zombik = NevekLetrehozasa(zombikSzama);
            Console.Write("Lakosság: ");
            Kiiratas(lakossag);
            Console.Write("Zombik: ");
            Kiiratas(zombik);
            int[] lakossagEletereje = EleteroBeallitasa(lakossagSzama);
            int[] zombikTamadasa = TamadoEroBeallitasa(zombikSzama);
            Console.Write("Lakosság életereje: ");
            KiirSzamok(lakossagEletereje);
            Console.Write("Zombik támadása: ");
            KiirSzamok(zombikTamadasa);
            ZombikInvazioja(lakossagEletereje, zombikTamadasa, zombik, lakossag);


            /*

            Console.WriteLine($"A tömb első eleme: {szavak[0]}"); //indexelés: nulláról kezdődik

            Console.WriteLine($"A tömb utolsó eleme: {szavak[szavak.Length - 1]}");

            Console.WriteLine($"A tömb elemeinek a száma: {szavak.Length}");

           */
        }

       
    }

}


//1. kiválsztok egy szót,a mit ki kell találni//2. a kitalalando szó helyett aláhuzásokat kell megjeleniteni//3. be kell kérni egy betűt a felhasználótól//4. meg kell nézni, hogy az adott betű benne van e a kitalalando szóban//5. ha benne van, akkor a megfelelő helyre be kell írni a betűt, annyiszor, és arra a helyre, ahol benne van// !!! amit eddig már kitalált, azt is meg kell jeleniteni.
