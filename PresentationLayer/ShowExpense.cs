﻿using System;
using System.Collections.Generic;
using System.Text;
using Eksisterende_kode;
using SmartMenuLibrary;
using Domain_Layer;
using Domain_Layer.Appendices;

namespace PresentationLayer
{
	class ShowExpense : IMenuItem
	{
		private Appendix Expense;

		public ShowExpense(Appendix expense)
		{
			Expense = expense;
		}

		public bool Activate(SmartMenu smartMenu)
		{
			string description;
			if (Expense is Trip)
			{
				Trip trip = Expense as Trip;
				description = $"{trip.Title}\n{trip.DepartureDestination}\n{trip.DepartureDate}\n{trip.ArrivalDestination}\n{trip.ArrivalDate}\n{trip.Distance}";
			}
			else
			{
				Expenditure trip = Expense as Expenditure;
				description = $"{trip.Title}\n{trip.ExpenseType}\n{trip.Cash}\n{trip.Date}\n{trip.Amount}";
			}

			SmartMenu sm = new SmartMenu(ToString(), "Tilbage", description);

			sm.Activate();

			return false;
		}

		public override string ToString() => string.Format("Afregning: {0}", Expense.Title);
	}
}
