namespace HttpServer
{
    using System.Collections.Generic;
    using System.Text;

    public class Response
    {
        public Response(string responseLine ,ICollection<Header> headers, string body)
        {
            this.ResponseLine = responseLine;
            this.Body = body;
            this.Headers = headers;
        }

        public string Body { get; set; }

        public ICollection<Header> Headers { get; set; }

        public string ResponseLine { get; set; }

        public override string ToString()
        {
            var sb = new StringBuilder();

            sb.Append(this.ResponseLine + Constants.NewLine);

            foreach (var header in this.Headers)
            {
                sb.Append($"{header.Key}: {header.Value}" + Constants.NewLine);
            }

            sb.Append(Constants.NewLine);
            sb.Append(this.Body + Constants.NewLine);

            return sb.ToString().TrimEnd();
        }
    }
}
