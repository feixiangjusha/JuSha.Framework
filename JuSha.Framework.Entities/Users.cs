
//------------------------------------------------------------------------------
// <auto-generated>
//     此代码已从模板生成。
//
//     手动更改此文件可能导致应用程序出现意外的行为。
//     如果重新生成代码，将覆盖对此文件的手动更改。
// </auto-generated>
//------------------------------------------------------------------------------


namespace JuSha.Framework.Entities
{

using System;
    using System.Collections.Generic;
    
public partial class Users
{

    public int ID { get; set; }

    public string UserName { get; set; }

    public string Password { get; set; }

    public string RealName { get; set; }

    public string Email { get; set; }

    public string Mobile { get; set; }

    public string Phone { get; set; }

    public System.DateTime CreateTime { get; set; }

    public string CreateIp { get; set; }

    public int CreateUserId { get; set; }

    public int LoginCount { get; set; }

    public System.DateTime UpdateTime { get; set; }

    public short IsDelete { get; set; }

    public short Status { get; set; }

    public Nullable<int> RoleId { get; set; }

    public string Remark { get; set; }

    public Nullable<int> IsAdmin { get; set; }

}

}
