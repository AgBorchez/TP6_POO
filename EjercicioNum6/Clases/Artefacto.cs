using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EjercicioNum6
{
    public class Artefacto
    {
		public Artefacto(string nombre, float precio) 
		{
			this.nombre = nombre;
			this.precio = precio;
		}

		private string nombre;

		public string Nombre
		{
			get { return nombre; }
			set { nombre = value; }
		}

		private float precio;

		public float Precio
		{
			get { return precio; }
			set { precio = value; }
		}

        public override string ToString()
        {
            return $"Nombre del Artefacto: {nombre} | Precio: {precio}";
        }

	}
}