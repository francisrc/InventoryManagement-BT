$(document).ready(function () {
    $('.take-inventory-form').on('submit', function (e) {
        e.preventDefault();
        $.ajax({
            url: $(this).attr('action'),
            type: "POST",
            data: $(this).serialize(),
            success: function (data) {
                HideTakeInventoryDescription();
                $("#search-results").html(data);
            },
            error: function(xhr) {
                $(".take-inventory-form").html(xhr.responseText);
            }
        });
    });

    $('.search-inventory-form').on('submit', function (e) {
        e.preventDefault();
        $.ajax({
            url: $(this).attr('action'),
            type: "POST",
            data: $(this).serialize(),
            success: function (data) {
                $("#search-results").html(data);
                HidePageDescription();
            },
            error: function (xhr) {
            }
        });
    });

    $('.add-asset-form').on('submit', function (e) {
        e.preventDefault();
        $.ajax({
            url: $(this).attr('action'),
            type: "POST",
            data: $(this).serialize(),
            success: function (data) {
                CloseModal();
            },
            error: function (xhr) {
                HandleError(xhr);
            }
        });
    });

    $('#search-results').on('click', '.edit-asset-link', function (e) {
        e.preventDefault();
        $.ajax({
            url: $(this).attr('href'),
            type: "GET",
            success: function (data) {
                $("#add-inventory-container").html(data);
                ShowAddInventoryModal();
            },
            error: function (xhr) {
                
            }
        });
    });

    $('#search-results').on('click', '.add-asset-link', function (e) {
        e.preventDefault();
        $.ajax({
            url: $(this).attr('href'),
            type: "GET",
            success: function (data) {
                $("#add-inventory-container").html(data);
                ShowAddInventoryModal();
                assetTag = $("#AssetTag");
                val = assetTag.data("disabled");
                if (val == "False")
                    assetTag.attr("readonly", "readonly");
            },
            error: function (xhr) {
                HandleError(xhr);
            }
        });
    });

    $('#add-inventory-container').on('submit', '.update-asset-form', function (e) {
        e.preventDefault();
        $.ajax({
            url: $(this).attr('action'),
            type: "POST",
            data: $(this).serialize(),
            success: function (data) {
                CloseModal();
                $("#add-inventory-modal").html(data);
            },
            error: function (xhr) {
                $(".update-asset-form").html(xhr.responseText);
            }
        });
    });

});


function ShowAddInventoryModal() {
    TriggerAddInventoryModal();
    $('.datepicker').datepicker({
        format: 'mm/dd/yyyy',
        startDate: '01/01/1900'
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




