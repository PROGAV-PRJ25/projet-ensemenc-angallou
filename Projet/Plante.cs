public abstract class Plante
{
    public int x { get; set; }
    public int y { get; set; }
    public bool etat { get; set; }
    //1 = la plante va bien, 0 = nul
    public bool miam { get; set; }
    //nature de la plante : si elle est bonne à manger ou pas
    public string saison { get; set; }
    //public Terrain terrain; TODO2
    public int espacement { get; set; }
    public int place { get; set; }
    public int vitesse { get; set; }
    // faire un dictionnaire pour les maladies TODO1
    public int esperanceVie { get; set; }
    public int nbFruits { get; set; }

    public const Dictionary<int, string> maladie = new Dictionary<int, string>
    {
        { 1, "peste"},
        {2, "choléra"}
    };
    public void Plante(int X, int Y, bool Etat, bool Miam, string Saison, int Espacement, int Place, int Vitesse, int EsperanceVie, int NbFruits)
    {
        X = X;
        Y = Y;
        Etat = etat;
        Miam = miam;
        Saison = saison;
        //Terrain TODO2
        Espacement = espacement;
        Place = place;
        Vitesse = vitesse;
        //maladie TODO1
        EsperanceVie = esperanceVie;
        NbFruits = nbFruits;

    }
}