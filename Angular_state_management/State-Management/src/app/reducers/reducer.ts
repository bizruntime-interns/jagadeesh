import { Action } from '@ngrx/store'
import { Tutorial } from '../models/model'
import * as TutorialActions from '../action/action'
import { InitialState } from '@ngrx/store/src/models'

const initialState:Tutorial={
    name:"Initail Tutorial",
    url:"https://google.com"
}
export function reducer(state: Tutorial[] = [initialState], action: TutorialActions.Actions) {

    switch(action.type) {
        case TutorialActions.ADD_TUTORIAL:
            return [...state, action.payload];

            case TutorialActions.REMOVE_TUTORIAL:
                const index = action.payload;
                return [...state.slice(0, index), ...state.slice(index + 1)];
        default:
            return state;
    }
}