// notification body's can be any html string or just string

function SetNotification(Title, Message) {
    //var notification_html = [];
    var str = "";
    if (Title == "Success")
        str = '<div class="activity-item"> <i class="fa fa-check text-success" style="color: darkgreen;">&nbsp;&nbsp;<b style="color: darkgreen;font-family: sans-serif;">' + Title + '</b></i> <div class="activity" style="font-family: Calibri;color: black;">' + Message + '</div> </div>';
    else if (Title == "Error")
        str = '<div class="activity-item"> <i class="fa fa-times-circle text-danger" style="color: white;">&nbsp;&nbsp;<b style="color: white;font-family: sans-serif;">' + Title + '</b></i> <div class="activity" style="font-family: Calibri;color: black;">' + Message + ' </div> </div>';
    else if (Title == "Help")
        str = '<div class="activity-item"> <i class="fa fa-info-circle text-info" style="color: white;">&nbsp;&nbsp;<b style="color: white;font-family: sans-serif;">' + Title + '</b></i> <div class="activity" style="font-family: Calibri;color: black;">' + Message + ' </div> </div>';
    else if (Title == "Warning")
        str = '<div class="activity-item"> <i class="fa fa-warning text-warning" style="color: rgb(130, 98, 0);">&nbsp;&nbsp;<b style="color: rgb(130, 98, 0);font-family: sans-serif;">' + Title + '</b></i> <div class="activity" style="font-family: Calibri;color: black;">' + Message + '</div></div>';



    //notification_html[0] = '<div class="activity-item"> <i class="fa fa-warning text-warning">&nbsp;&nbsp;<b>' + Title + '</b></i> <div class="activity">' + Message + '</div></div>',
    //notification_html[1] = '<div class="activity-item"> <i class="fa fa-times-circle text-danger">&nbsp;&nbsp;<b>' + Title + '</b></i> <div class="activity">' + Message + ' </div> </div>',
    //notification_html[2] = '<div class="activity-item"> <i class="fa fa-info-circle text-info">&nbsp;&nbsp;<b>' + Title + '</b></i> <div class="activity">' + Message + ' </div> </div>',
    //notification_html[3] = '<div class="activity-item"> <i class="fa fa-check text-success">&nbsp;&nbsp;<b>' + Title + '</b></i> <div class="activity">' + Message + '</div> </div>';

    return str;
}