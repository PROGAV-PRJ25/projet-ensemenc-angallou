public class Ocean : Terrain
{
    public Ocean()
    {
        nom = "Océan";
    }

    public override string RecupererTerrain()
    {
        return "🟦";
    }

    public override void ReagirASaison(Saison saison)
    {
        if (saison.nom == "Hiver")
            Console.WriteLine("L'océan a gelé !");
    }
}
