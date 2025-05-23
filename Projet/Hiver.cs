public class Hiver : Saison
{
<<<<<<< HEAD
    public Hiver() : base ("Hiver",0.8, 0.2) { }
    public override int RecupererTempMin() {return -10;} // Température minimale de saison estimée à -10°C
    public override int RecupererTempMax() {return 10;} // Température maximale de saison estimée à 10°C
=======
    public Hiver()
        : base("Hiver", 0.8, 0.2) { }
>>>>>>> refs/remotes/origin/main

    public override int RecupererTempMin()
    {
        return -10;
    }

    public override int RecupererTempMax()
    {
        return 10;
    }
}
