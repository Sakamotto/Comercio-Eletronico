import {ModuleWithProviders} from '@angular/core';
import {Routes, RouterModule} from '@angular/router';

import { PrincipalComponent } from './principal/principal.component';
import { HotelComponent } from './hotel/hotel.component';
import { ReservaComponent } from './reserva/reserva.component';
import { ReservaConfirmarComponent } from './reserva/reserva-confirmar.component';
import { CarroComponent } from './carro/carro.component';

const APP_ROUTES: Routes = [
    {path: 'hoteis', component: HotelComponent},
    {path: 'reservas', component: ReservaComponent},
    {path: 'reservas/:id', component: ReservaComponent},
    {path: 'confirmar-reserva', component: ReservaConfirmarComponent},
    {path: 'confirmar-reserva/:id', component: ReservaConfirmarComponent},
    {path: 'oferta-carros', component: CarroComponent},
    {path: '', component: PrincipalComponent}
];

// tslint:disable-next-line:eofline
export const routing: ModuleWithProviders = RouterModule.forRoot(APP_ROUTES);