import { CommonModule } from "@angular/common";
import { NgModule } from "@angular/core";
import { TicketsComponent } from "./apartado/tickets.component";
import { TicketsRoutingModule } from "./tickets-routing.module";

@NgModule({
    declarations: [
        TicketsComponent
    ],
    imports: [
      CommonModule,
      TicketsRoutingModule
    ]
  })

export class TicketsModule{}