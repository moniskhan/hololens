<?php
$servername = "tommy.heliohost.org";
$username = "user";
$password = "pass";
$dbname = "db";
$conn = new mysqli($servername, $username, $password, $dbname);
if (!$conn) {

	die("Connection Failed " . mysqli_connect_error());
}
$sql = "SELECT name from catalog_table";
$result = mysqli_query($conn ,$sql);
while ($row = mysqli_fetch_assoc($result)) {
	echo "Name:".$row['name'] . ";";
}
?>