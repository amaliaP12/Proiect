namespace SistemECommerce;

public class Administrator:Utilizator
{
    public Administrator(int id, string nume, string email, string parola) : base(id, nume, email, parola)
    {
    }

    //functii:adauga editeaza sterge produs
    public void AdaugareProdus(List<Produs> produse, Produs produsNou)
    {
        produse.Add(produsNou);
        Console.WriteLine($"Produsul {produsNou.Nume} a fost adăugat cu succes.");
    }

    public void EditeazaProdus(List<Produs> produse, int idProdus, string numeNou, decimal pretNou)
    {
        var produs = produse.Find(p => p.Id == idProdus);
        if (produs != null)
        {
            produs.Nume = numeNou;
            produs.Pret = pretNou;
            Console.WriteLine($"Produsul cu ID-ul {idProdus} a fost actualizat.");
        }
        else
        {
            Console.WriteLine($"Produsul cu ID-ul {idProdus} nu a fost găsit.");
        }
    }

    public void StergeProdus(List<Produs> produse, int idProdus)
    {
        var produs = produse.Find(p => p.Id == idProdus);
        if (produs != null)
        {
            produse.Remove(produs);
            Console.WriteLine($"Produsul cu ID-ul {idProdus} a fost șters.");
        }
        else
        {
            Console.WriteLine($"Produsul cu ID-ul {idProdus} nu a fost găsit.");
        }
    }
}
