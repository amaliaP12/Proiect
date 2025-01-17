using System.Data;

namespace SistemECommerce;

public static class UserManager
{
    public static List<Client> Clienti = new List<Client>();
    public static List<Administrator> Administratori = new List<Administrator>();
    public static List<Comanda> Comenzi = new List<Comanda>();

    private static string ClientiFilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "clienti.json");
    private static string AdministratoriFilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "administratori.json");
    private static string ComandaFilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "comanda.json");

    public static void IncarcaUtilizatori()
    {
        Clienti = DataManager.IncarcaDate<List<Client>>(ClientiFilePath) ?? new List<Client>();
        Administratori = DataManager.IncarcaDate<List<Administrator>>(AdministratoriFilePath) ?? new List<Administrator>();
        Comenzi=DataManager.IncarcaDate<List<Comanda>>(ComandaFilePath) ?? new List<Comanda>();

        Console.WriteLine($"Clienti incarcati: {Clienti.Count}");
        Console.WriteLine($"Administratori incarcati: {Administratori.Count}");
        Console.WriteLine($"Comenzile au fost incarcate! {Comenzi.Count}");
    }

    public static void SalveazaUtilizatori()
    {
        DataManager.SalvareDate(ClientiFilePath, Clienti);
        DataManager.SalvareDate(AdministratoriFilePath, Administratori);
    }

    public static void AdaugaClient(Client client)
    {
        if (!Clienti.Exists(c => c.Email == client.Email))
        {
            Clienti.Add(client);
            SalveazaUtilizatori();
        }
        else
        {
            Console.WriteLine("Clientul exista deja!");
        }
    }

    public static void AdaugaAdministrator(Administrator admin)
    {
        if (!Administratori.Exists(a => a.Email == admin.Email))
        {
            Administratori.Add(admin);
            SalveazaUtilizatori();
        }
        else
        {
            Console.WriteLine("Administratorul exista deja!");
        }
    }
}
