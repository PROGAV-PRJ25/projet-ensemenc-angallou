public class Ete : Saison
{
    public Ete() : base ("Été", 0.1, 0.9) {}
    public override int RecupererTempMin() {return 20}
    public override int RecupererTempMax() {return 35}

}