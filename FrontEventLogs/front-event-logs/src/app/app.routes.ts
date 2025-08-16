import { Routes } from '@angular/router';
import { HomeComponent } from './modules/pages/home/home.component';
import { EventLogsComponent } from './modules/pages/EventLogs/EventLogs.component';

export const routes: Routes = [
    { path: '', redirectTo: '/home', pathMatch: 'full' },
    { path: 'home', component: HomeComponent },
    { path: 'event-logs', component: EventLogsComponent },
];
