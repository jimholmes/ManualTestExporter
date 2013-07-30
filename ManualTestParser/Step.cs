namespace ManualTestParser
{
    public class Step
    {
        private string description;

        public string Description
        {
            get
            {
                return description;
            }
            set
            {
                description = value;
            }
        }

        private string custom;

        public string Custom
        {
            get
            {
                return custom;
            }
            set
            {
                custom = value;
            }
        }
    }
}