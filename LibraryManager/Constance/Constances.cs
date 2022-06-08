using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryManager.Constance
{
    public class Constances
    {
        public class ResponseMessages
        {
            public bool IsSuccessful { get; set; }
            public string Message { get; set; }
        }

        public class StatusMessages
        {
            public static string Submitted { get; set; } = "Submitted Successfully";
            public static string Deleted { get; set; } = "Deleted Successfully";
            public static string Updated { get; set; } = "Updated Successfully";
            public static string StatusChanged { get; set; } = "Status Changed Successfully";
            public static string Declined { get; set; } = "Operation Declined";
            public static string Error { get; set; } = "Error due to: ";
        }

    }
}
