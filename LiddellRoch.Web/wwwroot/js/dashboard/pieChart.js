
function loadPieChart(id, data) {
    var chartColors = getChartColorsArray(id);
    var options = {
        colors: chartColors,
        series: data.series,
        labels: data.labels,
        chart: {
            width: 380,
            type: 'donut',
        },
        stroke: {
            show: false
        },
        legend: {
            position: 'left',
            horizontalAlign: 'center',
            labels: {
                colors: "#fff",
                useSeriesColors: true,

            },
        },
        tooltip: {
            theme: 'dark'
        }
    };
    var chart = new ApexCharts(document.querySelector("#" + id), options);
    chart.render();
}