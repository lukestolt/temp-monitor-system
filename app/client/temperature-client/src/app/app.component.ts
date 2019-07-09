import { Component, OnInit } from '@angular/core';
import { SignalRService } from './services/signal-r.service';
import { HttpClient } from '@angular/common/http';


export interface Message {
  severity: string;
  summary: string;
}
@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit {

  constructor(public signalRService: SignalRService, private http: HttpClient) {
    //
  }

  ngOnInit(): void {
    // this.signalRService.startConnection();
    // this.signalRService.addTemperatureDataListener();
    // this.startHttpRequest();
  }

  private startHttpRequest = () => {
    this.http.get('http://10.90.233.6:5000/climate')
      .subscribe(res => {
        console.log(res);
      });
  }

  // histNavigate(): void {
  //     console.log('navigating to the hist view');
  //     this.router.navigateByUrl('/historical');
  // }

  // dashNavigate(): void {
  //   console.log('navigating to the dash view');
  //   this.router.navigateByUrl('/dashboard');
  // }

}

