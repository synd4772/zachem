using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using static System.Formats.Asn1.AsnWriter;

namespace Game_Uss
{
    public class PlayersControl
    {

        public List<string> currentLines { get; private set; }
        public string path { get; private set; }

        public PlayersControl(string path)
        {
            using (StreamWriter f = new StreamWriter(path, true)) { }
            this.path = path;
            this.currentLines = new List<string> { };
            this.UpdateList();
        }
        public void UpdateFile()
        {

            using (StreamWriter outputFile = new StreamWriter(this.path))
            {
                foreach (string line in this.currentLines)
                {
                    if (this.currentLines.IndexOf(line) == this.currentLines.Count - 1)
                    {
                        outputFile.Write($"{line.Trim()}");
                    }
                    else
                    {
                        outputFile.Write($"{line.Trim()}\n");
                    }

                }
            }
        }

        public void UpdateList() //Loeb failist andmeid ja laadib need praegusesse ridadesse. Iga rida jagatakse elementideks, kasutades reavahetusmärki
        {
            StreamReader sr = new StreamReader(this.path);
            this.currentLines = sr.ReadToEnd().Split("\n").ToList();
            sr.Close();
        }
        public int HasPlayer(string username)
        {
            for (int i = 0; i < currentLines.Count; i++)
            {
                List<string> formatedLine = this.currentLines[i].Trim().Split(":").ToList();
                if (formatedLine[0] == username.Trim())
                {
                    return i;
                }
            }
            return -1;
        }

        public void AddPlayer(string username, int score)
        {
            if (this.HasPlayer(username) == -1)
            {
                string line = $"{username}:{score}";
                using (StreamWriter outputFile = new StreamWriter(this.path, true))
                {
                    outputFile.Write(line);
                }
                this.UpdateList();
            }
        }

        public void AddPlayer(Player player)
        {
            if (this.HasPlayer(player.Name) == -1)
            {
                string sym = (currentLines.Count != 1) ? "\n" : "" ;
                string line = $"{sym}{player.Name}:{player.BestScore}";
                using (StreamWriter outputFile = new StreamWriter(this.path, true))
                {
                    outputFile.Write(line);
                }
                this.UpdateList();
            }
        }

        public void UpdatePlayer(Player player)
        {
            int userIndex = this.HasPlayer(player.Name);

            if (userIndex != -1)
            {
                string line = $"{player.Name}:{player.BestScore}";
                this.currentLines[userIndex] = line;
                this.UpdateFile();
            }
        }



        public List<string>? GetPlayer(string username)
        {
            int index = this.HasPlayer(username);
            if (index != -1)
            {
                string line = this.currentLines[index];
                List<string> formatedLine = line.Split(":").ToList();
                return formatedLine;
            }
            return null;
        }
    }
}
