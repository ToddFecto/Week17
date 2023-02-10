import { HttpClient } from '@angular/common/http';
import { Component, EventEmitter, Input, Output } from '@angular/core';
import { Instrument } from '../instrument';

@Component({
  selector: 'app-one-inst',
  templateUrl: './one-inst.component.html',
  styleUrls: ['./one-inst.component.css']
})
/** OneInst component*/
export class OneInstComponent {

  @Input() theinst: Instrument = null;
  @Output() deleteevent: EventEmitter<Number> = new EventEmitter<Number>();
  @Output() updateevent: EventEmitter<Instrument> = new EventEmitter<Instrument>();

  inEditMode: Boolean = false;
  editKind: String = '';
  editColor: String = '';

  /** OneInst ctor */
  constructor(private http: HttpClient) {

  }

  deleteMe() {
    this.deleteevent.emit(this.theinst.id);
  }

  showEditForm() {
    this.editKind = this.theinst.kind;
    this.editColor = this.theinst.color;
    this.inEditMode = true;
  }

  cancelEdit() {
    this.inEditMode = false;
  }

  saveChanges() {
    /*let newobj: Instrument = {
      id: this.theinst.id,
      kind: this.editKind,
      color: this.editColor
    };
    this.updateevent.emit(newobj);*/
    this.theinst.kind = this.editKind;
    this.theinst.color = this.editColor;
    this.inEditMode = false;
    this.updateevent.emit(this.theinst);
  }
}
