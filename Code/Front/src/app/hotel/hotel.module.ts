import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import {
  MatCardModule, MatGridListModule, MatButtonModule, MatCheckboxModule, MatSnackBarModule
  } from '@angular/material';

import { HotelComponent } from './hotel.component';
import { ToastModule } from 'ng2-toastr';
import { SharedModule } from '../shared/shared.module';

@NgModule({
  imports: [
    CommonModule,
    MatCardModule,
    MatButtonModule,
    MatGridListModule,
    MatCheckboxModule,
    MatSnackBarModule,
    SharedModule
  ],
  declarations: [
    HotelComponent
  ],
  exports: [
    HotelComponent
  ]
})
export class HotelModule { }
