public class Program
{
    static char[,] SzachownicaPolibiusza = {
        { 'A', 'B', 'C', 'D', 'E' },
        { 'F', 'G', 'H', 'I', 'K' },
        { 'L', 'M', 'N', 'O', 'P' },
        { 'Q', 'R', 'S', 'T', 'U' },
        { 'V', 'W', 'X', 'Y', 'Z' }
    };

    static string Szyfrowanie(string input)
    {
        input = input.ToUpper();
        string output = "";

        for (int i = 0; i < input.Length; i++)
        {
            if (input[i] == 'J') input = input.Replace("J", "I");
            if (input[i] == ' ') continue;

            for (int row = 0; row < 5; row++)
            {
                for (int col = 0; col < 5; col++)
                {
                    if (SzachownicaPolibiusza[row, col] == input[i])
                    {
                        output += (row + 1).ToString() + (col + 1).ToString();
                    }
                }
            }
        }
        return output;
    }

    static string Deszyfracja(string input)
    {
        string output = "";

        for (int i = 0; i < input.Length; i += 2)
        {
            int row = int.Parse(input[i].ToString()) - 1;
            int col = int.Parse(input[i + 1].ToString()) - 1;
            try
            {
                output += SzachownicaPolibiusza[row, col];
            }
            catch (Exception)
            {
                if (SzachownicaPolibiusza.GetLength(0) != SzachownicaPolibiusza.GetLength(1))
                {
                    Console.WriteLine("Szachownica którą stworzyłeś nie jest macierzą kwadratową!");
                }
                Console.WriteLine("Podane cyfry przekraczają zakres ustalonej tablicy: " + SzachownicaPolibiusza.GetLength(0) + " x " + SzachownicaPolibiusza.GetLength(1));
            }
        }
        return output;
    }

    static void Main()
    {
        Console.Title = "Szyfr Polibiusza";
        Console.WriteLine("Podaj tekst do zaszyfrowania:");
        string input = Console.ReadLine();
        string encrypted = Szyfrowanie(input);
        Console.WriteLine("\nTekst po zaszyfrowaniu: " + encrypted);

        Console.WriteLine("\n\nPodaj tekst do deszyfracji:");
        input = Console.ReadLine();
        try
        {
            string decrypted = Deszyfracja(input);
            Console.WriteLine("\nTekst po rozszyfrowaniu: " + decrypted);
        }
        catch (Exception)
        {
            Console.WriteLine("\nBłąd! Możliwe że zamiast podać cyfry wprowadziłeś litery, lub nieparzystą ilość cyfr.");
        }

        Console.ReadKey();
    }
}