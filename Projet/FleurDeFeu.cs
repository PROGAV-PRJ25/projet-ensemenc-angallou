public class FleurDeFeu : Plante
{
<<<<<<< HEAD
    public Inventaire inventaire; // On a besoin de l'inventaire car cette plante donne des boules de feu
    public FleurDeFeu(Inventaire inv) : base("Fleur de feu", 0, 0, true, false, new Ete(), new Volcan(), 0, 1, 4, 0.3, 0.7, 15, 40, 20, 0)
=======
    public Inventaire inventaire;

    public FleurDeFeu(Inventaire inv)
        : base(
            "Fleur de feu",
            0,
            0,
            true,
            false,
            new Ete(),
            new Volcan(),
            1,
            1,
            1,
            0.3,
            0.7,
            15,
            40,
            new Glaglaose(),
            20,
            0
        )
>>>>>>> refs/remotes/origin/main
    {
        inventaire = inv;
    }
<<<<<<< HEAD
    public override void RecupererObjet() // Permet d'ajouter une boule de feu à l'inventaire
=======

    public override void ActiverPouvoirSpecial()
>>>>>>> refs/remotes/origin/main
    {
        Console.WriteLine($"{nom} a donné une boule de feu !");
        inventaire.nbBoulesFeu++; // Ajouter boules de feu à l'inventaire
    }
    // fonctionnalité non implémentée
    /*
    public override bool ResisteAuFeu()
    {
        return true;
    }
    */
}
