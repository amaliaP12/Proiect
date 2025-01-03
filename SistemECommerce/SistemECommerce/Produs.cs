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

    public (bool succes, string errormessage) Validare()
    {
        if (string.IsNullOrEmpty(Nume))
        {
            return (false, "Nume invalid");
        }
            
        if (Pret <= 0)
        {
            return (false, $"Produsul are pret invalid");
        }

        if (Stoc < 0)
        {
            return (false, $"Produsul are stocul invalid");
        }

        if (string.IsNullOrEmpty(Categorie))
        {
            return (false, "Categoria produsului este invalida");
        }

        if (Rating < 0)
        {
            return (false, $"Produsul are rating invalid");
        }
        return (true, string.Empty);
    }
    public decimal CalculeazaPretFinal(int cantitate)
    {
        decimal PretFinal = Pret;
        foreach (var reducere in Reduceri)
        {
            PretFinal=reducere.AplicareReducere(PretFinal,cantitate);
        }

        return PretFinal;
    }

    public void AdaugaRating(int ratingNou)
    {
        
    }
}