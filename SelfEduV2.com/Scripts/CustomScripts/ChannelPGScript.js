var channelDetails;
var isSubscribed;

function getDetails(id) {
   selectRequest("GetChannelDetails", storeDetails, id); 
}

function subscribe(chanId) {
    
    if (isSubscribed !== undefined && (isSubscribed === false || isSubscribed === "false")) {
        selectRequest("Subscribe", subscribed, { Channel_id: chanId });
    } else if (isSubscribed !== undefined && (isSubscribed === true || isSubscribed === "true")) {
        selectRequest("Unsubscribe", unsubscribed, chanId);
    }
}

function storeDetails(data) {
    channelDetails = data;
    isSubscribed = data.IsCurrentUserSub;
    if (isSubscribed) {
        $('#SubBtn').empty();
        $('#SubBtn').append('Unsubscribe');
        $('#SubBtn').removeClass('btn-primary');
        $('#SubBtn').addClass('btn-success');
    }
}

function subscribed() {
    channelDetails.SubscriberCount++;
    isSubscribed = true;
    $('#SubCount').empty();
    $('#SubCount').append(channelDetails.SubscriberCount);
    $('#SubBtn').removeClass('btn-primary');
    $('#SubBtn').addClass('btn-success');
    $('#SubBtn').empty();
    $('#SubBtn').append('Unsubscribe');
}

function unsubscribed() {
    channelDetails.SubscriberCount--;
    isSubscribed = false;
    $('#SubCount').empty();
    $('#SubCount').append(channelDetails.SubscriberCount);
    $('#SubBtn').removeClass('btn-success');
    $('#SubBtn').addClass('btn-primary');
    $('#SubBtn').empty();
    $('#SubBtn').append('Subscribe');
}