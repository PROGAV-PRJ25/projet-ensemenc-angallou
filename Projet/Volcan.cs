public class Volcan : Terrain
{
    public Volcan()
    {
        nom = "Volcan";
    }

    public override string RecupererTerrain()
    {
        return "🟥";
    }
}
