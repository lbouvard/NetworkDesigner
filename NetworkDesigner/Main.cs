using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NetworkDesigner
{
    public partial class Main : Form
    {
        private readonly SynchronizationContext synchronizationContext;

        //root
        public List<Item> Dessin { get; set; }

        public int ItemEnCours { get; set; }
        public int NbClic { get; set; }
        public Outils OutilEnCours { get; set; }

        public bool Ajout { get; set; }
        public bool TraceEnCours { get; set; }
        public bool DeplacementAutorise { get; set; }

        public bool RedimensionnementAutorise { get; set; }
        public Constantes.PosRedim RedimEnCours { get; set; }

        public enum Outils
        {
            Main,
            Trait,
            Case
        }

        public int EcartX { get; set; }
        public int EcartY { get; set; }
        public int Entete { get; set; }
        public int Bord { get; set; }

        public System.Threading.Timer debug;

        private Item _maitre = null;
        private Point _positionSouris = new Point();

        public Main()
        {
            InitializeComponent();

            synchronizationContext = SynchronizationContext.Current;
            //this.DoubleBuffered = true;
            //this.SetStyle(
            //    ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer | ControlStyles.UserPaint, true);

            typeof(Panel).InvokeMember("DoubleBuffered",
                System.Reflection.BindingFlags.SetProperty | System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic,
                null, pnlBoard, new object[] { true });
        }

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            if (TraceEnCours)
            {
                if (e.KeyValue == (int)Keys.Escape)
                {
                    TraceEnCours = false;
                    NbClic = 0;
                    Dessin.RemoveAt(ItemEnCours--);
                    pnlBoard.Refresh();
                }
                else if (e.KeyValue == (int)Keys.Enter)
                {
                    TracerDroit(ItemEnCours);
                    TraceEnCours = false;
                    NbClic = 0;
                }
            }

            if (e.KeyValue == (int)Keys.Delete)
            {
                Dessin.RemoveAll(t => t.EstSelectionne);
                ItemEnCours = Dessin.Count() - 1;
                NbClic = 0;
                pnlBoard.Refresh();
            }

            Ajout = e.Control;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            NbClic = 0;
            Dessin = new List<Item>();
            ItemEnCours = -1;

            OutilEnCours = Outils.Main;

            Bord = (this.Width - this.ClientSize.Width) / 2;
            Entete = this.Height - this.ClientSize.Height - Bord;

            EcartX = this.Location.X + pnlBoard.Location.X + Bord;
            EcartY = this.Location.Y + pnlBoard.Location.Y + Entete;

            Constantes.EnumToListBox(typeof(KnownColor), cmbCouleur);

            cmbCouleur.SelectedIndex = cmbCouleur.Items.IndexOf(new Couleur("Black", Color.Black));

            DeplacementAutorise = false;
            RedimensionnementAutorise = false;
        }

        private void pnlBoard_Click(object sender, MouseEventArgs e)
        {
            #region Trace d'un trait
            if (OutilEnCours == Outils.Trait)
            {
                NbClic++;

                var trait = new Trait(string.Format("Trait{0}", Dessin.Where(i => i is Trait).Count() + 1), e.Location, new Point(), ((Couleur)cmbCouleur.SelectedItem).Valeur, (float)nudLargeur.Value);

                if (NbClic == 1)
                    TraceEnCours = true;
                else
                {
                    TraceEnCours = false;

                    TracerDroit(ItemEnCours);

                    var traitEnCours = Dessin.ElementAt(ItemEnCours) as Trait;
                    trait.Depart = new Point(traitEnCours.Fin.X - (int)(nudLargeur.Value / 2), traitEnCours.Fin.Y);

                    TraceEnCours = true; 
                }

                Dessin.Add(trait);
                ItemEnCours++;
            }
            #endregion

            #region Selection
            if (OutilEnCours == Outils.Main && !DeplacementAutorise && !RedimensionnementAutorise)
            {
                foreach (var item in Dessin)
                {
                    if (Ajout)
                    {
                        if (item.HitTest(e.Location))
                        {
                            if (item.EstSelectionne)
                            {
                                item.EstSelectionne = false;
                                item.CouleurLigne = ((Couleur)cmbCouleur.SelectedItem).Valeur;
                            }
                            else
                            {
                                item.EstSelectionne = true;
                                item.CouleurLigne = Color.Red;
                            }
                        }
                    }
                    else
                    {
                        if (item.HitTest(e.Location))
                        {
                            item.CouleurLigne = Color.Red;
                            item.EstSelectionne = true;
                        }
                        else
                        {
                            item.CouleurLigne = ((Couleur)cmbCouleur.SelectedItem).Valeur;
                            item.EstSelectionne = false;
                        }
                    }
                }

                pnlBoard.Invalidate();
            }
            #endregion

            #region Trace Equipement
            if (OutilEnCours == Outils.Case)
            {
                var width = int.Parse(txtWidth.Text);
                var height = int.Parse(txtHeight.Text);

                var equipement = new Equipement(
                    string.Format("Rectangle{0}", Dessin.Where(i => i is Equipement).Count() + 1),
                    new Point(e.Location.X - (width / 2), e.Location.Y - (height / 2)),
                    width,
                    height,
                    ((Couleur)cmbCouleur.SelectedItem).Valeur,
                    (float)nudLargeur.Value
                );

                Dessin.Add(equipement);
                ItemEnCours++;

                pnlBoard.Invalidate();
            }
            #endregion
        }

        private async void pnlBoard_Move(object sender, MouseEventArgs e)
        {
            UpdateUI(e.Location.X, e.Location.Y);

            await Task.Run(() =>
            {
                #region TRACE
                if (TraceEnCours)
                {
                    var item = Dessin.ElementAt(ItemEnCours) as Trait;
                    item.Fin = e.Location;
                }
                #endregion

                #region DEPLACEMENT
                if (DeplacementAutorise)
                {
                    // Valeur de déplacement
                    int dx = e.Location.X - _positionSouris.X;
                    int dy = e.Location.Y - _positionSouris.Y;

                    // Nouvelle position souris
                    _positionSouris = e.Location;

                    // Déplace tous les élements selectionnés
                    var items = Dessin.Where(i => i.EstSelectionne).ToList();

                    foreach( var item in items)
                    {
                        item.Translater(dx, dy);
                    }
                }
                #endregion

                #region REDIMENSIONNEMENT
                if ( RedimensionnementAutorise)
                {
                    // Trait
                    if( _maitre is Trait )
                    {
                        var item = _maitre as Trait;
                        // Horizontal
                        if (item.Depart.Y == item.Fin.Y)
                        {
                            if (RedimEnCours == Constantes.PosRedim.TraitDebut)
                                item.Depart = new Point(e.Location.X, item.Depart.Y);
                            else
                                item.Fin = new Point(e.Location.X, item.Fin.Y);
                        }
                        //Trait vertical
                        else
                        {
                            if (RedimEnCours == Constantes.PosRedim.TraitDebut)
                                item.Depart = new Point(item.Depart.X, e.Location.Y);
                            else
                                item.Fin = new Point(item.Fin.X, e.Location.Y);
                        }
                    }
                    // Equipement
                    else
                    {

                    }
                }
                #endregion

                // Mise à jour de l'affichage
                pnlBoard.Invalidate();
            });
        }

        private void pnlBoard_Paint(object sender, PaintEventArgs e)
        {
            foreach (var item in Dessin)
                item.Dessiner(e.Graphics);
        }

        protected override void DefWndProc(ref Message m)
        {
            if (m.Msg == 0x47)  //WM_WINDOWPOSCHANGED
            {
                this.Invalidate();
            }

            base.DefWndProc(ref m);
        }

        private void btnFerme_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnNouveau_Click(object sender, EventArgs e)
        {
            Dessin.Clear();
            ItemEnCours = -1;
            pnlBoard.Invalidate();

            OutilEnCours = Outils.Main;
        }

        private void btnMain_Click(object sender, EventArgs e)
        {
            OutilEnCours = Outils.Main;
        }

        private void btnTrait_Click(object sender, EventArgs e)
        {
            OutilEnCours = Outils.Trait;
        }

        private void btnRect_Click(object sender, EventArgs e)
        {
            OutilEnCours = Outils.Case;
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            Ajout = e.Control;
        }

        private void TracerDroit(int pElement)
        {
            var dernierTrait = Dessin.ElementAt(pElement) as Trait;

            //Vertical
            if (dernierTrait.Fin.X > (dernierTrait.Depart.X - Constantes.MARGE_TRAIT_DROIT) && dernierTrait.Fin.X < (dernierTrait.Depart.X + Constantes.MARGE_TRAIT_DROIT))
            {
                dernierTrait.Fin = new Point(dernierTrait.Depart.X, dernierTrait.Fin.Y);
                Cursor.Position = new Point(dernierTrait.Depart.X + EcartX, Cursor.Position.Y);
            }

            //Horizontal
            if (dernierTrait.Fin.Y < (dernierTrait.Depart.Y + Constantes.MARGE_TRAIT_DROIT) && dernierTrait.Fin.Y > (dernierTrait.Depart.Y - Constantes.MARGE_TRAIT_DROIT))
            {
                dernierTrait.Fin = new Point(dernierTrait.Fin.X, dernierTrait.Depart.Y);
                Cursor.Position = new Point(Cursor.Position.X, dernierTrait.Depart.Y + EcartY);
            }

            pnlBoard.Invalidate(); //modif refresh to invalidate
        }

        private void pnlBoard_MouseDown(object sender, MouseEventArgs e)
        {
            var nbItemSelectionne = Dessin.Where(i => i.EstSelectionne).Count();
            var itemEnCours = Dessin.Where(i => i.EstSelectionne && i is Trait && i.HitTest(e.Location)).FirstOrDefault();

            if (nbItemSelectionne == 0 || itemEnCours == null)
                return;

            _maitre = itemEnCours;

            if (nbItemSelectionne == 1)
            {
                //Dimensionnement ?
                if( itemEnCours.SelectionnerExtremite(e.Location) != Constantes.PosRedim.Aucune )
                {
                    RedimEnCours = itemEnCours.SelectionnerExtremite(e.Location);
                    RedimensionnementAutorise = true;
                }
                //Déplacement
                else
                {
                    _positionSouris = e.Location;
                    DeplacementAutorise = true;
                }
            }
            else
            {
                //Déplacement
                _positionSouris = e.Location;
                DeplacementAutorise = true;
            }            
        }

        private void pnlBoard_MouseUp(object sender, MouseEventArgs e)
        {
            if (DeplacementAutorise)
                DeplacementAutorise = false;

            if (RedimensionnementAutorise)
                RedimensionnementAutorise = false;
        }

        public void UpdateUI(int valueX, int valueY)
        {
            synchronizationContext.Post(new SendOrPostCallback(o =>
            {
                lblX.Text = ((int)o).ToString();
            }), valueX);

            synchronizationContext.Post(new SendOrPostCallback(o =>
            {
                lblY.Text = ((int)o).ToString();
            }), valueY);
        }
    }
}