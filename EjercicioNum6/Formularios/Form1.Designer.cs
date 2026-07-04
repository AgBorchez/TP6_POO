namespace EjercicioNum6
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.habitacionesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.artefactosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.integrantesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.monthCalendar1 = new System.Windows.Forms.MonthCalendar();
            this.labelPasajeroMasHospedado = new System.Windows.Forms.Label();
            this.labelRecaudacionTotal = new System.Windows.Forms.Label();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            this.button7 = new System.Windows.Forms.Button();
            this.button8 = new System.Windows.Forms.Button();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.habitacionesToolStripMenuItem,
            this.artefactosToolStripMenuItem,
            this.integrantesToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(9, 3, 0, 3);
            this.menuStrip1.Size = new System.Drawing.Size(1356, 31);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // habitacionesToolStripMenuItem
            // 
            this.habitacionesToolStripMenuItem.Name = "habitacionesToolStripMenuItem";
            this.habitacionesToolStripMenuItem.Size = new System.Drawing.Size(111, 25);
            this.habitacionesToolStripMenuItem.Text = "Habitaciones";
            this.habitacionesToolStripMenuItem.Click += new System.EventHandler(this.habitacionesToolStripMenuItem_Click);
            // 
            // artefactosToolStripMenuItem
            // 
            this.artefactosToolStripMenuItem.Name = "artefactosToolStripMenuItem";
            this.artefactosToolStripMenuItem.Size = new System.Drawing.Size(92, 25);
            this.artefactosToolStripMenuItem.Text = "Artefactos";
            this.artefactosToolStripMenuItem.Click += new System.EventHandler(this.artefactosToolStripMenuItem_Click);
            // 
            // integrantesToolStripMenuItem
            // 
            this.integrantesToolStripMenuItem.Name = "integrantesToolStripMenuItem";
            this.integrantesToolStripMenuItem.Size = new System.Drawing.Size(100, 25);
            this.integrantesToolStripMenuItem.Text = "Integrantes";
            this.integrantesToolStripMenuItem.Click += new System.EventHandler(this.integrantesToolStripMenuItem_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(649, 467);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(172, 52);
            this.button2.TabIndex = 7;
            this.button2.Text = "Cancelar Reserva";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(648, 409);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(172, 52);
            this.button1.TabIndex = 6;
            this.button1.Text = "Crear reserva";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(370, -28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(88, 24);
            this.label1.TabIndex = 5;
            this.label1.Text = "Reservas";
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.ItemHeight = 18;
            this.listBox1.Location = new System.Drawing.Point(13, 36);
            this.listBox1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(623, 598);
            this.listBox1.TabIndex = 4;
            this.listBox1.DoubleClick += new System.EventHandler(this.listBox1_DoubleClick);
            // 
            // monthCalendar1
            // 
            this.monthCalendar1.CalendarDimensions = new System.Drawing.Size(3, 1);
            this.monthCalendar1.Location = new System.Drawing.Point(649, 36);
            this.monthCalendar1.Name = "monthCalendar1";
            this.monthCalendar1.TabIndex = 8;
            // 
            // labelPasajeroMasHospedado
            // 
            this.labelPasajeroMasHospedado.AutoSize = true;
            this.labelPasajeroMasHospedado.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelPasajeroMasHospedado.Location = new System.Drawing.Point(941, 608);
            this.labelPasajeroMasHospedado.Name = "labelPasajeroMasHospedado";
            this.labelPasajeroMasHospedado.Size = new System.Drawing.Size(260, 25);
            this.labelPasajeroMasHospedado.TabIndex = 9;
            this.labelPasajeroMasHospedado.Text = "Pasajero Mas Hospedado";
            // 
            // labelRecaudacionTotal
            // 
            this.labelRecaudacionTotal.AutoSize = true;
            this.labelRecaudacionTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelRecaudacionTotal.Location = new System.Drawing.Point(941, 583);
            this.labelRecaudacionTotal.Name = "labelRecaudacionTotal";
            this.labelRecaudacionTotal.Size = new System.Drawing.Size(194, 25);
            this.labelRecaudacionTotal.TabIndex = 10;
            this.labelRecaudacionTotal.Text = "Recaudacion Hotel";
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(649, 225);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(168, 68);
            this.button3.TabIndex = 11;
            this.button3.Text = "Habitacion mas Ocupada por fecha";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(996, 225);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(168, 68);
            this.button4.TabIndex = 12;
            this.button4.Text = "Recaudacion Filtrada por fecha";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(649, 583);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(172, 52);
            this.button5.TabIndex = 13;
            this.button5.Text = "Registrar Checkout";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // button6
            // 
            this.button6.Location = new System.Drawing.Point(1170, 225);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(168, 68);
            this.button6.TabIndex = 14;
            this.button6.Text = "Habitacion mas solicitada por fecha";
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // button7
            // 
            this.button7.Location = new System.Drawing.Point(648, 525);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(172, 52);
            this.button7.TabIndex = 15;
            this.button7.Text = "Registrar Ocupacion Habitacion";
            this.button7.UseVisualStyleBackColor = true;
            this.button7.Click += new System.EventHandler(this.button7_Click);
            // 
            // button8
            // 
            this.button8.Location = new System.Drawing.Point(822, 225);
            this.button8.Name = "button8";
            this.button8.Size = new System.Drawing.Size(168, 68);
            this.button8.TabIndex = 16;
            this.button8.Text = "Habitacion mas Ocupada";
            this.button8.UseVisualStyleBackColor = true;
            this.button8.Click += new System.EventHandler(this.button8_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1356, 642);
            this.Controls.Add(this.button8);
            this.Controls.Add(this.button7);
            this.Controls.Add(this.button6);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.labelRecaudacionTotal);
            this.Controls.Add(this.labelPasajeroMasHospedado);
            this.Controls.Add(this.monthCalendar1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.menuStrip1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Form1";
            this.Text = "Metricas Hotel";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem habitacionesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem artefactosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem integrantesToolStripMenuItem;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.MonthCalendar monthCalendar1;
        private System.Windows.Forms.Label labelPasajeroMasHospedado;
        private System.Windows.Forms.Label labelRecaudacionTotal;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.Button button8;
    }
}

