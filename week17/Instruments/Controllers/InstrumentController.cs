using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Instruments.Models;

namespace Instruments.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class InstrumentController : ControllerBase
	{
		// CRUD operations:
		//   Read: Read everything. Don't really need a read individual for this sample

		//
		// Read all
		//
		[HttpGet]
		public IEnumerable<Instrument> GetAll()
		{
			return Instrument.GetAll();
		}

		//
		// Create
		//
		[HttpPost]
		public Instrument Save(Instrument inst)
		{
			//inst.id = Instrument.nextId;
			//Instrument.Instruments.Add(inst);
			//Instrument.nextId++;
			return Instrument.Add(inst);
		}

		//
		// Delete
		//
		[HttpPost("{id}")]
		public bool Delete(int id)
		{
			//int found = -1;
			//for (int i = 0; i < Instrument.Instruments.Count; i++)
			//{
			//	if (Instrument.Instruments[i].id == id)
			//	{
			//		found = i;
			//		break;
			//	}
			//}
			//if (found > -1)
			//{
			//	Instrument.Instruments.RemoveAt(found);
			//	return true;
			//}
			//return false;
			return Instrument.Delete(id);
		}

		//
		//Update (HttpPutAttribute)
		//
		[HttpPut]
		public Instrument Update(Instrument inst)
        {
			return Instrument.Update(inst);
        }

	}
}