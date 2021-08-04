#! /usr/bin/bash

#Yuriy Yarytskyy
#7/29/21

#TASK_1:
#w.a.p. to check if the number entered is an even or odd number.

#ANSWER:

read -p "Please enter a number which you want to check: " number
if (( $(( number%2 )) == 0 ))
then 
    echo "Number you have entered is an even number."
else
    echo "Number you have entered is an odd number."
fi


#TASK_2:
#If marks below 40, grade is F; if mark is between 41-50, grade is D, 
#if mark is between 51-60, grade is C; if mark is between 61-70,
#grade is B and if mark is greater than 70 grade is A.\

#ANSWER:

read -p "Enter your mark: " mark
if [ "$mark" -gt 70 ] && [ "$mark" -lt 101 ]
then    
    echo "Your grade is 'A'."
elif [ "$mark" -gt 60 ] && [ "$mark" -lt 71 ]
then
    echo "Your grade is 'B'."
elif [ "$mark" -gt 50 ] && [ "$mark" -lt 61 ]
then 
    echo "Your grade is 'C'."
elif [ "$mark" -gt 40 ] && [ "$mark" -lt 51 ]
then 
    echo "Your grade is 'D'."
else
    echo "YOUR GRADE IS 'F' AND YOU HAVE FAILED!"
fi