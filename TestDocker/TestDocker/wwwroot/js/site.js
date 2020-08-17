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
    var modal = $('#productModal');
    var button = $(event.relatedTarget) // Button that triggered the modal   
    modal.find('#seltest2').hide();
})
function BrandCollectionFilter() {
    var ArrayCollBrands = new Array();
    for (i = 0; i < BrandCollNames.length; i++) {

        ArrayCollBrands.push({
            Id: BrandCollId[i],
            Name: BrandCollNames[i],
            BrandId: BrandId[i]
        })
    }
    var modal = $('#productModal');
    var value = modal.find('#seltest1 option:selected').val();

    var ArrayCollBrandsFilter = ArrayCollBrands.filter(function (colbrand) {
        return colbrand.BrandId == value;
    })
    modal.find('#seltest2 option:contains()').remove();
    if (ArrayCollBrandsFilter.length > 0) {
        modal.find('#seltest2').show();
    }
    else {
        modal.find('#seltest2').hide();
    }


    for (var i = 0; i < ArrayCollBrandsFilter.length; i++) {
        modal.find('#seltest2').prepend('<option value="' + ArrayCollBrandsFilter[i].Id + '">' + ArrayCollBrandsFilter[i].Name + '</option>');
    };
    modal.find('#seltest3 option:contains()').remove();
    modal.find('#seltest3').hide();
    productHeader();
}

function FurnitureNameFilter() {
    var ArrayFurnitureNames = new Array();
    for (i = 0; i < FurnitureNames.length; i++) {

        ArrayFurnitureNames.push({
            Id: FurnitureNamesId[i],
            Name: FurnitureNames[i],
            BrandColldId: FurnitureNameBrandColldId[i]
        })
    }
    var modal = $('#productModal');
    var value = modal.find('#seltest2 option:selected').val();

    var ArrayFurnitureNamesFilter = ArrayFurnitureNames.filter(function (furname) {
        return furname.BrandColldId == value;
    })

    modal.find('#seltest3 option:contains()').remove();
    if (ArrayFurnitureNamesFilter.length > 0) {
        modal.find('#seltest3').show();
    }
    else {
        modal.find('#seltest3').hide();
    }

    for (var i = 0; i < ArrayFurnitureNamesFilter.length; i++) {
        modal.find('#seltest3').prepend('<option value="' + ArrayFurnitureNamesFilter[i].Id + '">' + ArrayFurnitureNamesFilter[i].Name + '</option>');
    };
    productHeader();
}

function productHeader() {
    var modal = $('#productModal');
    var namebrand = modal.find('#seltest1 option:selected').text();
    var namecollbrand = modal.find('#seltest2 option:selected').text();
    var furniturename = modal.find('#seltest3 option:selected').text();
    modal.find('.modal-product').text(namebrand + '.' + namecollbrand + '.' + furniturename);
}
