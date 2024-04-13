//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ShadrinDemo.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Order
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Order()
        {
            this.Product = new HashSet<Product>();
        }
    
        public int OrderID { get; set; }
        public int OrderStatus { get; set; }
        public Nullable<System.DateTime> OrderDate { get; set; }
        public System.DateTime OrderDeliveryDate { get; set; }
        public int OrderPickupPoint { get; set; }
        public Nullable<int> OrderClient { get; set; }
        public Nullable<int> OrderCode { get; set; }
        public Nullable<int> OrderCount { get; set; }
    
        public virtual OrderPoint OrderPoint { get; set; }
        public virtual Status Status { get; set; }
        public virtual User User { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Product> Product { get; set; }
    }
}
