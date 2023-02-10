import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Card } from './card';
import { Deck } from './deck';

@Injectable()
export class CardApiService {
  constructor(private http: HttpClient) {
  }
  getDeck(cb) {
    this.http.get<Card[]>('/api/cards/deck').subscribe(
      result => {
        cb(result);
      }
    );
  }

  getCards(deck_id, cb) {
    this.http.get<Card[]>(`/api/cards/cards/${deck_id}`).subscribe(
      result => {
        cb(result);
      }
    );
  }

  getAllDecks(cb) {
    this.http.get<Deck[]>('/api/cards/decks').subscribe(
      result => {
        cb(result);
      }
    );
  }
}
