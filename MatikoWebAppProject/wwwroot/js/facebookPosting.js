

        // Post using facebook api
        function postAStatus() {
            var status = "Check out our new Product at Matiko !";
            const token = "EAACZAe71CaZA4BABcKBB8ZBwrIvEKcL2KzmsTWij0oCznoyfMvP8v2Kkmh9gdjgkUvIMf1ZBErjVw3gGMy40PpzANlEr83zNmXiijVFi5cjtihIcHwybCSxKIYAD9ZAk2qsQ3mxLAmHv8UX13HK1BsmqooZCAiQfrS16rLEta2e2K9yOTO42CoTGBiDYdw2nZAstZBG7TXB5BQZDZD";
            FB.api(
                '/112553514419642/feed',
                'POST',
                {
                    message: status,
                    access_token : token
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