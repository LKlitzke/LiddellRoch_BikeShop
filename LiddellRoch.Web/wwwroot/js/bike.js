$(document).ready(function () {
    loadDataTable();
});

function loadDataTable() {
    dataTable = $('#tblData').DataTable({
        language: {
            url: '//cdn.datatables.net/plug-ins/1.13.6/i18n/pt-BR.json',
        },
        dom: 'Bfrtip',
        buttons: [
            //'excelHtml5',
            {
                extend: 'colvis',
                columnText: function (dt, idx, title) {
                    return (idx + 1) + ': ' + title;
                }
            },
            {
                extend: 'excelHtml5',
                title: 'LiddellRoch - Lista de Bikes',
                exportOptions: {
                    columns: [0, 1, 2, 3, 4]
                }
            },
            {
                extend: 'csvHtml5',
                title: 'LiddellRoch - Lista de Bikes',
                exportOptions: {
                    columns: [0, 1, 2, 3, 4]
                }
            },
            {
                extend: 'pdfHtml5',
                className: 'btn-outline-danger btn-sm ',
                //customize: function (doc) {
                //    doc.content.splice(1, 0, {
                //        margin: [0, 0, 0, 12],
                //        alignment: 'center'
                //    });
                //},
                //titleAttr: 'Generate PDF',
                exportOptions: {
                    columns: [0, 1, 2, 3, 4]
                },
                title: 'LiddellRoch - Lista de Bikes',
                messageTop: 'PDF created by PDFMake with Buttons for DataTables.'
                //customize: function (doc) {
                //    doc.defaultStyle =
                //    {
                //        font: 'Arial',
                //    };
                //}
            }            
        ],
        "ajax": { url: '/admin/bicicleta/getall' },
        "columns": [
            { data: 'nome', "width": "25%" },
            { data: 'estoque', "width": "15%" },
            { data: 'preco', "width": "10%", render: $.fn.dataTable.render.number('.', ',', 2, 'R$ ') },
            { data: 'marca.nome', "width": "15%" },
            { data: 'categoria.nome', "width": "10%" },
            {
                data: 'id',
                "render": function (data) {
                    return `<div class="text-center d-flex justify-content-center" role="group">
                     <a href="/Admin/Bicicleta/Upsert?id=${data}" class="btn btn-primary mx-2 w-25"> <i class="bi bi-pencil-square"></i> Editar</a>               
                     <a onClick=Delete('/Admin/Bicicleta/Delete/${data}') class="btn btn-danger mx-2 w-25"> <i class="bi bi-trash-fill"></i> Excluir</a>
                    </div>`
                },
                "width": "25%"
            }
        ]
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