public abstract class Plante
{
    protected Random rng = new Random();
    public string nom { get; set; }
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
    public string emoji { get; set; }
    public Plante(string Nom, int X, int Y, bool Etat, bool Miam, Saison SaisonM, Terrain TerrainPref, int Espacement, int Place, int Vitesse, double BesoinEau, double BesoinLumiere, int TempMin, int TempMax, Maladie Maladie, int EsperanceVie, int NbFruits)
    {
        nom = Nom;
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
        maladie = Maladie; //maladie à laquelle la plante est la plus sensible
        esperanceVie = EsperanceVie;
        nbFruits = NbFruits;
    }
    public double Satisfaction(Terrain TerrainActuel, bool Espacement, double Eau, double Lumiere, int Temp) // Satisfaction varie de 0 à 1
    {
        double tauxSatisfaction = 0;
        if (TerrainActuel == terrainPref)
            tauxSatisfaction += 0.2;
        if (Espacement)
            tauxSatisfaction += 0.2;
        if (Eau >= besoinEau)
            tauxSatisfaction += 0.2;
        if (Lumiere >= besoinLumiere)
            tauxSatisfaction += 0.2;
        if (Temp >= tempMin && Temp <= tempMax)
            tauxSatisfaction += 0.2;
        return tauxSatisfaction;
    }
    public void Croissance(Terrain TerrainActuel, bool Espacement, double Eau, double Lumiere, int Temp)
    {
        double satisfaction = Satisfaction(TerrainActuel, Espacement, Eau, Lumiere, Temp);
        if (etat == true) // si la plante est toujours vivante
        {
            if (satisfaction < 0.5)
            {
                etat = false; // la plante meurt
                Console.WriteLine($"La plante {nom} est morte par manque de conditions satisfaisantes.");
            }
            else if (satisfaction < 0.7)
            {
                place += vitesse / 2; // croissance réduite
                Console.WriteLine($"La plante {nom} pousse lentement.");
            }
            else if (satisfaction < 0.9)
            {
                place += vitesse; // croissance normale
                Console.WriteLine($"La plante {nom} pousse normalement.");
            }
            else
            {
                place += vitesse * 2; // croissance augmentée
                Console.WriteLine($"La plante {nom} pousse rapidement.");
            }
        }
        else // Si la plante est morte
        {
            Console.WriteLine("Cette plante est morte, il serait sage de la déraciner");
        }

        if (maladie != null && maladie.EstPlanteCible(this) && rng.NextDouble() < 0.2)
        {
            maladie.Infecter(this);
        }
    }
    public void Afficher()
    {
        string statut = etat ? "Vivante" : "Morte" // si etat == true, affiche "Vivante" sinon "Morte"
        string infoMaladie = maladie != null ? maladie.GetType().Name : "Aucune"; // si a une maladie, affiche le nom de la maladie sinon affiche "Aucune"
        Console.WriteLine($"{nom} - Statut : {statut} - Taille : {place} - Fruits : {nbFruits} - Maladie : {infoMaladie}");
    }
    public virtual void ActiverPouvoirSpecial() { } // toutes les plantes n'auront pas forcément de pouvoir spécial
    public virtual string RecupererEmoji()
    {
        if (!etat)
            return "☠️"; //la plante est morte
        if (maladie != null)
            return "🤢"; //la plante est malade
        return emoji;
    }
}
