# Yonghyun Kim
# Defining Procedures

# ===================================================================================
# Procedure - Sell Products
# ===================================================================================
delimiter $$
drop procedure if exists sell $$ # Delete if exists
create procedure sell
(in custid_in integer, in uid_in integer, in quant_in integer, in eid_in integer)
begin
	    declare _stockquant integer;
        declare _itemid integer;
        declare _new_saleid integer;
        declare _item_price integer;
        declare _gross_total integer;
        declare exit handler for sqlexception
			begin
				rollback;
			end;
		select quant into @_stockquant from stock_view where uid = uid_in;
		select iid into @_itemid from stock where uid = uid_in;
        select count(*) into @_new_saleid from sales;
        set @_new_saleid = @_new_saleid + 1;
        select cprice into @_item_price from items where iid = @_itemid;
        set @_gross_total = @_item_price * quant_in;
		start transaction;
			if @_stockquant >= quant_in then		
					insert into sales values(eid_in,custid_in,@_new_saleid,
					quant_in, @_gross_total,uid_in, timestamp(now()));
					update stock set quant = @_stockquant - quant_in where uid = uid_in;
			end if;
		commit;
end $$
delimiter ;
# ===================================================================================
# Stock Request Procedure
# ===================================================================================
delimiter $$
drop procedure if exists request_stock $$ # Delete if Exists
create procedure request_stock
(in in_iid integer, in in_quant integer)
begin
		declare in_new_uid integer;
        declare exit handler for sqlexception
			begin
				rollback;
			end;
        select count(*) into @in_new_uid from stock;
        set @in_new_uid = @in_new_uid + 1;
        start transaction;
			insert into stock(uid,iid,dop,doi,quant) values(@in_new_uid,in_iid,null,null,0);
			insert into stockorder(quant,iid,uid,timestamp) values(in_quant,in_iid,@in_new_uid, timestamp(now()));
		commit;
end $$
delimiter ;