//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WPFProjectDB.DataBaseConnection
{
    using System;
    using System.Collections.Generic;
    
    public partial class Users
    {
        public int User_id { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public string Username { get; set; }
        public byte[] UserImage { get; set; }
        public Nullable<int> Role_id { get; set; }
    
        public virtual UserRole UserRole { get; set; }
    }
}
