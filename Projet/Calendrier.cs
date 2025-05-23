public class Calendrier
{
    public int semaine { get; set; }
<<<<<<< HEAD
    public Calendrier(int semaine)
=======

    public Calendrier()
>>>>>>> refs/remotes/origin/main
    {
        this.semaine = semaine;
    }
<<<<<<< HEAD
    public Saison saisonCourante // Propriété en lecture seule qui renvoie la saison actuelle en fonction de la semaine du calendrier
    {
        get
        {
            if (semaine >=1 && semaine <= 13) // Les 13 premières semaines de l'année correspondent (approximativement) à l'hiver
=======

    public Saison saisonCourante
    {
        get
        {
            if (semaine >= 1 && semaine <= 13)
>>>>>>> refs/remotes/origin/main
                return new Hiver();
            else if (semaine >= 14 && semaine <= 26) // Les 13 suivantes correspondent au printemps
                return new Printemps();
            else if (semaine >= 27 && semaine <= 39) // Les 13 suivantes correspondent à l'été
                return new Ete();
            else // Les 13 suivantes correspondent à l'automne
                return new Automne();
        }
    }
<<<<<<< HEAD
    public void AvancerSemaine() // Permet de faire avancer les semaines
=======

    public void AvancerSemaine()
>>>>>>> refs/remotes/origin/main
    {
        semaine++;
        if (semaine > 52)
            semaine = 1; // Une nouvelle année débute
    }
}
