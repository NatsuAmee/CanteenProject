//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace COS_DesktopApp
{
    using System;
    using System.Collections.Generic;
    
    public partial class account
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public account()
        {
            this.carts = new HashSet<cart>();
            this.orders = new HashSet<order>();
        }
        public int id { get; set; }
        public string email { get; set; }
        public string password { get; set; }
        public string fullname { get; set; }
        public System.DateTime birthday { get; set; }
        public string phonenumber { get; set; }
        public int id_role { get; set; }
        public Nullable<System.DateTime> deletedAt { get; set; }
    
        public virtual account_role account_role { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<cart> carts { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<order> orders { get; set; }
    }
}
