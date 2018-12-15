var fData = new FormData();
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

function selectRequest(selection, callback, id) {
    switch (selection) {
        case "topRated":
            URL = "/api/Videos";
            retype = "GET";

            break;
        case "VideoDetails":
            URL = "/api/Videos/" + id;
            retype = "GET";
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
        //data:fData,
        dataType: "json",
        success: function (resp, statusText, xhr) {

            
            callback(resp);
        },
        error: function (xhr) {
            alert('Request failed: Status code =' + xhr.status);
        }

    });

}

