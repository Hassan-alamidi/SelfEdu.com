var videoId;
var videoDetails
var isUserLoggedIn
function getAndSetDetails(id, userLogged) {
    //set details of currently viewed details
    videoId = id;
    isUserLoggedIn = userLogged;
    //get details relating to the current video
    selectRequest("VideoDetails", getAndDisplay, id);
   
}

function postComment(commentId = -1, commentNum = -1) {
    //if commentId equals -1 then this is a comment on a video else it is a reply to a comment
    if (commentId === -1) {
        var commentSub = document.getElementById('commentTextbox').value;
    } else {
        var commentSub = document.getElementById('commentTextbox' + commentNum).value;
        alert(commentSub);
    }
    var commentDTO = { Id: commentId ,Comment: commentSub, Video_id: videoId };
    selectRequest("PostComment", commentResult, commentDTO);
}

function commentResult(data) {
    //this should notify the user that if their comment was successful
    //maybe I could append to the current list
    alert(data);
}

function getAndDisplay(data) {
    videoDetails = data;
    //display related videos
    displayRelatedVideos();
    //display comments
    displayComments();
    //display likes and dislikes
    displaylikeAndDislikes();
}

function displaylikeAndDislikes() {
    likes = videoDetails.Like;
    dislikes = videoDetails.Dislike;
    $('#likeLbl').append(likes);
    $('#dislikeLbl').append(dislikes);
}

function displayComments() {
    //this may not be needed as displayrelated videos should have all the details we need
    var html = "";
    var count = videoDetails.Comments.length;
    for (var i = 0; i < count; i++) {
        //extract the date from the value
        var date = videoDetails.Comments[i].Date.split(" ");
        html += '<div class="row vert_padding "> <div class="container-fluid commentContainer"><div class="row padding-left">';
        html += '<div class="col-xs-6"><h4>' + videoDetails.Comments[i].UserName + '</h4></div><div class="col-xs-6"><h6>Posted: ' + date[0] + '</h6></div></div>';
        html += '<hr/><div class="row padding-left">';
        html += '<div class="col-xs-10"><p>' + videoDetails.Comments[i].Comment + '</p></div>';
        if (isUserLoggedIn) {
            html += '<div class="col-xs-2" data-toggle="collapse" data-target="#commentFormCont' + i + '"><a>Reply</a></div>';
        }
        html += '</div>';
        html += '<div class="row collapse" id="commentFormCont' + i + '"><textarea class="form-control" rows = "5" id = "commentTextbox' + i + '" placeholder = "Please Enter your comment here"></textarea>';
        html += '<button type="button" class="btn btn-dark" onclick="postComment(' + videoDetails.Comments[i].Id + ', ' + i + ')" id="commentSubmit" data-toggle="collapse" data-target="#commentFormCont' + i + '">Submit</button></div>';
        var replyCount = videoDetails.Comments[i].Replies.length;
        for (var j = 0; j < replyCount; j++) {
            html += '<hr class="commentSeperator" />';
            var Rdate = videoDetails.Comments[i].Replies[j].Date.split(" ");
            html += '<div class="row padding-far-left">';
            html += '<div class="col-xs-6"><h4>' + videoDetails.Comments[i].Replies[j].UserName + '</h4></div><div class="col-xs-6"><h6>Posted: ' + Rdate[0] + '</h6></div></div>';
            html += '<hr/><div class="row padding-far-left">';
            html += '<div class="col-xs-10"><p>' + videoDetails.Comments[i].Replies[j].Comment + '</p></div>';
            html += '</div>';
        }
       
        html += '</div ></div>';
        
    }
    $('#commentsOnVideo').append(html);
}

function displayRelatedVideos() {
    var html = "";
    var count = videoDetails.Videos.length;
    
    for (var i = 0; i < count; i++) {
        
        html += '<div class="row vert_padding"> <div class="container-fluid spotlight-container"><div class="row popularVideo">';
        html += '<div class="searchResThumbnail" style="background-image: url(' + videoDetails.Videos[i].ThumbnailPath + ');"></div></div>';
        html += '<div class="row">';
        html += '<h4 class="itemTitle" >' + videoDetails.Videos[i].Title + '</h4><p class="itemRating">' + videoDetails.Videos[i].OverAllRating + '</p>';
        html += '</div></div></div>';
      
    }
    
    $('#videoSuggestions').append(html);
    
}