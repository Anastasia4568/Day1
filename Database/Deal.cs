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
    
    public partial class Deal
    {
        public int Id { get; set; }
        public Nullable<int> SalesManId { get; set; }
        public Nullable<int> BuyerId { get; set; }
        public Nullable<int> AgentId { get; set; }
        public Nullable<int> ObjectDemandsId { get; set; }
        public Nullable<int> OfferId { get; set; }
        public Nullable<decimal> PriceServices { get; set; }
    
        public virtual Agents Agents { get; set; }
        public virtual Clients Clients { get; set; }
        public virtual Clients Clients1 { get; set; }
        public virtual ObjectDemands ObjectDemands { get; set; }
        public virtual Offer Offer { get; set; }
    }
}
