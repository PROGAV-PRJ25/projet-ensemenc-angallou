public abstract class Maladie
{
    public int x { get; set; }
    public int y { get; set; }
    public string faiblesse { get; set; } // Faiblesse de la maladie
    public Type typePlanteCible { get; set; } // Type de plante visée par la maladie
<<<<<<< HEAD
    public double gravite { get; set; } // Taux de réduction de satisfaction de la plante (ex: 0.3)
    public Maladie(int X, int Y, string Faiblesse, Type TypePlanteCible)
=======
    public double gravite { get; set; } // Taux de réduction de satisfaction (ex: 0.3)
    public bool digestion { get; set; }
    public int delaiSurvie { get; set; }

    public Maladie(
        int X,
        int Y,
        bool ModeUrgence,
        double Attaque,
        string Faiblesse,
        Type TypePlanteCible
    )
>>>>>>> refs/remotes/origin/main
    {
        x = X;
        y = Y;
        faiblesse = Faiblesse;
        typePlanteCible = TypePlanteCible;
<<<<<<< HEAD
        gravite = 0.3; // Gravité constante
=======
        gravite = modeUrgence ? 0.5 : 0.2; // Définition automatique de la gravité en fonction du mode d'urgence. Si c'est true alors c'est 0.5, etc.
>>>>>>> refs/remotes/origin/main
    }
    public virtual bool EstPlanteCible(Plante plante) // Renvoie un booléen indiquant si la maladie peut infecter la plante ou non
    {
        return plante.GetType() == typePlanteCible;
    }
    public virtual void Infecter(Plante plante) // Méthode permettant d'infecter la plante rentrée en paramètre
    {
        if (plante.maladie == null) // Si la plante n'est pas déjà malade
        {
            plante.maladie = this; // Alors elle attrape cette maladie
            Console.WriteLine($"{plante.nom} a été infectée par {this.GetType().Name} !");
        }
    }
}
