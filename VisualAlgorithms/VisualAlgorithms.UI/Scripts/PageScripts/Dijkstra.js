
var path;
var isPlaying = false;
var cy;
var cyQueue;
var lastIndex = 0;
var timeout;

var cyQueueLayout;
var lastHighlightIndex;

function loadGraph() {
    $.get("/Dijkstra/Dijkstra", { start: 0, graphSize: $("#graphSize").val() }, function (data) {

        var graph = JSON.parse(data.graph);
        path = data.path;
        //$("#path-text").html(data.path.toString());
        console.log(data.path);
        cy = cytoscape({
            container: $(".cyGraph"),

            zoomingEnabled: true,
            userZoomingEnabled: false,
            boxSelectionEnabled: false,
            autounselectify: true,
            center: true,
            fit: true,
            height: 100,

            style: cytoscapeStyle,

            elements: graph,

            layout: {
                name: 'cose',
                directed: false,
                padding: 5
            }
        });


        cy.center();
        cy.fit();

        cy.style().selector('edge').style({
            'target-arrow-shape': 'triangle',
            'curve-style': 'bezier',
            'label': 'data(label)'
        }).update();
    });

    lastIndex = 0;
    isPlaying = false;
}

function loadQueue() {

    cyQueue = cytoscape({
        container: $(".cyQueue"),

        zoomingEnabled: true,
        userZoomingEnabled: false,
        boxSelectionEnabled: false,
        autounselectify: true,
        center: true,
        fit: true,

        style: cytoscapeStyle,
        layout: {
            name: 'queue',
            directed: false,
            padding: 5
        }

    });
    cyQueue.center();
    cyQueue.fit();

}


$(function () { // on dom ready
    loadGraph();
    loadQueue();
    $("#speed").trigger("input");
});






