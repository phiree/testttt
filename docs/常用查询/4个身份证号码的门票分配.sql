
select
dj.Name,* from TicketAssign ta ,OrderDetail detail,
TicketPrice tp,Ticket t,DJ_TourEnterprise dj
where ta.IdCard='321323198502020910'
and ta.OrderDetail_id=detail.Id
and detail.TicketPrice_id=tp.Id
and tp.Ticket_id=t.Id
and t.Scenic_id=dj.Id

select t

update TicketAssign 
dj.Name,* from TicketAssign ta ,OrderDetail detail,
TicketPrice tp,Ticket t,DJ_TourEnterprise dj
where ta.IdCard='330106195407052420'
and ta.OrderDetail_id=detail.Id
and detail.TicketPrice_id=tp.Id
and tp.Ticket_id=t.Id
and t.Scenic_id=dj.Id
