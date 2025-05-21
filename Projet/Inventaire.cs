public class Inventaire
{
    public int nbEclairs;
    public int nbSerums;
    public int nbEtoiles;
    public int nbBoulesFeu;
    public int nbBoulesGlace;

    public Inventaire()
    {
        nbEclairs = 0;
        nbSerums = 0;
        nbEtoiles = 0;
        nbBoulesFeu = 0;
        nbBoulesGlace = 0;
    }

    public void Ajouter(string type)
    {
        if (type == "éclair")
            nbEclairs++;
        else if (type == "sérum")
            nbSerums++;
        else if (type == "étoile")
            nbEtoiles++;
        else if (type == "feu")
            nbBoulesFeu++;
        else if (type == "glace")
            nbBoulesGlace++;
    }
}
