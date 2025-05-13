public class Toxinelles : Maladie
{
public Toxinelles (int X, int Y) : base (X, Y, false, ArbreACheddar hihi, 100, "Plantes Carnivores") { }
}
//if plante.x && plante.y == maladie (x, y) 
// & if plante.nom == plantecible
// then full attack
// if defense.x && defense.y == maladie(x, y) (avec une marge si plante à proximité)
// then remove menace

//pour l'erreur avec la plante cible, c'est pck il cherche une plante précise...