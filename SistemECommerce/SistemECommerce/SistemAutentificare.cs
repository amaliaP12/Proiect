namespace SistemECommerce;

public class SistemAutentificare
{

    private List<Utilizator> utilizatori;

    public SistemAutentificare()
    {
        utilizatori = new List<Utilizator>();
    }

    public void InregistreazaUtilizator(Utilizator utilizator)
    {
        if (utilizatori.Exists(u => u.Email == utilizator.Email))
        {
            Console.WriteLine("Un utilizator cu acest email există deja.");
        }
        else
        {
            utilizatori.Add(utilizator);
            Console.WriteLine("Utilizator înregistrat cu succes.");
        }
    }

    public Utilizator Autentifica(string email, string parola)
    {
        var utilizator = utilizatori.FirstOrDefault(u => u.Email == email);
        if (utilizator == null)
        {
            Console.WriteLine("Email incorect.");
            return null;
        }

        if (!utilizator.VerificaParola(parola))
        {
            Console.WriteLine("Parola incorectă.");
            return null;
        }

        Console.WriteLine($"Bine ai venit, {utilizator.Nume}!");
        return utilizator;
    }

    public Utilizator Autentifica(Utilizator utilizator)
    {
        var user = utilizatori.FirstOrDefault(u => u.Id == utilizator.Id);
        if (user == null)
        {
            Console.WriteLine("ID incorect.");
            return null;
        }

        Console.WriteLine($"Bine ai venit, {user.Nume}!");
        return user;
    }
}

