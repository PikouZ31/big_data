

<?php


require("index.php");


$etat = new couchClient($couch_dsn,"chiffredaffaire");
$etat->deleteDatabase();
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
$requete = "SELECT DATE(Date_livraison_relle), SUM( Prix ) FROM commande GROUP BY DATE(Date_livraison_relle)";
$resultat = $mysqli->query($requete) or die ('Erreur '.$requete.' '.$mysqli->error());



$n = $resultat->num_rows;


echo $n;

for($i=0;$i<$n;$i++) {

    $ligne = $resultat->fetch_row();


    $doc = new couchDocument($etat);

    $prop = new stdClass();

    $prop->datechiffre = $ligne[0];
    $prop->prixjour = $ligne[1];

    try{  
        $doc->set ($prop);
    }
    catch (Exception $e) {
    echo "ERROR: ".$e->getMessage()." (".$e->getCode().")<br>\n";
    }


}
echo "Chargement Complet";
?>


<script type="text/javascript">
window.onload = timediff;
</script>