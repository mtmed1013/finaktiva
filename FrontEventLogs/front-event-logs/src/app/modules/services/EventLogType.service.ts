import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { API_BASE_URL } from '../../constants';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class EventLogTypeService {
  urlBase: string = API_BASE_URL + 'EventLogsType/';
  constructor(private http: HttpClient) { }

  getEventLogsTypes(): Observable<any> {
    return this.http.get(this.urlBase);
  }

}
