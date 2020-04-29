$(document).ready(function () {
    var required = $("#required").data("kendoMultiSelect");
    $("#get").click(function () {
        alert("Attendees:\n\nRequired: " + required.value());
    });
    $('.disabledcard *').prop('disabled', true);
    $('[data-toggle="tooltip"]').tooltip();
});

function ItemCreateOnComplete() {
    $('.itemBtn').click();
}

$(document).on('click', '.goHome', function (e) {
    e.preventDefault();
    $.ajax({
        type: "GET",
        url: "/Home/Index",
        success: function (data) {
            $("#partialViewDiv").html(data);
        },
        error: function (result) {
            alert('error');
        }
    });
});
//Items CRUD
$(document).on('click', '.itemBtn', function (e) {
    e.preventDefault();
    $.ajax({
        type: "GET",
        url: "/Items/",
        success: function (data) {
            $("#partialViewDiv").html(data);
        },
        error: function (result) {
            alert("error");
        }
    });
});
$(document).on('click', '.addItemBtn', function (e) {
    e.preventDefault();
    $.ajax({
        type: "GET",
        url: "/Items/Create",
        success: function (data) {
            $("#partialViewDiv").html(data);
        },
        error: function (result) {
            alert('error');
        }
    });
});

//Assets CRUD
$(document).on('click', '.assetBtn', function (e) {
    e.preventDefault();
    $.ajax({
        type: "GET",
        url: "/Assets/",
        success: function (data) {
            $("#partialViewDiv").html(data);
        },
        error: function (result) {
            alert('error');
        }
    });
});
$(document).on('click', '.addAssetBtn', function (e) {
    e.preventDefault();
    $.ajax({
        type: "GET",
        url: "/Assets/Create",
        success: function (data) {
            $("#partialViewDiv").html(data);
        },
        error: function (result) {
            alert('error');
        }
    });
});


//Manutations CRUD
$(document).on('click', '.manutationsBtn', function (e) {
    e.preventDefault();
    $.ajax({
        type: "GET",
        url: "/Manutations/",
        success: function (data) {
            $("#partialViewDiv").html(data);
        },
        error: function (result) {
            alert('error');
        }
    });
});
$(document).on('click', '.addManutationBtn', function (e) {
    e.preventDefault();
    $.ajax({
        type: "GET",
        url: "/Manutations/Create",
        success: function (data) {
            $("#partialViewDiv").html(data);
        },
        error: function (result) {
            alert('error');
        }
    });
});
$(document).on('click', '.editManutationBtn', function (e) {
    e.preventDefault();
    $.ajax({
        type: "GET",
        url: "/Manutations/Edit",
        success: function (data) {
            $("#partialViewDiv").html(data);
        },
        error: function (result) {
            alert('error');
        }
    });
});

//UsersCrudUserCreateOnComplete
$(document).on('click', '.userBtn', function (e) {
    e.preventDefault();
    $.ajax({
        type: "GET",
        url: "/Users/",
        success: function (data) {
            $("#partialViewDiv").html(data);
        },
        error: function (result) {
            alert('error');
        }
    });
});
$(document).on('click', '.addUserBtn', function (e) {
    e.preventDefault();
    $.ajax({
        type: "GET",
        url: "/Users/Create",
        success: function (data) {
            $("#partialViewDiv").html(data);
        },
        error: function (result) {
            alert('error');
        }
    });
});


function ManutationCreateOnComplete() {
    $('.goHome').click();
}
function GetManutationEditForm(data) {
    $('#partialViewDiv').html(data);
}
function GetAssetEditForm(data) {
    $('#partialViewDiv').html(data);
}
function AssetCreateOnComplete() {
    $('.assetBtn').click();
}

function GetItemEditForm(data) {
    $('#partialViewDiv').html(data);
}
function ToolCreateOnComplete(e) {
    $('#createNewTool').modal('hide');
    $.ajax({
        type: "GET",
        url: "/Tools/GetAll",
        success: function (data) {
            $("#toolsViewDiv").html(data);
        },
        error: function (result) {
            alert('error');
        }
    });
}

function ToolDeleteComplete(e) {
    $.ajax({
        type: "GET",
        url: "/Tools/GetAll",        success: function (data) {
            $("#toolsViewDiv").html(data);
        },
        error: function (result) {
            alert('error');
        }
    });
}

function ToolEditComplete(e) {
    $('#editToolForm').modal('hide');
    $.ajax({
        type: "GET",
        url: "/Tools/GetAll",
        success: function (data) {
            $("#toolsViewDiv").html(data);
        },
        error: function (result) {
            alert('error');
        }
    });
}

function GetToolEditForm(data) {
    $('#editForm').html(data);
    $('#editToolForm').modal('show');

}

function ConsumableCreateOnComplete(e) {
    $('#createNewConsumable').modal('hide');
    $.ajax({
        type: "GET",
        url: "/Consumables/GetAll",
        success: function (data) {
            $("#consumablesViewDiv").html(data);
        },
        error: function (result) {
            alert('error');
        }
    });
}

function SupplierCreateOnComplete(e) {
    $('#createNewSupplier').modal('hide');
    $.ajax({
        type: "GET",
        url: "/Suppliers/GetAll",
        success: function (data) {
            $("#suppliersViewDiv").html(data);
        },
        error: function (result) {
            alert('error');
        }
    });
}

function ConsumableDeleteComplete(e) {
    $.ajax({
        type: "GET",
        url: "/Consumables/GetAll",
        success: function (data) {
            $("#consumablesViewDiv").html(data);
        },
        error: function (result) {
            alert('error');
        }
    });
}


function SupplierDeleteComplete(e) {
    $.ajax({
        type: "GET",
        url: "/Suppliers/GetAll",
        success: function (data) {
            $("#suppliersViewDiv").html(data);
        },
        error: function (result) {
            alert('error');
        }
    });
}

function ConsumableEditComplete(e) {
    $('#editConsumableForm').modal('hide');
    $.ajax({
        type: "GET",
        url: "/Consumables/GetAll",
        success: function (data) {
            $("#consumablesViewDiv").html(data);
        },
        error: function (result) {
            alert('error');
        }
    });
}

function SupplierEditComplete(e) {
    $('#editSupplierForm').modal('hide');
    $.ajax({
        type: "GET",
        url: "/Suppliers/GetAll",
        success: function (data) {
            $("#suppliersViewDiv").html(data);
        },
        error: function (result) {
            alert('error');
        }
    });
}

function GetConsumableEditForm(data) {
    $('#editConsumable').html(data);
    $('#editConsumableForm').modal('show');

}

function GetSupplierEditForm(data) {
    $('#editForm').html(data);
    $('#editSupplierForm').modal('show');

}

function GetUserEditForm(data) {
    $('#partialViewDiv').html(data);
}
function UserCreateOnComplete() {
    $('.userBtn').click();
}

function GetTimelineHtml(data) {
    $('#timelineModalDiv').html(data);
    $('#timelineModal').modal('show');
}

function addCircles() {
    $('.mtrue').addClass('btn-danger');
    $('.mfalse').addClass('btn-warning');
}




//$(document).on('click', '#AddAttivitaMdc', function (e) {
//    e.preventDefault();
//    var prevHtml = $('#attivitaMdcList').html();
//    $('#attivitaMdcList').html(prevHtml + '<div><button type="button" class="btn btn-light">' + $('#attivittaMdcName').val() + '<span class="badge badge-dark">' + $('#attivittaMdcCount').val() + '</span><button type="button" class="attivitaClose"><span aria-hidden="true">&times;</span></button></button></div>');
//    $('#attivitaAttrezzaturaModal').modal('hide');
//});

$(document).on('click', '#AddAttivitaMdc', function (e) {
    e.preventDefault();
    var prevHtml;
    var isContains = $('#attivitaMdcList').text().indexOf($('#attivittaMdcName').val()) > -1;
    if (isContains) {
        $('button:contains(' + $('#attivittaMdcName').val() + ')').html($('#attivittaMdcName').val() + '<span class="badge badge-dark">' + $('#attivittaMdcCount').val() + '</span>');
        prevHtml = $('#attivitaMdcList').html();
    } else {
        prevHtml = $('#attivitaMdcList').html();
        $('#attivitaMdcList').html(prevHtml + '<div class="attivitaMdc"><button type="button" class="btn btn-light">' + $('#attivittaMdcName').val() + '<span class="badge badge-dark">' + $('#attivittaMdcCount').val() + '</span><button type="button" class="attivitaClose"><span aria-hidden="true">&times;</span></button></button></div>');
    }
    $('#attivitaAttrezzaturaModal').modal('hide');
});

$(document).on('click', '#AddCheckOutMdc', function (e) {
    e.preventDefault();
    var prevHtml;
    var isContains = $('#checkOutMdcList').text().indexOf($('#checkOutMdcName').val()) > -1;
    if (isContains) {
        $('button:contains(' + $('#checkOutMdcName').val() + ')').html($('#checkOutMdcName').val() + '<span class="badge badge-dark">' + $('#checkOutMdcCount').val() + '</span>');
        prevHtml = $('#checkOutMdcList').html();
    } else {
        prevHtml = $('#checkOutMdcList').html();
        $('#checkOutMdcList').html(prevHtml + '<div class="checkOutMdc"><button type="button" class="btn btn-light">' + $('#checkOutMdcName').val() + '<span class="badge badge-dark">' + $('#checkOutMdcCount').val() + '</span><button type="button" class="checkOutClose"><span aria-hidden="true">&times;</span></button></button></div>');
    }
    $('#checkOutAttrezzaturaModal').modal('hide');
});

$(document).on('click', '#AddAttivitaMeasuring', function (e) {
    e.preventDefault();
    var prevHtml;
    var isContains = $('#attivitaMeasuringList').text().indexOf($('#attivittaMeasuringName').val()) > -1;
    if (isContains) {
        $('button:contains(' + $('#attivittaMeasuringName').val() + ')').html($('#attivittaMeasuringName').val() + '<span class="badge badge-dark">' + $('#attivittaMeasuringCount').val() + '</span>');
        prevHtml = $('#attivitaMdcList').html();
    } else {
        prevHtml = $('#attivitaMeasuringList').html();
        $('#attivitaMeasuringList').html(prevHtml + '<div class="attivitaMeasuring"><button type="button" class="btn btn-light">' + $('#attivittaMeasuringName').val() + '<span class="badge badge-dark">' + $('#attivittaMeasuringCount').val() + '</span><button type="button" class="attivitaClose"><span aria-hidden="true">&times;</span></button></button></div>');
    }
    $('#attivitaMeasuringModal').modal('hide');
});

$(document).on('click', '#AddCheckOutMeasuring', function (e) {
    e.preventDefault();
    var prevHtml;
    var isContains = $('#checkOutMeasuringList').text().indexOf($('#checkOutMeasuringName').val()) > -1;
    if (isContains) {
        $('button:contains(' + $('#checkOutMeasuringName').val() + ')').html($('#checkOutMeasuringName').val() + '<span class="badge badge-dark">' + $('#checkOutMeasuringCount').val() + '</span>');
        prevHtml = $('#checkOutMeasuringList').html();
    } else {
        prevHtml = $('#checkOutMeasuringList').html();
        $('#checkOutMeasuringList').html(prevHtml + '<div class="checkOutMeasuring"><button type="button" class="btn btn-light">' + $('#checkOutMeasuringName').val() + '<span class="badge badge-dark">' + $('#checkOutMeasuringCount').val() + '</span><button type="button" class="checkOutClose"><span aria-hidden="true">&times;</span></button></button></div>');
    }
    $('#checkOutMeasuringModal').modal('hide');
});

$(document).on('click', '#AddAttivitaConsumable', function (e) {
    e.preventDefault();
    var prevHtml;
    var isContains = $('#attivitaConsumableList').text().indexOf($('#attivittaConsumableName').val()) > -1;
    if (isContains) {
        $('button:contains(' + $('#attivittaConsumableName').val() + ')').html($('#attivittaConsumableName').val() + '<span class="badge badge-dark">' + $('#attivittaConsumableCount').val() + '</span>');
        prevHtml = $('#attivitaConsumableList').html();
    } else {
        prevHtml = $('#attivitaConsumableList').html();
        $('#attivitaConsumableList').html(prevHtml + '<div class="attivitaConsumable"><button type="button" class="btn btn-light">' + $('#attivittaConsumableName').val() + '<span class="badge badge-dark">' + $('#attivittaConsumableCount').val() + '</span><button type="button" class="attivitaClose"><span aria-hidden="true">&times;</span></button></button></div>');
    }
    $('#attivitaConsumableModal').modal('hide');
});

$(document).on('click', '#AddAttivitaItem', function (e) {
    e.preventDefault();
    var prevHtml;
    var isContains = $('#attivitaItemsList').text().indexOf($('#attivittaItemName').val()) > -1;
    if (isContains) {
        $('button:contains(' + $('#attivittaItemName').val() + ')').html($('#attivittaItemName').val() + '<span class="badge badge-dark">' + $('#attivittaItemCount').val() + '</span>');
        prevHtml = $('#attivitaItemsList').html();
    } else {
        prevHtml = $('#attivitaItemsList').html();
        $('#attivitaItemsList').html(prevHtml + '<div class="attivitaItem"><button type="button" class="btn btn-light">' + $('#attivittaItemName').val() + '<span class="badge badge-dark">' + $('#attivittaItemCount').val() + '</span><button type="button" class="attivitaClose"><span aria-hidden="true">&times;</span></button></button></div>');
    }
    $('#attivitaItemsModal').modal('hide');
});
$(document).on('click', '.attivitaClose', function (e) {
    e.preventDefault();
    $(this).parent().remove();
});

$(document).on('click', '.checkOutClose', function (e) {
    e.preventDefault();
    $(this).parent().remove();
});

$(document).on('hidden.bs.modal', '.modal', function (e) {
    $(this).removeData('bs.modal');
});

$('.group1').on('change', function () {
    $('.group1').not(this).prop('checked', false);
});


$(document).on('click', '#stageFilter', function (e) {
    e.preventDefault();
    var stage = null;
    $('.stagecheck:checkbox:checked').each(function () {
        if (stage == null) {
            stage = $(this).val();
        } else {
            stage += ',' + $(this).val();
        }
    });
    var status = null;
    $('.statuscheck:checkbox:checked').each(function () {
        if (status == null) {
            status = $(this).val();
        } else {
            status += ',' + $(this).val();
        }
    });
    $.ajax({
        type: "GET",
        url: "/ManutationStages/NewView?stageFilter=" + stage +"&statusFilter="+status,
        success: function (data) {
            $("#manutationsViewDiv").html(data);
        },
        error: function (result) {
            alert('error');
        }
    });
});

$(document).on('click', '#statusFilter', function (e) {
    e.preventDefault();
    var status = null;
    $('.statuscheck:checkbox:checked').each(function () {
        if (status == null) {
            status = $(this).val();
        } else {
            status += ',' + $(this).val();
        }
    });
    var stage = null;
    $('.stagecheck:checkbox:checked').each(function () {
        if (stage == null) {
            stage = $(this).val();
        } else {
            stage += ',' + $(this).val();
        }
    });
    $.ajax({
        type: "GET",
        url: "/ManutationStages/NewView?stageFilter=" + stage + "&statusFilter=" + status,
        success: function (data) {
            $("#manutationsViewDiv").html(data);
        },
        error: function (result) {
            alert('error');
        }
    });
});


$(document).on('change', '#utenteName', function (e) {
    if ($(this).children("option:selected").val() != 'Selezionare') {
        $('#assignUtente').prop("disabled", false);
    } 
});

$(document).on('click', '.assignBtn', function (e) {
    e.preventDefault();
    $("#assignUtente").val($(this).val());
    $('#assignModal').modal('show');
});

$(document).on('click', '#assignUtente', function (e) {
    e.preventDefault();
    window.location.href = '/ManutationStages/AssignTo?manutationId=' + $('#assignUtente').val() + '&userName=' + $('#utenteName').val();
});

function renewDisabled() {
    $('.disabledcard *').prop('disabled', true);
}

$(document).on('click', '#pauseCheckIn', function (e) {
    e.preventDefault();
    var model = {};
    model.CheckInManutationId = $('input[name=CheckInManutationId]').val();
    model.CheckInDescription = $('textarea[name=CheckInDescription').val();
    model.CheckInStartDate = $('input[name=CheckInStartDate]').val();
    model.CheckInWorkingHoursCount = $('input[name=CheckInWorkingHoursCount]').val();
    model.CheckInErrorCode = $('select[name = CheckInErrorCode]').children("option:selected").val();
    model.CheckInFaultType = $('select[name = CheckInFaultType]').children("option:selected").val();

    $.ajax({
        type: "POST",
        url: $('#pauseCheckIn').attr('formaction'),
        data: JSON.stringify(model),
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (data) {
            $.ajax({
                type: "GET",
                url: '/ManutationStages/DetailsP/' + model.CheckInManutationId,
                success: function (data) {
                    $('#details').html(data);
                    $('.disabledcard *').prop('disabled', true);
                }
            });
        },
    });
});

$(document).on('click', '#finishCheckIn', function (e) {
    e.preventDefault();
    var model = {};
    model.CheckInManutationId = $('input[name=CheckInManutationId]').val();
    model.CheckInDescription = $('textarea[name=CheckInDescription').val();
    model.CheckInStartDate = $('input[name=CheckInStartDate]').val();
    model.CheckInEndDate = $('input[name=CheckInEndDate]').val();
    model.CheckInWorkingHoursCount = $('input[name=CheckInWorkingHoursCount]').val();
    model.CheckInErrorCode = $('select[name = CheckInErrorCode]').children("option:selected").val();
    model.CheckInFaultType = $('select[name = CheckInFaultType]').children("option:selected").val();

    $.ajax({
        type: "POST",
        url: $('#finishCheckIn').attr('formaction'),
        data: JSON.stringify(model),
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (data) {
            $.ajax({
                type: "GET",
                url: '/ManutationStages/DetailsP/' + model.CheckInManutationId,
                success: function (data) {
                    $('#details').html(data);
                    $('.disabledcard *').prop('disabled', true);
                }
            });
        },
    });
});

$(document).on('click', '#editCheckIn', function (e) {
    e.preventDefault();
    var model = {};
    model.CheckInManutationId = $('input[name=CheckInManutationId]').val();
    model.CheckInDescription = $('textarea[name=CheckInDescription').val();
    model.CheckInStartDate = $('input[name=CheckInStartDate]').val();
    model.CheckInEndDate = $('input[name=CheckInEndDate]').val();
    model.CheckInWorkingHoursCount = $('input[name=CheckInWorkingHoursCount]').val();
    model.CheckInErrorCode = $('select[name = CheckInErrorCode]').children("option:selected").val();
    model.CheckInFaultType = $('select[name = CheckInFaultType]').children("option:selected").val();

    $.ajax({
        type: "POST",
        url: $('#editCheckIn').attr('formaction'),
        data: JSON.stringify(model),
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (data) {
            window.location.href = '/ManutationStages/Details/' + model.CheckInManutationId;
        },
    });
});

$(document).on('click', '#pauseAttivita', function (e) {
    e.preventDefault();
    var model = {};
    model.ManutationId = $('input[name=AttivitaManutationId]').val();
    model.Description = $('textarea[name=AttivitaDescription').val();
    model.AttivitaStartDate = $('input[name=AttivitaStartDate]').val();
    model.SpareParts = {};
    model.Consumables = {};
    model.Tools = {};
    model.MeasuringTools = {};

    $(".attivitaConsumable").each(function () {
        var name = $(this).children('button').first().contents().get(0).nodeValue;
        var count = $(this).children('button').first().children('span').text();
        model.Consumables[name] = count;
    });

    $(".attivitaMdc").each(function () {
        var name = $(this).children('button').first().contents().get(0).nodeValue;
        var count = $(this).children('button').first().children('span').text();
        model.Tools[name] = count;
    });

    $(".attivitaMeasuring").each(function () {
        var name = $(this).children('button').first().contents().get(0).nodeValue;
        var count = $(this).children('button').first().children('span').text();
        model.MeasuringTools[name] = count;
    });

    $(".attivitaItem").each(function () {
        var name = $(this).children('button').first().contents().get(0).nodeValue;
        var count = $(this).children('button').first().children('span').text();
        model.SpareParts[name] = count;
    });

    $.ajax({
        type: "POST",
        url: $('#pauseAttivita').attr('formaction'),
        data: JSON.stringify(model),
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (data) {
            $.ajax({
                type: "GET",
                url: '/ManutationStages/DetailsP/' + model.ManutationId,
                success: function (data) {
                    $('#details').html(data);
                    $('.disabledcard *').prop('disabled', true);
                }
            });
        },
    });
});

$(document).on('click', '#finishAttivita', function (e) {
    e.preventDefault();
    var model = {};
    model.ManutationId = $('input[name=AttivitaManutationId]').val();
    model.Description = $('textarea[name=AttivitaDescription').val();
    model.AttivitaStartDate = $('input[name=AttivitaStartDate]').val();
    model.AttivitaEndDate = $('input[name=AttivitaEndDate]').val();
    model.SpareParts = {};
    model.Consumables = {};
    model.Tools = {};
    model.MeasuringTools = {};

    $(".attivitaConsumable").each(function () {
        var name = $(this).children('button').first().contents().get(0).nodeValue;
        var count = $(this).children('button').first().children('span').text();
        model.Consumables[name] = count;
    });

    $(".attivitaMdc").each(function () {
        var name = $(this).children('button').first().contents().get(0).nodeValue;
        var count = $(this).children('button').first().children('span').text();
        model.Tools[name] = count;
    });

    $(".attivitaMeasuring").each(function () {
        var name = $(this).children('button').first().contents().get(0).nodeValue;
        var count = $(this).children('button').first().children('span').text();
        model.MeasuringTools[name] = count;
    });

    $(".attivitaItem").each(function () {
        var name = $(this).children('button').first().contents().get(0).nodeValue;
        var count = $(this).children('button').first().children('span').text();
        model.SpareParts[name] = count;
    });

    $.ajax({
        type: "POST",
        url: $('#finishAttivita').attr('formaction'),
        data: JSON.stringify(model),
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (data) {
            $.ajax({
                type: "GET",
                url: '/ManutationStages/DetailsP/' + model.ManutationId,
                success: function (data) {
                    $('#details').html(data);
                    $('.disabledcard *').prop('disabled', true);
                }
            });
        },
    });
});

$(document).on('click', '#editAttivita', function (e) {
    e.preventDefault();
    var model = {};
    model.ManutationId = $('input[name=AttivitaManutationId]').val();
    model.Description = $('textarea[name=AttivitaDescription').val();
    model.AttivitaStartDate = $('input[name=AttivitaStartDate]').val();
    model.AttivitaEndDate = $('input[name=AttivitaEndDate]').val();
    model.SpareParts = {};
    model.Consumables = {};
    model.Tools = {};
    model.MeasuringTools = {};

    $(".attivitaConsumable").each(function () {
        var name = $(this).children('button').first().contents().get(0).nodeValue;
        var count = $(this).children('button').first().children('span').text();
        model.Consumables[name] = count;
    });

    $(".attivitaMdc").each(function () {
        var name = $(this).children('button').first().contents().get(0).nodeValue;
        var count = $(this).children('button').first().children('span').text();
        model.Tools[name] = count;
    });

    $(".attivitaMeasuring").each(function () {
        var name = $(this).children('button').first().contents().get(0).nodeValue;
        var count = $(this).children('button').first().children('span').text();
        model.MeasuringTools[name] = count;
    });

    $(".attivitaItem").each(function () {
        var name = $(this).children('button').first().contents().get(0).nodeValue;
        var count = $(this).children('button').first().children('span').text();
        model.SpareParts[name] = count;
    });

    $.ajax({
        type: "POST",
        url: $('#editAttivita').attr('formaction'),
        data: JSON.stringify(model),
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (data) {
            window.location.href = '/ManutationStages/Details/' + model.ManutationId;
        },
    });
});

$(document).on('click', '#pauseCheckOut', function (e) {
    e.preventDefault();
    var model = {};
    model.ManutationId = $('input[name=CheckOutManutationId]').val();
    model.Description = $('textarea[name=CheckOutDescription').val();
    model.CheckOutStartDate = $('input[name=CheckOutStartDate]').val();
    model.Tools = {};
    model.MeasuringTools = {};

    $(".checkOutMdc").each(function () {
        var name = $(this).children('button').first().contents().get(0).nodeValue;
        var count = $(this).children('button').first().children('span').text();
        model.Tools[name] = count;
    });

    $(".checkOutMeasuring").each(function () {
        var name = $(this).children('button').first().contents().get(0).nodeValue;
        var count = $(this).children('button').first().children('span').text();
        model.MeasuringTools[name] = count;
    });

    $.ajax({
        type: "POST",
        url: $('#pauseCheckOut').attr('formaction'),
        data: JSON.stringify(model),
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (data) {
            $.ajax({
                type: "GET",
                url: '/ManutationStages/DetailsP/' + model.ManutationId,
                success: function (data) {
                    $('#details').html(data);
                    $('.disabledcard *').prop('disabled', true);
                }
            });
        },
    });
});


$(document).on('click', '#finishCheckOut', function (e) {
    e.preventDefault();
    var model = {};
    model.ManutationId = $('input[name=CheckOutManutationId]').val();
    model.Description = $('textarea[name=CheckOutDescription').val();
    model.CheckOutStartDate = $('input[name=CheckOutStartDate]').val();
    model.CheckOutEndDate = $('input[name=CheckOutEndDate]').val();
    model.Tools = {};
    model.MeasuringTools = {};

    $(".checkOutMdc").each(function () {
        var name = $(this).children('button').first().contents().get(0).nodeValue;
        var count = $(this).children('button').first().children('span').text();
        model.Tools[name] = count;
    });

    $(".checkOutMeasuring").each(function () {
        var name = $(this).children('button').first().contents().get(0).nodeValue;
        var count = $(this).children('button').first().children('span').text();
        model.MeasuringTools[name] = count;
    });

    $.ajax({
        type: "POST",
        url: $('#finishCheckOut').attr('formaction'),
        data: JSON.stringify(model),
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (data) {
            window.location.href = '/ManutationStages';
        },
    });
});

//Master spinners

$(document).on('click', '#getAllAssigned', function (e) {
    e.preventDefault();
    $('#getAllAssigned').hide();
    $('#spinner').show();

    $.ajax({
        type: "GET",
        url: $('#getAllAssigned').attr('href'),
        success: function (data) {
            $('#manutations').html(data);
            $('#getAllAssigned').show();
            $('#spinner').hide();
        },
    });
});

$(document).on('click', '#getMyActive', function (e) {
    e.preventDefault();
    $('#getMyActive').hide();
    $('#spinner').show();

    $.ajax({
        type: "GET",
        url: $('#getMyActive').attr('href'),
        success: function (data) {
            $('#manutations').html(data);
            $('#getMyActive').show();
            $('#spinner').hide();
        },
    });
});

$(document).on('click', '#getMyHistorical', function (e) {
    e.preventDefault();
    $('#getMyHistorical').hide();
    $('#spinner').show();

    $.ajax({
        type: "GET",
        url: $('#getMyHistorical').attr('href'),
        success: function (data) {
            $('#manutations').html(data);
            $('#getMyHistorical').show();
            $('#spinner').hide();
        },
    });
});

$(document).on('click', '#getAllPending', function (e) {
    e.preventDefault();
    $('#getAllPending').hide();
    $('#spinner').show();

    $.ajax({
        type: "GET",
        url: $('#getAllPending').attr('href'),
        success: function (data) {
            $('#manutations').html(data);
            $('#getAllPending').show();
            $('#spinner').hide();
        },
    });
});

$(document).on('click', '#getAll', function (e) {
    e.preventDefault();
    $('#getAll').hide();
    $('#spinner').show();

    $.ajax({
        type: "GET",
        url: $('#getAll').attr('href'),
        success: function (data) {
            $('#manutations').html(data);
            $('#getAll').show();
            $('#spinner').hide();
        },
    });
});

$(document).on('click', '#getAllH', function (e) {
    e.preventDefault();
    $('#getAllH').hide();
    $('#spinner').show();

    $.ajax({
        type: "GET",
        url: $('#getAllH').attr('href'),
        success: function (data) {
            $('#manutations').html(data);
            $('#getAllH').show();
            $('#spinner').hide();
        },
    });
});

$(document).on('click', '#validate', function (e) {
    var model = {};
    model.ManutationId = $('input[name=CheckInManutationId]').val();
    model.CheckInDescription = $('textarea[name=CheckInDescription').val();
    model.CheckInStartDate = $('input[name=CheckInStartDate]').val();
    model.CheckInEndDate = $('input[name=CheckInEndDate]').val();
    model.CheckInWorkingHoursCount = $('input[name=CheckInWorkingHoursCount]').val();
    model.CheckInErrorCode = $('select[name = CheckInErrorCode]').children("option:selected").val();
    model.CheckInFaultType = $('select[name = CheckInFaultType]').children("option:selected").val();
    model.AttivitaDescription = $('textarea[name=AttivitaDescription').val();
    model.AttivitaStartDate = $('input[name=AttivitaStartDate]').val();
    model.AttivitaEndDate = $('input[name=AttivitaEndDate]').val();
    model.AttivitaSpareParts = {};
    model.AttivitaConsumables = {};
    model.AttivitaTools = {};
    model.AttivitaMeasuringTools = {};
    model.CheckOutDescription = $('textarea[name=CheckOutDescription').val();
    model.CheckOutStartDate = $('input[name=CheckOutStartDate]').val();
    model.CheckOutEndDate = $('input[name=CheckOutEndDate]').val();
    model.CheckOutTools = {};
    model.CheckOutMeasuringTools = {};

    $(".attivitaConsumable").each(function () {
        var name = $(this).children('button').first().contents().get(0).nodeValue;
        var count = $(this).children('button').first().children('span').text();
        model.AttivitaConsumables[name] = count;
    });

    $(".attivitaMdc").each(function () {
        var name = $(this).children('button').first().contents().get(0).nodeValue;
        var count = $(this).children('button').first().children('span').text();
        model.AttivitaTools[name] = count;
    });

    $(".attivitaItem").each(function () {
        var name = $(this).children('button').first().contents().get(0).nodeValue;
        var count = $(this).children('button').first().children('span').text();
        model.AttivitaSpareParts[name] = count;
    });

    $(".checkOutMdc").each(function () {
        var name = $(this).children('button').first().contents().get(0).nodeValue;
        var count = $(this).children('button').first().children('span').text();
        model.CheckOutTools[name] = count;
    });

    $.ajax({
        type: "POST",
        url: $('#validate').attr('formaction'),
        data: JSON.stringify(model),
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (data) {
            window.location.href = '/ManutationStages/Administration';
        },
    });
   
});
