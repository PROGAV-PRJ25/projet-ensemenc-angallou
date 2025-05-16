public class Inventaire
{
    public int nbEclairs = 0;
    public int nbSerums = 0;
    public int nbEtoiles = 0;
    public void Ajouter(string type)
    {
        if (type == "éclair")
            nbEclairs++;
        else if (type == "sérum")
            nbSerums++;
        else if (type == "étoile")
            nbEtoiles;
    }
}