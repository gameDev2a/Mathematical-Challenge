<?php
include_once 'scoreFunctions.php';
include_once 'dbFunctions.php';



if(!isset($_GET["action"])){
    $action = 'defaultIndexPage';
} else {
    $action = $_GET["action"];
}
//die($action);
switch ($action) {
    case 'get':
        getPlayer();
        break;
    case 'set':
        setPlayer();
        break;
    case 'html':
        toHTML();
        break;
    case 'xml':
        toXML();
        break;
    case 'reset':
        resetDatabase();
        break;
    case 'getPerformance':
        getPerformance("matt");
        break;

    case 'defaultIndexPage':
        include_once 'htmlDefault.php';
        print $htmlDefaultPage;
        break;

    default:
        print 'Error - unknown value for "action" parameter';
}

print '<br>';
print '<a href="index.php">index</a>';