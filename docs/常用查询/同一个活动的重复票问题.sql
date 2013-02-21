/*
未完成
获取一个idcard在某次活动中获取的总票数
*/
select COUNT(ta.IdCard) as c,ta.IdCard 
,act.ActivityCode 
from TicketAssign ta,OrderDetail detail
,TicketPrice tp,Ticket t,TourActivity act
where ta.OrderDetail_id=detail.Id and detail.TicketPrice_id=tp.Id and tp.Ticket_id=t.Id
and t.TourActivity_id=act.Id group by act.ActivityCode,ta.IdCard
order by c desc


