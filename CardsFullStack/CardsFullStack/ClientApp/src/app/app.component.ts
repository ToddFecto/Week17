import { Component } from '@angular/core';
import { Card } from './card';
import { CardApiService } from './card-api.service';
import { Deck } from './deck';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html'
})
export class AppComponent {
  title = 'app';

  theCards?: Card[] = null;
  deck_id?: String = null;
  allDecks: Deck[] = null;

  constructor(private cardapi: CardApiService) {
    cardapi.getAllDecks(
      result => {
        this.allDecks = result;
        console.log('***ALL DECKS***');
        console.log(this.allDecks);
      }
    )
  }

  getDeck() {
    this.cardapi.getDeck(
      result => {
        console.log(result);
        this.deck_id = result[0].deck_id;
        this.theCards = result;
      }
    )
  }

  getTwoCards() {
    this.cardapi.getCards(this.deck_id,
      result => {
        console.log(result);
        this.theCards = result;
      }
    )
  }

  selectDeck(deckid) {
    this.cardapi.getCards(deckid,
      result => {
        console.log(result);
        this.deck_id = result[0].deck_id
        this.theCards = result;
      }
    )
  }
}
