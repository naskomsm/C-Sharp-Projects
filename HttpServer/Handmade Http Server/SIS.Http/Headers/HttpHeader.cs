namespace SIS.HTTP.Headers
{
    using SIS.HTTP.Common;

    public class HttpHeader
    {
        public const string ContentType = "content-type";
        public const string Location = "location";

        public HttpHeader(string key, string value)
        {
            CoreValidator.ThrowIfNullOrEmpty(key, nameof(key));
            CoreValidator.ThrowIfNullOrEmpty(value, nameof(value));

            this.Key = key;
            this.Value = value;
        }

        public string Key { get; }

        public string Value { get; }

        public override string ToString()
            => $"{this.Key}: {this.Value}";
    }
}
