/// <reference path="../../../../node_modules/@types/jasmine/index.d.ts" />
import { TestBed, async, ComponentFixture, ComponentFixtureAutoDetect } from '@angular/core/testing';
import { BrowserModule, By } from "@angular/platform-browser";
import { OneInstComponent } from './one-inst.component';

let component: OneInstComponent;
let fixture: ComponentFixture<OneInstComponent>;

describe('OneInst component', () => {
  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [OneInstComponent],
      imports: [BrowserModule],
      providers: [
        { provide: ComponentFixtureAutoDetect, useValue: true }
      ]
    });
    fixture = TestBed.createComponent(OneInstComponent);
    component = fixture.componentInstance;
  }));

  it('should do something', async(() => {
    expect(true).toEqual(true);
  }));
});
