﻿EF Database first模式，已做模型分离，当数据库发生改变时需要同时对JuSha.Framework.DataAccess和JuSha.Framework.Entities
中的DbEntities.edmx进行从数据库更新模型操作。更新完数据库之后还要对JuSha.Framework.DataAccess的DbEntities.Context.cs
文件添加using JuSha.Framework.Entities;引用