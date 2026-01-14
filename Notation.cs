using System;

namespace Concours
{
    // 1) Enumération des mentions
    public enum Mention
    {
        Echec,
        Passable,
        AssezBien,
        Bien,
        TresBien
    }

    public class Notation
    {
        // 2) Libellés associés aux mentions
        static string[] libelles =
        {
            "Echec",
            "Passable",
            "Assez bien",
            "Bien",
            "Très bien"
        };

        // 3) Méthode demandée par le prof
        public static (Mention mention, string libelle) GetMention(double note)
        {
            Mention m;

            if (note < 10)
                m = Mention.Echec;
            else if (note < 12)
                m = Mention.Passable;
            else if (note < 14)
                m = Mention.AssezBien;
            else if (note < 16)
                m = Mention.Bien;
            else
                m = Mention.TresBien;

            return (m, libelles[(int)m]);
        }
    }
}
