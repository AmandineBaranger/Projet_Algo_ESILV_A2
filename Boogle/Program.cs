// See https://aka.ms/new-console-template for more informationusing System;

using Boogle;

class Program
{
    static void Main()
    {
        // Create a 6-element array to store the characters 
        char[] charArray = new char[6];
        // Initialize the array with some characters 
        charArray[0] = 'a'; 
        charArray[1] = 'b'; 
        charArray[2] = 'c'; 
        charArray[3] = 'd'; 
        charArray[4] = 'e'; 
        charArray[5] = 'f';

        De new_de = new De(charArray) ;
        Console.Write("Hellowordl \n");
        Console.Write(new_de.toString());

    }
}

