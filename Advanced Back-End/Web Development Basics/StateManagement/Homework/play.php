<?php
session_start();
require_once 'logic.php';

if (!isset($_SESSION['user'])){
    header("Location: index.php");
    exit;
}
?>  

<?php if($_SESSION['flag'] == false): ?>
<form method="POST" action="play.php">
    <input type="number" name="number-field" min="1" max="100"
           placeholder="Your guess" />
    <input type="submit" name="submit-number" value="Send" />
</form>
<?php else: ?>
<a href="index.php">Play again</a>
<?php endif; ?>