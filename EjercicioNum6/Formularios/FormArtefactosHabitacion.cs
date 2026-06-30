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
    public partial class FormArtefactosHabitacion : Form
    {

        private Hotel hotel;

        public Hotel Hotel
        {
            get { return hotel; }
            set { hotel = value; }
        }

        private Habitacion h;

        public Habitacion H
        {
            get { return h; }
            set { h = value; }
        }


        public FormArtefactosHabitacion()
        {
            InitializeComponent();
        }

        private void FormArtefactosHabitacion_Load(object sender, EventArgs e)
        {
            //cargo datos antes de arrancar
            label1.Text += h.Numerohabitacion.ToString();
            listBox1.DataSource = h.Artefactos;
            listBox2.DataSource = hotel.Artefactos;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (listBox2.SelectedIndex > 0) 
            { 
                Artefacto a = listBox2.SelectedItem as Artefacto;
                h.Artefactos.Add(a);
                RefrescarLista();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex > 0)
            {
                Artefacto a = listBox1.SelectedItem as Artefacto;
                h.Artefactos.Remove(a);
                RefrescarLista();
            }
        }

        private void RefrescarLista()
        {
            listBox1.DataSource = null; 
            listBox2.DataSource = null;
            listBox1.DataSource = h.Artefactos;
            listBox2.DataSource = hotel.Artefactos;
        }
    }
}
