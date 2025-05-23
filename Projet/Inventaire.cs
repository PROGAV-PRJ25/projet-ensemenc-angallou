public class Inventaire
{
    public int nbEclairs; // Permet d'arrêter Mario et son kart en mode Urgence
    public int nbSerums; // Permet de guérir la maladie dont est atteinte une plante
    public int nbEtoiles; // Permet de monter le taux de satisfaction d'une plante à 1 (assurant sa survie et une croissance rapide)
    public int nbBoulesFeu; // Permet de combattre la glaglaose et de dégeler le terrain Océan durant l'hiver (non implémentés)
    public int nbBoulesGlace; // Permet de combattre la quécalorose et de solidifier le terrain Fromage durant l'été (non implémentés)
    public int nbCheddar; // Peut être donné à manger à une Plante Carnivore

    public Inventaire()
    {
        // On commence le jeu avec un inventaire vide
        nbEclairs = 0; //ou 1
        nbSerums = 0;
        nbEtoiles = 0;
        nbBoulesFeu = 0;
        nbBoulesGlace = 0;
        nbCheddar = 0;
    }
}
