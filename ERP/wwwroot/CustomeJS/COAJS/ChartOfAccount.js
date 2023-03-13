function pageUrl(methodname) {
    var uri = document.URL;
    uri += "/" + methodname;
    return uri;
}

var COAModule = angular.module('COAModule', []);

COAModule.controller('COAController', function ($scope, $http) {
    debugger;
    var uri = document.URL;
    uri += "/GetParentAccount";
    //document.getElementById("pnlLoader").style.display = 'inline';
    $http({
        method: 'POST',
        url: pageUrl('GetParentAccount'),
        data:"{}",
        contentType: "application/json; charset=utf-8",
        dataType: "json"
    }).then(function successCallback(response) {
        debugger;
        var dataa = JSON.parse(response.data.d);
        $scope.ParentAccountsCol = dataa;

        //document.getElementById("pnlLoader").style.display = 'none';
    }, function errorCallback(response) {
        alert("Service could not working correctly");
    });

    $scope.GetChildAccount = function (AccountID) {
        debugger;
        $http({
            method: 'POST',
            url: pageUrl('GetChildAccount'),
            data: "{AccountID:" + AccountID + "}",
            contentType: "application/json; charset=utf-8",
            dataType: "json"
        }).then(function successCallback(response) {
            debugger;
            var dataa = JSON.parse(response.data.d);
            
            $("#child_" + AccountID).remove();

            var string = "<ol class='dd-list' id='child_" + AccountID + "'>";

            for (var i = 0; i < dataa.length; i++) {
                var li_id = "list_" + dataa[i].AccountID;
                string += "<strong style='display:none' class='name'>" + dataa[i].AccountName + "</strong><li class='dd-item dd3-item' id='" + li_id + "'><div class='dd-dle dd3-handle'></div><div class='dd3-content'><a href='javascript:void(0)' onclick='Getchildaccout2(" + dataa[i].AccountID + "); return false'>" + dataa[i].AccountName + "</a><a href='javascript:void(0)' onclick='GetAccountDetails(" + dataa[i].AccountID + ")' title='View Details'><span class='fa fa-edit' style='float:right'></span></a></div></li>";
            }
            
            string += "</ol>";
            $("#list_" + AccountID).append(string);
            
            RecreateScript();

        }, function errorCallback(response) {
            alert("Service could not working correctly");
        });
    }
    $scope.GetAccountDetails1 = function (AccountID) {
        debugger;
        document.getElementById("divDetails").style.display = 'inline';
        document.getElementById("divloader").style.display = 'inline';
        document.getElementById("MainContentPlaceHolder_pnlAccountConfiguration").style.display = 'none';
        document.getElementById("MainContentPlaceHolder_pnlAccountDetails").style.display = 'none';

        $.ajax({
            type: "POST",
            url: pageUrl("GetAccountDetails"),
            data: "{AccountID:" + AccountID + "}",
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: function (msg) {
                debugger;
                var dataa = JSON.parse(msg.d);

                document.getElementById("MainContentPlaceHolder_hdnAccountID").value = dataa[0].AccountID;
                document.getElementById("MainContentPlaceHolder_lblAccountName").innerHTML = dataa[0].AccountName;
                document.getElementById("MainContentPlaceHolder_lblCurrentBalance").innerHTML = dataa[0].OpeningBalance;

                document.getElementById("MainContentPlaceHolder_pnlAccountConfiguration").style.display = 'inline';
                document.getElementById("MainContentPlaceHolder_pnlAccountDetails").style.display = 'none';
                document.getElementById("divloader").style.display = 'none';
            },
            error: function (msg) {
                debugger;
                alert("ERROR:" + msg.responseText);
            }
        });
    }

    $scope.filtertext = '';
    $scope.textChanged = function () {
        debugger;
        var text = $scope.filtertext;
        if (text.length > 0) {
            $http({
                method: 'POST',
                url: pageUrl('GetFilteredAccount'),
                data: "{FilterText:" + JSON.stringify(text) + "}",
                contentType: "application/json; charset=utf-8",
                dataType: "json"
            }).then(function successCallback(response) {
                debugger;
                var dataa = JSON.parse(response.data.d);
                $scope.ParentAccountsCol = dataa;
            }, function errorCallback(response) {
                alert("Service could not working correctly");
            });
        }
        else {
            $http({
                method: 'POST',
                url: pageUrl('GetParentAccount'),
                data: "{}",
                contentType: "application/json; charset=utf-8",
                dataType: "json"
            }).then(function successCallback(response) {
                debugger;
                var dataa = JSON.parse(response.data.d);
                $scope.ParentAccountsCol = dataa;

                //document.getElementById("pnlLoader").style.display = 'none';
            }, function errorCallback(response) {
                alert("Service could not working correctly");
            });
        }
    }
});

function Getchildaccout2(AccountID)
{
    $.ajax({
        type: "POST",
        url: pageUrl("GetChildAccount"),
        data: "{AccountID:" + AccountID + "}",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (msg) {
            debugger;
            var dataa = JSON.parse(msg.d);
            
            $("#child_" + AccountID).remove();
            
            var string = "<ol class='dd-list' id='child_" + AccountID + "'>";

            for (var i = 0; i < dataa.length; i++) {
                var li_id = "list_" + dataa[i].AccountID;
                string += "<strong style='display:none' class='name'>" + dataa[i].AccountName + "</strong><li class='dd-item dd3-item' id='" + li_id + "'><div class='dd-dle dd3-handle'></div><div class='dd3-content'><a href='javascript:void(0)' onclick='Getchildaccout2(" + dataa[i].AccountID + "); return false'>" + dataa[i].AccountName + "</a><a href='javascript:void(0)' onclick='GetAccountDetails(" + dataa[i].AccountID + ")' title='View Details'><span class='fa fa-edit' style='float:right'></span></a></div></li>";
            }
            
            string += "</ol>";
            $("#list_" + AccountID).append(string);
            
            RecreateScript();
        },
        error: function (msg) {
            debugger;
            alert("ERROR:" + msg.responseText);
        }
    });
}

function RecreateScript()
{
    debugger;
    var scripts = ["js/jquery.js", "js/nestable/jquery.nestable.js","js/nestable.js"];

    //remove scripts into parentpage
    var olelement = $("ol").find(":button").remove();

    //$("ol:button").remove();

    //Adding scripts into parent page
    for (var i = 0; i < scripts.length; i++) {
        var head = document.getElementsByTagName("head")[0];
        var js = document.createElement("script");
        js.type = "text/javascript";
        js.setAttribute("id", "testclass");
        js.src = scripts[i];
        
        head.appendChild(js);
    }
}

function GetAccountDetails(AccountID) {
    debugger;
    document.getElementById("divDetails").style.display = 'inline';
    document.getElementById("divloader").style.display = 'inline';
    document.getElementById("MainContentPlaceHolder_pnlAccountConfiguration").style.display = 'none';
    document.getElementById("MainContentPlaceHolder_pnlAccountDetails").style.display = 'none';

    $.ajax({
        type: "POST",
        url: pageUrl("GetAccountDetails"),
        data: "{AccountID:" + AccountID + "}",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (msg) {
            debugger;
            var dataa = JSON.parse(msg.d);

            document.getElementById("MainContentPlaceHolder_hdnAccountID").value = dataa[0].AccountID;
            document.getElementById("MainContentPlaceHolder_lblAccountName").innerHTML = dataa[0].AccountName;
            document.getElementById("MainContentPlaceHolder_lblCurrentBalance").innerHTML = dataa[0].OpeningBalance;

            document.getElementById("MainContentPlaceHolder_pnlAccountConfiguration").style.display = 'inline';
            document.getElementById("MainContentPlaceHolder_pnlAccountDetails").style.display = 'none';
            document.getElementById("divloader").style.display = 'none';
        },
        error: function (msg) {
            debugger;
            alert("ERROR:" + msg.responseText);
        }
    });
}

function AddNewAccount(IsNewRecord,IsCancel)
{    
    debugger;
    if (!IsCancel) {
        document.getElementById("MainContentPlaceHolder_pnlAccountConfiguration").style.display = 'none';
        document.getElementById("MainContentPlaceHolder_pnlAccountDetails").style.display = 'inline';
        document.getElementById("MainContentPlaceHolder_hdnACID").value = 0;
        if (!IsNewRecord) {
            var data = document.getElementById("MainContentPlaceHolder_lblAccountName").innerHTML.split('-');
            document.getElementById("MainContentPlaceHolder_hdnACID").value = document.getElementById("MainContentPlaceHolder_hdnAccountID").value;
            document.getElementById("MainContentPlaceHolder_txtAccountCode").value = data[0];
            document.getElementById("MainContentPlaceHolder_txtAccountName").value = data[1];
        }
    }
    else {
        document.getElementById("MainContentPlaceHolder_hdnACID").value = 0;
        document.getElementById("MainContentPlaceHolder_pnlAccountConfiguration").style.display = 'inline';
        document.getElementById("MainContentPlaceHolder_pnlAccountDetails").style.display = 'none';
    }
}

function LoadCurrentBalance()
{
    debugger;
    var AccountID = document.getElementById("MainContentPlaceHolder_hdnAccountID").value;
    $.ajax({
        type: "POST",
        url: pageUrl("LoadCurrentBalance"),
        data: "{AccountID:" + AccountID + "}",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (msg) {
            debugger;
            var dataa = JSON.parse(msg.d);
            document.getElementById("MainContentPlaceHolder_lblCurrentBalance").innerHTML = dataa;
        },
        error: function (msg) {
            debugger;
            alert("ERROR:" + msg.responseText);
        }
    });
}


var input = document.getElementById('txtsearch');
input.onkeyup = function () {
    debugger;
    var filter = input.value.toUpperCase();
    var lis = document.getElementsByTagName('ol');

    for (var i = 0; i < lis.length; i++) {
        var name = lis[i].getElementsByClassName('name')[0].innerHTML;
        if (name.toUpperCase().indexOf(filter) == 0) {
            lis[i].style.display = 'list-item';
            FindChild(lis[i].id);
        }
        else {
            lis[i].style.display = 'none';
            FindChild(lis[i].id);
        }
    }
}
function FindChild(ParentAccountID) {
    var lis = "";
    var filter = input.value.toUpperCase();
    var abc = $("#" + ParentAccountID).find("ol");
    lis = $("#" + ParentAccountID).find("ol");
    if (lis.length == 0)
        lis = $("#" + ParentAccountID).find("li");

    for (var i = 0; i < lis.length; i++) {
        var name = lis[i].getElementsByClassName('name');
        for (var j = 0; j < name.length; j++) {
            var abc = name[j].innerHTML;
            if (abc.toUpperCase().indexOf(filter) == 0) {
                lis[i].style.display = 'list-item';
                FindChild(lis[i].id);
            }
            else {
                lis[i].style.display = 'none';
                FindChild(lis[i].id);
            }
        }
    }
}
