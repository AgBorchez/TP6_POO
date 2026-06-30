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
    public partial class FormIntegrantes : Form
    {
        private Hotel hotel;

        public Hotel Hotel
        {
            get { return hotel; }
            set { hotel = value; }
        }

        public FormIntegrantes()
        {
            InitializeComponent();
        }

        private void btnAgregarIntegrante_Click(object sender, EventArgs e)
        {
            if(!textboxNumerica1.ToInt(out int DNI, "DNI")) return;
            if(dateTimePicker1.Value.Date == DateTime.Now.Date)
            {
                MessageBox.Show("Seleccione una fecha de nacimiento");
                return;
            }
            hotel.RegistrarIntegrante(new Integrante(textBox1.Text, textBox2.Text, dateTimePicker1.Value, DNI));
            RefrescarListboxes();
        }

        private void btnEliminarIntegrante_Click(object sender, EventArgs e)
        {
            if(listBox.SelectedItems.Count > 0) 
            {
                Integrante i = listBox.SelectedItem as Integrante;
                hotel.HistoricoIntegrantes.Remove(i);
            }
            RefrescarListboxes();
        }

        private void RefrescarListboxes()
        {
            listBox.DataSource = null;
            listBox.DataSource = hotel.HistoricoIntegrantes;
        }

        private void FormIntegrantes_Load(object sender, EventArgs e)
        {
            RefrescarListboxes();
        }
    }
}
