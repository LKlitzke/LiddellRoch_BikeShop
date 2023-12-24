﻿
$(document).ready(function () {
    loadUserRadialChart();
});

function loadUserRadialChart() {
    //$(".chart-spinner").show();

    $.ajax({
        url: "/Admin/Dashboard/GetRegistrosUsuariosChartData",
        type: 'GET',
        dataType: 'json',
        success: function (data) {
            document.querySelector("#spanTotalUserCount").innerHTML = data.totalCount;

            var sectionCurrentCount = document.createElement("span");
            if (data.hasRatioIncreased) {
                sectionCurrentCount.className = "text-success me-1";
                sectionCurrentCount.innerHTML = '<i class="bi bi-arrow-up-right-circle me-1"></i> <span> +' + data.countInCurrentMonth + '</span>';
            }
            else {
                sectionCurrentCount.className = "text-danger me-1";
                sectionCurrentCount.innerHTML = '<i class="bi bi-arrow-down-right-circle me-1"></i> <span> -' + data.countInCurrentMonth + '</span>';
            }

            document.querySelector("#sectionUserCount").append(sectionCurrentCount);
            document.querySelector("#sectionUserCount").append("neste mês");

            loadRadialBarChart("totalUserRadialChart", data);

            //$(".chart-spinner").hide();
        }
    });
}
