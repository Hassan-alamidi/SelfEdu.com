function getAllVideoDetails(id) {
    selectRequest("VideoDetails", test, id);
}

function test(data) {
    alert(data.Title);
}