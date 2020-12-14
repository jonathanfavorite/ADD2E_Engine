using System;
using System.Collections.Generic;
using System.Text;
using ADD2E_Core.Characters;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.IO;
using Newtonsoft.Json.Converters;

namespace ADD2E_Core.IO
{
    public class CharacterActions
    {
        public async Task saveCharacter(Character c)
        {
            CreateSaveDirectoryIfDoesntExist();

            using (StreamWriter wr = new StreamWriter("./Saves/" + c.Name + ".json"))
            {
                // var obj = JsonConvert.SerializeObject(c);
                
                var obj = JsonConvert.SerializeObject(c, Formatting.Indented, new StringEnumConverter());
                await wr.WriteAsync(obj);
            }
        }
        public void CreateSaveDirectoryIfDoesntExist()
        {
            if(!Directory.Exists("./Saves"))
            {
                Directory.CreateDirectory("./Saves");
            }
        }
        
    }
}
