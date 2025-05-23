public class Simulation
{
    private List<Maladie> maladiesDisponibles;
    private Random rng = new Random();
    public List<Maladie> maladies;
    public Calendrier? calendrier;
    public Grille grille;
    public Inventaire inventaire;
    public enum ModeJeu { Classique, Urgence } // Deux modes de jeu sont proposés
    public ModeJeu modeActuel; 
    private bool fin; 
    public double eau;
    public double lumiere;
    public int temperature;

    public Simulation()
    {
        grille = new Grille(); // Création de la grille de jeu
        maladies = new List<Maladie>();  // Liste des maladies qui seront présentes sur la grille
        modeActuel = ModeJeu.Classique; // Le jeu débute en mode Classique
        inventaire = new Inventaire(); // Création de l'inventaire
        fin = false; // Par défaut, le jeu n'est pas fini avant d'avoir commencé
        maladiesDisponibles = new List<Maladie>() // Liste des types de maladies non actifs sur la grille
        {
            new Toxinelles(0, 0), 
            new Glaglaose(0, 0),
            new QueCalorose(0, 0),
        };
    }

    public void LancerJeu() // Méthode principale 
    {
        Console.Clear();
        Console.WriteLine("*** BIENVENUE DANS NOTRE JEU ENSEMENC VS MARIO ! ***");
        Console.WriteLine("Aidez Toad à faire pousser le plus de plantes possible, mais attention Mario rôde en kart pas loin !");
        Console.WriteLine("Veuillez tout d'abord choisir une saison à laquelle commencer votre partie :");
        Console.WriteLine("1 : Hiver ----- 2 : Printemps ----- 3 : Ete ----- 4 : Automne");

        if (!int.TryParse(Console.ReadLine(), out int numero)) // Afin d'éviter les erreurs en console si autre saisie
        {
            Console.WriteLine("Entrée invalide. Veuillez entrer un nombre entre 1 et 4.");
        }

        // On instancie avec un entier correspondant à une des premières semaines de la saison, tout en évitant que ce soit une semaine où le mode Urgence se déclenche 
        if (numero == 1) calendrier = new Calendrier(1); 
        else if (numero == 2) calendrier = new Calendrier(16);
        else if (numero == 3) calendrier = new Calendrier(27);
        else calendrier = new Calendrier(41);

        while (!fin) // Tant que la condition de fin n'est pas atteinte, le jeu continue 
        {
            // Le jeu passe en mode Urgence toutes les 5 semaines
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
        return; // On quitte le jeu
    }

    public void LancerTourClassique() // Méthode simulant un tour basique en mode Classique
    {
        Console.Clear();
        Saison saison = calendrier.saisonCourante; // On récupère la saison actuelle
        saison.CalculerMeteo(); // On calcule les données météo actuelles

        eau = saison.pluieActuelle; // Le taux d'eau accessible aux plantes correspond à celui de la pluie
        lumiere = saison.soleilActuel; // Le taux de lumiere accessible aux plantes correspond à celui du soleil
        temperature = saison.temperatureActuelle;

        Console.WriteLine($"*** Semaine n°{calendrier.semaine} ***");
        Console.WriteLine(saison); // Affiche la saison et les données météo 
        saison.DecrireMeteo(); 
        System.Threading.Thread.Sleep(2500);

        /*
        // Réactions en fonction des saisons (à développer)
        foreach (var c in grille.cases)
        {
            c.terrain?.ReagirASaison(saison);
        }
        */

        List<Plante> plantes = new List<Plante>(); // Liste des plantes qui seront stockées dans la grille 
        foreach (Case c in grille.cases) // On parcourt les cases de la grille 
        {
            if (c.plante != null) // Si la case contient une plante
            {
                plantes.Add(c.plante); // On l'ajoute à la liste des plantes
            }
        }

        foreach (Plante plante in plantes) // // On parcourt les plantes 
        {
            Console.WriteLine();
            foreach (Maladie maladie in maladies) // On parcourt les maladies 
            {
                if (plante.x == maladie.x && plante.y == maladie.y && maladie.EstPlanteCible(plante)) // Si une plante et une maladie se situe sur la même case et que la plante est la cible privilégiée de la maladie
                {
                    maladie.Infecter(plante); // Elle est maintenant infectée
                    Console.WriteLine($"{plante.nom} est infectée par {maladie.GetType().Name} !");
                }
            }
            if (plante.maladie is Toxinelles toxinelles) // Si ce sont des Toxinelles
            {
                toxinelles.Agoniser(plante); // La plante commence à agoniser
            }
            if (plante.etat) // Si la plante est vivante
            {
                bool bonEspacement = (plante.espacement <= plante.place); // Renvoie un booléen indiquant si la plante a assez de place pour croitre
                plante.Croissance(plante.terrainPref, bonEspacement, eau, lumiere, temperature); // La plante évolue
                plante.Diagnostic(eau, lumiere, temperature); // On affiche des infos sur le statut de la plante
            }
            else //  Si la plante est morte
            {
                Console.WriteLine($"Plante {plante.nom} - Etat : Décédée");
            }
        }
        System.Threading.Thread.Sleep(1500);
        grille.Afficher(); // On affiche la grille
        AfficherMenuActions(); // On affiche le menu d'actions
        if (fin) return; // Si la condition de fin est atteinte, on quitte le jeu
        calendrier.AvancerSemaine(); // On passe au tour suivant
    }

    public void LancerModeUrgence() // // Méthode simulant un tour basique en mode Urgence
    {
        Console.Clear();
        Console.WriteLine("ATTENTION ! Un kart s'apprête à rouler sur votre jardin !");

        Kart kart = new Kart(); 
        kart.Rouler(grille.lignes); // On indique sur quelle ligne le kart risque de rouler

        grille.Afficher();

        Console.WriteLine("Appuyez sur E pour utiliser un éclair et stopper le kart tant qu'il en est encore temps !");
        Console.WriteLine("Sinon, appuyez sur n'importe quelle autre touche... au péril de votre jardin...");
        ConsoleKeyInfo touche = Console.ReadKey(true); // On récupère la touche sur laquelle le joueur appuie

        System.Threading.Thread.Sleep(2500);
        bool kartFoudroye = false; // Le kart n'a pas encore été foudroyé

        if (touche.Key == ConsoleKey.E) // Si le joueur a appuyé sur la touche E
        {
            if (inventaire.nbEclairs > 0) // S'il y a des éclairs dans son inventaire
            {
                kart.FoudroyerKart(); // Le kart est foudroyé
                inventaire.nbEclairs--; // Un éclair en moins dans l'inventaire
                kartFoudroye = true; // Le kart a été foudroyé
                Console.WriteLine("Le kart a été foudroyé !");
            }
            else
            {
                Console.WriteLine("Vous n'avez pas d'éclair !");
            }
        }

        // Si le kart n'a pas été foudroyé, il détruit la ligne
        if (!kartFoudroye)
        {
            kart.DetruireLigne(grille);
        }
        Console.WriteLine("Le kart est parti... Mais un autre problème vient d'apparaître !");

        GenererMaladiesUrgence(); // Des maladies apparaissent à des endroits aléatoires de la grille

        Console.WriteLine("*** Semaine suivante... Appuyez sur une touche pour continuer. ***");
        Console.ReadKey(true);

        // Retour au mode classique
        modeActuel = ModeJeu.Classique; 
        calendrier.AvancerSemaine();
        
        System.Threading.Thread.Sleep(3500);
    }

    public void AfficherMenuActions() // Méthode permettant l'interaction du joueur avec le jeu
    {
        while (!fin) // Tant que le joueur ne décide pas de passer à la semaine suivante, il peut continuer à faire des actions
        {
            System.Threading.Thread.Sleep(3500);
            Console.Clear();
            grille.Afficher();

            // Informations utiles pour le joueur
            Console.WriteLine("\n Légende :");
            Console.WriteLine("F = Fleur de feu  G = Fleur de glace  C = Arbre à cheddar  P = Plante Carnivore  X = Plante morte");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Une plante mature est affichée en vert");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Une plante non mature est affichée en blanc");
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.WriteLine("Une plante malade est affichée en gris sombre");
            Console.ResetColor();
            Console.WriteLine("Couleurs des terrains : 🟨 Fromage 🟥 Volcan 🟦 Océan 🟪 Arc-en-ciel");

            Console.WriteLine($"\nInventaire : 🔥 Boules de feu = {inventaire.nbBoulesFeu} ❄️  Boules de glace = {inventaire.nbBoulesGlace} ⚡ Eclairs = {inventaire.nbEclairs} 🧀 Cheddars = {inventaire.nbCheddar} 🌟 Etoiles = {inventaire.nbEtoiles} 🧪 Sérums = {inventaire.nbSerums}");

            Console.WriteLine("\n Menu d'actions :");
            Console.WriteLine("1 - Arroser une plante");
            Console.WriteLine("2 - Cueillir les fruits");
            Console.WriteLine("3 - Semer une graine");
            Console.WriteLine("4 - Utiliser un objet de l'inventaire");
            Console.WriteLine("5 - Déraciner plante");
            Console.WriteLine("6 - En savoir plus sur les types de plantes");
            Console.WriteLine("7 - Avoir des infos sur l'état d'une plante de ma grille");
            Console.WriteLine("8 - Passer à la semaine suivante");
            Console.WriteLine("9 - Quitter le jeu");

            if (!int.TryParse(Console.ReadLine(), out int numero)) // Afin d'éviter les erreurs en console si autre saisie
            {
                Console.WriteLine("Entrée invalide. Veuillez entrer un nombre entre 1 et 9.");
            }

            if (numero == 1) ArroserPlante();
            else if (numero == 2) CueillirFruits();
            else if (numero == 3) SemerGraine();
            else if (numero == 4) UtiliserObjet();
            else if (numero == 5) DeracinerPlante();
            else if (numero == 6) EtudierPlante();
            else if (numero == 7) DiagnosticPlante();
            else if (numero == 8)
            {
                Console.WriteLine("*** Semaine suivante... Appuyez sur une touche pour continuer. ***");
                Console.ReadKey(true);
                return;
            }
            else if (numero == 9)
            {
                fin = true; // Le joueur a décidé de quitter le jeu
                Console.WriteLine("Partie terminée !");
            }
            else
            {
                Console.WriteLine("Choix invalide");
            }
        }
        return;
    }

    public void ArroserPlante() // Méthode permettant de réduire les exigences en eau de la plante
    {
        Console.WriteLine("Quelle plante souhaitez-vous arroser ?");
        var c = RecupererCase();

        if (c.plante != null && c.plante.etat) // Si la case contient une plante qui est vivante
        {
            c.plante.besoinEau -= 0.1; // Son taux de besoin en eau est réduit de 10%
            if (c.plante.besoinEau < 0.1) c.plante.besoinEau = 0.1; // Valeur minimale raisonnable
            Console.WriteLine($"{c.plante.nom} a été arrosée !");
        }
        else
        {
            Console.WriteLine("Il n'y a pas de plante vivante à cet emplacement.");
        }
    }

    public void CueillirFruits() // Méthode permettant de récolter des objets utiles en jeu
    {
        Console.WriteLine("De quelle plante souhaitez-vous cueillir les fruits ?");
        var c = RecupererCase();

        if (c.plante != null && c.plante.etat && c.plante.nbFruits > 0 && c.plante.EstMature()) // Si la case contient une plante qui est vivante, qui possède des fruits et qui est à maturité
        {
            Console.WriteLine($"Vous avez récolté {c.plante.nbFruits} fruit(s) de la plante {c.plante.nom} !");
            c.plante.RecupererObjet(); // La plante offre un ou plusieurs objets au joueur
        }
        else if (c.plante != null && c.plante.etat && !c.plante.EstMature()) // Si la case contient une plante qui est vivante mais immature
        {
            Console.WriteLine($"Votre plante {c.plante.nom} n'est pas encore mature !");
        }
        else
        {
            Console.WriteLine("Il n'y a pas de fruit à cueillir ici.");
        }
    }

    public void SemerGraine() // Méthode permettant de planter de nouvelles plantes sur la grille
    {
        Console.WriteLine("Sur quel emplacement souhaitez-vous semer une graine ?");
        var c = RecupererCase();

        if (c.plante != null) // Si la case contient déjà une plante
        {
            Console.WriteLine("Cet emplacement est déjà occupé !");
            return;
        }

        // On récupère les coordonnées de la case
        int x = c.x;
        int y = c.y;

        Console.WriteLine("Choisissez une graine à planter :");
        Console.WriteLine("1 - Fleur de feu");
        Console.WriteLine("2 - Fleur de glace");
        Console.WriteLine("3 - Arbre à cheddar");
        Console.WriteLine("4 - Plante carnivore");

        if (!int.TryParse(Console.ReadLine(), out int numero)) // Afin d'éviter les erreurs en console si autre saisie
        {
            Console.WriteLine("Entrée invalide. Veuillez entrer un nombre entre 1 et 9.");
        }

        // On place la plante choisie par le joueur sur la case dont on vient de récupérer les coordonnées 
        if (numero == 1) grille.PlacerPlante(x, y, new FleurDeFeu(inventaire));
        else if (numero == 2) grille.PlacerPlante(x, y, new FleurDeGlace(inventaire));
        else if (numero == 3) grille.PlacerPlante(x, y, new ArbreACheddar(inventaire));
        else if (numero == 4) grille.PlacerPlante(x, y, new PlanteCarnivore());
        else Console.WriteLine("Choix invalide");
    }

    public void UtiliserObjet() // Méthode permettant d'utiliser les objets de l'inventaire
    {
        Console.WriteLine("Quel objet voulez-vous utiliser ? (1=Etoile, 2=Boule de Feu, 3=Boule de Glace, 4=Serum, 5=Cheddar)");

        if (!int.TryParse(Console.ReadLine(), out int numero)) // Afin d'éviter les erreurs en console si autre saisie
        {
            Console.WriteLine("Entrée invalide. Veuillez entrer un nombre entre 1 et 5.");
        }

        if (numero == 1) // Si le joueur a choisi de jouer un étoile
        {
            if (inventaire.nbEtoiles > 0) // S'il y a des étoiles dans son inventaire
            {
                Console.WriteLine("Quelle plante souhaitez-vous cibler ?");
                var c = RecupererCase();

                Console.WriteLine("Utilisation d'une étoile !");
                inventaire.nbEtoiles--; 
                c.plante.boostSatisfaction = true; // La plante reçoit un boost de satisfaction
            }
            else
            {
                Console.WriteLine("Vous n'avez pas d'étoile !");
            }
        }
        if (numero == 2) // Si le joueur a choisi de jouer une boule de feu
        {
            if (inventaire.nbBoulesFeu > 0) // S'il y a des boules de feu dans son inventaire
            {
                Console.WriteLine("Quelle plante souhaitez-vous cibler ?");
                var c = RecupererCase();

                Console.WriteLine("Utilisation d'une boule de feu !");
                inventaire.nbBoulesFeu--;
                // A DEVELOPPER : le but étant de vaincre la glaglaose et de dégeler le terrain Océan en hiver
            }
            else
            {
                Console.WriteLine("Vous n'avez pas de boule de feu !");
            }
        }
        if (numero == 3) // Si le joueur a choisi de jouer une boule de glace
        {
            if (inventaire.nbBoulesGlace > 0) // S'il y a des boules de glace dans son inventaire
            {
                Console.WriteLine("Quelle plante souhaitez-vous cibler ?");
                var c = RecupererCase();

                Console.WriteLine("Utilisation d'une boule de glace !");
                inventaire.nbBoulesGlace--;
                // A DEVELOPPER : le but étant de vaincre la quécalorose et de solidifier le terrain Fromage en été
            }
            else
            {
                Console.WriteLine("Vous n'avez pas de boule de glace !");
            }
        }
        if (numero == 4) // Si le joueur a choisi de jouer un sérum
        {
            if (inventaire.nbSerums > 0) // S'il y a des sérums dans son inventaire
            {
                Console.WriteLine("Quelle plante souhaitez-vous cibler ?");
                var c = RecupererCase();

                if (c.plante != null && c.plante.etat && c.plante.maladie != null) // Si la case contient une plante vivante atteinte de maladie
                {
                    c.plante.maladie = null; // La plante est guérie, la maladie a disparue
                    Console.WriteLine($"{c.plante.nom} a été soignée grâce au sérum !");
                }
                else if (c.plante != null && c.plante.etat) // Si la case contient une plante vivante mais non atteinte de maladie
                {
                    Console.WriteLine($"{c.plante.nom} n'est pas malade.");
                }
                else
                {
                    Console.WriteLine("Aucune plante vivante à cet emplacement pour utiliser un sérum.");
                }
                inventaire.nbSerums--;
            }
            else
            {
                Console.WriteLine("Vous n'avez pas de sérum !");
            }
        }
        if (numero == 5) // Si le joueur a choisi de jouer un cheddar
        {
            Console.WriteLine("Vous ne pouvez donner du cheddar qu'aux plantes carnivores.");

            if (inventaire.nbCheddar > 0) // S'il y a des cheddars dans son inventaire
            {
                Console.WriteLine("Quelle plante souhaitez-vous cibler ?");
                var c = RecupererCase();

                if (c.plante.nom == "Plante Carnivore") // Si la case contient une plante carnivore
                {
                    Console.WriteLine("La plante carnivore se régale de cheddar !");
                    inventaire.nbCheddar--;
                }
                else
                {
                    Console.WriteLine("Vous ne pouvez donner du cheddar qu'aux plantes carnivores !");
                }

            }
            else
            {
                Console.WriteLine("Vous n'avez pas de cheddar !");
            }
        }
    }

    public void DeracinerPlante() // Méthode permettant de retirer une plante morte ou non d'une case de la grille (permettant d'en planter une nouvelle à cet emplacement)
    {
        Console.WriteLine("Quelle plante souhaitez-vous déraciner ?");
        var c = RecupererCase();

        if (c.plante != null) // S'il y a une plante sur cette case
        {
            Console.WriteLine($"La plante {c.plante.nom} a été déracinée.");
            c.plante = null; // Il n'y a plus de plante sur cette case
        }
        else
        {
            Console.WriteLine("Il n'y a pas de plante à cet emplacement.");
        }
    }

    public void DiagnosticPlante() // Méthode permettant d'afficher des infos importantes sur le statut de la plante
    {
        Console.WriteLine("Quelle plante souhaitez-vous diagnostiquer ?");
        var c = RecupererCase();

        if (c.plante == null) // S'il n'y a pas de plante sur cette case
        {
            Console.WriteLine("Aucune plante à cet endroit.");
            return;
        }
        c.plante.Diagnostic(eau, lumiere, temperature); // Affiche le diagnostic
        Console.WriteLine("\nAppuyez sur Entrée pour continuer");
        Console.ReadKey(true);
    }

    public void EtudierPlante() // Méthode permettant d'afficher des informations sur tous les types de plante du jeu
    {
        Console.WriteLine("\nVoici des informations d'utilité sur les différents types de plantes.");
        Console.WriteLine();
        FleurDeFeu p1 = new FleurDeFeu(inventaire); p1.Afficher(); // Affiche des infos sur les fleurs de feu
        Console.WriteLine();
        FleurDeGlace p2 = new FleurDeGlace(inventaire); p2.Afficher(); // Affiche des infos sur les fleurs de glace
        Console.WriteLine();
        ArbreACheddar p3 = new ArbreACheddar(inventaire); p3.Afficher(); // Affiche des infos sur les arbres à cheddar
        Console.WriteLine();
        PlanteCarnivore p4 = new PlanteCarnivore(); p4.Afficher(); // Affiche des infos sur les plantes carnivores
        Console.WriteLine("\nAppuyez sur Entrée pour continuer");
        Console.ReadKey(true);
    }

    public Maladie GenererMaladie() // Méthode permettant de genérer une maladie aléatoirement (utile dans le mode urgence)
    {
        if (maladiesDisponibles == null || maladiesDisponibles.Count == 0) // S'il n'y a pas de maladies dans la liste ou que cette liste n'existe pas
        {
            throw new InvalidOperationException("Aucune maladie disponible."); 
        }

        // On récupère un type de maladie au hasard parmi ceux de la liste
        Maladie prototype = maladiesDisponibles[rng.Next(maladiesDisponibles.Count)]; 

        // On récupère des coordonnées aléatoires de la grille 
        int x = rng.Next(grille.lignes);
        int y = rng.Next(grille.colonnes);

        // Créer directement l'instance de la maladie en fonction du type
        Maladie nouvelleMaladie;

        if (prototype is Toxinelles)
        {
            nouvelleMaladie = new Toxinelles(x, y);
        }
        else if (prototype is Glaglaose)
        {
            nouvelleMaladie = new Glaglaose(x, y);
        }
        else if (prototype is QueCalorose)
        {
            nouvelleMaladie = new QueCalorose(x, y);
        }
        else
        {
            throw new InvalidOperationException("Ce type de maladie est inconnu.");
        }
        return nouvelleMaladie;
    }

    /*
    public void GenererMaladiesSemaine()
    {
        Maladie maladie = GenererMaladie();
        Console.WriteLine($"Une maladie {maladie.GetType().Name} attaque à ({maladie.x}, {maladie.y})");
        AffecterMaladie(maladie);
    }
    */

    public void GenererMaladiesUrgence() // Méthode permettant de générer plusieurs maladies en mode Urgence
    {
        for (int i = 0; i < 4; i++)
        {
            Maladie maladie = GenererMaladie();
            Console.WriteLine(
                $"[⚠️  URGENCE] {maladie.GetType().Name} apparaît à ({maladie.x}, {maladie.y}) !"
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

    public Case? RecupererCase() // Méthode générique pour récupérer une case de la grille
    {
        Console.Write("Coordonnée x : ");
        string? X = Console.ReadLine();
        Console.Write("Coordonnée y : ");
        string? Y = Console.ReadLine();

        if (!int.TryParse(X, out int x) || !int.TryParse(Y, out int y)) // Afin d'éviter les erreurs en console si autre saisie
        {
            Console.WriteLine("Saisie invalide.");
            return null;
        }

        if (x < 0 || y < 0 || x >= grille.lignes || y >= grille.colonnes) 
        {
            Console.WriteLine("Coordonnées hors limites");
            return null;
        }

        return grille.cases[x, y];
    }
}
    



