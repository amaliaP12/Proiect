namespace SistemECommerce;

public class Utilizator
{
    public int Id { get; set; }
    public string Nume { get; set; }
    public string Email { get; set; }
   

    public Utilizator(int id, string nume, string email)
    {
        Id = id;
        Nume = nume;
        Email = email;
    }
}