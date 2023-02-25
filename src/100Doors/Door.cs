namespace HundredDoors
{
    public class Door
    {
        public bool IsOpen { get; set; }

        public string GetState()
        {
            return IsOpen ? "@" : "#";
        }
    }
}
