public class FleurDeGlace : Plante
{
    public Inventaire inventaire; // On a besoin de l'inventaire car cette plante donne des boules de glace
    public FleurDeGlace(Inventaire inv) : base("Fleur de glace", 0, 0, true, false, new Hiver(), new Ocean(), 0, 1, 4, 0.7, 0.3, -10, 15, 20, 0)
    {
        inventaire = inv;
    }
    public override void RecupererObjet() // Permet d'ajouter une boule de feu à l'inventaire
    {
        Console.WriteLine($"{nom} a donné une boule de glace !");
        inventaire.nbBoulesGlace++; // Ajouter boules de glace à l'inventaire
    }
    // fonctionnalité non implémentée
    /*
    public override bool ResisteAuFroid()
    {
        return true;
    }
    */

}