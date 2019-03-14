using System;
using System.Collections.Generic;
using System.Text;
using Domain_Layer.Appendices;
using Domain_Layer.Compensations;
using SmartMenuLibrary;

namespace PresentationLayer
{
	internal class AddExpenditure : IMenuItem
	{
		private readonly Travel Travel;

		public AddExpenditure(Travel travel)
		{
			Travel = travel;
		}

		public bool Activate(SmartMenu smartMenu)
		{
			string title = Request.String("Titel på udgiften");
			DateTime date = Request.DateTime("Tidspunkt");
			double amount = Request.Double(string.Format("Sum af udgiften {0}", title));
			Expenditure.Type type = Request.Enum<Expenditure.Type>("Type");
			bool cash = Request.Bool("Betalte du med kontant?");

			Expenditure expenditure = new Expenditure(title, date, amount, type, cash, Travel);
			Travel.AddAppendix(expenditure);

			smartMenu.Attach(new EditExpenditure(Travel, expenditure));

			return false;
		}

		public override string ToString() => "Tilføj ny bekostning";
	}
}
