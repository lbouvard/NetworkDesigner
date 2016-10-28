using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetworkDesigner
{
    [Serializable]
    public class Trait : Item
    {
        private Point _depart;
        private Point _fin;

        public Point Depart
        {
            get { return _depart; }
            set
            {
                _depart = value;
                MiseAJourGripExtremite();  
            }
        }

        public Point Fin
        {
            get { return _fin; }
            set
            {
                _fin = value;
                MiseAJourGripExtremite();
            }
        }

        public Trait(string pId, Point pDepart, Point pFin, Color pCouleur, float pLargeur)
            : base(pId, pCouleur, pLargeur)
        {
            Depart = pDepart;
            Fin = pFin;     
        }

        public override void MiseAJourGripExtremite()
        {
            DimensionsModifiable.Clear();

            DimensionsModifiable.Add(new Rectangle(_depart.X - 5, _depart.Y - 5, 10, 10));
            DimensionsModifiable.Add(new Rectangle(_fin.X - 5, _fin.Y - 5, 10, 10));
        }

        public override void Dessiner(Graphics g)
        {
            using (Pen stylo = new Pen(CouleurLigne, LargeurLigne))
            {
                g.DrawLine(stylo, Depart, Fin);

                if( EstSelectionne )
                {
                    g.FillEllipse(new SolidBrush(Color.Red), DimensionsModifiable.ElementAt(0));
                    g.FillEllipse(new SolidBrush(Color.Red), DimensionsModifiable.ElementAt(1));
                }                
            }
        }

        public override bool HitTest(Point pPoint)
        {
            //// test si on est a l'extérieur d'un trait
            //if (pPoint.X < Depart.X && pPoint.X < Fin.X ||
            //    pPoint.X > Depart.X && pPoint.X > Fin.X ||
            //    pPoint.Y < Depart.Y && pPoint.Y < Fin.Y ||
            //    pPoint.Y > Depart.Y && pPoint.Y > Fin.Y)
            //    return false;

            //float dy = Fin.Y - Depart.Y;
            //float dx = Fin.X - Depart.X;
            //float Z = dy * pPoint.X - dx * pPoint.Y + Depart.Y * Fin.X - Depart.X * Fin.Y;
            //float N = dy * dy + dx * dx;

            //float dist = (float)(Math.Abs(Z) / Math.Sqrt(N));

            //Console.WriteLine("Ecart : " + dist.ToString());
            //return dist < LargeurLigne;

            //Méthode 2
            if (Depart.X == Fin.X)      //Trait vertical
            {
                var area = new Rectangle((int)(Depart.X - Constantes.MARGE_SELECTION),
                                                Depart.Y > Fin.Y ? (int)(Fin.Y - Constantes.MARGE_SELECTION) : (int)(Depart.Y - Constantes.MARGE_SELECTION),
                                                (int)(2 * Constantes.MARGE_SELECTION),
                                                (int)Math.Abs(Fin.Y - Depart.Y) + 10);

                return area.Contains(pPoint);
            }

            if (Depart.Y == Fin.Y)      //Trait horizontal
            {
                var area = new Rectangle(Depart.X > Fin.X ? (int)(Fin.X - Constantes.MARGE_SELECTION) : (int)(Depart.X - Constantes.MARGE_SELECTION),
                                            (int)(Depart.Y - Constantes.MARGE_SELECTION),
                                            (int)Math.Abs(Fin.X - Depart.X) + 10,
                                            (int)(2 * Constantes.MARGE_SELECTION));

                return area.Contains(pPoint);
            }

            return false;
        }

        public override Constantes.PosRedim SelectionnerExtremite(Point pPoint)
        {
            if( DimensionsModifiable.ElementAt(0).Contains(pPoint) )
            {
                return Constantes.PosRedim.TraitDebut;
            }

            if( DimensionsModifiable.ElementAt(1).Contains(pPoint) )
            {
                return Constantes.PosRedim.TraitFin;
            }

            return Constantes.PosRedim.Aucune;
        }

        public override void Translater(int dx, int dy)
        {
            var depart = new Point(Depart.X, Depart.Y);
            depart.Offset(dx, dy);

            var fin = new Point(Fin.X, Fin.Y);
            fin.Offset(dx, dy);

            Depart = depart;
            Fin = fin;
        }
    }
}
