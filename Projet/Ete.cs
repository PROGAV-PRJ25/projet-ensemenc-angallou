public class Ete : Saison
{
<<<<<<< HEAD
    public Ete() : base ("Été", 0.1, 0.9) { }
    public override int RecupererTempMin() {return 20;} // Température minimale de saison estimée à 20°C
    public override int RecupererTempMax() {return 40;} // Température maximale de saison estimée à 40°C
=======
    public Ete()
        : base("Été", 0.1, 0.9) { }
>>>>>>> refs/remotes/origin/main

    public override int RecupererTempMin()
    {
        return 20;
    }

    public override int RecupererTempMax()
    {
        return 35;
    }
}
