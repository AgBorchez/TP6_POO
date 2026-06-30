using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

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

		private List<Artefacto> artefactos = new List<Artefacto>();

		public List<Artefacto> Artefactos
		{
			get { return artefactos; }
		}

		private int vecesOcupada;

		public int VecesOcupada
        {
			get { return vecesOcupada; }
			set { vecesOcupada = value; }
		}

        private bool vistamar;

        public bool Vistamar
        {
            get { return vistamar; }
            set { vistamar = value; }
        }

        private int vecesSolicitada;

        public int VecesSolicitada
        {
            get { return vecesSolicitada; }
            set { vecesSolicitada = value; }
        }


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