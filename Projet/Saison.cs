public abstract class Saison
{
    private static Random rng = new Random();
    public string? nom;
    public double pluieMoyenne;
    public double soleilMoyen;
    public double pluieActuelle;
    public double soleilActuel;
    public int temperatureActuelle;
    public Saison(string Nom, double PluieMoyenne, double SoleilMoyen)
    {
        nom = Nom;
        pluieMoyenne = PluieMoyenne; // Taux de pluie moyen de saison (fixe dans les classes héritières)
        soleilMoyen = SoleilMoyen; // Taux de lumière moyen de saison (fixe dans les classes héritières)
        CalculerMeteo(); 
    }
    public void CalculerMeteo() // Calcule les données météo de la semaine actuelle
    {
        pluieActuelle = Math.Round(rng.NextDouble(),1); // Taux de pluie actuel (valeur aléatoire située entre 0 et 1)
        soleilActuel = Math.Round(rng.NextDouble(),1); // Taux de lumière actuel (valeur aléatoire située entre 0 et 1)
        temperatureActuelle = rng.Next(RecupererTempMin(), RecupererTempMax() + 1); // Température aléatoire située entre les température minimale et maximale de saison
    }
    public void DecrireMeteo() // Décrit brièvement le temps en fonction des valeurs de pluie et de soleil
    {
        string message;
        if (pluieActuelle < pluieMoyenne) // Si le taux de pluie actuel est inférieur au taux de pluie moyen de saison
        {
            message = (soleilActuel < soleilMoyen) ? "Nuageux" : "Ensoleillé"; // Si le taux de lumière actuel est inférieur au taux de lumière moyen de saison, affiche "Nuageux" sinon "Ensoleillé"
        }
        else // Si le taux de pluie actuel est supérieur ou égal au taux de pluie moyen de saison
        {
            message = (soleilActuel < soleilMoyen) ? "Pluvieux" : "Averse ensoleillée"; // Si le taux de lumière actuel est inférieur au taux de lumière moyen de saison, affiche "Pluvieux" sinon "Averse ensoleillée"
        }
        Console.WriteLine(message);
    }

    public override string ToString()
    {
        return $"{nom} - Pluie : {pluieActuelle} - Soleil : {soleilActuel} - Température : {temperatureActuelle}°C";
    }
    public abstract int RecupererTempMin(); 
    public abstract int RecupererTempMax();
}