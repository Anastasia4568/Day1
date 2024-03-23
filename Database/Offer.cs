//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace RealEstateAgency.Database
{
    using System;
    using System.Collections.Generic;
    
    public partial class Offer
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Offer()
        {
            this.Deal = new HashSet<Deal>();
        }
    
        public int Id { get; set; }
        public Nullable<int> SalesManId { get; set; }
        public Nullable<int> RealEstateId { get; set; }
        public string Address_City { get; set; }
        public string Address_Street { get; set; }
        public Nullable<int> Address_House { get; set; }
        public Nullable<int> Address_Number { get; set; }
        public Nullable<double> TotalArea { get; set; }
        public Nullable<int> Rooms { get; set; }
        public Nullable<int> Floor { get; set; }
        public Nullable<decimal> Price { get; set; }
    
        public virtual Clients Clients { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Deal> Deal { get; set; }
        public virtual RealEstate RealEstate { get; set; }
    }
}
