import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import {FormsModule, ReactiveFormsModule} from '@angular/forms';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { ReservaComponent } from './reserva.component';
import { SharedModule } from '../shared/shared.module';
import { ReservaConfirmarComponent } from './reserva-confirmar.component';

@NgModule({
  imports: [
    CommonModule,
    ReactiveFormsModule,
    FormsModule,
    SharedModule
  ],
  declarations: [
    ReservaComponent,
    ReservaConfirmarComponent
  ],
  exports: [
    ReservaComponent,
    ReservaConfirmarComponent
  ]
})
export class ReservaModule { }
