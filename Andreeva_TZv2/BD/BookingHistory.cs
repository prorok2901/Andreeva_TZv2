//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Andreeva_TZv2.BD
{
    using System;
    using System.Collections.Generic;
    
    public partial class BookingHistory
    {
        public int ID { get; set; }
        public int borrowRoom { get; set; }
        public System.DateTime DepartureDate { get; set; }
        public string Cause { get; set; }
    
        public virtual BorrowRoom BorrowRoom1 { get; set; }
    }
}
