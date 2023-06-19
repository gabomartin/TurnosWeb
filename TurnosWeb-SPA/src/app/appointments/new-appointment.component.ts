import { Component, OnInit } from '@angular/core';
import { Barber } from '../models/Barber';
import { BarberDomServiceService } from '../services/barber-dom-service.service';

@Component({
  templateUrl: './new-appointment.component.html',
  styleUrls: ['./new-appointment.component.less']
})
export class NewAppointmentComponent implements OnInit {

  barbers: Barber[] = [];

  constructor(private _barberDomService : BarberDomServiceService) { }

  ngOnInit(): void {
    this._barberDomService.GetAll().subscribe(
      data => this.barbers = data as Barber[]
    )
  }

}
