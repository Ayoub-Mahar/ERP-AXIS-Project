//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ERP.APP_CODE
{
    using System;
    using System.Collections.Generic;
    
    public partial class LEVEL2
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public LEVEL2()
        {
            this.LEVEL3 = new HashSet<LEVEL3>();
        }
    
        public int level1id { get; set; }
        public int level2id { get; set; }
        public string level2desc { get; set; }
        public string EntryBy { get; set; }
        public Nullable<System.DateTime> EntryDate { get; set; }
        public string EditBy { get; set; }
        public Nullable<System.DateTime> EditDate { get; set; }
        public string DeletedBy { get; set; }
        public Nullable<System.DateTime> DeletedDate { get; set; }
    
        public virtual LEVEL1 LEVEL1 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<LEVEL3> LEVEL3 { get; set; }
    }
}