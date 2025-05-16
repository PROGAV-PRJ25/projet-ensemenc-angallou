public class FleurDeGlace : Plante
{
    public Inventaire inventaire;
    public FleurDeGlace(int X, int Y, Inventaire inv) : base("Fleur de glace", X, Y, true, false, new Hiver(), new Ocean(), 1, 1, 1, 0.7, 0.3, -10, 15, new QueCalorose(), 20, 0)
    {
        emoji = "❄️";
        inventaire = inv;
    }
    public override void ActiverPouvoirSpecial()
    {
        Console.WriteLine($"{nom} a donné une boule de glace !");
        // Ajouter boules de glace à l'inventaire
    }
    public override bool ResisteAuFroid()
    {
        return true;
    }

}