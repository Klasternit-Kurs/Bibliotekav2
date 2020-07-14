using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteka
{
	class Clan
	{
		public string Ime;
		public string Prezime;
		public string ClanskiBroj;
		public DateTime ZadnjaClanarina;

		//TODO fale jos knjige :D

		public Clan(string i, string p, string cb)
		{
			Ime = i;
			Prezime = p;
			ClanskiBroj = cb;
			ZadnjaClanarina = DateTime.Now;
		}
	}


}
