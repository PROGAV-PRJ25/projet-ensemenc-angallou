public abstract class Plante
{
    protected Random rng = new Random();
    public string nom { get; set; }
    public int x { get; set; }
    public int y { get; set; }
    public bool etat { get; set; }
    public bool miam { get; set; }
    public Saison saison { get; set; }
    public Terrain? terrainPref { get; set; }
    public int espacement { get; set; }
    public int place { get; set; }
    public int vitesse { get; set; }
    public double besoinEau { get; set; }
    public double besoinLumiere { get; set; }
    public int tempMin { get; set; }
    public int tempMax { get; set; }
<<<<<<< HEAD
    public Maladie? maladie { get; set; }
    public int esperanceVie { get; set; }
    public int nbFruits { get; set; }
    public string? emoji { get; set; }
    public bool boostSatisfaction { get; set; }
    public int semaineDepuisSemis { get; set; }  
    public Plante(string Nom, int X, int Y, bool Etat, bool Miam, Saison SaisonM, Terrain TerrainPref, int Espacement, int Place, int Vitesse, double BesoinEau, double BesoinLumiere, int TempMin, int TempMax, int EsperanceVie, int NbFruits)
=======
    public Maladie maladie;
    public int esperanceVie { get; set; }
    public int nbFruits { get; set; }
    public string emoji;

    public Plante(
        string Nom,
        int X,
        int Y,
        bool Etat,
        bool Miam,
        Saison SaisonM,
        Terrain TerrainPref,
        int Espacement,
        int Place,
        int Vitesse,
        double BesoinEau,
        double BesoinLumiere,
        int TempMin,
        int TempMax,
        //Maladie Maladie,
        int EsperanceVie,
        int NbFruits
    )
>>>>>>> refs/remotes/origin/main
    {
        nom = Nom;
        x = X;
        y = Y;
<<<<<<< HEAD
        etat = Etat; // Indique si la plante est vivante ou non --> false si satisfaction < 0.5
        miam = Miam; // Indique si la plante est comestible ou non
        saison = SaisonM; // Correspond à la saison de semis
        terrainPref = TerrainPref; // Correspond au terrain préféré de la plante
        espacement = Espacement; // Correspond à l'espacement minimal idéal entre cette plante et une autre
        place = Place; // Correspond à la place maximale prise par la plante sur la grille
        vitesse = Vitesse; // De manière un peu contre-intuitive, la vitesse ici correspond au nombre de semaines nécessaires pour qu'une plante devienne mature, donc plus elle est faible mieux c'est
        besoinEau = BesoinEau; // Taux d'eau nécessaire à la plante pour s'épanouir
        besoinLumiere = BesoinLumiere; // Taux de lumière nécessaire à la plante pour s'épanouir
        tempMin = TempMin; // Température minimale acceptable pour la plante
        tempMax = TempMax; // Température maximale acceptable pour la plante
        esperanceVie = EsperanceVie; // Nombre de semaines maximal d'existence de la plante
        nbFruits = NbFruits; // Nombre de fruits cueillables chaque semaine quand la plante est mature
        boostSatisfaction = false; // Pas de boost de satisfaction par défaut
        semaineDepuisSemis = 0; // Correspond à l'âge de la plante (en semaines)
=======
        etat = Etat; //false si satisfaction < 0.5
        miam = Miam;
        saison = SaisonM;
        terrainPref = TerrainPref; // si le terrain est le préféré, alors la satisfaction augmente
        espacement = Espacement; // si espacement respecté, alors la satisfaction augmente
        place = Place; // si il y a de la place, alors elle va croitre
        vitesse = Vitesse;
        besoinEau = BesoinEau; //si respecté, augmente
        besoinLumiere = BesoinLumiere; // si respecté, augmente
        tempMin = TempMin; // si moins diminue
        tempMax = TempMax; // si plus diminue
        //maladie = Maladie; //maladie à laquelle la plante est la plus sensible
        esperanceVie = EsperanceVie;
        nbFruits = NbFruits;
>>>>>>> refs/remotes/origin/main
    }

    public double Satisfaction(Terrain TerrainActuel, bool Espacement, double Eau, double Lumiere, int Temp) // Renvoie le taux de satisfaction de la plante (varie de 0 à 1)
    {
        if (boostSatisfaction) // Si un boost de satisfaction a été obtenu (en utilisant une étoile sur une plante)
        {
            boostSatisfaction = false; // Celui-ci disparait
            return 1.0; // Mais la satisfaction de la plante est au maximum
        }

        double tauxSatisfaction = 0;
        if (TerrainActuel == terrainPref) // Si le terrain sur lequel la plante pousse est son terrain préféré (+20% de satisfaction)
            tauxSatisfaction += 0.2; 
        if (Espacement) // Espacement est ici un booléen qui prend la valeur true, si espacement <= place, donc si la plante possède suffisament de place pour pousser (+20% de satisfaction)
            tauxSatisfaction += 0.2;
        if (Eau >= besoinEau) // Si le taux d'eau actuel auquel la plante a accès est supérieur ou égal au taux dont elle a besoin (+20% de satisfaction)
            tauxSatisfaction += 0.2;
        if (Lumiere >= besoinLumiere) // Si le taux de lumiere actuel auquel la plante a accès est supérieur ou égal au taux dont elle a besoin (+20% de satisfaction)
            tauxSatisfaction += 0.2;
        if (Temp >= tempMin && Temp <= tempMax) // Si la température actuelle se situe entre les températures minimale et maximale acceptables pour la plante (+20% de satisfaction)
            tauxSatisfaction += 0.2;
        if (maladie != null) // // Si la plante est malade (-30% de satisfaction)
            tauxSatisfaction -= maladie.gravite;
        return Math.Clamp(tauxSatisfaction, 0.0, 1.0); //Math.Clamp(...) permet de forcer tauxSatisfaction à rester entre 0 et 1.
    }

    public virtual void Croissance(Terrain TerrainActuel, bool Espacement, double Eau, double Lumiere, int Temp) // Méthode permettant d'ajuster la vitesse de croissance de la plante soit le nombre de semaines qui lui faut pour devenir mature
    {
        double satisfaction = Satisfaction(TerrainActuel, Espacement, Eau, Lumiere, Temp); // On récupère le taux de satisfaction de la plante

        if (semaineDepuisSemis > esperanceVie) // Si l'âge de la plante dépasse son espérance de vie
        {
            etat = false; // La plante meurt
            Console.WriteLine($"La plante {nom} est morte de vieillesse.");
        }

        if (etat) // Si la plante est vivante
        {
            if (satisfaction < 0.5) // Si son taux de satisfaction est inférieur à 50%
            {
                etat = false; // La plante meurt
                Console.WriteLine($"La plante {nom} est morte par manque de conditions satisfaisantes.");
            }
            else if (satisfaction < 0.7) // Si son taux de satisfaction se situe entre 50% et 70%
            {
                vitesse *= 2; // Sa croissance est réduite, le nombre de semaines nécessaire pour devenir mature double
                Console.WriteLine($"La plante {nom} pousse lentement.");

                if (maladie == null && rng.NextDouble() < 0.2) // De plus dans ces conditions détériorés, la plante présente un risque d'attraper une maladie de 20% si elle n'est pas déjà infectée par une autre
                {
                    maladie = InstancierMaladieAssociee(); // On récupère la maladie associée à la plante
                    maladie?.Infecter(this); // La plante est infectée par la maladie
                }
            }
            else if (satisfaction >= 0.7 && satisfaction < 0.9) // Si son taux de satisfaction se situe entre 70% et 90%, sa croissance est normale donc la vitesse ne bouge pas
            { 
                Console.WriteLine($"La plante {nom} pousse normalement."); 
            }
            else // Si son taux de satisfaction est supérieur à 90%
            {
                vitesse /= 2; // Sa croissance est augmentée, le nombre de semaines nécessaire pour devenir mature est réduit de moitié
                Console.WriteLine($"La plante {nom} pousse rapidement.");
            }
            semaineDepuisSemis++; // L'âge de la plante augmente d'une semaine
        }
        else // Si la plante est morte
        {
            Console.WriteLine("Cette plante est morte, il serait sage de la déraciner");
        }
    }

    public void Diagnostic(double Eau, double Lumiere, int Temp) // Méthode permettant d'afficher des informations précises sur le statut de la plante
    {
        Console.WriteLine();
        if (etat) // Si la plante est vivante
        {
            Console.WriteLine($"*** {nom} est âgé(e) de {semaineDepuisSemis} semaines (esperance de vie = {esperanceVie}) ***"); 
            Console.WriteLine($"- Besoin en eau: {besoinEau} - Taux actuel : {Eau}");
            if (besoinEau > Eau) // Si le taux d'eau actuel auquel la plante a accès est inférieur au taux dont elle a besoin 
                Console.WriteLine("Votre plante est déshydratée !");
            else
                Console.WriteLine("Le taux d'hydratation de votre plante est bon.");

            Console.WriteLine($"- Besoin en lumiere: {besoinLumiere} - Taux actuel : {Lumiere}");
            if (besoinLumiere > Lumiere) // Si le taux de lumière actuel auquel la plante a accès est inférieur au taux dont elle a besoin 
                Console.WriteLine("Votre plante manque de lumière !");
            else
                Console.WriteLine("Le taux de luminosité de votre plante est bon.");

            Console.WriteLine($"- Température idéale : {tempMin} à {tempMax} - Température actuelle : {Temp}");
            if (Temp < tempMin || Temp > tempMax) // Si la température actuelle dépasse les bornes de l'intervalle des températures acceptables pour la plante
                Console.WriteLine("La température est inadaptée pour votre plante !");
            else
                Console.WriteLine("La température est adaptée pour votre plante.");

            if (maladie != null) // Si la plante est malade
                Console.WriteLine($"Votre plante est malade ! Maladie : {maladie}");
        }
        else // Si la plante est morte
        {
           Console.WriteLine($"Votre plante est morte !"); 
        }
    }

    public void Afficher() // Méthode permettant d'afficher des informations génériques sur la plante 
    {
        Console.WriteLine(
            $"{nom} - Taille : {place} - Fruits : {nbFruits} - Espacement : {espacement} - Place : {place}"
        );
        Console.WriteLine(
            $"Besoins en eau : {besoinEau} - Besoins en lumière : {besoinLumiere} - Température minimale : {tempMin} - Température max : {tempMax}"
        );
        Console.WriteLine(
            $"Saison préférée : {saison.nom} - Terrain préféré : {terrainPref.nom} - Espérance de vie : {esperanceVie}"
        );
    }

    public virtual void RecupererObjet() { } // Toutes les plantes n'auront pas forcément de pouvoir spécial

    public virtual string RecupererEmoji() // Récupère le symbole à afficher pour la plante
    {
        if (!etat) // Si la plante est morte
            return " X "; // On renvoie un X, symbole commun pour toutes les plantes mortes
        return emoji; // Sinon, on renvoie le symbole associé à la plante
    }

    public virtual Maladie? InstancierMaladieAssociee() // Renvoie la maladie associée à une plante en particulier
    {
        if (nom == "Fleur de feu") // La glaglaose infecte les fleurs de feu
            return new Glaglaose(x, y);
        if (nom == "Fleur de glace") // La quécalorose infecte les fleurs de glace
            return new QueCalorose(x, y);
        if (nom == "Arbre à cheddar") // Les toxinelles infectent les arbres à cheddar
            return new Toxinelles(x, y);
        return null; // Aucune maladie n'infecte les plantes carnivores
    }

    public bool EstMature() // Renvoie un booléen indiquant si une plante est mature ou non
    {
        return (semaineDepuisSemis >= vitesse) ? true : false; // Si l'âge de la plante est supérieur ou égal au nombre de semaines nécessaires pour arriver à maturité (= vitesse) on renvoie true, sinon false
    }

    public ConsoleColor GetCouleurAffichage() // Renvoie une couleur d'affichage du texte de la console en fonction du statut de la plante
    {
        if (!etat) // Si la plante est morte
            return ConsoleColor.DarkRed; // Elle sera affichée en rouge sombre
        if (maladie != null) // Si la plante est malade
            return ConsoleColor.DarkGray; // Elle sera affichée en gris sombre
        if (!EstMature()) // Si la plante est immature
            return ConsoleColor.White; // Elle sera affichée en blanc
        return ConsoleColor.Green; // Si la plante est mature, elle sera affichée en vert
    }
}
