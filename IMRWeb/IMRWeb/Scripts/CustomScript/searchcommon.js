function showDialog(id, id1, head, id2, body, id3, footer) {

    $(id1).html(head);
    $(id2).html(body);
    $(id3).html(footer);
    $(id).modal({ backdrop: 'static', keyboard: false })
}

function hideDialog(id) {
     $(id).modal('toggle');
}


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


function viewDetails(treatmentID, formatID, caseNumber) {
    showLoader();
    $.ajax({
        type: "POST",
        url: "Search/GetPDFDetails",
        data: "{\"caseNumber\": \"" + caseNumber + "\",\"treatmentID\":" + treatmentID + ",\"formatID\":" + formatID + "}",
        contentType: "application/json;",
        dataType: 'json',
        success: onDetailSuccess,
        failure: function (response) {
            alert("error loading data");
            hideLoader();
        },
        error: function (jqxhr, textStatus, errorThrown) {
            alert("error loading data");
            hideLoader();
        }
    });
    return false;
}

function onDetailSuccess(data, status, jqXHR) {
    hideLoader();
    var formatID = data.formatID;
    var message = [];

    message.push('View Detail [ ' + data.caseNumber + ' ]');
    var boxdiv = '<div class="box"><div class="box-body pre-scrollable">';
    if (formatID == 1) {
        boxdiv = boxdiv + '<div class="form-group"><label for="txtCaseNumber" class="control-label">Case Number</label><input type="text" class="form-control" id="txtCompanyName"  readonly value="' + data.caseNumber + '"></div>';
        boxdiv = boxdiv + '<div class="form-group"><label for="txtAge" class="control-label">Age</label><input type="text" class="form-control" id="txtAge"  readonly value="' + data.pdfDetail.Age + '"></div>';
        boxdiv = boxdiv + '<div class="form-group"><label for="txtGender" class="control-label">Gender</label><input type="text" class="form-control" id="txtGender"  readonly value="' + data.pdfDetail.Gender + '"></div>';
        boxdiv = boxdiv + '<div class="form-group"><label for="txURDenial" class="control-label">UR Denial Date</label><input type="text" class="form-control" id="txURDenial"  readonly value="' + new Date(data.pdfDetail.URDenialDate).toMMDDYYYY() + '"></div>';
        boxdiv = boxdiv + '<div class="form-group"><label for="txtDateAssigned" class="control-label">Date Assigned</label><input type="text" class="form-control" id="txtDateAssigned"  readonly value="' + new Date(data.pdfDetail.DateAssigned).toMMDDYYYY() + '"></div>';
        boxdiv = boxdiv + '<div class="form-group"><label for="txtState" class="control-label">State Of Licensure</label><input type="text" class="form-control" id="txtState"  readonly value="' + data.pdfDetail.StateofLicensure + '"></div>';
        boxdiv = boxdiv + '<div class="form-group"><label for="txtCert" class="control-label">Certifications</label><input type="text" class="form-control" id="txtCert"  readonly value="' + data.pdfDetail.Certifications + '"></div>';
        boxdiv = boxdiv + '<div class="form-group"><label class="control-label">How the IMR Final Determination was made</label><textarea class="form-control" readonly >' + data.pdfDetail.HowIMRDetermination + '</textarea></div>';
        boxdiv = boxdiv + '<div class="form-group"><label class="control-label">Clinical Case Summary</label><textarea class="form-control"  readonly >' + data.pdfDetail.ClinicalCaseSummary + '</textarea></div>';
        boxdiv = boxdiv + '<div class="form-group"><label class="control-label">Diagnosis</label><textarea class="form-control"readonly >' + data.pdfDetail.Diagnosis + '</textarea></div>';
        boxdiv = boxdiv + '<div class="form-group"><label class="control-label">IMR Issues, Decisions and Rationales</label><textarea class="form-control" readonly >' + data.pdfDetail.IMRIssuesRationales + '</textarea></div>';



    }
    else if (formatID == 2) {
        boxdiv = boxdiv + '<div class="form-group"><label for="txtCaseNumber" class="control-label">Case Number</label><input type="text" class="form-control" id="txtCompanyName"  readonly value="' + data.caseNumber + '"></div>';
        boxdiv = boxdiv + '<div class="form-group"><label for="txURDenial" class="control-label">UR Denial Date</label><input type="text" class="form-control" id="txURDenial"  readonly value="' + new Date(data.pdfDetail.URDenialDate).toMMDDYYYY() + '"></div>';
        boxdiv = boxdiv + '<div class="form-group"><label class="control-label">How the IMR Final Determination was made</label><textarea class="form-control" readonly >' + data.pdfDetail.HowIMRDetermination + '</textarea></div>';
        boxdiv = boxdiv + '<div class="form-group"><label class="control-label">Clinical Case Summary</label><textarea class="form-control"  readonly >' + data.pdfDetail.ClinicalCaseSummary + '</textarea></div>';
        boxdiv = boxdiv + '<div class="form-group"><label class="control-label">Documents Reviewed</label><textarea class="form-control"readonly >' + data.pdfDetail.DocumentsReviewed + '</textarea></div>';
        boxdiv = boxdiv + '<div class="form-group"><label class="control-label">IMR Issues, Decisions and Rationales</label><textarea class="form-control" readonly >' + data.pdfDetail.IMRIssuesRationales + '</textarea></div>';

    }
    else if (formatID == 3) {
        boxdiv = boxdiv + '<div class="form-group"><label for="txtCaseNumber" class="control-label">Case Number</label><input type="text" class="form-control" id="txtCompanyName"  readonly value="' + data.caseNumber + '"></div>';
        boxdiv = boxdiv + '<div class="form-group"><label for="txtAge" class="control-label">Age</label><input type="text" class="form-control" id="txtAge"  readonly value="' + data.pdfDetail.Age + '"></div>';
        boxdiv = boxdiv + '<div class="form-group"><label for="txtGender" class="control-label">Gender</label><input type="text" class="form-control" id="txtGender"  readonly value="' + data.pdfDetail.Gender + '"></div>';
        boxdiv = boxdiv + '<div class="form-group"><label class="control-label">Issue At Dispute</label><textarea class="form-control" readonly >' + data.pdfDetail.IssueAtDispute + '</textarea></div>';
        boxdiv = boxdiv + '<div class="form-group"><label class="control-label">Case Summary</label><textarea class="form-control"  readonly >' + data.pdfDetail.ClinicalCaseSummary + '</textarea></div>';
        boxdiv = boxdiv + '<div class="form-group"><label class="control-label">Diagnosis</label><textarea class="form-control"readonly >' + data.pdfDetail.Diagnosis + '</textarea></div>';
        boxdiv = boxdiv + '<div class="form-group"><label class="control-label">Documents Reviewed</label><textarea class="form-control"readonly >' + data.pdfDetail.DocumentsReviewed + '</textarea></div>';
        boxdiv = boxdiv + '<div class="form-group"><label class="control-label">Medical Treatment Guideline(s)  Relied Upon By Professional Reviewer and Why</label><textarea class="form-control"readonly >' + data.pdfDetail.TreatmentGuidelines + '</textarea></div>';
        boxdiv = boxdiv + '<div class="form-group"><label class="control-label">Rationale For Why the Requested Treatment/Service Is/Was Not Medically Necessary</label><textarea class="form-control" readonly >' + data.pdfDetail.IMRIssuesRationales + '</textarea></div>';
        boxdiv = boxdiv + '<div class="form-group"><label class="control-label">Medical Reviewer Qualifications</label><textarea class="form-control"readonly >' + data.pdfDetail.ReviewerQualifications + '</textarea></div>';


    }
    else {
        boxdiv = boxdiv + '<h2>Data Not Parsed</h2>';
    }
    boxdiv = boxdiv + '</div></div>';
    message.push(boxdiv);
    message.push('<button class="btn btn-primary" type="button" id="btnOK" onclick="hideDialog(\'#view-dialog\')">OK</button>');
    showDialog("#view-dialog", "#head", message[0], "#body", message[1], "#footer", message[2]);

};
