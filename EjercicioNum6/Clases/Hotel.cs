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
			bool ReservaYaRegistrada = false;
			foreach (Reserva r in reservas)
			{
				if ((reserva.FechaInicio > r.FechaInicio && reserva.FechaInicio < r.FechaFin) || (r.FechaInicio > reserva.FechaInicio && r.FechaInicio < reserva.FechaFin))
				{
					ReservaYaRegistrada = true;
				}
			}
			return ReservaYaRegistrada;
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


			if (!VerificarDisponibilidadReserva(r))
			{
                r.Habitacion.VecesOcupada++;
                r.Habitacion.VecesSolicitada++;
				r.CalcularValorReserva();
                reservas.Add(r);
				return r;
			}
			return null;
		}

		public float CancelarReserva(Reserva r)
		{
			//Punto 4
			DateTime fecha = DateTime.Now;
			float Vuelto = 0;

			if ((r.FechaInicio - fecha) < TimeSpan.FromDays(2))
			{
				Vuelto = r.DevolverExcedenteDeposito(10);
			}
			if ((r.FechaInicio - fecha) > TimeSpan.FromDays(2))
			{
				Vuelto = r.DevolverExcedenteDeposito(5);
			}
			if ((r.FechaInicio - fecha) > TimeSpan.FromDays(7))
			{
				Vuelto = r.DevolverExcedenteDeposito(0);
			}

			r.Habitacion.VecesOcupada--;
			return Vuelto;
		}

		public bool EfectuarPagoFinal(Reserva r, float pago)
		{
			//Punto 6

			if(r.PagarTotal(pago) != -1f) 
			{
				ActualizarRecaudacion();
				return true;
            }
			return false;
        }

		public Habitacion HabitacionMasSolicitada(DateTime FIL, DateTime FFL)
		{

			//punto 7
			Habitacion HabMasSolicitada = new HabSimple();
			foreach (Reserva r in reservas) 
			{
				if(r.FechaInicio > FIL && r.FechaInicio < FFL)
				{
					if(r.Habitacion.VecesSolicitada > HabMasSolicitada.VecesSolicitada)
					{
						HabMasSolicitada = r.Habitacion;
					}
				}
			}

			return HabMasSolicitada;
		}

        public Integrante PasajeroMasHospedado()
        {
            //Punto 8
            Integrante IMasHospedado = new Integrante();

            if (historicoIntegrantes.Count >= 0)
            {
                foreach (Integrante integrante in historicoIntegrantes)
                {
                    if (IMasHospedado.VecesHospedado < integrante.VecesHospedado) IMasHospedado = integrante;
                }
            }

            return IMasHospedado;
        }

        public float ObtenerRecaudacionPorFecha(DateTime InicioPeriodo, DateTime FinPeriodo)
		{

			//punto 9
			float RecaudacionFecha = 0;

			foreach (Reserva r in reservas)
			{
				if(r.FechaInicio > InicioPeriodo && r.FechaInicio < FinPeriodo)
				{
					RecaudacionFecha += r.Deposito;
				}
			}

			return RecaudacionFecha;
		}

		public Habitacion HabitacionMasOcupada() 
		{
			//punto 11 primera parte

			Habitacion HMasOcupada = new HabSimple();
			foreach (Habitacion h in habitaciones)
			{
				if (h.VecesOcupada > HMasOcupada.VecesOcupada)
				{
					HMasOcupada = h;
				}
			}

			return HMasOcupada;
		}

        public Habitacion HabitacionMasOcupada(DateTime FIL, DateTime FFL)
        {
            //punto 11 segunda parte

            Habitacion HMasOcupada = new HabSimple();
            foreach (Habitacion h in habitaciones)
            {
				//if(h)
                if (h.VecesOcupada > HMasOcupada.VecesOcupada)
                {
                    HMasOcupada = h;
                }
            }

            return HMasOcupada;

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
				rec += r.Deposito;
			}

			recaudacion = rec;
		}
    }
}