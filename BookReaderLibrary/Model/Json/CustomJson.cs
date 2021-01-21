using System;
using System.Collections.ObjectModel;
using System.IO;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace BookReaderLibrary.Model.Json
{
    public class CustomJson
    {
        public async void Serialize(ObservableCollection<string> books)
        {
            using(FileStream Writer = new FileStream("Books.json", FileMode.OpenOrCreate))
            {
                await JsonSerializer.SerializeAsync<ObservableCollection<string>>(Writer, books);
            }   
        }

        public ObservableCollection<string> Deserialize()
        {
            ObservableCollection<string> Result;
            string JsonResult;
            using (StreamReader Reader = new StreamReader("Books.json"))
            {
                JsonResult = Reader.ReadToEnd();
                Result = JsonSerializer.Deserialize<ObservableCollection<string>>(JsonResult);
            }
            return Result;
        }
    }
}
