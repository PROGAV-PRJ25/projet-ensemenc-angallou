public abstract class Saison
{
    public double probaPluie;
    public double probaSoleil;
    public Saison (double pluie, double soleil)
    {
        probaPluie = pluie;
        probaSoleil = soleil;
    }
    public void AfficherMeteo();
}