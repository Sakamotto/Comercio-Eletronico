import { BrowserModule } from '@angular/platform-browser';
import {BrowserAnimationsModule} from '@angular/platform-browser/animations';
import { NgModule } from '@angular/core';
import {FormsModule, ReactiveFormsModule} from '@angular/forms';
import { HttpModule, JsonpModule} from '@angular/http';
import { ToastModule } from 'ng2-toastr/ng2-toastr';
import { SpinnerComponent } from '../componentes/spinner/spinner.component';
import { RouterModule } from '@angular/router';


@NgModule({
  declarations: [
    SpinnerComponent
  ],
  exports: [
    SpinnerComponent,
    RouterModule,
    ToastModule
  ],
  imports: [
    BrowserModule,
    HttpModule,
    RouterModule,
    ToastModule
  ],
  providers: []
})
export class SharedModule { }
