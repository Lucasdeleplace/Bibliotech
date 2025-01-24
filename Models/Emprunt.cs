namespace bibliotech.Models
{
    public class Emprunt
    {
        public int Id { get; set; }
        public DateTime Date_Emprunt { get; set; } = DateTime.Now;
        public DateTime Date_Retour { get; set; } = DateTime.Now.AddDays(7);
        public int Id_Membre { get; set; }
        public int Id_Livre { get; set; }
        public Livre? Livre { get; set; }
        public Membre? Membre { get; set; }

    }

}
