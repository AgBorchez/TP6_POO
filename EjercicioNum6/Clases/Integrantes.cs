using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EjercicioNum6
{
    public class Integrante
    {
        public Integrante() { }

        public Integrante(string nombre, string apellido, 
			DateTime Fnacimiento, decimal dni) 
		{
			this.nombre = nombre;
			this.apellido = apellido;
			this.fechaNacimiento = Fnacimiento;
			this.dni = dni;
		}
		
		private string nombre;

		public string Nombre
		{
			get { return nombre; }
			set { nombre = value; }
		}

		private string apellido;

		public string Apellido
        {
			get { return apellido; }
			set { apellido = value; }
		}

		private DateTime fechaNacimiento;

		public DateTime FechaNacimiento
        {
			get { return fechaNacimiento; }
			set { fechaNacimiento = value; }
		}

		private decimal dni;

		public decimal DNI
		{
			get { return dni; }
			set { dni = value; }
		}

		public int Edad
		{
			get { return (DateTime.Now.Year - fechaNacimiento.Year); }
		}

		private int vecesHospedado;

		public int VecesHospedado
        {
			get { return vecesHospedado; }
			set { vecesHospedado = value; }
		}

        public override string ToString()
        {
            return $"Nombre completo: {nombre} {apellido} | DNI: {dni} | Fecha de nacimiento: {fechaNacimiento.ToShortDateString()} | Edad: {Edad}";
        }

	}
}