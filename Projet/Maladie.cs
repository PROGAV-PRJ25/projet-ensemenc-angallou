public abstract class Maladie
{
    public int x { get; set; }
    public int y { get; set; }
    public bool modeUrgence { get; set; }
    public double attaque { get; set; }
    public string faiblesse { get; set; }
    public Type typePlanteCible { get; set; } // Type de plante visée par la maladie 

    public Maladie(int X, int Y, bool ModeUrgence, double Attaque, string Faiblesse, Type TypePlanteCible)
    {
        x = X;
        y = Y;
        modeUrgence = ModeUrgence;
        attaque = Attaque;
        faiblesse = Faiblesse;
        typePlanteCible = TypePlanteCible;
    }
    public virtual bool EstPlanteCible(Plante plante)
    {
        return plante.GetType() == typePlanteCible;
    }

    public abstract void Infecter(Plante plante) { } 
}

//gérer le mode urgence
//gérer les différentes maladies
// gérer les différentes attaques
//est-ce que je met un bool il y a plante ? mehhh on verra ça dans les codes au cas par cas
// Ne pas oublier de faire le mode urgence et les différentes manières de se protéger des invasions

// faiblesse TODO
