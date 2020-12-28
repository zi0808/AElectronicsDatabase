# Use my DB
use s2013112501;
# Set Foreign Key Check to false
set FOREIGN_KEY_CHECKS = 0;
# Delete Existing Rows
delete from team;
delete from employees;
delete from customer;
delete from stock;
delete from work;
delete from items;
delete from requirement_emp;
delete from requirement_parts;
delete from sales;
delete from shipping;
# insert teams
insert into team values (1,NULL,'총괄');
insert into team values (2,1,'수리');
insert into team values (3,2,'응대(수리)');
insert into team values (4,1,'판매');
# insert employees
insert into employees values(1,'김용현',2,'010-6401-0359','kimy@atech.com','서울시 동대문구');
insert into employees values(2,'이수도',1,'010-1401-5355','sudo-rm-rf@atech.com','서울시 동대문구');
insert into employees values(3,'조상하',3,'011-2251-1256','jsh@atech.com','서울시 중구');
insert into employees values(4,'박삼수',4,'010-5555-2215','bss@atech.com','서울시 중구');
# insert customers
insert into customer values(1,'김고객','010-9999-9999','kimk@aaa.com','서울시 중구');
insert into customer values(2,'박고객','010-5999-7799','pimk@aaa.com','서울시 강남구');
# insert items
insert into items values(1,1001,'SM951 256GB',200000,250000,'SSD');
insert into items values(2,1001,'Intel Core i7-5820K',300000,500000,'CPU');
insert into items values(3,1001,'SDisk 512GB',150000,200000,'SSD');
insert into items values(4,1001,'Intel Core i7-5960X',800000,1000000,'CPU');
insert into items values(1001,NULL,'A-Tech PC-2015A',2500000,3000000,'데스크탑 완제품');
# insert stocks
insert into stock values(1,1001,'2019-12-01','2019-11-25',1);
insert into stock values(2,1,'2019=12-02','2019-11-11',5);
insert into stock values(3,3,'2019-12-01','2019-11-15',15);
insert into stock values(4,2,'2019-12-04','2019-11-01',1);
insert into stock values(5,4,'2019-12-07','2019-12-01',1);
# insert work
insert into work values(2,1,'2019-12-07 11:53:22','2019-12-25',NULL,'CPU 및 SSD 교체',1,'고객 제품 입고',1300000);
insert into work values(2,2,'2019-12-06 15:22:11',NULL,NULL,'SSD 교체 및 추가',2,'고객 제품 입고',300000);
# insert parts requirement for work
insert into requirement_parts values(4,1,1);
insert into requirement_parts values(3,1,1);
insert into requirement_parts values(3,2,4);
# insert employees for work
insert into requirement_emp values(1,1);
insert into requirement_emp values(1,2);
# set foreign key check back
set FOREIGN_KEY_CHECKS = 1;