//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MergTestUebungen.DatenBank
{
    using System;
    using System.Collections.Generic;
    
    public partial class customer_managers
    {
        public long custid { get; set; }
        public long empid { get; set; }
    
        public virtual customers customers { get; set; }
    }
}
