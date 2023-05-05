import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { AppointmentViewModel } from '../models/Appointment';
import { DatePipe } from '@angular/common';



@Component({
  selector: 'app-appointment',
  templateUrl: './appointment-list.component.html',
  styleUrls: ['./appointment-list.component.less']
})
export class AppointmentListComponent implements OnInit {

  constructor(private _http: HttpClient) { }

  appointments: AppointmentViewModel[] = [];

  ngOnInit(): void {
    this._http.get("https://localhost:7003/Appointments").subscribe(res=>
        this.appointments = res as AppointmentViewModel[]
    );
  }

}
