using System;
using System.Threading;
using System.IO;
using System.Linq;
using System.Collections.Generic;

namespace ConsoleApp18
{
    class Program
    {
        static void Main(string[] args)
        {
            int count = 0;
            List<int> countword = new List<int>();
            List<string> kelimeler = new List<string>();
            List<string> sonkelimeler = new List<string>();

            

            string lastWord;
            List<string> linelist = new List<string>();
            StreamReader f = File.OpenText("D:\\poem.txt");
            do
            {
                string line = f.ReadLine();

                linelist.Add(line);
                for (int i = 0; i <= line.Split(' ').Count() - 1; i++)
                {
                    lastWord = line.Split(' ')[i];
                    kelimeler.Add(lastWord);
                }

                string sonkelime = line.Split(' ').Last();
                sonkelimeler.Add(sonkelime);


                count = line.Split(' ').Count();
                countword.Add(count);



            } while (!f.EndOfStream);
            f.Close();

            wr1();
            ar2();
            pr1();
            altr1();
            void wr1()
            {
                //Word Rhyme
                bool flagwr = false;
                for (int wr = 0; wr < linelist.Count - 1; wr++)
                {

                    if (linelist[wr].Split(' ')[linelist[wr].Split(' ').Count() - 1] == linelist[wr + 1].Split(' ')[linelist[wr + 1].Split(' ').Count() - 1])
                    {
                        flagwr = true;

                    }
                    else
                    {
                        flagwr = false;
                        break;
                    }
                }
                if (flagwr == true)
                {
                    Console.WriteLine("Word Rhyme");
                    Console.WriteLine($"Repeated Word: {linelist[1].Split(' ')[linelist[1].Split(' ').Count() - 1]}");
                }



            }

            void ar2()
            {
                //Additional Rhymes
                bool flagar = false;
                var enkisa = sonkelimeler.OrderBy(c => c.Length).FirstOrDefault();
                int ar1 = 1;
                string rptdchars = "";
                for (int ar = 0; ar < sonkelimeler.Count() - 1; ar++)
                {
                    if (sonkelimeler[ar].ToCharArray()[sonkelimeler[ar].Length - ar1] == sonkelimeler[ar + 1].ToCharArray()[sonkelimeler[ar + 1].Length - ar1])
                    {

                        flagar = true;
                        rptdchars = sonkelimeler[ar].ToCharArray()[sonkelimeler[ar].Length - ar1] + rptdchars;

                    }
                    else
                    {
                        if (flagar == true && ar == sonkelimeler.Count - 2)
                        {

                        }
                        else
                        {
                            flagar = false;
                        }
                        break;

                    }
                    ar1++;

                }



                if (flagar == true)
                {
                    Console.WriteLine("Additional Rhyme");
                    Console.WriteLine($"Repeated chars: {rptdchars} ");

                }

            }


            void pr1()
            {
                //Phrase Rhyme
                bool flagpr = false;
                int a = 1;
                for (int pr = 0; pr < linelist.Count - 1; pr++)
                {



                }
            }

            void altr1()
            {
                //Alternating Rhyme
                bool flagar = false;

                for (int ar = 0; ar < linelist.Count - 2; ar++)
                {

                    var enkisa = sonkelimeler.OrderBy(c => c.Length).FirstOrDefault();

                    for (int ar1 = 0; ar1 <= enkisa.Length - 1; ar1++)
                    {

                        if (sonkelimeler[ar].ToCharArray()[sonkelimeler[ar].Length - 1] == sonkelimeler[ar + 2].ToCharArray()[sonkelimeler[ar + 2].Length - 1])
                        {
                            flagar = true;

                        }
                        else
                        {
                            flagar = false;
                            break;


                        }
                    }
                }
                if (flagar == true)
                    Console.WriteLine("Alternating Rhyme");

            }

            Console.ReadLine();







        }
    }
}

