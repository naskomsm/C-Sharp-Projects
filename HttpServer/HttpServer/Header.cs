namespace HttpServer
{
    public class Header
    {
        public Header(string key, string value)
        {
            this.Key = key;
            this.Value = value;
        }

        public string Key { get; set; }

        public string Value { get; set; }
    }
}
