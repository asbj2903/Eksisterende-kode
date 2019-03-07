using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eksisterende_kode
{
	interface IMenuItem
	{
		bool Activate(SmartMenu smartMenu);

		string ToString();
	}
}
