public class Grille
{
    public int lignes;
    public int colonnes;
    public Grille(int row=8, int col=8)
    {
        lignes = row;
        colonnes = col;
    }
    public void Afficher()
    {
        Console.Write("\u001b[2J\u001b[H"); // Efface la console (équivalent à Console.Clear())
        for (int i = 0; i < lignes; i++)
        {
            for (int j = 0; j < colonnes; j++)
            {
                Console.Write($"[ ]");
            }
        }
    }
     // Afficher la première ligne de séparateurs
    for (int i = 0; i < plateau.GetLength(1); i++)
    {
        Console.Write("╬═══"); // chaque cellule est encadrée de " ╬═══ "
    }
    Console.WriteLine("╬");

    // Affichage des lignes du plateau
    for (int i = 0; i < plateau.GetLength(0); i++)
    {
        // Affichage des cases de chaque ligne
        for (int j = 0; j < plateau.GetLength(1); j++)
        {
            Console.Write("║ " + plateau[i, j] + " "); // Chaque case est entourée de " ║ "
        }
        Console.WriteLine("║");

        // Affichage de la ligne de séparation après chaque ligne de cases
        for (int j = 0; j < plateau.GetLength(1); j++)
        {
            Console.Write("╬═══"); // Séparateur après chaque ligne de cases
        }
        Console.WriteLine("╬");
    }
}
}