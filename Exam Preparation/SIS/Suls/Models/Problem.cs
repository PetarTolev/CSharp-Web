using System;

namespace Suls.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Problem
    {
        public Problem()
        {
            this.Id = Guid.NewGuid().ToString();
            this.Submissions = new HashSet<Submission>();
        }

        [Key]
        public string Id { get; set; }

        [Required]
        [MinLength(5), MaxLength(20)]
        public string Name { get; set; }

        [Required]
        public int Points { get; set; }

        public virtual ICollection<Submission> Submissions { get; set; }
    }
}
