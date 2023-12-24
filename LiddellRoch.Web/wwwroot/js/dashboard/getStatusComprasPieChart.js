
$(document).ready(function () {
    loadStatusComprasPieChart();
});

function loadStatusComprasPieChart() {
    //$(".chart-spinner").show();

    $.ajax({
        url: "/Admin/Dashboard/GetStatusComprasPieChartData",
        type: 'GET',
        dataType: 'json',
        success: function (data) {
      
            loadPieChart("StatusComprasPieChart", data);

            //$(".chart-spinner").hide();
        }
    });
}