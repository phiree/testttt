select qz from QZPartnerTicketAsign qz
 where 1=1  and qz.QZTicketAsign.Date='2013-01-29'  
 and qz.Partner.FriendlyId='taizhou'
and qz.QZTicketAsign.Ticket.ProductCode='B5D52E0D-0A20-448C-B8C7-3A5DE7D72216'


select * from QZTicketAsign a,QZPartnerTicketAsign b,QZSpringPartner p, Ticket t
where a.Id=b.QZTicketAsign_id and a.Ticket_id=t.Id
and a.Date='2013-01-29'
and b.Partner_id=p.Id
and p.FriendlyId='taizhou' 
and t.ProductCode='B5D52E0D-0A20-448C-B8C7-3A5DE7D72216'

