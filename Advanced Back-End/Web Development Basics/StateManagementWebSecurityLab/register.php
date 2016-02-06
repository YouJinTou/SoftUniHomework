<?php
require_once 'index.php';

if (isset($_POST['username'], $_POST['password'])) {
    try {
        $user = $_POST['username'];
        $pass = $_POST['password'];
        $app->register($user, $pass);

        if ($app->login($user, $pass)) {
            header("Location: profile.php");
        }
    } catch (Exception $e) {
        echo $e->getMessage();
    }
}

loadTemplate("register");

