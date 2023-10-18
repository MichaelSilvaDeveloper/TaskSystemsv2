using TaskSystemsV2.Enums;

namespace TaskSystemsV2.Models
{
    public class TaskModel
    {
        public int Id { get; set; }

        public string? Name { get; set; }

        public string? Description { get; set; }

        public StatusTask Status { get; set; }

        public int? UserId { get; set; }

        public UserModel? User { get; set; }
    }
}   