using GameExeTranslation.TextFormat;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameExeTranslation.Core
{
    public class Project
    {
        private string exePath = "";
        List<ExeSectorText> exeSectorTextList = new List<ExeSectorText>();

        public string ExePath { get => exePath; set => exePath = value; }
        public List<ExeSectorText> ExeSectorTextList { get => exeSectorTextList; set => exeSectorTextList = value; }

        public static Project LoadJson(string projectPath)
        {
            if (File.Exists(projectPath))
            {
                string json = File.ReadAllText(projectPath);
                return (Project)JsonConvert.DeserializeObject(json, typeof(Project));
            }
            else
                return null;
        }

        public void SaveJson(string projectPath)
        {
            string jsonString = JsonConvert.SerializeObject(this, Formatting.Indented);
            File.WriteAllText(projectPath, jsonString);
        }
    }
}
