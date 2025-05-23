public class Grille
{
    private Random rng = new Random();
    public int lignes;
    public int colonnes;
    public Case[,] cases; // Grille 2D contenant des cases (chaque case peut contenir un terrain et une plante)

    public Grille()
    {
        lignes = 6;  
        colonnes = 6;
        cases = new Case[lignes, colonnes]; // Grille 6x6

        // Création de chaque case de la grille
        for (int i = 0; i < lignes; i++)
        {
            for (int j = 0; j < colonnes; j++)
            {
                Terrain terrain;
                if (i < lignes / 2 && j < colonnes / 2) // Les 9 cases en haut à gauche de la grille ont un terrain Fromage
                    terrain = new Fromage();
                else if (i < lignes / 2 && j >= colonnes / 2) // Les 9 cases en haut à droite de la grille ont un terrain Océan
                    terrain = new Ocean();
                else if (i >= lignes / 2 && j < colonnes / 2) // Les 9 cases en bas à gauche de la grille ont un terrain Volcan
                    terrain = new Volcan();
                else // Les 9 cases en bas à droite de la grille ont un terrain Arc-en-ciel
                    terrain = new ArcEnCiel();

                cases[i, j] = new Case(i, j, terrain);
            }
        }
    }

    public void Afficher() // Affiche toute la grille
    {
        Console.WriteLine("\n    ***** VOTRE JARDIN *****");

        //En-tête des colonnes
        Console.Write("   ");
        for (int col = 0; col < colonnes; col++)
            Console.Write($"{col,4}"); // On affiche les numéro des colonnes avec un décalage de 4 afin qu'ils soient alignés avec
        Console.WriteLine();

        for (int i = 0; i < lignes; i++)
        {
            AfficherLigneSeparatrice(i); // Affiche les bordures horizontales des cases

            AfficherLigneContenu(i); // Affiche le contenu des cases
        }
        AfficherLigneSeparatrice(lignes-1); // Affiche la dernière bordure
    }

    private void AfficherLigneSeparatrice(int ligne) // Affiche les bordures horizontales des cases
    {
        Console.Write("    ");
        for (int i = 0; i < colonnes; i++)
        {
            Case c = cases[ligne, i]; // On récupère chaque case de la ligne entrée en paramètre
            Console.ForegroundColor = c.GetCouleurBordure(); // On change de couleur d'affichage en fonction de la case et de son terrain associé
            Console.Write("╬═══");
            Console.ResetColor(); // On revient à la couleur d'affichage par défaut (= blanc)
        }    
        Console.WriteLine("╬"); 
    }

    private void AfficherLigneContenu(int ligne) // Affiche le contenu des cases
    {
        Console.Write($"{ligne,2}  "); // On affiche les numéro des lignes avec un décalage de 2 afin qu'ils ne soient pas trop collés à la grille

        for (int colonne = 0; colonne < colonnes; colonne++)
        {
            Case c = cases[ligne, colonne]; // On récupère la case 

            if (c.plante != null) // Si la case possède une plante, on l'affiche d'une certaine couleur en fonction de son statut en plus de sa bordure gauche
            {
                Console.ForegroundColor = c.plante.GetCouleurAffichage();
                Console.Write($"║{c.AfficherEmoji()}");
            }
            else // Sinon on affiche seulement la bordure gauche d'une certaine couleur en fonction de la case et de son terrain associé
            {
                Console.ForegroundColor = c.GetCouleurBordure();
                Console.Write($"║{c.AfficherEmoji()}");
            }
            Console.ResetColor(); // On revient à la couleur d'affichage par défaut (= blanc)
        }
        Console.WriteLine("║");
    }

    public void PlacerPlante(int x, int y, Plante p) // Permet d'ajouter une nouvelle plante à une case 
    {
        if (x >= 0 && x < lignes && y >= 0 && y < colonnes) // On vérifie que les coordonnées se situent bien dans la grille
        {
            p.x = x;
            p.y = y;
            cases[x, y].plante = p;
        }
        else 
        {
            Console.WriteLine("Coordonnées invalides, impossible de placer la plante.");
        }
    }

    public List<Case> RecupererVoisines(int X, int Y) // Crée une liste des cases voisines à une dont les coordonnées sont rentrées en paramètre
    {
        List<Case> voisines = new List<Case>();
        int[] dx = { -1, 1, 0, 0 }; // haut et bas
        int[] dy = { 0, 0, -1, 1 }; // gauche et droite
        for (int i = 0; i < 4; i++)
        {
            int nx = X + dx[i];
            int ny = Y + dy[i];
            if (nx >= 0 && nx < lignes && ny >= 0 && ny < colonnes) // On vérifie que les coordonnées de la case voisine se situent bien dans la grille
            {
                voisines.Add(cases[nx, ny]); // On ajoute cette case à la liste des voisines
            }
        }
        return voisines;
    }
}
