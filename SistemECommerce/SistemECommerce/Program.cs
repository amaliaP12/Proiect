namespace SistemECommerce;

class Program
{
    static void Main(string[] args)
    {
        var aplicatie = new Aplicatie();

        // Adăugarea unui administrator de test și salvarea lui în sistem
        var admin = new Administrator(1, "Admin", "admin@exemplu.com", "admin123");
        UserManager.AdaugaAdministrator(admin);

        // Adăugarea unui client de test și salvarea lui în sistem
        var client = new Client(2, "Client", "client@exemplu.com", "client123");
        UserManager.AdaugaClient(client);

        // Reîncarcarea utilizatorilor pentru a fi siguri că datele sunt în memorie
        UserManager.IncarcaUtilizatori();

        Console.WriteLine("Administratorul și clientul au fost creați și salvați în sistem.");

        // Pornirea aplicației
        aplicatie.Porneste();
    }
    
}
        