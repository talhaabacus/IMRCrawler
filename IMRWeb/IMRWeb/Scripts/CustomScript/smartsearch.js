var options = ["Age","Gender","Diagnosis", "Case Number", "Case Outcome","Sub Category", "IMRO Specialty", "Request Decision",  "How IMR Determination works", "Case Summary", "IMR Issues and Rationales", "State Of Licensure", "Certifications", "Documents Reviewed", "Issue At Dispute", "Treatment Guidelines", "Reviewer Qualifications"];
var values = ["Age", "Gender", "Diagnosis", "CaseNumber", "CaseOutcome", "SubCategory", "IMROSpeciality", "RequestDecision", "HowIMRDetermination", "ClinicalCaseSummary",  "IMRIssuesRationales", "StateOfLicensure", "Certifications", "DocumentsReviewed", "IssueAtDispute", "TreatmentGuidelines", "ReviewerQualifications"];
var textfields = ["Diagnosis", "HowIMRDetermination", "ClinicalCaseSummary", "IMRIssuesRationales", "DocumentsReviewed", "IssueAtDispute", "TreatmentGuidelines", "ReviewerQualifications"];
var notTextOps = [0, 1, 2, 3, 4, 5, 6, 7, 8, 9];//["IN", "NOT IN", "=", "<>", ">", ">=", "!<", "<", "<=", "!<"];
var _searchcriteria = "";
var _pagesize = 50;
var _totalResults = 0;
var _currentPage = 0;
var _totalPages = 0;

$(document).ready(function () {
    addFirstRow();
});

Date.prototype.toMMDDYYYY = function () {
    return this.getMonth() + 1 + "/" + this.getDate() + "/" + this.getFullYear()
};

function getSearchColumnOptions() {
    var opts = [];
    for (var i = 0; i < options.length; i++) {
            opts.push('<option value="',
              values[i], '">',
               options[i], '</option>');   
    }
    return opts.join('');
}

function getSearchOperators() {
    var opts = [];
    opts.push('<option value="IN">IN</option>');
    opts.push('<option value="NOT IN">NOT IN</option>');
    opts.push('<option value="=">EQUALS</option>');
    opts.push('<option value="<>">NOT EQUALS</option>');
    opts.push('<option value=">">GREATER THAN</option>')
    opts.push('<option value=">=">GREATER THAN OR EQUAL TO</option>')
    opts.push('<option value="!>">NOT GREATER THAN</option>')
    opts.push('<option value="<">LESS THAN</option>')
    opts.push('<option value="<=">LESS THAN OR EQUAL TO</option>')
    opts.push('<option value="!<">NOT LESS THAN</option>')
    opts.push('<option value="LIKE">LIKE</option>');
    opts.push('<option value="NOT LIKE">NOT LIKE</option>');
    return opts.join('');
}

function checkCol(sel, rowid)
{
    var selCol = $(sel).val();
    var found = false;
    for (var i = 0; i < textfields.length; i++) {
        if (selCol == textfields[i])
        {
            found = true;
            hideOperators(rowid);
            break;
        }

    }
    if(found == false)
    {
        showOperators(rowid);
    }
}
function hideOperators(rowid)
{
    for (var i = 0; i < notTextOps.length; i++) {
        $('#op_' + rowid).val($('#op_' + rowid + ' option:eq(' + notTextOps[i] + ')').hide());
      
    }
}
function showOperators(rowid) {
    for (var i = 0; i < notTextOps.length; i++) {
        $('#op_' + rowid).val($('#op_' + rowid + ' option:eq(' + notTextOps[i] + ')').show());

    }
}

function getLogicOperator() {
    var opts = [];
    opts.push('<option value="AND">AND</option>');
    opts.push('<option value="OR">OR</option>');
    return opts.join('');
}

function addFirstRow()
{
    var row = [];
    var rowid = 1;
    row.push("<tr id='tr_" + rowid + "'>");
    row.push("<td><select id='col_" + rowid + "' onchange='checkCol(this," + rowid + ");' class='form-control'>" + getSearchColumnOptions() + "</select></td><td><select id='op_" + rowid + "' class='form-control'>" + getSearchOperators() + "</select></td><td><input type='text' id='txt_" + rowid + "' class='form-control'/></td><td><select id='logic_" + rowid + "' class='form-control'>" + getLogicOperator() + "</select></td><td><i class='glyphicon glyphicon-plus-sign' onclick='addrow();'></i></td>");
    row.push("</tr>");
    $("#hdTotalSearch").val(1);
    $("#tbSearchCriteria").html(row.join(''));


}

function removeRow(row) {
    var totalSearch = $("#hdTotalSearch").val();
    totalSearch -= 1;
    $("#hdTotalSearch").val(totalSearch);
    $(row).closest('tr').remove();

}

function addrow() {
    var totalSearch = parseInt($("#hdTotalSearch").val());
    var i = $('#tr_' + totalSearch);
    totalSearch += 1;
    $("#hdTotalSearch").val(totalSearch);
    $('<tr id="tr_' + totalSearch + '"><td><select class="form-control" onchange="checkCol(this,' + totalSearch + ');" id="col_' + totalSearch + '">' + getSearchColumnOptions() + '</select></td><td><select class="form-control" id="op_' + totalSearch + '">' + getSearchOperators() + '</select></td><td><input type="text" class="form-control" id="txt_' + totalSearch + '"/></td><td><select class="form-control" id="logic_' + totalSearch + '">' + getLogicOperator() + '</select></td><td> <i class="glyphicon glyphicon-trash" onclick="removeRow(this);"></td></tr>').insertAfter(i);

}

function validateSearchCriteria() {
    var z1 = /^[\w\-\s\,]+$/;
    var totalSearch = parseInt($("#hdTotalSearch").val());
    for (i = 1; i <= totalSearch; i++) {
        if(!z1.test($('#txt_' + i).val()))
        {
            $("#invalidsearchstring").removeClass('hidden');
            return false;
        }
        else
        {
            if($('#txt_' + i).val().indexOf(",") != -1)
            {
                var op = $('#op_' + i).val();
                if (!((op == 'IN') || (op == 'NOT IN'))) {
                    $("#invalidsearchstring").removeClass('hidden');
                    return false;
                }

            }
        }
    }
    return true;

}

function buildSearchCriteria()
{
    var totalSearch = parseInt($("#hdTotalSearch").val());
    var searchCriteria = "";
    var lastLogical = "";
    for(i =1; i<=totalSearch; i++)
    {
        if((searchCriteria.length > 0) && (lastLogical.length > 0))
        {
            searchCriteria = searchCriteria + " " + lastLogical;
        }
        var col = $('#col_' + i ).val();
        var op = $('#op_' + i ).val();
        var txtval = $('#txt_' + i).val();
        lastLogical = $('#logic_' + i ).val();
        txtval = txtval +","
        var values = "";
        var arr = txtval.split(",");
        for (j = 0; j < arr.length; j++) {
            if (arr[j].length > 0) {
                if (values.length > 0)
                    values = values + ",";
                if ((op == 'LIKE') || (op == 'NOT LIKE'))
                    values = values + "'%" + arr[j] + "%'";
                else
                    values = values + "'" + arr[j] + "'";
            }
        }
        searchCriteria = searchCriteria + " " + col + " " + op + " (" + values + ") ";
    }

    return searchCriteria;
}

function searchsmart() {

    if (validateSearchCriteria()) {
     
         _searchcriteria = buildSearchCriteria();
        if (_searchcriteria == "") {
            $("#invalidsearchstring").removeClass('hidden');
            $("#noresults").addClass('hidden');
            return false;
        }
        else {
            showLoader();
            _currentPage = 1;
            $("#invalidsearchstring").addClass('hidden');
                getSmartSearchResultCount();
            getSmartSearchResults(1);
            return false;
        }
    }
    else
    {
        return false;
    }
}

function getSmartSearchResults(pageIndex) {
   
    $.ajax({
        type: "POST",
        url: "SmartSearchQuery",
        data: "{\"criteria\": \"" + _searchcriteria + "\", \"current\":" + pageIndex + ",\"pagesize\":" + _pagesize + "}",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: onSmartSuccess,
        failure: function (response) {
            alert("error loading data");
            hideLoader();
        },
        error: function (response) {
            alert("error loading data");
            hideLoader();
        }
    });
}

function getSmartSearchResultCount() {
    $.ajax({
        type: "POST",
        url: "SmartSearchCount",
        data: "{ \"criteria\": \"" + _searchcriteria + "\"}",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: onSmartCountSuccess,
        failure: function (response) {
            alert("error loading data");
            hideLoader();
        },
        error: function (jqxhr, textStatus, errorThrown) {
            alert("error loading data");
            hideLoader();

        }
    });
}

function onSmartCountSuccess(data, status, jqXHR) {
    _totalResults = data.count;
    
    _totalPages = Math.ceil(_totalResults / _pagesize);

    if (_totalResults > 0) {
        $("#page-selection").show();
        $("#page-selection").bs_pagination({
            currentPage: _currentPage,
            rowsPerPage: _pagesize,
            maxRowsPerPage: _pagesize,
            totalPages: _totalPages,
            totalRows: _totalResults,
            showGoToPage: false,
            showRowsPerPage: false,
            onChangePage: function (event, data) {
                showLoader();
                getSmartSearchResults(data.currentPage);
            }
        });
    }
    else
    {
        $("#page-selection").hide();
    }

};
function onSmartSuccess(data, status, jqXHR) {

    if (data == "[{}]") {
        $("#noresults").removeClass('hidden');
        $("#tablediv").html("");
    }
    else {
        $("#noresults").addClass('hidden');
        var x = JSON.parse(data);
        var results = [];
        results.push(" <table class=\"table table-striped table-hover table-condensed\">");
        results.push("<thead><tr><th>Case Number</th><th>Outcome</th><th>Dec. Date</th><th>Injury Dt</th><th>Rcvd Date</th><th>IMRO Specialty</th><th>Req. Category</th><th>Sub Category</th><th>Decision</th><th></th><th></th></tr></thead>");
        results.push("<tbody>");
        for (i = 0; i < x.length; i++) {
            results.push("<tr>");
            results.push("<td>" + x[i].CaseNumber + "</td>");
            if (x[i].CaseOutCome != null)
                results.push("<td>" + x[i].CaseOutCome + "</td>");
            else
                results.push("<td></td>");

            results.push("<td>" + new Date(x[i].DecisionDate).toMMDDYYYY() + "</td>");
            results.push("<td>" + new Date(x[i].DateOfInjury).toMMDDYYYY() + "</td>");
            results.push("<td>" + new Date(x[i].RecievedDate).toMMDDYYYY() + "</td>");
            if (x[i].IMROSpeciality != null)
                results.push("<td>" + x[i].IMROSpeciality + "</td>");
            else
                results.push("<td></td>");
            if (x[i].RequestCategory != null)
                results.push("<td>" + x[i].RequestCategory + "</td>");
            else
                results.push("<td></td>");

            if (x[i].SubCategory != null)
                results.push("<td>" + x[i].SubCategory + "</td>");
            else
                results.push("<td></td>");

            if (x[i].RequestDecision != null)
                results.push("<td>" + x[i].RequestDecision + "</td>");
            else
                results.push("<td></td>");
            if (x[i].ParentCaseNumber == null)
                results.push("<td><button class=\"btn btn-primary\"  onclick=\"return viewPDF('" + x[i].CaseNumber + ".pdf')\">View PDF</button</td>")
            else
                results.push("<td></td>");
            if (x[i].ParentCaseNumber == null)
                results.push("<td><button class=\"btn btn-primary\"  onclick=\"return viewDetails(" + x[i].TreatmentID + "," + x[i].PDFFormatID + ",'" + x[i].CaseNumber + "')\">Details</button</td>")
            else
                results.push("<td></td>");
            results.push("</tr>");
        }
        results.push("</tbody></table>");
        $("#tablediv").html(results.join(''));


    }

    hideLoader();

};
