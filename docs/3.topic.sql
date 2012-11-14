if  exists(select * from Topic )
begin
 print 'WARNING:topic表已经有数据,请手动执行'
end
else

begin

insert into topic(id,name,seoname) values('CBECBDEC-3747-462F-B7DC-54A52E1DE066','山水','shanshui')
insert into topic(id,name,seoname) values('5013C5DA-5BF9-4CF2-B8D6-DA4E60131CE6','人文史迹','renwenshiji')
insert into topic(id,name,seoname) values('3B9509F4-E1AA-4C7F-9475-16B4A2E270A7','遗址','yizhi')
insert into topic(id,name,seoname) values('E91CA17F-28F6-4790-8955-221C22C906C5','生态旅游','shangtailvyou')
insert into topic(id,name,seoname) values('A66A7FC7-9012-477D-9BCA-FE53FFF88ECB','森林瀑布','senlinpubu')
insert into topic(id,name,seoname) values('77E9F8CA-B572-4C3E-B4D9-9FF629296955','温泉','wenquan')
insert into topic(id,name,seoname) values('6F684B4B-38EA-4265-8980-7FA65974AF80','漂流','piaoliu')
insert into topic(id,name,seoname) values('7A6BB190-0F9E-4D50-BD76-54E42A3A87B8','水上乐园','shuishangleyuan')
insert into topic(id,name,seoname) values('5031A39D-C8A7-4FBD-B384-1CF178497D53','森林公园','senlingongyuan')
insert into topic(id,name,seoname) values('07201C6A-7494-49EF-8FD8-28680320382D','人文','renwen')
insert into topic(id,name,seoname) values('8EAB39F7-A888-49AA-993C-7750CA97C0FC','自然景观','ziranjingguan')
insert into topic(id,name,seoname) values('7CDE0A96-0BA0-4ACD-A5F4-ACE17DDCDC48','寺庙','simiao')
insert into topic(id,name,seoname) values('AF59E8ED-CE74-4111-8FDB-E770D53525B7','民俗风情','minsufengqing')
insert into topic(id,name,seoname) values('1A5B1824-29D1-490F-AC24-7C470473F66D','原始森林','yuanshisenlin')
insert into topic(id,name,seoname) values('444297D6-BABC-48A7-8901-247A3E1A95DD','森林','senlin')
insert into topic(id,name,seoname) values('A9451382-7E02-42DB-9C1C-BAE087C07763','拓展','tuozhan')
insert into topic(id,name,seoname) values('A220820B-9B8B-4D9C-94FE-A8B6A1126BB4','登山','dengshan')
insert into topic(id,name,seoname) values('BF219E69-697F-45E4-9AF3-4ECCAD659C94','乐园','leyuan')
end
