
var path;
var isPlaying = false;
var cy;
var cyQueue;
var lastIndex = 0;
var timeout;

var cyQueueLayout;
var lastHighlightIndex;

function loadGraph() {
    $.get("/PrimsMST/Mst", null, function (data) {

        var graph = JSON.parse(data.graph);
        path = data.path;
        //$("#path-text").html(data.path.toString());
        console.log(data.path);
        cy = cytoscape({
            container: $(".cyGraph"),

            zoomingEnabled: true,
            userZoomingEnabled: true,
            boxSelectionEnabled: false,
            autounselectify: true,
            center: true,
            fit: true,
            height: 100,

            style: [
            {
                selector: 'node',
                css: {
                    'content': 'data(id)',
                    'text-valign': 'center',
                    'text-halign': 'center',
                    'label': 'data(label)'
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
                        'haystack-radius': 0,
                        'label': 'data(label)'
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
                },
                {
                    selector: '.RedHighlighted',
                    css: {
                        'background-color': '#ee0000',
                        'line-color': '#000000',
                        'target-arrow-color': '#0000ee',
                        'transition-property': 'background-color, line-color, target-arrow-color',
                        'transition-duration': '0.3s'
                    }
                },
                {
                    selector: '.GreenHighlighted',
                    css: {
                        'background-color': '#00ee00',
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
                directed: true,
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
        ]

    });
    cyQueue.center();
    cyQueue.fit();
    cyQueueLayout = cyQueue.makeLayout({ name: "queue" });

}

function refreshGraph() {
    loadGraph();
};

$("#playButton").on("click", function () {
    isPlaying = !isPlaying;

    if (isPlaying) {
        $("#playButton").children().removeClass('fa-play');
        $("#playButton").children().addClass('fa-pause');
        highlightStep();
    }
    else {
        $("#playButton").children().removeClass('fa-pause');
        $("#playButton").children().addClass('fa-play');
    }


});

$("#backButton").on("click", function () {
    if (isPlaying)
        return;


    if (lastIndex > 0) {
        lastIndex--;
        cy.getElementById(path[lastIndex]).removeClass('highlighted');

    } else {
        cy.getElementById(path[lastIndex]).removeClass('highlighted');
    }

});

$("#nextButton").on("click", function () {
    if (isPlaying)
        return;


    highlightStep();
});

$("#resetButton").on("click", function () {
    $("#playButton").children().removeClass('fa-pause');
    $("#playButton").children().addClass('fa-play');
    resetGraphAnimation();
});


var highlightStep = function () {
    if (lastIndex < path.length) {

        var id = path[lastIndex].id;
        var command = path[lastIndex].command;
        var data = path[lastIndex].data;

        var node = { group: "nodes", data: { id: id } };

        switch (command) {
            case 'gh':
                cy.getElementById(id).addClass('GreenHighlighted');
                break;
            case 'rh':
                cy.getElementById(id).addClass('RedHighlighted');
                break;
            case 'Rh':
                cy.getElementById(id).removeClass('GreenHighlighted');
                cy.getElementById(id).removeClass('RedHightlighted');
                cy.getElementById(id).removeClass('highlighted');
                break;
            case 'qa':
                var n = cyQueue.getElementById(lastHighlightIndex);
                if (n != undefined) {
                    n.removeClass('highlighted');
                }
                cyQueue.add(node).addClass('highlighted');

                lastHighlightIndex = id;
                cyQueue.layout({ name: 'queue' });
                break;
            case 'qr':
                cyQueue.getElementById(id).remove();
                cyQueue.layout({ name: 'queue' });
                break;
            case 'sl':
                var parentNode = cy.getElementById(id);

                if (parentNode.data('circleId')) {
                    var circleNode = cy.getElementById(parentNode.data('circleId'));
                    circleNode.data('label', data);
                    break;
                }

                parentNode.lock();
                var px = parentNode.position('x') - 15;
                var py = parentNode.position('y') - 15;

                var circleId = ('l' + id).toString();
                parentNode.data('circleId', circleId);

                var newNode = {
                    group: 'nodes',
                    data: { id: circleId, label: data },
                    position: { x: px, y: py },
                    locked: true
                };

                cy.add(newNode).css({
                    'background-color': 'white',
                    'shape': 'ellipse',
                    'background-opacity': 0.0,
                    'color': 'red',
                    'font-size': 10
                }).unselectify();

                cy.getElementById(circleId).data('label', data);
                break;
            case 'sp':
                console.log((cy.getElementById(data).length));

                cy.startBatch();
                cy.add({ group: "nodes", data: { id: data } });
                cy.getElementById(id).data('parent', data);
                //cy.forceRender();
                cy.endBatch();
                if (cy.getElementById(data).length === 0) {
                }

                break;

        }
        lastIndex++;
        if (isPlaying) {
            setTimeout(highlightStep, timeout);
        }
    }
};

function resetGraphAnimation() {
    for (var i = 0; i < path.length; i++) {
        cy.getElementById(path[i]).removeClass('RedHighlighted');
        cy.getElementById(path[i]).removeClass('GreenHighlighted');
        cy.getElementById(path[i]).removeClass('highlighted');
    }

    lastIndex = 0;
    isPlaying = false;
}

$("#speed").on("change", function () {

    var val = $("#speed").val();
    switch (val) {
        case '1':
            timeout = 1500;
            break;
        case '2':
            timeout = 1300;
            break;
        case '3':
            timeout = 1000;
            break;
        case '4':
            timeout = 700;
            break;
        case '5':
            timeout = 500;
            break;
        default:
            timeout = 1000;
            break;
    }
});

$(function () { // on dom ready
    loadGraph();
    loadQueue();
    $("#speed").val('5');
    $("#speed").trigger("change");


    $('.inner').matchHeight();
});






