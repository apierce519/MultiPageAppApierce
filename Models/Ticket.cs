using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace MultiPageAppApierce.Models
{
    public class Ticket
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Please enter a name.")]
        public string Name { get; set; } = string.Empty;

        [Required(ErrorMessage = "Please enter a description.")]
        public string Description { get; set; } = string.Empty;
        [Required(ErrorMessage = "Please enter a sprint number.")]
        public int SprintNumber { get; set; }
        [Required(ErrorMessage = "Please enter a point value.")]
        public int PointValue { get; set; }
        public string StatusId { get; set; } = null!;
        [Required(ErrorMessage = "Please enter a status.")]
        public Status Status { get; set; } = null!;

    }
}
