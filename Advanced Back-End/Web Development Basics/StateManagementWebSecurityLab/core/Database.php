<?php
namespace Core;

class Database {
    private static $inst = [];
    private $db;
    
    private function __construct(\PDO $db) {
        $this->db = $db;
    }
    
    private static function getInstance($instanceName = 'default'){
        if (!isset(self::$inst[$instanceName])){
            throw new Exception('Instance with that name has not been set.');
        }
        
        return self::$inst;
    }
    
    public static function setInstance(
        $instanceName,
        $driver,
        $user,
        $pass,
        $dbName,
        $host = null
    ) {
        $driver = DriverFactory::create($driver, $user, $pass, $dbName, $host);

        $pdo = new \PDO(
            $driver->getDsn(),
            $user,
            $pass
        );

        self::$inst[$instanceName] = new self($pdo);
    }
    
    public function prepare($statement, array $driverOptions = [])
    {
        $statement = $this->db->prepare($statement, $driverOptions);

        return new Statement($statement);
    }

    public function query($query)
    {
        $this->db->query($query);
    }

    public function lastId($name = null)
    {
        return $this->db->lastInsertId($name);
    }
}

class Statement {
    private $stmt;
    
    public function __construct(\PDOStatement $stmt) {
        $this->stmt = $stmt;
    }
    
    public function fetch($fetchStyle = \PDO::FETCH_ASSOC)
    {
        return $this->stmt->fetch($fetchStyle);
    }

    public function fetchAll($fetchStyle = \PDO::FETCH_ASSOC)
    {
        return $this->stmt->fetchAll($fetchStyle);
    }

    public function bindParam($parameter, &$variable, $dataType = \PDO::PARAM_STR, $length = null, $driverOptions = null)
    {
        return $this->stmt->bindParam($parameter, $variable, $dataType, $length, $driverOptions);
    }
    
    public function execute(array $inputParameters = null)
    {
        return $this->stmt->execute($inputParameters);
    }
    
    public function rowCount()
    {
        return $this->stmt->rowCount();
    }
}
