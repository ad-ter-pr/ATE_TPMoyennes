using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HNI_TPmoyennes
{
    class Eleve
    {
        public string prenom { get; }
        public string nom { get; }
        public List<Note> notes { get; }
        public List<float> moyennes { get; set; }

        public const int NBMAXNOTES = 200;

        public Eleve(string prenom, string nom)
        {
            this.prenom = prenom;
            this.nom = nom;
            notes = new List<Note>();
            moyennes = new List<float>();
        }

        public void ajouterNote(Note note)
        {
            if (notes.Count <  NBMAXNOTES)
            {
                notes.Add(note);
            }
            else
            {
                Console.WriteLine($"Le nombre de notes dépasse {NBMAXNOTES}, l'élève est trop fatigué.");
            }
        }

        // Calcul de la moyenne de l'élève par matière
        public float moyenneMatiere(int numMatiere)
        {
            // Récupérer les notes de l'élève dans la matière indiquée
            var notesMatiere = new List<Note>();
            foreach (Note note in notes)
            {
                if (note.matiere == numMatiere)
                {
                    notesMatiere.Add(note);
                }
            }
            return (float)Math.Truncate(notesMatiere.Average(n => n.note) * 100) / 100;
        }

        // Calcul de la moyenne générale d'un élève
        public float moyenneGeneral()
        {
            // Récupérer le nombre de matières
            int nombreMatieres = 0;
            foreach (Note note in notes)
            {
                if (note.matiere == nombreMatieres)
                {
                    nombreMatieres++;
                }
            }
            // Ajouter à la collection des moyennes d'un élève sa moyenne dans chaque matière
            for (int i = 0; i < nombreMatieres; i++)
            {
                moyennes.Add(moyenneMatiere(i));
            }
            return (float)Math.Truncate(moyennes.Average() * 100) / 100;
        }
    }
}
