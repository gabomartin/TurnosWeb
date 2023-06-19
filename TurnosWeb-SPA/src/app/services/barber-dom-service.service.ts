import { Injectable } from '@angular/core';
import { ServiceBase } from './base-service';
import { Observable } from 'rxjs';
import { Barber } from '../models/Barber';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class BarberDomServiceService extends ServiceBase {

  constructor (http : HttpClient){
    super(http)
  }

  public GetAll() : Observable<Barber[]> {
    return this.http.get<Barber[]>(this.baseEndpoint + "/Barber")
  }

}
