using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteka
{
	class Program
	{
		static List<Clan> Clanovi = new List<Clan>();

		static void Main(string[] args)
		{
			string unos;
			do
			{
				Meni();
				unos = Console.ReadKey().KeyChar.ToString();
				Console.WriteLine();
				switch(unos)
				{
					case "5":
						UnosClana();
						break;
					case "9":
						Console.WriteLine("Bye :)");
						break;
					default:
						Console.WriteLine("Unos nije razumljiv :(");
						break;
				}
			} while (unos != "9");
			Console.ReadKey();
		}

		static void UnosClana()
		{
			string ImeIPrezime;
			while (true)
			{
				Console.Write("Unesite ime i prezime: ");
				ImeIPrezime = Console.ReadLine();
				if (ImeIPrezime.Split(' ').Length == 2)
				{
					break;
				}
				Console.WriteLine("Los unos :(");
			}

			string clanska;
			while(true)
			{
				Console.Write("Unesite broj clanske: ");
				clanska = Console.ReadLine();
				bool Problem = false;

				if (string.IsNullOrEmpty(clanska))
				{
					Problem = true;
					Console.WriteLine("Los unos :(");
				}
				
				foreach(Clan c in Clanovi)
				{
					if (c.ClanskiBroj == clanska)
					{
						Problem = true;
						Console.WriteLine("Broj je duplikat!");
					}
				}
				if (!Problem)
				{
					break;
				}
			}

			string[] iIp = ImeIPrezime.Split(' ');

			Clanovi.Add(new Clan(iIp[0], iIp[1], clanska));
		}

		static void Meni()
		{
			Console.WriteLine("0 - Izdaj knjigu");
			Console.WriteLine("1 - Dodaj knjigu");
			Console.WriteLine("2 - Izmeni knjigu");
			Console.WriteLine("3 - Ukloni knjigu");
			Console.WriteLine("4 - Ispis knjiga");
			Console.WriteLine("5 - Unos clana");
			Console.WriteLine("6 - Izmena clana");
			Console.WriteLine("7 - Uklanjanje clana");
			Console.WriteLine("8 - Ispis clanova");
			Console.WriteLine("9 - Izlaz");
			Console.WriteLine("---------------------");
			Console.Write("Unesite izbor: ");
		}
	}
}
