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

        public override float CalcularValorHospedaje()
        {
            
            double dias = (FechaFin - FechaInicio).TotalDays;
            return base.CalcularValorHospedaje() + ((float)dias * 50);

        }
    }
}