using System.ComponentModel.DataAnnotations;

namespace BlazorBookking.Model;

public class AttendeModel
{
    [Required(ErrorMessage = "Attendee Name is required")]
    public string attendeeName { get; set; }

    [Range(1, int.MaxValue, ErrorMessage = "Ticket count must be greater than 0")]
    public int ticketCount { get; set; } = 1;
}
