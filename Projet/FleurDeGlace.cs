public class FleurDeGlace : Plante
{
    public Inventaire inventaire;

    public FleurDeGlace(Inventaire inv)
        : base(
            "Fleur de glace",
            0,
            0,
            true,
            false,
            new Hiver(),
            new Ocean(),
            1,
            1,
            1,
            0.7,
            0.3,
            -10,
            15,
            20,
            0,
            "❄️"
        )
    {
        inventaire = inv;
    }

    public override void ActiverPouvoirSpecial()
    {
        Console.WriteLine($"{nom} a donné une boule de glace !");
        // Ajouter boules de glace à l'inventaire
    }
    /*
    public override bool ResisteAuFroid()
    {
        return true;
    }
    */
}
