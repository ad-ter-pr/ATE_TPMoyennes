using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HNI_TPmoyennes
{
    class Classe
    {
        public string nomClasse { get; set; }
        public List<Eleve> eleves { get; set; }
        public List<string> matieres { get; set; }
        public List<float> moyennesClasse { get; set; }

        public const int NBMAXELEVES = 30;
        public const int NBMAXMATIERES = 10;

        public Classe(string nomClasse)
        {
            this.nomClasse = nomClasse;
            eleves = new List<Eleve>();
            matieres = new List<string>();
            moyennesClasse = new List<float>();

        }

        public void ajouterEleve(string prenom, string nom)
        {
            if (eleves.Count < NBMAXELEVES)
            {
                eleves.Add(new Eleve(prenom, nom));
            }
            else
            {
                Console.WriteLine($"Le nombre d'élèves de cette classe dépasse {NBMAXELEVES}.");
            }
        }

        public void ajouterMatiere(string nomMatiere)
        {
            if (matieres.Count < NBMAXMATIERES)
            {
                matieres.Add(nomMatiere);
            }
            else
            {
                Console.WriteLine($"Le nombre de matières de cette classe dépasse {NBMAXMATIERES}");
            }
        }

        // Calcul de la moyenne de la classe par matière
        public float moyenneMatiere(int numMatiere)
        {
            // Récupérer les moyennes des élèves dans la matière indiquée
            var moyennesEleves = new List<float>();
            foreach (Eleve eleve in eleves)
            {
                moyennesEleves.Add(eleve.moyenneMatiere(numMatiere));
            }
            return (float)Math.Truncate(moyennesEleves.Average() * 100) / 100;
        }

        // Calcul de la moyenne générale de la classe
        public float moyenneGeneral()
        {
            // Ajouter à la collection des moyennes d'une classe la moyenne dans chaque matière
            for (int i = 0; i < matieres.Count; i++)
            {
                moyennesClasse.Add(moyenneMatiere(i));
            }
            return (float)Math.Truncate(moyennesClasse.Average() * 100) / 100;
        }
    }
}
