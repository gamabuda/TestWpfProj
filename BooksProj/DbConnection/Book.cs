//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace BooksProj.DbConnection
{
    using System;
    using System.Collections.Generic;
    
    public partial class Book
    {
        public int ID_Book { get; set; }
        public string Title { get; set; }
        public decimal Price { get; set; }
        public string Writer { get; set; }
        public int ID_Genre { get; set; }
    
        public virtual Genre Genre { get; set; }
    }
}
