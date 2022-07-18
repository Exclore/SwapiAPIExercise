using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StarWarsAPIExercise.Models
{
    public class Starship
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Model{ get; set; }
        public string? Starship_class{ get; set; }
        public string? Manufacturer{ get; set; }
        public string? Cost_in_credits{ get; set; }
        public string? Length{ get; set; }
        public string? Crew{ get; set; }
        public string? Passengers{ get; set; }
        public string? Max_atmosphering_speed{ get; set; }
        public string? Hyperdrive_rating{ get; set; }
        public string? MGLT{ get; set; }
        public string? Cargo_capacity{ get; set; }
        public string? Consumables{ get; set; }
        [NotMapped]
        public string[]? Films{ get; set; }
        [NotMapped]
        public string[]? Pilots{ get; set; }
        public string? Url{ get; set; }
        public string? Created{ get; set; }
        public string? Edited{ get; set; }
    }
}
