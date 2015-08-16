<?php
if (version_compare(phpversion(), '5.4.0', '<')) {
    function  http_response_code ( $response_code  ) {
        header(':', true, $response_code);
    }
}

http_response_code(404);

?>

<!DOCTYPE html>
<!--
 Project: T0515 CMS
 Author: Hau Viet Nguyen (nvconghau1995@gmail.com)
 Copyright: Hau Viet Nguyen
 This Program is not free.
-->
<html>
    <head>
        <title>404 ERROR - Page not found</title>
        <meta charset="UTF-8">
        <meta name="viewport" content="width=device-width, initial-scale=1.0">
    </head>
    <body>
        <h1>404 ERROR</h1>
        <div>The requested URL was not found on this server. If you entered the URL manually please check your spelling and try again.
            <br>If you think this is a server error, please contact the webmaster.</div>
    </body>
</html>
