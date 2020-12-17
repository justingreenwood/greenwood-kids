namespace complicated
{
    public class Identity
    {
        public string name;
        public string hair;
        public string eye;
        public string species;
        public string outfit;
        public string loveintrest;
        public int age;

        public string description
        {
            get
            {
                return $"{name}, {hair}, {eye}, {species}, {outfit}, {loveintrest}*, {age} :)";
            }
        }
    }
}  

   
    