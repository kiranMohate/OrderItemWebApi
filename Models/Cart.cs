using System.ComponentModel.DataAnnotations;

namespace OrderItemWebApi.Models
{
    public class Cart
    {
        [Key]
        public int Id { get; set; }
        public int userId { get; set; }
        public int menuItemId { get; set; }
        public string menuItemName { get; set; }

       
       

    }
}
