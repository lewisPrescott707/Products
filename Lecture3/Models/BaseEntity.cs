using System;

namespace Lecture3.Models
{
    public class BaseEntity
    {
        public BaseEntity() { }

        public int Id { get; set; }
        public DateTime AddedDate { get; set; }

    }
}