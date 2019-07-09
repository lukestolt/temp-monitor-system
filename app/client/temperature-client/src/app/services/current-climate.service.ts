import { Injectable } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';
import { Dashboard } from '../dashboard/dashboard.component';
import { Observable } from 'rxjs';
import { Response } from 'selenium-webdriver/http';

export interface Response {
  response: string;
}

@Injectable({
  providedIn: 'root'
})
export class CurrentClimateService {
  port = '5000';
  base = 'http://10.90.233.6';
  url = this.base + ':' + this.port ;

  constructor(private http: HttpClient) { }

  getCurrentStatus(): Observable<Dashboard> {
    return this.http.get<Dashboard>(this.url + '/dashboard/getcurrentstatus');
  }

  updateCurrentStatus(dm: Dashboard): Observable<Dashboard> {
    return this.http.post<Dashboard>(this.url + '/dashboard/updatecurrentstatus', dm);
  }

  // getHistoricalData(): Observable<Dashboard[]> {
  //   return this.http.get<Dashboard[]>(this.url + '/historical/gethistoricaldata');
  // }

  getHistoricalData(startKey: number, finishKey: number): Observable<Dashboard[]> {
    const paramters =  new HttpParams()
    .set('startKey', startKey + '')
    .set('finishTimeKey', finishKey + '');
    return this.http.get<Dashboard[]>(this.url + '/historical/gethistoricaldata',
                                      {params: paramters});
  }
}
