//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Mess_Management_System.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Meal
    {
        public int mealID { get; set; }
        public System.DateTime mealDate { get; set; }
        public Nullable<int> TotalMealNo { get; set; }
        public int userID { get; set; }
    
        public virtual mess_member mess_member { get; set; }
    }
}
