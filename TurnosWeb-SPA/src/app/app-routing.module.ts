import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AppointmentListComponent } from './appointments/appointment-list.component';
import { NewAppointmentComponent } from './appointments/new-appointment.component';

const routes: Routes = [
  {path: 'appointments', component: AppointmentListComponent},
  {path: 'appointments/create', component: NewAppointmentComponent}

];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
