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
    private int NrRatinguri = 0;
    
    public Produs(int id, string nume, string descriere, decimal pret, int stoc, string categorie)
    {
        Id = id;
        Nume = nume;
        Descriere = descriere;
        Pret = pret;
        Stoc = stoc;
        Categorie = categorie;
        Rating = 0;
    }

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

        return Math.Max(PretFinal,0);
    }

    public void AdaugaRating(int ratingNou)
    {
        if (ratingNou < 1 || ratingNou > 5)
        {
            throw new AggregateException("Ratingul trebuie sa fie intre 1 si 5.");
        }
        Rating=(Rating*NrRatinguri+ratingNou)/++NrRatinguri;
    }
    
}