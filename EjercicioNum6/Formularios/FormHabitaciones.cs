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
    public partial class FormHabitaciones : Form
    {
        private Hotel hotel;

        public Hotel Hotel
        {
            get { return hotel; }
            set { hotel = value; }
        }
        public FormHabitaciones()
        {
            InitializeComponent();
        }

        //btn para agregar habitaciones
        private void button1_Click(object sender, EventArgs e)
        {
            if (!radioButton1.Checked && !radioButton2.Checked) 
            {
                //aca verificamos que al menos 1 radio btn este seleccionado
                MessageBox.Show("Seleccione si la habitacion cuenta con vista al mar o no");
                return;
            }
            //con el siguiente metodo le avisamos al usuario de errores de parseo, el programa sigue su funcion.
            if (!textboxNumerica1.ToInt(out int numerohabitacion, "Numero Habitacion")) return; 

            //El hotel tiene su propia logica para agregar habitaciones.
            //En el caso de las habitaciones tienen un metodo estatico que detecta que tipo de habitacion (es decir la clase)
            //es necesario crear, en caso de haber algun error devuelve null para que agregarhabitacion() lo trate
            hotel.AgregarHabitacion(Habitacion.CrearHabitacion(comboBox1.Text, numerohabitacion, (radioButton1.Checked)));

            LimpiarFormulario();

        }

        private void FormHabitaciones_Load(object sender, EventArgs e)
        {
            //cargamos el combobox, que esta en modo solo seleccion para que el usuario no pueda ingresar nada erroneo
            //ademas cargo los datos de el hotel, por si ya hay habitaciones existentes
            listBox1.DataSource = hotel.Habitaciones;
            comboBox1.Items.Add("Habitacion Simple");
            comboBox1.Items.Add("Habitacion Doble");
            comboBox1.Items.Add("Habitacion Triple");
            comboBox1.Items.Add("Habitacion Cuadruple");
        }

        //evento para la seleccion de una habitacion, ya sea para su modificacion o eliminacion
        private void listBox1_Click(object sender, EventArgs e)
        {
            //aca me traigo los datos por si el usuario desea modificar los datos de la habitacion
            if (listBox1.SelectedItems.Count > 0)
            {
                Habitacion h = listBox1.SelectedItem as Habitacion;
                AsignarDatosFormulario(h);
            }
        }


        //evento para ver la lista de artefactos que contiene una habitacion
        private void listBox1_DoubleClick(object sender, EventArgs e)
        {
            //Aca me traigo los datos para mostrarlos en el modal que voy a abrir a continuacion. De 
            //esta forma, con la habitacion creada, el usuario le puede agregar los artefactos que desee
            if (listBox1.SelectedItems.Count > 0)
            {
                Habitacion h = listBox1.SelectedItem as Habitacion;
                AsignarDatosFormulario(h);
                FormArtefactosHabitacion frm = new FormArtefactosHabitacion();
                frm.Hotel = hotel;
                frm.H = h;
                frm.ShowDialog();
            }
        }

        //boton para eliminar una habitacion de la lista
        private void button2_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedItems.Count > 0)
            {
                Habitacion h = listBox1.SelectedItem as Habitacion;
                hotel.Habitaciones.Remove(h);
                LimpiarFormulario();
            }
        }

        // boton para modificar datos de una habitacion
        private void button3_Click(object sender, EventArgs e)
        {
            if (!textboxNumerica1.ToInt(out int numerohabitacion, "Numero Habitacion")) return;
            if (listBox1.SelectedItems.Count > 0)
            {
                Habitacion h = listBox1.SelectedItem as Habitacion;
                h.ModificarDatos(numerohabitacion, radioButton1.Checked);
                LimpiarFormulario();
            }
        }

        //este metodo limpia todos los input necesarios para crear una habitacion
        private void LimpiarFormulario()
        {
            textboxNumerica1.Text = "";
            comboBox1.SelectedIndex = -1;
            comboBox1.Enabled = true;
            radioButton1.Checked = false;
            radioButton2.Checked = false;
            listBox1.DataSource = null;
            listBox1.DataSource = hotel.Habitaciones;

        }

        //este metodo rellena los inputs con los datos de una habitacion ya existente
        private void AsignarDatosFormulario(Habitacion h)
        {
            comboBox1.Enabled = false;
            textboxNumerica1.Text = h.Numerohabitacion.ToString();
            if(h.GetType() == typeof(HabSimple))
            {
                comboBox1.SelectedIndex = 0;
            }
            else if (h.GetType() == typeof(HabDoble))
            {
                comboBox1.SelectedIndex = 1;
            }
            else if (h.GetType() == typeof(HabTriple))
            {
                comboBox1.SelectedIndex = 2;
            }
            else if (h.GetType() == typeof(HabCuadruple))
            {
                comboBox1.SelectedIndex = 3;
            }

            if (h.Vistamar == true) radioButton1.Checked = true;
            else radioButton2.Checked = true;
        }
    }
}
