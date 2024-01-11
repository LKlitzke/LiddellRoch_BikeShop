$(document).ready(function () {
    loadDataTable();
});

function loadDataTable() {
    dataTable = $('#tblData').DataTable({
        language: {
            url: '//cdn.datatables.net/plug-ins/1.13.6/i18n/pt-BR.json',
        },
        scrollX: true,
        stateSave: true,
        dom: 'Bfrtip',
        buttons: [
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
                title: 'LiddellRoch - Lista de Bikes',
                exportOptions: {
                    columns: [0, 1, 2, 3, 4, 5]
                }
            },
            {
                extend: 'csvHtml5',
                title: 'LiddellRoch - Lista de Bikes',
                exportOptions: {
                    columns: [0, 1, 2, 3, 4, 5]
                }
            },
            {
                extend: 'pdfHtml5',
                exportOptions: {
                    columns: [0, 1, 2, 3, 4, 5]
                },
                title: 'LiddellRoch - Lista de Bicicletas',
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

                    var columnWidths = ['auto', 'auto', 'auto', '*', 'auto', 'auto'];
                    columnWidths[0] = 30; // ID
                    columnWidths[1] = 150; // Nome
                    columnWidths[2] = 80; // Marca
                    columnWidths[4] = 50; // Estoque
                    columnWidths[5] = 80; // Preco

                    doc.content[3].table.widths = Array(doc.content[3].table.body[0].length + 1).join('*').split('');
                    doc.content[3].table.widths = columnWidths;               

                    doc.content[3].table.body.forEach(function (row) {
                        row.forEach(function (cell, index) {

                            let rowSpacing = 5;
                            cell.margin = [0, rowSpacing, 0, rowSpacing];

                            let headerList = doc.content[3].table.body[0];
                            //const onlyContainsNumbers = (str) => /^\d+$/.test(str);

                            if (cell.text && cell.text.toString().includes('R$')) {
                                
                                headerList[index].alignment = 'right';
                                cell.alignment = 'right';
                            }
                            //else if (cell.text && onlyContainsNumbers(cell.text)) {
                            //    headerList[index].alignment = 'right';
                            //    cell.alignment = 'right';
                            //}
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
        "ajax": { url: '/admin/bicicleta/getall' },
        "columns": [
            { data: 'id', "width": "5%" },
            { data: 'nome', "width": "25%" },
            { data: 'marca.nome', "width": "15%" },
            { data: 'categoria.nome', "width": "10%" },
            { data: 'estoque', "width": "10%" },
            {
                data: 'preco', "width": "10%",
                render: function (data, type, row) {
                    return type === 'display' ? '<div style="text-align:right;">' + $.fn.dataTable.render.number('.', ',', 2, 'R$ ').display(data) + '</div>' : data;
                }
            },
            {
                data: 'id',
                "render": function (data) {
                    return `<div class="text-center d-flex justify-content-center" role="group">
                     <a href="/Admin/Bicicleta/Upsert?id=${data}" class="btn btn-primary px-4 mx-2"> <i class="bi bi-pencil-square"></i> Editar</a>               
                     <a onClick=Delete('/Admin/Bicicleta/Delete/${data}') class="btn btn-danger px-4 mx-2"> <i class="bi bi-trash-fill"></i> Excluir</a>
                    </div>`
                },
                "width": "25%"
            }
        ],
    });
}

function Delete(url) {
    Swal.fire({
        title: 'Confirmar exclusão',
        text: "Deseja excluir este registro? Esta ação é irreversível!",
        icon: 'warning',
        showCancelButton: true,
        confirmButtonColor: '#3085d6',
        cancelButtonColor: '#d33',
        confirmButtonText: 'Excluir',
        cancelButtonText: "Cancelar"
    }).then((result) => {
        if (result.isConfirmed) {
            $.ajax({
                url: url,
                type: 'DELETE',
                success: function (data) {
                    dataTable.ajax.reload();
                    toastr.success(data.message);
                }
            })
        }
    })
}