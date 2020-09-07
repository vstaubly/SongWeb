// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your Javascript code.

// table header for easier DOM manipulation code
var songTableHeader = "<tr><th>ID</th><th>Song Title</th><th>Artist/Band</th><th>Album</th><th>Yeah</th><th>Track #</th></tr>";

// convert song from JSON object to table row (adding a class to each cell might help to jazz things up via CSS)
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

// when reply with data received, generate table with new song list
function ajaxHandleReply(data) {
    var testDiv = document.getElementById("songtable");
    if (testDiv) {
        var html = songTableHeader;
        if (data) {
            for (var i = 0; i < data.length; i++) {
                html += "" + wrapSong(data[i]);
            }
        }
        testDiv.innerHTML = html;
    }
}
function ajaxMakeRequest() {
    $.ajax({
        url: "/api/songs",
        method: 'GET',
        dataType: 'json',
        success: ajaxHandleReply
        // note: for finished project, add error handler
    });
}

// handle requesting the song table with searching by a particular field
function requestSearchBy() {
    var fieldElement = document.getElementById("searchField");
    var valueElement = document.getElementById("searchValue");
    if (fieldElement && valueElement) {
        var field = encodeURI(fieldElement.value);
        var value = encodeURI(valueElement.value);
        console.log("Search by " + field + " with value " + value);
        $.ajax({
            url: "/api/songs?field=" + field + "&value=" + value,
            method: 'GET',
            dataType: 'json',
            success: ajaxHandleReply
            // note: for finished project, add error handler
        });
    }
}

function requestTable() {
    ajaxMakeRequest(); // should just merge these functions since testing is over
}
