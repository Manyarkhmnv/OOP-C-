
select json_build_object(
	'Users', json_agg(
		json_build_object('fname', u."Fullname", 'id', u."Id", 'Pin', u."Pin",
			'Balance',  ( 
				select json_agg(
		 					json_build_object(
		 						'id', uo."Id", 'balance', uo."Balance",
		 						'Operations', (
		 							select json_agg(
		 								json_build_object(
		 									'id', o."Id",
		 									'operationName', o."Operation_name",
		 									'Amount', o."Amount"
		 								)
		 							) from "Operations" o  where uo."Id" = o."Order_id"
		 						)
		 				)
		 		) from "UserOrder" uo  where u."Id" = uo."User_ID"
		 
		 	) 
		)
	)
) from "Users" u;
;


select "User_ID" 
from "UserOrder" uo ;

select json_build_object(
	'Users', json_agg(
		json_build_object('fname', u."Fullname", 'id', u."Id", 'Pin', u."Pin", 'Balances',  
			(select json_agg(
		 		json_build_object(
		 			'id', uo.Id, 'balance', uo."Balance" , 'Operations', 
		 				(select json_agg(
		 					json_build_object(
		 						'id', o.Id, 'operation_name', o."Operation_name"
		 									)
		 								)
		 				) from "Operations" o  where o.Order_id = uo."Id"
		 						)
		 					)
		 	)
		 	from "UserOrder" uo  where u."Id" = uo."User_ID"
		 
		 				)
		 			)
						) from "Users" u;

					
					
					
					
					
					
					
					
					
					
					
					
select json_build_object('Users', json_agg( json_build_object('fname', u."Fullname", 'id', u."Id", 'Pin', u."Pin")))from "Users" u;

					
		//string sql = "select json_build_object(\n\t'Clients', json_agg(\n\t\tjson_build_object('Fullname', u.\"Fullname\", 'Id', u.\"Id\", 'Pin', u.\"Pin\",\n\t\t\t'Orders',  ( \n\t\t\t\tselect json_agg(\n\t\t \t\t\t\t\tjson_build_object(\n\t\t \t\t\t\t\t\t'Id', uo.\"Id\", 'Balance', uo.\"Balance\",\n\t\t \t\t\t\t\t\t'Operations', (\n\t\t \t\t\t\t\t\t\tselect json_agg(\n\t\t \t\t\t\t\t\t\t\tjson_build_object(\n\t\t \t\t\t\t\t\t\t\t\t'Id', o.\"Id\",\n\t\t \t\t\t\t\t\t\t\t\t'OperationName', o.\"Operation_name\",\n\t\t \t\t\t\t\t\t\t\t\t'Amount', o.\"Amount\"\n\t\t \t\t\t\t\t\t\t\t)\n\t\t \t\t\t\t\t\t\t) from \"Operations\" o  where uo.\"Id\" = o.\"Order_id\"\n\t\t \t\t\t\t\t\t)\n\t\t \t\t\t\t)\n\t\t \t\t) from \"UserOrder\" uo  where u.\"Id\" = uo.\"User_ID\"\n\t\t \n\t\t \t) \n\t\t)\n\t)\n) from \"Users\" u;\n;";
			
					
					
select json_build_object('Id', uo."Id", 'UserId', uo."User_ID", 'Balance', uo."Balance", 'OrderNumber', uo."Order_number")
from "UserOrder" uo 
where uo."Order_number" = '77-242-2856';
--
--- создание счета
--- просмотр баланса счета +




 insert into "UserOrder"  ("User_ID", "Balance", "Order_number") values (11, 1, '33-444-5555');

select * from "UserOrder" uo ;


ALTER TABLE "UserOrder"
ADD UNIQUE ("Order_number"); 

--- просмотр истории операций					
--					
					
					
			select json_build_object('Id', uo."Id", 'UserId', uo."User_ID", 'Balance', uo."Balance", 'OrderNumber', uo."Order_number")from "UserOrder" uo where uo."Order_number" =  '77-242-2856';		
					
					
					
					
            select json_build_object( 'OrderNumber', uo."Order_number", 'Operations', (select json_agg(json_build_object('id', o."Id",'operationName', o."Operation_name",'Amount', o."Amount")) from "Operations" o  where uo."Id" = o."Order_id"))from "UserOrder" uo  where uo."Order_number" = '77-242-2856';
					
					
					
select json_build_object('Id', u."Id", 'Fullname', u."Fullname" , 'Pin', u."Pin")  from "Users" u 
where u."Fullname" = 'Humberto Walls' and u."Pin" = '7891';
					
					

update "UserOrder" set "Balance" = {0} where "UserOrder"."Id" = {1};					
					
select json_build_object( 'OrderId', uo."Id" , 'OrderUserId', uo."User_ID"  , 'OrderNumber', uo."Order_number", 'OrderBalance', uo."Balance", 'OrderOperations', (select json_agg(json_build_object('OperationId', o."Id",'OperationFullname', o."Operation_name",'OperationAmount', o."Amount")) from "Operations" o  where uo."Id" = o."Order_id"))from "UserOrder" uo  where uo."Order_number" = '77-242-2856';
					
select json_build_object( 'OrderId', uo."Id" , 'OrderUserId', uo."User_ID"  , 'OrderNumber', uo."Order_number", 'OrderBalance', uo."Balance", 'OrderOperations', (select json_agg(json_build_object('O
perationId', o."Id",'OperationFullname', o."Operation_name",'OperationAmount', o."Amount")) from "Operations" o  where uo."Id" = o."Order_id"))from "UserOrder" uo  where uo."Order_number" = '77-242-2856';					
					
select json_build_object( 'OrderId', uo."Id" , 'OrderUserId', uo."User_ID"  , 'OrderNumber', uo."Order_number", 'OrderBalance', uo."Balance", 'OrderOperations', (select json_agg(json_build_object('OperationId', o."Id",'OperationFullname', o."Operation_name",'OperationAmount', o."Amount")) from "Operations" o  where uo."Id" = o."Order_id"))from "UserOrder" uo  where uo."Order_number" = '77-242-2856';
					
select * from "UserOrder" uo 
join "Operations" o 
on uo."Id" = o."Order_id"   where uo."Order_number" = '77-242-2856';




select json_build_object( 'OrderId', uo."Id" , 'OrderUserId', uo."User_ID"  , 'OrderNumber', uo."Order_number", 'OrderBalance', uo."Balance", 'OrderOperations', (select json_agg(json_build_object('OperationId', o."Id",'OperationFullname', o."Operation_name",'OperationAmount', o."Amount")) from "Operations" o  where uo."Id" = o."Order_id"))from "UserOrder" uo  where uo."Order_number" = '77-242-2856'; 
insert into "Operations" 
select ("Order_id", "Operation_name", "Amount")  values ('77-242-2856', 'history', 0);

select o."Order_id"  from "Operations" o 
join "UserOrder" uo 
on uo."Id" = o."Order_id" 
where uo."Order_number" = '77-242-2856';

 -- view balance +

create or replace function view_balance( OrderNumber text ) 
returns table (txt text) as $$
	select json_build_object('OrderId', uo."Id", 'UserId', uo."User_ID", 'OrderBalance', uo."Balance", 'OrderNumber', uo."Order_number")from "UserOrder" uo where uo."Order_number" = OrderNumber;
	
$$ language sql;

select view_balance('77-242-2856');

select json_build_object('OrderId', uo."Id", 'UserId', uo."User_ID", 'OrderBalance', uo."Balance", 'OrderNumber', uo."Order_number")from "UserOrder" uo where uo."Order_number" = '77-242-2856';

-- view operations +
----------------------------
create or replace function view_operations( OrderNumber text ) 
returns table (txt text) as $$
	insert into "Operations" ("Order_id", "Operation_name", "Amount")  values ((select uo."Id"  from "UserOrder" uo where uo."Order_number" = OrderNumber limit 1), 'history', 0);
select json_build_object( 'OrderId', uo."Id" , 'OrderUserId', uo."User_ID"  , 'OrderNumber', uo."Order_number", 'OrderBalance', uo."Balance", 'OrderOperations', (select json_agg(json_build_object('OperationId', o."Id",'OperationFullname', o."Operation_name",'OperationAmount', o."Amount")) from "Operations" o  where uo."Id" = o."Order_id"))from "UserOrder" uo  where uo."Order_number" = OrderNumber; 
	
$$ language sql;

select view_operations('77-242-2856');
 --------------------------

select *
from "Operations" o 
where o."Order_id" = (select uo."Id"  from "UserOrder" uo where uo."Order_number" = '77-242-2856');


insert into "Operations" ("Order_id", "Operation_name", "Amount")  values ((select uo."Id"  from "UserOrder" uo where uo."Order_number" = '77-242-2856' limit 1), 'history', 0);
select json_build_object( 'OrderId', uo."Id" , 'OrderUserId', uo."User_ID"  , 'OrderNumber', uo."Order_number", 'OrderBalance', uo."Balance", 'OrderOperations', (select json_agg(json_build_object('OperationId', o."Id",'OperationFullname', o."Operation_name",'OperationAmount', o."Amount")) from "Operations" o  where uo."Id" = o."Order_id"))from "UserOrder" uo  where uo."Order_number" = '77-242-2856'; 

-- auth
create or replace function auth(UserName text, UserPin text) 
returns table (txt text) as $$
	select json_build_object('UserId', u."Id", 'UserFullname', u."Fullname" , 'UserPin', u."Pin")  from "Users" u where u."Fullname" = UserName and u."Pin" = UserPin;
$$ language sql;

select auth('Humberto Walls', '7891');
--------------------------------------------------

-----------------add

create or replace function deposite(value int, OrderNumber text) 
returns table (txt text) as $$
	update "UserOrder" 
	set "Balance" = "Balance" + value
	where "Order_number" = OrderNumber;
	insert into "Operations" ("Order_id", "Operation_name", "Amount")  values ((select uo."Id"  from "UserOrder" uo where uo."Order_number" = OrderNumber limit 1), 'deposite', value);
	select json_build_object('OperationId', o."Id", 'OperationAmount', o."Amount", 'OperationFullname', o."Operation_name") from "Operations" o 
	where o."Order_id" = (select uo."Id" from "UserOrder" uo where uo."Order_number" = OrderNumber)
	order by o."Id" desc 
	limit 1;
$$ language sql;

select deposite(50, '77-242-2856');


select json_build_object('OperationId', o."Id", 'OperationAmount', o."Amount", 'OperationFullname', o."Operation_name") from "Operations" o 
	where o."Order_id" = (select uo."Id" from "UserOrder" uo where uo."Order_number" = '77-242-2856')
	order by o."Id" desc 
	limit 1;

---------------------------- delete

create or replace function withdraw(value int, OrderNumber text) 
returns table (txt text) as $$
	update "UserOrder" 
	set "Balance" = "Balance" - value
	where "Order_number" = OrderNumber;
	insert into "Operations" ("Order_id", "Operation_name", "Amount")  values ((select uo."Id"  from "UserOrder" uo where uo."Order_number" = OrderNumber limit 1), 'withdraw', value);
	select json_build_object('OperationId', o."Id", 'OperationAmount', o."Amount", 'OperationFullname', o."Operation_name") from "Operations" o 
	where o."Order_id" = (select uo."Id" from "UserOrder" uo where uo."Order_number" = OrderNumber)
	order by o."Id" desc 
	limit 1;
$$ language sql;

select withdraw(50, '77-242-2856');



select * 
from "UserOrder" uo 
where uo."Order_number" = '77-242-2856';


---------------------------------------
------Add order

create or replace function addorder(userid int, OrderNumber text) 
returns table (txt text) as $$
	insert  into "UserOrder" ("User_ID", "Balance", "Order_number") values (userid, 0, OrderNumber);
	insert into "Operations" ("Order_id", "Operation_name", "Amount")  values ((select uo."Id"  from "UserOrder" uo where uo."Order_number" = OrderNumber limit 1), 'create', 0);
	select json_build_object('OperationId', o."Id", 'OperationAmount', o."Amount", 'OperationFullname', o."Operation_name") from "Operations" o 
	where o."Order_id" = (select uo."Id" from "UserOrder" uo where uo."Order_number" = OrderNumber)
	order by o."Id" desc 
	limit 1;
$$ language sql;

select addorder(50, '77-242-26856');


select * from "Users" u 
join "UserOrder" uo 
ON u."Id"  = uo."User_ID" 
join "Operations" o 
ON uo."Id"  = o."Order_id" 
where u."Id" = 2;








					