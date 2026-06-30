using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EjercicioNum6
{
    public partial class FormArtefactos : Form
    {

        private Hotel hotel;

        public Hotel Hotel
        {
            get { return hotel; }
            set { hotel = value; }
        }


        public FormArtefactos()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(textboxNumerica1.ToFloat(out float precio, "Precio")) 
            { 

            Artefacto a = new Artefacto(textBox1.Text, precio);

            hotel.Artefactos.Add(a);

            listBox1.DataSource = null;
            listBox1.DataSource = hotel.Artefactos;
            }
        }

        private void FormArtefactos_Load(object sender, EventArgs e)
        {
            listBox1.DataSource = hotel.Artefactos;
        }
    }
}
