using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryManager.Constance
{
    public class BaseModels
    {
        public BaseModels()
        {
            Id = Guid.NewGuid().ToString();
            ActionDate = DateTime.Now;
        }

        [Key]
        public string Id { get; set; }
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime ActionDate { get; set; }
    }
}
