
/*
默认权限全部设置为 未纳入
*/
update DJ_TourEnterprise set CountryVeryfyState=2 where CountryVeryfyState=0
update DJ_TourEnterprise set CityVeryfyState=2 where CityVeryfyState=0
update DJ_TourEnterprise set ProvinceVeryfyState=2 where ProvinceVeryfyState=0
/*修改管理部门的权限*/
  update TourMembership set PermissionType =7 
  where Id in (
   select TourMembership_id from DJ_User_Gov)
   /*给id为单数的景区划进奖励范围*/
update DJ_TourEnterprise set CountryVeryfyState=1,CityVeryfyState=1 where Id%2=1
