# Concours – Projet C# (.NET)

👩🏽‍💻 
Ce projet est une application console en C#** réalisée dans le cadre de l’apprentissage du langage C# / .NET.  
Il permet de gérer les résultats d’un concours à partir d’un fichier CSV contenant les informations des étudiants.

Le projet met en pratique :
- les énumérations classiques
- les énumérations à bits indicateurs ([Flags])
- la lecture de fichiers CSV
- la structuration du code avec une DAL (Data Access Layer)


Structure du projet

- Program.cs  
  Contient le point d’entrée du programme (`Main`) et les méthodes d’affichage.
  
- DAL.cs
  Gère l’accès aux données :
  - chargement du fichier `Etudiants.csv`
  - stockage des étudiants
  - gestion des statuts (étranger, boursier, admis)
  - remplacement des étudiants admis qui se désistent

 Notions C# utilisées

-Énumérations simples
Utilisées pour représenter les mentions.

-Énumérations avec `[Flags]`
Utilisées pour représenter plusieurs statuts simultanés pour un étudiant :
- Étranger
- Boursier
- Admis


