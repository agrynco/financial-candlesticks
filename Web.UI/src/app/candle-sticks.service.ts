import {Injectable} from '@angular/core';
import {HttpClient, HttpParams} from '@angular/common/http';
import {Observable} from 'rxjs';
import {CandleSticksGetRequest} from "./candle-sticks-get.request";
import {CandleStick} from "./candle.stick";

@Injectable({
  providedIn: 'root'
})
export class CandleSticksService {
  // Specify the base URL to your API
  private baseUrl = 'http://localhost:5000/api/'; // replace with your API's base URL

  constructor(private http: HttpClient) { }

  getCandleSticks(request?: CandleSticksGetRequest): Observable<CandleSticksGetResponse> {
    let params = new HttpParams();

    if(request) {
      for (let [key, value] of Object.entries(request)) {
        if (value !== undefined && value !== null) {
          params = params.set(key, value);
        }
      }
    }

    return this.http.get<CandleSticksGetResponse>(this.baseUrl + 'candlesticks');
  }
}

export interface CandleSticksGetResponse {
  candleSticks: CandleStick[];
}


