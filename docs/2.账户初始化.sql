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

/****************** 3 创建一个地接社管理员 用户名djs001密码123456****************/ 
insert into TourMembership([Id]
      ,[Name]
      ,[Password]
      ,[Openid]
      ,[Opentype]) 
      values('66F15C43-97B9-47E3-BF5D-FFA65E757B32','djs001','E10ADC3949BA59ABBE56E057F20F883E',null,null)
insert into DJ_User_TourEnterprise values('66F15C43-97B9-47E3-BF5D-FFA65E757B32',438)