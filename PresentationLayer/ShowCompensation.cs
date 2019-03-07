using System;
using System.Collections.Generic;
using System.Text;

namespace PresentationLayer
{
	public class ShowCompensation : IMenuItem
	{
		private Compensation compensation;

		public ShowCompensation(Compensation compensation)
		{
			this.compensation = compensation;
		}

		public bool Activate(SmartMenu smartMenu)
		{
			SmartMenu sm = new SmartMenu(ToString(), "Tilbage");

			foreach (Appendix expense in compensation.GetAppendices())
			{
				sm.Attach(new ShowExpense(expense));
			}

			sm.Activate();

			return false;
		}

		public override string ToString() => compensation.Title;
	}
}
