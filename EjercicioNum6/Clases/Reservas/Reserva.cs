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

        private List<Integrante> integrantes;

        public List<Integrante> Integrantes
        {
            get { return integrantes; }
        }

        private List<Artefacto> consumos = new List<Artefacto>();

        public List<Artefacto> Consumos
        {
            get { return consumos; }
        }

        private float deposito = 0;

        public float Deposito
        {
            get { return deposito; }
            set { deposito = value; }
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

        private bool solicitada = false;

        public bool Solicitada
        {
            get { return solicitada; }
            set { solicitada = value; }
        }

        private bool ocupada = false;

        public bool Ocupada
        {
            get { return ocupada; }
            set { ocupada = value; }
        }

        private bool completa = false;

        public bool Completa { get { return completa; } }

        public void TerminarReserva()
        {
            completa = true;
            foreach (Integrante i in integrantes)
            {
                i.VecesHospedado++;
            }
        }

        



        public override string ToString()
        {
            return $"Reserva de la habitacion numero: {habitacion.Numerohabitacion} | Ocupada: {(ocupada ? "Si" : "No")} | {fechaInicio.ToShortDateString()} - {fechaFin.ToShortDateString()}" ;
        }

        public virtual float CalcularValorHospedaje()
        {
            //punto 3
            double dias = (FechaFin - FechaInicio).TotalDays;
            float Reserva = Habitacion.Precio * (float)dias;
            

            if (habitacion.Vistamar == true)
            {
                Reserva = Reserva + (Reserva * 15) / 100;
            }

            return Reserva;
        }

        public float CalcularValorFinal()
        {
            float totalConsumos = consumos.Sum(a => a.Precio);
            return CalcularValorHospedaje() + totalConsumos;
        }
        public bool PagarValorDeposito(float deposito)
        {
            //punto 3
            float vReserva = CalcularValorHospedaje();
            if(deposito < (vReserva*10)/100) 
            {
                MessageBox.Show("El valor de el deposito debe ser como minimo un 10% del " +
                    "valor total de la reserva");
                return false;
            }
            else if(deposito > vReserva)
            {
                MessageBox.Show("El valor de el deposito no puede ser mayor al valor de la reserva");
                return false;
            }
            else
            {
                Deposito += deposito;
                return true;
            }
        }

        public float DevolverExcedenteDeposito(int diasAnticipacion)
        {
            //punto 4
            if (diasAnticipacion <= 0)
            {
                completa = true;
                return 0;
            }
            float cantidadDevolucion = 0;

            float minimoExigido = (CalcularValorHospedaje() * 10) / 100;
            float excedente = deposito - minimoExigido;

            if (diasAnticipacion < 2)
            {
                deposito = minimoExigido;
                cantidadDevolucion = excedente;
            }
            else if (diasAnticipacion >= 2 && diasAnticipacion <= 7)
            {
                deposito = minimoExigido / 2;
                cantidadDevolucion = (minimoExigido / 2 ) + excedente;
            }
            else if (diasAnticipacion > 7)
            {
                cantidadDevolucion = deposito;
                deposito = 0;
            }

            completa = true; //porque la reserva ya fue cancelada y no tendria sentido que siga activa
            return cantidadDevolucion;
        }

        public float PagarTotal(float Pago)
        {
            float valorReserva = CalcularValorFinal();
            float CantidadPago = valorReserva - deposito;

            if (Pago < CantidadPago)
            {
                //si la funcion termina mal, se retorna -1 por default
                MessageBox.Show("Cantidad insuficiente para completar el pago");
                return -1;
            }
            else
            {
                //asi podemos asegurar que se pago el total
                deposito = valorReserva;

                //si la funcion sale bien se devuelve el sobrante del pago, de
                //no sobrar nada se devolvera 0
                return Pago - CantidadPago;
            }

        }
    }
}