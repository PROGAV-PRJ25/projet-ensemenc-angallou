public abstract class Saison
{
    public double Pluie;
    public double Soleil;
    public Saison (double pluie, double soleil)
    {
        Pluie = pluie;
        Soleil = soleil;
    }
    public string CalculerMeteo();
}