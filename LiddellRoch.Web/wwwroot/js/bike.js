$(document).ready(function () {
    loadDataTable();
});

function loadDataTable() {
    dataTable = $('#tblData').DataTable({
        language: {
            url: '//cdn.datatables.net/plug-ins/1.13.6/i18n/pt-BR.json',
        },
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
                    return `<div class="w-75 btn-group" role="group">
                     <a href="/admin/bicicleta/upsert?id=${data}" class="btn btn-primary mx-2"> <i class="bi bi-pencil-square"></i> Editar</a>               
                     <a onClick=Delete('/admin/bicicleta/delete/${data}') class="btn btn-danger mx-2"> <i class="bi bi-trash-fill"></i> Excluir</a>
                    </div>`
                },
                "width": "25%"
            }
        ]
    });
}

function Delete(url) {
    Swal.fire({
        title: 'Você tem certeza?',
        text: "Esta ação é irreversível!",
        icon: 'warning',
        showCancelButton: true,
        confirmButtonColor: '#3085d6',
        cancelButtonColor: '#d33',
        confirmButtonText: 'Sim, exclua!'
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