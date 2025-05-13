public class Toxinelles : Maladie
{
public Toxinelles (int X, int Y) : base (X, Y, false, ArbreACheddar hihi, 100, "Plantes Carnivores") { }
=======
    public Toxinelles(int X, int Y)
        : base(X, Y, false, 100, "Plantes Carnivores", typeof(ArbreACheddar)) { }

    public override bool EstPlanteCible(Plante PlanteCible)
    {
        return PlanteCible is ArbreACheddar;
    }
}
