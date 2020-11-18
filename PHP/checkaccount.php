<?php
include_once('DatabaseConnect.php'); 

$username = "";
$email    = "";


$sql = "SELECT * FROM `users` WHERE `username`= '".$_POST['username']."'";
$result = $db->query($sql);
$row = $result->fetch_assoc();

if(crypt($_POST['password_1'],$row[salt]) == $row[password]){
    print("<p style='font-size: 100px;'>"."Velkommen ".$_POST['username']."<p>");
} else {
    print("<p style='font-size: 100px;'>Invalid login!<p>");

}