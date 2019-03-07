using Domain_Layer.Compensations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain_Layer
{
    public class Department
    {
        private readonly List<Compensation> compensations = new List<Compensation>();
        public readonly int Id;

        internal Department(int id)
        {
            Id = id;
        }

        public void AddCompensation(Compensation compensation)
        {
            compensation.Save();
            compensations.Add(compensation);
        }

        public void RemoveCompensation(Compensation compensation)
        {
            compensations.Remove(compensation);
        }

        public IList<Compensation> GetAllCompensations()
        {
            return compensations.AsReadOnly();
        }
    }
}
