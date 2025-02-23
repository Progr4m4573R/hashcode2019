﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace hascode
{
    public class Photo
    {
        public string orientation { get; set; }
        public int numOfTags { get; set; }
        public List<string> tags = new List<string>();
    }

    public class DataImport             //Class to handle reading and spliting the data from the txt file
    {
        public string Filepath { get; set; }    //variable for the setting of the filepath

        private List<string> import()       //function for loading in the csv file
        {
            List<string> data = File.ReadAllLines(Filepath).Skip(1).ToList();   //reading the file and skipping the first line, these lines are then added to the list
            return data;           //function returns the imported data                       
        }

        public List<Photo> filter()     //function for splitting up the different elements of the data, and storing them in the photo data type
        {
            List<string> unFiltered = import();     //storing the imported data
            List<Photo> filtered = new List<Photo>();       //defining a new p0hoto data type list for storing the extracted photos
            foreach (string x in unFiltered)
            {
                Photo addPhoto = new Photo();    //creating a new instance of the photo class
                var line = x.Split(' ');        //splitting the strings at the spaces
                addPhoto.orientation = line[0];     //as we know the position of first two elements dont change 
                addPhoto.numOfTags = Convert.ToInt32(line[1]);
                for (int y = 2; y < line.Count(); y++)  //going through the tags for the current photo and adding them to the list in the photo class data type
                {
                    addPhoto.tags.Add(line[y]);
                }

                filtered.Add(addPhoto);  //adding the completed photo to the list
            }

            return filtered;    //returning the list of photos
        }
    }
        class Program
    {
        static void Main(string[] args)
        {
            string filePath = @"b_lovely_landscapes.txt";   //setting the filepath of the photos
            DataImport newImport = new DataImport();    //creating a new instance of the import class
            newImport.Filepath = filePath;      //setting the filepath for the new instance
            var photoData = newImport.filter(); //storing the completed photo filters 

            for (int y = 0; y < 10; y++)
            {
                Console.WriteLine(photoData[y].orientation);
                Console.WriteLine(photoData[y].numOfTags);
                for (int x = 0; x < photoData[y].tags.Count; x++)
                {
                    Console.WriteLine(photoData[y].tags[x]);
                }
            }
            Console.ReadLine();
            
        }
    }
}

/* photoData[index max eg 80000].orientation - returns the orientatio (string "H" or "V")
 *                              .numOfTags - returns the number of tags for that photo
 *                              .tags[index] - list of all the tags to that photo
 *                              .tags.Count - tells you how many elements are in that list
 * 
 * 
