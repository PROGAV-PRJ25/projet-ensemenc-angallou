public class PlanteCarnivore : Plante
{
    public bool boostCheddar = false;
    public PlanteCarnivore(int X, int Y) : base("Plante Carnivore", X, Y, true, false, new Printemps(), new ArcEnCiel(), 1, 1, 1, 0.5, 0.7, 10, 35, null, 20, 0)
    {
        emoji = "🪴";
    }
    public override void Croissance(Terrain terrain, bool espacement, double eau, double lumiere, int temp)
    {
        base.Croissance(terrain, espacement, eau, lumiere, temp);

        if (Satisfaction(terrain, espacement, eau, lumiere, temp) < 0.8)
        {
            Console.WriteLine($"La plante carnivore a faim... Elle risque de dévorer une de ses voisines...");
            // Gérer ce comportement dans la Grille
        }
    }
    public void MangerToxinelles(List<ArbreACheddar> voisins)
    {
        foreach (var v in voisins)
        {
            if (v.maladie == Toxinelles toxinelles && toxinelles.digestion)
            {
                int alea = boostCheddar ? 100 : 50; // plus de chances de manger des toxinelles si on donne du cheddar à la plante
                if (new.Random().Next(100) < alea)
                {
                    toxinelles.digestion = false;
                    Console.WriteLine($"La plante carnivore a mangé les toxinelles qui infectaient {v.nom}");
                }
                else
                {
                    Console.WriteLine($"La plante carnivore n'a pas réussi à manger les toxinelles qui infectaient {v.nom}");
                }
            }
        }
    }
    public override void ActiverPouvoirSpecial()
    {
        // Donne des graines à sa mort ?
    }
}