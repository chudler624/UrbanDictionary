using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using UrbanDictionary.Models;

namespace UrbanDictionary.UrbanDictionaryApi
{
    public class UrbanApi
    {

        public UrbanApi() { }


        public List<WordModel> GetWordInfo(string word)
        {
            //Creating Request Object
            var client = new HttpClient();
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri($"https://mashape-community-urban-dictionary.p.rapidapi.com/define?term={word}"),
                Headers =
                {
                    { "X-RapidAPI-Key", "fe96c29976msh7164fa7f072bef1p19efc6jsn0ad83cbe2bb2" },
                    { "X-RapidAPI-Host", "mashape-community-urban-dictionary.p.rapidapi.com" },
                },
            };

            //Send Request
            using (var response = client.SendAsync(request).Result)
            {
                //handle Result
                response.EnsureSuccessStatusCode();
                var body = response.Content.ReadAsStringAsync().Result;

                //Deserialze to C# Object
                var wordInfo = JsonConvert.DeserializeObject<ApiResult>(body);

                //Map object to Model
                var wordModels = new List<WordModel>();
                foreach (var item in wordInfo.list)
                {
                    //ALTERNATE OPTION
                    //var tmp = new WordModel();
                    //tmp.Word = "test";
                    //wordModels.Add(tmp);

                    wordModels.Add(new WordModel
                    {
                        Word = item.word,
                        Definition = item.definition,
                        SoundUrls = item.sound_urls,
                        Example = item.example

                    }) ;


                }

                return wordModels;
            }

        }

    }
}