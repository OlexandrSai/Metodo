var dataTable;

$(document).ready(function () {
    loadDataTable();
});


function loadDataTable() {
    dataTable = $('#tblData').DataTable({
        "ajax": {
            "url": "/Suppliers/GetAllJson"
        },
        "columns": [
            { "data": "Name" },
            { "data": "Nationality" },
            { "data": "Address" },
            { "data": "CommercialRefferent" },
            { "data": "EmailCom" },
            { "data": "PhoneCom" },
            { "data": "TechnicalRefferent" },
            { "data": "PhoneTechn" },
            { "data": "EmailTechn" },
            { "data": "ApprovTemp" },
            {
                "data": "Id",
                "render": function (data) {
                    return `
                            <div class="text-center">
                                <a href="/Admin/Category/Upsert/${data}" class="btn btn-success text-white" style="cursor:pointer">
                                    <i class="fas fa-edit"></i> 
                                </a>
                                <a onclick=Delete("/Admin/Category/Delete/${data}") class="btn btn-danger text-white" style="cursor:pointer">
                                    <i class="fas fa-trash-alt"></i> 
                                </a>
                            </div>
                           `;
                }, "width": "40%"
            }
        ]
    });
}
