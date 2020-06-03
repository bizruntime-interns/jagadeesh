

// const observable = new Observable(subscriber => {
//   subscriber.next(1);
//   subscriber.next(2);
//   subscriber.next(3);
//   setTimeout(() => {
//     subscriber.next(4);
//     subscriber.complete();
//   }, 1000);
// });

// const observable=rxjs.Observable.create(observer=>{
//   observer.next('Hello')
//   observer.next('World')
// })

// observable.subscribe(val=>print(val))
// const clicks=rxjs.Observable.fromEvent(document,'click')
// clicks.subscribe(click=>console.log(click))

function print(val){
  let el=document.createElement('p');
  el.innerText=val;
  document.body.appendChild(el)
}

// const promise = new Promise((resolve, reject) => { 
//   setTimeout(() => {
//       resolve('resolved!')
//   }, 1000)
// });



// const obsvPromise = rxjs.observable.fromPromise(promise)

// obsvPromise.subscribe(result => console.log(result) ) 


// PROMISE
const myPromise = new Promise((resolve) => {
  console.log('Hello from Promise');
  resolve(1);
});
myPromise.then(o => console.log(o));
myPromise.then(o => console.log(o));
//OBSERVABLE 
const myObservable = rxjs.Observable.create((observer) => {
  console.log('Hello from Observable');
  observer.next(1);
  observer.next(2);
  observer.next(3);
});
myObservable.subscribe(o => console.log(o));
// myObservable.subscribe(o => console.log(o));

const myObservable=rxjs.Observable.create((observer)=>{
  const intervalId=setInterval(() => {
    observer.next('Hello');
  }, 1000);
  return()=>{clearInterval(intervalId);
};
});
const mySubscription=myObservable.subscribe(O=>console.log(O));
setTimeout(()=>mySubscription.unsubscribe(),5000);

//reducers
const reducer = (state = 0, action) => {
  switch (action.type) {
    case 'INCREMENT':
      return state + 1;
    case 'DECREMENT':
      return state - 1;
    default:
      return state;
  }
};
const myStore = (new Subject())
  .scan(reducer, 0);
myStore.subscribe({
  next: o => console.log(o),
});
myStore.next({
  type: 'INCREMENT',
});
myStore.next({
  type: 'INCREMENT',
});
myStore.next({
  type: 'DECREMENT',
});

//combine reducers

const combineReducers = (reducers) => {
  const reducerKeys = Object.keys(reducers);
  return (state, action) => {
    const nextState = {};
    let hasChanged = false;
    for (let i = 0; i < reducerKeys.length; i += 1) {
      const key = reducerKeys[i];
      const reducer = reducers[key];
      const previousStateForKey = state[key];
      const nextStateForKey = reducer(previousStateForKey, action);
      nextState[key] = nextStateForKey;
      hasChanged = hasChanged || nextStateForKey !== previousStateForKey;
    }
    return hasChanged ? nextState : state;
  };
};
const counter1 = (state = 0, action) => {
  switch (action.type) {
    case 'C1_INCREMENT':
      return state + 1;
    case 'C1_DECREMENT':
      return state - 1;
    default:
      return state;
  }
};
const counter2 = (state = 0, action) => {
  switch (action.type) {
    case 'C2_INCREMENT':
      return state + 1;
    case 'C2_DECREMENT':
      return state - 1;
    default:
      return state;
  }
};
const reducer = combineReducers({
  counter1,
  counter2,
});
const initialState = reducer({}, { TYPE: '_INIT' });
const myStore = (new Subject())
  .scan(reducer, initialState);
myStore.subscribe({
  next: o => console.log(o),
});
myStore.next({
  type: 'C1_INCREMENT',
});
myStore.next({
  type: 'C1_INCREMENT',
});
myStore.next({
  type: 'C1_DECREMENT',
});
myStore.next({
  type: 'C2_INCREMENT',
});