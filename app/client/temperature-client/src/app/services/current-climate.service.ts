import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Dashboard } from '../dashboard/dashboard.component';
import { Observable } from 'rxjs';


@Injectable({
  providedIn: 'root'
})
export class CurrentClimateService {
  port = '5000';
  base = 'http://10.90.232.1';
  url = this.base + ':' + this.port ;

  constructor(private http: HttpClient) { }

  getCurrentStatus(): Observable<Dashboard> {
    return this.http.get<Dashboard>(this.url + '/dashboard/getcurrentstatus');
  }

  updateCurrentStatus(dm: Dashboard): Observable<Dashboard> {
    return this.http.post<Dashboard>(this.url + '/dashboard/updatecurrentstatus', dm);
  }

}
