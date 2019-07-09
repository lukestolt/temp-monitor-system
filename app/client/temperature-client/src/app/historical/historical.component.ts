import { Component, OnInit, ViewChild, ElementRef } from '@angular/core';
import { CurrentClimateService } from '../services/current-climate.service';
import CanvasJS from 'canvasjs';
import { Dashboard } from '../dashboard/dashboard.component';
import { TimeService } from '../services/time.service';


@Component({
  selector: 'app-historical',
  templateUrl: './historical.component.html',
  styleUrls: ['./historical.component.css']
})
export class HistoricalComponent implements OnInit {
  @ViewChild('startDate') startDateElement: ElementRef;
  startTimeKey: number;
  finishTimeKey: number;

  title = 'Historical Data';
  type = 'LineChart';
  data = [['0', 0, 0]];
  width = 800;
  height = 300;
  columnNames = [ 'Time', 'Temperature', 'Humidity'];
  options = {
   tooltip: {
     isHtml: true
    },
   animation: {
     duration: 2000,
     easing: 'inAndOut',
     startup: true
    }
};
  constructor(private climateService: CurrentClimateService, private timeService: TimeService) { }

  ngOnInit() {
    console.log(this.startDateElement);

  }

  exportClick() {
    console.log(this.startDateElement);
    if (this.startTimeKey == null) {
      console.error('Start date has not been selected');
      return;
    }

    if (this.finishTimeKey == null) {
      console.error('Finish date has not been selected');
      return;
    }

    this.climateService.getHistoricalData(this.startTimeKey, this.finishTimeKey).subscribe(result => {
      const chartData = [];

      result.forEach(dashboard => {
        chartData.push([dashboard.time, dashboard.temperature, dashboard.humidity]);
      });

      this.data = chartData;
      console.log(this.data);
    });
  }

  startDateChange(event: any): void {
    // TODO: need more user input validation so that the year is in the correct range
    // and that the startDate < finishDate
    console.log(event);
    this.startTimeKey = this.timeService.createKey(event.target.value);
  }

  finishDateChange(event: any): void {
    console.log(event);
    this.finishTimeKey = this.timeService.createKey(event.target.value);
  }
}
