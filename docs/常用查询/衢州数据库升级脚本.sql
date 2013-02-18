/*
a 门票分配修改
----------------------------------------------------------------程序自己添加
 1 合作单位 将合作单位放入 一个 activitylist
 -- 1) 创建一个活动 得到@id

-- 2) 将现有合作商插入到activitypartner表
*/
declare @activityid varchar(100)
select @activityid='159477B2-04C7-48AD-BB02-A15A011CF16A'
insert into ActivityTicketAssign 
select 
NEWID() as id
,pta.AsignedAmount as assignedamount
,ta.Date as dateassign
,ta.SoldAmount
,ap.Id as Partner_Id
,ta.Ticket_id,@activityid
 from QZTicketAsign ta
 ,QZPartnerTicketAsign pta
 ,ActivityPartner ap,
 QZSpringPartner sp
where pta.QZTicketAsign_id=ta.Id
 and ap.PartnerCode=sp.FriendlyId
  and pta.Partner_id=sp.Id

select * from QZSpringPartner 
select * from QZPartnerTicketAsign
select * from QZTicketAsign
select * from ActivityTicketAssign
select * from ActivityPartner

--------------------------------------------------------------------程序:修改onlycontrolamount

/*
2 门票格式修改

*/
 insert into TicketNormal (Ticket_id,MipangId)
 select Id,MipangId from Ticket
 alter table ticket drop column mipangid
update Ticket set Enabled=1
 go
 
 /*3
 将ticketassign里面的 ticketcode更新一下
 */
 
 update TicketAssign   
 set TicketCode=t.ProductCode
 --select t.ProductCode,ta.*
 from TicketAssign ta, OrderDetail detail,TicketPrice tp,Ticket t
 where ta.OrderDetail_id=detail.Id and detail.TicketPrice_id=tp.Id
 and tp.Ticket_id=t.Id


