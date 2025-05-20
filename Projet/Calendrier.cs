public class Calendrier
{
    public int semaine { get; set; }

    public Calendrier()
    {
        semaine = 1;
    }

    public Saison saisonCourante
    {
        get
        {
            if (semaine >= 1 && semaine <= 13)
                return new Hiver();
            else if (semaine >= 14 && semaine <= 26)
                return new Printemps();
            else if (semaine >= 27 && semaine <= 39)
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
