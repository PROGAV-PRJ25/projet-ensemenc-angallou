public class Automne : Saison
{
    public Automne() : base ("Automne",0.6,0.4) { } 
    public override int RecupererTempMin() {return 0;} // Température minimale de saison estimée à 0°C
    public override int RecupererTempMax() {return 20;} // Température maximale de saison estimée à 20°C
}