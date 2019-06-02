import { Component, OnInit } from '@angular/core';
import { startTimeRange } from '@angular/core/src/profile/wtf_impl';

@Component({
  selector: 'app-dashboard',
  templateUrl: './dashboard.component.html',
  styleUrls: ['./dashboard.component.css']
})
export class DashboardComponent implements OnInit {

  curTime: string;
  curDate: string;
  curTemp: number;
  curHumidity: number;

  constructor() { }

  ngOnInit() {
    // starts the clock and gets current date
    this.startTime();

    // TODO: populate the temp and humidity from the server
  }

  

  /**
   * updates the time
   */
  startTime(): void {
    const today = new Date();
    const hours = (today.getHours() % 12) + '';


    const minutesNum = today.getMinutes();
    let minutes = minutesNum + '';
    if (minutesNum <= 9) {
      minutes = '0' + minutesNum;
    }

    this.curTime = hours + ':' + minutes;
    this.curDate = (today.getMonth() + 1) + '/' + today.getDate() + '/' + today.getFullYear();
    setTimeout(this.startTime, 2000);
  }
}
