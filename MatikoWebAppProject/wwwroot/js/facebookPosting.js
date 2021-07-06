const token = "EAACZAe71CaZA4BAGkaLG2UZCRyqvRFZAbr8nupC5zQvWZAEyZA3Iqu3I1bE1NPcw1kd4sM799wyviF6wSyebFvbwEoxRoJlJvnvXOptY45KGzlj3vNdHHzwLBFKJpRnawqPZAiwiRVraQW6iOy9iC4ZBfnZALFN2mW5jIc5r6I6ruRkfBQ2Xu7nc9fM5tMb2CXoJ6hluo4WHN2wZDZD";

// Post using facebook api
document.getElementById("submitButton").onclick = function postAStatus() {
    var status = "Check out our new Product - " +  document.getElementById('nameInput').value + " !" ;

    FB.api(
        '/112553514419642/feed',
        'POST',
        {
            "message": status,
            "access_token": token
        },
        function (response) {
            console.log(response);
        }
    );
}

function boostAProduct(status, photoURL) {
    FB.api(
        '/enter your page id/photos',
        'POST',
        {
            "message": status,
            "url": photoURL,
            "access_token": token
        },
        function (response) {
            console.log(response);
        }
    );
}