import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { DashboardComponent } from './dashboard/dashboard.component';
import { HistoricalComponent } from './historical/historical.component';
import { AppComponent } from './app.component';

const routes: Routes = [
  {path: 'dashboard', component: DashboardComponent},
  {path: '', component: DashboardComponent},
  {path: '**', component: DashboardComponent},
  {path: 'historical', component: HistoricalComponent},
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
