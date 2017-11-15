import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ToastModule } from 'ng2-toastr';
import { SharedModule } from '../shared/shared.module';
import { CarroComponent } from './carro.component';

@NgModule({
  imports: [
    CommonModule,
    SharedModule
  ],
  declarations: [
    CarroComponent
  ],
  exports: [
    CarroComponent
  ]
})
export class CarroModule { }
