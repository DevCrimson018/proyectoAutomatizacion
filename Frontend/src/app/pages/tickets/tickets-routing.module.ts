import { RouterModule, Routes } from '@angular/router';

import { NgModule } from '@angular/core';
import { TicketsComponent } from './apartado/tickets.component';

const routes: Routes = [
  {
    path: "",
    redirectTo: "login",
    pathMatch: "full"
  }, 
  {
    path: "mytickets",
    component: TicketsComponent
  }, 
  
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class TicketsRoutingModule { }
