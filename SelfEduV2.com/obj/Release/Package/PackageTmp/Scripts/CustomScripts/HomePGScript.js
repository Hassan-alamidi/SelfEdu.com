$(document).ready(function () {
    selectRequest("topRated", processPopularVideos);
});

function processPopularVideos(data) {
    //alert("worked " + data[1].Title);
    var html = "";
    var NumOfLoops = data.length / 2;
    var count = 0;
    for (var i = 0; i < NumOfLoops; i++) {
        html += '<div class="col-md-4 NoPadding"><div class="container-fluid"><div class="row">';
        for (var j = 0; j < 2; j++) {
            var link = "'/Videos/Details/" + data[count].Video_id + "'";
            html += '<div class="col-sm-6" onclick="navigateTo(' + link + ')"> <div class="container-fluid spotlight-container"> <div class="row popularVideo">';
            html += '<div class="searchResThumbnail" style="background-image: url(' + data[count].ThumbnailPath + ');"></div></div>';
            html += '<div class="row">';
            html += '<h4 class="itemTitle" >' + data[count].Title + '</h4><p class="itemRating">' + data[count].OverAllRating + '</p>';
            html += '</div></div></div>';
            count++;
        }
        html += "</div></div></div>"
    }
    $('.ContentSpotlight').append(html);
}


function navigateTo(url) {
    window.location.href = url;
}