using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace EjercicioNum6
{
    public abstract class Habitacion
    {
		public Habitacion() { }
		public Habitacion(int numerohabitacion, bool vistamar) 
		{
			this.numerohabitacion = numerohabitacion;
			this.vistamar = vistamar;
		}

		private int numerohabitacion;

		public int Numerohabitacion
        {
			get { return numerohabitacion; }
			set { numerohabitacion = value; }
		}

		public abstract float Precio
		{
			get;
		}

        private bool vistamar;

        public bool Vistamar
        {
            get { return vistamar; }
            set { vistamar = value; }
        }

        public List<Artefacto> Artefactos = new List<Artefacto>();

        public List<Artefacto> artefactos { get {return Artefactos; } }


        public static Habitacion CrearHabitacion(string seleccion, int numerohabitacion, bool vistamar)
		{
            Habitacion habitacion = null;
            switch (seleccion)
            {
                case "Habitacion Simple":
                    {
                        habitacion = new HabSimple(numerohabitacion, vistamar);
                        break;
                    }
                case "Habitacion Doble":
                    {
                        habitacion = new HabDoble(numerohabitacion, vistamar);
                        break;
                    }
                case "Habitacion Triple":
                    {
                        habitacion = new HabTriple(numerohabitacion, vistamar);
                        break;
                    }
                case "Habitacion Cuadruple":
                    {
                        habitacion = new HabCuadruple(numerohabitacion, vistamar);
                        break;
                    }
            }

            return habitacion;
        }

        public void ModificarDatos(int numerohabitacion, bool vistamar)
        {
            this.numerohabitacion = numerohabitacion;
            this.vistamar = vistamar;
        }
    }
}