using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetworkDesigner
{
    public class Item
    {
        public bool EstSelectionne { get; set; }
        public Color CouleurLigne { get; set; }
        public float LargeurLigne { get; set; }

        /*public int OrigineCurseurX { get; set; }
        public int OrigineCurseurY { get; set; }*/

        public List<Rectangle> DimensionsModifiable { get; set; }

        public string ID { get; set; }

        public Item(string pID, Color pCouleur, float pLargeur)
        {
            ID = pID;
            CouleurLigne = pCouleur;
            LargeurLigne = pLargeur;
            EstSelectionne = false;

            DimensionsModifiable = new List<Rectangle>();
        }

        public virtual void MiseAJourGripExtremite()
        {
            return;
        }

        public virtual void Dessiner(Graphics g)
        {
            return;
        }

        public virtual bool HitTest(Point pPoint)
        {
            return false;
        }

        public virtual Constantes.PosRedim SelectionnerExtremite(Point pPoint)
        {
            return Constantes.PosRedim.Aucune;
        }

        public virtual void Translater(int dx, int dy)
        {
            return;
        }
    }
}
