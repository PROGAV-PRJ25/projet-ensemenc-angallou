public class Fromage : Terrain
{
    public Fromage()
    {
        nom = "Fromage";
    }
    public override string RecupererTerrain()
    {
        return "🟨";
    }
    public override void ReagirASaison(Saison saison)
    {
        if (saison.nom == "Été")
            Console.WriteLine("Le terrain fromage a fondu !");
    }
}