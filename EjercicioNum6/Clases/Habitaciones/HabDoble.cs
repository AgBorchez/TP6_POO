using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EjercicioNum6
{

    public class HabDoble : Habitacion
    {
        public HabDoble(int numerohabitacion, bool vistamar) : base(numerohabitacion, vistamar)
        {

        }

        public override string ToString()
        {
            return $"Tipo habitacion: Doble | Numero Habitacion: {Numerohabitacion} | Vista Al Mar: {(Vistamar ? "si" : "no")}";
        }
        public override float Precio { get; } = 350;
    }
}