  
  
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

  INSERT INTO [TourOnline].[dbo].[DJ_TourEnterprise](
  [Name],[Address],[ChargePersonName],[ChargePersonPhone],[Phone],[IsVeryfied],[Type],[Area_id])
  VALUES(
  '妈妈家','杭州市西湖区','陈近南','13877885211','0571-59876459',1,2,1019)
  INSERT INTO [TourOnline].[dbo].[DJ_TourEnterprise](
  [Name],[Address],[ChargePersonName],[ChargePersonPhone],[Phone],[IsVeryfied],[Type],[Area_id])
  VALUES(
  '外公家','杭州市西湖区','陈近南','13877885211','0571-59876459',1,2,1019)
  INSERT INTO [TourOnline].[dbo].[DJ_TourEnterprise](
  [Name],[Address],[ChargePersonName],[ChargePersonPhone],[Phone],[IsVeryfied],[Type],[Area_id])
  VALUES(
  '外婆家','杭州市西湖区','陈近南','13877885211','0571-59876459',1,2,1019)
  INSERT INTO [TourOnline].[dbo].[DJ_TourEnterprise](
  [Name],[Address],[ChargePersonName],[ChargePersonPhone],[Phone],[IsVeryfied],[Type],[Area_id])
  VALUES(
  '希尔顿酒店','杭州市西湖区','陈近南','13877885211','0571-59876459',1,3,1019)
  INSERT INTO [TourOnline].[dbo].[DJ_TourEnterprise](
  [Name],[Address],[ChargePersonName],[ChargePersonPhone],[Phone],[IsVeryfied],[Type],[Area_id])
  VALUES(
  '如家快捷酒店','杭州市西湖区','陈近南','13877885211','0571-59876459',1,3,1019)
  INSERT INTO [TourOnline].[dbo].[DJ_TourEnterprise](
  [Name],[Address],[ChargePersonName],[ChargePersonPhone],[Phone],[IsVeryfied],[Type],[Area_id])
  VALUES(
  '杭州丝绸土特产','杭州市西湖区','陈近南','13877885211','0571-59876459',1,4,1019)
  INSERT INTO [TourOnline].[dbo].[DJ_TourEnterprise](
  [Name],[Address],[ChargePersonName],[ChargePersonPhone],[Phone],[IsVeryfied],[Type],[Area_id])
  VALUES(
  '龙井茶旗舰店','杭州市西湖区','陈近南','13877885211','0571-59876459',1,4,1019)