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
    
    public partial class customers
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public customers()
        {
            this.customer_managers = new HashSet<customer_managers>();
            this.orders = new HashSet<orders>();
        }
    
        public long custid { get; set; }
        public string compname { get; set; }
        public string contact { get; set; }
        public string city { get; set; }
        public string country { get; set; }
        public string currid { get; set; }
        public short discount { get; set; }
    
        public virtual currencies currencies { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<customer_managers> customer_managers { get; set; }
        public virtual custstats custstats { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<orders> orders { get; set; }
    }
}