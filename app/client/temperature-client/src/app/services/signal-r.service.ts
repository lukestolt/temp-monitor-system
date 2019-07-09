import { Injectable } from '@angular/core';
import * as signalR from '@aspnet/signalr';

export interface SignalRModel
{
  temperature: number;
  humidity: number;
}

@Injectable({
  providedIn: 'root'
})
export class SignalRService {
  public data: SignalRModel;

  private hubConnection: signalR.HubConnection;

  public startConnection = () => {
      this.hubConnection = new signalR.HubConnectionBuilder().withUrl('http://10.90.233.6:5000/climatehub').build();

      this.hubConnection
      .start()
      .then(() => console.log('Connection started'))
      .catch(err => console.log('Error while starting connection: ' + err));
  }

  public addTemperatureDataListener = () => {
      this.hubConnection.on('transfertemperaturedata', (data) => {
        this.data = data;
        console.log(data);
      });
  }

  constructor() { }
}
