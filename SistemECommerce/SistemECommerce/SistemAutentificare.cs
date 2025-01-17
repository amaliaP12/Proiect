namespace SistemECommerce;

public class SistemAutentificare
{
    //lista utilizatorilor inregistratți în sistem
    private List<Utilizator> utilizatori;

    //constructor inițializare sistem autentificare
    public SistemAutentificare()
    {
        //inițializare listă utilizatori
        utilizatori = new List<Utilizator>();
    }

    //functie inregistrare utilizatori noi
    public void InregistreazaUtilizator(Utilizator utilizator)
    {
        //verifica existența unui utilizator cu același email
        if (utilizatori.Exists(u => u.Email == utilizator.Email))
        {
            Console.WriteLine("Un utilizator cu acest email există deja.");
        }
        else
        {
            //adaugare utilizator in lista
            utilizatori.Add(utilizator);
            Console.WriteLine("Utilizator înregistrat cu succes.");
        }
    }
    
    //functie autentificare pe baza email si parolă
    public Utilizator? Autentifica(string email, string parola)
    {
        //incarcare utilizatori din UserManager
        UserManager.IncarcaUtilizatori(); 
        //cautare client in functie de email si parola
        var client = UserManager.Clienti.FirstOrDefault(c => 
            c.Email.Equals(email, StringComparison.OrdinalIgnoreCase) && c.VerificaParola(parola));

        if (client != null)
        {
            Console.WriteLine($"Autentificat ca Client: {client.Nume}");
            return client;//returnare client autentificat
        }
        //cautare ]n listă administratori dupa email si parola
        var admin = UserManager.Administratori.FirstOrDefault(a =>
            a.Email.Equals(email, StringComparison.OrdinalIgnoreCase) && a.VerificaParola(parola));

        if (admin != null)
        {
            Console.WriteLine($"Autentificat ca Administrator: {admin.Nume}");
            return admin;//returnare administrator autentificat
        }
        
        Console.WriteLine("Autentificare esuata! Verifica datele introduse.");
        return null;//daca utilizatorul nu a fost gasit se va returna null
    }

}

