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
    public partial class FormCrearReserva : Form
    {
        private Hotel hotel;

        public Hotel Hotel
        {
            get { return hotel; }
            set { hotel = value; }
        }

        protected List<Integrante> integrantesReserva = new List<Integrante>();
        protected Habitacion habSeleccionada = null;
            

        public FormCrearReserva()
        {
            InitializeComponent();
        }

        private void FormCrearReserva_Load(object sender, EventArgs e)
        {
            listBox3.DataSource = hotel.HistoricoIntegrantes;
            listBox1.DataSource = hotel.Habitaciones;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (listBox3.SelectedItems.Count > 0) 
            {
                Integrante i = listBox3.SelectedItem as Integrante;
                foreach (Integrante integrante in integrantesReserva) 
                {
                    if(i == integrante)
                    {
                        MessageBox.Show("Este integrante ya se encuentra en la lista de integrantes de la reserva");
                        return;
                    }
                }
                integrantesReserva.Add(i);
            }

            listBox2.DataSource = null;
            listBox2.DataSource = integrantesReserva;    
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (listBox2.SelectedItems.Count > 0)
            {
                Integrante i = listBox2.SelectedItem as Integrante;
                integrantesReserva.Remove(i);
            }
            listBox2.DataSource = null;
            listBox2.DataSource = integrantesReserva;
        }

        private void listBox1_Click(object sender, EventArgs e)
        {
            if(listBox1.SelectedItems.Count > 0)
            {
                habSeleccionada = listBox1.SelectedItem as Habitacion;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (integrantesReserva.Count ==  0)
            {
                MessageBox.Show("Agregue integrantes para continuar con la reserva");
                return;
            }
            if(monthCalendar1.SelectionStart < DateTime.Now)
            {
                MessageBox.Show("La fecha seleccionada no puede ser anterior a la fecha actual");
                return;
            }
            if (habSeleccionada == null) 
            {
                MessageBox.Show("Seleccione una habitacion para crear la reserva");
                return;
            }
            if(!radioButton1.Checked && !radioButton2.Checked)
            {
                MessageBox.Show("Especifique si la habitacion va a necesitar cuna o no");
                return;
            }

            Reserva r = hotel.RegistrarReserva(integrantesReserva, habSeleccionada, monthCalendar1.SelectionStart, monthCalendar1.SelectionEnd, radioButton1.Checked);

            if (r != null)
            { 
                FormCargarDeposito frm = new FormCargarDeposito();
                frm.Hotel = hotel;
                frm.Reserva = r;
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    MessageBox.Show("Reserva Creada!");
                    this.DialogResult = DialogResult.OK;
                    Close();
                }
                else
                {
                    MessageBox.Show("La reserva se cancelo con exito!");
                    hotel.Reservas.Remove(r);
                }       
            }

        }


    }
}
