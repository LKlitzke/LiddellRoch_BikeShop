var dataTable;

$(document).ready(function () {
    loadDataTable();
});

function loadDataTable() {
    dataTable = $('#tblData').DataTable({
        language: {
            url: '//cdn.datatables.net/plug-ins/1.13.6/i18n/pt-BR.json',
        },
        "ajax": { url: '/admin/user/getall' },
        "columns": [
            { "data": "name", "width": "15%" },
            { "data": "email", "width": "15%" },
            { "data": "phoneNumber", "width": "15%" },
            { "data": "company.name", "width": "15%" },
            { "data": "role", "width": "10%" },
            {
                data: { id: "id", lockoutEnd: "lockoutEnd" },
                "render": function (data) {
                    var today = new Date().getTime();
                    var lockout = new Date(data.lockoutEnd).getTime();

                    if (lockout > today) {
                        return `<div class="text-center">
                             <a onclick=LockUnlock('${data.id}') class="btn btn-danger text-white" title="Bloquear" style="cursor:pointer;">
                                    <i class="bi bi-lock-fill"></i>
                                </a> 
                                <a href="/admin/user/RoleManagement?userId=${data.id}" class="btn btn-secondary text-white" title="Alterar papel" style="cursor:pointer;">
                                     <i class="bi bi-pencil-square"></i>
                                </a>
                                <a href="/admin/user/ClaimManagement?userId=${data.id}" class="btn btn-secondary text-white" title="Alterar papel" style="cursor:pointer;">
                                     <i class="bi-check-square"></i>
                                </a>
                                <a onclick=Delete('/admin/user/Delete?userId=${data.id}') class="btn btn-danger text-white" title="Excluir" style="cursor:pointer;">
                                     <i class="bi bi-trash"></i>
                                </a>
                        </div>`
                    }
                    else {
                        return `<div class="text-center">
                              <a onclick=LockUnlock('${data.id}') class="btn btn-success text-white" title="Desbloquear" style="cursor:pointer;">
                                    <i class="bi bi-unlock-fill"></i>
                                </a>
                                <a href="/admin/user/RoleManagement?userId=${data.id}" class="btn btn-secondary text-white" title="Alterar papel" style="cursor:pointer;">
                                     <i class="bi bi-pencil-square"></i>
                                </a>
                                 <a href="/admin/user/ClaimManagement?userId=${data.id}" class="btn btn-secondary text-white" title="Alterar papel" style="cursor:pointer;">
                                     <i class="bi-check-square"></i>
                                </a>
                                <a onclick=Delete('/admin/user/Delete?userId=${data.id}') class="btn btn-danger text-white" title="Excluir" style="cursor:pointer;">
                                     <i class="bi bi-trash"></i>
                                </a>
                        </div>`
                    }
                },
                "width": "20%"
            }
        ]
    });
}


function LockUnlock(id) {
    $.ajax({
        type: "POST",
        url: '/Admin/User/LockUnlock',
        data: JSON.stringify(id),
        contentType: "application/json",
        success: function (data) {
            if (data.success) {
                toastr.success(data.message);
                dataTable.ajax.reload();
            }
        }
    });
}


function Delete(url) {
    Swal.fire({
        title: 'Confirmação de exclusão',
        text: "Esta ação é irreversível!",
        icon: 'warning',
        showCancelButton: true,
        confirmButtonColor: '#3085d6',
        cancelButtonColor: '#d33',
        confirmButtonText: 'Excluir'
    }).then((result) => {
        if (result.isConfirmed) {
            $.ajax({
                url: url,
                type: 'DELETE',
                success: function (data) {
                    if (data["success"] == "success") {
                        toastr.success(data.message);
                    }
                    else {
                        toastr.error(data.message);
                    }
                    dataTable.ajax.reload();
                }
            })
        }
    })
}