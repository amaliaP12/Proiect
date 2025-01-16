namespace SistemECommerce;

public class Wishlist
{
    public List<Produs>Produse { get; set; } = new List<Produs>();

    public void AdaugaProdus(Produs produs)
    {
        if (!Produse.Contains(produs))
        {
            Produse.Add(produs);
            Console.WriteLine("Produsul a fost adaugat in wishlist!");
        }
        else
        {
            Console.WriteLine("Produsul se afla deja in wishlist!");
        }
    }

    public void EliminaProdus(Produs produs)
    {
        if (Produse.Remove(produs))
        {
            Console.WriteLine($"Produsul{produs.Nume} a fost eliminat din wishlist.");
            
        }
        else
        {
            Console.WriteLine($"Produsul {produs.Nume} nu se afla in wishlist.");
        }
    }

    public void MutaInCos(Produs produs, int cantitate, CosCumparaturi cosCumparaturi)
    {
        if (!Produse.Contains(produs))
        {
            Console.WriteLine($"Produsul {produs.Nume} nu se afla in wishlist.");
            return;
        }

        if (produs.Stoc < cantitate)
        {
            Console.WriteLine($"Stoc insuficient pentru produsul {produs.Nume}. Disponibil {produs.Stoc}");
            return;
        }
        cosCumparaturi.AdaugaProdus( produs,cantitate);
       Produse.Remove(produs);
       Console.WriteLine($"Produsul {produs.Nume} a fost mutat in cosul de cumparaturi.");
       
    }
}