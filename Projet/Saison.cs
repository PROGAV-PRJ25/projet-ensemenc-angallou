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
    public abstract string CalculerMeteo()
    {
        double pluie = rng.Next(0,1);
        double soleil = rng.Next(0,1);
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
    };
}