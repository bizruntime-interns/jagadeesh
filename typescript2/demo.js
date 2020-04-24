"use strict";
// var message="hello"
exports.__esModule = true;
// console.log(message);
// if(message){
// var i:number;
// for(i=0;i<3;i++){
// console.log(message+' '+i);
// }
// }
// console.log("value of i "+i)
//-----------------------------------------------------------------------------------------
// function Person(Name){
//     this.Name=Name
//     this.sayhi=function(){
//          setTimeout(() => {
//             console.log(this.Name)
//         }, 1000);
//     }
// }
// const person=new Person('blok')
// person.sayhi()
//-------------------------------------------------------------------------------------------
// import { person } from "./person";
//     const firstname='kane',
//             lastname='kole';
//     const partial_address=["street","Road"];
//     const persondata={
//         firstname,
//         lastname
//     };
//     const address=[...partial_address,'streetking'];
//     console.log(person(persondata,address));
//---------------------------------------------------------------------------
// interface createmessage{
//     (name:string):string
// };
// function createmessage1(name:string):string{
//     return `my name is ${name}`;
// }
// const msgc:createmessage=createmessage1
// const msg=msgc('Bill');
// console.log(msg)
//-----------------------------------------------------------------------------
// enum position{
//     first,
//     second,
//     third
// }
// type player=[string,position]
// let kobe:player=['kobe',position["first"]];
// let kal:player=['kal',position.second];
// let kon:player=['kon',position.third];
// let players:player[]=[kobe,kal,kon];
// // console.log(kobe);
// // console.log(players[1],players[2]);
// //console.log(players[2])
// players.forEach(element => {
//     console.log(element);
// });
// ------------------------------------------------------------------------------
// interface name{firstname:string,lastname:string}
// interface address{address:string}
// type player=(name & address) | null;
// const kob:player={firstname:'kobe',lastname:'kk'}
// let key:any;
// key=""
// key=undefined
// key=null
// var r=key
// -------------------------------------------------------------------
var _ = require("lodash");
var colors = ['red', 'green', 'blue'];
var firstC = _.first(colors);
console.log(firstC);
//# sourceMappingURL=demo.js.map