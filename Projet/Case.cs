public class Case
{
    public int x { get; set; }
    public int y { get; set; }
    public Terrain terrain { get; set; } 
    public Plante? plante { get; set; } // ? car une case peut ne pas avoir de plante
    public Case(int X, int Y, Terrain ter = null)
    {
        x = X;
        y = Y;
        terrain = ter;
        plante = null; // Les cases n'ont pas de plante à la base
    }
    public string AfficherEmoji() // Méthode permettant de savoir quel symbole afficher dans la case
    {
        if (plante == null) // si la case ne contient pas de plante, on renvoie une case vide
        {
            return "   "; 
        }
        if (!plante.etat) // si la plante est morte (plante.etat = false), on renvoie X
        {
            return " X ";
        }
        else
        {
            // Renvoie une lettre spécifique en fonction de la plante associée à la case, permettant de bien identifier
            return plante switch
            {
                FleurDeFeu => " F ",
                FleurDeGlace => " G ",
                ArbreACheddar => " C ",
                PlanteCarnivore => " P ",
                _ => " ? ", // Pour prendre en charge toutes les valeurs possibles
            };
        }
    }
    public ConsoleColor GetCouleurBordure()
    {
    if (terrain is Fromage) // Le terrain fromage a des bordures jaunes
        return ConsoleColor.Yellow;
    else if (terrain is Ocean) // Le terrain océan a des bordures bleues
        return ConsoleColor.Blue;
    else if (terrain is Volcan) // Le terrain volcan a des bordures jaunes
        return ConsoleColor.Red;
    else if (terrain is ArcEnCiel) // Le terrain arc-en-ciel a des bordures magenta
        return ConsoleColor.Magenta;
    else
        return ConsoleColor.Gray; // Si le terrain n'est pas spécifié, alors les bordures seront grises
    }
}