public class Fromage : Terrain
{
    public Fromage()
    {
        nom = "Fromage";
    }
<<<<<<< HEAD
    public override void ReagirASaison(Saison saison) // Le terrain fromage fond en été, ce qui a des répercussions (non implémenté)
=======

    public override string RecupererTerrain()
    {
        return "🟨";
    }

    public override void ReagirASaison(Saison saison)
>>>>>>> refs/remotes/origin/main
    {
        if (saison.nom == "Été")
            Console.WriteLine("Le terrain fromage a fondu !");
    }
}
