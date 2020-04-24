import { wheels} from './../parrts';
import { ShopserviceService } from './../shopservice.service';
import { Engines } from './../engine';
import { Component, OnInit } from '@angular/core';



@Component({
  selector: 'app-parts',
  templateUrl: './parts.component.html',
  styleUrls: ['./parts.component.css']
})
export class PartsComponent implements OnInit {

  parts:wheels[];
  selectedpart:wheels;


  
  constructor(private ShopserviceService:ShopserviceService) { }

  ngOnInit() {
    this.getparts();
  }
  onSelect(part:wheels):void{
    this.selectedpart=part;
  }
  getparts():void{
    this.ShopserviceService.getparts().subscribe(parts=>this.parts=parts)
  }

}
