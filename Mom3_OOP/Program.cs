using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Runtime.ConstrainedExecution;
using System.Text.Json;
using System.Text.RegularExpressions;
using static Moment_3_OOP.Guestbook;

namespace Moment_3_OOP
{

    //Applikationen 
    class Program
    {
        static void Main(string[] args)
        {
            //Skapa instans av Guestbook
            Guestbook guestbook = new Guestbook();

            while (true)
            {

                //if (clearConsole) { 
                Console.Clear();
                Console.CursorVisible = false;

                // Anropa funktion som adderar inlägg med titel och innehåll
                Console.WriteLine("1. Vill du skriva ett nytt inlägg till gästboken?");
                // Anropa funktion som läser ut alla inlägg från gästboken
                Console.WriteLine("2. Vill du läsa alla inlägg från gästboken?");
                // Läs ut inlägg med titel och index, sedan får användaren välja vilket som ska raderas
                Console.WriteLine("3. Vill du radera ett inlägg från gästboken? ");
                // Avsluta applikationen om användaren klickar x
                Console.WriteLine("x. Vill du avsluta? \n");


                //Amropa funktion som läser ut antal poster lagrade
                Console.WriteLine("Det finns " + guestbook.countPosts() + " inlägg i gästboken!");

                int i = 0;

                int userInput = (int)Console.ReadKey(true).Key;


                switch (userInput)
                {
                    case '1':

                        Console.CursorVisible = true;

                        //Bool värden till inmatade värden för titel och innehåll
                        bool titleFilledIn;
                        bool contentFilledIn;
                        bool authorFilledIn;

                        //Deklarera variabler för titel och innehåll
                        string title = "";
                        string content = "";
                        string author = "";

                        Console.WriteLine("Skriv titel till ditt inlägg:");


                        //Kontroll så titel har angetts
                        do
                        {
                            title = Console.ReadLine();
                            if (title.Length < 1)
                            {
                                Console.WriteLine("Du måste fylla i rubrik");
                                titleFilledIn = true;
                            }
                            else
                            {
                                titleFilledIn = false;
                            }
                        }
                        while (titleFilledIn);

                        Console.WriteLine("Skriv innehåll till ditt inlägg:");

                        //Kontroll så innehåll angetts
                        do
                        {
                            content = Console.ReadLine();
                            if (content.Length < 1)
                            {
                                Console.WriteLine("Du måste skriva innehåll till ditt inlägg!");
                                contentFilledIn = true;
                            }
                            else
                            {
                                contentFilledIn = false;
                            }
                        }
                        while (contentFilledIn);

                        Console.WriteLine("Ange skribent:");

                        //Kontroll så innehåll angetts
                        do
                        {
                            author = Console.ReadLine();
                            if (author.Length < 1)
                            {
                                Console.WriteLine("Ange skribent");
                                authorFilledIn = true;
                            }
                            else
                            {
                                authorFilledIn = false;
                            }
                        }
                        while (authorFilledIn);

                        //Skapa instans av klassen GuestbookPost
                        GuestbookPost obj = new GuestbookPost();

                        //Lagra värden i klassens properties
                        obj.Content = content;
                        obj.Title = title;
                        obj.Author = author;

                        //Anropa funktionen som adderar post till json-fil
                        guestbook.addPost(obj);

                        break;

                    case '2':
                        //Kod
                        Console.Clear();

                        Console.WriteLine("Alla inlägg som finns lagrade!");

                        foreach (GuestbookPost p in guestbook.getAllPosts())
                        {
                            Console.WriteLine(
                                "[" + i++ + "] " + '\n' +
                                "Rubrik: " + p.Title + '\n' +
                                "Innehåll: " + p.Content + '\n' +
                                "Skribent: " + p.Author + '\n'
                                );
                        }

                        //Listan med inlägg ska bevaras men info inom clearConsole ska inte dubbleras
                        Console.WriteLine("Tryck valfri tangent för att komma tillbaka till menyn!");
                        Console.ReadKey();

                        break;

                    case '3':
                        //Kod
                        Console.WriteLine("Välj index på det inlägg du önskar radera \n");
                        Console.WriteLine("A. Gå tillbaka! \n ");

                        foreach (GuestbookPost p in guestbook.getAllPosts())
                        {
                            Console.WriteLine(
                                "[" + i++ + "]" + '\n' +
                                "Rubrik: " + p.Title + '\n' +
                                "Skribent: " + p.Author + '\n');
                        }

                        //Lagra inmatat värde
                        string indexInput = Console.ReadLine();

                        //Avsluta funktion
                        if ((indexInput == "A") || (indexInput == "a"))
                        {
                            break;
                        }

                        //Kontroll om input-värde är ett tal
                        if (!indexInput.All(char.IsDigit))
                        {
                            Console.WriteLine("Endast siffor kan anges!");
                            Console.ReadKey();
                            break;
                        }

                        //Konvertera till int
                        int index = Convert.ToInt32(indexInput);

                        //Kontroll hur många poster som finns
                        int amount = guestbook.countPosts();

                        //Kontroll om index finns
                        if (index > amount - 1)
                        {
                            Console.WriteLine("Index finns ej!");
                            Console.ReadKey();
                            break;
                        }

                        //Anropa fuktion med index som agument
                        guestbook.deletePost(index);

                        break;

                    case 88:
                        //Kod
                        Environment.Exit(0);
                        break;



                }

            }
        }

    }

}