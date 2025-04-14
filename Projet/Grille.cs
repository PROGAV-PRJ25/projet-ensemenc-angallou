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
}