public class QueCalorose : Maladie
{
    public int delaiSurvie { get; set; }

    public QueCalorose(int X, int Y)
        : base(X, Y, false, 100, "Boule de glace", typeof(FleurDeGlace))
    {
        delaiSurvie = 8;
    }

    public override void Infecter(Plante plante)
    {
        if (EstPlanteCible(plante))
        {
            digestion = true;
            delaiSurvie = 8; // compte à rebours avant la mort si les toxinelles n'ont pas été anéanties
            Console.WriteLine($"{plante.nom} a attrapé la quécalorose !");
        }
    }
    public void Agoniser(Plante plante)
    {
        if (digestion)
        {
            delaiSurvie--;
            if (delaiSurvie == 0)
            {
                plante.etat = false;
                Console.WriteLine($"{plante.nom} est mort : la quécalorose a eu raison de votre plante !");
            }
        }
    } 
}


