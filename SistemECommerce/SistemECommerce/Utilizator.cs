namespace SistemECommerce;

public class Utilizator
{
    public int Id { get; set; }
    public string Nume { get; set; }
    public string Email { get; set; }
   

    public Utilizator(int id, string nume, string email, string parola, string rol)
    {
        Id = id;
        Nume = nume;
        Email = email;
    }

    //mi l-a generat intellisense-ul
    protected Utilizator(int id, string nume, string email)
    {
        throw new NotImplementedException();
    }
}