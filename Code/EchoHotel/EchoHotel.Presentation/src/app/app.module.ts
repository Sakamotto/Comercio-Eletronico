import { BrowserModule } from '@angular/platform-browser';
import {BrowserAnimationsModule} from '@angular/platform-browser/animations';
import { NgModule } from '@angular/core';
import {FormsModule, ReactiveFormsModule} from '@angular/forms';
import { HttpModule, JsonpModule} from '@angular/http';
import { ToastModule } from 'ng2-toastr/ng2-toastr';

import { AppComponent } from './app.component';
import { HotelModule } from './hotel/hotel.module';
import { PrincipalModule } from './principal/principal.module';
import { routing } from './app.routing';
import { AppConfig } from './App.config';

@NgModule({
  declarations: [
    AppComponent
  ],
  imports: [
    BrowserModule,
    HttpModule,
    HotelModule,
    JsonpModule,
    PrincipalModule,
    BrowserAnimationsModule,
    ReactiveFormsModule,
    FormsModule,
    ToastModule.forRoot(),
    routing
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
