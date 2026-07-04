using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace EjercicioNum6
{
	public class Hotel
	{
		private float recaudacion = 0;

		public float Recaudacion
		{
			get { return recaudacion; }
			set { recaudacion = value; }
		}

		private List<Habitacion> habitaciones = new List<Habitacion>();

		public List<Habitacion> Habitaciones
		{
			get { return habitaciones; }
		}

		private List<Reserva> reservas = new List<Reserva>();

		public List<Reserva> Reservas
		{
			get { return reservas; }
		}

		private List<Integrante> historicoIntegrantes = new List<Integrante>();

		public List<Integrante> HistoricoIntegrantes
        {
			get { return historicoIntegrantes; }
		}

        private List<Artefacto> artefactos = new List<Artefacto>();

        public List<Artefacto> Artefactos
        {
            get { return artefactos; }
        }




        public bool VerificarDisponibilidadReserva(Reserva reserva)
		{
			//punto 11
			bool ReservaDisponible = true;
			foreach (Reserva r in reservas)
			{
                if (reserva.Habitacion.Numerohabitacion == r.Habitacion.Numerohabitacion && reserva.FechaInicio < r.FechaFin && r.FechaInicio < reserva.FechaFin)
                {
                    ReservaDisponible = false;
                }
            }
			return ReservaDisponible;
		}

		//como es el hotel el que se encarga de las reservas
		public Reserva RegistrarReserva(List<Integrante> integrantes, Habitacion habitacion, DateTime FI, DateTime FF, bool cuna)
		{
			Reserva r;

			//punto 1 y 2
			if (cuna)
			{
				r = new ReservaConCuna(integrantes, habitacion, FI, FF);
			}
			else {
				r = new Reserva(integrantes, habitacion, FI, FF);
			}


			if (VerificarDisponibilidadReserva(r))
			{
				r.Solicitada = true;
                reservas.Add(r);
				return r;
			}
			return null;
		}

		public void OcuparHabitacionReservada(Reserva r)
		{
			//punto 2 
			//se us asolo cuando los pasajeros llegan presencialmente y ocupan la habitacion
			if(!r.Completa && r.FechaFin > DateTime.Now) r.Ocupada = true;

		}

		public float CancelarReserva(Reserva r)
		{
			//Punto 4
			
			int DiasAnticipacion = (int)(r.FechaInicio - DateTime.Now).TotalDays;

            float Vuelto = r.DevolverExcedenteDeposito(DiasAnticipacion);

			ActualizarRecaudacion();

			return Vuelto;
		}

		public bool EfectuarPagoCheckOut(Reserva r, float pago)
		{
			//Punto 6
			float vuelto = r.PagarTotal(pago);


            if (vuelto != -1f) 
			{
				ActualizarRecaudacion();
				r.TerminarReserva();
				MessageBox.Show($"Se ha devuelto ${vuelto:F2} sobrantes de el pago");
				return true;
            }
			return false;
        }

		public Habitacion HabitacionMasSolicitada(DateTime FIL, DateTime FFL)
		{

            //punto 7
            return reservas
				.Where(r => r.FechaInicio < FFL && FIL < r.FechaFin && r.Solicitada == true)
				.GroupBy(r => r.Habitacion)
				.OrderByDescending(grupo => grupo.Count())
				.Select(grupo => grupo.Key)
				.FirstOrDefault() ?? new HabSimple();
        }

        public Integrante PasajeroMasHospedado()
        {
            //Punto 8

            return historicoIntegrantes.OrderByDescending(r => r.VecesHospedado).FirstOrDefault();
        }

        public float ObtenerRecaudacionPorFecha(DateTime InicioPeriodo, DateTime FinPeriodo)
		{

			//punto 9
			float RecaudacionFecha = 0;

			foreach (Reserva r in reservas)
			{
				if(r.Completa && r.FechaInicio >= InicioPeriodo && r.FechaInicio <= FinPeriodo)
				{
					RecaudacionFecha += r.Deposito;
				}
			}

			return RecaudacionFecha;
		}

		public Habitacion HabitacionMasOcupada() 
		{
			//punto 10 primera parte

			Habitacion HMasOcupada = new HabSimple();
            return reservas
                .Where(r => r.Ocupada == true)
                .GroupBy(r => r.Habitacion)
                .OrderByDescending(grupo => grupo.Count())
                .Select(grupo => grupo.Key)
                .FirstOrDefault() ?? new HabSimple();
        }

        public Habitacion HabitacionMasOcupada(DateTime FIL, DateTime FFL)
        {
            //punto 10 segunda parte

            return reservas
				.Where(r => r.FechaInicio < FFL && FIL < r.FechaFin && r.Ocupada == true)
				.GroupBy(r => r.Habitacion)
				.OrderByDescending(grupo => grupo.Count())
				.Select(grupo => grupo.Key)
				.FirstOrDefault() ?? new HabSimple();

        }

		public void AgregarHabitacion(Habitacion habitacion)
		{
			if (habitacion == null) { MessageBox.Show("Algo salio mal!"); return; }
		
            foreach (Habitacion hab in Habitaciones)
            {
                if (hab.Numerohabitacion == habitacion.Numerohabitacion)
                {
                    MessageBox.Show("Ya existe una habitacion con el mismo numero, eliminela o cambie el numero de esta");
					return;
                }
            }

			habitaciones.Add(habitacion);
            
        }

		public void RegistrarIntegrante(Integrante integrante) 
		{
			foreach(Integrante i in historicoIntegrantes)
			{
				if(i.DNI == integrante.DNI)
				{
					MessageBox.Show("Revise DNI.\n Ya existe una persona con este DNI en el sistema");
					return;
				}
			}
            historicoIntegrantes.Add(integrante);
        }

		public void ActualizarRecaudacion()
		{
			float rec = 0;

			foreach(Reserva r in reservas)
			{
				if(r.Completa) rec += r.Deposito;
			}

			recaudacion = rec;
		}
    }
}

//Te amo LINQ