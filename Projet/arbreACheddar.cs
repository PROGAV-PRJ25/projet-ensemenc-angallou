public class ArbreACheddar : Plante
{
<<<<<<< HEAD
    public Inventaire inventaire; // On a besoin de l'inventaire car cette plante donne du cheddars et d'autres objets
    public ArbreACheddar(Inventaire inv) : base("Arbre à cheddar",0,0,true,true, new Automne(), new Fromage(),0,1,6,0.6,0.5,10,25,50,2)
=======
    public Inventaire inventaire;

    public ArbreACheddar(Inventaire inv)
        : base(
            "Arbre à Cheddar",
            0,
            0,
            true,
            true,
            new Automne(),
            new Fromage(),
            1,
            3,
            1,
            0.6,
            0.5,
            10,
            25,
            50,
            4,
            "🧀"
        )
>>>>>>> refs/remotes/origin/main
    {
        inventaire = inv;
    }

    public override void RecupererObjet() // Permet d'ajouter un cheddar et un autre objet tiré aléatoirement à l'inventaire
    {
        int alea = rng.Next(100); // Calcule une proba entre 0 et 99

        inventaire.nbCheddar++;
        Console.WriteLine($"{nom} vous offre un cheddar !");

        if (alea < 40) // 40% de chances d'obtenir un éclair
        {
            inventaire.nbEclairs++;
            Console.WriteLine($"{nom} vous offre aussi un éclair !");
        }
        else if (alea < 80) // 40% de chances d'obtenir un sérum
        {
            inventaire.nbSerums++;
            Console.WriteLine($"{nom} vous offre aussi un sérum contre les maladies !");
        }
        else // 20% de chances d'obtenir une étoile
        {
            inventaire.nbEtoiles++;
            Console.WriteLine($"{nom} vous offre aussi une étoile magique !");
        }
    }
}
