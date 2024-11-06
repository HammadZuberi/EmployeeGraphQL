using System.ComponentModel.DataAnnotations.Schema;

namespace EmployeeGraphQL.Models
{
	[Table("Review")]
	public class Review
	{
		[System.ComponentModel.DataAnnotations.Key]
        public int Id { get; set; }

		public required int Rate { get; set; }

		public required string Comments { get; set; }

        public int EmployeeId { get; set; }
		[ForeignKey(nameof(EmployeeId))]
        public required Employee Employee { get; set; }

    }
}
