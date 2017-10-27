import {ModuleWithProviders} from '@angular/core';
import {Routes, RouterModule} from '@angular/router';

import { PrincipalComponent } from './principal/principal.component';
import { HotelComponent } from './hotel/hotel.component';

const APP_ROUTES: Routes = [
    {path: 'hoteis', component: HotelComponent},
    {path: '', component: PrincipalComponent}
];

// tslint:disable-next-line:eofline
export const routing: ModuleWithProviders = RouterModule.forRoot(APP_ROUTES);