public class Calendrier
{
    public int semaine { get; set; }
    public class Calendrier()
    {
        semaine = 1;
    }
    public Saison saisonCourante
    {
        get
        {
            if (Semaine >=1 && Semaine <= 13)
                return new Hiver();
            else if (Semaine >= 14 && Semaine <= 26)
                return new Printemps();
            else if (Semaine >= 27 && Semaine <= 39)
                return new Ete();
            else
                return new Automne();
        }
    }
    public void AvancerSemaine()
    {
        semaine++;
        if (semaine > 52)
            semaine = 1; //une nouvelle année débute
    }
}