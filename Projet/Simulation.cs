public class Simulation
{
    public List<Plante> plantes;
    public List<Maladie> maladies;
    public Calendrier calendrier;
    public Grille grille;
    public Inventaire inventaire;
    public Simulation(List<Plante> plante)
    {
        plantes = plante;
        calendrier = new Calendrier();
        maladies = new List<Maladie>();
    }
    public void LancerJeu()
    {
        while (true)
        {
            Saison saison = calendrier.saisonCourante;
            saison.CalculerMeteo();

            double eau = saison.pluieActuelle;
            double lumiere = saison.soleilActuel;
            int temperature = saison.temperatureActuelle;

            Console.Clear();
            Console.WriteLine($"\n Semaine n°{calendrier.semaine}");
            Console.WriteLine(saison);

            foreach (Plante plante in plantes)
            {
                foreach (Maladie maladie in maladies)
                {
                    if (
                        plante.x == maladie.x
                        && plante.y == maladie.y
                        && maladie.EstPlanteCible(plante)
                    )
                    {
                        plante.maladie = maladie; // elle est maintenant infectée
                        maladie.Infecter(plante); //TO DO
                        Console.WriteLine(
                            $"{plante.nom} est infectée par {maladie.GetType().Name} !"
                        );
                        // infection possible
                        // enlever de la vie aussi
                    }
                    if (plante.etat)
                    {
                        bool bonEspacement = (plante.espacement <= plante.place);
                        plante.Croissance(
                            plante.terrainPref,
                            bonEspacement,
                            eau,
                            lumiere,
                            temperature
                        );
                        Console.WriteLine(
                            $"Plante {plante.nom} - Taille : {plante.place} - Etat : Vivante"
                        );
                    }
                    else
                        Console.WriteLine($"Plante {plante.nom} - Etat : Décédée");
                }
            }

            calendrier.AvancerSemaine();

            Console.WriteLine(
                "\nAppuyez sur Entrée pour passer à la semaine suivante, ou sur Q pour quiiter le jeu"
            );
            ConsoleKeyInfo touche = Console.ReadKey(true);
            if (touche.Key == ConsoleKey.Q)
            {
                Console.WriteLine("Partie abandonnée !");
                break;
            }
        }
    }
}
