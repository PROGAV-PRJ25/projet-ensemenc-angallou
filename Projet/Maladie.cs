public abstract class Maladie {
    public string nom {get; set;}
    public int x { get; set; }
    public int y { get; set; }
    public Plante planteCible {get; set;}
    public double attaque {get; set;}
    public string faiblesse {get; set;} 
    // [] -> à voir si on en met qu'une de faiblesse ou pas
    public bool modeUrgence {get; set;}
public Maladie(int X, int Y, bool ModeUrgence, Plante PlanteCible, double Attaque, string Faiblesse)
 {
x = X ;
y = Y;
planteCible = PlanteCible;
attaque = Attaque;
faiblesse=Faiblesse;
modeUrgence = ModeUrgence;
}
public abstract class Invasion{

}
}
//gérer le mode urgence
//gérer les différentes maladies
// gérer les différentes attaques
//est-ce que je met un bool il y a plante ? mehhh on verra ça dans les codes au cas par cas
// Ne pas oublier de faire le mode urgence et les différentes manières de se protéger des invasions