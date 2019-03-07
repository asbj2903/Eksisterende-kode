﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eksisterende_kode
{
    internal class CreateTravel : IMenuItem
    {
        private AccessPoint accessPoint;

        public CreateTravel(AccessPoint accessPoint)
        {
            this.accessPoint = accessPoint;
        }

        public bool Activate(SmartMenu smartMenu)
        {
            string title = Request.String("Rejse godtgørelsens titel:");
            DateTime departureDate = Request.DateTime("Hvornår tog du afsted?");
            DateTime returnDate = Request.DateTime("Hvorn år kom du hjem?");
            bool overNightStay = Request.Bool("Overnattede du under rejsen?");
            double credit = Request.Double("Hvor meget i kontant havde du med?");
            Travel travel = new Travel(title, accessPoint.Employee, departureDate, returnDate, overNightStay, credit);

            SmartMenu sm = new SmartMenu(travel.Title, "Anullér");

            sm.Attach(new AddExpenditure(travel));

            sm.Attach(new AddCompensationToDepartment(accessPoint.Department, travel));

            sm.Activate();

            return false;
        }

        public override string ToString()
        {
            return "Opret rejse godtgørelse";
        }
    }
}
