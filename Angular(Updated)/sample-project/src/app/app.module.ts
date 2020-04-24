import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { PartsComponent } from './parts/parts.component';
import {FormsModule} from '@angular/forms';
import { PartdetailsComponent } from './partdetails/partdetails.component';
import { MessagesComponent } from './messages/messages.component';
import { DashboardComponent } from './dashboard/dashboard.component';
import { ImagesComponent } from './images/images.component';

@NgModule({
  declarations: [
    AppComponent,
    PartsComponent,
    PartdetailsComponent,
    MessagesComponent,
    DashboardComponent,
    ImagesComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    FormsModule,
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
