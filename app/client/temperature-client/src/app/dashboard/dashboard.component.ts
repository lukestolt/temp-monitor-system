import { Component, OnInit } from '@angular/core';
import { startTimeRange } from '@angular/core/src/profile/wtf_impl';
import { CurrentClimateService } from '../services/current-climate.service';


export interface Dashboard {
  temperature: number;
  humidity: number;
  time: string;
  date: string;
}

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

  constructor(private climateService: CurrentClimateService) {
    this.climateService.getCurrentStatus().subscribe(result => {
      this.curTemp = result.temperature;
      this.curHumidity = result.humidity;
    });
  }

  ngOnInit() {
    // starts the clock and gets current date
    this.curTime = '';
    this.startTime();
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
    setInterval(() => this.startTime(), 5000);
  }
}
