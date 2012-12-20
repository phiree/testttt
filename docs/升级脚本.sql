select * from dbo.DJ_TourEnterprise
select * from DJ_User_Gov
select * from DJ_User_TourEnterprise
select * from TourMembership
select * from DJ_Route
select * from dbo.DJ_TourEnterprise order by LastUpdateTime desc

--delete from DJ_Route
update DJ_TourEnterprise set CountryVeryfyState=2 where CountryVeryfyState=0
update DJ_TourEnterprise set CityVeryfyState=2 where CityVeryfyState=0
update DJ_TourEnterprise set ProvinceVeryfyState=2 where ProvinceVeryfyState=0
