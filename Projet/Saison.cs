public abstract class Saison
{
    Random rng = new Random();
    public double Pluie;
    public double Soleil;
    public Saison(double pluie, double soleil)
    {
        Pluie = pluie;
        Soleil = soleil;
    }
    public string CalculerMeteo()
    {
        double pluie = rng.NextDouble();
        double soleil = rng.NextDouble();
        if (pluie > Pluie)
        {
            if (soleil > Soleil)
                return "Nuageux";
            else
                return "Ensoleillé";
        }
        else
        {
            if (soleil > Soleil)
                return "Pluvieux";
            else
                return "Averse ensoleillée";
        }
    }
}