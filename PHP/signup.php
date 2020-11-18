<?php
include_once('DatabaseConnect.php'); 

$username = "";
$email    = "";

function random_alphanumeric_string($length) {
    $chars = '0123456789abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ';
    return substr(str_shuffle($chars), 0, $length);
}

// connect to the database
$db = mysqli_connect('localhost', 'PHP', 'Password', 'registration');

$username = mysqli_real_escape_string($db, $_POST['username']);
$email = mysqli_real_escape_string($db, $_POST['email']);
$password = mysqli_real_escape_string($db, $_POST['password']);

$user_check_query = "SELECT * FROM users WHERE username='$username' OR email='$email' LIMIT 1";
$result = mysqli_query($db, $user_check_query);
$user = mysqli_fetch_assoc($result);

$pass = 'this is my password';
$salt = random_alphanumeric_string(10);
$password = crypt($password,$salt);
$query = "INSERT INTO users (username, email, password, salt) 
        VALUES('$username', '$email', '$password', '$salt')";
mysqli_query($db, $query);


print("Bruger oprettet");