<?php require_once 'index.php'; ?>

<?php if (isset($_SESSION['id'])){
    header("Location: profile.php");
    exit;
}
?>

<form method="POST" action="">
    <input type="text" name="username" placeholder="Username" />
    <input type="text" name="password" placeholder="Password" />
    <input type="submit" name="login" value="Login" />
</form>

<?php
if (isset($_POST['login'])){
    $username = ($_POST['username']);
    $password = md5($_POST['password']);   
    
    $loggedUserId = key(array_filter($users, function($user) use ($username, $password){
        return 
            $user['username'] == $username &&
            $user['password'] == $password;
    }));
    
    if ($loggedUserId){
        $_SESSION['id'] = $loggedUserId;
        
        header("Location: profile.php");
        exit;
    }
}



