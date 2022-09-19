using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace DownloadQuranFull
{
    class Program
    {
        static void Main(string[] args)
        {
            WebClient client = new WebClient();

            string[] links = GetLinks();

            int counter = 1;
            foreach (var link in links)
            {
                client.DownloadFile(new Uri(link), "Surah" + link.Substring(link.LastIndexOf('/') + 1));
                Console.WriteLine("Downloaded Surah " + counter);
                counter++;
            }
        }
        static string[] GetLinks()
        {
            string[] links = new string[114];
            string baselink = "https://download.quranicaudio.com/quran/yasser_ad-dussary/";
            for (int i = 0; i < 114; i++)
            {
                links[i] = baselink + CovertToThreeDigit(i + 1) + ".mp3";
            }

            return links;
        }
        static string CovertToThreeDigit(int i)
        {
            return i.ToString().PadLeft(3, '0');
        }
    }
}

