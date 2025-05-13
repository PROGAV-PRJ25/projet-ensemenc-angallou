public class Printemps : Saison
{
    public Printemps() : base ("Printemps",0.3, 0.7) { }
    public override int RecupererTempMin() {return 10;}
    public override int RecupererTempMax() {return 20;}

}