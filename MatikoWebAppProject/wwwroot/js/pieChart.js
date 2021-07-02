$(function () {
    $("#stats1").click(function (e) {
        e.preventDefault();
        $.ajax({
            // method : 'post',
            url: '/Products/Statistics',
            data: {/* 'Color': Color, 'count': count*/ }
        }).done(function (data) {
            console.log(data);
            // Step 3
            /* var svg = d3.select("svg"),
                 width = svg.attr("width"),
                 height = svg.attr("height"),
                 radius = 200;
 
             var g = svg.append("g")
                 .attr("transform", "translate(" + width / 2 + "," + height / 2 + ")");
 
             // Step 4
             var ordScale = d3.scaleOrdinal()
                 .domain(data)
                 .range(['#ffd384', '#94ebcd', '#fbaccc', '#d3e0ea', '#fa7f72']);
 
             // Step 5
             var pie = d3.pie().value(function (d) {
                 return d.count;
             });
 
             var arc = g.selectAll("arc")
                 .data(pie(data))
                 .enter();
 
             // Step 6
             var path = d3.arc()
                 .outerRadius(radius)
                 .innerRadius(0);
 
             arc.append("path")
                 .attr("d", path)
                 .attr("fill", function (d) { return ordScale(d.data.Color); });
 
             // Step 7
             var label = d3.arc()
                 .outerRadius(radius)
                 .innerRadius(0);
 
             arc.append("text")
                 .attr("transform", function (d) {
                     return "translate(" + label.centroid(d) + ")";
                 })
                 .text(function (d) { return d.data.Color; })
                 .style("font-family", "arial")
                 .style("font-size", 15);
 
             $('body').load('/Products/Statistics'); */
        };
    });
});