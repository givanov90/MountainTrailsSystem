using MountainTrailsSystem.Core.Models.Trail;
using System.ComponentModel.DataAnnotations;
using static MountainTrailsSystem.Infrastructure.Constants.DataConstants;
using static MountainTrailsSystem.Infrastructure.Constants.MessageConstants;

namespace MountainTrailsSystem.Core.Models.StatusNote
{
    public class TrailStatusNoteViewModel
    {
        [Required(ErrorMessage = RequiredErrorMessage)]
        [StringLength(TrailStatusNoteTitleMaximumLength, MinimumLength = TrailStatusNoteTitleMinimumLength, ErrorMessage = FieldLengthErrorMessage)]
        public string Title { get; set; } = string.Empty;

        [Required(ErrorMessage = RequiredErrorMessage)]
        [StringLength(TrailStatusNoteMaximumLength, MinimumLength = TrailStatusNoteMinimumLength, ErrorMessage = FieldLengthErrorMessage)]
        public string Description { get; set; } = string.Empty;

        [Required(ErrorMessage = RequiredErrorMessage)]
        public string ImageUrl { get; set; } = string.Empty;

        [Required(ErrorMessage = RequiredErrorMessage)]
        [Display(Name = "Trail")]
        public int TrailId { get; set; }

        public IEnumerable<TrailServiceModel> Trails { get; set; } =
            new List<TrailServiceModel>();
    }
}
