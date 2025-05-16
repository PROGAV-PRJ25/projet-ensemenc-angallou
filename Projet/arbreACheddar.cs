public class ArbreACheddar : Plante
{
    public Inventaire inventaire;
    private static Random rng = new Random();
    public ArbreACheddar(int X, int Y, Inventaire inv) : base("Arbre à Cheddar", X, Y, true, true, new Automne(), new Fromage(), 1, 3, 1, 0.6, 0.5, 10, 25, new Toxinelles(), 50, 4)
    {
        emoji = "🧀";
        inventaire = inv;
    }
    public override void ActiverPouvoirSpecial()
    {
        int alea = rng.Next(100); // calcule une proba entre 0 et 99

        if (alea < 40)
        {
            inventaire.Ajouter("éclair");
            Console.WriteLine($"{nom} vous offre un éclair !");
        }
        else if (alea < 80)
        {
            inventaire.Ajouter("sérum");
            Console.WriteLine($"{nom} vous offre un sérum contre les maladies !");
        }
        else
        {
            inventaire.Ajouter("étoile");
            Console.WriteLine($"{nom} vous offre une étoile magique !");
        }
    }
}