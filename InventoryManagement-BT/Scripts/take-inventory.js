$(document).ready(function () {



})

function ShowAddInventoryModal() {
    TriggerAddInventoryModal();
    $('.datepicker').datepicker({
        format: 'mm/dd/yyyy'
    }); //Initialise any date pickers

}

function TriggerAddInventoryModal() {
    $(".modal").modal("show");
}

function CloseModal() {
    $(".modal").modal("hide");
}

function HandleError(response) {

    $('#add-inventory-container').html(response.responseText);
    TriggerAddInventoryModal();
}


