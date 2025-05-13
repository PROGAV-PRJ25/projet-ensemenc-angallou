public class Grille
{
    public int lignes;
    public int colonnes;
    public Grille()
    {
        lignes = 6;
        colonnes = 6;
    }
    public void Afficher()
    {
        Console.Clear();

        int moitie = lignes / 2; // indice de la moitié du potager

        for (int i = 0; i <= lignes; i++)
        {
            AfficherLigneSeparatrice(i == moitie); // ligne formant les bordures de cases
            AfficherLigneContenu(i == moitie); // ligne formant les contenus de cases
        }
        AfficherLigneSeparatrice-






            {
                Console.Write("╬═══"); // chaque cellule est encadrée de " ╬═══ "
            }
            Console.Write("╬");
            Console.Write(" ▒▒ ");
            for (int i = lignes/2; i < lignes+1; i++)
            {
                Console.Write("╬═══"); // chaque cellule est encadrée de " ╬═══ "
            }
            Console.WriteLine("╬");
            for (int i = 0; i < (lignes/2)+1; i++)
            {
                Console.Write("║   "); // Chaque case est entourée de " ║ "
            }
            Console.Write("║");
            Console.Write(" ▒▒ ");
            for (int i = lignes/2; i < lignes+1; i++)
            {
                Console.Write("║   "); // Chaque case est entourée de " ║ "
            }
            Console.WriteLine("║");
            k++;
        }
        for (int i = 0; i < (lignes/2)+1; i++)
        {
            Console.Write("╬═══"); // chaque cellule est encadrée de " ╬═══ "
        }
        Console.Write("╬");
        Console.Write(" ▒▒ ");
        for (int i = lignes/2; i < lignes+1; i++)
        {
            Console.Write("╬═══"); // chaque cellule est encadrée de " ╬═══ "
        }
        Console.WriteLine("╬");

        for (int i = 0; i < (lignes/2)+1; i++)
        {
            Console.Write("▒▒▒▒");
        }
        Console.Write("▒▒");
        Console.Write("  ");
        Console.Write("▒▒");
        for (int i = (lignes/2)+1; i < lignes+2; i++)
        {
            Console.Write("▒▒▒▒");
        }
        Console.WriteLine();

        k = (lignes/2)+1;
        while (k < lignes+2)
        {
            for (int i = 0; i < (lignes/2)+1; i++)
            {
                Console.Write("╬═══"); // chaque cellule est encadrée de " ╬═══ "
            }
            Console.Write("╬");
            Console.Write(" ▒▒ ");
            for (int i = lignes/2; i < lignes+1; i++)
            {
                Console.Write("╬═══"); // chaque cellule est encadrée de " ╬═══ "
            }
            Console.WriteLine("╬");
            for (int i = 0; i < (lignes/2)+1; i++)
            {
                Console.Write("║   "); // Chaque case est entourée de " ║ "
            }
            Console.Write("║");
            Console.Write(" ▒▒ ");
            for (int i = lignes/2; i < lignes+1; i++)
            {
                Console.Write("║   "); // Chaque case est entourée de " ║ "
            }
            Console.WriteLine("║");
            k++;
        }
        for (int i = 0; i < (lignes/2)+1; i++)
        {
            Console.Write("╬═══"); // chaque cellule est encadrée de " ╬═══ "
        }
        Console.Write("╬");
        Console.Write(" ▒▒ ");
        for (int i = lignes/2; i < lignes+1; i++)
        {
            Console.Write("╬═══"); // chaque cellule est encadrée de " ╬═══ "
        }
        Console.WriteLine("╬");
    }

}
