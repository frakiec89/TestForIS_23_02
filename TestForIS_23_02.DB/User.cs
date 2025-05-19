// track
using System.ComponentModel.DataAnnotations;

namespace TestForIS_23_02.DB
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
