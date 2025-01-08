namespace SistemECommerce;

public class Utilizator
{
    public int Id { get; set; }
    public string Nume { get; set; }
    public string Email { get; set; }
    public string Parola { get; set; }
   

    public Utilizator(int id, string nume, string email, string parola)
    {
        Id = id;
        Nume = nume;
        Email = email;
        Parola = parola;
    }
    
    public bool VerificaParola(string parola)
    {
        return Parola == parola;
    }
}