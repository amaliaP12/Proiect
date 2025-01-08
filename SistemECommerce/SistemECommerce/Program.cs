namespace SistemECommerce;

class Program
{
    static void Main(string[] args)
    {
        //s-a facut
        //Console.WriteLine("Hello, World!");
                var sistemAutentificare = new SistemAutentificare();

                var admin = new Administrator(1, "Admin", "admin@exemplu.com", "admin123");
                //var client = new Client(2, "Client", "client@exemplu.com", "client123");

                sistemAutentificare.InregistreazaUtilizator(admin);
                //sistemAutentificare.InregistreazaUtilizator(client);

                Console.WriteLine("Autentificare utilizator:");

                Console.Write("ID: ");
                int id = int.Parse(Console.ReadLine());

                Console.Write("Parola: ");
                string parola = Console.ReadLine();

                var utilizatorAutentificat = sistemAutentificare.Autentifica(admin);

                if (utilizatorAutentificat != null)
                {
                    Console.WriteLine($"Autentificare reusita pentru utilizatorul {utilizatorAutentificat.Nume}.");
                }
                else
                {
                    Console.WriteLine("Autentificare eșuată.");
                }
    }
}
        