  
  
  INSERT [TourOnline].[dbo].[DJ_TourEnterprise] 
  ([Name],[Address],[ChargePersonName],[ChargePersonPhone],[Phone],[Type],[Area_id])
  VALUES
  ('旭日旅行社','杭州市西湖区','陈旭日','15988880000','0571-88886666',5,'1019')


--团队信息
insert into DJ_TourEnterprise values('杭州地接社','西溪路358号','老王','330203515695','874569253',1,5,1019)
insert into DJ_dijiesheInfo values(438)
insert into DJ_TourGroup values('e4fd78ba-9ed6-49a4-9331-66f93d4f85b7','浙江杭州三日游','2012-10-7','2012-10-9',3,20,3,438)
insert into DJ_Group_Worker values(newid(),'330203198705265484','徐老六','18992548675','54786523q',1,'e4fd78ba-9ed6-49a4-9331-66f93d4f85b7')
insert into DJ_Route values(newid(),1,8,15,'参观江郎山景区',435,null,'e4fd78ba-9ed6-49a4-9331-66f93d4f85b7')


  --2012-10-16  杭州乌镇绍兴四日游 模拟数据
  --餐厅
  INSERT INTO [TourOnline].[dbo].[DJ_TourEnterprise](
  [Name],[Address],[ChargePersonName],[ChargePersonPhone],[Phone],[IsVeryfied],[Type],[Area_id])
  VALUES(
  '外婆家','杭州市西湖区','陈杭州','13877885211','0571-59876459',1,2,1019)
  INSERT INTO [TourOnline].[dbo].[DJ_TourEnterprise](
  [Name],[Address],[ChargePersonName],[ChargePersonPhone],[Phone],[IsVeryfied],[Type],[Area_id])
  VALUES(
  '伊家鲜','杭州市西湖区','陈绍兴','13877885211','0573-59876459',1,2,1076)
  INSERT INTO [TourOnline].[dbo].[DJ_TourEnterprise](
  [Name],[Address],[ChargePersonName],[ChargePersonPhone],[Phone],[IsVeryfied],[Type],[Area_id])
  VALUES(
  '干锅居','杭州市西湖区','陈杭州','13877885211','0571-59876459',1,2,1019)
  INSERT INTO [TourOnline].[dbo].[DJ_TourEnterprise](
  [Name],[Address],[ChargePersonName],[ChargePersonPhone],[Phone],[IsVeryfied],[Type],[Area_id])
  VALUES(
  '川味观','杭州市西湖区','陈杭州','13877885211','0571-59876459',1,2,1019)
  INSERT INTO [TourOnline].[dbo].[DJ_TourEnterprise](
  [Name],[Address],[ChargePersonName],[ChargePersonPhone],[Phone],[IsVeryfied],[Type],[Area_id])
  VALUES(
  '胡庆余堂药膳','杭州市西湖区','陈杭州','13877885211','0571-59876459',1,2,1019)
  INSERT INTO [TourOnline].[dbo].[DJ_TourEnterprise](
  [Name],[Address],[ChargePersonName],[ChargePersonPhone],[Phone],[IsVeryfied],[Type],[Area_id])
  VALUES(
  '如家快捷酒店','杭州市西湖区','陈杭州','13877885211','0571-59876459',1,2,1019)
  INSERT INTO [TourOnline].[dbo].[DJ_TourEnterprise](
  [Name],[Address],[ChargePersonName],[ChargePersonPhone],[Phone],[IsVeryfied],[Type],[Area_id])
  VALUES(
  '梅家坞农家','杭州市西湖区','陈杭州','13877885211','0571-59876459',1,2,1019)
  INSERT INTO [TourOnline].[dbo].[DJ_TourEnterprise](
  [Name],[Address],[ChargePersonName],[ChargePersonPhone],[Phone],[IsVeryfied],[Type],[Area_id])
  VALUES(
  '乌镇农家乐','杭州市西湖区','陈杭州','13877885211','0571-59876459',1,2,1060)
  INSERT INTO [TourOnline].[dbo].[DJ_TourEnterprise](
  [Name],[Address],[ChargePersonName],[ChargePersonPhone],[Phone],[IsVeryfied],[Type],[Area_id])
  VALUES(
  '乌镇客栈','杭州市西湖区','陈杭州','13877885211','0571-59876459',1,2,1060)
  
  --景点
  INSERT INTO [TourOnline].[dbo].[DJ_TourEnterprise](
  [Name],[Address],[ChargePersonName],[ChargePersonPhone],[Phone],[IsVeryfied],[Type],[Area_id])
  VALUES(
  '西栅景区','杭州市西湖区','陈西栅','13877885211','0571-59876459',1,1,1019)
  INSERT INTO [TourOnline].[dbo].[DJ_TourEnterprise](
  [Name],[Address],[ChargePersonName],[ChargePersonPhone],[Phone],[IsVeryfied],[Type],[Area_id])
  VALUES(
  '鲁迅故里','杭州市西湖区','陈鲁迅','13877885211','0571-59876459',1,1,1076)
  INSERT INTO [TourOnline].[dbo].[DJ_TourEnterprise](
  [Name],[Address],[ChargePersonName],[ChargePersonPhone],[Phone],[IsVeryfied],[Type],[Area_id])
  VALUES(
  '沈园','杭州市西湖区','陈近南','13877885211','0571-59876459',1,1,1076)
  INSERT INTO [TourOnline].[dbo].[DJ_TourEnterprise](
  [Name],[Address],[ChargePersonName],[ChargePersonPhone],[Phone],[IsVeryfied],[Type],[Area_id])
  VALUES(
  '兰亭','杭州市西湖区','陈近南','13877885211','0571-59876459',1,1,1076)
  INSERT INTO [TourOnline].[dbo].[DJ_TourEnterprise](
  [Name],[Address],[ChargePersonName],[ChargePersonPhone],[Phone],[IsVeryfied],[Type],[Area_id])
  VALUES(
  '船游西湖','杭州市西湖区','陈船游','13877885211','0571-59876459',1,1,1019)
  INSERT INTO [TourOnline].[dbo].[DJ_TourEnterprise](
  [Name],[Address],[ChargePersonName],[ChargePersonPhone],[Phone],[IsVeryfied],[Type],[Area_id])
  VALUES(
  '花港观鱼','杭州市西湖区','陈华冈','13877885211','0571-59876459',1,1,1019)
  INSERT INTO [TourOnline].[dbo].[DJ_TourEnterprise](
  [Name],[Address],[ChargePersonName],[ChargePersonPhone],[Phone],[IsVeryfied],[Type],[Area_id])
  VALUES(
  '苏提春晓','杭州市西湖区','陈速递','13877885211','0571-59876459',1,1,1019)
  INSERT INTO [TourOnline].[dbo].[DJ_TourEnterprise](
  [Name],[Address],[ChargePersonName],[ChargePersonPhone],[Phone],[IsVeryfied],[Type],[Area_id])
  VALUES(
  '龙井问茶','杭州市西湖区','陈龙井','13877885211','0571-59876459',1,1,1019)
  INSERT INTO [TourOnline].[dbo].[DJ_TourEnterprise](
  [Name],[Address],[ChargePersonName],[ChargePersonPhone],[Phone],[IsVeryfied],[Type],[Area_id])
  VALUES(
  '六合塔','杭州市西湖区','陈六合','13877885211','0571-59876459',1,1,1019)
  INSERT INTO [TourOnline].[dbo].[DJ_TourEnterprise](
  [Name],[Address],[ChargePersonName],[ChargePersonPhone],[Phone],[IsVeryfied],[Type],[Area_id])
  VALUES(
  '飞来峰','杭州市西湖区','陈飞来','13877885211','0571-59876459',1,1,1019)

  --景点scenic
  INSERT INTO [TourOnline].[dbo].[Scenic](
  [DJ_TourEnterprise_id],[IsHide],[Name],[Address],[ScenicOrder],[Level],[Photo],[Trafficintro],[ScenicDetail]
      ,[Desec],[Position],[SeoName],[BookNote],[TransGuid],[Area_id])
  VALUES(
  454,0,'西栅景区','杭州市西湖区','0','5A',NULL,'TRAFFIC','DETAIL',
  'DESC','118.489189,28.296525','xizhajingqu','','',1060)
  INSERT INTO [TourOnline].[dbo].[Scenic](
  [DJ_TourEnterprise_id],[IsHide],[Name],[Address],[ScenicOrder],[Level],[Photo],[Trafficintro],[ScenicDetail]
      ,[Desec],[Position],[SeoName],[BookNote],[TransGuid],[Area_id])
  VALUES(
  455,0,'鲁迅故里','杭州市西湖区','0','5A',NULL,'TRAFFIC','DETAIL',
  'DESC','118.489189,28.296525','xizhajingqu','','',1076)
  INSERT INTO [TourOnline].[dbo].[Scenic](
  [DJ_TourEnterprise_id],[IsHide],[Name],[Address],[ScenicOrder],[Level],[Photo],[Trafficintro],[ScenicDetail]
      ,[Desec],[Position],[SeoName],[BookNote],[TransGuid],[Area_id])
  VALUES(
  456,0,'沈园','杭州市西湖区','0','5A',NULL,'TRAFFIC','DETAIL',
  'DESC','118.489189,28.296525','xizhajingqu','','',1076)
  INSERT INTO [TourOnline].[dbo].[Scenic](
  [DJ_TourEnterprise_id],[IsHide],[Name],[Address],[ScenicOrder],[Level],[Photo],[Trafficintro],[ScenicDetail]
      ,[Desec],[Position],[SeoName],[BookNote],[TransGuid],[Area_id])
  VALUES(
  457,0,'兰亭','杭州市西湖区','0','5A',NULL,'TRAFFIC','DETAIL',
  'DESC','118.489189,28.296525','xizhajingqu','','',1076)
  INSERT INTO [TourOnline].[dbo].[Scenic](
  [DJ_TourEnterprise_id],[IsHide],[Name],[Address],[ScenicOrder],[Level],[Photo],[Trafficintro],[ScenicDetail]
      ,[Desec],[Position],[SeoName],[BookNote],[TransGuid],[Area_id])
  VALUES(
  458,0,'船游西湖','杭州市西湖区','0','5A',NULL,'TRAFFIC','DETAIL',
  'DESC','118.489189,28.296525','xizhajingqu','','',1019)
  INSERT INTO [TourOnline].[dbo].[Scenic](
  [DJ_TourEnterprise_id],[IsHide],[Name],[Address],[ScenicOrder],[Level],[Photo],[Trafficintro],[ScenicDetail]
      ,[Desec],[Position],[SeoName],[BookNote],[TransGuid],[Area_id])
  VALUES(
  459,0,'花港观鱼','杭州市西湖区','0','5A',NULL,'TRAFFIC','DETAIL',
  'DESC','118.489189,28.296525','xizhajingqu','','',1019)
  INSERT INTO [TourOnline].[dbo].[Scenic](
  [DJ_TourEnterprise_id],[IsHide],[Name],[Address],[ScenicOrder],[Level],[Photo],[Trafficintro],[ScenicDetail]
      ,[Desec],[Position],[SeoName],[BookNote],[TransGuid],[Area_id])
  VALUES(
  460,0,'苏提春晓','杭州市西湖区','0','5A',NULL,'TRAFFIC','DETAIL',
  'DESC','118.489189,28.296525','xizhajingqu','','',1019)
  INSERT INTO [TourOnline].[dbo].[Scenic](
  [DJ_TourEnterprise_id],[IsHide],[Name],[Address],[ScenicOrder],[Level],[Photo],[Trafficintro],[ScenicDetail]
      ,[Desec],[Position],[SeoName],[BookNote],[TransGuid],[Area_id])
  VALUES(
  461,0,'龙井问茶','杭州市西湖区','0','5A',NULL,'TRAFFIC','DETAIL',
  'DESC','118.489189,28.296525','xizhajingqu','','',1019)
  INSERT INTO [TourOnline].[dbo].[Scenic](
  [DJ_TourEnterprise_id],[IsHide],[Name],[Address],[ScenicOrder],[Level],[Photo],[Trafficintro],[ScenicDetail]
      ,[Desec],[Position],[SeoName],[BookNote],[TransGuid],[Area_id])
  VALUES(
  462,0,'六合塔','杭州市西湖区','0','5A',NULL,'TRAFFIC','DETAIL',
  'DESC','118.489189,28.296525','xizhajingqu','','',1019)
  INSERT INTO [TourOnline].[dbo].[Scenic](
  [DJ_TourEnterprise_id],[IsHide],[Name],[Address],[ScenicOrder],[Level],[Photo],[Trafficintro],[ScenicDetail]
      ,[Desec],[Position],[SeoName],[BookNote],[TransGuid],[Area_id])
  VALUES(
  463,0,'飞来峰','杭州市西湖区','0','5A',NULL,'TRAFFIC','DETAIL',
  'DESC','118.489189,28.296525','xizhajingqu','','',1019)

  --住宿
  INSERT INTO [TourOnline].[dbo].[DJ_TourEnterprise](
  [Name],[Address],[ChargePersonName],[ChargePersonPhone],[Phone],[IsVeryfied],[Type],[Area_id])
  VALUES(
  '乌镇客栈','杭州市西湖区','陈乌镇','13877885211','0571-59876459',1,3,1060)
  INSERT INTO [TourOnline].[dbo].[DJ_TourEnterprise](
  [Name],[Address],[ChargePersonName],[ChargePersonPhone],[Phone],[IsVeryfied],[Type],[Area_id])
  VALUES(
  '如家快捷酒店','杭州市西湖区','陈如家','13877885211','0571-59876459',1,3,1019)

