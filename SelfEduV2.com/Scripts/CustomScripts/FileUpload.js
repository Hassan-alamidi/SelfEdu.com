var fData = new FormData();
var URL, reqtype;

$(document).ready(function () {
   /* $('#submitBtn').on('click', function () {
        URL = "../Videos/Create";
        reqType = "POST";
        storeVidData();
        uploadData();
        
    })*/
});

function storeChThumbnailData() {
    $_POST['title'];
}

function storeVidData() {

    //get data
    var title = $('#Title').val();
    var description = $('#Description').val();
    var keywords = $('#Keywords').val();
    var thumbnail = $('#thumbnail')[0].files[0];
    var video = $('#video')[0].files[0];
    if (video == undefined || thumbnail == undefined) {
        alert('undefined');
    }
    
    //store data in formdata for transportation
    fData.append("title", title);
    fData.append("description", description);
    fData.append("keywords", keywords);
    //fData.append('thumbnail', thumbnail);
    //fData.append('video', video);
}

function uploadData() {
    alert('processing');
    var file = fData.get('video');//video
    var thumbnail = fData.get('thumbnail');//image
    
    //a quick test to check if files are not undefined and if they are a folder,
    //this isnt a fool proof way of checking but hopefully helps minimizes the chances of folder uploads
   /* if ((file == undefined || thumbnail == undefined) || (!file.type && file.size % 4096 == 0) || (!thumbnail.type && thumbnail.size % 4096 == 0)) {
        alert("failed");
        return;
    }*/

    $.ajax({
        type: "POST",
        url: URL,
        data:fData,
        //dataType: "json",
        enctype: 'multipart/form-data',
        processData: false,
        ContentType: false,
        success: function (resp, statusText ,xhr) {
            
            try {
                alert("worked data is: " + resp["message"] + " " + statusText + " " + xhr.status);
            } catch (e) {
                alert("failed error: " + e);
            }
        },
        error: function (xhr) {
            alert('Request failed: Status code =' + xhr.status);
        }

    });

}

