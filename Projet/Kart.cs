public class Kart
{
    private Random rng = new Random();
<<<<<<< HEAD
    public int ligneCible; 
    public bool frappéParEclair; 
=======
    public bool actif;
    public int ligneCible;
    public bool frappéParEclair;

>>>>>>> refs/remotes/origin/main
    public Kart()
    {
        frappéParEclair = false; // Le kart n'a pas été frappé par un éclair
    }
<<<<<<< HEAD
    public void Rouler(int maxLignes) // Affiche un message indiquant la ligne sur laquelle le kart va rouler
=======

    public void Rouler(int maxLignes)
>>>>>>> refs/remotes/origin/main
    {
        ligneCible = rng.Next(0, maxLignes); // Le kart va rouler sur une ligne au hasard
        Console.WriteLine($"\n Mario et son kart foncent droit sur la ligne {ligneCible} !");
    }
<<<<<<< HEAD
    public void FoudroyerKart() // Méthode qui permet de stopper le kart 
=======

    public void FoudroyerKart()
>>>>>>> refs/remotes/origin/main
    {
        frappéParEclair = true; // Le kart a été foudroyé
        Console.WriteLine("Vous avez arrêté Mario à temps avec un éclair !");
    }
<<<<<<< HEAD
    public void DetruireLigne(Grille grille) // Méthode qui permet au kart de détruire les plantes d'une même ligne
    {
        if (frappéParEclair) return; // Si le kart a été foudroyé, le kart ne détruit rien... cette fois-ci
=======

    public void DetruireLigne(Grille grille)
    {
        if (frappéParEclair || !actif)
            return;
>>>>>>> refs/remotes/origin/main

        Console.WriteLine($"Mario roule sur la ligne {ligneCible} !");

        for (int col = 0; col < grille.colonnes; col++) // On parcourt toutes les cases de la ligne
        {
            if (grille.cases[ligneCible, col].plante != null) // S'il y a une plante sur cette case
            {
<<<<<<< HEAD
                Console.WriteLine($"La plante {grille.cases[ligneCible, col].plante.nom} a été détruite !");
                grille.cases[ligneCible, col].plante.etat = false; // Alors la plante meurt écrasée (etat = false)
=======
                Console.WriteLine(
                    $"La plante {grille.cases[ligneCible, col].plante.nom} a été détruite !"
                );
                grille.cases[ligneCible, col].plante.etat = false;
>>>>>>> refs/remotes/origin/main
            }
        }
        frappéParEclair = true; // On passe cet attribut à true afin que le kart ne repasse pas une deuxième fois dans ce tour
    }
}
