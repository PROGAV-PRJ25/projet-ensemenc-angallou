Console.WriteLine("Test :");
Grille grille = new Grille();
Console.Clear();
grille.Afficher();
Saison hiver = new Saison(0.8,0.2);
Saison printemps = new Saison(0.3,0.7);
Saison ete = new Saison(0.1,0.9);
Saison automne = new Saison(0.6,0.4);
hiver.CalculerMeteo();