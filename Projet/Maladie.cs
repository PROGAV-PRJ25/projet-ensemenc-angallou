public abstract class Maladie
{
    public int x { get; set; }
    public int y { get; set; }
    public string faiblesse { get; set; } // Faiblesse de la maladie
    public Type typePlanteCible { get; set; } // Type de plante visée par la maladie
    public double gravite { get; set; } // Taux de réduction de satisfaction de la plante (ex: 0.3)

    public Maladie(int X, int Y, string Faiblesse, Type TypePlanteCible)
    {
        x = X;
        y = Y;
        faiblesse = Faiblesse;
        typePlanteCible = TypePlanteCible;
        gravite = 0.3; // Gravité constante
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
