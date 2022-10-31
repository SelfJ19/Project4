////////////////////////////////////////////////////////////////////////////////////////////////////////
//
// Project: Project 4 MP3 Tracker with Files
// File Name: MPThreeDriver.cs
// Description: Demonstrate the functionality of the MPThree class
// Course: CSCI 1260-001 – Introduction to Computer Science II
// Author: Jason Self, selfj1@etsu.edu, East Tennessee State University
// Created: 9/6/2022
// Updated: 10/30/2022
// Copyright: Jason Self, 2022
//
////////////////////////////////////////////////////////////////////////////////////////////////////////
using System;
using MPThreeClass;
using Project3;

/// <summary>
/// This is the beginning of the MpThree Driver class
/// </summary>
public class MPThreeDriver
{
    #region Main()
    /// <summary>
    /// This is the main method of the driver class
    /// </summary>
    public static void Main()
    {
        Console.WriteLine("This program implements an MP3 class and demonstrates its functionality with a driver class." + '\n' + "Written by:\tJason Self\n");

        Menu();
    }
    #endregion

    #region Menu()
    /// <summary>
    /// This is the menu method of the driver class
    /// </summary>
    public static void Menu()
    {
        Console.Write("What is your name? ");
        string userName = Console.ReadLine();
        string userInput;
        bool inputValidation = false;
        Playlist playlist = null;
        /// <summary>
        /// This is the do-while loop that iterates with the menu based on the users options
        /// </summary>
        do
        {
            userInput = DisplayMenu();

            switch (userInput)
            {
                #region Case1
                case "1":
                    playlist = new Playlist();
                    Console.Write("What is the name of your playlist? ");
                    playlist.NameOfPlaylist = Console.ReadLine();
                    Console.Write("Who is the creator of this playlist? ");
                    playlist.CreatorOfPlaylist = Console.ReadLine();
                    Console.Write("What is the date this playlist is created? Use the following format (MM/DD/YYYY): ");
                    playlist.CreationDate = Console.ReadLine();

                    // Loop that will always run if the user's input  is y for yes if it is n for no it will stop 
                    do
                    {
                        MPThree mpthrees = NewMPThree();
                        playlist.Add(mpthrees);
                        Console.Write("Do you want to add more songs (Y/N)? ");
                        Console.WriteLine();
                        userInput = Console.ReadLine().ToUpper();

                        if (userInput == "Y")
                        {
                            inputValidation = true;
                        }
                        else
                        {
                            inputValidation = false;
                        }
                    } while (inputValidation == true);

                break;
                #endregion

                #region Case2
                case "2":
                    if (playlist == null)
                    {
                        Console.WriteLine("Playlist is empty. Please create one.");
                    }
                    else
                    {
                        MPThree newMP3 = NewMPThree();
                        playlist.Add(newMP3);
                    }                                       
                    break;
                #endregion

                #region Case3
                case "3":
                    if (playlist == null)
                    {
                        Console.WriteLine("Playlist is empty. Please create one.");
                    }
                    else
                    {
                        Console.Write("Which song from the playlist would you like to edit? Please enter the song number. (ex. 1, 2, 3, ...)\n");
                        Console.WriteLine(playlist);
                        int index = Int32.Parse(Console.ReadLine());
                        MPThree newMP3 = NewMPThree();
                        playlist.Edit(index, newMP3);
                    }              
                    break;
                #endregion

                #region Case4
                case "4":
                    if(playlist == null)
                    {
                        Console.WriteLine("Playlist is empty. Please create one.");
                    }
                    else
                    {
                        Console.Write("What MP3 would you like to remove from the Playlist? Please enter the song number.(ex. 1, 2, 3, ...)\n");
                        Console.WriteLine(playlist);
                        int index = Int32.Parse(Console.ReadLine());
                        playlist.Drop(index);
                    }                    
                    break;
                #endregion

                #region Case5
                case "5":
                    if (playlist == null)
                    {
                        Console.WriteLine("Playlist is empty. Please create one.");
                    }
                    else
                    {
                        Console.WriteLine(playlist);
                    }
                    break;
                #endregion

                #region Case6
                case "6":
                    if (playlist == null)
                    {
                        Console.WriteLine("Playlist is empty. Please create one.");
                    }
                    else
                    {
                        Console.Write("What song would you like to display? Please enter the Song Name: ");
                        string titleSearch = Console.ReadLine();
                        playlist.SearchByTitle(titleSearch);
                        if(playlist.SearchByTitle(titleSearch) == null)
                        {
                            Console.WriteLine("Song not found");
                        }
                        else
                        {
                            Console.WriteLine(playlist.SearchByTitle(titleSearch));
                        }
                    }                    
                    break;
                #endregion

                #region Case7
                case "7":
                    if (playlist == null)
                    {
                        Console.WriteLine("Playlist is empty. Please create one.");
                    }
                    else
                    {
                        Console.Write("What genre of music would you like to see from the Playlist? ");
                        string genre = Console.ReadLine();
                        Genre userGenre = (Genre)Enum.Parse(typeof(Genre), genre);
                        playlist.SearchByGenre(userGenre);
                        
                        // If the genre the user enters is in the playlist it will not be null and the foreach loop will display all mp3's that are of that genre. Else return there were no songs found of that genre
                        if (playlist.SearchByGenre(userGenre) != null)
                        {
                            Console.WriteLine($"The MP3's of that genre are: \n");
                            foreach(MPThree mPThree in playlist.SearchByGenre(userGenre))
                                Console.WriteLine(mPThree);                    
                        }
                        else
                        {
                            Console.WriteLine("There were no songs found of that genre.");
                        }
                    }                    
                    break;
                #endregion

                #region Case8
                case "8":
                    if (playlist == null)
                    {
                        Console.WriteLine("Playlist is empty. Please create one.");
                    }
                    else
                    {
                        Console.WriteLine("Which artist would you like to display songs by?");
                        string artistName = Console.ReadLine();                       
                        playlist.SearchByArtist(artistName);

                        // If the artist the user enters is in the playlist it will not be null and the foreach loop will display all mp3's that are by that artist. Else return there were no songs found by that artist
                        if (playlist.SearchByArtist(artistName) != null)
                        {
                            Console.WriteLine($"The MP3's by that artist are: \n");
                            foreach (MPThree mPThree in playlist.SearchByArtist(artistName))
                                Console.WriteLine(mPThree);
                        }
                        else
                        {
                            Console.WriteLine("There were no songs found by that artist.");
                        }
                }                    
                    break;
                #endregion

                #region Case9
                case "9":
                    if (playlist == null)
                    {
                        Console.WriteLine("Playlist is empty. Please create one.");
                    }
                    else
                    {
                        Console.WriteLine("The songs in the Playlist sorted by Title:");
                        playlist.SortByTitle();
                        Console.WriteLine(playlist);
                    }
                    break;                    
                #endregion

                #region Case10
                case "10":
                    if (playlist == null)
                    {
                        Console.WriteLine("Playlist is empty. Please create one.");
                    }
                    else
                    {
                        Console.WriteLine("The songs in the Playlist sorted by Release Date are:");
                        playlist.SortByDate();
                        Console.WriteLine(playlist);
                    }                    
                    break;
                #endregion

                #region Case11
                case "11":
                    Console.WriteLine($"Goodbye. Thank you! {userName}");
                    break;

                default:
                    Console.WriteLine("Please enter a valid option from the menu.");
                    break;
                #endregion
            }
        } while (userInput != "11");
    }
    #endregion

    #region DisplayMenu()
    /// <summary>
    /// This is the display menu that stores the menu printout and stores the user input and returns it
    /// </summary>
    /// <returns>userInput for Menu Option</returns>
    private static string DisplayMenu()
    {
        string userInput;
        Console.WriteLine("\nMenu:");
        Console.WriteLine("-----");
        Console.WriteLine("1. Create a new Playlist of MP3's");
        Console.WriteLine("2. Create a new MP3 and add it to the Playlist");
        Console.WriteLine("3. Edit an MP3 from the Playlist");
        Console.WriteLine("4. Drop an MP3 from the Playlist");
        Console.WriteLine("5. Display all MP3's in the Playlist");
        Console.WriteLine("6. Search for an MP3 in the Playlist by song title");
        Console.WriteLine("7. Display all MP3's in the Playlist of a specific Genre");
        Console.WriteLine("8. Display all MP3's in the Playlist with a specific artist");
        Console.WriteLine("9. Sort the MP3's in the Playlist by song title");
        Console.WriteLine("10. Sort the MP3's in the Playlist by song release date");
        Console.WriteLine("11. End the Program");
        Console.WriteLine("Please type the number of your choice: ");
        userInput = Console.ReadLine();
        return userInput;
    }
    #endregion

    #region NewMP3()
    /// <summary>
    /// This is the new mp3 method that allows the user to answer the prompts and stores them in the parameterized method and returns the song info
    /// </summary>
    /// <returns>songInfo based on user input and makes a new MPThree() using user input</returns>
    private static MPThree NewMPThree()
    {
        MPThree songInfo;
        Genre userInput2;
        int genre;
        
        // Loop that changes the genre entered by the user into an int and keeps looping if it is below 1 or greater than or equal to 7 so the user must enter a valid genre option. If it is below 1 or greater than or equal to 7 it will display the error message.
        do
        {
            Console.WriteLine("What is the Genre of your mp3?");
            Console.Write("Pick from the following options: ");
            Console.WriteLine("\n1-Rock\n2-Pop\n3-Jazz\n4-Country\n5-Classical\n6-Other");
            string Genre = Console.ReadLine();
            userInput2 = (Genre)Enum.Parse(typeof(Genre), Genre);
            genre = Int32.Parse(Genre);
            if(genre < 1 || genre >= 7)
            {
                Console.WriteLine("\nPlease select a valid option:\n");
            }
        } while (genre < 1 || genre >= 7);      
        
        Console.Write("What is your mp3 title? ");
        string MpthreeTitle = Console.ReadLine();
        Console.Write("Who is the artist? ");
        string Artist = Console.ReadLine();
        Console.Write("What is the release date of your mp3? Use the following format (MM/DD/YYYY): ");
        string releaseDate = Console.ReadLine();
        DateOnly Date = DateOnly.Parse(releaseDate);
        Console.Write("How long is your mp3? ");
        double SongPlaytime = Double.Parse(Console.ReadLine());
        Console.Write("How much does it cost to download? ");
        decimal DownloadCost = Decimal.Parse(Console.ReadLine());
        Console.Write("What is the file size of your mp3? ");
        double FileSize = Double.Parse(Console.ReadLine());
        Console.Write("What is the path of your mp3? ");
        string Path = Console.ReadLine();

        songInfo = new MPThree(userInput2, MpthreeTitle, Artist, Date, SongPlaytime, DownloadCost, FileSize, Path);
        return songInfo;
    }
    #endregion
}