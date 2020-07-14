using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteka
{
	class Program
	{
		//TODO izmena (takodje uz izmenu, placanje clanarine) i uklanjanje korisnika za domaci
		//isto za knjige
		//Dodati datuma na racune u POSu 
		//Kod ispisa, treba napraviti da kada se prikazuju knjige prikazu kod kojih su sve clanova
		//kopije. Kod clanova, treba da ispisemo knjige koje su kod njih
		//Treba implemetirati zapisivanje u fajlove. Posto korisnici imaju list knjiga, kao racun u pos-u
		//otrpilike, treba da zapisemo sifru svake knjige koja je kod korisnika

		static List<Clan> Clanovi = new List<Clan>();
		static List<Knjiga> Knjige = new List<Knjiga>();

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
					case "0":
						Izdaj();
						break;
					case "1":
						DodajKnjigu();
						break;
					case "4":
						IspisKnjiga();
						break;
					case "5":
						UnosClana();
						break;
					case "8":
						IspisClanova();
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

		static void Izdaj()
		{
			Console.Write("Unesite sifru clana: ");
			string sifra = Console.ReadLine();

			Clan c = null;
			foreach(Clan cl in Clanovi)
			{
				if (cl.ClanskiBroj == sifra)
				{
					c = cl;
					break;
				}
			}

			if (c == null)
			{
				Console.WriteLine("Pogresan broj");
				return;
			}

			TimeSpan kas = c.ProveriClanarinu();
			if (kas.Days != 0)
			{
				Console.WriteLine($"Clanarina kasni {kas.Days}");
				return;
			}

			Console.Write("Unesite sifru knjige: ");
			sifra = Console.ReadLine();

			Knjiga k = null;
			foreach (Knjiga kg in Knjige)
			{
				if (kg.Sifra == sifra)
				{
					k = kg;
					break;
				}
			}

			if (k == null)
			{
				Console.WriteLine("Pogresan broj knjige");
				return;
			}

			if (k.BrojPrimeraka == 0)
			{
				Console.WriteLine("Nema slobodan primerak :(");
			}

			c.Knjige.Add(k);
			k.BrojPrimeraka--;

		}

		static void IspisKnjiga()
		{
			foreach(Knjiga k in Knjige)
			{
				Console.WriteLine($"{k.Sifra} - {k.Naziv} {k.Zanr} {k.BrojPrimeraka}");
			}
		}

		static void DodajKnjigu()
		{
			Knjiga k = new Knjiga();
			Console.WriteLine("Unesite sifra: ");
			k.Sifra = Console.ReadLine();
			Console.WriteLine("Unesite naziv: ");
			k.Naziv = Console.ReadLine();
			Console.WriteLine("Unesite zanr: ");
			k.Zanr = Console.ReadLine();
			Console.WriteLine("Unesite broj primeraka: ");
			k.BrojPrimeraka = int.Parse(Console.ReadLine());
			Knjige.Add(k);
		}

		static void IspisClanova()
		{
			foreach(Clan c in Clanovi)
			{
				Console.Write($"{c.ClanskiBroj} -- {c.Ime} {c.Prezime} ");
				DateTime sada = DateTime.Now;
				TimeSpan kasnjenje = c.ProveriClanarinu();
				if (kasnjenje.Days == 0)
				{
					Console.WriteLine("-- Clanarina OK");
				} else
				{
					Console.WriteLine($"Kasni {kasnjenje.Days} dana");
				}
			}
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
