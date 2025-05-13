public class Calendrier
{
    public int semaine;
    public Calendrier()
    {
        semaine = 1; 
    }
    public Saison saisonCourante // Détermine la saison actuelle selon la semaine actuelle
    {
        get
        {
            if (semaine >=1 && semaine <= 13) // Les 13 premières semaines c'est l'hiver
                return new Hiver();
            else if (semaine >= 14 && semaine <= 26) // Les 13 suivantes c'est le printemps
                return new Printemps();
            else if (semaine >= 27 && semaine <= 39) // Les 13 suivantes c'est l'été
                return new Ete();
            else // Les 13 suivantes c'est l'automne 
                return new Automne();
        }
    }
    public void AvancerSemaine()
    {
        semaine++;
        if (semaine > 52) // Si une année est terminée, on en recommence une
            semaine = 1;
    }
}