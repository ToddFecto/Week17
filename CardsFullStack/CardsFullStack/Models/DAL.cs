using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Dapper;
using Dapper.Contrib.Extensions;
using MySql.Data.MySqlClient;

namespace CardsFullStack.Models
{
	//
	// IMPORTANT!!!
	//    1. Some of the Http stuff was moved to a NuGet package!!
	//      You need to install the NuGet package "Microsoft.AspNet.WebApi.Client"!!!
	//    2. Some students have used remote APIs that sometimes time out.

	public class DAL
	{
		public static MySqlConnection DB;

		//=================================================
		//
		//    HIGH LEVEL DB HELPER FUNCTIONS
		//
		//    Ideally, this section is the ONLY place where
		//       DeckResponse and CardResponse classes are used.
		//    The rest of the app uses Deck and Card classes.
		//
		//=================================================

		// Initialize a deck
		//    Get back a deck from the API
		//    Save the deck into our own DB
		//    Draw two cards
		//    Save those cards in our own DB
		//    Return those cards

		// Note: When building an async function, wrap your return type inside Task<  ...  >
		public static async Task<IEnumerable<Card>> InitializeDeck()
		{

			// Step 1: Call the API for a new shuffled deck. Grab the deck_id from what we get back

			HttpClient client = new HttpClient();
			client.BaseAddress = new Uri("https://deckofcardsapi.com");
			var response = await client.GetAsync("/api/deck/new/shuffle/?deck_count=1");
			DeckResponse deckresp = await response.Content.ReadAsAsync<DeckResponse>();

			// Step 2: Save the deck into the DB (we have a function that does that down below)

			Deck mydeck = saveDeck(deckresp.deck_id, "user100");

			// Step 3: Call the API to get two cards for that deck

			//response = await client.GetAsync($"https://deckofcardsapi.com/api/deck/{mydeck.deck_id}/draw/?count=2");
			//DeckResponse deckresp2 = await response.Content.ReadAsAsync<DeckResponse>();

			//// Step 4: Save those cards into the DB (we have a function that does that)

			//foreach (CardResponse cardresp in deckresp2.cards)
			//{
			//	saveCard(mydeck.deck_id, cardresp.image, cardresp.code, "user100");
			//}

			//// Step 5: Return that list of Card instances (not a list of CardResponse instances)
			//// We have a function for that!

			//return getCardsForDeck(mydeck.deck_id);
			return await DrawTwoCards(mydeck.deck_id);
		}

		// Get More Cards
		// (Already wrote this in InitializeDeck function, so moved it here --jeffc)
		public static async Task<IEnumerable<Card>> DrawTwoCards(string deck_id)
		{
			HttpClient client = new HttpClient();
			client.BaseAddress = new Uri("https://deckofcardsapi.com");
			var response = await client.GetAsync($"https://deckofcardsapi.com/api/deck/{deck_id}/draw/?count=2");
			DeckResponse deckresp2 = await response.Content.ReadAsAsync<DeckResponse>();

			// Step 4: Save those cards into the DB (we have a function that does that)

			foreach (CardResponse cardresp in deckresp2.cards)
			{
				saveCard(deck_id, cardresp.image, cardresp.code, "user100");
			}

			// Step 5: Return that list of Card instances (not a list of CardResponse instances)
			// We have a function for that!

			return getCardsForDeck(deck_id);
		}

		//=================================================
		//
		//    LOWER LEVEL DB METHODS
		//    The code below has NO API CALLS (and therefore no knowledge of the API classes)
		//       In other words, the code below will not use DeckResponse or CardResponse
		//       (We call this "Separation of Concerns")
		//
		//=================================================

		// Add a new deck to the Deck table
		public static Deck saveDeck(string deck_id, string username)
		{
			Deck theDeck = new Deck() { deck_id = deck_id, username = username, created_at = DateTime.Now };
			DB.Insert(theDeck);
			return theDeck;
		}

		// Get the latest deck from the Deck table
		public static Deck getLatestDeck()
		{
			// To make this work we have to also add in the using statement for Dapper itself.
			IEnumerable<Deck> result = DB.Query<Deck>("select * from Deck order by created_at desc limit 1");
			if (result.Count() == 0)
			{
				return null;
			}
			{
				return result.First();
			}
		}

		public static IEnumerable<Deck> getAllDecks()
		{
			return DB.GetAll<Deck>();
		}

		// Save a set of cards to the Card table for a particular deck
		public static void saveCards(IEnumerable<Card> cards)
		{
			foreach (Card card in cards)
			{
				DB.Insert(card);
			}
		}

		// Save a single card
		public static Card saveCard(string deck_id, string image, string cardcode, string username)
		{
			Card thecard = new Card()
			{
				deck_id = deck_id,
				image = image,
				cardcode = cardcode,
				username = username,
				created_at = DateTime.Now
			};
			DB.Insert(thecard);
			return thecard;
		}

		// Read all the current cards in a particular deck

		public static IEnumerable<Card> getCardsForDeck(string deck_id_param)
		{
			var p = new { deck_id = deck_id_param };
			IEnumerable<Card> result = DB.Query<Card>("select * from Card where deck_id = @deck_id", p);
			return result;
		}
	}
}