
        function ShowModal() {
            $('#mdlConfirmSave').modal("show");
        }

        function ShowModuleModal() {
            $('#mdlModule').modal("show");
        }

        var pageUrl = '<%= ResolveUrl(Request.Url.AbsolutePath) %>';
        debugger;
        jQuery.ajax({
            type: "POST",
            url: pageUrl + "/SetShortcut",
            data: "{}",
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: function (msg) {
                debugger;
                // Replace the div's content with the page method's return.
                //var objdata = JSON.parse(msg.d);
                for (var i = 0; i < msg.d.length; i++) {
                    var ShortcutKey = msg.d[i].split(':');
                    if (ShortcutKey[1] != "" && ShortcutKey[1] != null) {
                        var script = '<script type="text/javascript"> $(document).keydown(function (e) {if (e.altKey && e.shiftKey && String.fromCharCode(e.which) =="' + ShortcutKey[1] + '") {e.preventDefault(); window.location = "' + ShortcutKey[0] + '";}})<\/script>';

                        $("head").append(script);
                    }
                }
            },
            failure: function (msg) {
                debugger;
            }
        });

        //function SaveSuccessfully()
        //{
        //        $.gritter.add({
        //            // (string | mandatory) the heading of the notification
        //            title: 'Save Successfully',
        //            // (string | mandatory) the text inside the notification
        //            text: 'Data has been save successfully'
        //        });
        //}
        function ShowMessage(Messages, MessageType) {
            debugger;
            var varMessages = Messages.split(':');
            $.gritter.add({
                // (string | mandatory) the heading of the notification
                title: varMessages[1],
                // (string | mandatory) the text inside the notification
                text: varMessages[0]
            });
        }

        $(document).ready(function () {
            // Handler for .ready() called.
            debugger;
            if (document.getElementsByClassName("myswitch").length > 0) {
                var botts = document.getElementsByClassName("myswitch")[0].innerHTML;
                var botts = $(".myswitch").html();
                $(".myswitch").replaceWith(botts);
            }

        });
       
        $(document).ready(function () {
            // Fix up GridView to support THEAD tags            
            $(".dynamic-table tbody").before("<thead><tr></tr></thead>");
            $(".dynamic-table thead tr").append($(".dynamic-table th"));
            $(".dynamic-table tbody tr:first").remove();

            $(".hidden-table-info tbody").before("<thead><tr></tr></thead>");
            $(".hidden-table-info thead tr").append($(".hidden-table-info th"));
            $(".hidden-table-info tbody tr:first").remove();
            
        });
