var videoId;
var videoDetails
function getAndSetDetails(id) {
    //set details of currently viewed details
    videoId = id;
    //get details relating to the current video
    selectRequest("VideoDetails", displayRelatedVideos, id);
   
}

function postComment() {
    var commentSub = document.getElementById('commentTextbox').value;
    alert(videoDetails.Title);
    var commentDTO = { Comment: commentSub, Video_id: videoId };
    selectRequest("PostComment", commentResult, commentDTO);
}

function commentResult(data) {
    //this should notify the user that if their comment was successful
    //maybe I could append to the current list
    alert(data);
}

function displayComments() {
    //this may not be needed as displayrelated videos should have all the details we need
    var html = "";
    var count = videoDetails.Comments.length;
    for (var i = 0; i < count; i++) {
        html += '<div class="row vert_padding"> <div class="container-fluid"><div class="row">';
        html += '<h3>' + videoDetails.Comments[i].UserName + '</h3></div>';
        html += '<div class="row">';
        html += '<p>' + videoDetails.Comments[i].Comment + '</p>';
        html += '</div></div></div>';
    }
    $('#commentsOnVideo').append(html);
}

function displayRelatedVideos(data) {
    var html = "";
    var count = data.Videos.length;
    videoDetails = data;
    for (var i = 0; i < count; i++) {
        
            html += '<div class="row vert_padding"> <div class="container-fluid spotlight-container"><div class="row popularVideo">';
            html += '<div class="searchResThumbnail" style="background-image: url(' + data.Videos[i].ThumbnailPath + ');"></div></div>';
            html += '<div class="row">';
            html += '<h4 class="itemTitle" >' + data.Videos[i].Title + '</h4><p class="itemRating">' + data.Videos[i].OverAllRating + '</p>';
            html += '</div></div></div>';
      
    }
    alert(data.Title);
    $('#videoSuggestions').append(html);
    //get comments
    displayComments();
}