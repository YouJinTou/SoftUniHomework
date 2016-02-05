<?php
session_start();
if (isset($_GET['logout'])){
    session_destroy();
    header("Location: login.php");
    exit;
}

$users = [
    1 => [
        "username" => "ivan",
        "password" => md5("123")
    ],
    2 => [
        "username" => "asen",
        "password" => md5("123")
    ],
    3 => [
        "username" => "peter",
        "password" => md5("123")
    ]
];

$currentPage = basename($_SERVER['PHP_SELF']);
if (!isset($_SESSION['id']) && $currentPage != 'login.php'){
    header("Location: login.php");
    exit;
}