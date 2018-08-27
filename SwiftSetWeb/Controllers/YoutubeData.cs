namespace SwiftSetWeb.Controllers
{
    public class YoutubeData
    {
        public int startTimeMillis = 0;
        public string videoCode = "";

        public YoutubeData(string vc, int st)
        {
            this.videoCode = vc;
            this.startTimeMillis = st;
        }
    }
}