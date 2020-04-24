import { PartsComponent } from './parts/parts.component';
import { NgModule, Component } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';



const routes: Routes = [{path:'wheel',component:PartsComponent},
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})

export class AppRoutingModule { }
