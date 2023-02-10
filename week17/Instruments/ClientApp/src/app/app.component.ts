import { HttpClient } from '@angular/common/http';
import { Component } from '@angular/core';
import { Instrument } from './instrument';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html'
})
export class AppComponent {
  title = 'app';
  myInsts: Instrument[] = [];
  newKind = '';
  newColor = '';

  constructor(private http: HttpClient) {
    this.getList();
  }

  addNew() {
    let inst = {
      kind: this.newKind,
      color: this.newColor
    };

    // Allows the the use of the Debugger in the browser console.
    debugger;

    //this.myInsts.push(inst);
    //console.log(this.myInsts);
    this.http.post<Instrument>('/api/instrument', inst).subscribe(
      (result) => {
        // Work with the variables only. The textboxes
        // will automatically reflect the value of the variable.
        this.newKind = '';
        this.newColor = '';
        this.getList();
      }
    );
  }

  getList() {
    this.http.get<Instrument[]>('/api/instrument').subscribe(
      (result) => {
        // Replace the existing list with a new one
        this.myInsts = result;
        console.log(this.myInsts);
      }
    );
  }

  doDelete(id) {
    this.http.post<Instrument>(`/api/instrument/${id}`, null).subscribe(
      (result) => {
        this.getList();
      }
    );
  }

  doUpdate(inst: Instrument) {
    this.http.put<Instrument>('/api/instrument', inst).subscribe(
      (result) => {
        //this.getList();
      }
    )
  }

  test() {
    alert('Replacing the list with an empty one');
    this.myInsts = [];
  }
}
