public class Grille
{
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
                cases[i, j] = new Case(i, j);
            }
        }
    }

    public void Afficher() // Affiche toute la grille
    {
        Console.Clear();

        for (int i = 0; i < lignes; i++)
        {
            AfficherLigneSeparatrice(i == lignes / 2); // Affiche les bordures de cases
            AfficherLigneContenu(i); // Affiche le contenu des cases
        }
        AfficherLigneSeparatrice(false); // Affiche la dernière bordure, pas besoin de bloc spécial ici
    }

    private void AfficherLigneSeparatrice(bool ligneCentre)
    {
        for (int i = 0; i <= lignes; i++)
        {
            if (i == colonnes / 2 && ligneCentre) // si on est au centre de la grille, on affiche le bloc spécial
                Console.Write("╬ ▒▒ ");
            else
                Console.Write("╬═══");
        }
        Console.WriteLine("╬");
    }

    private void AfficherLigneContenu(int ligne)
    {
        for (int colonne = 0; colonne < colonnes; colonne++)
        {
            Case c = cases[ligne, colonne];

            if (ligne == (lignes / 2) && colonne == (colonnes / 2)) // si on est à la ligne centrale, on n'affiche que des blocs spéciaux
                Console.Write("║ ▒▒ ");
            else if (c.plante != null)
                Console.Write($"║ {c.plante.nom[0]} ");
            else
                Console.Write("║   ");
        }
        Console.WriteLine("║");
    }

    public void PlacerPlante(int x, int y, Plante p)
    {
        if (x >= 0 && x < lignes && y >= 0 && y < colonnes)
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
}
