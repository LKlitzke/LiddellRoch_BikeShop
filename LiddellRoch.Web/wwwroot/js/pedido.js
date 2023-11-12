var dataTable;

$(document).ready(function () {
    var url = window.location.search;
    if (url.includes("processando")) {
        loadDataTable("processando");
    }
    else {
        if (url.includes("completado")) {
            loadDataTable("completado");
        }
        else {
            if (url.includes("pendente")) {
                loadDataTable("pendente");
            }
            else {
                if (url.includes("aprovado")) {
                    loadDataTable("aprovado");
                }
                else {
                    loadDataTable("todos");
                }
            }
        }
    }

});

function loadDataTable(status) {
    dataTable = $('#tblData').DataTable({
        language: {
            url: '//cdn.datatables.net/plug-ins/1.13.6/i18n/pt-BR.json',
        },
        "ajax": { url: '/admin/pedido/getall?status=' + status },
        "columns": [
            { data: 'id', "width": "5%" },
            { data: 'nome', "width": "25%" },
            { data: 'telefone', "width": "20%" },
            { data: 'applicationUser.email', "width": "20%" },
            { data: 'statusPagamento', "width": "10%" },
            { data: 'totalPedidoStr', "width": "10%" },
            {
                data: 'id',
                "render": function (data) {
                    return `<div class="btn-group" role="group">
                     <a href="/admin/pedido/detalhes?pedidoId=${data}" title="Editar pedido"> <i class="bi bi-pencil-square"></i></a>
                    </div>`
                },
                "width": "10%",
                "class":"text-center"
            }
        ]
    });
}