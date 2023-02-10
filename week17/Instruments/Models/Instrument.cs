using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dapper.Contrib.Extensions;
using MySql.Data;
using MySql.Data.MySqlClient;

namespace Instruments.Models
{
	[Table("instrument")]
	public class Instrument
	{
		[Key]
		public int id { get; set; }
		public string kind { get; set; }
		public string color { get; set; }

		//
		// Static members
		//
		public static List<Instrument> Instruments = new List<Instrument>();
		public static int nextId = 1;
		public static MySqlConnection DB;

		//
		//cRud
		//
		public static IEnumerable<Instrument> GetAll()
		{
			// If you're not sure the relationship between IEnumerable<> and List<>, please google and read up on it.
			// List "implements" IEnumerable.
			return DB.GetAll<Instrument>();
		}

		//
		//Crud
		//
		public static Instrument Add(Instrument inst)
        {
			DB.Insert(inst);
			// The Insert should have filled in the ID for us with whatever the database created
			return inst;
        }

		//
		//cruD
		//
		public static bool Delete(int id)
        {
			Instrument inst = new Instrument();
			inst.id = id;
			return DB.Delete(inst);
        }

		//
		//crUd: Update
		//
		public static Instrument Update(Instrument inst)
        {
			DB.Update(inst);
			return inst;
        }
	}
}