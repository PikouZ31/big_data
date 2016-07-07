<?php


require("index.php");


$etat = new couchClient($couch_dsn,"nbprodcom");

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
$requete = "SELECT DATE(Date_livraison_relle), COUNT( Date_livraison_relle ) FROM commande GROUP BY DATE(Date_livraison_relle)";
$resultat = $mysqli->query($requete) or die ('Erreur '.$requete.' '.$mysqli->error());


$n = $resultat->num_rows;






$mysqli = connexion("127.0.0.1","commande","root","");
$requete = "SELECT SUM(contient.Quantite) , DATE(commande.Date_livraison_relle) FROM contient, commande WHERE contient.ID_Commande= commande.ID_Commande GROUP BY DATE(commande.Date_livraison_relle)";
$resultat2 = $mysqli->query($requete) or die ('Erreur '.$requete.' '.$mysqli->error());




for($i=0;$i<$n;$i++) {

    $ligne = $resultat->fetch_row();
    $ligne2 = $resultat2->fetch_row();

    $doc = new couchDocument($etat);
    $prop = new stdClass();
    $prop->datecomjour = $ligne[0];
    $prop->nbcommande = $ligne[1];
    $prop->nbproduit = $ligne2[0];

    try{  
        $doc->set ($prop);
    }
    catch (Exception $e) {
    echo "ERROR: ".$e->getMessage()." (".$e->getCode().")<br>\n";
    }

}

echo "Chargement Complet";