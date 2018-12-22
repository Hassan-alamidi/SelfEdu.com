var userDetails;
$(document).ready(function () {
    $('#SideBarBtn').on('click', function () {
        toggleSideBar();
    });

    $('#usernameBtn').on('click', function () {
        toggletopBar();
    });

    
});

function toggleSideBar() {
    $('#SideBar').toggleClass('sideBToggle');
}

function toggletopBar() {
    $('#userdropdown').toggleClass('topBToggle');
}

function loadUserDetails(data) {
    userDetails = data;
    var channelNo = userDetails.Subscriptions.length;
    if (channelNo > 0) {
        $('#sideNavBar').append('<li style="color:red;">Subscriptions</li>');
        for (var i = 0; i < userDetails.Subscriptions.length; i++) {
            $('#sideNavBar').append('<li><a href="/Channels/Details?isMyChan=false&chanId=' + userDetails.Subscriptions[i].Id + '">' + userDetails.Subscriptions[i].ChannelName + '</a></li>');
        }
    }
}

$(document).click(function (event) {
    if ($(event.target).closest('#usernameBtn').length == 0 && $('#userdropdown').hasClass('topBToggle')) {
        $('#userdropdown').removeClass('topBToggle');
    }else if ($(event.target).closest('#SideBarBtn').length == 0 && $('#SideBar').hasClass('sideBToggle')) {
        $('#SideBar').removeClass('sideBToggle');
    }
});

