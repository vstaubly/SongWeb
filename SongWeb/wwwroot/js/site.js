// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your Javascript code.
var songTableHeader = "<tr><th>ID</th><th>Song Title</th><th>Artist/Band</th><th>Album</th><th>Yeah</th><th>Track #</th></tr>";
var dummySong = {
    id: 1, title: "Blowin' In The Wind", artist: "Peter, Paul, and Mary", album: "Ten Years After", year: "1970", track: "1"
}

function wrapSong(songObj) {
    var html = "<tr>";
    html += "<td>" + songObj.id + "</td>";
    html += "<td>" + songObj.title + "</td>";
    html += "<td>" + songObj.artist + "</td>";
    html += "<td>" + songObj.album + "</td>";
    html += "<td>" + songObj.year + "</td>";
    html += "<td>" + songObj.track + "</td>";
    html += "</tr>";
    return html;
}
function ajaxHandleReply(data) {
    var testDiv = document.getElementById("ajaxtest");
    if (testDiv) {
        var html = "";
        if (data.d) {
            for (var i = 0; i < data.d.length; i++) {
                html += data[i] + "<br/>";
            }
        }
        testDiv.innerHTML = html;
    }
}
function ajaxMakeRequest() {
    $.ajax({
        url: "api/SongsController",
        method: 'GET',
        dataType: 'json',
        success: ajaxHandleReply
    });
}
function requestTable() {
    var songTable = document.getElementById("songtable");
    if (songTable) {
        tableHtml = songTableHeader;
        tableHtml += wrapSong(dummySong);
        songTable.innerHTML = tableHtml;
    } else {
        console.log("SongTable element not found");
    }
    ajaxMakeRequest();
}
