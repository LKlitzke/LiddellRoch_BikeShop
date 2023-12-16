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
            document.querySelector("#spanTotalRevenueCount").innerHTML = "R$ " + data.totalCount;

            var sectionCurrentCount = document.createElement("span");
            if (data.hasRatioIncreased) {
                sectionCurrentCount.className = "text-success me-1";
                sectionCurrentCount.innerHTML = '<i class="bi bi-arrow-up-right-circle me-1"></i> <span> ' + '+R$ ' + data.countInCurrentMonth + '</span>';
            }
            else {
                sectionCurrentCount.className = "text-danger me-1";
                sectionCurrentCount.innerHTML = '<i class="bi bi-arrow-down-right-circle me-1"></i> <span> ' + '-R$ ' + data.countInCurrentMonth + '</span>';
            }
            document.querySelector("#sectionRevenueCount").append(sectionCurrentCount);
            document.querySelector("#sectionRevenueCount").append("neste mês");

            loadRadialBarChart("totalRevenueRadialChart", data);

            //$(".chart-spinner").hide();
        }
    });
}
