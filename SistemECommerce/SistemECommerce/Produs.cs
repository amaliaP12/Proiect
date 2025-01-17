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
    //listă reduceri aplicabile produsului
    public List<Reducere> Reduceri { get; set; } = new List<Reducere>();
    private int NrRatinguri = 0;
    
    //constructor inițializare produs
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
    
    //funcție validare atribute produs
    public (bool succes, string errormessage) Validare()
    {
        //verificare validitate nume
        if (string.IsNullOrEmpty(Nume))
        {
            return (false, "Nume invalid");
        }
        //verificare validitate preț
        if (Pret <= 0)
        {
            return (false, $"Produsul are pret invalid");
        }
        //verificare validitate stoc
        if (Stoc < 0)
        {
            return (false, $"Produsul are stocul invalid");
        }
        //validitate categorie
        if (string.IsNullOrEmpty(Categorie))
        {
            return (false, "Categoria produsului este invalida");
        }
        //validitate rating
        if (Rating < 0)
        {
            return (false, $"Produsul are rating invalid");
        }
        //validitate id
        if (Id.GetType() != typeof(int))
        {
            return (false, "Id invalid");
        }
        //validitate produs în sine
        return (true, string.Empty);
    }
    //functie calcul preț final(include reduceri)
    public decimal CalculeazaPretFinal(int cantitate)
    {

        decimal PretFinal = Pret;
        //itereaza prin reduceri
        foreach (var reducere in Reduceri)
        {
            PretFinal=reducere.AplicareReducere(PretFinal,cantitate);
        }
        //returneaza pret finla, nu mai mic de zero
        return Math.Max(PretFinal, 0);
    }

    //functie adaugare rating
    public void AdaugaRating(int ratingNou)
    {
        //verificare rating valid
        if (ratingNou < 1 || ratingNou > 5)
        {
            throw new AggregateException("Ratingul trebuie sa fie intre 1 si 5.");
        }
        //calcul noua medie rating, dupa adaugarea ultimului rating
        Rating=(Rating*NrRatinguri+ratingNou)/++NrRatinguri;
    }
    
}