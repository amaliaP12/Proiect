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
    public void VizualizeazaComenzi(List<Comanda> comenzi)
    {
        foreach (var comanda in comenzi)
        {
            Console.WriteLine($"ID: {comanda.Id}, Client: {comanda.Client.Nume}, Status: {comanda.Status}, Total: {comanda.Total:C}");
        }
    }

    public void ModificaStatusComanda(List<Comanda> comenzi, int idComanda, string nouStatus)
    {
        var comanda = comenzi.Find(c => c.Id == idComanda);
        if (comanda != null)
        {
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
    
    public void GenereazaFactura(Comanda comanda)
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
    
    public void MonitorizareStoc(List<Produs> produse)
    {
        Console.WriteLine("Produse cu stoc redus:");
        foreach (var produs in produse)
        {
            //Am adaugat prag de stoc redus pentru management mai eficient
            if (produs.Stoc < 10) 
            {
                Console.WriteLine($"{produs.Nume} - Stoc: {produs.Stoc}");
            }
        }
    }
    public void ActualizeazaStoc(List<Produs> produse, int idProdus, int cantitateNoua)
    {
        var produs = produse.Find(p => p.Id == idProdus);
        if (produs != null)
        {
            produs.Stoc = cantitateNoua;
            Console.WriteLine($"Stocul produsului {produs.Nume} a fost actualizat la {cantitateNoua}.");
        }
        else
        {
            Console.WriteLine($"Produsul cu ID {idProdus} nu a fost găsit.");
        }
    }
    
    
}
