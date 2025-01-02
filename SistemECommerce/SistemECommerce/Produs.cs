namespace SistemECommerce;

public class Produs
{
    public int Id { get; set; }
    public string Nume { get; set; }
    public string Descriere { get; set; }
    public decimal Pret { get; set; }
    public int Stoc { get; set; }
    public double Rating { get; set; }
    public string Categorie { get; set; }
    public List<Reducere> Reduceri { get; set; } = new List<Reducere>();
}