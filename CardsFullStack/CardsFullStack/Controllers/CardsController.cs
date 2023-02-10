using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CardsFullStack.Models;

namespace CardsFullStack.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class CardsController : ControllerBase
	{

		[HttpGet("deck")]
		public async Task<IEnumerable<Card>> GetDeck()
		{
			return await DAL.InitializeDeck();
		}

		[HttpGet("cards/{id}")]
		public async Task<IEnumerable<Card>> GetCards(string id)
		{
			return await DAL.DrawTwoCards(id);
		}

		[HttpGet("decks")]
		public IEnumerable<Deck> GetDecks()
		{
			return DAL.getAllDecks();
		}

		[HttpGet("test")]
		public async Task<IEnumerable<Card>> runtest()
		{
			return await DAL.InitializeDeck();
		}
	}
}