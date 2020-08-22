using Abp.Domain.Values;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BlogPost.Posts
{
    public class Tag : ValueObject
    {
        public Tag()
        {
            
        }

        public Tag(string name)
        {
            Name = name;
        }

        [Required]
        public string Name { get; private set; }
        
        protected override IEnumerable<object> GetAtomicValues()
        {
            yield return Name;
        }
    }
}
