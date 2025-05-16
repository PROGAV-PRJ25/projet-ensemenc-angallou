public class Simulation
{
    public List<Plante> plantes;
    public List<Maladie> maladies;
    public Calendrier calendrier;
    public Grille grille;
    public Inventaire inventaire;
    public Kart kart;
    public Simulation()
    {
        grille = new Grille();
        calendrier = new Calendrier();
        maladies = new List<Maladie>();
        kart = new Kart();

        // J'ai mis des plantes dès le départ pour tester mais l'idéal serait de les planter soi-même
        grille.PlacerPlante(2, 2, new FleurDeFeu(inventaire));
        grille.PlacerPlante(4, 4, new ArbreACheddar(inventaire));
        grille.PlacerPlante(1, 1, new PlanteCarnivore(inventaire));
        grille.PlacerPlante(5, 3, new FleurDeGlace(inventaire));
    }
    public void LancerJeu()
    {
        while (true)
        {
            Saison saison = calendrier.saisonCourante;
            saison.CalculerMeteo();

            double eau = saison.pluieActuelle;
            double lumiere = saison.soleilActuel;
            int temperature = saison.temperatureActuelle;

            Console.Clear();
            Console.WriteLine($"\n Semaine n°{calendrier.semaine}");
            Console.WriteLine(saison);

            // Possible passage du kart
            if (calendrier.semaine % 5 == 0)
            {
                kart.Rouler(grille.lignes);
            }
            // Réactions en fonction des saisons
                foreach (var c in grille.Cases())
                {
                    c.terrain?.ReagirASaison(saison);
                }

            grille.Afficher();
            Console.WriteLine("\n Légende des emojis :");
            Console.WriteLine("🔥Fleur de feu ❄️Fleur de glace 🧀Arbre à cheddar 🪴Plante Carnivore");
            Console.WriteLine("☠️Plante morte 🤢Plante malade");
            Console.WriteLine("🟨Fromage 🟥Volcan 🟦Océan 🌈Arc-en-ciel");

            Console.WriteLine($"\nInventaire : Boules de feu = {inventaire.nbBoulesFeu} - Boules de glace = {inventaire.nbBoulesGlace} - Eclairs = {inventaire.nbEclairs} - Cheddars = {inventaire.cheddar}");

            foreach (Plante plante in plantes)
            {
                foreach (Maladie maladie in maladies)
                {
                    if (
                        plante.x == maladie.x
                        && plante.y == maladie.y
                        && maladie.EstPlanteCible(plante)
                    )
                    {
                        plante.maladie = maladie; // elle est maintenant infectée
                        maladie.Infecter(plante); //TO DO
                        Console.WriteLine(
                            $"{plante.nom} est infectée par {maladie.GetType().Name} !"
                        );
                        // infection possible
                        // enlever de la vie aussi
                    }
                    if (plante.etat)
                    {
                        bool bonEspacement = (plante.espacement <= plante.place);
                        plante.Croissance(
                            plante.terrainPref,
                            bonEspacement,
                            eau,
                            lumiere,
                            temperature
                        );
                        Console.WriteLine(
                            $"Plante {plante.nom} - Taille : {plante.place} - Etat : Vivante"
                        );
                    }
                    else
                        Console.WriteLine($"Plante {plante.nom} - Etat : Décédée");
                }
            }

            //Interaction joueur
            Console.WriteLine("\n Action ? (F=Feu, G=Glace, E=Eclair, Q=Quitter, Entrée=Continuer)");
            var touche = Console.ReadKey(true);
            if (touche.Key == ConsoleKey.Q) break;
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
            else if (touche.Key == ConsoleKey.E && inventaire.nbEclairs > 0)
            {
                if (kart.actif)
                {
                    kart.FoudroyerKart();
                    inventaire.nbEclairs--;
                }
                else
                {
                    Console.WriteLine("Il n'y a pas de kart à foudroyer !");
                }
            }
            kart.DetruireLigne(grille);
            calendrier.AvancerSemaine();
        }
        Console.WriteLine("Partie terminée !");
    }
}
