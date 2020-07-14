using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Biblioteka
{
	class Clan
	{
		public string Ime;
		public string Prezime;
		public string ClanskiBroj;
		public DateTime ZadnjaClanarina;

		public List<Knjiga> Knjige = new List<Knjiga>();

		public Clan(string i, string p, string cb)
		{
			Ime = i;
			Prezime = p;
			ClanskiBroj = cb;
			ZadnjaClanarina = DateTime.Now;
		}

		//Kandidat za out parametre, neka me neko seti iduce predavanje :) 
		public TimeSpan ProveriClanarinu()
		{
			DateTime sada = DateTime.Now;
			if (ZadnjaClanarina.Year == sada.Year && ZadnjaClanarina.Month == sada.Month)
			{
				return new TimeSpan(0, 0, 0, 0);
			}
			else
			{
				return sada - ZadnjaClanarina;
			}
		}
	}


}
