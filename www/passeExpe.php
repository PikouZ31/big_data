<?php

require("index.php");


$etat = new couchClient($couch_dsn,"etat");

if ( $etat->databaseExists() ) {

    $etat->deleteDatabase();
}

    $etat->createDatabase();

function connexion($serveur,$base,$user,$pass)
{

$mysqli = new mysqli($serveur, $user, $pass, $base);
if ($mysqli->connect_error) {
    die('Erreur de connexion ('.$mysqli->connect_errno.')'. $mysqli->connect_error);
}
 return $mysqli;
}


$mysqli = connexion("127.0.0.1","commande","root","");
$requete = "SELECT COUNT(`ID_Etat`) FROM `etat` WHERE `Etat` = 'Terminer'";
$resultat = $mysqli->query($requete) or die ('Erreur '.$requete.' '.$mysqli->error());



$n = $resultat->num_rows;


echo $n;

for($i=0;$i<$n;$i++) {

    $ligne = $resultat->fetch_row();


    $doc = new couchDocument($etat);

    $prop = new stdClass();

    $prop->idetat = $ligne[0];
    $prop->etat = $ligne[1];

    try{  
        $doc->set ($prop);
    }
    catch (Exception $e) {
    echo "ERROR: ".$e->getMessage()." (".$e->getCode().")<br>\n";
    }


}

echo "Chargement Complet";