namespace SistemECommerce;

public class GestionareProduse
{
    private List<Produs> Produse = new List<Produs>();

    public void AdaugaProdus(Produs produs) {
        Produse.Add(produs);
    }

    public List<Produs> ObtineProduse() {
        return Produse;
    }
}