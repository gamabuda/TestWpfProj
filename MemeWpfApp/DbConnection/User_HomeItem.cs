//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MemeWpfApp.DbConnection
{
    using System;
    using System.Collections.Generic;
    
    public partial class User_HomeItem
    {
        public int ID { get; set; }
        public int UserID { get; set; }
        public int HomeItemID { get; set; }
    
        public virtual HomeItem HomeItem { get; set; }
        public virtual User User { get; set; }
    }
}
