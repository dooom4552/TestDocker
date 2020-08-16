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
    modal.find('.modal-title').text('Brand: ' + recipient + brandid)
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
var brands = 
// Write your JavaScript code.
$('#productModal').on('show.bs.modal', function (event) {
    var button = $(event.relatedTarget) // Button that triggered the modal
    //var brands = button.data('brands') // Extract info from data-* attributes
    var test = button.data('test') // Extract info from data-* attributes
    //var furnitureNames = button.data('furnitureNames') // Extract info from data-* attributes
    //var furnitureTypes = button.data('furnitureTypes') // Extract info from data-* attributes
    //var finishings = button.data('finishings') // Extract info from data-* attributes
    //var collectionid = button.data('collectionid')
    // If necessary, you could initiate an AJAX request here (and then do the updating in a callback).
    // Update the modal's content. We'll use jQuery here, but you could use a data binding library or other methods instead.
    var modal = $(this)
    modal.find('.modal-body select').val(test)
    //modal.find('.modal-title').text('BrandCollection: ' + brandcollname)
    //modal.find('.modal-body input').val(recipient)
})