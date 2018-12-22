var data;
var URL, reqtype;
var response;
$(document).ready(function () {
   /* $('#submitBtn').on('click', function () {
        URL = "../Videos/Create";
        reqType = "POST";
        storeVidData();
        uploadData();
        
    })*/
});

function selectRequest(selection, callback, vals = "") {
    switch (selection) {
        case "topRated":
            URL = "/api/Videos";
            retype = "GET";
            data = "";
            break;
        case "VideoDetails":
            URL = "/api/Videos/" + vals;
            retype = "GET";
            data = "";
            break;
        case "PostComment":
            URL = "/api/Comments";
            retype = "POST";
            data = vals;
            break;
        case "RateVideo":
            URL = "/api/Ratings";
            retype = "POST";
            data = vals;
            break;
        case "DeleteRating":
            URL = "/api/Ratings/Delete/" + vals;
            retype = "DELETE";
            data = "";
            break;
        case "UpdateVideoRating":
            URL = "/api/Ratings/Update/" + vals;
            retype = "PUT";
            data = "";//{ 'id': vals };
            break;
        case "Subscribe":
            URL = "/api/Channels/Subscribe";
            retype = "POST";
            data = vals;
            break;
        case "GetChannelDetails":
            URL = "/api/Channels/" + vals;
            retype = "GET";
            data = "";
            break;
        case "Unsubscribe":
            URL = "/api/Channels/Unsubscribe/" + vals;
            retype = "DELETE";
            data = "";
            break;
        case "userDetails":
            URL = "/api/ApplicationUsers";
            retype = "GET";
            data = "";
            break;
        default:
            alert("request not setup");
            return;
            
    }
    BeginRequest(callback);
    
}


function BeginRequest(callback) {

    $.ajax({
        type: retype,
        url: URL,
        data:data,
        dataType: "json",
        contentType: 'application/x-www-form-urlencoded',
        success: function (resp, statusText, xhr) {

            //alert('success?');
            callback(resp);
        },
        error: function (xhr) {
            alert('Request failed: Status code =' + xhr.status);
        }

    });

}

