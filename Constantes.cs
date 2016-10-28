using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NetworkDesigner
{
    public static class Constantes
    {
        public const float MARGE_TRAIT_DROIT = 25f;
        public const float MARGE_SELECTION = 5f;

        static public void EnumToListBox(Type EnumType, ComboBox pListe)
        {
            Array Values = System.Enum.GetValues(EnumType);

            foreach (int Value in Values)
            {
                var nom = Enum.GetName(EnumType, Value);
                var couleur = System.Drawing.Color.FromName(nom);

                if (couleur.IsSystemColor == true)
                    continue;

                Couleur item = new Couleur(nom, couleur);

                pListe.Items.Add(item);
            }
        }

        public enum PosRedim
        {
            Aucune,
            TraitDebut,
            TraitFin,
            RectangleOrigine,
            RectangleOppose,
        }
    }

    public class Couleur
    {
        public string Nom { get; set; }
        public System.Drawing.Color Valeur { get; set; }

        public Couleur(string pNom, System.Drawing.Color pCouleur)
        {
            Nom = pNom;
            Valeur = pCouleur;
        }

        public override string ToString()
        {
            return Nom;
        }

        public override bool Equals(object obj)
        {
            var item = obj as Couleur;

            if (item == null)
                return false;

            return this.Nom == item.Nom;
        }

        public override int GetHashCode()
        {
            return this.Nom.GetHashCode();
        }
    }
}
