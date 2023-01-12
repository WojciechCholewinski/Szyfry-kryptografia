class Program
{
    public static char Szyfr(char ch, int key)
    {
        if (!char.IsLetter(ch))
        {
            return ch;
        }

        char d = char.IsUpper(ch) ? 'A' : 'a';
        return (char)((((ch + key) - d) % 26) + d);
    }


    public static string Szyfrowanie(string input, int key)
    {
        string output = string.Empty;

        foreach (char ch in input)
            output += Szyfr(ch, key);

        return output;
    }

    public static string Deszyfrowanie(string input, int key)
    {
        return Szyfrowanie(input, 26 - key);
    }


    static void Main(string[] args)
    {
        Console.Title = "Szyfr Cezara";
        Console.Write("Wpisz tekst do zaszyfrowania: ");
        string text = Console.ReadLine();

        Console.WriteLine("\n");

        int key = 0;
        try
        {
            Console.Write("Podaj wartość klucza: ");
            key = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("\n");

            Console.WriteLine("Test po zaszyfrowaniu:");

            string textzaszyfrowany = Szyfrowanie(text, key);
            Console.WriteLine(textzaszyfrowany);
            Console.Write("\n");

            Console.WriteLine("Tekst po odszyfrowaniu spowrotem:");

            string t = Deszyfrowanie(textzaszyfrowany, key);
            Console.WriteLine(t);
            Console.Write("\n");

        }
        catch (Exception exp)
        {
            Console.WriteLine();
            Console.WriteLine("Klucz musi być cyfrą!\n");
            Console.WriteLine(exp.StackTrace);
        }
        Console.ReadKey();

    }
}
