$(document).ready(function () {
    loadRevenueRadialChart();
});

function loadRevenueRadialChart() {
    ///$(".chart-spinner").show();

    $.ajax({
        url: "/Admin/Dashboard/GetLucrosChartData",
        type: 'GET',
        dataType: 'json',
        success: function (data) {
            document.querySelector("#spanTotalRevenueCount").innerHTML =
                Intl.NumberFormat('pt-br', { style: 'currency', currency: 'BRL' })
                .format(parseFloat(data.totalCount).toFixed(2));

            var sectionCurrentCount = document.createElement("span");
            if (data.hasRatioIncreased) {
                sectionCurrentCount.className = "text-success me-1";
                sectionCurrentCount.innerHTML = '<i class="bi bi-arrow-up-right-circle me-1"></i> <span> ' + '+' +
                    Intl.NumberFormat('pt-br', { style: 'currency', currency: 'BRL' })
                        .format(parseFloat(data.countInCurrentMonth).toFixed(2)) + '</span>';
            }
            else {
                sectionCurrentCount.className = "text-danger me-1";
                sectionCurrentCount.innerHTML = '<i class="bi bi-arrow-down-right-circle me-1"></i> <span> ' + '-' +
                    Intl.NumberFormat('pt-br', { style: 'currency', currency: 'BRL' })
                        .format(parseFloat(data.countInCurrentMonth).toFixed(2)) + '</span>';
            }
            document.querySelector("#sectionRevenueCount").append(sectionCurrentCount);
            document.querySelector("#sectionRevenueCount").append("nos últimos 30 dias");

            loadRadialBarChart("totalRevenueRadialChart", data);

            //$(".chart-spinner").hide();
        }
    });
}
