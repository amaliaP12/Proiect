using System.Data;

namespace SistemECommerce;

public static class UserManager
{
    //listele clienti si administratori inregistrati
    public static List<Client> Clienti = new List<Client>();
    public static List<Administrator> Administratori = new List<Administrator>();
    //lista comenzi plasate
    public static List<Comanda> Comenzi = new List<Comanda>();
    
    //caile catre fisierele json pentru salvarea si incărcarea datelor
    private static string ClientiFilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "clienti.json");
    private static string AdministratoriFilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "administratori.json");
    private static string ComandaFilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "comanda.json");

    //metoda pentru incarcarea utilizatorilr si comenzilor din fisier
    public static void IncarcaUtilizatori()
    {
        // Încarcă lista clienților,comenzilor și administrator din fișierul JSON
        Clienti = DataManager.IncarcaDate<List<Client>>(ClientiFilePath) ?? new List<Client>();
        Administratori = DataManager.IncarcaDate<List<Administrator>>(AdministratoriFilePath) ?? new List<Administrator>();
        Comenzi=DataManager.IncarcaDate<List<Comanda>>(ComandaFilePath) ?? new List<Comanda>();
        //afisare nr clienți administartori si comenzi
        Console.WriteLine($"Clienti încărcați: {Clienti.Count}");
        Console.WriteLine($"Administratori încărcați: {Administratori.Count}");
        Console.WriteLine($"Comenzile au fost incarcate! {Comenzi.Count}");
    }

    //metoda salvare utilizatori in fisier json
    public static void SalveazaUtilizatori()
    {
        DataManager.SalvareDate(ClientiFilePath, Clienti);
        DataManager.SalvareDate(AdministratoriFilePath, Administratori);
    }

    //metoda adaugare client nou in lista clienti
    public static void AdaugaClient(Client client)
    {
        //verificare daca exista deja un client cu acelasi email
        if (!Clienti.Exists(c => c.Email == client.Email))
        {
            //adaugare client in lista+salavare modificari
            Clienti.Add(client);
            SalveazaUtilizatori();
        }
        else
        {
            Console.WriteLine("Clientul există deja!");
        }
    }

    //metodă adaugare admin
    public static void AdaugaAdministrator(Administrator admin)
    {
        if (!Administratori.Exists(a => a.Email == admin.Email))
        {
            //analog client
            Administratori.Add(admin);
            SalveazaUtilizatori();
        }
        else
        {
            Console.WriteLine("Administratorul există deja!");
        }
    }
}
