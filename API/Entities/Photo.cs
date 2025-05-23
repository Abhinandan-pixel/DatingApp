using System.ComponentModel.DataAnnotations.Schema;

namespace API.Entities
{
    //This attribute is used to specify the name of the table in the database
    //If we don't specify it, the default name will be the class name
    [Table("Photos")]
    public class Photo
    {
        public int Id { get; set; }
        public string Url { get; set; }
        public bool IsMain { get; set; }
        public string PublicId { get; set; }
        public int AppUserId { get; set; }
        public AppUser AppUser { get; set; } //Navigation property to the AppUser entity
        
    }
}