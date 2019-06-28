import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Dashboard } from '../dashboard/dashboard.component';
import { Observable } from 'rxjs';


@Injectable({
  providedIn: 'root'
})
export class CurrentClimateService {
  port = '5001';
  base = 'localhost';
  url = this.base + ':' + this.port ;

  constructor(private http: HttpClient) { }

  getCurrentStatus(): Observable<Dashboard> {
    return this.http.get<Dashboard>(this.url + '/dashboard/getcurrentstatus');
  }

}
