public class ArbreACheddar : Plante
{


    public ArbreACheddar(int X, int Y, string Type, bool Etat, bool Miam, string Saison, int Espacement, int Place, int Vitesse, int EsperanceVie, int NbFruits) : base(int X, int Y, "Arbre à cheddar", true, bool Miam, string Saison, int Espacement, int Place, int Vitesse, int EsperanceVie, int NbFruits)
    {
        x = X;
        y = Y;
        type = Type;
        etat = Etat;
        miam = Miam; //pour la plante carnivore, si c'est bon ou pas
        saison = Saison;
        //Terrain TODO2
        espacement = Espacement;
        place = Place;
        vitesse = Vitesse;
        //maladie TODO1
        esperanceVie = EsperanceVie;
        nbFruits = NbFruits;
    }

}