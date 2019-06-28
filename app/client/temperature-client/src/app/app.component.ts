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

  histNavigate(): void {
      console.log('navigating to the hist view');
      this.router.navigateByUrl('/historical');
  }

  dashNavigate(): void {
    console.log('navigating to the dash view');
    this.router.navigateByUrl('/dashboard');
  }

}

