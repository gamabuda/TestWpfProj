//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WpfProj.Framework.DbConnection
{
    using System;
    using System.Collections.Generic;
    
    public partial class Meme
    {
        public string ID { get; set; }
        public string Title { get; set; }
        public decimal Price { get; set; }
        public byte[] Photo { get; set; }
        public string MemeTypeID { get; set; }
    
        public virtual MemeType MemeType { get; set; }
    }
}
