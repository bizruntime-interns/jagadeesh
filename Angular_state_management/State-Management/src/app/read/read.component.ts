
import { Component, OnInit } from '@angular/core';
import { Store } from '@ngrx/store';
import { Tutorial } from '../models/model';
import * as TutorialActions from '../action/action';
import { AppState } from './../app.state';
import { Observable } from 'rxjs';

@Component({
  selector: 'app-read',
  templateUrl: './read.component.html',
  styleUrls: ['./read.component.css']
})
export class ReadComponent implements OnInit {

  tutorials: Observable<Tutorial[]>;


  constructor(private store: Store<AppState>) { 
    this.tutorials = store.select('tutorial');
  }
  deleteTutorial(index){
    this.store.dispatch(new TutorialActions.RemoveTutorial(index))
  }

  ngOnInit() {}

}
