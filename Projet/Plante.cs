public abstract class Plante
{
    public int x { get; set; }
    public int y { get; set; }
    public bool etat { get; set; }
    public bool miam { get; set; }
    public string saison { get; set; }
    public string terrainPref { get; set; }
    public int espacement { get; set; }
    public int place { get; set; }
    public int vitesse { get; set; }
    public double besoinEau { get; set; }
    public double besoinLumiere { get; set; }
    public int tempMin { get; set; }
    public int tempMax { get; set; }
    public string maladie { get; set; }
    public int esperanceVie { get; set; }
    public int nbFruits { get; set; }
    public Plante(int X, int Y, bool Etat, bool Miam, string Saison, string TerrainPref, int Espacement, int Place, int Vitesse, double BesoinEau, double BesoinLumiere, int TempMin, int TempMax, string Maladie, int EsperanceVie, int NbFruits)
    {
        x = X;
        y = Y;
        etat = Etat; //false si satisfaction < 0.5
        miam = Miam;
        saison = Saison;
        terrainPref = TerrainPref; // si le terrain est le préféré, alors la satisfaction augmente
        espacement = Espacement; // si espacement respecté, alors la satisfaction augmente
        place = Place; // si il y a de la place, alors elle va croitre
        vitesse = Vitesse;
        besoinEau = BesoinEau; //si respecté, augmente
        besoinLumiere = BesoinLumiere; // si respecté, augmente
        tempMin = TempMin; // si moins diminue
        tempMax = TempMax; // si plus diminue
        maladie = Maladie; 
        esperanceVie = EsperanceVie;
        nbFruits = NbFruits;
    }
    /*
    public bool VerifLimPlateau(int x, int y)
    { }
    */
    public double Satisfaction()
    {
        double tauxSatisfaction = 0;
        if 
        return tauxSatisfaction;
    }
    /*
    public void Croissance()
    {
        if (etat == true)
        {
            if (Satisfaction() < 0.5)
            {
                etat = false;
                vitesse = -1;
            }
            else if (Satisfaction() >= 0.5 && Satisfaction() <= 0.8)
            {

            }
        }
        else
        {
            Console.WriteLine("Cette plante est morte, il serait sage de la déraciner");
        }
    }
    */
}