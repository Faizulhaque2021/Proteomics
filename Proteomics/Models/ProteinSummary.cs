using System.ComponentModel.DataAnnotations;

namespace Proteomics.Models
{
    public class ProteinSummary
    {
        public int ProteinSummaryID { get; set; }

        [Display(Name = "Accession ID")]
        [Required]
        [StringLength(20)]
        public string? AccessionID { get; set; }

        [Display(Name = "Gene Symbol")]
        [Required]
        [StringLength(20)]
        public string? GeSymbol { get; set; }

        [Display(Name = "Protein Name")]
        [Required]
        [StringLength(20)]
        public string? ProtName { get; set; }

        [Display(Name = "Gene Names")]
        [Required]
        [StringLength(20)]
        public string? GeNames { get; set; }

        [Display(Name = "Total PSMs")]
        [Required]
        public int TotalPs { get; set; }

        [Display(Name = "Mean PSMs")]
        [Required]
        public int MePSMs { get; set; }

        [Display(Name = "Detected in (%)")]
        [Required]
        public int Detected { get; set; }
    }
}
