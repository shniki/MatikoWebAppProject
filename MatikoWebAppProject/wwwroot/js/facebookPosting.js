

        // Post using facebook api
        function postAStatus() {
            var status = "Check out our new Product at Matiko !";
            const token = "EAACZAe71CaZA4BADTMp9gYmURLThnOfIZAvnPwZB82Ed2pBeRS51dQbW2xIUSkfd8vSwoqRKXNXR82HnqRWvHAEpF99RP0ckZAkOAPOZAD78kZA1fWnDQuRQJZBcbaUgZA5KrVQ5Kg7qFKUQZBU9N96yZBubl1mZB5age72eU3auYvtWxxXEE4E36UPAOOtOisOZAEeOjN2yqvl0KuwZB0HwMGrvvV";
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