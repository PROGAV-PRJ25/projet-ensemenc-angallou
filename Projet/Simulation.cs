public class Simulation
{
    private List<Maladie> maladiesDisponibles;
    private Random rng = new Random();

    public Calendrier calendrier;
    public Grille grille;
    public Inventaire inventaire;

    public enum ModeJeu
    {
        Classique,
        Urgence,
    }

    public ModeJeu modeActuel;
    private bool fin;

    public Simulation()
    {
        grille = new Grille();
        calendrier = new Calendrier();
        maladiesDisponibles = new List<Maladie>()
        {
            new Toxinelles(0, 0), // TODO
            new Toxinelles(0, 0),
            new Toxinelles(0, 0),
        };

        modeActuel = ModeJeu.Classique;
        inventaire = new Inventaire();
        fin = false;

        // J'ai mis des plantes dès le départ pour tester mais l'idéal serait de les planter soi-même
        grille.PlacerPlante(2, 2, new FleurDeFeu(inventaire));
        grille.PlacerPlante(4, 4, new ArbreACheddar(inventaire));
        grille.PlacerPlante(1, 1, new PlanteCarnivore(inventaire));
        grille.PlacerPlante(5, 3, new FleurDeGlace(inventaire));
    }

    public void LancerJeu()
    {
        while (!fin)
        {
            // Passage du kart toutes les 5 semaines
            if (calendrier.semaine % 5 == 0)
            {
                modeActuel = ModeJeu.Urgence;
            }

            if (modeActuel == ModeJeu.Classique)
            {
                LancerTourClassique();
            }
            else
            {
                LancerModeUrgence();
            }
        }
    }

    public void LancerTourClassique()
    {
        Saison saison = calendrier.saisonCourante;
        saison.CalculerMeteo();
        GenererMaladiesSemaine();

        double eau = saison.pluieActuelle;
        double lumiere = saison.soleilActuel;
        int temperature = saison.temperatureActuelle;

        Console.Clear();
        Console.WriteLine($"\n Semaine n°{calendrier.semaine} - {saison}");

        // Réactions en fonction des saisons
        foreach (var c in grille.cases)
        {
            c.terrain?.ReagirASaison(saison);
        }

        grille.Afficher();
        Console.WriteLine("\n Légende des emojis :");
        Console.WriteLine(
            "🔥 Fleur de feu ❄️ Fleur de glace 🧀 Arbre à cheddar 🪴 Plante Carnivore"
        );
        Console.WriteLine("☠️ Plante morte 🤢 Plante malade");
        Console.WriteLine("🟨 Fromage 🟥 Volcan 🟦 Océan 🌈 Arc-en-ciel");

        Console.WriteLine(
            $"\nInventaire : Boules de feu = {inventaire.nbBoulesFeu} - Boules de glace = {inventaire.nbBoulesGlace} - Eclairs = {inventaire.nbEclairs} - Cheddars = TODO"
        );

        List<Plante> plantes = new List<Plante>();
        /*
        foreach (Case c in grille.Cases())
        {
            if (c.plante != null)
            {
                plantes.Add(c.plante);
            }
        }
        */
        foreach (Plante plante in plantes)
        {
            Case caseActuelle = grille.cases[plante.x, plante.y];

            foreach (Maladie maladie in maladiesDisponibles)
            {
                if (
                    plante.x == maladie.x
                    && plante.y == maladie.y
                    && maladie.EstPlanteCible(plante)
                )
                {
                    plante.maladie = maladie; // elle est maintenant infectée
                    maladie.Infecter(plante); //TO DO
                    Console.WriteLine($"{plante.nom} est infectée par {maladie.GetType().Name} !");
                    // infection possible
                    // enlever de la vie aussi
                }
                if (plante.etat)
                {
                    bool bonEspacement = (plante.espacement <= plante.place);
                    plante.Croissance(plante.terrainPref, bonEspacement, eau, lumiere, temperature);
                    Console.WriteLine(
                        $"Plante {plante.nom} - Taille : {plante.place} - Etat : Vivante"
                    );
                }
                else
                {
                    Console.WriteLine($"Plante {plante.nom} - Etat : Décédée");
                }
            }

            //Interaction joueur
            Console.WriteLine(
                "\n Action ? (F=Feu, G=Glace, E=Eclair, Q=Quitter, Entrée=Continuer)"
            );
            var touche = Console.ReadKey(true);

            if (touche.Key == ConsoleKey.Q)
            {
                Console.WriteLine($"Fin de la partie !");
                fin = true;
                return;
            }
            else if (touche.Key == ConsoleKey.F && inventaire.nbBoulesFeu > 0)
            {
                Console.Write("Entrez les coordonnées de x :");
                var input = Console.ReadLine();
                int x = int.Parse(input);

                Console.Write("Entrez les coordonnées de y :");
                input = Console.ReadLine();
                int y = int.Parse(input);
                if (grille.cases[x, y].terrain is Ocean)
                {
                    Console.WriteLine("L'océan est dégelé !");
                    inventaire.nbBoulesFeu--;
                }
            }
            else if (touche.Key == ConsoleKey.G && inventaire.nbBoulesGlace > 0)
            {
                Console.Write("Entrez les coordonnées de x :");
                var input = Console.ReadLine();
                int x = int.Parse(input);
                Console.Write("Entrez les coordonnées de y :");
                input = Console.ReadLine();
                int y = int.Parse(input);
                if (grille.cases[x, y].terrain is Volcan)
                {
                    Console.WriteLine("Le volcan est refroidi !");
                    inventaire.nbBoulesGlace--;
                }
            }
            calendrier.AvancerSemaine();
        }
        Console.WriteLine("Partie terminée !");
    }

    public void LancerModeUrgence()
    {
        Console.Clear();
        Console.WriteLine("ATTENTION ! Un kart s'apprête à rouler sur votre jardin !");

        Kart kart = new Kart();
        kart.Rouler(grille.lignes);

        grille.Afficher();
        Console.WriteLine(
            "Appuyez sur E pour utiliser un éclair et stopper le kart tant qu'il en est encore temps !"
        );

        ConsoleKeyInfo touche = Console.ReadKey(true);
        if (touche.Key == ConsoleKey.E && inventaire.nbEclairs > 0)
        {
            kart.FoudroyerKart();
            inventaire.nbEclairs--;
        }
        kart.DetruireLigne(grille);

        // Retour au mode classique
        modeActuel = ModeJeu.Classique;
        Console.WriteLine("Le kart est parti, vous pouvez reprendre soin de votre jardin.");
        Console.ReadKey(true);
        GenererMaladiesUrgence();
    }

    public Maladie GenererMaladie()
    {
        // Choisir un prototype parmi ceux disponibles
        Maladie prototype = maladiesDisponibles[rng.Next(maladiesDisponibles.Count)];

        // Créer une copie de la maladie avec des coordonnées aléatoires
        int x = rng.Next(grille.lignes);
        int y = rng.Next(grille.colonnes);

        // Créer directement l'instance de la maladie en fonction du type
        Maladie nouvelleMaladie;

        if (prototype is Toxinelles)
        {
            nouvelleMaladie = new Toxinelles(x, y);
        }
        /* else if (prototype is MaladieAutreType) // Exemple d'un autre type de maladie
        {
            nouvelleMaladie = new MaladieAutreType(x, y);
        } */
        //TODO avec les autres maladies
        else
        {
            throw new InvalidOperationException("Type de maladie non supporté.");
        }

        return nouvelleMaladie;
    }

    public void GenererMaladiesSemaine()
    {
        Maladie maladie = GenererMaladie();
        Console.WriteLine(
            $"Une maladie {maladie.GetType().Name} attaque à ({maladie.x}, {maladie.y})"
        );
        AffecterMaladie(maladie);
    }

    public void GenererMaladiesUrgence()
    {
        for (int i = 0; i < 4; i++)
        {
            Maladie maladie = GenererMaladie();
            Console.WriteLine(
                $"[⚠️ URGENCE] {maladie.GetType().Name} apparaît à ({maladie.x}, {maladie.y}) !"
            );
            AffecterMaladie(maladie);
        }
    }

    public void AffecterMaladie(Maladie maladie)
    {
        // Parcours de la grille avec deux boucles pour chaque dimension
        for (int i = 0; i < grille.lignes; i++)
        {
            for (int j = 0; j < grille.colonnes; j++)
            {
                Case c = grille.cases[i, j]; // Accède à chaque case

                if (c.plante != null) // Si la case contient une plante
                {
                    Plante plante = c.plante;

                    // Vérifie la proximité (dans un rayon de 1 autour de la maladie)
                    if (Math.Abs(plante.x - maladie.x) <= 1 && Math.Abs(plante.y - maladie.y) <= 1)
                    {
                        maladie.Infecter(plante); // Infecter la plante
                        Console.WriteLine(
                            $"{plante.nom} est infectée par {maladie.GetType().Name} !"
                        );
                    }
                }
            }
        }
    }
}
