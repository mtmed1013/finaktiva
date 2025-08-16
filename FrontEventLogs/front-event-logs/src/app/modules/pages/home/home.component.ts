import { ChangeDetectionStrategy, Component } from '@angular/core';
import { logo } from './../../../constants';

@Component({
  selector: 'app-home',
  imports: [],
  templateUrl: './home.component.html',
  styleUrl: './home.component.css',
})
export class HomeComponent {
  logo = logo;
}
