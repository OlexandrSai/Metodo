﻿var dataTable;

$(document).ready(function () {
    loadDataTable();
});


function loadDataTable() {
    dataTable = $('#tblData').DataTable({
        "ajax": {
            "url": "/Suppliers/GetAllJson/"
        },
        "columns": [
            { "data": "name" },
            { "data": "nationality" },
            { "data": "address" },
            { "data": "commercialRefferent" },
            { "data": "phoneCom" },
            { "data": "emailCom" },           
            { "data": "technicalRefferent" },
            { "data": "phoneTechn" },
            { "data": "emailTechn" },
            { "data": "approvTemp" },
            {
                "data": "Id",
                "render": function (data) {
                    return `
                            <div class="text-center">
                                <a href="/Suppliers/Upsert/${data}" class="btn btn-success text-white" style="cursor:pointer">
                                    <i class="fas fa-edit"></i> 
                                </a>
                                <a onclick=Delete("/Suppliers/Delete/${data}") class="btn btn-danger text-white" style="cursor:pointer">
                                    <i class="fas fa-trash-alt"></i> 
                                </a>
                            </div>
                           `;
                }, "width": "10%"
            }
        ]
    });
}

function Delete(url) {
    swal({
        title: "Sei sicuro vuoi cancellare?",
        text: "Non potrai recuperare i dati!",
        icon: "warning",
        buttons: true,
        dangerMode: true
    }).then((willDelete) => {
        if (willDelete) {
            $.ajax({
                type: "DELETE",
                url: url,
                success: function (data) {
                    if (data.success) {
                        toastr.success(data.message);
                        dataTable.ajax.reload();
                    }
                    else {
                        toastr.error(data.message);
                    }
                }
            });
        }
    });
}