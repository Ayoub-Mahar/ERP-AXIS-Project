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
    
    public partial class LEVEL3
    {
        public int level1id { get; set; }
        public int level2id { get; set; }
        public int level3id { get; set; }
        public string level3desc { get; set; }
        public string EntryBy { get; set; }
        public Nullable<System.DateTime> EntryDate { get; set; }
        public string EditBy { get; set; }
        public Nullable<System.DateTime> EditDate { get; set; }
        public string DeletedBy { get; set; }
        public Nullable<System.DateTime> DeletedDate { get; set; }
    
        public virtual LEVEL2 LEVEL2 { get; set; }
    }
}