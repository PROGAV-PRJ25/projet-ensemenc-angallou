public abstract class Plante
{
    public int x { get; set; }
    public int y { get; set; }
    public string type { get; set; }
    public Plante(int X, int Y, string Type)
    {
        X = X;
        Y = Y;
        type = Type;
    }
    //place = pour la croissance
    public bool VerifLimPlateau(int x, int y)
    { }
    public abstract Croissance();
    public abstract 

}