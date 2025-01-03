namespace SistemECommerce;

public class Comanda
{
    public int Id { get; set; }
    public DateTime DataComenzii { get; set; }
    public string Status { get; set; } = "In Procesare";
    public string AdresaLivrare { get; set; }
    public List<(Produs, int)> Produse { get; set; } = new List<(Produs, int)>();
    public decimal Total { get; set; }

    public (bool succes, string errormessage) Valid()
    {
        if (Produse == null || Produse.Count == 0)
        {
            return (false, "Comanda nu contine produse");
        }

        foreach (var (produs, cantitate) in Produse)
        {
            if (produs.Validare().succes==false)
            {
                return (produs.Validare().succes,produs.Validare().errormessage);
            }

            if (cantitate <= 0)
            {
                return (false, $"Produsul {produs.Nume} are o cantitate invalida( {cantitate} )");
            }

            if (cantitate > produs.Stoc)
            {
                return (false,"Produsul " + produs.Nume + " nu are stoc suficient (cerut: "+cantitate+" disponibil: "+produs.Stoc);
            }
        }
        return (true, string.Empty);
    }
    public decimal CalculeazaTotal()
    {
        decimal total = 0;
        foreach (var (produs,cantitate) in Produse)
        {
            decimal pret = produs.CalculeazaPretFinal(cantitate);
            total += pret * cantitate;
        }

        return total;
    }
}