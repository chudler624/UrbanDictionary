namespace UrbanDictionary.Models
{
    public class WordModel
    {
        public string Word { get; set; }
        public string Definition { get; set; }
        public List<string> SoundUrls { get; set; }
        public string Example { get; set; }
        public string Author { get; set; }
        public DateTime WrittenOn { get; set; }
        public int ThumbsUp { get; set; }
        public int ThumbsDown { get; set; }



    }
}
