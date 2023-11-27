# 2048 en C#

![Capture d'écran du jeu](screenshot.png)

## Description

Ceci est une implémentation simple du jeu de puzzle 2048 en C#. Le jeu offre une approche basée sur la console avec des fonctionnalités classiques de fusion de tuiles pour atteindre la valeur 2048.

## Règles du jeu

- **Plateau de jeu :** Le jeu se joue sur une grille en 4x4, initialement remplie de deux chiffres.
- **Combinaison des tuiles :** En déplaçant les tuiles dans les 4 directions, elles se fusionnent avec les tuiles voisines ayant le même chiffre, doublant ainsi sa valeur.
- **Ajout d'une nouvelle tuile :** À chaque mouvement, une nouvelle tuile '2' ou '4' apparaît de manière aléatoire sur le plateau (90% de chance d'être '2' 10% de chance d'être '4'), occupant une case vide.
- **Objectif :** L'objectif est d'obtenir une tuile '2048' en combinant les tuiles. Cependant, le jeu continue après avoir atteint 2048.
- **Fin de la partie :** La partie se termine lorsque la grille est pleine et qu'aucun mouvement n'est possible.
- **Stratégie :** Une stratégie connue est de maintenir les tuiles de grandes valeurs dans un coin pour maximiser les combinaisons.

## Comment jouer

- Utilisez les flèches directionnelles (haut, bas, gauche, droite) pour déplacer les tuiles sur la grille.

## Fonctionnalités

- Interface basée sur la console pour une expérience de jeu simple.
- Suivi du score et du meilleur score.
- Gestion de la grille en C# avec des méthodes de fusion et de déplacement.

## Comment démarrer

1. Clonez le dépôt :

   ```bash
   git clone https://github.com/SamuelRothlisberger/2048.git
   ```

2. Ouvrez le projet dans votre environnement de développement C#.

3. Exécutez le programme pour commencer à jouer.

## Exigences

- .NET Core (version 4.7.2)

## Crédits

- Développé par Röthlisberger.