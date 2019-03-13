using System;
using System.Collections.Generic;
using System.Text;
using Domain_Layer;
using Domain_Layer.Compensations;
using SmartMenuLibrary;

namespace PresentationLayer
{
	public class AddCompensationToDepartment
	{
		private Department Department;
		private Compensation Compensation;

		public AddCompensationToDepartment(Department department, Compensation compensation)
		{
			Department = department;
			Compensation = compensation;
		}

		public bool Activate(SmartMenu smartMenu)
		{
			Department.AddCompensation(Compensation);
			return true;
		}

		public override string ToString() => string.Format("Gem {0}", Compensation.Title);
	}
}
