public class FleurDeFeu : Plante
{
    public Inventaire inventaire;
    public FleurDeFeu(int X, int Y, Inventaire inv) : base("Fleur de feu", X, Y, true, false, new Ete(), new Volcan(), 1, 1, 1, 0.3, 0.7, 15, 40, new Glaglaose(), 20, 0)
    {
        emoji = "🔥";
        inventaire = inv;
    }
    public override void ActiverPouvoirSpecial()
    {
        Console.WriteLine($"{nom} a donné une boule de feu !");
        // Ajouter boules de feu à l'inventaire
    }
    public override bool ResisteAuFeu()
    { 
        return true;
    }
}