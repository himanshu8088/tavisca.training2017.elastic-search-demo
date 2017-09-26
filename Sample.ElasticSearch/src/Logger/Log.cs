using System;
using ESSearchEngine.Lib;

namespace Logger
{
    public class Log
    {
        //private string _req;
        //private string _res;
        //private string _status;
        public Guid Id { get; private set; }
        public DateTime CreationStamp { get; private set; }
        public string Status { get; private set; }
        public string Request { get; private set; }
        public string Response { get; private set; }
        private Uri _uri;
        private string _index;
        private string _type;

        public Log(Uri uri, int logId)
        {
            _index = $"log{logId}";
            _type = $"log_entry{logId}";
            _uri = uri;
        }

        public void Store(object req, object res, object status)
        {
            Status = status.ToString();
            Request = req.ToString();
            Response = res.ToString();
            CreationStamp = DateTime.Now;
            Id = Guid.NewGuid();

            ESConnection conn = new ESConnection();           
            var client = conn.GetClient(_uri, _index);

            ESIndexer indexer = new ESIndexer(client, _index, _type);
            var logEntry = $"{CreationStamp} {Request} {Response} {Status}";            
            var response = indexer.CreateIndex<object>(new { logEntry = logEntry}, Id.ToString());
            var ex = response.OriginalException;
            if (ex != null)
                throw new Exception("Log could not be stored");
        }
    }
}
