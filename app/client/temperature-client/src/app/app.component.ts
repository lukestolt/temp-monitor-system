import { Component } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  title = 'temperature-client';

  constructor(private router: Router) {
    //
  }

  showHist(): void {
      console.log('navigating to the hist view');
      this.router.navigateByUrl('/historical');
  }

  showDash(): void {
    console.log('navigating to the hist view');
    this.router.navigateByUrl('/dashboard');
  }

}

