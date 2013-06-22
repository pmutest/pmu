

        // Keep access_token return by google after sign in
        // this variable will used during disconnecting from google +
        var access_token;

        (function () {
            var po = document.createElement('script'); po.type = 'text/javascript'; po.async = true;
            po.src = 'https://apis.google.com/js/client:plusone.js';
            var s = document.getElementsByTagName('script')[0]; s.parentNode.insertBefore(po, s);
        })();

        $(document).ready(function () {
            // Could trigger the disconnect on a button click
            $('#revokeButton').click(function () {
                disconnectUser(access_token);
            });

            // Logout / Disconnect from google + sign in 
            function disconnectUser(access_token) {
                var revokeUrl = 'https://accounts.google.com/o/oauth2/revoke?token=' + access_token;

                // Perform an asynchronous GET request.
                $.ajax({
                    type: 'GET',
                    url: revokeUrl,
                    async: false,
                    contentType: "application/json",
                    dataType: 'jsonp',
                    success: function (nullResponse) {
                        // Do something now that user is disconnected
                        // The response is always undefined.
                        //alert("You have log out succesfully....");

                        // This techniqu will used to return back to own site 
                        // After using this user will log out from every where in same browser 
                        // If I don't use this then user will only log out from my application 
                        window.location = "https://www.google.com/accounts/Logout?continue=https://appengine.google.com/_ah/logout?continue=http://localhost:58304/Home.aspx";

                        document.getElementById('signinButton').setAttribute('style', 'display: block');
                        document.getElementById('revokeButton').setAttribute('style', 'display: none');
                    },
                    error: function (e) {
                        // Handle the error
                        // console.log(e);
                        // You could point users to manually disconnect if unsuccessful
                        // https://plus.google.com/apps
                    }
                });
            }

        });

        // Call Back function 
        function signinCallback(authResult) {
            if (authResult['access_token']) {
                access_token = authResult['access_token'];
                // Successfully authorized
                // Hide the sign-in button now that the user is authorized, for example:
                document.getElementById('signinButton').setAttribute('style', 'display: none');
                document.getElementById('revokeButton').setAttribute('style', 'display: block');
                getEmail();  // Triger the request to get email address
                getProfileInfo(); // Triger the request to get the user name and profile pic
            } else if (authResult['error']) {
                // There was an error.
                // Possible error codes:
                //   "access_denied" - User denied access to your app
                //   "immediate_failed" - Could not automatically log in the user
                // console.log('There was an error: ' + authResult['error']);
            }
        }

        function getProfileInfo() {

            var getProfileInfo = 'https://www.googleapis.com/oauth2/v1/userinfo?alt=json&access_token=' + access_token;

            // Perform an asynchronous GET request.
            $.ajax({
                type: 'GET',
                url: getProfileInfo,
                async: false,
                contentType: "application/json",
                dataType: 'jsonp',
                success: function (objInfo) {
                    var key = Object.keys(objInfo);
                    alert(objInfo["email"]);
                    //id,email,verified_email,name,given_name,family_name,link,picture,gender,birthday,locale
                    // Do something now that user is disconnected
                    // The response is always undefined.
                    //alert("You have log out succesfully....");

                    // This techniqu will used to return back to own site 
                    // After using this user will log out from every where in same browser 
                    // If I don't use this then user will only log out from my application 
                },
                error: function (e) {
                    // Handle the error
                    // console.log(e);
                    // You could point users to manually disconnect if unsuccessful
                    // https://plus.google.com/apps
                }
            });
        }

        function getEmail() {
            // Load the oauth2 libraries to enable the userinfo methods.
            gapi.client.load('oauth2', 'v2', function () {
                var request = gapi.client.oauth2.userinfo.get();
                request.execute(getEmailCallback);
            });
        }

        function getEmailCallback(obj) {
            //var keys = Object.keys(obj);
            //alert(obj['id'])
             var el = document.getElementById('email');
             var email = '';

             if (obj['email']) {
                 email = 'Email: ' + obj['email'];
                 //alert(email);
             }
        }