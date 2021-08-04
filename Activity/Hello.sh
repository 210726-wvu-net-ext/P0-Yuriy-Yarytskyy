#! /usr/bin/bash

#promp will ask to input 3 favourite movies
echo "Please enter top 3 movies of yours"
#takes input into an array
read -a movies
#prints out massage with an array
echo "You have entered: ${movies[0]}, ${movies[1]}, ${movies[2]}"
