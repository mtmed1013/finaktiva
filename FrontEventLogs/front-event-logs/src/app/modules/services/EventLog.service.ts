import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { API_BASE_URL } from '../../constants';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class EventLogService {
  urlBase: string = API_BASE_URL + 'EventLogs/';
  constructor(private http: HttpClient) { }

  getEventLogs(): Observable<any> {
    return this.http.get(this.urlBase);
  }

  addEventLog(eventLog: any): Observable<any> {
    return this.http.post(this.urlBase, eventLog);
  }

  getEventsDates(fechaInicio: string, fechaFinal: string): Observable<any> {
    return this.http.post(`${this.urlBase}dates`, { "fechaInicial": fechaInicio, "fechaFinal": fechaFinal });
  }
  getEventsByTypes(tipo: string): Observable<any> {
    return this.http.get(`${this.urlBase}types/${tipo}`);
  }

}
