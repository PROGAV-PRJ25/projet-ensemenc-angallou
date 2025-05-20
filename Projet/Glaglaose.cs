public class Glaglaose : Maladie
{
    public Glaglaose(int X, int Y)
        : base(X, Y, false, 100, "Boule de feu", typeof(FleurDeFeu))
    {
        delaiSurvie = 8;
    }

    public override void Infecter(Plante plante)
    {
        if (EstPlanteCible(plante))
        {
            digestion = true;
            delaiSurvie = 8; // compte à rebours avant la mort si les toxinelles n'ont pas été anéanties
            Console.WriteLine($"{plante.nom} a attrapé la glaglaose !");
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
                Console.WriteLine(
                    $"{plante.nom} est mort : la glaglaose a eu raison de votre plante !"
                );
            }
        }
    }
}
