public class Hiver : Saison
{
    public Hiver()
        : base("Hiver", 0.8, 0.2) { }

    public override int RecupererTempMin()
    {
        return -10;
    }

    public override int RecupererTempMax()
    {
        return 10;
    }
}
