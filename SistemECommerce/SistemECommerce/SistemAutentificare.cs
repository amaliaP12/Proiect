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
    

    public Utilizator? Autentifica(string email, string parola)
    {
        UserManager.IncarcaUtilizatori(); 

        var client = UserManager.Clienti.FirstOrDefault(c => 
            c.Email.Equals(email, StringComparison.OrdinalIgnoreCase) && c.VerificaParola(parola));

        if (client != null)
        {
            Console.WriteLine($"Autentificat ca Client: {client.Nume}");
            return client;
        }

        var admin = UserManager.Administratori.FirstOrDefault(a =>
            a.Email.Equals(email, StringComparison.OrdinalIgnoreCase) && a.VerificaParola(parola));

        if (admin != null)
        {
            Console.WriteLine($"Autentificat ca Administrator: {admin.Nume}");
            return admin;
        }

        Console.WriteLine("Autentificare esuata! Verifica datele introduse.");
        return null;
    }

}

