# TP 1 - Tests & Validation

## 1 - Les difficultés liées à la validation

### 1.1 - Complexité cyclomatique

La complexité cyclomatique des fonctions de vérification sont élevés

```csharp
        // Morpion.cs
        public bool verifVictoire(char c) =>
             grille[0, 0] == c && grille[1, 0] == c && grille[2, 0] == c ||
             grille[0, 1] == c && grille[1, 1] == c && grille[2, 1] == c ||
             grille[0, 2] == c && grille[1, 2] == c && grille[2, 2] == c || 
        ...
```

```csharp
        // PuissanceQuatre.cs
        public bool verifVictoire(char c) =>
             grille[0, 0] == c && grille[1, 0] == c && grille[2, 0] == c && grille[3, 0] == c ||
             grille[0, 1] == c && grille[1, 1] == c && grille[2, 1] == c && grille[3, 1] == c ||
             grille[0, 2] == c && grille[1, 2] == c && grille[2, 2] == c && grille[3, 2] == c ||
        ...
```

### 1.2 - Code redondant

Les méthodes `tourJoueur` et `tourJoueur2` partagent une grande partie de leur logique, mais elles sont implémentées séparément dans chaque classe. Cela rend le code sujet aux erreurs et plus difficile à maintenir.

```csharp
// Morpion.cs
public void tourJoueur()
{
    // Logique spécifique au joueur 1
}
public void tourJoueur2()
{
    // Logique similaire au joueur 1, mais adaptée pour le joueur 2
}
```

```csharp
// PuissanceQuatre.cs
public void tourJoueur()
{
    // Logique spécifique au joueur 1
}
public void tourJoueur2()
{
    // Logique similaire au joueur 1, mais adaptée pour le joueur 2
}
```

### 1.3 - Couplage fort

#### 1.3.1 - Avec la console

Les appels à la console sont effectués directement dans les classes de jeu. Cela rend le code dépendant de l'interface console, limitant la possibilité d'ajouter d'autres interfaces utilisateur (GUI)

### 1.4 - Gestion des erreurs

Les méthodes de déplacement des joueurs (`tourJoueur` et `tourJoueur2`) n'incluent pas de gestion des erreurs, ce qui peut conduire à des comportements inattendus.

### 1.5 - Violation des principes SOLID

Les classes Morpion et PuissanceQuatre assument plusieurs responsabilités telles que la gestion du jeu, l'interaction avec la console et la vérification de la victoire. Cela viole le principe de responsabilité unique de SOLID, rendant le code moins modulaire et difficile à étendre.

### 1.6 - Présence de code mort

Présence de code mort dans `tourJoueur.cs` du puissance quatre

```csharp
// PuissanceQuatre.cs


                    //case ConsoleKey.UpArrow:
                    //    if (row <= 0)
                    //    {
                    //        row = 3;
                    //    }
                    //    else
                    //    {
                    //        row = row - 1;
                    //    }
                    //    break;

                    //case ConsoleKey.DownArrow:
                    //    if (row >= 3)
                    //    {
                    //        row = 0;
                    //    }
                    //    else
                    //    {
                    //        row = row + 1;
                    //    }
                    //    break;
...
```

### 1.7 - Présence de nombre magique

Lors de la création de la grille du morpion et du puissance quatre : 

```csharp
        // PuissanceQuatre.cs
        public PuissanceQuatre()
        {
            grille = new char[4, 7];
        }
```

Lors du déplacement du curseur : 

```csharp
                // PuissanceQuatre.cs
                Console.WriteLine("Choisir une case valide est appuyer sur [Entrer]");
                Console.SetCursorPosition(column * 6 + 1, row * 4 + 1);
```

Il est possible de faire des tests uniquement sur des fonctions qui retournent quelque chose (normalement il y a deux fonctions bool) et pas sur les void

## 2 - Les méthodes de résolution de ces problèmes

- Séparation des Classes

- Application des Principes SOLID

- Tests Unitaires

- Refactoring
