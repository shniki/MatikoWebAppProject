$.ajax({
    type: "POST",
    url: "/person/create",
    dataType: "json",
    contentType: "application/json; charset=utf-8",
    data: jsonData,
    success: function (result) {
        console.log(result); //log to the console to see whether it worked
    },
    error: function (error) {
        alert("There was an error posting the data to the server: " + error.responseText);
    }
});