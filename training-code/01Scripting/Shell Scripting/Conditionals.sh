#! /usr/bin/bash

# if [condition]
# then
#     statement for  true condition
# fi

# read -p "Enter a number: " number
# #if [ $number -ge 16 ]
# if (( $number > 16 ))
# then 
#     echo 'user is eligible'
# else 
#     echo 'user in not eligible'
# fi

# String comparison
# name="Fred"
# if [ $name = "FRED" ] # compares with ASCII value of strings
# then
#      echo "Its a match"
# fi

# char=a
# if [[ $char == "1" ]]
# then
#     echo 'true'
# else
#     echo 'false'
# fi

# Arithmatic comparison
# read -p "Enter your age: " age
#if [ "$age" -gt 15 ] && [ "$age" -lt 32 ]
# if [ "$age" -gt 15 -a "$age" -lt 32 ]
# if [[ "$age" -gt 15 && "$age" -lt 32 ]]
# then
#     echo "You are eligible to apply for US Defence"
# else
#     echo " Sorry you are not between 16 to 32 age bracket"
# fi

# read -p "Enter your marks: " marks
# if [ "$marks" -gt 100 ]
# then    
#     echo "Invalid marks"
# elif [ "$marks" -lt 0 ]
# then
#     echo "Invalid marks"
# elif [ "$marks" -gt 39 ]
# then 
#     echo 'you pass'
# else
#     echo "you fail"
# fi

#echo $(( 1+1 ))

num1=21
num2=5

# echo $(( num1 + num2 ))
# echo $(( num1 - num2 ))
# echo $(( num1 * num2 ))
# echo $(( num1 / num2 ))
# echo $(( num1 % num2 ))

# echo $(expr $num1 + $num2 )
# echo $(expr $num1 - $num2 )
# echo $(expr $num1 \* $num2 )
# echo $(expr $num1 / $num2 )
# echo $(expr $num1 % $num2 )