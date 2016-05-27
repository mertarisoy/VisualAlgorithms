
var path;
var isPlaying = false;
var cy;
var cyStack;
var lastIndex = 0;
var timeout;

var cyStackLayout;
var lastHighlightIndex;

function loadGraph() {
    $.get("/DepthFirstSearch/Dfs", {start : 0, graphSize : $("#graphSize").val()}, function (data) {

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
                directed: false,
                padding: 5
            }
        });

        cy.center();
        cy.fit();
    });

    lastIndex = 0;
    isPlaying = false;
}

function loadStack() {

    cyStack = cytoscape({
        container: $(".cyStack"),

        zoomingEnabled: true,
        userZoomingEnabled: false,
        boxSelectionEnabled: false,
        autounselectify: true,
        center: true,
        fit: true,

        style: cytoscapeStyle,

        layout: {
            name: 'stack',
            directed: false,
            padding: 5
        }

    });
    cyStack.center();
    cyStack.fit();

}



$(function () { // on dom ready
    loadGraph();
    loadStack();
    $("#speed").val('5');
    $("#speed").trigger("change");
    $('.inner').matchHeight();
});






