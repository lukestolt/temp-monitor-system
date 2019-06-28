import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppComponent } from './app.component';
import { DashboardComponent } from './dashboard/dashboard.component';
import { HistoricalComponent } from './historical/historical.component';
import { RouterModule, Routes } from '@angular/router';
import { HttpClientModule } from '@angular/common/http';

const routes: Routes = [
  {path: 'dashboard', component: DashboardComponent},
  {path: '', component: DashboardComponent},
  {path: '**', component: DashboardComponent},
  {path: 'historical', component: HistoricalComponent},
];

@NgModule({
  declarations: [
    AppComponent,
    DashboardComponent,
    HistoricalComponent
  ],
  imports: [
    BrowserModule,
    HttpClientModule,
    RouterModule.forRoot([
    {path: 'dashboard', component: DashboardComponent},
    {path: '', component: DashboardComponent},
    // {path: '**', component: HistoricalComponent},
    {path: 'historical', component: HistoricalComponent}]
    )
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
