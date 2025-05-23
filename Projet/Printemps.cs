public class Printemps : Saison
{
    public Printemps() : base ("Printemps",0.3, 0.7) { }
    public override int RecupererTempMin() {return 10;} // Température minimale de saison estimée à 10°C
    public override int RecupererTempMax() {return 30;} // Température maximale de saison estimée à 30°C
}