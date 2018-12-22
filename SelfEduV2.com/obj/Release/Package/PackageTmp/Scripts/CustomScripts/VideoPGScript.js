var videoId;
var videoDetails;
var isUserLoggedIn;
var isLiked;
var alreadyRated;
var updateRatingBy;
var likesNo, dislikesNo;

function getAndSetDetails(id, userLogged) {
    //set details of currently viewed details

    videoId = id;
    isUserLoggedIn = userLogged;
    //get details relating to the current video
    selectRequest("VideoDetails", getAndDisplay, id);
   
}

function postComment(commentId = -1, commentNum = -1) {
    if (isUserLoggedIn) {
        //if commentId equals -1 then this is a comment on a video else it is a reply to a comment
        if (commentId === -1) {
            var commentSub = document.getElementById('commentTextbox').value;
        } else {
            var commentSub = document.getElementById('commentTextbox' + commentNum).value;
           
        }
        var commentDTO = { Id: commentId, Comment: commentSub, Video_id: videoId };
        selectRequest("PostComment", result, commentDTO);
    } else {
        alert('you must login first');
    }
}

function rateVideo(isLike) {
    //TODO overly and unnecessarily complicated if I have time must simplify
    if (isUserLoggedIn) {
        if (alreadyRated === "noRating") {
            updateRatingBy = 1;
            isLiked = isLike;
            var Rating = { IsLike: isLike, Content_id: videoId };
            selectRequest('RateVideo', updateLikesAndDislikes, Rating);
        } else if (alreadyRated === "liked") {
            
            if (!isLike) {
                //change to dislike
                updateRatingBy = 1;
                isLiked = isLike;
                var Rating = { IsLike: isLike, Content_id: videoId };
                selectRequest('UpdateVideoRating', updateLikesAndDislikes, videoId);
            } else if (isLike) {

                //remove like
                isLiked = isLike;
                updateRatingBy = -1;
                selectRequest('DeleteRating', updateLikesAndDislikes, videoId);
            }
        } else if (alreadyRated === "disliked") {
            
            if (!isLike) {
                //remove dislike
                isLiked = isLike;
                updateRatingBy = -1;
                selectRequest('DeleteRating', updateLikesAndDislikes, videoId);
            } else if (isLike) {
                //change to like
                updateRatingBy = 1;
                isLiked = isLike;
                var Rating = { IsLike: isLike, Content_id: videoId };
                selectRequest('UpdateVideoRating', updateLikesAndDislikes, videoId);

            }
        }




        
    } else {
        alert('you must login first');
    }
}

function removeRating() {
    //when this is set up it should use a DELETE request to remove the rating from the video
    
}

function result(data) {
    //this should notify the user that if their comment was successful
    //maybe I could append to the current list
    alert(data);
}

function getAndDisplay(data) {
    videoDetails = data;
    alreadyRated = videoDetails.CurrentUserRating;
    
    //display related videos
    displayRelatedVideos();
    //display comments
    displayComments();
    //display likes and dislikes
    displaylikeAndDislikes();
}

function displaylikeAndDislikes() {
    if (alreadyRated === "disliked") {
        $('#dislikeBtn').css('background-image', '-webkit-linear-gradient(top, #0cad27,#1ba219, #17670e)');
    } else if (alreadyRated === "liked") {
        $('#likeBtn').css('background-image', '-webkit-linear-gradient(top, #0cad27,#1ba219, #17670e)');
    }
    likesNo = videoDetails.Like;
    dislikesNo = videoDetails.Dislike;
    $('#likeLbl').append(likesNo);
    $('#dislikeLbl').append(dislikesNo);
}

function updateLikesAndDislikes() {
    
    if (updateRatingBy === 1) {
        if (isLiked) {
            if (alreadyRated === "disliked") {
                //remove dislike and add like
                $('#dislikeBtn').css('background-image', '-webkit-linear-gradient(top, #d3d3d3,#b3b3b3, #636363)');
                $('#likeBtn').css('background-image', '-webkit-linear-gradient(top, #0cad27,#1ba219, #17670e)');
                alreadyRated = "liked";
                likesNo++;
                dislikesNo--;
                $('#likeLbl').empty();
                $('#likeLbl').append(likesNo);
                $('#dislikeLbl').empty();
                $('#dislikeLbl').append(dislikesNo);
            } else {
                //add like
                $('#likeBtn').css('background-image', '-webkit-linear-gradient(top, #0cad27,#1ba219, #17670e)');
                alreadyRated = "liked";
                likesNo++;
                $('#likeLbl').empty();
                $('#likeLbl').append(likesNo);
            }
        } else {
            if (alreadyRated === "liked") {
                //remove like and add disliked
                $('#likeBtn').css('background-image', '-webkit-linear-gradient(top, #d3d3d3,#b3b3b3, #636363)');
                $('#dislikeBtn').css('background-image', '-webkit-linear-gradient(top, #0cad27,#1ba219, #17670e)');
                alreadyRated = "disliked";
                likesNo--;
                dislikesNo++;
                $('#likeLbl').empty();
                $('#likeLbl').append(likesNo);
                $('#dislikeLbl').empty();
                $('#dislikeLbl').append(dislikesNo);
            } else {
                //add dislike
                $('#dislikeBtn').css('background-image', '-webkit-linear-gradient(top, #0cad27,#1ba219, #17670e)');
                alreadyRated = "disliked";
                dislikesNo++;
                $('#dislikeLbl').empty();
                $('#dislikeLbl').append(dislikesNo);
            }
        }
    } else if (updateRatingBy === -1) {
        if (isLiked) {
            if (alreadyRated === "liked") {
                //remove like
                $('#likeBtn').css('background-image', '-webkit-linear-gradient(top, #d3d3d3,#b3b3b3, #636363)');
                alreadyRated = "noRating";
                likesNo--;
                $('#likeLbl').empty();
                $('#likeLbl').append(likesNo);
               
            } else {
                console.debug("should not have gotten this far");
            }
        } else {
            if (alreadyRated === "disliked") {
                //remove disliked
                $('#dislikeBtn').css('background-image', '-webkit-linear-gradient(top, #d3d3d3,#b3b3b3, #636363)');
                alreadyRated = "noRating";
                dislikesNo--;
                $('#dislikeLbl').empty();
                $('#dislikeLbl').append(dislikesNo);
            } else {
                console.debug("should not have gotten this far");
            }
        }
    } else {
        alert('not setUp');
    }
    /*
    if (isLiked) {
        alreadyRated = "liked";
        likes = videoDetails.Like + updateRatingBy;
        $('#likeLbl').empty();
        $('#likeLbl').append(likes);
    } else if (isLiked === false) {
        alreadyRated = "disliked";
        dislikes = videoDetails.Dislike + updateRatingBy;
        $('#dislikeLbl').empty();
        $('#dislikeLbl').append(dislikes);
    } else {
        if (alreadyRated === "liked") {
            alreadyRated = "noRating";
            isLiked = "";
            likes = videoDetails.Like + updateRatingBy;
            $('#likeLbl').empty();
            $('#likeLbl').append(likes);
        } else {
            alreadyRated = "noRating";
            isLiked = "";
            likes = videoDetails.Like + updateRatingBy;
            $('#dislikeLbl').empty();
            $('#dislikeLbl').append(likes);
        }
    }*/
    
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
        var link = "'/Videos/Details/" + videoDetails.Videos[i].Video_id + "'";
        html += '<div class="row vert_padding" onclick="navigateTo(' + link + ')"> <div class="container-fluid spotlight-container"><div class="row popularVideo">';
        html += '<div class="searchResThumbnail" style="background-image: url(' + videoDetails.Videos[i].ThumbnailPath + ');"></div></div>';
        html += '<div class="row">';
        html += '<h4 class="itemTitle" >' + videoDetails.Videos[i].Title + '</h4><p class="itemRating">' + videoDetails.Videos[i].OverAllRating + '</p>';
        html += '</div></div></div>';
      
    }
    
    $('#videoSuggestions').append(html);
    
}

function navigateTo(url) {
    window.location.href = url;
}