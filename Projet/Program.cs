Console.WriteLine("Test :");
Grille grille = new Grille();
Console.Clear();
grille.Afficher();

Calendrier calendrier = new Calendrier();

for (int i = 0; i < 10; i++)
{
    Saison saison = calendrier.saisonCourante;
    string meteo = saison.CalculerMeteo()

    Console.WriteLine($"Semaine {calendrier.Semaine}: Saison = {saison}, Météo = {meteo}");
    //plante.Croissance(saison,meteo);
    calendrier.AvancerSemaine();
}

Hiver hiver = new Hiver();
//Saison printemps = new Saison(0.3,0.7);
Ete ete = new Ete();
hiver.CalculerMeteo();


