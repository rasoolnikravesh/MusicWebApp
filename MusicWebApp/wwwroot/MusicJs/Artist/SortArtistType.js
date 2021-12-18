$(document).ready(function () {
    $(SortArtistType).change(function (event) {
        console.log($(this).val())
        const xhr = new XMLHttpRequest();
        xhr.open("get", "/panel/artist/sortartist")
        xhr.send();
    })
})