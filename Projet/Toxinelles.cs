public class Toxinelles : Maladie
{
    public bool digestion { get; set; }
    public int delaiSurvie { get; set; }
    public Toxinelles(int X, int Y) : base(X, Y, false, 100, "Plantes Carnivores", typeof(ArbreACheddar)) { }
    {
        digestion = false;
        delaiSurvie = 3;
    }
    public override void Infecter(Plante plante)
    {
        if (EstPlanteCible(plante))
        {
            digestion = true;
            delaiSurvie = 3; // compte à rebours avant la mort si les toxinelles n'ont pas été anéanties
            Console.WriteLine($"{plante.nom} a été infecté par des toxinelles !");
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
                Console.WriteLine($"{plante.nom} est mort : les toxinelles ont eu raison de votre plante !");
            }
        }
    }
}
