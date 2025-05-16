public abstract class Maladie
{
    public int x { get; set; }
    public int y { get; set; }
    public bool modeUrgence { get; set; }
    public double attaque { get; set; } // Potentiel de dégâts directs (ex: perte de vie)
    public string faiblesse { get; set; }
    public Type typePlanteCible { get; set; } // Type de plante visée par la maladie

    public double gravite { get; set; } // Taux de réduction de satisfaction (ex: 0.3)

    public Maladie(
        int X,
        int Y,
        bool ModeUrgence,
        double Attaque,
        string Faiblesse,
        Type TypePlanteCible
    )
    {
        x = X;
        y = Y;
        modeUrgence = ModeUrgence;
        attaque = Attaque;
        faiblesse = Faiblesse;
        typePlanteCible = TypePlanteCible;
        gravite = modeUrgence ? 0.5 : 0.2; // Définition automatique de la gravité en fonction du mode d'urgence
    }

    public virtual bool EstPlanteCible(Plante plante)
    {
        return plante.GetType() == typePlanteCible;
    }

    public virtual void Infecter(Plante plante)
    {
        if (plante.maladie == null)
        {
            plante.maladie = this;
            Console.WriteLine($"{plante.nom} a été infectée par {this.GetType().Name} !");
        }
    }
}

//gérer le mode urgence
//gérer les différentes maladies
// gérer les différentes attaques
//est-ce que je met un bool il y a plante ? mehhh on verra ça dans les codes au cas par cas
// Ne pas oublier de faire le mode urgence et les différentes manières de se protéger des invasions

// faiblesse TODO
