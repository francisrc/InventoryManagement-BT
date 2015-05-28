﻿$(document).ready(function () {



})

function ShowAddInventoryModal() {
    TriggerAddInventoryModal();
    $('.datepicker').datepicker({
        format: 'mm/dd/yyyy'
    }); 
    
}

function HideTakeInventoryDescription() {
    $("#take-inventory-description").hide();
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

function HidePageDescription() {
    $("#page-description").hide();
}


