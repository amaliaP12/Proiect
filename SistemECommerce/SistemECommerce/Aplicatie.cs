namespace SistemECommerce;

class Aplicatie
{
    private List<Produs> produse;
    private List<Comanda> comenzi;
    private SistemAutentificare sistemAutentificare;

    public Aplicatie()
    {
        produse = new List<Produs>();
        comenzi = new List<Comanda>();
        sistemAutentificare = new SistemAutentificare();
        IncarcaDateInitiale();
    }

    private void IncarcaDateInitiale()
    {
        // Încarcă date doar dacă lista este goală
        var produseIncarcate = DataManager.IncarcaDate<List<Produs>>("produse.json");
        if (produseIncarcate != null && produseIncarcate.Count > 0)
        {
            produse = produseIncarcate;
        }
        var comenziIncarcate = DataManager.IncarcaDate<List<Comanda>>("comenzi.json");
        if (comenziIncarcate != null && comenziIncarcate.Count > 0)
        {
            comenzi = comenziIncarcate;
        }

        UserManager.IncarcaUtilizatori();
    }


    public void Porneste()
    {
        Console.WriteLine("Bine ai venit la Sistemul ECommerce!");
        while (true)
        {
            Console.WriteLine("\n1. Autentificare\n2. Inregistrare Client\n3. Inregistrare Administrator\n4. Iesire\nAlege o optiune:");
            var optiune = Console.ReadLine();

            if (optiune == "1")
            {
                Console.Write("Email: ");
                string email = Console.ReadLine();
                Console.Write("Parola: ");
                string parola = Console.ReadLine();

                var utilizator = sistemAutentificare.Autentifica(email, parola);

                if (utilizator is Administrator admin)
                {
                    MeniuAdministrator(admin);
                }
                else if (utilizator is Client client)
                {
                    MeniuClient(client);
                }
                else
                {
                    Console.WriteLine("Autentificare esuata!");
                }
            }
            else if (optiune == "2") // Înregistrare Client
            {
                Console.Write("Nume: ");
                string nume = Console.ReadLine();
                Console.Write("Email: ");
                string email = Console.ReadLine();
                Console.Write("Parola: ");
                string parola = Console.ReadLine();
                var clientNou = new Client(new Random().Next(1, 100000), nume, email, parola);
                UserManager.AdaugaClient(clientNou);
                Console.WriteLine("Client inregistrat cu succes!");
            }
            else if (optiune == "3") // Înregistrare Administrator
            {
                Console.Write("Nume: ");
                string nume = Console.ReadLine();
                Console.Write("Email: ");
                string email = Console.ReadLine();
                Console.Write("Parola: ");
                string parola = Console.ReadLine();
                var adminNou = new Administrator(new Random().Next(1, 100000), nume, email, parola);
                UserManager.AdaugaAdministrator(adminNou);
                Console.WriteLine("Administrator inregistrat cu succes!");
            }
            else if (optiune == "4")
            {
                SalveazaDate();
                Console.WriteLine("La revedere!");
                break;
            }
            else
            {
                Console.WriteLine("Optiune invalida!");
            }
        }
    }

    private void MeniuAdministrator(Administrator admin)
    {
        while (true)
        {
            Console.WriteLine("\n1. Adauga produs\n2. Editeaza produs\n3. Sterge produs\n4. Vizualizeaza comenzi\n5. Modifica status comanda\n6. Genereaza factura\n7. Monitorizare stoc\n8. Actualizeaza stoc\n9. Genereaza raport vanzari\n10. Adauga reducere\n11. Iesire\nAlege o optiune:");
            var optiune = Console.ReadLine();

            if (optiune == "1")
            {
                Console.Write("Nume produs: ");
                string nume = Console.ReadLine();
                Console.Write("Descriere: ");
                string descriere = Console.ReadLine();
                Console.Write("Pret: ");
                decimal pret = decimal.Parse(Console.ReadLine());
                Console.Write("Stoc: ");
                int stoc = int.Parse(Console.ReadLine());
                Console.Write("Categorie: ");
                string categorie = Console.ReadLine();

                var produsNou = new Produs(produse.Count + 1, nume, descriere, pret, stoc, categorie);
                admin.AdaugareProdus(produse, produsNou);
            }
            else if (optiune == "2")
            {
                Console.Write("ID produs: ");
                int id = int.Parse(Console.ReadLine());
                Console.Write("Nume nou: ");
                string nume = Console.ReadLine();
                Console.Write("Pret nou: ");
                decimal pret = decimal.Parse(Console.ReadLine());

                admin.EditeazaProdus(produse, id, nume, pret);
            }
            else if (optiune == "3")
            {
                Console.Write("ID produs: ");
                int id = int.Parse(Console.ReadLine());
                admin.StergeProdus(produse, id);
            }
            else if (optiune == "4")
            {
                admin.VizualizareComenzi(comenzi);
            }
            else if (optiune == "5")
            {
                Console.Write("ID comanda: ");
                int id = int.Parse(Console.ReadLine());
                Console.Write("Nou status: ");
                string status = Console.ReadLine();

                admin.ModificareStatusComanda(comenzi, id, status);
            }
            else if (optiune == "6")
            {
                Console.Write("ID comanda: ");
                int id = int.Parse(Console.ReadLine());
                var comanda = comenzi.Find(c => c.Id == id);
                if (comanda != null)
                {
                    admin.GenerareFactura(comanda);
                }
                else
                {
                    Console.WriteLine("Comanda nu a fost găsită.");
                }
            }
            else if (optiune == "7")
            {
                admin.MonitorizareStoc(produse);
            }
            else if (optiune == "8")
            {
                Console.Write("ID produs: ");
                int id = int.Parse(Console.ReadLine());
                Console.Write("Cantitate nouă: ");
                int cantitate = int.Parse(Console.ReadLine());

                admin.ActualizareStoc(produse, id, cantitate);
            }
            else if (optiune == "9")
            {
                admin.GenerareRaportVanzari(comenzi);
            }
            else if (optiune == "10")
            {
                Console.Write("ID produs: ");
                int id = int.Parse(Console.ReadLine());
                Console.Write("Tip reducere (1: Procent, 2: Fix, 3: 2+1): ");
                int tip = int.Parse(Console.ReadLine());
            
                Reducere reducere;
                if (tip == 1)
                {
                    Console.Write("Procent: ");
                    double procent = double.Parse(Console.ReadLine());
                    reducere = new DiscountProcent { Procent = procent };
                }
                else if (tip == 2)
                {
                    Console.Write("Valoare: ");
                    decimal valoare = decimal.Parse(Console.ReadLine());
                    reducere = new DiscountFix { Valoare = valoare };
                }
                else
                {
                    reducere = new Reducere2Plus1();
                }
            
                admin.AdaugareReducere(produse, id, reducere);
            }
            else if (optiune == "11")
            {
                break;
            }
            else
            {
                Console.WriteLine("Optiune invalida!");
            }
        }
    }

    private void MeniuClient(Client client)
    {
        while (true)
        {
            Console.WriteLine("\n1. Vizualizeaza produse\n2. Adauga in cos\n3. Plaseaza comanda\n4. Anuleaza comanda\n5. Adauga in wishlist\n6.Adauga Rating\n7.Iesire\nAlege o optiune:");
            var optiune = Console.ReadLine();

            if (optiune == "1")
            {
                foreach (var produs in produse)
                {
                    Console.WriteLine($"ID: {produs.Id}, Nume: {produs.Nume}, Pret: {produs.Pret}, Stoc: {produs.Stoc}, Rating: {produs.Rating}, Reduceri: ");
                    foreach (var dis in produs.Reduceri)
                    {
                        Console.WriteLine($"{dis.Tip} ");
                    }
                }
            }
            else if (optiune == "2")
            {
                Console.Write("ID produs: ");
                int id = int.Parse(Console.ReadLine());
                Console.Write("Cantitate: ");
                int cantitate = int.Parse(Console.ReadLine());
                
                var produs = produse.Find(p => p.Id == id);
                if (produs != null)
                {
                    client.AgaugaCosCumparaturi(produs, cantitate);
                }
                else
                {
                    Console.WriteLine("Produsul nu a fost gasit!");
                }
            }
            else if (optiune == "3")
            {
                Console.Write("Adresa de livrare: ");
                string adresa = Console.ReadLine();
                client.AdaugaComanda(adresa);
                comenzi.AddRange(client.comenzi);
            }
            else if (optiune == "4")
            {
                Console.Write("ID comanda: ");
                int id = int.Parse(Console.ReadLine());
                client.AnuleazaComanda(id);
            }
            else if (optiune == "5")
            {
                Console.Write("ID produs: ");
                int id = int.Parse(Console.ReadLine());
                var produs = produse.Find(p => p.Id == id);

                if (produs != null)
                {
                    client.AgaugaWishlist(produs);
                }
                else
                {
                    Console.WriteLine("Produsul nu a fost gasit!");
                }
            }
            else if (optiune == "6")
            {
                Console.Write("ID produs: ");
                int id = int.Parse(Console.ReadLine());
                Console.Write("Rating (1-5): ");
                int rating = int.Parse(Console.ReadLine());
                var produs = produse.Find(p => p.Id == id);

                if (produs != null)
                {
                    try
                    {
                        produs.AdaugaRating(rating);
                        Console.WriteLine("Rating adaugat cu succes!");
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }
                else
                {
                    Console.WriteLine("Produsul nu a fost gasit!");
                }
            }
            else if(optiune=="7")
            {
                break;
            }
            else
            {
                Console.WriteLine("Optiune invalida!");
            }
        }
    }

    private void SalveazaDate()
    {
        UserManager.SalveazaUtilizatori();
        if (produse != null && produse.Count > 0)
        {
            DataManager.SalvareDate("produse.json", produse);
        }
        else
        {
            
            Console.WriteLine("Nu sunt produse de adaugat! ");
        }

        if (comenzi != null && comenzi.Count > 0)
        {
             DataManager.SalvareDate("comenzi.json", comenzi);
        }
        else
        {
            Console.WriteLine("Nu sunt comenzi de adaugat! ");
        }
       
    }
}

