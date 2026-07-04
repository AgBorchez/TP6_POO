using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EjercicioNum6.Formularios
{
    public partial class FormCargarDeposito : Form
    {
        private Reserva reserva;

        public Reserva Reserva
        {
            get { return reserva; }
            set { reserva = value; }
        }

        private Hotel hotel;

        public Hotel Hotel
        {
            get { return hotel; }
            set { hotel = value; }
        }
        public FormCargarDeposito()
        {
            InitializeComponent();
        }

        private void FormCargarDeposito_Load(object sender, EventArgs e)
        {
            label1.Text = $"El deposito minimo debe ser de {(reserva.CalcularValorHospedaje()*10)/100:F2}";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textboxNumerica1.ToFloat(out float deposito, "deposito")) 
            {
                if (reserva.PagarValorDeposito(deposito)) 
                { 
                    this.DialogResult = DialogResult.OK;
                    Close();
                }
            }
        }
    }
}
