
import { MessagesService } from './messages.service';
import { Engines } from './engine';
import { wheels } from './parrts';
import { Injectable } from '@angular/core';
import {Observable, of } from 'rxjs';



@Injectable({
  providedIn: 'root'
})
export class ShopserviceService {
  
  

  constructor(private messagesService: MessagesService) { }
  getparts(): Observable <wheels[]>{
    this.messagesService.add('parts Service : fetched parts from the list')
    return of (Engines);
}

}