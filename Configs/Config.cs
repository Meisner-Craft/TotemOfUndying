namespace TotemOfUndying
{
    public class Config
    {
        // MAIN
        public ItemType TotemItem { get; set; } = ItemType.KeycardMTFOperative;

        public int TotemCount { get; set; } = 1;

        public int SevesCount { get; set; } = 3;

        public int NewCustomItem { get; set; } = 6;


        // EFFECTS
        public int BringDuration { get; set; } = 2;
        
        public int ProtetDuration { get; set; } = 5;
        
        public float HP { get; set; } = 45f;

        public float AHP { get; set; } = 25f;


        // DEBUG
        public bool DebugAllItem { get; set; } = false;

        public bool DebugCustomItem { get; set; } = true;

        public bool DebugUndying { get; set; } = true;

        public bool DebugNewItem { get; set; } = true;
    }
}

