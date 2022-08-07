namespace MessAPI
{
    public class Message
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Body { get; set; }

        public Message(int id)
        {
            Id = id;
        }
        public Message(int id, string title, string body)
        {
            Id = id;
            Title = title;
            Body = body;
        }
        public Message()
        {
        }

    }
}
