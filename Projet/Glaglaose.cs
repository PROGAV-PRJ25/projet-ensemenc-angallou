public class Glaglaose : Maladie
{
    // Maladie ciblant les fleurs de feu mais sensible aux boules de feu
    public Glaglaose(int X, int Y) : base(X, Y, "Boule de feu", typeof(FleurDeFeu)) 
    {
        gravite = 0.3; // Réduit de 30% la satisfaction d'une plante infectée
    }
    public override void Infecter(Plante plante) // Méthode permettant d'infecter une plante
    {
        if (EstPlanteCible(plante) && plante.maladie == null) // Si la plante n'est pas malade et est la cible privilégiée de la glaglaose (ici Fleur de feu)
        {
            plante.maladie = this; // Alors la plante attrape la glaglaose
            Console.WriteLine($"{plante.nom} a attrapé la glaglaose !");
        }
    }
}

