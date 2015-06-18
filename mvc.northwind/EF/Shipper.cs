using System.ComponentModel.DataAnnotations;

namespace mvc.northwind.EF
{
    public partial class Shipper
    {
        public int ShipperID { get; set; }

        [Required]
        [StringLength(40)]
        public string CompanyName { get; set; }

        [StringLength(24)]
        public string Phone { get; set; }
    }
}
