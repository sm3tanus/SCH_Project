//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace SCH_Project.Dbconnection
{
    using System;
    using System.Collections.Generic;
    
    public partial class Task
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Task()
        {
            this.Subtask = new HashSet<Subtask>();
        }
    
        public int ID { get; set; }
        public string Name { get; set; }
        public Nullable<bool> Status { get; set; }
        public Nullable<System.DateTime> FinalDate { get; set; }
        public string Description { get; set; }
        public Nullable<int> IdUser { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Subtask> Subtask { get; set; }
        public virtual User User { get; set; }
    }
}
