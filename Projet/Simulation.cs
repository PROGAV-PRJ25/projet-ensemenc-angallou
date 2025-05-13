public class Simulation
{
    private List<Plante> plantes;
    private Calendrier calendrier;
    public Simulation(List<Plante> plante)
    {
        plantes = plante;
        calendrier = new Calendrier();
    }
    public void LancerJeu()
    {
        while (true)
        {
            Console.WriteLine($"\n Semaine {calendrier.semaine}")
            foreach (Plante plante in plantes)
            {
                if (plante.etat)
                {
                    double eau = 1;
                    double lumiere = 2;
                    int temperature = TempParSaison(calendrier.saisonCourante);
                    bool bonEspacement = (plante.espacement <= plante.place);
                    plante.Croissance(plante.terrainPref,bonEspacement,eau,lumiere,temperature);
                    Console.WriteLine($"Plante {plante.nom} - Taille : {plante.place} - Etat : Vivante");     
                }
                else
                    Console.WriteLine($"Plante {plante.nom} - Etat : Décédée");     
                
            }
            calendrier.AvancerSemaine();
            Console.WriteLine("Appuyez sur Entrée pour passer à la semaine suivante, ou sur Q pour quiiter le jeu");
            ConsoleKeyInfo touche = Console.ReadKey(true);
            if (touche.Key == ConsoleKey.Q)
            {
                Console.WriteLine("Partie abandonnée !");
                break;
            }
        }
    }
    public int TempParSaison(Saison saison)
    {
        if (saison.Nom == "Hiver") 
            return 
    }
}