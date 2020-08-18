// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
$('#exampleModal').on('show.bs.modal', function (event) {
    var button = $(event.relatedTarget) // Button that triggered the modal
    var recipient = button.data('whatever') // Extract info from data-* attributes
    var brandid = button.data('brandid')
    //    // If necessary, you could initiate an AJAX request here (and then do the updating in a callback).
    //    // Update the modal's content. We'll use jQuery here, but you could use a data binding library or other methods instead.
    var modal = $(this)
    modal.find('.modal-brandid input').val(brandid)
    modal.find('.modal-title').text('Brand: ' + recipient)
    //modal.find('.modal-body input').val(recipient)
})
// Write your JavaScript code.
$('#BrandCollectionModal').on('show.bs.modal', function (event) {
    var button = $(event.relatedTarget) // Button that triggered the modal
    var brandcollname = button.data('brandcollname') // Extract info from data-* attributes
    var collectionid = button.data('collectionid')
    // If necessary, you could initiate an AJAX request here (and then do the updating in a callback).
    // Update the modal's content. We'll use jQuery here, but you could use a data binding library or other methods instead.
    var modal = $(this)
    modal.find('.modal-brandcollid input').val(collectionid)
    modal.find('.modal-title').text('BrandCollection: ' + brandcollname)
    //modal.find('.modal-body input').val(recipient)
})
// Write your JavaScript code.
$('#BrandCollectionFinishing').on('show.bs.modal', function (event) {
    var button = $(event.relatedTarget) // Button that triggered the modal
    var brandcollname = button.data('brandcollname') // Extract info from data-* attributes
    var collectionid = button.data('collectionid')
    // If necessary, you could initiate an AJAX request here (and then do the updating in a callback).
    // Update the modal's content. We'll use jQuery here, but you could use a data binding library or other methods instead.
    var modal = $(this)
    modal.find('.modal-brandcollid input').val(collectionid)
    modal.find('.modal-title').text('BrandCollection: ' + brandcollname)
    //modal.find('.modal-body input').val(recipient)
})

// Write your JavaScript code.
$('#productModal').on('show.bs.modal', function (event) {
    let modal = $('#productModal');
    var button = $(event.relatedTarget) // Button that triggered the modal 

    modal.find('#lab2').hide();
    modal.find('#seltest2').hide();

    modal.find('#seltest3').hide();   
    modal.find('#lab3').hide();

    modal.find('#lab4').hide();
    modal.find('#seltest4').hide(); 
})
function BrandCollectionFilter() {
    

    let ArrayCollBrands = new Array();
    for (i = 0; i < BrandCollNames.length; i++) {

        ArrayCollBrands.push({
            Id: BrandCollId[i],
            Name: BrandCollNames[i],
            BrandId: BrandId[i]
        })
    }
    let modal = $('#productModal');
    let value = modal.find('#seltest1 option:selected').val();

    let ArrayCollBrandsFilter = ArrayCollBrands.filter(function (colbrand) {
        return colbrand.BrandId == value;
    })
    modal.find('#seltest2 option:contains()').remove();
    if (ArrayCollBrandsFilter.length > 0) {
        modal.find('#seltest2').show();
        modal.find('#lab2').show();
    }
    else {
        modal.find('#seltest2').hide();
        modal.find('#lab2').hide();
    }

    for (i = 0; i < ArrayCollBrandsFilter.length; i++) {
        modal.find('#seltest2').prepend('<option value="' + ArrayCollBrandsFilter[i].Id + '">' + ArrayCollBrandsFilter[i].Name + '</option>');
    };
    modal.find('#seltest2').prepend('<option value="" disabled> select collection </option>');

    modal.find('#seltest3 option:contains()').remove();
    modal.find('#seltest4 option:contains()').remove();

    modal.find('#lab3').hide();
    modal.find('#seltest3').hide();

    modal.find('#lab4').hide();
    modal.find('#seltest4').hide();
    
    resetselect2();

    productHeader();
}

function FurnitureNameFilter() {
    let ArrayFurnitureNames = new Array();
    for (i = 0; i < FurnitureNames.length; i++) {

        ArrayFurnitureNames.push({
            Id: FurnitureNamesId[i],
            Name: FurnitureNames[i],
            BrandColldId: FurnitureNameBrandColldId[i]
        })
    }
    let modal = $('#productModal');
    let value = modal.find('#seltest2 option:selected').val();

    var ArrayFurnitureNamesFilter = ArrayFurnitureNames.filter(function (furname) {
        return furname.BrandColldId == value;
    })

    modal.find('#seltest3 option:contains()').remove();
    if (ArrayFurnitureNamesFilter.length > 0) {
        modal.find('#lab3').show();
        modal.find('#seltest3').show();
    }
    else {
        modal.find('#lab3').hide();
        modal.find('#seltest3').hide();
    }

    for (i = 0; i < ArrayFurnitureNamesFilter.length; i++) {
        modal.find('#seltest3').prepend('<option value="' + ArrayFurnitureNamesFilter[i].Id + '">' + ArrayFurnitureNamesFilter[i].Name + '</option>');
    };
    modal.find('#seltest3').prepend('<option value="" disabled> select furniture </option>');
    resetselect3(); 
     
    productHeader();
}

function FinishingFilter() {
    let ArrayFinishing = new Array();
    for (i = 0; i < FinishingNames.length; i++) {

        ArrayFinishing.push({
            Id: FinishingId[i],
            Name: FinishingNames[i],
            BrandColldId: FinishingBrandColldId[i]
        })
    }
    let modal = $('#productModal');
    let value = modal.find('#seltest2 option:selected').val();

    var ArrayFinishingFilter = ArrayFinishing.filter(function (finish) {
        return finish.BrandColldId == value;
    })

    modal.find('#seltest4 option:contains()').remove();
    if (ArrayFinishingFilter.length > 0) {
        modal.find('#lab4').show();
        modal.find('#seltest4').show();
    }
    else {
        modal.find('#lab4').hide();
        modal.find('#seltest4').hide();
    }

    for ( i = 0; i < ArrayFinishingFilter.length; i++) {
        modal.find('#seltest4').prepend('<option value="' + ArrayFinishingFilter[i].Id + '">' + ArrayFinishingFilter[i].Name + '</option>');
    };
    modal.find('#seltest4').prepend('<option value="" disabled> select finish </option>');
    resetselect4();
    productHeader();
}





function productHeader() {
    let modal = $('#productModal');
    let namebrand = modal.find('#seltest1 option:selected').text();
    let namecollbrand = modal.find('#seltest2 option:selected').text();
    let furniturename = modal.find('#seltest3 option:selected').text();
    let finishing = modal.find('#seltest4 option:selected').text();
    let type = modal.find('#seltest5 option:selected').text();
    modal.find('.modal-product').text(namebrand + '.'
        + namecollbrand + '.'
        + furniturename + '.'
        + finishing + '.'
        + type);
}

function resetselect1() {
    var modal = $('#productModal');
    modal.find('#seltest1 option:first').prop('selected', true);
}
function resetselect2() {
    var modal = $('#productModal');
    modal.find('#seltest2 option:first').prop('selected', true);
}
function resetselect3() {
    var modal = $('#productModal');
    modal.find('#seltest3 option:first').prop('selected', true);
}
function resetselect4() {
    var modal = $('#productModal');
    modal.find('#seltest4 option:first').prop('selected', true);
}
function resetselect5() {
    var modal = $('#productModal');
    modal.find('#seltest5 option:first').prop('selected', true);
}


