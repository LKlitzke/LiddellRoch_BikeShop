
$(document).ready(function () {
    loadTotalComprasRadialChart();
});

function loadTotalComprasRadialChart() {
    //$(".chart-spinner").show();

    $.ajax({
        url: "/Admin/Dashboard/GetTotalComprasChartData",
        type: 'GET',
        dataType: 'json',
        success: function (data) {
            document.querySelector("#spanTotalComprasCount").innerHTML = data.totalCount;

            //console.log(data);
            var sectionCurrentCount = document.createElement("span");
            if (data.hasRatioIncreased) {
                sectionCurrentCount.className = "text-success me-1";
                sectionCurrentCount.innerHTML = '<i class="bi bi-arrow-up-right-circle me-1"></i> <span> +' + data.countInCurrentMonth + '</span>';
            }
            else {
                sectionCurrentCount.className = "text-danger me-1";
                sectionCurrentCount.innerHTML = '<i class="bi bi-arrow-down-right-circle me-1"></i> <span> -' + data.countInCurrentMonth + '</span>';
            }

            document.querySelector("#sectionComprasCount").append(sectionCurrentCount);
            //console.log(sectionCurrentCount);

            document.querySelector("#sectionComprasCount").append("nos últimos 30 dias");

            loadRadialBarChart("totalComprasRadialChart", data);

            /*$(".chart-spinner").hide();*/
        }
    });
}