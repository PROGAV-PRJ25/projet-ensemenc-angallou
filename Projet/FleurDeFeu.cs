public class FleurDeFeu : Plante
{
    public Inventaire inventaire; // On a besoin de l'inventaire car cette plante donne des boules de feu

    public FleurDeFeu(Inventaire inv)
        : base(
            "Fleur de feu",
            0,
            0,
            true,
            false,
            new Ete(),
            new Volcan(),
            0,
            1,
            4,
            0.3,
            0.7,
            15,
            40,
            20,
            0
        )
    {
        inventaire = inv;
    }

    public override void RecupererObjet() // Permet d'ajouter une boule de feu à l'inventaire
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
