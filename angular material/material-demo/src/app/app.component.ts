import { DialogExampleComponent } from './dialog-example/dialog-example.component';
import { Component,OnInit } from '@angular/core';
import {FormControl} from '@angular/forms';
import {observable, Observable, from} from 'rxjs';
import {map,startWith} from 'rxjs/Operators';
import {MatDialog} from '@angular/material/dialog';


@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit {
  constructor(public dialog:MatDialog){}
  title = 'material-demo';
  notifications=0;
  showSpinner=false;
  loadData(){
    this.showSpinner=true;
    setTimeout(()=>{
      this.showSpinner=false;
    },5000);
  }
  opened=false;
  log(state){
    console.log(state)
  }
  logChange(index){
    console.log(index)
  }
  selectedValue:string;
  options:string[]=['angular','React','Vue'];
  objectOptions:[{name:"Angular"},{name:"React"},{name:"Native"}];
  myControl=new FormControl();
  filteredOptions:Observable<string[]>;
  ngOnInit() {
    this.filteredOptions=this.myControl.valueChanges.pipe(
      startWith(''),
      map(value=>this._filter(value))
    );
  }
  private _filter(value:string): string[]{
    const filetrValue=value.toLowerCase()
    return this.options.filter(option=>option.toLowerCase().includes(filetrValue))
  }
  displayFn(subject){
    return subject ? subject.name  : undefined;
  }
  openDialog(){
    this.dialog.open(DialogExampleComponent);
  }

  
  
}