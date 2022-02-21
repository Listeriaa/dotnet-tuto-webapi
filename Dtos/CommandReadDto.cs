namespace Commander.Dtos
{
    public class CommandReadDto
    {

        public int Id { get; set; }

        public string HowTo { get; set; }

        public string Line { get; set; }

        //le dto ne veut pas afficher la platforme au client
       // public string Platform { get; set; }
    }
}