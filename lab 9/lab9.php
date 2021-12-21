<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>Interactive HTML Form</title>
    <link rel="stylesheet" href="styles.css">
</head>
<body>
    <form method="post" id="registration-form">
        <h1 class="registration-title">Registration form</h1>
        <label for="username">Username</label>
        <input type="text" name="username" id="username" name="username">
        <input type="text" id="isCorrectUsername" name="isCorrectUsername" hidden>
        <label for="password">Password</label>
        <input type="password" name="password" id="password" name="password">
        <input type="text" id="isCorrectPassword"  name="isCorrectPassword" hidden>
        <label for="country">Country</label>
        <input type="text" name="country" id="country">
        <label for="city">City</label>
        <input type="text" name="city" id="city">
        <input type="submit" value="Sign up" id="btn" name="submit">
        <p class="validate-username" id="unique">Username is unique</p>
        <p class="validate-password" id="general-validate">Password must contain at least:</p>
        <ul>
            <li class="validate-password" id="8chars"></li>
            <li class="validate-password" id="1upper"></li>
        </ul>
        <div id="users"></div>
    </form>
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.6.0/jquery.min.js"></script>
    <script src="http://www.geoplugin.net/javascript.gp" type="text/javascript"></script>
    <script src="validatePassword.js"></script>
    <script src="validateUsername.js"></script>
    <script src="gettingLocation.js"></script>

    <?php
        if(isset($_POST['submit']))
        {
            $temp = file_get_contents("log.xml");
            $list = new SimpleXMLElement($temp);
            $array = array();
            $isCorrectPassword = ($_POST['isCorrectPassword']);
            $isCorrectUsername = ($_POST['isCorrectUsername']);
            $row = ($_POST['username']) . ' - Is correct username: ' . $isCorrectUsername . '; Is correct password: ' . $isCorrectPassword. '; Time: ' . date("Y-m-d H:i:s");
            foreach ($list->validation as $result) {
                array_push($array, (string)$result);
            }
            array_push($array, $row);
            $finalXml = "<list>\n";
            for ($i = 0; $i < count($array); $i++) {
                $finalXml .= "<validation>" . $array[$i] . "</validation>\n";
            }
            $finalXml .= "</list>";
            $xml = fopen('log.xml', 'w');
            fwrite($xml, $finalXml);
            fclose($xml);
        }
    ?>
</body>
</html>