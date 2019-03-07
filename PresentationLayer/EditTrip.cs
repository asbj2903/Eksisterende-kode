using System;
using System.Collections.Generic;
using System.Text;
using Eksisterende_kode;

namespace PresentationLayer
{
	public class EditTrip : IMenuItem
	{
		private Compensation Compensation;
		private Trip trip;

		public EditTrip(Compensation compensation, Trip trip)
		{
			Compensation = compensation;
			this.trip = trip;
		}

		public bool Activate(SmartMenu smartMenu)
		{
			string description = string.Format(
				"{0}\n{1}\n{2}\n{3}\n{4}\n{5}",
				trip.Title,
				trip.DepartureDestination,
				trip.DepartureDate,
				trip.ArrivalDestination,
				trip.ArrivalDate,
				trip.Distance
			);

			SmartMenu sm = new SmartMenu(trip.Title, "Tilbage", description);

			sm.Attach(new RemoveExpense(Compensation, trip));


			int countExpenses = Compensation.CountAppendices();

			sm.Activate();

			if (countExpenses > Compensation.CountAppendices())
			{
				smartMenu.Detach(this);
			}

			return false;
		}

		public override string ToString() => string.Format("Se {0}", trip.Title);
	}
}
