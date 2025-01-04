namespace SistemECommerce;

public abstract class Reducere
{
    //public string Tip { get; set; }
    public abstract decimal AplicareReducere(decimal pretInitial, int cantitate = 1);
}

public class DiscountProcent : Reducere {
    public double Procent { get; set; }

    public override decimal AplicareReducere(decimal pretInitial, int cantitate = 1) {
        return pretInitial - (pretInitial * (decimal)Procent / 100);
    }
}

public class DiscountFix : Reducere {
    public decimal Valoare { get; set; }

    public override decimal AplicareReducere(decimal pretInitial, int cantitate = 1) {
        return pretInitial - Valoare;
    }
}

public class Reducere2Plus1 : Reducere {
    public override decimal AplicareReducere(decimal pretInitial, int cantitate = 1) {
        if (cantitate >= 3) {
            return pretInitial * (cantitate - cantitate / 3);
        }
        return pretInitial * cantitate;
    }
}
