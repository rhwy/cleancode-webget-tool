namespace ngetv2
{
    interface IArgument
    {

        string[] Argument { get; set; }
        WebConnection Connection { get; set; }
        void execute();
        
    }
}
