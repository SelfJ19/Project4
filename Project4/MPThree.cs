////////////////////////////////////////////////////////////////////////////////////////////////////////
//
// Project: Project 4 MP3 Tracker with Files
// File Name: MPThree.cs
// Description: Represents the MPThree Object
// Course: CSCI 1260-001 – Introduction to Computer Science II
// Author: Jason Self, selfj1@etsu.edu, East Tennessee State University
// Created: 10/30/2022
// Copyright: Jason Self, 2022
//
////////////////////////////////////////////////////////////////////////////////////////////////////////
using System;

namespace MPThreeClass
{
    /// <summary>
    /// Creating the public class MPThree to use in MPThreeDriverClass
    /// </summary>
    public class MPThree
    {
        #region Attributes
        //3 main components of an object class: attributes, constructors, methods
        /// <summary>
        /// Attributes - data that belongs to and describes an object of the class
        ///</summary>
        public Genre Genre { get; set; }
        public string MpthreeTitle { get; set; }
        public string Artist { get; set; }
        public DateOnly Date { get; set; }
        public double SongPlaytime { get; set; }
        public decimal DownloadCost { get; set; }
        public double FileSize { get; set; }
        public string Path { get; set; }
        #endregion

        #region Default()
        /// <summary>
        /// default constructor: sets attributes to default values
        /// </summary>
        public MPThree()
        {
            Genre = Genre.Rock;
            MpthreeTitle = "";
            Artist = "";
            Date = DateOnly.MinValue;
            SongPlaytime = '0';
            DownloadCost = '0';
            FileSize = '0';
            Path = "";
        }
        #endregion

        #region Parameterized()
        /// <summary>
        /// parameterized constructor
        /// </summary>
        /// <param name="Genre">sets the Genre based on user input</param>
        /// <param name="MpthreeTitle">sets the MpthreeTitle based on user input</param>
        /// <param name="Artist">sets the Artist based on user input</param>
        /// <param name="Date">sets the ReleaseDate based on user input</param>
        /// <param name="SongPlaytime">sets the SongPlaytime based on user input</param>
        /// <param name="DownloadCost">sets the DownloadCost based on user input</param>
        /// <param name="FileSize">sets the FileSize based on user input</param>
        /// <param name="Path">sets the Path based on user input</param>
        public MPThree(string MpthreeTitle, string Artist, DateOnly Date, double SongPlaytime, Genre Genre, decimal DownloadCost, double FileSize, string Path)
        {
            this.Genre = Genre;
            this.MpthreeTitle = MpthreeTitle;
            this.Artist = Artist;
            this.Date = Date;
            this.SongPlaytime = SongPlaytime;
            this.DownloadCost = DownloadCost;
            this.FileSize = FileSize;
            this.Path = Path;
        }
        #endregion

        #region Copy()
        /// <summary>
        /// copy constructor
        /// </summary>
        /// <param name="existingMPThree">uses the existing MPThree to create a copy</param>
        public MPThree(MPThree existingMPThree)
        {
            Genre = existingMPThree.Genre;
            MpthreeTitle = existingMPThree.MpthreeTitle;
            Artist = existingMPThree.Artist;
            Date = existingMPThree.Date;
            SongPlaytime = existingMPThree.SongPlaytime;
            DownloadCost = existingMPThree.DownloadCost;
            FileSize = existingMPThree.FileSize;
            Path = existingMPThree.Path;
        }
        #endregion

        #region ToString()
        /// <summary>
        /// ToString method
        /// </summary>
        /// <returns>how info of MPThree is to display</returns>
        public override string ToString()
        {
            string info = "";
            
            info = $"MP3 Title:\t{MpthreeTitle}\n";
            info += $"Artist:\t\t{Artist}\n";
            info += $"Release Date:\t{Date}\tGenre:\t\t{Genre}\n";
            info += $"Download Cost:\t${DownloadCost}\t\tFile Size:\t{FileSize} Mbs\n";
            info += $"Song Playtime:\t{SongPlaytime}min\t\tAlbum Photo:\t{Path}\n\n";
                    
            return info;
        }
        #endregion
    }
}