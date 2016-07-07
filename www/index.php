
<?php
$couch_dsn = "http://localhost:5984/";
### AUTHENTICATED DSN
### $couch_dsn = "http://user:password@localhost:5984/"
$couch_db = "commande";

require_once "/lib/couch.php";
require_once "/lib/couchClient.php";
require_once "/lib/couchDocument.php";

require("menu.php");

