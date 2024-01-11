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
        scrollX: true,
        stateSave: true,
        dom: 'Bfrtip',
        lengthMenu: [
            [10, 25, 50, -1],
            ['10 linhas', '25 linhas', '50 linhas', 'Tudo']
        ],
        buttons: [
            'pageLength',
            {
                extend: 'colvis',
                columnText: function (dt, idx, title) {
                    return (idx + 1) + ': ' + title;
                }
            },
            {
                extend: 'spacer',
                style: 'bar',
                text: 'Exportar:'
            },
            {
                extend: 'excelHtml5',
                title: 'LiddellRoch - Lista de Categorias',
                exportOptions: {
                    columns: [0, 1, 2, 3, 4, 5, 6, 7]
                }
            },
            {
                extend: 'csvHtml5',
                title: 'LiddellRoch - Lista de Categorias',
                exportOptions: {
                    columns: [0, 1, 2, 3, 4, 5, 6, 7]
                }
            },
            {
                extend: 'pdfHtml5',
                orientation: 'landscape',
                pageSize: 'LEGAL',
                exportOptions: {
                    columns: [0, 1, 2, 3, 4, 5, 6, 7]
                },
                title: 'LiddellRoch - Lista de Categorias',
                messageTop: 'Gerado em ' + new Date().toLocaleDateString('pt-br') + ' às ' + new Date().toLocaleTimeString('pt-br'),

                // Customização do pdfmake
                customize: function (doc) {
                    doc.content.splice(0, 0, {
                        margin: [0, 0, 0, 12],
                        alignment: 'center',
                        width: 120,
                        image: imgLogoLiddellRoch()
                    });

                    doc.defaultStyle.fontSize = 12;

                    doc.styles.message.italics = true;
                    doc.styles.message.alignment = 'center';

                    doc.styles.title.fontSize = 20;
                    doc.styles.title.bold = true;
                    doc.styles.tableHeader.fillColor = '#375a7f';
                    doc.styles.tableHeader.alignment = 'left';
                    doc.styles.tableHeader.fontSize = '12';

                    var columnWidths = ['auto', '*', '*', 'auto', 'auto', 'auto', 'auto', 'auto'];
                    columnWidths[0] = 30; // ID
                    columnWidths[1] = 150;
                    columnWidths[2] = 100;
                    columnWidths[3] = 130;
                    columnWidths[4] = 130;
                    columnWidths[5] = 130;

                    doc.content[3].table.widths = Array(doc.content[3].table.body[0].length + 1).join('*').split('');
                    doc.content[3].table.widths = columnWidths;

                    doc.content[3].table.body.forEach(function (row) {
                        row.forEach(function (cell, index) {
                            let rowSpacing = 5;
                            cell.margin = [0, rowSpacing, 0, rowSpacing];
                        });
                    });

                    doc.content[3].layout = {
                        hLineWidth: function (i, node) { return (i === 0 || i === node.table.body.length) ? 1 : 0; },
                        vLineWidth: function (i, node) { return (i === 0 || i === node.table.widths.length) ? 1 : 0; },
                        hLineColor: function (i, node) { return '#aaa'; },
                        vLineColor: function (i, node) { return '#aaa'; }
                    };
                }
            }
        ],
        "ajax": { url: '/admin/pedido/getall?status=' + status },
        "columns": [
            { data: 'id', "width": "3%" },
            { data: 'nome', "width": "10%" },
            {
                data: 'statusPedido', "width": "8%",
                render: function (data, type, row) {
                    var bgColor = '--bs-success';
                    switch (data) {
                        case 'Enviado':
                            bgColor = '--bs-primary';
                            break;
                        case 'Pendente':
                            bgColor = '--bs-warning';
                            break;
                        case 'Cancelado':
                            bgColor = '--bs-danger';
                            break;
                        case 'Aprovado':
                            bgColor = '--bs-success';
                            break;
                        default:
                            bgColor = '--bs-dark';
                    }
                    return `<div style="text-align:left; font-weight: 600;color: var(${bgColor})">${data}</div>`;
                }
            },
            {
                data: 'dataPedido', "width": "10%",
                render: function (data, type, row) {
                    return `<div style="text-align:center;">${new Date(data).toLocaleString('pt-br')}</div>`;
                }
            },
            {
                data: 'dataPagamento', "width": "10%",
                render: function (data, type, row) {
                    return checkIfDateExists(data)
                        ? `<div style="text-align:center;"> ${new Date(data).toLocaleString('pt-br')}</div>`
                        : `<div style="text-align:center;">-</div>`;
                }
            },
            {
                data: 'dataEnvio', "width": "10%",
                render: function (data, type, row) {
                    return checkIfDateExists(data)
                        ? `<div style="text-align:center;"> ${new Date(data).toLocaleString('pt-br')}</div>`
                        : `<div style="text-align:center;">-</div>`;
                }
            },
            { data: 'endereco', "width": "10%" },
            {
                data: 'totalPedidoStr', "width": "10%",
                render: function (data, type, row) {
                    return type === 'display' ? '<div style="text-align:right;">' + $.fn.dataTable.render.number('.', ',', 2, 'R$ ').display(data) + '</div>' : data;
                }
            },
            {
                data: 'id',
                "render": function (data) {
                    return `<div class="text-center d-flex justify-content-center" role="group">
                     <a href="/Admin/Pedido/Detalhes?pedidoId=${data}" class="btn btn-primary px-4 mx-2"> <i class="bi bi-eye-fill"></i> Detalhes</a>
                    </div>`
                },
                "width": "10%"
            }
        ]
    });
}

function checkIfDateExists(date) {
    return date && date > '0001-01-01T00:00:00';
}