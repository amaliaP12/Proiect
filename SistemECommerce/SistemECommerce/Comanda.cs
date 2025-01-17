namespace SistemECommerce;

public class Comanda
{
    public int Id { get; set; }
    public Client Client { get; set; }  
    public DateTime DataComenzii { get; set; }=DateTime.Now;
    public string Status { get; set; } = "In Procesare";
    public string AdresaLivrare { get; set; }
    public DateTime? DataLivrarii { get; set; }
    public List<(Produs, int)> Produse { get; set; } = new List<(Produs, int)>();
    public decimal Total => CalculeazaTotal();
    
    //constructor initializare comenzi
    public Comanda(Client client, string adresa)
    {
        var r= new Random();
        int random = r.Next(1, 10000);
        Id = random;
        Client = client;
        Produse = new List<(Produs, int)>();
        DataComenzii = DateTime.Now;
        AdresaLivrare = adresa;
    }

    //validare produs comanda
    public (bool succes, string errormessage) Valid()
    {
        //verificare dacă lista e goala
        if (Produse == null || Produse.Count == 0)
        {
            return (false, "Comanda nu contine produse");
        }

        foreach (var (produs, cantitate) in Produse)
        {
            //verificare dacă produsul e valid
            if (produs.Validare().succes==false)
            {
                return (produs.Validare().succes,produs.Validare().errormessage);
            }
            //verificare dacă cantitatea e valida
            if (cantitate <= 0)
            {
                return (false, $"Produsul {produs.Nume} are o cantitate invalida( {cantitate} )");
            }
            //verificare daca stocul e suficient
            if (cantitate > produs.Stoc)
            {
                return (false,"Produsul " + produs.Nume + " nu are stoc suficient (cerut: "+cantitate+" disponibil: "+produs.Stoc+")");
            }
        }
        //validare finală comandă
        return (true, string.Empty);
    }
    
    //functție pentru totalul comenzii, pe baza produselor și cantitătilor
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

    //modificare status comandă, daca este permis 
    public bool ModificaStatus(string nouStatus)
    {
        var statusuri = new List<string> { "In Procesare", "Expediata", "Livrata" };
        //verifică validitatea noului status
        if (!statusuri.Contains(nouStatus))
        {
            Console.WriteLine("Eroare: Status invalid!");
            return false;
        }

        if (Status == "Livarata" || Status == "Anulata")
        {
            Console.WriteLine("Eroare: Comanda finalizata nu poate fi modificata!");
            return false;
        }
        //actualizare status
        Status = nouStatus;
        if (nouStatus == "Expediata")
        {
            //data livrarii estimata
            DataLivrarii=DateTime.Now.AddDays(3);
        }
        else if (nouStatus == "Livrata")
        {
            //data livrarii estimată
            DataLivrarii=DateTime.Now;
        }
        Console.WriteLine($"Statusul comenzii a fost modificat la: {Status}");
        return true;//status actualizat cu succes
    }
}
