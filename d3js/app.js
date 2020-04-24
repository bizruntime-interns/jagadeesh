// d3.selectAll("p")
// .style("color","brown");
const canvas=d3.select(".canva");
// var dataArray=[2,23,34,14];
// var dataArray=[{width:25,height:10,fill:"pink"},
//                 {width:25,height:14,fill:"green"},
//                 {width:25,height:20,fill:"blue"},
//                 {width:25,height:30,fill:"yellow"},
//                 {width:25,height:50,fill:"orange"}]

//const svg=canvas.select("svg");
//ading svg element

const svg=canvas.append("svg")
            .attr('width',"600")
            .attr('heght',"600");
const rect=svg.selectAll("rect")
d3.json('text.json')
.then(data=>{console.log(data);
    //var scaling=d3.scaleLinear().domain([0,70]).range([0,"height"]);


    rect
    .data(data)
    .enter().append("rect")
    .attr("width",24)
    .attr("fill",d=>  d.fill)
    .attr("height",function(d) {
        return d.height*3;})

    .attr("x",function(d,i){ 
        console.log(d);
        return i*25;})
    .attr("y",function(d,i){
        return 100-d.height*3;
    })
})  





























            
// svg.append("circle").attr("cx",300)
//                     .attr("cy",80)
//                     .attr("r",50)
//                     .attr("fill","purple");
// svg.append("rect").attr("x","120")
//                     .attr("y","0")
//                     .attr("width","100")
//                     .attr("height","100")
//                     .attr("fill","yellow")
//                     .attr("rx",15)
//                     .attr("ry",15);
// svg.append("line").attr("x1",150)
//                     .attr("x2",80)
//                     .attr("y1",500)
//                     .attr("y2",40)
//                     .attr("stroke","gray");
// svg.append("text")
//         .text("hello there")
//         .attr("x",100)
//         .attr("y",20)
//         .attr("text-anchor","start")
//         .attr("stroke","blue")
//         .attr("fill","maroon")
//         .attr("font-size",20);
// svg.append("text")
//         .text("hello there")
//         .attr("x",100)
//         .attr("y",40)
//         .attr("text-anchor","middle")
//         .attr("stroke","blue")
//         .attr("fill","maroon")
//         .attr("font-size",20);
// svg.append("text")
//         .text("hello there")
//         .attr("x",100)
//         .attr("y",80)
//         .attr("text-anchor","end")
//         .attr("stroke","blue")
//         .attr("fill","maroon")
//         .attr("font-size",20);

