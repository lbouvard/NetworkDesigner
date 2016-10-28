using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetworkDesigner
{
    [Serializable]
    public class Equipement : Item
    {
        public Point Origine { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }

        public string Nom { get; set; }
        public string Adresse { get; set; }

        public Equipement(String pId, Point pOrigine, int pWidth, int pHeight, Color pCouleur, float pLargeur)
            : base(pId, pCouleur, pLargeur)
        {
            Origine = pOrigine;
            Width = pWidth;
            Height = pHeight;
        }

        public override void Dessiner(Graphics g)
        {
            using (Pen stylo = new Pen(CouleurLigne, LargeurLigne))
            {
                var points = new Point[] 
                { 
                    Origine, 
                    new Point(Origine.X + Width, Origine.Y), 
                    new Point(Origine.X + Width, Origine.Y + Height), 
                    new Point(Origine.X, Origine.Y + Height) 
                };

                g.DrawPolygon(stylo, points);
            }
        }

        public override bool HitTest(Point pPoint)
        {
            Rectangle area = new Rectangle(Origine, new Size(Width, Height));

            return area.Contains(pPoint);
        }
    }
}
