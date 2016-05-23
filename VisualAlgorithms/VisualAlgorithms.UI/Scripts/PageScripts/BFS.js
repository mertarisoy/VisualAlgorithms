
var path;
var isPlaying = false;
var cy;
var cyQueue;
var lastIndex = 0;
var timeout;

var cyQueueLayout;
var lastHighlightIndex;

function loadGraph() {
    $.get("/Home/GetRandomGraphForBFS", null, function (data) {

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
        ]

    });
    cyQueue.center();
    cyQueue.fit();
    cyQueueLayout = cyQueue.makeLayout({ name: "concentric" });

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
    else
    {
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

        var node = { group: "nodes", data: { id: id } };

        switch(command) {
            case 'nh':
                cy.getElementById(path[lastIndex].id).addClass('highlighted');
                break;
            case 'eh':
                cy.getElementById(path[lastIndex].id).addClass('highlighted');
                break;
            case 'qa':
                var n = cyQueue.getElementById(lastHighlightIndex);
                if (n != undefined) {
                    n.removeClass('highlighted');
                }                   
                cyQueue.add(node).addClass('highlighted');
                
                lastHighlightIndex = id;
                cyQueue.layout({ name: 'concentric' });
                break;
            case 'qr':
                cyQueue.getElementById(id).remove();
                cyQueue.layout({name : 'concentric'});
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
        cy.getElementById(path[i]).removeClass('highlighted');
    }

    lastIndex = 0;
    isPlaying = false;
}

$("#speed").on("change", function() {

    var val = $("#speed").val();
    switch(val) {
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
    $("#speed").val('3');
    $("#speed").trigger("change");

    // The code snippet you want to highlight, as a string
    var code = "var data = 1;";

    // Returns a highlighted HTML string
    var html = Prism.highlightElement($("#code")[0]);

    $('.inner').matchHeight();
});






