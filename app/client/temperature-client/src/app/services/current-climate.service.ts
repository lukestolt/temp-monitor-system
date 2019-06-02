import { Injectable } from '@angular/core';
import { HttpClient } from 'selenium-webdriver/http';

@Injectable({
  providedIn: 'root'
})
export class CurrentClimateService {


  //TODO: create api for historical data 


  constructor(private http: HttpClient) { }

  getCurrentStatus(){

  }

}
