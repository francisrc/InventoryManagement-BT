    $(".modal").modal("show");
    $('.datepicker').datepicker();
function CloseModal() {
}

function HandleError(response) {
 
    $('#add-inventory-container').html(response.responseText);
    TriggerAddInventoryModal();
}


