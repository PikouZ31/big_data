<?php

require("index.php");


$etat = new couchClient($couch_dsn,"datecondicommande");

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


$mysqli = connexion("192.168.0.2","conditionnement","guer","123456");
$requete = "SELECT DATE(`Date_conditionnement`), COUNT( `ID_commande` ) FROM conditionnement GROUP BY DATE(`Date_conditionnement`)";
$resultat = $mysqli->query($requete) or die ('Erreur '.$requete.' '.$mysqli->error());



$n = $resultat->num_rows;


echo $n;

for($i=0;$i<$n;$i++) {

    $ligne = $resultat->fetch_row();


    $doc = new couchDocument($etat);

    $prop = new stdClass();

    $prop->datecondi = $ligne[0];
    $prop->nbcondijour = $ligne[1];


    try{  
        $doc->set ($prop);
    }
    catch (Exception $e) {
    echo "ERROR: ".$e->getMessage()." (".$e->getCode().")<br>\n";
    }


}

echo "Chargement Complet";