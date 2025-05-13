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
        AfficherLigneSeparatrice(false); // dernière ligne, pas besoin de bloc spécial ici
    }
    private void AfficherLigneSeparatrice(bool ligneCentre)
    {
        for (int i = 0; i <= lignes; i++)
        {
            if (i == colonnes / 2 && ligneCentre)
                Console.Write("╬ ▒▒ ");
            else
                Console.Write("╬═══");
        }
        Console.WriteLine("╬");
    }
    private void AfficherLigneContenu(bool ligneCentre)
    {
        for (int i = 0; i <= lignes; i++)
        {
            if (i == colonnes / 2 && ligneCentre)
                Console.Write("║ ▒▒ ");
            else
                Console.Write("║   ");
        }
        Console.WriteLine("║");
    }
}
