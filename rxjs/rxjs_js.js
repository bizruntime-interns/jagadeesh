//var observable=Rx.Observable.interval(1000);
//var observer={
  //next:function(value){
    //console.log(value);
 // }};
//observable.map(function(value){
//  return 'number:'+value;
//}).throttleTime(1900).subscribe(observer);
var subject=new rxjs.Subject();
subject.subscribe({next:function(value){
  console.log(value);
},
error:function(value){
console.log(error);
},
complete:function(value){
console.log('complete');
}
});
subject.subscribe({next:function(value){
  console.log(value);
}
});
subject.next('a new data piece');
subject.complete();
subject.next('A new value');
                  