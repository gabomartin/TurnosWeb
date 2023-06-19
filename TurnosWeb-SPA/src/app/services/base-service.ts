import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class ServiceBase {

  baseEndpoint : string = "https://localhost:7003";
  http : HttpClient;

  constructor (http : HttpClient) {
    this.http = http;
  }
   
}
