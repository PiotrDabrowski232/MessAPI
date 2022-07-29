namespace MessAPI
{
    public class MessaClass
    {
        public int MessClassId { get; set; }
        public string MessClassTitles { get; set; }
        public string MessClassBody { get; set; }

        public MessaClass(int id)
        {
            MessClassId = id;
        }
        public MessaClass()
        {
        }
    }
}
