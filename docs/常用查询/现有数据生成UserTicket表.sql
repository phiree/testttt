drop table tblActivitySync



select top 100
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
--into  tblActivitySync 
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


