
var TreeView = function () {
    debugger;
    //var names = [
    //               { name: 'Dashboard', type: 'folder', additionalParameters: { id: 'F1' } },
    //               { name: 'Elements', type: 'folder', additionalParameters: { id: 'F2' } },
    //               { name: 'View Category', type: 'item', additionalParameters: { id: 'I1' } },
    //               { name: 'Testing', type: 'item', additionalParameters: { id: 'I2' } }];


    var names = [
                    { name: 'Dashboard', type: 'folder'},
                    { name: 'Elements', type: 'folder' },
                    { name: 'View Category', type: 'item' },
                    { name: 'Testing', type: 'item' }];

    var COA = ChartOfAccounts;
    return {
        
        //main function to initiate the module
        init: function () {
            debugger;
            var DataSourceTree = function (options) {
                this._data  = options.data;
                this._delay = options.delay;
            };

            DataSourceTree.prototype = {

                data: function (options, callback) {
                    debugger;
                    var self = this;
                    var ID = options.ID;
                    var ChildAccounts = [];

                    //jQuery.ajax({
                    //    type: "POST",
                    //    url: "ChartOfAccount.aspx/CurrentSelected",
                    //    data: "{ID:" + ID + "}",
                    //    contentType: "application/json; charset=utf-8",
                    //    dataType: "json",
                    //    success: function (msg) {
                    //        debugger;
                    //        document.getElementById('lblCurrentSelectAccount').innerHTML = "Current Balance: " + msg.d;
                    //        document.getElementById('pnlDetailsSec').style.display = "block";
                    //        document.getElementById('pnlDetailsSec').style.visibility = "visible";
                    //        document.getElementById('pnlAddNewAccountSec').style.display = "none";
                    //        document.getElementById('pnlAddNewAccountSec').style.visibility = "hidden";

                    //    },
                    //    failure: function (msg) {
                    //        debugger;
                    //    }
                    //});

                    if (ID > 0)
                    {
                        jQuery.ajax({
                            type: "POST",
                            url: pageUrl + "/GetChildAccounts",
                            data: "{ID:" + ID + "}",
                            contentType: "application/json; charset=utf-8",
                            dataType: "json",
                            success: function (msg) {
                                debugger;
                                // Replace the div's content with the page method's return.
                                //ChartOfAccounts = [];
                                document.getElementById('lblCurrentSelectAccount').innerHTML = "Current Balance: " + msg.d[0].CurrentBalance;
                                document.getElementById('pnlDetailsSec').style.display = "block";
                                document.getElementById('pnlDetailsSec').style.visibility = "visible";
                                document.getElementById('pnlAddNewAccountSec').style.display = "none";
                                document.getElementById('pnlAddNewAccountSec').style.visibility = "hidden";
                                for (var i = 0; i < msg.d.length; i++) {
                                    ChildAccounts.push({ name: msg.d[i].Name, type: msg.d[i].Type, ID: msg.d[i].AccountID });
                                }

                            },
                            failure: function (msg) {
                                debugger;
                            }
                        });

                    }

                    
                    setTimeout(function () {
                        debugger;
                        if (ChildAccounts.length > 0)
                            var data = $.extend(true, [], ChildAccounts);
                        else
                            var data = $.extend(true, [], self._data);

                        callback({ data: data });

                    }, this._delay)
                }
            };

            // INITIALIZING TREE
            var treeDataSource = new DataSourceTree({
                data: COA,
                delay: 1000
            });

            var treeDataSource2 = new DataSourceTree({
                data: [
                    { name: 'Test tree 1 <div class="tree-actions"></div>', type: 'folder', additionalParameters: { id: 'F11' } },
                    { name: 'Test tree 2 <div class="tree-actions"></div>', type: 'folder', additionalParameters: { id: 'F12' } },
                    { name: '<i class="fa fa-bell-o"></i> Notification', type: 'item', additionalParameters: { id: 'I11' } },
                    { name: '<i class="fa fa-bar-chart-o"></i> Assignment', type: 'item', additionalParameters: { id: 'I12' } }
                ],
                delay: 400
            });

            var treeDataSource3 = new DataSourceTree({
                data: [
                    { name: 'Dashboard <div class="tree-actions"></div>', type: 'folder', additionalParameters: { id: 'F11' } },
                    { name: 'View Category <div class="tree-actions"></div>', type: 'folder', additionalParameters: { id: 'F12' } },
                    { name: 'Bucket Theme', type: 'item', additionalParameters: { id: 'I11' } },
                    { name: 'Modern Elements', type: 'item', additionalParameters: { id: 'I12' } }
                ],
                delay: 400
            });

            var treeDataSource4 = new DataSourceTree({
                data: [
                    { name: 'Dashboard<div class="tree-actions"><i class="fa fa-plus"></i><i class="fa fa-trash-o"></i><i class="fa fa-refresh"></i></div>', type: 'folder', additionalParameters: { id: 'F11' } },
                    { name: 'View Category<div class="tree-actions"><i class="fa fa-plus"></i><i class="fa fa-trash-o"></i><i class="fa fa-refresh"></i></div>', type: 'folder', additionalParameters: { id: 'F12' } },
                    { name: '<i class="fa fa-user"></i> User <div class="tree-actions"><i class="fa fa-plus"></i><i class="fa fa-trash-o"></i><i class="fa fa-refresh"></i></div><div class="tree-actions"><i class="fa fa-plus"></i><i class="fa fa-trash-o"></i><i class="fa fa-refresh"></i></div>', type: 'item', additionalParameters: { id: 'I11' } },
                    { name: '<i class="fa fa-calendar"></i> Events <div class="tree-actions"><i class="fa fa-plus"></i><i class="fa fa-trash-o"></i><i class="fa fa-refresh"></i></div>', type: 'item', additionalParameters: { id: 'I12' } },
                    { name: '<i class="fa  fa-gear "></i> Works <div class="tree-actions"><i class="fa fa-plus"></i><i class="fa fa-trash-o"></i><i class="fa fa-refresh"></i></div>', type: 'item', additionalParameters: { id: 'I12' } }
                ],
                delay: 400
            });

            var treeDataSource5 = new DataSourceTree({
                data: [
                    { name: 'Dashboard<div class="tree-actions"><i class="fa fa-plus"></i><i class="fa fa-trash-o"></i><i class="fa fa-refresh"></i></div>', type: 'folder', additionalParameters: { id: 'F11' } },
                    { name: 'View Category<div class="tree-actions"><i class="fa fa-plus"></i><i class="fa fa-trash-o"></i><i class="fa fa-refresh"></i></div>', type: 'folder', additionalParameters: { id: 'F12' } },
                    { name: '<i class="fa fa-user"></i> User <div class="tree-actions"><i class="fa fa-plus"></i><i class="fa fa-trash-o"></i><i class="fa fa-refresh"></i></div><div class="tree-actions"><i class="fa fa-plus"></i><i class="fa fa-trash-o"></i><i class="fa fa-refresh"></i></div>', type: 'item', additionalParameters: { id: 'I11' } },
                    { name: '<i class="fa fa-calendar"></i> Events <div class="tree-actions"><i class="fa fa-plus"></i><i class="fa fa-trash-o"></i><i class="fa fa-refresh"></i></div>', type: 'item', additionalParameters: { id: 'I12' } },
                    { name: '<i class="fa  fa-gear "></i> Works <div class="tree-actions"><i class="fa fa-plus"></i><i class="fa fa-trash-o"></i><i class="fa fa-refresh"></i></div>', type: 'item', additionalParameters: { id: 'I12' } }
                ],
                delay: 400
            });

            var treeDataSource6 = new DataSourceTree({
                data: [
                    { name: 'Dashboard<div class="tree-actions"><i class="fa fa-plus"></i><i class="fa fa-trash-o"></i><i class="fa fa-refresh"></i></div>', type: 'folder', additionalParameters: { id: 'F11' } },
                    { name: 'View Category<div class="tree-actions"><i class="fa fa-plus"></i><i class="fa fa-trash-o"></i><i class="fa fa-refresh"></i></div>', type: 'folder', additionalParameters: { id: 'F12' } },
                    { name: '<i class="fa fa-user"></i> User <div class="tree-actions"><i class="fa fa-plus"></i><i class="fa fa-trash-o"></i><i class="fa fa-refresh"></i></div><div class="tree-actions"><i class="fa fa-plus"></i><i class="fa fa-trash-o"></i><i class="fa fa-refresh"></i></div>', type: 'item', additionalParameters: { id: 'I11' } },
                    { name: '<i class="fa fa-calendar"></i> Events <div class="tree-actions"><i class="fa fa-plus"></i><i class="fa fa-trash-o"></i><i class="fa fa-refresh"></i></div>', type: 'item', additionalParameters: { id: 'I12' } },
                    { name: '<i class="fa  fa-gear "></i> Works <div class="tree-actions"><i class="fa fa-plus"></i><i class="fa fa-trash-o"></i><i class="fa fa-refresh"></i></div>', type: 'item', additionalParameters: { id: 'I12' } }
                ],
                delay: 400
            });

            $('#FlatTree').tree({
                dataSource: treeDataSource,
                loadingHTML: '<img src="images/input-spinner.gif"/>',
            });


            $('#FlatTree2').tree({
                dataSource: treeDataSource2,
                loadingHTML: '<img src="images/input-spinner.gif"/>',
            });

            $('#FlatTree3').tree({
                dataSource: treeDataSource3,
                loadingHTML: '<img src="images/input-spinner.gif"/>',
            });

            $('#FlatTree4').tree({
                selectable: false,
                dataSource: treeDataSource4,
                loadingHTML: '<img src="images/input-spinner.gif"/>',
            });


        }

    };

}();