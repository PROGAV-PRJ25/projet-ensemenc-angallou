public class Case
{
    public int x { get; set; }
    public int y { get; set; }
    public Terrain terrain { get; set; }
    public Plante plante { get; set; }

    public Case(int X, int Y, Terrain ter = null)
    {
        x = X;
        y = Y;
        terrain = ter;
        plante = null;
    }

    public string AfficherEmoji()
    {
        if (plante != null)
            return plante.RecupererEmoji();
        else if (terrain != null)
            return terrain.RecupererTerrain();
        else
            return "   ";
    }

    public bool EstVide()
    {
        return plante == null;
    }
}
