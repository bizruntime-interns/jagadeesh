import { wheels } from './../parrts';
import { Component, OnInit,Input } from '@angular/core';


@Component({
  selector: 'app-partdetails',
  templateUrl: './partdetails.component.html',
  styleUrls: ['./partdetails.component.css']
})
export class PartdetailsComponent implements OnInit {

  @Input() parts:wheels;
  constructor() { }

  ngOnInit(): void {
  }

}
