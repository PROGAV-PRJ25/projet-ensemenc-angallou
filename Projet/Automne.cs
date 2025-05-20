public class Automne : Saison
{
    public Automne()
        : base("Automne", 0.6, 0.4) { }

    public override int RecupererTempMin()
    {
        return 5;
    }

    public override int RecupererTempMax()
    {
        return 15;
    }
}
