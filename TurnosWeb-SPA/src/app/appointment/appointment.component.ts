import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { Appointment } from '../models/Appointment';



@Component({
  selector: 'app-appointment',
  templateUrl: './appointment.component.html',
  styleUrls: ['./appointment.component.less']
})
export class AppointmentComponent implements OnInit {

  constructor(private _http: HttpClient) { }

  data: Appointment[] = [];

  displayedColumns: string[] = ['appointmentId', 'barberId', 'clientName', 'appointmentDate', 'stateId','totalCharged'];

  ngOnInit(): void {
    this._http.get("https://localhost:7003/Appointments").subscribe(res=>
        this.data = res as Appointment[]
    );
  }

}
