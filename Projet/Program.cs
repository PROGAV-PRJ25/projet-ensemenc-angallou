Console.WriteLine("Test :");
Grille grille = new Grille();
Console.Clear();
grille.Afficher();

Calendrier calendrier = new Calendrier();

for (int i = 0; i < 10; i++)
{
    Saison saison = calendrier.saisonCourante;
    string meteo = saison.CalculerMeteo();

    Console.WriteLine($"Semaine {calendrier.semaine}: Saison = {saison}, Météo = {meteo}");
    //plante.Croissance(saison,meteo);
    calendrier.AvancerSemaine();
}