using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSharpProfessional.Part1
{
    public interface IDocument
    {
        string Title { get; set; }
        string Content { get; set; }
    }

    public class Document : IDocument
    {
        public string Title { get; set; }
        public string Content { get; set; }

        public Document()
        { }

        public Document(string title, string content)
        {
            this.Title = title;
            this.Content = content;
        }
    }

    public class DocumentManager<TDocument>
        where TDocument : IDocument
    {
        private readonly Queue<TDocument> _queue = new Queue<TDocument>();

        public void Add(TDocument doc)
        {
            lock (this)
            {
                this._queue.Enqueue(doc);
            }
        }

        public TDocument Get()
        {
            TDocument doc = default(TDocument);
            lock (this)
            {
                doc = this._queue.Dequeue();
            }

            return doc;
        }

        public string DisplayAll()
        {
            StringBuilder sb = new StringBuilder();
            foreach (TDocument doc in this._queue)
                sb.Append(doc.Title + ",");

            return sb.ToString();
        }

        public bool IsAvailable
        {
            get { return this._queue.Count > 0; }
        }
    }
}
