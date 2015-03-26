namespace StudentSystem.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Resource
    {
        private ICollection<Course> courses;

        public Resource()
        {
            this.courses = new HashSet<Course>();
        }

        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

        [Required]
        public ResourceType TypeOfResource { get; set; }

        [MaxLength(300)]
        public string Link { get; set; }

        public ICollection<Course> Courses 
        {
            get { return this.courses; }
            set { this.courses = value; } 
        }
    }
}
