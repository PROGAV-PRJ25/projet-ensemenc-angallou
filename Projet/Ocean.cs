public class Ocean : Terrain
{
    public Ocean()
    {
        nom = "Océan";
    }
<<<<<<< HEAD
    public override void ReagirASaison(Saison saison) // Le terrain océan gèle en hiver, ce qui a des répercussions (non implémenté)
=======

    public override string RecupererTerrain()
    {
        return "🟦";
    }

    public override void ReagirASaison(Saison saison)
>>>>>>> refs/remotes/origin/main
    {
        if (saison.nom == "Hiver")
            Console.WriteLine("L'océan a gelé !");
    }
}
