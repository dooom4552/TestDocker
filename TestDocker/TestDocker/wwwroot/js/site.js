// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
$('#exampleModal').on('show.bs.modal', function (event) {
    let button = $(event.relatedTarget) // Button that triggered the modal
    let recipient = button.data('whatever') // Extract info from data-* attributes
    let brandid = button.data('brandid')
    //    // If necessary, you could initiate an AJAX request here (and then do the updating in a callback).
    //    // Update the modal's content. We'll use jQuery here, but you could use a data binding library or other methods instead.
    let modal = $(this)
    modal.find('.modal-brandid input').val(brandid)
    modal.find('.modal-title').text('Brand: ' + recipient)
    //modal.find('.modal-body input').val(recipient)
})
// Write your JavaScript code.
$('#BrandCollectionModal').on('show.bs.modal', function (event) {
    let button = $(event.relatedTarget) // Button that triggered the modal
    let brandcollname = button.data('brandcollname') // Extract info from data-* attributes
    let collectionid = button.data('collectionid')
    // If necessary, you could initiate an AJAX request here (and then do the updating in a callback).
    // Update the modal's content. We'll use jQuery here, but you could use a data binding library or other methods instead.
    var modal = $(this)
    modal.find('.modal-brandcollid input').val(collectionid)
    modal.find('.modal-title').text('BrandCollection: ' + brandcollname)
    //modal.find('.modal-body input').val(recipient)
})
// Write your JavaScript code.
$('#BrandCollectionFinishing').on('show.bs.modal', function (event) {
    let button = $(event.relatedTarget) // Button that triggered the modal
    let brandcollname = button.data('brandcollname') // Extract info from data-* attributes
    let collectionid = button.data('collectionid')
    // If necessary, you could initiate an AJAX request here (and then do the updating in a callback).
    // Update the modal's content. We'll use jQuery here, but you could use a data binding library or other methods instead.
    let modal = $(this)
    modal.find('.modal-brandcollid input').val(collectionid)
    modal.find('.modal-title').text('BrandCollection: ' + brandcollname)
    //modal.find('.modal-body input').val(recipient)
})

// Write your JavaScript code.
$('#productModal').on('show.bs.modal', function (event) {
    let modal = $('#productModal');
    let button = $(event.relatedTarget) // Button that triggered the modal 

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

    let ArrayFurnitureNamesFilter = ArrayFurnitureNames.filter(function (furname) {
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
    let modal = $('#productModal');
    modal.find('#seltest1 option:first').prop('selected', true);
}
function resetselect2() {
    let modal = $('#productModal');
    modal.find('#seltest2 option:first').prop('selected', true);
}
function resetselect3() {
    let modal = $('#productModal');
    modal.find('#seltest3 option:first').prop('selected', true);
}
function resetselect4() {
    let modal = $('#productModal');
    modal.find('#seltest4 option:first').prop('selected', true);
}
function resetselect5() {
    let modal = $('#productModal');
    modal.find('#seltest5 option:first').prop('selected', true);
}

$('#addprod2Modal').on('show.bs.modal', function (event) {
    let button = $(event.relatedTarget) // Button that triggered the modal
    
    // If necessary, you could initiate an AJAX request here (and then do the updating in a callback).
    // Update the modal's content. We'll use jQuery here, but you could use a data binding library or other methods instead.
    let modal = $(this)
    
    let brandid = button.data('brandid')
    let brandcollectionid = button.data('brandcollectionid')
    let furniturenameid = button.data('furniturenameid')
    let finishingid = button.data('finishingid')
    let furnituretypeid = button.data('furnituretypeid')

    let brand = button.data('brand')
    let brandcollection = button.data('brandcollection')
    let furniturename = button.data('furniturename')
    let finishing = button.data('finishing')
    let furnituretype = button.data('furnituretype')

    let lastprice = button.data('lastprice')
  
    modal.find('.modal-BrandId input').val(brandid)
    modal.find('.modal-BrandCollectionId input').val(brandcollectionid)
    modal.find('.modal-FurnitureNameId input').val(furniturenameid)
    modal.find('.modal-FinishingId input').val(finishingid)
    modal.find('.modal-FurnitureTypeId input').val(furnituretypeid)

    modal.find('.modal-Brand input').val(brand)
    modal.find('.modal-BrandCollection input').val(brandcollection)
    modal.find('.modal-FurnitureName input').val(furniturename)
    modal.find('.modal-Finishing input').val(finishing)
    modal.find('.modal-FurnitureType input').val(furnituretype)

    modal.find('.modal-LastPrice input').val(lastprice)
})

$('#soldprod2Modal').on('show.bs.modal', function (event) {
    let button = $(event.relatedTarget) // Button that triggered the modal

    // If necessary, you could initiate an AJAX request here (and then do the updating in a callback).
    // Update the modal's content. We'll use jQuery here, but you could use a data binding library or other methods instead.
    let modal = $(this)

    let brandid = button.data('brandid')
    let brandcollectionid = button.data('brandcollectionid')
    let furniturenameid = button.data('furniturenameid')
    let finishingid = button.data('finishingid')
    let furnituretypeid = button.data('furnituretypeid')

    let brand = button.data('brand')
    let brandcollection = button.data('brandcollection')
    let furniturename = button.data('furniturename')
    let finishing = button.data('finishing')
    let furnituretype = button.data('furnituretype')

    let quantity = button.data('quantity')

    modal.find('.modal-BrandId input').val(brandid)
    modal.find('.modal-BrandCollectionId input').val(brandcollectionid)
    modal.find('.modal-FurnitureNameId input').val(furniturenameid)
    modal.find('.modal-FinishingId input').val(finishingid)
    modal.find('.modal-FurnitureTypeId input').val(furnituretypeid)

    modal.find('.modal-Brand input').val(brand)
    modal.find('.modal-BrandCollection input').val(brandcollection)
    modal.find('.modal-FurnitureName input').val(furniturename)
    modal.find('.modal-Finishing input').val(finishing)
    modal.find('.modal-FurnitureType input').val(furnituretype)

    modal.find('.modal-Quantity label').text('No more  ' + quantity)

    modal.find('.modal-Quantity input').attr({
        "max": quantity
    });

})

function sumpriceFormatter(data){
    let field = this.field
    return data.map(function(row){
        return + row[field].substring(0)
    }).reduce((total, amount) => total+ amount);
}

$('#acceptprodModal').on('show.bs.modal', function (event) {
    let button = $(event.relatedTarget) // Button that triggered the modal

    // If necessary, you could initiate an AJAX request here (and then do the updating in a callback).
    // Update the modal's content. We'll use jQuery here, but you could use a data binding library or other methods instead.
    let modal = $(this)

    let id = button.data('productoutvmid')   
    let brand = button.data('brand')
    let brandcollection = button.data('brandcollection')
    let furniturename = button.data('furniturename')
    let finishing = button.data('finishing')
    let furnituretype = button.data('furnituretype')
  
    let buyer = button.data('buyer')

    let quantity = button.data('quantity')

    
    modal.find('.modal-Brand input').val(brand)
    modal.find('.modal-BrandCollection input').val(brandcollection)
    modal.find('.modal-FurnitureName input').val(furniturename)
    modal.find('.modal-Finishing input').val(finishing)
    modal.find('.modal-FurnitureType input').val(furnituretype)
    modal.find('.modal-Buyer input').val(buyer)
    modal.find('.modal-Quantity input').val(quantity)
    
    modal.find('.modal-Id input').val(id)   

})