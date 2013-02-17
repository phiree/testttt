select * from TicketAssign ta, OrderDetail detail, TicketPrice tp,[Order] od, Ticket t,DJ_TourEnterprise dj

where ta.OrderDetail_id=detail.Id and detail.Order_id=od.Id
and detail.TicketPrice_id=tp.Id and tp.Ticket_id=t.Id
and t.Scenic_id=dj.Id
and ta.IdCard  in(
'360402198404242712',
'362103198307090843',
'360782198812103349',
'360782198609103394'

)

select COUNT(*) from TicketAssign  
--ÇÀÆ±
select count(*) as amount,
dj.name,
t.TourActivity_id from TicketAssign ta, OrderDetail detail, TicketPrice tp,[Order] od, Ticket t,
DJ_TourEnterprise dj

where ta.OrderDetail_id=detail.Id and detail.Order_id=od.Id
and detail.TicketPrice_id=tp.Id and tp.Ticket_id=t.Id
and t.Scenic_id=dj.Id
and ta.IsUsed=1
group by
 dj.name, 
 t.TourActivity_id
  order by t.TourActivity_id, amount desc
--yanpiao
select count(*) as amount,dj.name,t.TourActivity_id from TicketAssign ta,
 OrderDetail detail, TicketPrice tp,[Order] od, Ticket t,DJ_TourEnterprise dj

where ta.OrderDetail_id=detail.Id and detail.Order_id=od.Id
and detail.TicketPrice_id=tp.Id and tp.Ticket_id=t.Id
and t.Scenic_id=dj.Id and ta.IsUsed=1

group by dj.name ,t.TourActivity_id order by t.TourActivity_id, amount desc



