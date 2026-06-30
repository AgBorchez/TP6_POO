using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EjercicioNum6
{
    public class HabSimple : Habitacion
    {
        public HabSimple() { }
        public HabSimple(int numerohabitacion, bool vistamar):base(numerohabitacion, vistamar) 
        {

        }

        public override string ToString()
        {
            return $"Tipo habitacion: Simple | Numero Habitacion: {Numerohabitacion} | Vista Al Mar: {(Vistamar ? "si" : "no")}";
        }
        public override float Precio => 200;
    }
}