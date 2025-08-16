import { ChangeDetectionStrategy, ChangeDetectorRef, Component, signal } from '@angular/core';
import { OnInit, Inject } from '@angular/core';
import { catchError, finalize, of, throwError } from 'rxjs';
import { EventLogService } from '../../services/EventLog.service';
import { CardModule } from 'primeng/card';
import { TextareaModule } from 'primeng/textarea';
import { FormBuilder, FormGroup, ReactiveFormsModule, Validators, FormsModule } from '@angular/forms';
import { CommonModule } from '@angular/common';
import { FloatLabel } from 'primeng/floatlabel';
import { ButtonModule } from 'primeng/button';
import { TableModule } from 'primeng/table';
import { MessageService } from 'primeng/api';
import { ToastModule } from 'primeng/toast';
import { DatePickerModule } from 'primeng/datepicker';
import { formatDate } from '@angular/common'; // Import formatDate for date formatting
import { TooltipModule } from 'primeng/tooltip';
import { ProgressSpinnerModule } from 'primeng/progressspinner';
import { MessageModule } from 'primeng/message';
import { Select } from 'primeng/select';
import { EventLogTypeService } from '../../services/EventLogType.service';
import { IEventTypes } from '../../interfaces/IEventTypes';



@Component({
  selector: 'app-event-logs',
  imports: [CardModule, TextareaModule, ReactiveFormsModule,
    CommonModule, FloatLabel, ButtonModule, TableModule, ToastModule,
    DatePickerModule, TooltipModule, ProgressSpinnerModule, MessageModule, Select, FormsModule],
  templateUrl: './EventLogs.component.html',
  styleUrl: './EventLogs.component.css',
  providers: [MessageService]
})
export class EventLogsComponent implements OnInit {
  eventLogs: any[] = [];
  form: FormGroup;
  formFilters: FormGroup;
  loading: boolean = false;
  typeFilter: any[] = [
    { id: 1, label: 'Tipo' },
    { id: 2, label: 'Rango de fechas' },
  ]
  tipo = signal<number | null>(null)
  eventLogTypes: IEventTypes[] | undefined;
  selectedEventLogType: number | undefined;


  constructor(
    private eventLogService: EventLogService,
    private eventLogTypeService: EventLogTypeService,
    private fb: FormBuilder,
    private cdr: ChangeDetectorRef,
    private messageService: MessageService
  ) {
    this.form = this.fb.group({
      descripcion: ['', Validators.required]
    });
    this.formFilters = this.fb.group({
      fechaInicio: [null],
      fechaFinal: [null]
    });
  }

  ngOnInit(): void {
    this.loadEventLogs();
    this.loadCboEventTypes();
    this.form.markAllAsTouched();
    this.cdr.markForCheck();
  }

  onEventLogTypeChange(selectedType: any): void {
    this.loading = true;
    this.eventLogService.getEventsByTypes(selectedType).pipe(
      catchError((error) => error.status == 204 ? of([]) : throwError(() => error)),
      finalize(() => {
        this.loading = false;
      })
    ).subscribe((response: any) => {
      this.eventLogs = response;
      this.cdr.markForCheck();
    });
  }

  loadEventLogs(): void {
    this.loading = true;
    this.eventLogService.getEventLogs().pipe(
      catchError((error) => error.status == 204 ? of([]) : throwError(() => error)),
      finalize(() => {
        this.loading = false;
      })
    ).subscribe((response: any) => {
      this.eventLogs = response;
      this.cdr.markForCheck();
    });
  }
  loadCboEventTypes(): void {
    this.loading = true;
    this.eventLogTypeService.getEventLogsTypes().pipe(
      catchError((error) => error.status == 204 ? of([]) : throwError(() => error)),
      finalize(() => {
        this.loading = false;
      })
    ).subscribe((response: any) => {
      this.eventLogTypes = response;
      this.cdr.markForCheck();
    });
  }
  onDateChange(): void {
    const fechaInicio = formatDate(this.formFilters.get('fechaInicio')?.value, 'MM/dd/yyyy', 'en-US');
    const fechaFinal = formatDate(this.formFilters.get('fechaFinal')?.value, 'MM/dd/yyyy', 'en-US');
    const yearIni = new Date(this.formFilters.get('fechaInicio')?.value).getFullYear();
    const yearFin = new Date(this.formFilters.get('fechaFinal')?.value).getFullYear();
    if (fechaInicio && fechaFinal && fechaInicio <= fechaFinal && yearIni !== 1969 && yearFin !== 1969) {
      this.loading = true;
      this.eventLogService.getEventsDates(fechaInicio, fechaFinal).pipe(
        catchError((error) => error.status == 204 ? of([]) : throwError(() => error)),
        finalize(() => {
          this.loading = false;
        })
      )
        .subscribe((response: any) => {
          this.eventLogs = response;
          this.cdr.markForCheck();
        });
    } else {
      this.messageService.add({
        severity: 'warn',
        summary: 'Advertencia',
        detail: 'La fecha inicial y la fecha final son obligatorias, y la fecha inicial no puede ser mayor que la fecha final.'
      });
      this.cdr.markForCheck();
    }
  }
  onRefresh(): void {
    this.formFilters.reset();
    this.selectedEventLogType = undefined;
    this.tipo.set(null);
    this.loadEventLogs();
  }

  onSave(): void {
    if (this.form.valid) {
      this.loading = true;
      this.eventLogService.addEventLog(this.form.value).subscribe({
        next: (response) => {
          this.loadEventLogs();
          this.form.reset();
          this.messageService.add({
            severity: 'success',
            summary: 'Éxito',
            detail: 'Evento guardado correctamente'
          });
          this.cdr.markForCheck();
        },
        error: (error) => {
          console.error('Error adding event log:', error);
          this.messageService.add({
            severity: 'error',
            summary: 'Error',
            detail: error.error?.message || 'Error al guardar el evento'
          });
          this.cdr.markForCheck();
        },
        complete: () => {
          this.loading = false;
        }
      });
    } else {
      this.messageService.add({
        severity: 'warn',
        summary: 'Advertencia',
        detail: 'Por favor completa todos los campos requeridos'
      });
      this.cdr.markForCheck();
    }
  }
}
