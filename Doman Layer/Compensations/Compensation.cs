using Domain_Layer.Appendices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain_Layer.Compensations
{
    public abstract class Compensation : ISavable
    {
        protected static readonly string ConnectionString = "Server=EALSQL1.eal.local; Database=B_DB17_2018; User Id=B_STUDENT17; Password=B_OPENDB17;";
        public int Id { get; internal set; }
        protected readonly List<Appendix> appendices = new List<Appendix>();
        public readonly string Title;
        internal readonly Employee Employee;

        protected Compensation(string title, Employee employee)
        {
            Title = title;
            Employee = employee;
        }

        public void AddAppendix(Appendix expense)
        {
            appendices.Add(expense);
        }

        public void RemoveAppendix(Appendix expense)
        {
            appendices.Remove(expense);
        }

        public abstract List<Appendix> GetAppendices();

        public int CountAppendices()
        {
            return appendices.Count;
        }

        public abstract void Save();
    }
}
