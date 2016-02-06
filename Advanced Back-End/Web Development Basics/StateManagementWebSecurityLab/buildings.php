<?php
$buildings = $app->createBuildings();

if (isset($_GET['id'])) {
    $buildings->evolve($_GET['id']);
    header("Location: buildings.php");
    exit;
}

loadTemplate('buildings', $buildings);