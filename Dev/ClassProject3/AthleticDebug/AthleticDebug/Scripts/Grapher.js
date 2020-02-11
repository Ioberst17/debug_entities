// Wait for the DOM to load everything, just to be safe
$(document).ready(function () {

    // Create our graph from the data table and specify a container to put the graph in
    createGraph('#data-table', '.chart');

    // Here be graphs
    function createGraph(data, container) {
        // Declare some common variables and container elements
        var bars = [];
        var figureContainer = $('<div id="figure"></div>');
        var graphContainer = $('<div class="graph"></div>');
        var barContainer = $('<div class="bars"></div>');
        var data = $(data);
        var container = $(container);
        var chartData;
        var chartYMax;
        var columnGroups;

        // Timer variables
        var barTimer;
        var graphTimer;

        // Create table data object
        var tableData = {
            // Get numerical data from table cells
            chartData: function () {
        …
    },
    // Get heading data from table caption
    chartHeading: function() {
        …
    },
    // Get legend data from table body
    chartLegend: function() {
        …
    },
    // Get highest value for y-axis scale
    chartYMax: function() {
        …
    },
    // Get y-axis data from table cells
    yLegend: function() {
        …
    },
    // Get x-axis data from table header
    xLegend: function() {
        …
    },
    // Sort data into groups based on number of columns
    columnGroups: function() {
        var columnGroups = [];
        // Get number of columns from first row of table body
        var columns = data.find('tbody tr:eq(0) td').length;
        for (var i = 0; i < columns; i++) {
            columnGroups[i] = [];
            data.find('tbody tr').each(function () {
                columnGroups[i].push($(this).find('td').eq(i).text());
            });
        }
        return columnGroups;
    }


    // Useful variables to access table data
    …

    // Construct the graph
    …

    // Set the individual height of bars
    function displayGraph(bars, i) {
        // Changed the way we loop because of issues with $.each not resetting properly
        if (i < bars.length) {
            // Animate the height using the jQuery animate() function
            $(bars[i].bar).animate({
                height: bars[i].height
            }, 800);
            // Wait the specified time, then run the displayGraph() function again for the next bar
            barTimer = setTimeout(function () {
                i++;
                displayGraph(bars, i);
            }, 100);
        }
    }

    // Reset graph settings and prepare for display
    function resetGraph() {
        // Stop all animations and set the bar's height to 0
        $.each(bars, function (i) {
            $(bars[i].bar).stop().css('height', 0);
        });

        // Clear timers
        clearTimeout(barTimer);
        clearTimeout(graphTimer);

        // Restart timer
        graphTimer = setTimeout(function () {
            displayGraph(bars, 0);
        }, 200);
    }

    // Helper functions
    …

    // Finally, display the graph via reset function
    resetGraph();
}
});

// Loop through column groups, adding bars as we go
$.each(columnGroups, function (i) {
    // Create bar group container
    var barGroup = $('<div class="bar-group"></div>');
    // Add bars inside each column
    for (var j = 0, k = columnGroups[i].length; j < k; j++) {
        // Create bar object to store properties (label, height, code, etc.) and add it to array
        // Set the height later in displayGraph() to allow for left-to-right sequential display
        var barObj = {};
        barObj.label = this[j];
        barObj.height = Math.floor(barObj.label / chartYMax * 100) + '%';
        barObj.bar = $('<div class="bar fig' + j + '"><span>' + barObj.label + '</span></div>')
            .appendTo(barGroup);
        bars.push(barObj);
    }
    // Add bar groups to graph
    barGroup.appendTo(barContainer);
});

// Add y-axis to graph
var yLegend = tableData.yLegend();
var yAxisList = $('<ul class="y-axis"></ul>');
$.each(yLegend, function (i) {
    var listItem = $('<li><span>' + this + '</span></li>')
        .appendTo(yAxisList);
});
yAxisList.appendTo(graphContainer);

// Add bars to graph
barContainer.appendTo(graphContainer);

// Add graph to graph container
graphContainer.appendTo(figureContainer);

// Add graph container to main container
figureContainer.appendTo(container);

