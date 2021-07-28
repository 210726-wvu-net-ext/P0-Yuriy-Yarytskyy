#! /usr/bin/bash

#promp will ask to input 3 favourite movies
echo "Please enter top 3 movies of yours"
read -a movies
echo "You have entered: ${movies[0]}, ${movies[1]}, ${movies[2]}"
