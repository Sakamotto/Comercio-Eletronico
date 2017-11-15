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
import { ReservaComponent } from './reserva/reserva.component';
import { ReservaModule } from './reserva/reserva.module';
import { AcomodacaoComponent } from './acomodacao/acomodacao.component';
import { LoginComponent } from './login/login.component';
import { CarroModule } from './carro/carro.module';

@NgModule({
  declarations: [
    AppComponent,
    AcomodacaoComponent,
    LoginComponent
  ],
  imports: [
    BrowserModule,
    HttpModule,
    HotelModule,
    JsonpModule,
    PrincipalModule,
    ReservaModule,
    CarroModule,
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
