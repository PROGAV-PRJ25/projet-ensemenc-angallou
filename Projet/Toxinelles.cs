public class Toxinelles : Maladie
{
    public Toxinelles(int X, int Y)
        : base(X, Y, false, 100, "Plantes Carnivores", typeof(ArbreACheddar)) { }

    public override bool EstPlanteCible(Plante PlanteCible)
    {
        return PlanteCible is ArbreACheddar;
    }
}
//if plante.x && plante.y == maladie (x, y)
// & if plante.nom == plantecible
// then full attack TODO
// if defense.x && defense.y == maladie(x, y) (avec une marge si plante à proximité)
// then remove menace
