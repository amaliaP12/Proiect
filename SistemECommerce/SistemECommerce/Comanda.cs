namespace SistemECommerce;

public class Comanda
{
    public int Id { get; set; }
    public DateTime DataComenzii { get; set; }
    public string Status { get; set; } = "In Procesare";
    public string AdresaLivrare { get; set; }
    public List<(Produs, int)> Produse { get; set; } = new List<(Produs, int)>();
    public decimal Total { get; set; }
}