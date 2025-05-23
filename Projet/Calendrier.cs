public class Calendrier
{
    public int semaine { get; set; }

    public Calendrier(int semaine)
    {
        this.semaine = semaine;
    }

    public Saison saisonCourante // Propriété en lecture seule qui renvoie la saison actuelle en fonction de la semaine du calendrier
    {
        get
        {
            if (semaine >= 1 && semaine <= 13) // Les 13 premières semaines de l'année correspondent (approximativement) à l'hiver
                return new Hiver();
            else if (semaine >= 14 && semaine <= 26) // Les 13 suivantes correspondent au printemps
                return new Printemps();
            else if (semaine >= 27 && semaine <= 39) // Les 13 suivantes correspondent à l'été
                return new Ete();
            else // Les 13 suivantes correspondent à l'automne
                return new Automne();
        }
    }

    public void AvancerSemaine() // Permet de faire avancer les semaines
    {
        semaine++;
        if (semaine > 52)
            semaine = 1; // Une nouvelle année débute
    }
}
