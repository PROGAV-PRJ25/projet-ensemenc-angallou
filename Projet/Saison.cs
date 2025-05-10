public abstract class Saison
{
    private static Random rng = new Random();
    public string Nom;
    public double Pluie;
    public double Soleil;
    public Saison(string nom, double pluie, double soleil)
    {
        Nom = nom;
        Pluie = pluie;
        Soleil = soleil;
    }
    public string CalculerMeteo()
    {
        double pluie = rng.NextDouble();
        double soleil = rng.NextDouble();
        if (pluie > Pluie)
        {
            return (soleil > Soleil) ? "Nuageux" : "Ensoleillé"; 
        }
        else
        {
            return (soleil > Soleil) ? "Pluvieux" : "Averse ensoleillée";
        }
    }
    public override string ToString()
    {
        return Nom;
    }
}