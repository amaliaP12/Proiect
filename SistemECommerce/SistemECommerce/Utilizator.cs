namespace SistemECommerce;

public class Utilizator
{
    public int Id { get; set; }
    public string Nume { get; set; }
    public string Email { get; set; }
    public string Parola { get; set; }
    public string Rol { get; set; } = "Client";

    public Utilizator(int id, string nume, string email, string parola, string rol)
    {
        Id = id;
        Nume = nume;
        Email = email;
        Parola = parola;
        Rol = rol;
    }
    
}