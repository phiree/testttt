select t.ProductCode,dj.Name, * from Ticket t,DJ_TourEnterprise dj
where t.Scenic_id=dj.Id