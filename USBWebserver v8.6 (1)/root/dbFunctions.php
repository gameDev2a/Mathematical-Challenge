<?php
        $action = isset($_REQUEST['action']) ? $_REQUEST['action'] : null;
        $playerName = isset($_REQUEST['playerName']) ? $_REQUEST['playerName'] : null;
        $score = isset($_REQUEST['score']) ? $_REQUEST['score'] : 0;
        $addition = isset($_REQUEST['addition']) ? $_REQUEST['addition'] : 0;
        $substraction = isset($_REQUEST['substraction']) ? $_REQUEST['substraction'] : 0;
        $multiplication = isset($_REQUEST['multiplication']) ? $_REQUEST['multiplication'] : 0;
        if ($action != null){
            
            if($action == 'insertPerformance'){
                insertPerformance($playerName, $score, $addition, $substraction, $multiplication);
            }else if($action == 'getPerformance'){
                getPerformance($playerName);
            }
        
        }
    

function open_database_connection() {
    // DB connection details
    $username = 'root';
    $password = 'usbw';
    $host = 'localhost';
    $db = 'cookbook_highscores';

    // try to connect to DB
    $connection = mysqli_connect($host, $username, $password, $db);

    // check connection successful
    // redirect with message to error page
    if (mysqli_connect_errno()) {
        $errorMessage = 'DB connection failed: '.mysqli_connect_error();
        die($errorMessage);
    }
    return $connection;
}

function close_database_connection($connection)
{
    mysqli_close($connection);
}

function getScoreByPlayerName($playerName){
    $connection=open_database_connection();
//	$score = getScoreByPlayerName($playerName);
    $query = "select * from cookbook_highscores WHERE player='$playerName'";
//	die($query);
    if($result = mysqli_query($connection,$query)){
        if($row = mysqli_fetch_assoc($result)){
            $score = $row['score'];
        }
    } else {
        $errorMessage = 'Query failed:'.$query;
        die($errorMessage);
    }
    close_database_connection($connection);
    return null;//$score;
}

function getIdByPlayerName($playerName){
    $id = null;

    $connection=open_database_connection();
    $query = "select * from cookbook_highscores WHERE player='$playerName'";
    if($result = mysqli_query($connection,$query)){
        if($row = mysqli_fetch_assoc($result)){
            $id = $row['id'];
        }
    } else {
        $errorMessage = 'Query failed:'.$query;
        die($errorMessage);
    }
    return $id;
}

function setScoreByPlayerName($playerName, $newScore){
    $connection = open_database_connection();

    $oldScore = getScoreByPlayerName($playerName);
    $playerId = getIdByPlayerName($playerName);

    $shouldUpdate = $newScore > $oldScore;

    if($shouldUpdate){
        //---------
        // update score //
        $query = "UPDATE cookbook_highscores SET score=$newScore WHERE id=$playerId";

        mysqli_query($connection, $query);
        $numAffectedRows = mysqli_affected_rows($connection);
        close_database_connection($connection);
        return ($numAffectedRows > 0);
    } else {
        close_database_connection($connection);
        return false;
    }
}


function insertPerformance($playerName, $score, $addition, $substraction, $multiplication)
{
    
    $connection = open_database_connection();
    $query = "select * from cookbook_highscores WHERE player='$playerName'";
    $result = mysqli_query($connection,$query);
    if(!$result){
        $oldValue = getScoreByPlayerName($playerName);
        $newValue = $oldValue + $score;
        $query = "UPDATE cookbook_highscores SET score=$newValue, scoreAddition=$addition, scoreSubstraction=$substraction, scoreMultiplication=$multiplication  WHERE player='$playerName'";
        mysqli_query($connection, $query);
        close_database_connection($connection);
        print("update");
    } else {
        $query = "INSERT INTO cookbook_highscores(player, score, scoreAddition, scoreSubstraction, scoreMultiplication) VALUES ('$playerName',$score, $addition, $substraction, $multiplication)";
        mysqli_query($connection, $query);
        close_database_connection($connection);
        print("insert");
    }
}
function getPerformance($playerName)
{
    $currentScoreAddition = null;
    $currentScoreSubstraction = null;
    $currentScoreMultiplication = null;
    $connection=open_database_connection();
    $query = "select * from cookbook_highscores WHERE player='$playerName'";
    if($result = mysqli_query($connection,$query)){
        if($row = mysqli_fetch_assoc($result)){
        
                $currentScore = $row['score'];
                $currentScoreAddition = $row['scoreAddition'];
                $currentScoreSubstraction = $row['scoreSubstraction'];
                $currentScoreMultiplication = $row['scoreMultiplication'];
        }
    }
    $resultStr = $playerName." , "+$currentScore." , ".$currentScoreAddition." , ".$currentScoreSubstraction." , ".$currentScoreMultiplication;
    
    print($resultStr);
}