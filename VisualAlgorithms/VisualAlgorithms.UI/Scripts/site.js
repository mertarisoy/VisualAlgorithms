
var cytoscapeStyle = [
    {
        selector: 'node',
        css: {
            'content': 'data(id)',
            'text-valign': 'center',
            'text-halign': 'center',
            'label' : 'data(label)'
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
            'label' : 'data(label)'
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
];

var highlightStep = function () {
    if (lastIndex < path.length && isPlaying) {

        var id = path[lastIndex].id;
        var command = path[lastIndex].command;
        var data = path[lastIndex].data;

        var node = { group: "nodes", data: { id: id ,label:id} };

        switch (command) {
            case 'gh':
                cy.getElementById(id).addClass('GreenHighlighted');
                break;
            case 'rh':
                cy.getElementById(id).addClass('RedHighlighted');
                break;
            case 'Rh':
                cy.getElementById(id).removeClass('GreenHighlighted');
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
            case 'sa':
                var n = cyStack.getElementById(lastHighlightIndex);
                if (n != undefined) {
                    n.removeClass('highlighted');
                }
                cyStack.add(node).addClass('highlighted');

                lastHighlightIndex = id;
                cyStack.layout({ name: 'stack' });
                break;
            case 'sr':
                cyStack.getElementById(id).remove();
                cyStack.layout({ name: 'stack' });
                break;
            case 'sl':
                var parentNode = cy.getElementById(id);

                if (parentNode.data('circleId')) {
                    var circleNode = cy.getElementById(parentNode.data('circleId'));
                    circleNode.data('label', data);
                    break;
                }

                parentNode.lock();
                var px = parentNode.position('x') - 20;
                var py = parentNode.position('y') - 20;

                var circleId = (cy.nodes().size() + 1).toString();
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

        }
        lastIndex++;
        if (lastIndex == path.length) {

            isPlaying = false;
            $("#playButton").children().removeClass('fa-pause');
            $("#playButton").children().addClass('fa-play');
        }

        if (isPlaying) {
            setTimeout(highlightStep, timeout);
        }
    }
};

function refreshGraph() {
    isPlaying = false;
    $("#playButton").children().removeClass('fa-pause');
    $("#playButton").children().addClass('fa-play');

    loadGraph();

    try {
        loadQueue();
    } catch (err) {
        loadStack();
    }
    
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
    }

    var id = path[lastIndex].id;
    var command = path[lastIndex].command;
    var data = path[lastIndex].data;

    var node = { group: "nodes", data: { id: id, label: id } };

    switch (command) {
        case 'Rh':
            cy.getElementById(id).addClass('GreenHighlighted');
            break;
        case 'rh':
            cy.getElementById(id).removeClass('RedHighlighted');
            break;
        case 'gh':
            cy.getElementById(id).removeClass('GreenHighlighted');
            break;
        case 'qr':
            var n = cyQueue.getElementById(lastHighlightIndex);
            if (n != undefined) {
                n.removeClass('highlighted');
            }
            cyQueue.add(node).addClass('highlighted');

            lastHighlightIndex = id;
            cyQueue.layout({ name: 'queue' });
            break;
        case 'qa':
            cyQueue.getElementById(id).remove();
            cyQueue.layout({ name: 'queue' });
            break;
        case 'sr':
            var n = cyStack.getElementById(lastHighlightIndex);
            if (n != undefined) {
                n.removeClass('highlighted');
            }
            cyStack.add(node).addClass('highlighted');

            lastHighlightIndex = id;
            cyStack.layout({ name: 'stack' });
            break;
        case 'sa':
            cyStack.getElementById(id).remove();
            cyStack.layout({ name: 'stack' });
            break;
        case 'sl':
            var parentNode = cy.getElementById(id);

            if (parentNode.data('circleId')) {
                var circleNode = cy.getElementById(parentNode.data('circleId'));
                circleNode.data('label', data);
                break;
            }

            parentNode.lock();
            var px = parentNode.position('x') - 20;
            var py = parentNode.position('y') - 20;

            var circleId = (cy.nodes().size() + 1).toString();
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

    }

    

});

$("#nextButton").on("click", function () {
    if (isPlaying)
        return;

    isPlaying = true;
    highlightStep();
    isPlaying = false;
});

$("#resetButton").on("click", function () {
    $("#playButton").children().removeClass('fa-pause');
    $("#playButton").children().addClass('fa-play');
    resetGraphAnimation();
});




function resetGraphAnimation() {
    for (var i = 0; i < path.length; i++) {
        cy.getElementById(path[i]).removeAttr("class");
    }

    lastIndex = 0;
    isPlaying = false;
}

$("#speed").on("input", function () {

    timeout = 1200 - $("#speed").val();
    //var val = $("#speed").val();
    //switch (val) {
    //    case '1':
    //        timeout = 1500;
    //        break;
    //    case '2':
    //        timeout = 1300;
    //        break;
    //    case '3':
    //        timeout = 1000;
    //        break;
    //    case '4':
    //        timeout = 700;
    //        break;
    //    case '5':
    //        timeout = 500;
    //        break;
    //    default:
    //        timeout = 1000;
    //        break;
    //}
});

$("#graphSize").on('change', function() {

    refreshGraph();

});

$("#pseudo").click(function() {
    var html = $("#pseudo").html();
    $(".bs-example-modal-lg .modal-body").html(html);
    $(".bs-example-modal-lg").modal("show");
});

$("#csharp").click(function () {
    var html = $("#csharp").html();
    $(".bs-example-modal-lg .modal-body").html(html);
    $(".bs-example-modal-lg").modal("show");
});

