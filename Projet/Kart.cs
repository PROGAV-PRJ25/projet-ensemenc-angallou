public class Kart
{
    private Random rng = new Random();
    public int ligneCible;
    public bool frappéParEclair;

    public Kart()
    {
        frappéParEclair = false; // Le kart n'a pas été frappé par un éclair
    }

    public void Rouler(int maxLignes) // Affiche un message indiquant la ligne sur laquelle le kart va rouler
    {
        ligneCible = rng.Next(0, maxLignes); // Le kart va rouler sur une ligne au hasard
        Console.WriteLine($"\n Mario et son kart foncent droit sur la ligne {ligneCible} !");
    }

    public void FoudroyerKart() // Méthode qui permet de stopper le kart
    {
        frappéParEclair = true; // Le kart a été foudroyé
        Console.WriteLine("Vous avez arrêté Mario à temps avec un éclair !");
    }

    public void DetruireLigne(Grille grille) // Méthode qui permet au kart de détruire les plantes d'une même ligne
    {
        if (frappéParEclair)
            return; // Si le kart a été foudroyé, le kart ne détruit rien... cette fois-ci

        Console.WriteLine($"Mario roule sur la ligne {ligneCible} !");

        for (int col = 0; col < grille.colonnes; col++) // On parcourt toutes les cases de la ligne
        {
            if (grille.cases[ligneCible, col].plante != null) // S'il y a une plante sur cette case
            {
                Console.WriteLine(
                    $"La plante {grille.cases[ligneCible, col].plante.nom} a été détruite !"
                );
                grille.cases[ligneCible, col].plante.etat = false; // Alors la plante meurt écrasée (etat = false)
            }
        }
        frappéParEclair = true; // On passe cet attribut à true afin que le kart ne repasse pas une deuxième fois dans ce tour
    }
}
