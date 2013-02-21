--删除身份证的订票信息

select * from TicketAssign ta,OrderDetail detail, [Order] od where 
ta.OrderDetail_id=detail.Id 
and detail.Order_id=od.Id
and
 IdCard in ('332501196304050031','332521196509100026')

delete from TicketAssign where Id in 
(
'A1E491E9-BF83-403B-BD25-A15C0165210C',
'19126F0C-B046-4A04-8C04-A15C01652110',
'2BCD340E-ACF5-4F7D-BC59-A15C01652114',
'C0A7E353-336B-447B-A81E-A15C0165CAE3',
'9F542CB8-3F41-4F6A-8550-A15C0165CAEE',
'CDDDA580-DEB8-4AA9-BB80-A15C0165CAF1'
)
delete from OrderDetail where  id in 
(
 101908,
101909,
101910,
101918,
101919,
101920
)
delete from [Order] where  Id in  
(
79244756,
2137995596
)


