public class Hiver : Saison
{
    Random rng = new Random();
    public Hiver(double Pluie, double Soleil) : base(Pluie,Soleil)
    {
        Pluie = 0.8;
        Soleil = 0.2;
    }
    public override string CalculerMeteo()
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
    }
}