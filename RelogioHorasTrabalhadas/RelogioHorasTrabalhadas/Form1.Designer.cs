namespace RelogioHorasTrabalhadas
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.label1 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.primeiroResultado = new System.Windows.Forms.Label();
            this.mskBPrimeiraEntrada = new System.Windows.Forms.MaskedTextBox();
            this.mskBPrimeiraSaida = new System.Windows.Forms.MaskedTextBox();
            this.mskBSegundaEntrada = new System.Windows.Forms.MaskedTextBox();
            this.mskBSegundaSaida = new System.Windows.Forms.MaskedTextBox();
            this.resultadoTotal = new System.Windows.Forms.Label();
            this.lbBemVindo = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 92);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(94, 15);
            this.label1.TabIndex = 1;
            this.label1.Text = "primeira entrada";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(222, 89);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(96, 15);
            this.label6.TabIndex = 6;
            this.label6.Text = "Segunda entrada";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(327, 89);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(84, 15);
            this.label9.TabIndex = 13;
            this.label9.Text = "Segunda Saída";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(121, 92);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(82, 15);
            this.label14.TabIndex = 8;
            this.label14.Text = "primeira Saída";
            // 
            // primeiroResultado
            // 
            this.primeiroResultado.AccessibleName = "primeiroResultado";
            this.primeiroResultado.AutoSize = true;
            this.primeiroResultado.Location = new System.Drawing.Point(561, 113);
            this.primeiroResultado.Name = "primeiroResultado";
            this.primeiroResultado.Size = new System.Drawing.Size(13, 15);
            this.primeiroResultado.TabIndex = 33;
            this.primeiroResultado.Text = "0";
            this.primeiroResultado.Click += new System.EventHandler(this.primeiroResultado_Click);
            // 
            // mskBPrimeiraEntrada
            // 
            this.mskBPrimeiraEntrada.Location = new System.Drawing.Point(12, 110);
            this.mskBPrimeiraEntrada.Mask = "00:00";
            this.mskBPrimeiraEntrada.Name = "mskBPrimeiraEntrada";
            this.mskBPrimeiraEntrada.Size = new System.Drawing.Size(87, 23);
            this.mskBPrimeiraEntrada.TabIndex = 37;
            this.mskBPrimeiraEntrada.ValidatingType = typeof(System.DateTime);
            // 
            // mskBPrimeiraSaida
            // 
            this.mskBPrimeiraSaida.Location = new System.Drawing.Point(116, 110);
            this.mskBPrimeiraSaida.Mask = "00:00";
            this.mskBPrimeiraSaida.Name = "mskBPrimeiraSaida";
            this.mskBPrimeiraSaida.Size = new System.Drawing.Size(87, 23);
            this.mskBPrimeiraSaida.TabIndex = 38;
            this.mskBPrimeiraSaida.ValidatingType = typeof(System.DateTime);
            // 
            // mskBSegundaEntrada
            // 
            this.mskBSegundaEntrada.Location = new System.Drawing.Point(222, 110);
            this.mskBSegundaEntrada.Mask = "00:00";
            this.mskBSegundaEntrada.Name = "mskBSegundaEntrada";
            this.mskBSegundaEntrada.Size = new System.Drawing.Size(87, 23);
            this.mskBSegundaEntrada.TabIndex = 39;
            this.mskBSegundaEntrada.ValidatingType = typeof(System.DateTime);
            // 
            // mskBSegundaSaida
            // 
            this.mskBSegundaSaida.Location = new System.Drawing.Point(327, 110);
            this.mskBSegundaSaida.Mask = "00:00";
            this.mskBSegundaSaida.Name = "mskBSegundaSaida";
            this.mskBSegundaSaida.Size = new System.Drawing.Size(87, 23);
            this.mskBSegundaSaida.TabIndex = 40;
            this.mskBSegundaSaida.ValidatingType = typeof(System.DateTime);
            // 
            // resultadoTotal
            // 
            this.resultadoTotal.AutoSize = true;
            this.resultadoTotal.Location = new System.Drawing.Point(596, 58);
            this.resultadoTotal.Name = "resultadoTotal";
            this.resultadoTotal.Size = new System.Drawing.Size(87, 15);
            this.resultadoTotal.TabIndex = 54;
            this.resultadoTotal.Text = "Resultado Total";
            // 
            // lbBemVindo
            // 
            this.lbBemVindo.AutoSize = true;
            this.lbBemVindo.Location = new System.Drawing.Point(12, 21);
            this.lbBemVindo.Name = "lbBemVindo";
            this.lbBemVindo.Size = new System.Drawing.Size(84, 15);
            this.lbBemVindo.TabIndex = 55;
            this.lbBemVindo.Text = "Bem vindo(a): ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(438, 113);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(117, 15);
            this.label2.TabIndex = 56;
            this.label2.Text = "Hoje você trabalhou:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(621, 113);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(38, 15);
            this.label3.TabIndex = 57;
            this.label3.Text = "Horas";
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(718, 203);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lbBemVindo);
            this.Controls.Add(this.resultadoTotal);
            this.Controls.Add(this.mskBSegundaSaida);
            this.Controls.Add(this.mskBSegundaEntrada);
            this.Controls.Add(this.mskBPrimeiraSaida);
            this.Controls.Add(this.mskBPrimeiraEntrada);
            this.Controls.Add(this.primeiroResultado);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label label1;
        private Label label6;
        private Label label9;
        private Label label14;
        private Label primeiroResultado;
        private MaskedTextBox mskBPrimeiraEntrada;
        private MaskedTextBox mskBPrimeiraSaida;
        private MaskedTextBox mskBSegundaEntrada;
        private MaskedTextBox mskBSegundaSaida;
        private Label resultadoTotal;
        private Label lbBemVindo;
        private Label label2;
        private Label label3;
        private System.Windows.Forms.Timer timer1;
    }
}