namespace EBookie.model
{
    public class PageEntry
    {
        public string PAGE;
        public object[] ARGS;

        public PageEntry(string page, object[] args)
        {
            PAGE = page;
            ARGS = args;
        }
    }
}