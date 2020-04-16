namespace eBookie.model
{
    public class PageEntry
    {
        public string Page;
        public object[] Args;

        public PageEntry(string page, object[] args)
        {
            Page = page;
            Args = args;
        }
    }
}