using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace EjercicioNum6
{
    public class Reserva
    {
        public Reserva(List<Integrante> Integrantes, Habitacion hab, DateTime FI, DateTime FF) 
        {
            integrantes = Integrantes;
            fechaInicio = FI;
            FechaFin = FF;
            habitacion = hab;
        }
        private float precio;

        public float Precio
        {
            get { return precio; }
            set { precio = value; }
        }

        private List<Integrante> integrantes;

        public List<Integrante> Integrantes
        {
            get { return integrantes; }
            set { integrantes = value; }
        }

        private float deposito = 0;

        public float Deposito
        {
            get { return deposito; }
            set { deposito = value; }
        }

        protected float valorTotReserva;

        public float ValorTotReserva
        {
            get { return valorTotReserva; }
        }



        private DateTime fechaInicio;

        public DateTime FechaInicio
        {
            get { return fechaInicio; }
            set { fechaInicio = value; }
        }

        private DateTime fechaFin;

        public DateTime FechaFin
        {
            get { return fechaFin; }
            set { fechaFin = value; }
        }


        private Habitacion habitacion;

        public Habitacion Habitacion
        {
            get { return habitacion; }
            set { habitacion = value; }
        }

        private bool completa;

        public bool Completa
        {
            get { return completa; }
            set { completa = value; }
        }


        public override string ToString()
        {
            return $"Reserva de la habitacion numero: {habitacion.Numerohabitacion} | Desde {fechaInicio.ToShortDateString()} Hasta: {fechaFin.ToShortDateString()}" ;
        }

        public virtual void CalcularValorReserva()
        {
            //punto 3
            double dias = (FechaFin - FechaInicio).TotalDays;
            float Reserva = Habitacion.Precio * (float)dias;

            if (habitacion.Vistamar == true)
            {
                Reserva = Reserva - (Reserva * 15) / 100;
            }

            valorTotReserva = Reserva;
        }

        public bool PagarValorDeposito(float deposito)
        {
            //punto 3
            CalcularValorReserva();
            if(deposito < (valorTotReserva*10)/100) 
            {
                MessageBox.Show("El valor de el deposito debe ser como minimo un 10% del " +
                    "valor total de la reserva");
                return false;
            }
            else
            {
                Deposito += deposito;
                return true;
            }
        }

        public float DevolverExcedenteDeposito(int PorcentajeGanado)
        {
            //punto 4
            float CantidadDevolucion;
            if(PorcentajeGanado == 0) { CantidadDevolucion = 0; }
            else
            {
                CantidadDevolucion = deposito - ((PorcentajeGanado * valorTotReserva) / 100);
                deposito -= CantidadDevolucion;
            }

            return CantidadDevolucion;
        }

        public float PagarTotal(float Pago)
        {
            float CantidadPago = valorTotReserva - deposito;

            if (Pago < CantidadPago)
            {
                //si la funcion termina mal, se retorna -1 por default
                MessageBox.Show("Cantidad insuficiente para completar el pago");
                return -1;
            }
            else
            {
                //asi podemos asegurar que se pago el total
                deposito = valorTotReserva;
                completa = true;

                //si la funcion sale bien se devuelve el sobrante del pago, de
                //no sobrar nada se devolvera 0
                return Pago - CantidadPago;
            }

        }
    }
}