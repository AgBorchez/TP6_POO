using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EjercicioNum6
{
    public class ReservaConCuna : Reserva
    {
        public ReservaConCuna(List<Integrante> Integrantes, Habitacion hab, DateTime FI, DateTime FF) : base(Integrantes, hab, FI, FF)
        {
        }

        public override void CalcularValorReserva()
        {
            base.CalcularValorReserva();
            double dias = (FechaInicio - FechaFin).TotalDays;
            valorTotReserva += (float)dias * 50;
            
        }
    }
}