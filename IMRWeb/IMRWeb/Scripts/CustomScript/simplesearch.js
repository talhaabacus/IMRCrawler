﻿Date.prototype.toMMDDYYYY = function () {
    return this.getMonth()+1 + "/" + this.getDate() + "/" + this.getFullYear()
};

function viewPDF(pdfName)
{
    var url = "claims/" + pdfName;
    window.open(url, '_blank');
    return false;
}
function clearSearch() {
    document.getElementById('txtSearch').value = "";
    return false;
}
var _searchtext = "";
var _pagesize = 50;
var _totalResults = 0;
var _currentPage = 0;
var _totalPages = 0;
function showLoader() {

    $('#loader-dialog').modal({ backdrop: 'static', keyboard: false })

}
function hideLoader() {
    $('#loader-dialog').modal('hide');
}
function search()
{  

    _searchtext = document.getElementById('txtSearch').value
    if(_searchtext == "")
    {
        $("#nosearchstring").removeClass('hidden');
        $("#noresults").addClass('hidden');
        return false;
    }
    else
    {
        showLoader();
        _currentPage = 1;
        $("#nosearchstring").addClass('hidden');
        getSearchResultCount();
        getSearchResults(1);
        return false;
    }
}

function getSearchResults(pageIndex) {
    $.ajax({
        type: "POST",
        url: "/Search/SimpleSearchQuery",
        data: "{\"any\": 0, \"searchText\": \"" + _searchtext + "\", \"current\":" + pageIndex + ",\"pagesize\":" + _pagesize + "}",
       contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: onSuccess,
        failure: function (response) {
            alert("failed");
            alert(response);
        },
        error: function (response) {
            alert("error");
            alert(response);
        }
    });
}

function getSearchResultCount() {
    $.ajax({
        type: "POST",
        url: "/Search/SimpleSearchCount",
        data: "{\"any\": 0, \"searchText\": \"" + _searchtext + "\"}",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: onCountSuccess,
        failure: function (response) {
            alert(response);
        },
        error:  function(jqxhr,textStatus,errorThrown)
        {
            console.log(jqxhr);
            console.log(textStatus);
            console.log(errorThrown);                               

         
            //<--- All those logs/alerts, don't say anything helpful, how can I understand what error is going on? ---->

        }
    });
}

function onCountSuccess(data, status, jqXHR) {
    _totalResults = data.count;
    _totalPages = Math.ceil(_totalResults / _pagesize);
  

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
           getSearchResults(data.currentPage);
       }
    });
  };
function onSuccess(data, status, jqXHR) {
   
    if (data == "[{}]") {
        $("#noresults").removeClass('hidden');
        $("#tablediv").html("");
    }
    else
    {
        $("#noresults").addClass('hidden');
        var x = JSON.parse(data);
        var results = [];
        results.push(" <table class=\"table table-striped table-hover table-condensed\">");
        results.push("<thead><tr><th>Case Number</th><th>Outcome</th><th>Dec. Date</th><th>Injury Dt</th><th>Rcvd Date</th><th>IMRO Specialty</th><th>Req. Category</th><th>Sub Category</th><th>Decision</th><th></th><th></th></tr></thead>");
        results.push("<tbody>");
        for (i = 0; i < x.length; i++)
        {
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
                results.push("<td><button class=\"btn btn-primary\"  onclick=\"return viewDetails(" + x[i].TreatmentID + "," + x[i].PDFFormatID + ")\">Details</button</td>")
            else
                results.push("<td></td>");
            results.push("</tr>");
        }
        results.push("</tbody></table>");
        $("#tablediv").html(results.join(''));

     
    }

    hideLoader();

};
