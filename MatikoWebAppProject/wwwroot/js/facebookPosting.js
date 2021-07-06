

        // Post using facebook api
        function postAStatus() {
            var status = "Check out our new Product at Matiko !";
            const token = "EAACZAe71CaZA4BAEIrOfsnwM0VIvPoWmjaUTjkXXhvTW52b52dDh5oILAr4c0dzINuqvvdYiFVfP3Rtsoz4LZAw2UxCP888YJ2xJesvneduhCSZApiDVYCgmBD7qs7oMfyvztN2L6QCG52VfCVVeEVICOHAZBK2tE9MZCOw5d264b0osdnUByy5DWT8JmHt69TbyuxF1pAxgZDZD";
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