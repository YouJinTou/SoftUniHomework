<?php
namespace Core;

class BuildingsRepository {
    private $db;
    private $user;

    public function __construct(Database $db, User $user)
    {
        $this->db = $db;
        $this->user = $user;
    }
    
    public function getBuildings()
    {
        $result = $this->db->prepare("
            SELECT
                b.id,
                b.name,
                ub.level_id,
                bl.gold,
                bl.food
            FROM buildings b
            INNER JOIN building_levels bl
            ON b.id = bl.buildings_id
            INNER JOIN user_buildings ub
            ON ub.building_id = bl.buildings_id
            AND ub.level_id + 1 = bl.level
            WHERE ub.user_id = ?
        ");

        $result->execute([$this->user->getId()]);

        return $result->fetchAll();
    }
    
    public function getCost($buildingId)
    {
        $result = $this->db->prepare("SELECT
                b.id,
                b.name,
                ub.level_id,
                bl.gold,
                bl.food
            FROM buildings b
            INNER JOIN building_levels bl
            ON b.id = bl.buildings_id
            INNER JOIN user_buildings ub
            ON ub.building_id = bl.buildings_id
            AND ub.level_id + 1 = bl.level
            WHERE ub.user_id = ? AND ub.building_id = ?
        ");

        $result->execute(
            [
                $this->user->getId(), $buildingId
            ]
        );

        return $result->fetch();
    }
    
    public function getMaxLevel($buildingId)
    {
        $result = $this->db->prepare("
          SELECT
            MAX(level) AS 'max_level'
          FROM
            building_levels
          WHERE
            buildings_id = ?
        ");

        $result->execute([$buildingId]);

        return $result->
    }
    
    public function evolve($buildingId)
    {
        $cost = $this->getCost($buildingId);
        if ($cost['gold'] > $this->getUser()->getGold() ||
            $cost['food'] > $this->getUser()->getFood()
        ) {
            throw new \Exception('Insufficient resources');
        }

        if ($cost['level_id'] >= $this->getMaxLevel($buildingId)) {
            throw new \Exception('Max level reached');
        }

        $resourceUpdate = $this->db->prepare("
            UPDATE users SET food = food - ?, gold = gold - ?
            WHERE id = ?
        ");
        $resourceUpdate->execute(
            [
                $cost['food'],
                $cost['gold'],
                $this->user->getId()
            ]
        );

        if ($resourceUpdate->rowCount() > 0) {
            $levelUp = $this->db->prepare("
                UPDATE user_buildings
                SET level_id = level_id + 1
                WHERE building_id = ?
                AND user_id = ?
            ");

            $levelUp->execute([
                $buildingId,
                $this->user->getId()
            ]);

            return $levelUp->rowCount() > 0;
        }

        throw new \Exception('Cannot level up');
    }
}
