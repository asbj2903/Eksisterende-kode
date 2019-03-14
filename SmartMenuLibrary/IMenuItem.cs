using System;
using System.Collections.Generic;
using System.Text;

namespace SmartMenuLibrary
{
	public interface IMenuItem
	{
		bool Activate(SmartMenu smartMenu);

		string ToString();
	}
}
