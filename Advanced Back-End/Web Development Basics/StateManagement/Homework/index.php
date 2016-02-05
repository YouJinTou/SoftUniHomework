<?php
session_start();
require_once 'logic.php';

$_SESSION['user'] = null;
$_SESSION['secretNumber'] = null;
$_SESSION['flag'] = false;
?>
<form method="POST" action="play.php">
    <input type="text" name="username" placeholder="Username" />
    <input type="submit" name="start" value="Begin" />
</form>