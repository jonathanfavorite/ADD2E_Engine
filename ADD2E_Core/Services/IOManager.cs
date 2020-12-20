using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Threading.Tasks;
//using Newtonsoft.Json;
using ADD2E_Core.Models;
using ADD2E_Core.Interfaces;
//using Newtonsoft.Json.Converters;

namespace ADD2E_Core.Services
{
    public class IOManager
    {
        /*
        private void CreateSaveDirectoryIfDoesntExist()
        {
            if (!Directory.Exists("./Characters"))
            {
                Directory.CreateDirectory("./Characters");
            }
            if (!Directory.Exists("./Equipment"))
            {
                Directory.CreateDirectory("./Equipment");
            }
        }
        public async Task SaveCharacter(ICharacter c)
        {
            CreateSaveDirectoryIfDoesntExist();

            using (StreamWriter wr = new StreamWriter("./Characters/" + c.Name + ".json"))
            {
                // var obj = JsonConvert.SerializeObject(c);

                var obj = JsonConvert.SerializeObject(c, Formatting.Indented, new JsonSerializerSettings
                {
                    TypeNameHandling = TypeNameHandling.Auto
                });
                await wr.WriteAsync(obj);
            }
        }
        public async Task<PlayerCharacter> LoadCharacter(string CharacterName)
        {
            PlayerCharacter returnChar = null;
            CreateSaveDirectoryIfDoesntExist();
            using(StreamReader r = new StreamReader("./Characters/" + CharacterName + ".json"))
            {
                string playerData = await r.ReadToEndAsync();
                returnChar = JsonConvert.DeserializeObject<PlayerCharacter>(playerData, new JsonSerializerSettings
                {
                    TypeNameHandling = TypeNameHandling.Auto
                });
            }
            return returnChar;
        }
        */
    }
}
