 Select a.Quantity From OrderDetail a,TicketAssign b
  where a.id = b.OrderDetail_id and b.IdCard ='330802198810203619'
  
 @IDCard Varchar(50),		--身份证
  @RealName VarChar(50),	--姓名
  @Phone Varchar(50),		--电话
  @ActivityID uniqueidentifier,--活动代码
  @PartnerID  uniqueidentifier, --合作商代码
  @ProductCode VarChar(100),    --门票代码
  @ReqAmount int,				--请求门票的数量
  @Remark VarChar(255)			--备注(订单详情)
exec usp_TicketRequest '330106195505170420','realname','phone','0bc9afba-7a45-4f7b-a04f-a15b00555574',
'f9921999-6b47-4674-9fad-a15c00d85caf','suichangdalibao2',1,''

select * from TicketAssign where IdCard='330106195505170420'


Select AssignedAmount - SoldAmount, *
    From ActivityTicketAssign 
    where TourActivity_id='0bc9afba-7a45-4f7b-a04f-a15b00555574' 
    and Partner_id='f9921999-6b47-4674-9fad-a15c00d85caf' 
    and Convert(Varchar(10),DateAssign,120)=CONVERT(VarChar(10),GETDATE(),120)
    select count(Quantity),Quantity from OrderDetail group by Quantity
    
    declare @c int
     Select @c= case a.Quantity when null then 0 end From OrderDetail a,TicketAssign b
  where a.Id=  b.OrderDetail_id and b.IdCard = '330106195505170420' and a.TicketPrice_id = 123
  
  select ISNULL(@c,0)  