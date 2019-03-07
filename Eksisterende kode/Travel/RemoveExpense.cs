using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eksisterende_kode
{
    class RemoveExpense : IMenuItem
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
