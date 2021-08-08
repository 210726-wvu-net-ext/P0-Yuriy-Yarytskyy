#! /usr/bin/bash
# ARRAYS
# plang=('C' 'C++' 'Java' 'C#' 'Python' 'JavaScript')
# plang[60]="Ruby"
# unset plang #[1]
# echo "first element - ${plang[0]}"
# echo "Indexes - ${!plang[@]}"
# echo "All elements - ${plang[@]}"
# echo "Length - ${#plang[@]}"

# string="Pushpinder"
# echo "${string[@]}"
# echo "${#string[@]}"
# echo "${string[0]}"
# echo "${string[1]}"

## LOOPS IN BASH
# WHILE LOOP
# while [condition]
# do
#     statement(s)
# done

# n=1
# #while [ $n -le 10 ]
# while  (($n <= 10)) 
# do
# if [ $(( n%2 )) -eq 0 ]
# then
#    echo "$n"
# fi
#    #n=$(( n+1 ))
#    (( n++ ))
# done

# Until loop
# n=1
# #until [ $n -gt 10 ]
# until (( $n > 10 ))
# do
#     echo $n
#     (( n++ ))
# done

# FOR Loop
#for variable in unix-or-linux-commands
# for (( exp1; exp2; exp3 ))
# do  
#     statement(s)
# done

#for temp in 1 2 3 4 5
# for temp in {1..10..2} #seed, range, increment number
# do
#     echo $temp
# done

# for (( i=0; i<6; i++ ))
# do 
#     echo $i
# done

# for command in date pwd ls $BASH_VERSION $HOME
# do 
#     echo "---------------------$command--------------------"
#     $command
# done

# Select loop
# select variable in list
# do
#     statement(s)
# done

select lang in C C# Java Python Ruby
do
    #echo "$lang has been selected"
    case $lang in
        C)
            echo C programming language has been selected
            break;;
        C#)
            echo C# programming language has been selected
            break;;
        Java)
            echo Java programming language has been selected
            break;;
        Python)
            echo Python programming language has been selected
            break;;
        Ruby)
            echo Ruby programming language has been selected
            break;;
        *)
            echo " Error! Please selected choices between 1 to 5"
    esac
done