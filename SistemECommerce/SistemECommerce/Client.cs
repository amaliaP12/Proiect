namespace SistemECommerce;


public class Client:Utilizator
{ 
    public Wishlist wishlist { get; set; }
    public CosCumparaturi cosCumparaturi { get; set; }
    public List<Comanda> comenzi { get; set; }
    public Client(int id, string nume, string email,string parola) : base(id, nume, email,parola)
    {
        wishlist = new();
        cosCumparaturi = new();
        comenzi = new();
    }
    //functionalitate de adaugare in Wishlist
    public void AgaugaWishlist(Produs produs)
    {
        if (!wishlist.Produse.Contains(produs))
        {
            wishlist.Produse.Add(produs);
            Console.WriteLine($"Produsul{produs.Nume} a fost agaugat in wishlist");
        }
        else
        {
            Console.WriteLine($"Produsul {produs.Nume} se afla deja in wishlist");
        }
    }
    //functionalitate de adaugare in cosul de cumparaturi
    
    public void AgaugaCosCumparaturi(Produs produs,int cantitate)
    {
        if (produs.Stoc < cantitate)
        {
            Console.WriteLine($"Stocul este insuficient pentru{produs.Nume}. Disponibil: {produs.Stoc}");
            return;
        }

        if (cosCumparaturi.Produse.ContainsKey(produs))
        {
            cosCumparaturi.Produse[produs] += cantitate;
        }
        else
        {
            cosCumparaturi.Produse[produs] = cantitate;
        }
        Console.WriteLine($"Produsul {produs.Nume} a fost adaugat in cos ({cantitate} buc)");
       
    }
    //adauga o lista de comenzi direct in clasa client pt a stoca comenzile plasate de acest utilizator
    public void AdaugaComanda(string adresa)
    {
        if (cosCumparaturi.Produse.Count == 0)
        {
            Console.WriteLine($"Cosul de cumparaturi este gol.Adauga un produs!");
            return ;
        }

        var comandaNoua = new Comanda(comenzi.Count + 1, this, adresa);
        foreach (var produs in cosCumparaturi.Produse)
        {
            if (produs.Key.Stoc < produs.Value)
            {
             Console.WriteLine($"Produsul {produs.Key.Nume}nu este disponibil in aceasta cantitate!");
             return;
            } 
            comandaNoua.Produse.Add((produs.Key, produs.Value));
            produs.Key.Stoc -= produs.Value;
        }
        comenzi.Add(comandaNoua);
        cosCumparaturi.Produse.Clear();
        Console.WriteLine($"Comanda {comandaNoua.Id} a fost adaugata cu succes si este in curs de procesare.");
        
    }

    public void AnuleazaComanda(int comandaId)
    {
        Comanda comandaAnulat = null;
        foreach (var comanda in comenzi)
        {
            if (comanda.Id == comandaId)
            {
                comandaAnulat = comanda;
                break;
            }
        }

        if (comandaAnulat == null)
        {
            Console.WriteLine($"NU s-a gasit comanda cu Id-ul {comandaId}");
            return;
        }

        comandaAnulat.Status = "Anulata";
        foreach (var (produs,cantitate) in comandaAnulat.Produse)
        {
            produs.Stoc += cantitate;
        }
        Console.WriteLine($"Comanda cu ID {comandaId} a fost anulata si produsele au fost restabilite in cos!");
    }

}
