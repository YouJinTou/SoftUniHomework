<?php
if (!isset($_SESSION['secretNumber'])){
        $_SESSION['user'] = $_POST['username'];
        $_SESSION['secretNumber'] = rand(1, 100);
    }    
    
if (isset($_POST['submit-number'])){
    $userNumber = $_POST['number-field'];   
    if ($userNumber < $_SESSION['secretNumber']){
        echo 'Up';
    } else if ($userNumber > $_SESSION['secretNumber']){
        echo 'Down';
    } else{
        $_SESSION['flag'] = true;
        echo 'Congratulations, ' . $_SESSION['user'] . '!';        
    }
}