public class Ocean : Terrain
{
    public Ocean()
    {
        nom = "Océan";
    }
    public override void ReagirASaison(Saison saison) // Le terrain océan gèle en hiver, ce qui a des répercussions (non implémenté)
    {
        if (saison.nom == "Hiver")
            Console.WriteLine("L'océan a gelé !");
    }
}