using System;
using System.IO;

namespace Copyingfiles
{
    class Program
    {
        static void Main(string[] args)
        {
            string sourcefile =@"d:\New folder\MyTest.txt";
            string destinationfile=@"d:\New folder\mytest11";
            try{
                File.Copy(sourcefile,destinationfile,true);
            }
            catch(IOException iox){
                Console.WriteLine(iox.Message);
            }
        }
    }
}
