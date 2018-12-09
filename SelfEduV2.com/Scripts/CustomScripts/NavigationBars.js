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

$(document).click(function (event) {
    if ($(event.target).closest('#usernameBtn').length == 0 && $('#userdropdown').hasClass('topBToggle')) {
        $('#userdropdown').removeClass('topBToggle');
    }else if ($(event.target).closest('#SideBarBtn').length == 0 && $('#SideBar').hasClass('sideBToggle')) {
        $('#SideBar').removeClass('sideBToggle');
       
    }
});