import { CommonModule } from '@angular/common';
import { Component, signal } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { MegaMenuItem } from 'primeng/api';
import { ButtonModule } from 'primeng/button';
import { MegaMenu } from 'primeng/megamenu';

@Component({
  selector: 'app-root',
  imports: [RouterOutlet, ButtonModule, CommonModule, MegaMenu],
  templateUrl: './app.html',
  styleUrl: './app.scss'
})
export class App {
  protected readonly title = signal('front-event-logs');
  items: MegaMenuItem[] | undefined;
  ngOnInit(): void {
    this.items = [
      {
        label: 'Inicio',
        icon: 'pi pi-home',
        routerLink: '/'
      },
      {
        label: 'Event logs',
        icon: 'pi pi-box',
        routerLink: '/event-logs'
      }
    ];
  }
}
