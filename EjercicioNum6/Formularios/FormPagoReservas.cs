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
    public partial class FormPagoReservas : Form
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


        public FormPagoReservas()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textboxNumerica1.ToFloat(out float pago, "Pago")) 
            {
                if(hotel.EfectuarPagoCheckOut(reserva, pago))
                {
                    Close();
                }
            }
        }

        private void FormPagoReservas_Load(object sender, EventArgs e)
        {
            label1.Text = $"Cantidad Total a pagar: {(reserva.CalcularValorFinal()-reserva.Deposito):F2}";
        }
    }
}
