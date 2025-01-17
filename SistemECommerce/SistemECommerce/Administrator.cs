namespace SistemECommerce;

public class Administrator:Utilizator
{
    public Administrator(int id, string nume, string email, string parola) : base(id, nume, email, parola)
    {
    }

    //functie aduagre produs nou produs nou in lista
    public void AdaugareProdus(List<Produs> produse, Produs produsNou)
    {
        produse.Add(produsNou);
        Console.WriteLine($"Produsul {produsNou.Nume} a fost adăugat cu succes.");
    }

    //functie editare produs existent
    public void EditeazaProdus(List<Produs> produse, int idProdus, string numeNou, decimal pretNou)
    {
        var produs = produse.Find(p => p.Id == idProdus);
        if (produs != null)
        {
            //actualizare nume si pret
            produs.Nume = numeNou;
            produs.Pret = pretNou;
            Console.WriteLine($"Produsul cu ID-ul {idProdus} a fost actualizat.");
        }
        else
        {
            Console.WriteLine($"Produsul cu ID-ul {idProdus} nu a fost găsit.");
        }
    }

    //functie stergere produs din lista
    public void StergeProdus(List<Produs> produse, int idProdus)
    {
        //cautare in functie de id
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
    //functie vizualizare comenzi
    public void VizualizareComenzi(List<Comanda> comenzi)
    {
        foreach (var comanda in comenzi)
        {
            Console.WriteLine($"ID: {comanda.Id}, Client: {comanda.Client.Nume}, Status: {comanda.Status}, Total: {comanda.Total:C}");
        }
    }

    //functie modificare status, a carei cautare se gasire to pe id
    public void ModificareStatusComanda(List<Comanda> comenzi, int idComanda, string nouStatus)
    {
        var comanda = comenzi.Find(c => c.Id == idComanda);
        if (comanda != null)
        {
            //modificarea statusului comenzii
            if (comanda.ModificaStatus(nouStatus))
            {
                Console.WriteLine($"Statusul comenzii cu ID {idComanda} a fost modificat la: {nouStatus}");
            }
        }
        else
        {
            Console.WriteLine($"Comanda cu ID {idComanda} nu a fost găsită.");
        }
    }
    
    //functie generare factura pentru o comanda
    public void GenerareFactura(Comanda comanda)
    {
        Console.WriteLine("Factura generata:");
        Console.WriteLine($"ID Comanda: {comanda.Id}");
        Console.WriteLine($"Client: {comanda.Client.Nume}");
        Console.WriteLine("Produse:");
        foreach (var (produs, cantitate) in comanda.Produse)
        {
            Console.WriteLine($"{produs.Nume} - Cantitate: {cantitate} - Pret: {produs.Pret * cantitate:C}");
        }
        Console.WriteLine($"Total: {comanda.Total:C}");
    }
    
    //functie monitorizare stoc redus
    public void MonitorizareStoc(List<Produs> produse)
    {
        Console.WriteLine("Produse cu stoc redus:");
        foreach (var produs in produse)
        {
            //Am ales prag stoc redus de 10 produse
            if (produs.Stoc < 10) 
            {
                Console.WriteLine($"{produs.Nume} - Stoc: {produs.Stoc}");
            }
        }
    }
    
    //cautarea produselor care necesita actualizare se bazeaza tot pe id
    public void ActualizareStoc(List<Produs> produse, int idProdus, int cantitateNoua)
    {
        var produs = produse.Find(p => p.Id == idProdus);
        if (produs != null)
        {
            //actualizarea stocului
            produs.Stoc = cantitateNoua;
            Console.WriteLine($"Stocul produsului {produs.Nume} a fost actualizat la {cantitateNoua}.");
        }
        else
        {
            Console.WriteLine($"Produsul cu ID {idProdus} nu a fost găsit.");
        }
    }
    
    //functie generare raport vanzari
    public void GenerareRaportVanzari(List<Comanda> comenzi)
    {
        //inițializare venit total pe 0, ca la orice sumă
        decimal venitTotal = 0;
        //am ales să le fac dicționar deoarece am nevoie de tuplul -produs, cantitate-
        var produseVandute = new Dictionary<string, int>();

        foreach (var comanda in comenzi)
        {
            //adaug totalul comenzii la venitul total
            venitTotal += comanda.Total;
            foreach (var (produs, cantitate) in comanda.Produse)
            {
                if (!produseVandute.ContainsKey(produs.Nume))
                {
                    produseVandute[produs.Nume] = 0;
                }
                //actualizarea cantitatii produsului vandut
                produseVandute[produs.Nume] += cantitate;
            }
        }

        Console.WriteLine("Raport vânzări:");
        Console.WriteLine($"Venit total: {venitTotal:C}");
        Console.WriteLine("Produse vândute:");
        foreach (var (numeProdus, cantitate) in produseVandute)
        {
            Console.WriteLine($"{numeProdus} - Cantitate: {cantitate}");
        }
    }
    //functie adaugare reducere la uun produs, cautarea produsului se realizeaza
    //tot dupa id
    public void AdaugareReducere(List<Produs> produse, int idProdus, Reducere reducere)
    {
        var produs = produse.Find(p => p.Id == idProdus);
        if (produs != null)
        {
            //Seteaza tipul reducerii pt serializare corecta
            reducere.Tip = reducere.GetType().Name;
            //adaugare reduere la produs
            produs.Reduceri.Add(reducere);
            Console.WriteLine($"Reducerea a fost adaugată la produsul {produs.Nume}.");
        }
        else
        {
            Console.WriteLine($"Produsul cu ID {idProdus} nu a fost găsit.");
        }
    }
}
