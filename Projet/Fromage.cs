public class Fromage : Terrain
{
    public Fromage()
    {
        nom = "Fromage";
    }
    public override void ReagirASaison(Saison saison) // Le terrain fromage fond en été, ce qui a des répercussions (non implémenté)
    {
        if (saison.nom == "Été")
            Console.WriteLine("Le terrain fromage a fondu !");
    }
}