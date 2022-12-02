using Media_Player.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Media_Player.ViewModel
{
    internal class ReadFile
    {
        public static void ReadSong(ref List<Song> list, int N, string path1, string path2, string m)
        {
            string[] tennhac = new string[N];
            string[] tencasi = new string[N];
            using (StreamReader sr = new StreamReader(path1 + "/TenNhac.txt"))
            {
                int i = 0;
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    tennhac[i] = line;
                    i += 1;
                }
            }
            using (StreamReader tr = new StreamReader(path1+ "/TenCaSi.txt"))
            {
                int j = 0;
                string line;
                while ((line = tr.ReadLine()) != null)
                {
                    tencasi[j] = line;
                    j += 1;
                }
            }
            for (int k = 0; k < N; k++)
            {
                string linknhac = AppDomain.CurrentDomain.BaseDirectory + path2+ "/LinkNhac/" + "b" + k + ".mp3";                
                string linkAnh = AppDomain.CurrentDomain.BaseDirectory + path2 + "/LinkAnh/" + "a" + k + m;
                list.Add(new Song()
                {
                    songName = tennhac[k],
                    singerName = tencasi[k],
                    linkanh = linkAnh,
                    savepath = linknhac
                });
            }
        }
        
    }
}
