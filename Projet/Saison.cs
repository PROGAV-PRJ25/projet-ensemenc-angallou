public abstract class Saison
{
    private static Random rng = new Random();
    public string nom;
    public double pluieMoyenne;
    public double soleilMoyen;
    public double pluieActuelle;
    public double soleilActuel;
    public int temperatureActuelle;
    public Saison(string Nom, double PluieMoyenne, double SoleilMoyen)
    {
        nom = Nom;
        pluieMoyenne = Pluie;
        soleilMoyen = Soleil;
        CalculerMeteo();
    }
    public void CalculerMeteo()
    {
        pluieActuelle = rng.NextDouble();
        soleilActuel = rng.NextDouble();
        temperatureActuelle = rng.Next(RecupererTempMin(), RecupererTempMin() + 1);
    }
    public string DecrireMeteo()
    {
        if (pluieActuelle < pluieMoyenne) 
        {
            return (soleilActuel < soleilMoyen) ? "Nuageux" : "Ensoleillé"; // Si soleil > Soleil, alors le temps est "Nuageux" sinon il est "Ensoleillé"
        }
        else
        {
            return (soleilActuel < soleilMoyen) ? "Pluvieux" : "Averse ensoleillée";
        }
    }
    public override string ToString()
    {
        return $"{Nom} - Pluie : {pluieActuelle*100}% - Soleil : {soleilActuel*100}% - Température : {temperatureActuelle}°C";
    }
    public abstract int RecupererTempMin();
    public abstract int RecupererTempMax();
}