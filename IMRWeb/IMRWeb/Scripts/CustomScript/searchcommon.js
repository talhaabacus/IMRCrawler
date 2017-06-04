

function viewPDF(pdfName) {
    var url = "claims/" + pdfName;
    window.open(url, '_blank');
    return false;
}
function showLoader() {

    $('#loader-dialog').modal({ backdrop: 'static', keyboard: false })

}
function hideLoader() {
    $('#loader-dialog').modal('hide');
}