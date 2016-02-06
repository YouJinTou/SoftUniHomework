<h1>Buildings</h1>

<h3>
    Resources:
    <p>Gold: <?= $data->getUser()->getGold(); ?></p>
    <p>Food: <?= $data->getUser()->getFood(); ?></p>
</h3>

<table border="1">
    <tr>
        <td>Building name</td>
        <td>Level</td>
        <td>Gold</td>
        <td>Food</td>
        <td>Action</td>
    </tr>
<?php foreach($data->getBuildings() as $building): ?>
    <tr>
        <td><?= $building['name'] ;?></td>
        <td><?= $building['level_id'] ;?></td>
        <td><?= $building['gold']; ?></td>
        <td><?= $building['food']; ?></td>
        <td><a href="?id=<?=$building['id'];?>">Build</a></td>
    </tr>
<?php endforeach; ?>
</table>