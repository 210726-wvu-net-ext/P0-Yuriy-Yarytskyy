#! /usr/bin/bash

# echo "Enter the names : "
# read name # command to take input from the user and save its value in a variable
# read name1 name2 name3 # take multi values from user
# echo "The entered names are - $name1, $name2, $name3"

# read -p 'Username: ' username
# read -sp 'Password: ' password
# echo
# echo "username is $username"
# echo "Password is $password"

# Arrays
# echo "Enter the names: "
# read -a names
# echo "The names are: ${names[0]}, ${names[1]}"

# echo "enter names"
# read
# echo "names : $REPLY"

# Arguments
echo $0 $1 $2 $3 '> echo $0 $1 $2 $3'

args=("$@")

# echo ${args[0]} ${args[1]} ${args[2]}

echo 'The argurments passed are: ' $@

echo 'The number of arguments passed is ' $#