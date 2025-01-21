﻿namespace bibliotech.Models
{
    public class Emprunt
    {
        public int Id { get; set; }
        public DateTime Date_Emprunt { get; set; } = DateTime.Now;
        public DateTime Date_Retour { get; set; }
        public int Id_Livre { get; set; }
        public int Id_Membre { get; set; }
        public Livre? Livre { get; set; }
    }

}
