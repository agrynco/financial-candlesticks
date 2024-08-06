import { Injectable } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class CandleSticksService {
  // Specify the base URL to your API
  private baseUrl = 'http://localhost:5000/api/'; // replace with your API's base URL

  constructor(private http: HttpClient) { }

  getCandleSticks(request?: CandleSticksGetRequest): Observable<any> {
    let params = new HttpParams();

    // Add the properties of the request object to the params
    if (request) {
      for (let key in request) {
        if (request[key] !== undefined && request[key] !== null) {
          params = params.append(key, request[key]);
        }
      }
    }

    return this.http.get(this.baseUrl + 'candlesticks', { params: params });
  }
}

export interface CandleSticksGetRequest {
  startDate?: string;
  endDate?: string;
}

export interface CandleStick {
  close: number;
  closeTime: Date;
  high: number;
  low: number;
  open: number;
  openTime: Date;
}
