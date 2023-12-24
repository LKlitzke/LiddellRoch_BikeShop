function loadRadialBarChart(id, data) {
    var chartColors = getChartColorsArray(id);
    var options = {
        fill: {
            colors: chartColors
        },
        legend: {
            show: false
        },
        series: data.series,
        chart: {
            height: 100,
            width: 100,
            sparkline: {
                enabled: true
            },
            type: 'radialBar',
            offsetY: -10
        },
        plotOptions: {
            radialBar: {
                hollow: {
                    size: '65%',
                },
                dataLabels: {
                    name: {
                        show: false
                    },
                    value: {
                        offsetY: 5
                    }
                }
            },
        }
    };

    var chart = new ApexCharts(document.querySelector("#" + id), options);
    chart.render();
}

function getChartColorsArray(id) {
    if (document.getElementById(id) !== null) {
        var colors = document.getElementById(id).getAttribute("data-colors");

        if (colors) {
            colors = JSON.parse(colors);
            return colors.map(function (value) {
                var newValue = value.replace(" ", "");
                if (newValue.indexOf(",") === -1) {
                    var color = getComputedStyle(document.documentElement).getPropertyValue(newValue);
                    if (color) return color;
                    else return newValue;;
                }
            });
        }
    }
}