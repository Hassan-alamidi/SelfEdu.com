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

function selectRequest(selection, callback, vals) {
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
        
        default:
            alert("request not setup");
            break;
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

            
            callback(resp);
        },
        error: function (xhr) {
            alert('Request failed: Status code =' + xhr.status);
        }

    });

}

