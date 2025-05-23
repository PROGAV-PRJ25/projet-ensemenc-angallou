public class Ete : Saison
{
    public Ete()
        : base("Été", 0.1, 0.9) { }

    public override int RecupererTempMin()
    {
        return 20;
    } // Température minimale de saison estimée à 20°C

    public override int RecupererTempMax()
    {
        return 40;
    } // Température maximale de saison estimée à 40°C
}
