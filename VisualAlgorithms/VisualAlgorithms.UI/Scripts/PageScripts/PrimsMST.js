
var path;
var isPlaying = false;
var cy;
var cyQueue;
var lastIndex = 0;
var timeout;

var cyQueueLayout;
var lastHighlightIndex;

function loadGraph() {
    $.get("/PrimsMST/Mst", { start: 0, graphSize: $("#graphSize").val() }, function (data) {

        var graph = JSON.parse(data.graph);
        path = data.path;
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
                padding: 10
            }
        });


        cy.center();
        cy.fit();
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

        style: cytoscapeStyle

    });
    cyQueue.center();
    cyQueue.fit();
    cyQueueLayout = cyQueue.makeLayout({ name: "queue" });

}


$(function () { // on dom ready
    loadGraph();
    loadQueue();
    $("#speed").val('5');
    $("#speed").trigger("change");
});






