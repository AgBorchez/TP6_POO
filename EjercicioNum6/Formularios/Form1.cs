using EjercicioNum6.Formularios;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EjercicioNum6
{
    public partial class Form1 : Form
    {
        
        protected Hotel Hotel = new Hotel();

        protected List<Reserva> Reservas = new List<Reserva>();
        
        public Form1()
        {
            InitializeComponent();
        }

        private void ActualizarInfo()
        {
            Hotel.ActualizarRecaudacion();
            labelRecaudacionTotal.Text = $"Recaudacion Total {Hotel.Recaudacion}";
            labelPasajeroMasHospedado.Text = $"Pasajero Mas Hospedado: {Hotel.PasajeroMasHospedado().Nombre}";
            Reservas = (from r in Hotel.Reservas where (r.Completa == false) select r).ToList();
            listBox1.DataSource = null;
            listBox1.DataSource = Reservas;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // Datos para debuggear

            Hotel.AgregarHabitacion(Habitacion.CrearHabitacion("Habitacion Simple", 101, true));
            Hotel.AgregarHabitacion(Habitacion.CrearHabitacion("Habitacion Doble", 102, false));
            Hotel.AgregarHabitacion(Habitacion.CrearHabitacion("Habitacion Triple", 201, true));
            Hotel.AgregarHabitacion(Habitacion.CrearHabitacion("Habitacion Cuadruple", 202, false));
            Hotel.AgregarHabitacion(Habitacion.CrearHabitacion("Habitacion Simple", 103, false));
            Hotel.Artefactos.Add(new Artefacto("Licuadora", 4500));
            Hotel.Artefactos.Add(new Artefacto("Microondas", 1200));
            Hotel.Artefactos.Add(new Artefacto("Pava Eléctrica", 3200));
            Hotel.Artefactos.Add(new Artefacto("Tostadora", 2850));
            Hotel.Artefactos.Add(new Artefacto("Cafetera", 8500));
            Hotel.HistoricoIntegrantes.Add(new Integrante("Alejandro", "Silva", new DateTime(1978, 4, 15), 26789123m));
            Hotel.HistoricoIntegrantes.Add(new Integrante("Mariana", "Paz", new DateTime(1983, 11, 22), 30456123m));
            Hotel.HistoricoIntegrantes.Add(new Integrante("Gonzalo", "Fernández", new DateTime(1991, 1, 5), 35987412m));
            Hotel.HistoricoIntegrantes.Add(new Integrante("Laura", "Benítez", new DateTime(1995, 8, 30), 38123456m));
            Hotel.HistoricoIntegrantes.Add(new Integrante("Facundo", "Herrera", new DateTime(1988, 6, 14), 33741852m));
            Hotel.HistoricoIntegrantes.Add(new Integrante("Romina", "Castro", new DateTime(2000, 12, 10), 42951753m));
            Hotel.HistoricoIntegrantes.Add(new Integrante("Santiago", "Acosta", new DateTime(2002, 3, 25), 44123987m));
            Hotel.HistoricoIntegrantes.Add(new Integrante("Micaela", "Suárez", new DateTime(1974, 9, 18), 23456789m));
            Hotel.HistoricoIntegrantes.Add(new Integrante("Matías", "Pereyra", new DateTime(1997, 5, 7), 40321654m));
            Hotel.HistoricoIntegrantes.Add(new Integrante("Florencia", "Díaz", new DateTime(2004, 7, 19), 45678912m));

            //
        }

        private void artefactosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormArtefactos frm = new FormArtefactos();
            frm.Hotel = Hotel;
            frm.ShowDialog();
        }

        private void habitacionesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormHabitaciones frm = new FormHabitaciones();
            frm.Hotel = Hotel;
            frm.ShowDialog();
        }

        private void integrantesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormIntegrantes frm = new FormIntegrantes();
            frm.Hotel = Hotel;
            frm.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FormCrearReserva frm = new FormCrearReserva();
            frm.Hotel = Hotel;
            if(frm.ShowDialog() == DialogResult.OK)
            {
                ActualizarInfo();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
            Habitacion habmasSolicitada = Hotel.HabitacionMasSolicitada(monthCalendar1.SelectionStart, monthCalendar1.SelectionEnd);
            MessageBox.Show($"La habitacion mas solicitada fue: {habmasSolicitada}");
        }

        private void button4_Click(object sender, EventArgs e)
        {
            float RecaudacionPorFecha = Hotel.ObtenerRecaudacionPorFecha(monthCalendar1.SelectionStart, monthCalendar1.SelectionEnd);
            MessageBox.Show($"La recaudacion Total en esta fecha fue de: {RecaudacionPorFecha}");
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedItems.Count > 0) 
            {
                FormPagoReservas frm = new FormPagoReservas();
                frm.Hotel = Hotel;
                frm.Reserva = listBox1.SelectedItem as Reserva;
                if(frm.ShowDialog() == DialogResult.OK) ActualizarInfo();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedItems.Count > 0)
            {
                if (MessageBox.Show("Esta segurod que desea eliminar la reserva.\nSe aplicaran los cargos correspondientes.", "", MessageBoxButtons.OKCancel) == DialogResult.OK)
                {
                    Reserva r = listBox1.SelectedItem as Reserva;
                    Hotel.CancelarReserva(r);
                    ActualizarInfo();
                }
            }
           
        }
    }
}
