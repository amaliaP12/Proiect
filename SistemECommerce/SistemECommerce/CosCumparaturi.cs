namespace SistemECommerce;

public class CosCumparaturi
{
    public Dictionary<Produs,int>Produse{get;set;}=new Dictionary<Produs,int>();

    public void AdaugaProdus(Produs produs, int cantitate)
    {
        if (cantitate <= 0)
        {
            Console.WriteLine("Cantitatea trebuie sa fie mai mare decat 0.");
            return;
        }

        if (produs.Stoc < cantitate)
        {
            Console.WriteLine("Produsul nu este disponibil in aceasta cantitate.");
            return;
        }
        if (Produse.ContainsKey(produs))
        {
            Produse[produs] += cantitate;
        }
        else
        {
            Produse[produs] = cantitate;
        }

        produs.Stoc -= cantitate;// se actualizeaza stocul produsului
        Console.WriteLine($"Produsul {produs.Nume} a fost adaugat in cos {cantitate} bucati.");
    }
    
    public void EliminaProdus(Produs produs)
    {
        if (Produse.Remove(produs))
        {
            Console.WriteLine($"Produsul{produs.Nume} a fost eliminat din cos.");
            
        }
        else
        {
            Console.WriteLine($"Produsul {produs.Nume} nu se afla in cos.");
        }
    }

    public void ModificaCantitate(Produs produs, int cant_noua)
    {
        if (!Produse.ContainsKey(produs))
        {
            Console.WriteLine($"Produsul {produs.Nume} nu se afla in cosul de cumparaturi.");
            return;
        }
        int cant_curenta=Produse[produs];
        if (cant_noua <= 0)
        {
            EliminaProdus(produs);
            Console.WriteLine("Produsul a fost eliminat deoarece cantitatea este mai mica decat 0.");
            
        }
        else if (cant_noua > produs.Stoc + cant_curenta)
        {
            Console.WriteLine($"Stoc insuficient pentru a seta cantitatea {cant_noua} . Disponibil :{produs.Stoc + cant_curenta }");
        }
        else
        {
            produs.Stoc += cant_curenta - cant_noua;
            Produse[produs] = cant_noua;
            Console.WriteLine($"Cantitatea pentru produsul {produs.Nume} a fost modificata la {cant_noua}");
            
        }
    }

    public decimal Calculeaza_total()
    {
        decimal total=0;
        foreach (var (produs, cantitate) in Produse)
        {
            total +=produs.Pret*cantitate;
            
        }
        Console.WriteLine($"Totalul cosului este {total} RON.");
        return total;
    }
    
    
    
    
    
}