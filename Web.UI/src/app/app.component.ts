import {Component, OnInit} from '@angular/core';
import { RouterOutlet } from '@angular/router';
import {CandleSticksGetResponse, CandleSticksService} from "./candle-sticks.service";
import {CandleStick} from "./candle.stick";
import {DatePipe, NgClass, NgForOf} from "@angular/common";

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [RouterOutlet, NgForOf, NgClass, DatePipe],
  templateUrl: './app.component.html',
  styleUrl: './app.component.css'
})
export class AppComponent implements OnInit{
  title = 'Web.UI';
  candleSticks: CandleStick[] = [];

  constructor(private _candleSticksService: CandleSticksService) {
  }

  ngOnInit(): void {
    this._candleSticksService.getCandleSticks().subscribe(
      (data: CandleSticksGetResponse) => {
        this.candleSticks = data.candleSticks;
        console.log('Data: ', data);
      },
      error => {
        console.error('Error: ', error);
      });
    }
}
