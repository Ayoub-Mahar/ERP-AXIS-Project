var sOut = '<table cellpadding="5" cellspacing="0" border="0" style="padding-left:50px;">';
function fnFormatDetails(oTable, nTr)
{
    debugger;
    var aData = oTable.fnGetData(nTr);
    var ID = aData[1].match(/Id=([0-9]+)/)[1];
 
    FillDetail(ID, oTable, nTr);
    return sOut;
    
}

function FillDetail(ID, oTable, nTr)
{

     var pageUrl = document.URL;
     var sOut = '<table cellpadding="5" cellspacing="0" border="0" style="padding-left:50px;" class="table table-bordered table-striped dynamic-table cf">';
    debugger;
    jQuery.ajax({
        type: "POST",
        url: pageUrl + "/SetDetails",
        data: "{ID:" + JSON.stringify(ID) + "}",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (msg) {
            debugger;
            //Replace the div's content with the page method's return.
            var colCount = msg.d[0];

            //Header
            sOut += '<tr>';
            for (var i = 1; i <= colCount; i++) {
                sOut += '<th>'+msg.d[i]+'</th>';
            }
            sOut += '</tr>';

            //tbody
            for (var i = parseInt(colCount) + 1; i < msg.d.length; ) {
                
                sOut += '<tr>';
                for (var j = 0; j < colCount; j++)
                {
                    
                    var Record = msg.d[i];                   
                    sOut += '<td>' + Record + '</td>';
                    i++;
                }
                sOut += '</tr>';
                //i = i + colCount - 1;
            }
            sOut += '</table>';

            
            fillTable(oTable, nTr, sOut)

        },
        failure: function (msg) {
            debugger;
        }
    });
}

function fillTable(oTable, nTr, Data)
{
    oTable.fnOpen(nTr, Data, 'details');
}

$(document).ready(function() {

    $('.dynamic-table').dataTable( {
        "aaSorting": [[0, "desc"]],
        "dom": 'T<"clear">lfrtip',
        "tableTools": {
            "sSwfPath": "/js/advanced-datatable/swf/copy_csv_xls_pdf.swf"
        }
    } );

    /*
     * Insert a 'details' column to the table
     */
    var nCloneTh = document.createElement( 'th' );
    var nCloneTd = document.createElement( 'td' );
    nCloneTd.innerHTML = '<img src="images/details_open.png">';
    nCloneTd.className = "center";

    $('.hidden-table-info thead tr').each( function () {
        this.insertBefore( nCloneTh, this.childNodes[0] );
    } );

    $('.hidden-table-info tbody tr').each( function () {
        this.insertBefore(  nCloneTd.cloneNode( true ), this.childNodes[0] );
    } );

    /*
     * Initialse DataTables, with no sorting on the 'details' column
     */
    var oTable = $('.hidden-table-info').dataTable( {
        "aoColumnDefs": [
            { "bSortable": false, "aTargets": [ 0 ] }
        ],
        "aaSorting": [[7, 'desc']]
    });

    /* Add event listener for opening and closing details
     * Note that the indicator for showing which row is open is not controlled by DataTables,
     * rather it is done here
     */
    $(document).on('click', '.hidden-table-info tbody td img', function () {
        var nTr = $(this).parents('tr')[0];
        if (oTable.fnIsOpen(nTr)) {
            /* This row is already open - close it */
            this.src = "images/details_open.png";
            oTable.fnClose(nTr);
        }
        else {
            /* Open this row */
            this.src = "images/details_close.png";
            
            oTable.fnOpen(nTr, fnFormatDetails(oTable, nTr), 'details');
        }
    });
} );