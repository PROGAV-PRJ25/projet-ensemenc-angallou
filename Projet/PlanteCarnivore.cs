public class PlanteCarnivore : Plante
{
    public bool boostCheddar = false;
<<<<<<< HEAD
    public PlanteCarnivore() : base("Plante Carnivore", 0, 0, true, false, new Printemps(), new ArcEnCiel(), 0, 1, 4, 0.4, 0.6, 10, 35, 40, 0) { }
    
    public override void Croissance(Terrain terrain, bool espacement, double eau, double lumiere, int temp) // En plus de croître, la plante carnivore peut commencer à manger ses voisines si son taux de satisfaction n'est pas assez élevé
=======
    public Inventaire inventaire;

    public PlanteCarnivore(Inventaire inv)
        : base(
            "Plante Carnivore",
            0,
            0,
            true,
            false,
            new Printemps(),
            new ArcEnCiel(),
            1,
            1,
            1,
            0.5,
            0.7,
            10,
            35,
            30,
            20,
            "🪴"
        )
    {
        inventaire = inv;
    }

    public override void Croissance(
        Terrain terrain,
        bool espacement,
        double eau,
        double lumiere,
        int temp
    )
>>>>>>> refs/remotes/origin/main
    {
        base.Croissance(terrain, espacement, eau, lumiere, temp);

        if (Satisfaction(terrain, espacement, eau, lumiere, temp) < 0.8) // Si le taux de satisfaction de la plante est inférieur à 80%
        {
<<<<<<< HEAD
            Console.WriteLine($"La plante carnivore a faim... Elle risque de dévorer une de ses voisines...");
            // Gérer ce comportement dans la Grille (non implémenté)
        }
    }

    public void MangerToxinelles(List<ArbreACheddar> voisins) // Méthode permettant aux plantes carnivores de manger les toxinelles qui infectent un arbre à cheddar voisin
=======
            Console.WriteLine(
                $"La plante carnivore a faim... Elle risque de dévorer une de ses voisines..."
            );
            // Gérer ce comportement dans la Grille
        }
    }

    public void MangerToxinelles(List<ArbreACheddar> voisins)
>>>>>>> refs/remotes/origin/main
    {
        foreach (var v in voisins) // On parcourt les arbres à cheddar voisins de la plante carnivore
        {
            if (v.maladie is Toxinelles toxinelles && toxinelles.digestion) // Si l'arbre à cheddar est infecté de toxinelles 
            {
                int alea = boostCheddar ? 100 : 50; // Plus de chances que la plante mange des toxinelles si on lui donne du cheddar 
                if (rng.Next(100) < alea) // 50% de chances sans cheddar, 100% avec
                {
<<<<<<< HEAD
                    toxinelles.digestion = false; // Les toxinelles ont été mangées, elle ne font plus de mal à l'arbre à cheddar
                    Console.WriteLine($"La plante carnivore a mangé les toxinelles qui infectaient {v.nom}");
=======
                    toxinelles.digestion = false;
                    Console.WriteLine(
                        $"La plante carnivore a mangé les toxinelles qui infectaient {v.nom}"
                    );
>>>>>>> refs/remotes/origin/main
                }
                else // Si la plante carnivore n'a pas mangé les toxinelles
                {
                    Console.WriteLine(
                        $"La plante carnivore n'a pas réussi à manger les toxinelles qui infectaient {v.nom}"
                    );
                }
            }
        }
    }

<<<<<<< HEAD
    public override void RecupererObjet()
    {
        Console.WriteLine("La plante carnivore ne donne pas de fruits.");
    }
}
=======
    /* public override void ActiverPouvoirSpecial()
    {
        // Donne des graines à sa mort ?
        // Un peu too much en vrai, go finir ce qu'on fait d'abord
    } */
}
>>>>>>> refs/remotes/origin/main
