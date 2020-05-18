var dataTable;
$(document).ready(function () {
    loadDataTable();
});

function loadDataTable() {
    dataTable = $('#tblData').dataTable({
        "ajax": {
            "url": "Suppliers/GetAllJson"
        },
        "columns": [
            { "data": "name" },
            { "data": "nationality" },
            { "data": "address" },
            { "data": "commercialRefferent" },
            { "data": "EmailCom" },
            { "data": "phoneCom" },
            { "data": "technicalRefferent" },
            { "data": "phoneTechn" },
            { "data": "EmailTechn" },
            { "data": "approvTemp" },
            {
                "data": "id",
                "render": function (data) {
                    return '
                        < div class="text-center" >
                            <a href="/Suppliers/Upsert/$(data)" class="btn btn-success text-white" style="cursor:pointer">
                                <i class="fas fa-edit"></i>
                            </a>
                            <a href="/Suppliers/Upsert/id" class="btn btn-danger text-white" style="cursor:pointer">
                                <i class="fas fa-trash-alt"></i>
                            </a>
                        </div >

                        ';
                }
            }

        ]
    })
}


<th>Nazione</th>
    <th>Indirizzo</th>
    <th>Ref Comm</th>
    <th>Telefono</th>
    <th>Email</th>
    <th>Appr Temp</th>