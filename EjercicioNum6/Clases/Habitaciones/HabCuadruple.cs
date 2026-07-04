using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EjercicioNum6
{
    public class HabCuadruple : Habitacion
    {
        public HabCuadruple(int numerohabitacion, bool vistamar) : base(numerohabitacion, vistamar)
        {

        }

        public override string ToString()
        {
            return $"Tipo habitacion: Cuadruple | Numero Habitacion: {Numerohabitacion} | Vista Al Mar: {(Vistamar ? "si" : "no")}";
        }
        public override float Precio { get; } = 700;
    }
}