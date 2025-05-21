public abstract class Terrain
{
    public string nom { get; set; }

    public Terrain() { }

    public abstract string RecupererTerrain();

    public virtual void ReagirASaison(Saison saison) { }
}
