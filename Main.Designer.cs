namespace NetworkDesigner
{
    partial class Main
    {
        /// <summary>
        /// Variable nécessaire au concepteur.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Nettoyage des ressources utilisées.
        /// </summary>
        /// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Code généré par le Concepteur Windows Form

        /// <summary>
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            this.pnlBoard = new System.Windows.Forms.Panel();
            this.btnMain = new System.Windows.Forms.Button();
            this.btnTrait = new System.Windows.Forms.Button();
            this.btnRect = new System.Windows.Forms.Button();
            this.lblTrack = new System.Windows.Forms.Label();
            this.btnFerme = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.btnNouveau = new System.Windows.Forms.Button();
            this.nudLargeur = new System.Windows.Forms.NumericUpDown();
            this.cmbCouleur = new System.Windows.Forms.ComboBox();
            this.txtWidth = new System.Windows.Forms.TextBox();
            this.txtHeight = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblX = new System.Windows.Forms.Label();
            this.lblY = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.nudLargeur)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlBoard
            // 
            this.pnlBoard.BackColor = System.Drawing.SystemColors.Info;
            this.pnlBoard.Location = new System.Drawing.Point(16, 64);
            this.pnlBoard.Margin = new System.Windows.Forms.Padding(4);
            this.pnlBoard.Name = "pnlBoard";
            this.pnlBoard.Size = new System.Drawing.Size(1129, 656);
            this.pnlBoard.TabIndex = 0;
            this.pnlBoard.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlBoard_Paint);
            this.pnlBoard.MouseClick += new System.Windows.Forms.MouseEventHandler(this.pnlBoard_Click);
            this.pnlBoard.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pnlBoard_MouseDown);
            this.pnlBoard.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pnlBoard_Move);
            this.pnlBoard.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pnlBoard_MouseUp);
            // 
            // btnMain
            // 
            this.btnMain.Location = new System.Drawing.Point(16, 15);
            this.btnMain.Margin = new System.Windows.Forms.Padding(4);
            this.btnMain.Name = "btnMain";
            this.btnMain.Size = new System.Drawing.Size(48, 42);
            this.btnMain.TabIndex = 1;
            this.btnMain.Text = "Sel";
            this.btnMain.UseVisualStyleBackColor = true;
            this.btnMain.Click += new System.EventHandler(this.btnMain_Click);
            // 
            // btnTrait
            // 
            this.btnTrait.Location = new System.Drawing.Point(72, 15);
            this.btnTrait.Margin = new System.Windows.Forms.Padding(4);
            this.btnTrait.Name = "btnTrait";
            this.btnTrait.Size = new System.Drawing.Size(48, 42);
            this.btnTrait.TabIndex = 2;
            this.btnTrait.Text = "/";
            this.btnTrait.UseVisualStyleBackColor = true;
            this.btnTrait.Click += new System.EventHandler(this.btnTrait_Click);
            // 
            // btnRect
            // 
            this.btnRect.Location = new System.Drawing.Point(128, 15);
            this.btnRect.Margin = new System.Windows.Forms.Padding(4);
            this.btnRect.Name = "btnRect";
            this.btnRect.Size = new System.Drawing.Size(48, 42);
            this.btnRect.TabIndex = 3;
            this.btnRect.Text = "Rct";
            this.btnRect.UseVisualStyleBackColor = true;
            this.btnRect.Click += new System.EventHandler(this.btnRect_Click);
            // 
            // lblTrack
            // 
            this.lblTrack.AutoSize = true;
            this.lblTrack.Location = new System.Drawing.Point(1037, 28);
            this.lblTrack.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTrack.Name = "lblTrack";
            this.lblTrack.Size = new System.Drawing.Size(0, 17);
            this.lblTrack.TabIndex = 4;
            // 
            // btnFerme
            // 
            this.btnFerme.Location = new System.Drawing.Point(969, 727);
            this.btnFerme.Margin = new System.Windows.Forms.Padding(4);
            this.btnFerme.Name = "btnFerme";
            this.btnFerme.Size = new System.Drawing.Size(176, 42);
            this.btnFerme.TabIndex = 5;
            this.btnFerme.Text = "Fermer";
            this.btnFerme.UseVisualStyleBackColor = true;
            this.btnFerme.Click += new System.EventHandler(this.btnFerme_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(785, 727);
            this.button1.Margin = new System.Windows.Forms.Padding(4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(176, 42);
            this.button1.TabIndex = 6;
            this.button1.Text = "Enregistrer";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // btnNouveau
            // 
            this.btnNouveau.Location = new System.Drawing.Point(601, 727);
            this.btnNouveau.Margin = new System.Windows.Forms.Padding(4);
            this.btnNouveau.Name = "btnNouveau";
            this.btnNouveau.Size = new System.Drawing.Size(176, 42);
            this.btnNouveau.TabIndex = 7;
            this.btnNouveau.Text = "Nouveau";
            this.btnNouveau.UseVisualStyleBackColor = true;
            this.btnNouveau.Click += new System.EventHandler(this.btnNouveau_Click);
            // 
            // nudLargeur
            // 
            this.nudLargeur.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nudLargeur.Increment = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.nudLargeur.Location = new System.Drawing.Point(455, 22);
            this.nudLargeur.Margin = new System.Windows.Forms.Padding(4);
            this.nudLargeur.Name = "nudLargeur";
            this.nudLargeur.Size = new System.Drawing.Size(53, 26);
            this.nudLargeur.TabIndex = 12;
            this.nudLargeur.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
            // 
            // cmbCouleur
            // 
            this.cmbCouleur.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbCouleur.FormattingEnabled = true;
            this.cmbCouleur.Location = new System.Drawing.Point(187, 21);
            this.cmbCouleur.Margin = new System.Windows.Forms.Padding(4);
            this.cmbCouleur.Name = "cmbCouleur";
            this.cmbCouleur.Size = new System.Drawing.Size(259, 28);
            this.cmbCouleur.TabIndex = 13;
            // 
            // txtWidth
            // 
            this.txtWidth.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtWidth.Location = new System.Drawing.Point(521, 22);
            this.txtWidth.Margin = new System.Windows.Forms.Padding(4);
            this.txtWidth.Name = "txtWidth";
            this.txtWidth.Size = new System.Drawing.Size(88, 26);
            this.txtWidth.TabIndex = 14;
            this.txtWidth.Text = "100";
            this.txtWidth.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtHeight
            // 
            this.txtHeight.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtHeight.Location = new System.Drawing.Point(619, 22);
            this.txtHeight.Margin = new System.Windows.Forms.Padding(4);
            this.txtHeight.Name = "txtHeight";
            this.txtHeight.Size = new System.Drawing.Size(88, 26);
            this.txtHeight.TabIndex = 15;
            this.txtHeight.Text = "50";
            this.txtHeight.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 737);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(30, 20);
            this.label1.TabIndex = 16;
            this.label1.Text = "X :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(90, 737);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 20);
            this.label2.TabIndex = 17;
            this.label2.Text = "Y :";
            // 
            // lblX
            // 
            this.lblX.AutoSize = true;
            this.lblX.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblX.Location = new System.Drawing.Point(48, 737);
            this.lblX.Name = "lblX";
            this.lblX.Size = new System.Drawing.Size(0, 20);
            this.lblX.TabIndex = 18;
            // 
            // lblY
            // 
            this.lblY.AutoSize = true;
            this.lblY.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblY.Location = new System.Drawing.Point(125, 737);
            this.lblY.Name = "lblY";
            this.lblY.Size = new System.Drawing.Size(0, 20);
            this.lblY.TabIndex = 19;
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1161, 773);
            this.Controls.Add(this.lblY);
            this.Controls.Add(this.lblX);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtHeight);
            this.Controls.Add(this.txtWidth);
            this.Controls.Add(this.cmbCouleur);
            this.Controls.Add(this.nudLargeur);
            this.Controls.Add(this.btnNouveau);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btnFerme);
            this.Controls.Add(this.lblTrack);
            this.Controls.Add(this.btnRect);
            this.Controls.Add(this.btnTrait);
            this.Controls.Add(this.btnMain);
            this.Controls.Add(this.pnlBoard);
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Main";
            this.Text = "MaintenanceDesigner";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyUp);
            ((System.ComponentModel.ISupportInitialize)(this.nudLargeur)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel pnlBoard;
        private System.Windows.Forms.Button btnMain;
        private System.Windows.Forms.Button btnTrait;
        private System.Windows.Forms.Button btnRect;
        private System.Windows.Forms.Label lblTrack;
        private System.Windows.Forms.Button btnFerme;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btnNouveau;
        private System.Windows.Forms.NumericUpDown nudLargeur;
        private System.Windows.Forms.ComboBox cmbCouleur;
        private System.Windows.Forms.TextBox txtWidth;
        private System.Windows.Forms.TextBox txtHeight;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblX;
        private System.Windows.Forms.Label lblY;
    }
}