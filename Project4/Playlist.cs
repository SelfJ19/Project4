////////////////////////////////////////////////////////////////////////////////////////////////////////
//
// Project: Project 4 MP3 Tracker with Files
// File Name: Playlist.cs
// Description: Stores the MPThrees user created in a List
// Course: CSCI 1260-001 – Introduction to Computer Science II
// Author: Jason Self, selfj1@etsu.edu, East Tennessee State University
// Created: 9/6/2022
// Updated: 10/30/2022
// Copyright: Jason Self, 2022
//
////////////////////////////////////////////////////////////////////////////////////////////////////////
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using MPThreeClass;

namespace Project3
{
    /// <summary>
    /// Creates the Playlist class
    /// </summary>
    public class Playlist
    {
        #region Attributes
        /// <summary>
        /// Attributes - data that belongs to and describes an object of the class
        /// </summary>
        private List<MPThree> MPThrees { get; set; }
        public string NameOfPlaylist { get; set; }
        public string CreatorOfPlaylist { get; set; }
        public string CreationDate { get; set; }
        public bool SaveNeeded { get; set; }
        #endregion

        #region Default()
        /// <summary>
        /// default constructor: sets attributes to default values
        /// </summary>
        public Playlist()
        {
            MPThrees = new List<MPThree>();
            NameOfPlaylist = "Default";
            CreatorOfPlaylist = "Default";
            CreationDate = "Default";
        }
        #endregion

        #region Copy()
        /// <summary>
        /// copy constructor
        /// </summary>
        /// <param name="existingPlaylist">uses existing playlist to make a copy</param>
        public Playlist(Playlist existingPlaylist)
        {
            List<MPThree> MPThrees = new List<MPThree>();
            MPThrees = existingPlaylist.MPThrees;
            NameOfPlaylist = existingPlaylist.NameOfPlaylist;
            CreatorOfPlaylist = existingPlaylist.CreatorOfPlaylist;
            CreationDate = existingPlaylist.CreationDate;
        }
        #endregion

        #region Parameterized()
        /// <summary>
        /// Parameterized Constructor
        /// </summary>
        /// <param name="MPThrees">MPThrees to be added to playlist</param>
        /// <param name="NameOfPlaylist">sets the name of the playlist</param>
        /// <param name="CreatorOfPlaylist">sets the name of the creator</param>
        /// <param name="CreationDate">sets the date the playlist was created</param>
        public Playlist(List<MPThree> MPThrees, string NameOfPlaylist, string CreatorOfPlaylist, string CreationDate)
        {
            this.MPThrees = new List<MPThree>(MPThrees);
            this.NameOfPlaylist = NameOfPlaylist;
            this.CreatorOfPlaylist = CreatorOfPlaylist;
            this.CreationDate = CreationDate;
        }
        #endregion

        #region SearchBySongTitle()
        /// <summary>
        /// Creates the Search by song method to search for a song in the List based on users input 
        /// </summary>
        /// <param name="titleSearch">title to be searched for in the List</param>
        /// <returns>the song that was found or null if not found</returns>
        public MPThree SearchByTitle(string titleSearch)
        {
            // loop that searches for the song title based on the users input in the driver and returns it, if it is not found returns null
            for(int i = 0; i < MPThrees.Count; i++)
            {
                if (MPThrees[i].MpthreeTitle == titleSearch)
                {
                    return MPThrees[i];
                }
            }
            return null;
        }
        #endregion

        #region SearchingByGenre()
        /// <summary>
        /// Creates the Search by genre method to search for a song/songs in the List based on users input
        /// </summary>
        /// <param name="genre">genre to be searched for in the List</param>
        /// <returns>the song/songs found using genre or null if not found</returns>
        public List<MPThree> SearchByGenre(Genre searchGenre)
        {
            // loop that searches for the song genre based on the users input in the driver stores it in a new List and returns the List
            List<MPThree> foundMPThrees = new List<MPThree>();
            for (int i = 0; i < MPThrees.Count; i++)
            {
                if (MPThrees[i].Genre == searchGenre)
                {
                    foundMPThrees.Add(MPThrees[i]);
                }
            }
            return foundMPThrees;
        }
        #endregion

        #region SearchByArtist()
        /// <summary>
        /// creates the Search by artist method
        /// </summary>
        /// <param name="artist">artist to search for in the List</param>
        /// <returns>the artist that was found in the List or null if artist doesn't exist</returns>
        public List<MPThree> SearchByArtist(string artist)
        {
            // loop that searches for the song artist based on the users input in the driver stores it in a new List and returns the List
            List<MPThree> foundMPThrees = new List<MPThree>();
            for (int i = 0; i < MPThrees.Count; i++)
            {
                if (MPThrees[i].Artist == artist)
                {
                    foundMPThrees.Add(MPThrees[i]);
                }
            }
            return foundMPThrees;
        }

        #endregion

        #region SortingByTitle()
        /// <summary>
        /// creates the SortByTitle method
        /// </summary>
        public void SortByTitle()
        {
            // Mr. Gillenwater helped me :P
            // A lambda expression is used to create an anonymous function. Creates a Sort method that uses x and y as input parameters with a lambda declaration operator to        separaate the lambda's parameter list from its body. The body is using the CompareTo to compare the MpthreeTitle to sort them.
            MPThrees.Sort((x, y) => x.MpthreeTitle.CompareTo(y.MpthreeTitle));
        }
        #endregion

        #region SortingByReleaseDate()
        /// <summary>
        /// creates the SortByDate method
        /// </summary>
        public void SortByDate()
        {
            //A lambda expression is used to create an anonymous function. Creates a Sort method that uses x and y as input parameters with a lambda declaration operator to separaate the lambda's parameter list from its body. The body is using the CompareTo to compare the Dates to sort them.
            MPThrees.Sort((x, y) => x.Date.CompareTo(y.Date));
        }
        #endregion

        #region Adding()
        /// <summary>
        /// Creates the Add method
        /// </summary>
        /// <param name="newMP3">MPThree to be added to the playlist</param>
        public void Add(MPThree newMP3)
        {
            MPThrees.Add(newMP3);
        }
        #endregion

        #region Dropping()
        /// <summary>
        /// Creates the Drop method
        /// </summary>
        /// <param name="index">index of MPThree to be removed from the playlist</param>
        /// <returns>the new MPThrees in the playlist without the one that was removed</returns>
        public List<MPThree> Drop(int index)
        {
            MPThrees.RemoveAt(index - 1);
            return MPThrees;
        }
        #endregion

        #region Editing()
        /// <summary>
        /// Creates the Edit method
        /// </summary>
        /// <param name="index">index to be removed at based on users input in the driver</param>
        /// <param name="newMP3">MPThree to be added based on user input in the driver</param>
        /// <returns>MPThrees that are now stored after removing one and adding one</returns>
        public List<MPThree> Edit(int index, MPThree newMP3)
        {
            MPThrees.RemoveAt(index - 1);
            MPThrees.Add(newMP3);
            return MPThrees;
        }
        #endregion

        #region FillFromFile()
        public void FillFromFile(string path)
        {
            StreamReader reader = new StreamReader(path);
            string line = reader.ReadLine();
            string[] fields = line.Split("|");
            NameOfPlaylist = fields[0];
            CreatorOfPlaylist = fields[1];
            CreationDate = fields[2];
            try
            {
                while (reader.Peek() != -1)
                {
                    line = reader.ReadLine();
                    fields = line.Split("|");
                    MPThree mPThrees = new MPThree(fields[0], fields[1], DateOnly.Parse(fields[2]), Double.Parse(fields[3]), ((Genre)Enum.Parse(typeof(Genre), (fields[4]))), Decimal.Parse(fields[5]), Double.Parse(fields[6]), fields[7]);
                    MPThrees.Add(mPThrees);
                }
            }
            catch (ArgumentException e)
            {
                return;
            }
            catch (FormatException e)
            {
                return;
            }
            catch (Exception e)
            {
                return;
            }
            finally
            {
                if (reader != null)
                    reader.Close();
            }
        }
        #endregion

        #region SaveToFile()
        public void SaveToFile(string path)
        {
            StreamWriter writer = new StreamWriter(path);
            writer.WriteLine(NameOfPlaylist + "|" + CreatorOfPlaylist + "|" + CreationDate);
            for (int i = 0; i < MPThrees.Count; i++)
            {
                writer.WriteLine(MPThrees[i].MpthreeTitle + "|" + MPThrees[i].Artist + "|" + MPThrees[i].Date + "|" + MPThrees[i].SongPlaytime + "|" + MPThrees[i].Genre + "|" + MPThrees[i].DownloadCost + "|" + MPThrees[i].FileSize + "|" + MPThrees[i].Path);
            }
            writer.Close();
        }
        #endregion

        #region ToString()
        /// <summary>
        /// ToString method
        /// </summary>
        /// <returns>format output of the playlist</returns>
        public override string ToString()
        {
            string info = "";
            int index = 0;
            foreach (MPThree MPThree in MPThrees)
                {                
                    info += $"Song {index + 1}\n";
                    info += "-------------------------\n";
                    info += MPThree.ToString();
                    index++;
                }
            info += $"\nName of Playlist:\t\t{NameOfPlaylist}\n";
            info += $"Creator of the Playlist:\t{CreatorOfPlaylist}\n";
            info += $"Creation Date:\t\t\t{CreationDate}\n";

            return info;
        }
        #endregion
    }
}