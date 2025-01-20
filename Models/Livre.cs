namespace bibliotech.Models
{
    public class Livre
    {
        public int Id { get; set; }

        public string  Titre {get; set;}

        public  string Auteur { get; set; }
        public int Isbn { get; set; }
        
        public bool Disponibilite { get; set; }
    }
}
