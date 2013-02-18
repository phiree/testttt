
drop table #tempall
--1 删除重复数据 
select 
 NEWID() as id
,od.Id orderid
,detail.Id orderdetailid
,ta.Id ticketassignid
,activity.ActivityCode
,od.OrderFrom
,t.ProductCode
,ta.IdCard
,ta.Name,
'' as phone
, od.BuyTime
 ,1 as syncstate 
into  #tempAll
from 
TicketAssign ta
,OrderDetail  detail
 , [Order] od
,TicketPrice tp
,Ticket t
,DJ_TourEnterprise dj
,TourActivity activity
where ta.OrderDetail_id=detail.Id
and detail.Order_id=od.Id
and detail.TicketPrice_id=tp.Id 
and tp.Ticket_id=t.Id
and t.Scenic_id=dj.id
and t.TourActivity_id=activity.Id

declare @activitycode varchar(20)
select @activitycode='suichang2013'

--遂昌的重复数据:
--重复的身份证号

select  min(orderid),a.idcard from #tempall a
inner join 
(
select COUNT(idcard) as c ,idcard from #tempall 
where 
activitycode=@activitycode
group by idcard
having COUNT(idcard)>1
) as mutiIdCardNo
on a.idcard=mutiIdCardNo.idcard and a.idcard=mutiIdCardNo.idcard



