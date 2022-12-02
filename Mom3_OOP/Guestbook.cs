using System;
using System.Collections.Generic;

using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using System.Runtime.ConstrainedExecution;
using System.Collections;
using System.IO;

namespace Moment_3_OOP
{
    //Deklarera class för gästbok där alla metoder skapas och körs
    class Guestbook
    {


        //String inom Guestbook för lagring av json-fil
        private string guestbookFile = Directory.GetCurrentDirectory().ToString() + "/" + @"guestbook.json";
        //Deklarering av lista, som består av objekten från GuestbookPost
        private List<GuestbookPost> guestbookList = new List<GuestbookPost>();

        //Funktion som kollar om filen guestbook.json finns, isåfall läser ut dess innehåll
        //Läses in direkt vid intansiering av appsen
        public Guestbook()
        {
            if (File.Exists(@"guestbook.json") == true)
            { // If stored json data exists then read
              //Lagrar innehåll i filename till jsonString
                string jsonString = File.ReadAllText(guestbookFile);
                //Hämta innehållet i json-filen och deserialize innehållet och lagra i listan guestbookList
                guestbookList = JsonSerializer.Deserialize<List<GuestbookPost>>(jsonString);
            }
        }

        //Publik funktion om man vill addera en bil till json-filen
        public GuestbookPost addPost(GuestbookPost post)
        {

            //Lägger till ny post till listan
            guestbookList.Add(post);

            //Anropa metod som lagrar lista
            saveToFile();

            return post;
        }

        public int countPosts()
        {
            //Returnera antalet inlägg
            return guestbookList.Count();
        }

        //Hämta alla inlägg
        public List<GuestbookPost> getAllPosts()
        {
            return guestbookList;
        }

        //Radera inlägg baserat på index
        public int deletePost(int index)
        {
            guestbookList.RemoveAt(index);
            //Anropa metod som lagrar uppdat lista
            saveToFile();
            return index;

        }

        //Denna funktion anropas när listan har uppdaterats, den hämtar listan och sparar den i json-filen som ligger under guestbookFile
        private void saveToFile()
        {
            // Serialize alla obejekt från listan cars och spara till json-filen
            var jsonString = JsonSerializer.Serialize(guestbookList);
            File.WriteAllText(guestbookFile, jsonString);
        }

    }

    //Ny class för Car
    public class GuestbookPost
    {
        //Deklarera en privat string inom classen 
        private string title;
        private string content;
        private string author;

        public string Title
        {

            set { this.title = value; }
            get { return title; }

        }

        public string Content
        {

            set { this.content = value; }
            get { return content; }

        }

        public string Author
        {

            set { this.author = value; }
            get { return author; }

        }


    }

}
