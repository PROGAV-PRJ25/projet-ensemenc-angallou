public abstract class Terrain
{
<<<<<<< HEAD
    public string? nom;
    public Terrain() { }
=======
    public string nom { get; set; }

    public Terrain() { }

    public abstract string RecupererTerrain();

>>>>>>> refs/remotes/origin/main
    public virtual void ReagirASaison(Saison saison) { }
}
