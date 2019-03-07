using System;
using System.Collections.Generic;
using System.Text;
using Eksisterende_kode;

namespace PresentationLayer
{
	public class CreateDriving
	{
		private AccessPoint accessPoint;

		public CreateDriving(AccessPoint accessPoint)
		{
			this.accessPoint = accessPoint;
		}

		public bool Activate(SmartMenu smartMenu)
		{
			string title = Request.String("Kørsels godtgørelse titel");
			string numberPlate = Request.String("Nummerplade");
			Driving drivingCompensation = new Driving(title, accessPoint.Employee, numberPlate);

			SmartMenu sm = new SmartMenu(drivingCompensation.Title, "Anullér");

			sm.Attach(new AddTrip(drivingCompensation));

			sm.Attach(new AddCompensationToDepartment(accessPoint.Department, drivingCompensation));

			sm.Activate();

			return false;
		}

		public override string ToString()
		{
			return "Opret kørsels godtgørelse";
		}
	}
}
