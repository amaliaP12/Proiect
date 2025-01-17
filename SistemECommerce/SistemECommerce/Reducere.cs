
namespace SistemECommerce;

public class Reducere
{
    public string Tip { get; set; }
    public virtual decimal AplicareReducere(decimal pretInitial, int cantitate = 1)
    {
        return pretInitial;
    }

    public Reducere()
    {
        
    }
}

public class DiscountProcent : Reducere {
    public double Procent { get; set; }

    public DiscountProcent()
    {
        Tip = "DiscountProcent";
    }

    public override decimal AplicareReducere(decimal pretInitial, int cantitate = 1) {
        return pretInitial - (pretInitial * (decimal)Procent / 100);
    }
}

public class DiscountFix : Reducere {
    public decimal Valoare { get; set; }

    public DiscountFix()
    {
        Tip= "DiscountFix";
    }

    public override decimal AplicareReducere(decimal pretInitial, int cantitate = 1) {
        return pretInitial - Valoare;
    }
}

public class Reducere2Plus1 : Reducere {
    public Reducere2Plus1()
    {
        Tip= "Reducere2Plus1";
    }

    public override decimal AplicareReducere(decimal pretInitial, int cantitate = 1) {
        if (cantitate >= 3) {
            return pretInitial * (cantitate - cantitate / 3);
        }
        return pretInitial * cantitate;
    }
}
