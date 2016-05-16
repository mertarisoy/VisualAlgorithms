﻿
var path;
var isPlaying = false;
var cy;
var lastIndex = 0;
var timeout;

function loadGraph() {
    $.get("/Home/GetRandomGraphForBFS", null, function (data) {

        var graph = JSON.parse(data.graph);
        path = data.path;
        $("#path-text").html(data.path.toString());
        cy = cytoscape({
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
 
    });

    lastIndex = 0;
    isPlaying = false;
}

function refreshGraph() {
    loadGraph();
};

$("#playButton").on("click", function () {
    isPlaying = !isPlaying;

    if(isPlaying)
        highlightStep();
});

$("#backButton").on("click", function () {
    if (isPlaying)
        return;

    cy.getElementById(path[lastIndex]).removeClass('highlighted');

    if (lastIndex > 0) {
        lastIndex--;
    } 
});

$("#nextButton").on("click", function () {
    if (isPlaying)
        return;

    highlightStep();
});


var highlightStep = function () {
    if (lastIndex < path.length) {
        cy.getElementById(path[lastIndex]).addClass('highlighted');
        lastIndex++;
        if (isPlaying) {
            setTimeout(highlightStep, timeout);
        }
    }
};

$("#speed").on("change", function() {

    var val = $("#speed").val();
    switch(val) {
        case '1':
            timeout = 1000;
            break;
        case '2':
            timeout = 800;
            break;
        case '3':
            timeout = 600;
            break;
        case '4':
            timeout = 400;
            break;
        case '5':
            timeout = 200;
            break;
        default:
            timeout = 1000;
            break;
    }
});
$(function () { // on dom ready
    loadGraph();
});


