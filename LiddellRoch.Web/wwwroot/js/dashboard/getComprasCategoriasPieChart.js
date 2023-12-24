
$(document).ready(function () {
    loadComprasCategoriasPieChart();
});

function loadComprasCategoriasPieChart() {
    //$(".chart-spinner").show();

    $.ajax({
        url: "/Admin/Dashboard/GetComprasCategoriasPieChartData",
        type: 'GET',
        dataType: 'json',
        success: function (data) {
      
            loadPieChart("ComprasCategoriasPieChart", data);

            //$(".chart-spinner").hide();
        }
    });
}