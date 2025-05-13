public abstract class Plante
{
    public int x { get; set; }
    public int y { get; set; }
    public bool etat { get; set; }
    public bool miam { get; set; }
    public Saison saison { get; set; }
    public Terrain terrainPref { get; set; }
    public int espacement { get; set; }
    public int place { get; set; }
    public int vitesse { get; set; }
    public double besoinEau { get; set; }
    public double besoinLumiere { get; set; }
    public int tempMin { get; set; }
    public int tempMax { get; set; }
    public Maladie maladie { get; set; }
    public int esperanceVie { get; set; }
    public int nbFruits { get; set; }
    public Plante(int X, int Y, bool Etat, bool Miam, Saison SaisonM, Terrain TerrainPref, int Espacement, int Place, int Vitesse, double BesoinEau, double BesoinLumiere, int TempMin, int TempMax, Maladie Maladie, int EsperanceVie, int NbFruits)
    {
        x = X;
        y = Y;
        etat = Etat; //false si satisfaction < 0.5
        miam = Miam;
        saison = SaisonM;
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
    public double Satisfaction(string Terrain, bool Espacement, double Eau, double lumiere, int Temp)
    {
        double tauxSatisfaction = 0;
        if (Terrain == terrainPref)
            tauxSatisfaction += 0.2;
        if (Espacement )    
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