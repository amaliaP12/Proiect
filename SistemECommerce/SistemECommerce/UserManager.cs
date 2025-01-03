using System.Data;

namespace SistemECommerce;

public class UserManager
{
    private static List<Utilizator>Utilizatori=new List<Utilizator>();
    private static string FilePath = "utilizatori.json";// s-ar putea sa trebuiasca sa schimb path-ul
    
    public static void IncarcaUtilizatori()
    {
        Utilizatori = DataManager.IncarcaDate<List<Utilizator>>(FilePath);
    }

    public static void SalveazaUtilizatori()
    {
        DataManager.SalvareDate(FilePath, Utilizatori);
    }

    public static void AdaugaUtilizatori(Utilizator utilizator)
    {
        if (!Utilizatori.Exists(u => u.Email == utilizator.Email))
        {
            Utilizatori.Add(utilizator);
            SalveazaUtilizatori();
        }
        else
        {
            Console.WriteLine("Utilizatorul exista deja!");
        }
    }
}