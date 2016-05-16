function loadGraph() {
    $.get("/Home/GetRandomGraphForBFS", null, function (data) {

        var graph = JSON.parse(data.graph);
        var path = data.path;
        $("#path-text").html(data.path.toString());
        var cy = cytoscape({
            container: $("#cy"),

            zoomingEnabled: true,
            userZoomingEnabled: false,
            boxSelectionEnabled: false,
            autounselectify: true,
            center: true,
            fit: true,

            style: [
                {
                    selector: 'node',
                    css: {
                        'content': 'data(id)',
                        'text-valign': 'center',
                        'text-halign': 'center'
                    }
                },
                {
                    selector: '$node > node',
                    css: {
                        'padding-top': '10px',
                        'padding-left': '10px',
                        'padding-bottom': '10px',
                        'padding-right': '10px',
                        'text-valign': 'top',
                        'text-halign': 'center',
                        'background-color': '#bbb'
                    }
                },
                {
                    selector: 'edge',
                    css: {
                        'target-arrow-shape': 'none',
                        'curve-style': 'haystack',
                        'haystack-radius': 0
                    }
                },
                {
                    selector: ':selected',
                    css: {
                        'background-color': 'black',
                        'line-color': 'black',
                        'target-arrow-color': 'black',
                        'source-arrow-color': 'black'
                    }
                },
                {
                    selector: '.highlighted',
                    css: {
                        'background-color': '#ee0000',
                        'line-color': '#000000',
                        'target-arrow-color': '#0000ee',
                        'transition-property': 'background-color, line-color, target-arrow-color',
                        'transition-duration': '0.3s'
                    }
                }
            ],

            elements: graph,

            layout: {
                name: 'cose',
                directed: false,
                padding: 5
            }
        });

        cy.center();
  
        console.log(path);
        var queue = path;
        var i = 0;
        var highlight = function () {
            if (i < queue.length) {
                cy.getElementById(queue[i]).addClass('highlighted');
                i++;
                setTimeout(highlight, 1000);
            }
        };

        highlight();


    });
}

function refreshGraph() {
    loadGraph();
};

$(function () { // on dom ready
    loadGraph();
});


