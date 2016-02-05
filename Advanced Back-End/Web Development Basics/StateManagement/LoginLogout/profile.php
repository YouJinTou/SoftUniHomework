<?php require_once 'index.php'; ?>
<h1>Welcome <?= $users[$_SESSION['id']]['username'];?></h1> 
<a href="?logout=true">Logout</a>
