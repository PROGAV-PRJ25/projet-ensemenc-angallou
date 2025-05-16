public class Kart
{
    private Random rng = new Random();
    public bool actif;
    public int ligneCible;
    public bool frappéParEclair;
    public Kart()
    {
        actif = false;
        frappéParEclair = false;
    }
    public void Rouler(int maxLignes)
    {
        actif = true;
        frappéParEclair = false;
        ligneCible = rng.Next(0, maxLignes); // le kart va rouler sur une ligne au hasard
        Console.WriteLine($"\n Le kart fonce droit sur la ligne {ligneCible} !");
    }
    public void FoudroyerKart()
    {
        frappéParEclair = true;
        actif = false;
        Console.WriteLine("Vous avez arrêté le kart à temps avec un éclair !");
    }
    public void DetruireLigne(Grille grille)
    {
        if (frappéParEclair || !actif) return;

        for (int col = 0; col < grille.colonnes; col++)
        {
            if (grille.cases[ligneCible, col].plante != null)
            {
                Console.WriteLine($"La plante {grille.cases[ligneCible, col].plante.nom} a été détruite !");
                grille.cases[ligneCible, col].plante.etat = false;
            }
        }
        actif = false;
    }
}