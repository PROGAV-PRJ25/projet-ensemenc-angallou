public class QueCalorose : Maladie
{
<<<<<<< HEAD
    // Maladie ciblant les fleurs de glace mais sensible aux boules de glace
    public QueCalorose(int X, int Y) : base(X, Y, "Boule de glace", typeof(FleurDeGlace))
=======
    public QueCalorose(int X, int Y)
        : base(X, Y, false, 100, "Boule de glace", typeof(FleurDeGlace))
>>>>>>> refs/remotes/origin/main
    {
        gravite = 0.3; // Réduit de 30% la satisfaction d'une plante infectée
    }
    public override void Infecter(Plante plante) // Méthode permettant d'infecter une plante
    {
        if (EstPlanteCible(plante) && plante.maladie == null) // Si la plante n'est pas malade et est la cible privilégiée de la quécalorose (ici Fleur de glace)
        {
            plante.maladie = this; // Alors la plante attrape la quécalorose
            Console.WriteLine($"{plante.nom} a attrapé la quécalorose !");
        }
    }
<<<<<<< HEAD
=======

    public void Agoniser(Plante plante)
    {
        if (digestion)
        {
            delaiSurvie--;
            if (delaiSurvie == 0)
            {
                plante.etat = false;
                Console.WriteLine(
                    $"{plante.nom} est mort : la quécalorose a eu raison de votre plante !"
                );
            }
        }
    }
>>>>>>> refs/remotes/origin/main
}
