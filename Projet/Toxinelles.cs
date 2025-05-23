public class Toxinelles : Maladie
{
<<<<<<< HEAD
    public bool digestion { get; set; } // Indique si les toxinelles sont en train d'infecter une plante ou non
    public int delaiSurvie { get; set; } // Correspond au nombre de semaines restant avant que les toxinelles finissent par tuer la plante
    // Maladie ciblant les arbres à cheddar mais sensible aux plantes carnivores
    public Toxinelles(int X, int Y) : base(X, Y, "Plante Carnivore", typeof(ArbreACheddar))
=======
    public Toxinelles(int X, int Y)
        : base(X, Y, false, 100, "Plantes Carnivores", typeof(ArbreACheddar))
>>>>>>> refs/remotes/origin/main
    {
        digestion = false; // Par défaut, la maladie n'a pas encore infecté de plante
        delaiSurvie = 3; // Compte à rebours avant la mort si les toxinelles n'ont pas été anéanties
        gravite = 0; // Les toxinelles ne réduisent pas le taux de satisfaction, car elles sont une menace à court terme
    }

    public override void Infecter(Plante plante) // Méthode permettant d'infecter une plante
    {
        if (EstPlanteCible(plante) && plante.maladie == null) // Si la plante n'est pas malade et est la cible privilégiée des toxinelles (ici Arbre à cheddar)
        {
            digestion = true; // Les toxinelles ont infecté la plante
            Console.WriteLine($"{plante.nom} a été infecté par des toxinelles !");
        }
        else
            Console.WriteLine("Impossible d'infecter cette Plante!");
    }

<<<<<<< HEAD
    public void Agoniser(Plante plante) // Méthode qui modélise l'effet des toxinelles sur la plante
=======
    public void Agoniser(Plante plante)
>>>>>>> refs/remotes/origin/main
    {
        if (digestion && delaiSurvie > 0) // Si les toxinelles ont infecté la plante et que le délai de survie n'est pas encore atteint
        {
            delaiSurvie--; // La plante se rapproche du moment fatidique
            if (delaiSurvie == 0) // Si le délai est écoulé 
            {
<<<<<<< HEAD
                plante.etat = false; // La plante est morte
                Console.WriteLine($"{plante.nom} est mort : les toxinelles ont eu raison de votre plante !");
=======
                plante.etat = false;
                Console.WriteLine(
                    $"{plante.nom} est mort : les toxinelles ont eu raison de votre plante !"
                );
>>>>>>> refs/remotes/origin/main
            }
        }
    }
}
