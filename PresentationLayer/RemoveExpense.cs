using System;
using System.Collections.Generic;
using System.Text;
using SmartMenuLibrary;

using Domain_Layer.Compensations;
using Domain_Layer.Appendices;

namespace PresentationLayer
{
	public class RemoveExpense : IMenuItem
	{
		private Compensation Compensation;
		private Appendix Expense;

		public RemoveExpense(Compensation compensation, Appendix expense)
		{
			Compensation = compensation;
			Expense = expense;
		}

		public bool Activate(SmartMenu smartMenu)
		{
			Compensation.RemoveAppendix(Expense);
			smartMenu.Detach(this);
			return true;
		}

		public override string ToString() => string.Format("Fjern {0} fra {1}", Expense.Title, Compensation.Title);
	}
}
