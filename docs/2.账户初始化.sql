/*
 
 1 设置网站管理员
  
 
 */
/****************** 1 设置网站管理员******************/
 if not exists(select * from userrole where membername='admin' and rolename='siteadmin')
insert into userrole values(newid(), 'admin','SiteAdmin' )



/****************** 2 创建一个网站管理员 用户名admin密码123456****************/ 
insert into TourMembership([Id]
      ,[Name]
      ,[Password]
      ,[Openid]
      ,[Opentype]) 
      values(NEWID(),'admin','E10ADC3949BA59ABBE56E057F20F883E',null,null)
select Id from TourMembership where Name='admin' and Password='E10ADC3949BA59ABBE56E057F20F883E'