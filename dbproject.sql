
USE s2013112501;



set FOREIGN_KEY_CHECKS=0;




DROP TABLE requirement_parts
;



DROP VIEW work_view
;




DROP TABLE requirement_emp
;



DROP VIEW stock_view
;



DROP VIEW view_work_achv
;




DROP TABLE work
;



DROP VIEW orderinfo
;




DROP TABLE shipping
;




DROP TABLE sales
;




DROP TABLE employees
;




DROP TABLE team
;




DROP TABLE customer
;




DROP TABLE stockorder
;




DROP TABLE stock
;




DROP TABLE items
;



CREATE TABLE customer
(
	custid                INT(5) NOT NULL,
	name                  VARCHAR(10) NOT NULL,
	cellphone             VARCHAR(15) NOT NULL,
	email                 VARCHAR(50) NULL,
	addr                  VARCHAR(150) NULL
)
;



ALTER TABLE customer
	ADD  PRIMARY KEY (custid)
;



CREATE TABLE employees
(
	eid                   INT(3) NOT NULL,
	name                  VARCHAR(8) NOT NULL,
	tid                   INTEGER NULL,
	cellphone             VARCHAR(15) NOT NULL,
	email                 VARCHAR(50) NOT NULL,
	addr                  VARCHAR(150) NOT NULL
)
;



ALTER TABLE employees
	ADD  PRIMARY KEY (eid)
;



CREATE TABLE items
(
	iid                   INTEGER NOT NULL,
	compat                INTEGER NULL,
	name                  VARCHAR(30) NOT NULL,
	price                 INTEGER NOT NULL,
	cprice                INTEGER NOT NULL,
	type                  VARCHAR(30) NOT NULL
)
;



ALTER TABLE items
	ADD  PRIMARY KEY (iid)
;



CREATE TABLE requirement_emp
(
	eid                   INT(3) NOT NULL,
	wid                   INTEGER NOT NULL
)
;



ALTER TABLE requirement_emp
	ADD  PRIMARY KEY (wid)
;



CREATE TABLE requirement_parts
(
	iid                   INTEGER NOT NULL,
	wid                   INTEGER NOT NULL,
	quant                 INTEGER NOT NULL
)
;



ALTER TABLE requirement_parts
	ADD  PRIMARY KEY (iid,wid)
;



CREATE TABLE sales
(
	eid                   INT(3) NOT NULL,
	custid                INTEGER NULL,
	saleid                INTEGER NOT NULL,
	quant                 INTEGER NOT NULL,
	saletotal             INTEGER NOT NULL,
	stockid               INTEGER NULL,
	timestamp             DATETIME NULL
)
;



ALTER TABLE sales
	ADD  PRIMARY KEY (saleid)
;



CREATE TABLE shipping
(
	saleid                INTEGER NOT NULL,
	address               VARCHAR(150) NOT NULL,
	tracking              VARCHAR(20) NOT NULL
)
;



ALTER TABLE shipping
	ADD  PRIMARY KEY (saleid)
;



CREATE TABLE stock
(
	uid                   INTEGER NOT NULL,
	iid                   INTEGER NOT NULL,
	dop                   DATE NULL,
	doi                   DATE NULL,
	quant                 INTEGER NOT NULL
)
;



ALTER TABLE stock
	ADD  PRIMARY KEY (uid)
;



CREATE TABLE stockorder
(
	quant                 INTEGER NOT NULL,
	iid                   INTEGER NULL,
	uid                   INTEGER NOT NULL,
	timestamp             DATETIME NOT NULL
)
;



ALTER TABLE stockorder
	ADD  PRIMARY KEY (uid)
;



CREATE TABLE team
(
	tid                   INT(2) NOT NULL,
	assoc                 INT(2) NULL,
	name                  VARCHAR(20) NULL
)
;



ALTER TABLE team
	ADD  PRIMARY KEY (tid)
;



CREATE TABLE work
(
	tid                   INT(2) NOT NULL,
	wid                   INTEGER NOT NULL,
	date_start            DATETIME NOT NULL,
	date_deadline         DATETIME NULL,
	date_finish           DATETIME NULL,
	wname                 VARCHAR(40) NULL,
	custid                INTEGER NOT NULL,
	wstat                 VARCHAR(50) NULL,
	fee                   INTEGER NOT NULL
)
;



ALTER TABLE work
	ADD  PRIMARY KEY (wid)
;



CREATE VIEW orderinfo AS
	SELECT sales.saleid,sales.timestamp,sales.quant,sales.saletotal,shipping.address,shipping.tracking,customer.name
		FROM sales,shipping,customer
		WHERE sales.custid = customer.custid AND shipping.saleid=sales.saleid
		GROUP BY sales.saleid
;



CREATE VIEW view_work_achv ( eid,fee,saletotal,total )  AS
	SELECT employees.eid,work.fee,sales.saletotal,sum(work.fee) + sum(sales.saletotal)
		FROM work,employees,sales
		WHERE (employees.eid = requirement_emp.eid AND
work.date_finish IS NOT NULL) OR
(employees.eid = sales.eid)
;



CREATE VIEW stock_view AS
	SELECT  DISTINCT stock.iid,stock.uid,items.name,stock.doi,stock.dop,stock.quant
		FROM items,stock
		WHERE stock.iid = items.iid and quant > 0
		GROUP BY iid
;



CREATE VIEW work_view ( eid,wid,wname,wstat,date_start,date_deadline,date_finish,cname,fee )  AS
	SELECT requirement_emp.eid,work.wid,work.wname,work.wstat,work.date_start,work.date_deadline,work.date_finish,customer.name,work.fee
		FROM work,customer,requirement_emp
		WHERE requirement_emp.wid = work.wid AND work.custid = customer.custid
;



ALTER TABLE employees
	ADD FOREIGN KEY R_25 (tid) REFERENCES team(tid)
;



ALTER TABLE items
	ADD FOREIGN KEY R_8 (compat) REFERENCES items(iid)
;



ALTER TABLE requirement_emp
	ADD FOREIGN KEY R_22 (wid) REFERENCES work(wid)
;


ALTER TABLE requirement_emp
	ADD FOREIGN KEY R_24 (eid) REFERENCES employees(eid)
;



ALTER TABLE requirement_parts
	ADD FOREIGN KEY R_21 (wid) REFERENCES work(wid)
;


ALTER TABLE requirement_parts
	ADD FOREIGN KEY R_26 (iid) REFERENCES items(iid)
;



ALTER TABLE sales
	ADD FOREIGN KEY R_28 (custid) REFERENCES customer(custid)
;


ALTER TABLE sales
	ADD FOREIGN KEY R_32 (eid) REFERENCES employees(eid)
;


ALTER TABLE sales
	ADD FOREIGN KEY R_35 (stockid) REFERENCES stock(uid)
;



ALTER TABLE shipping
	ADD FOREIGN KEY R_29 (saleid) REFERENCES sales(saleid)
;



ALTER TABLE stock
	ADD FOREIGN KEY R_2 (iid) REFERENCES items(iid)
;



ALTER TABLE stockorder
	ADD FOREIGN KEY R_49 (iid) REFERENCES items(iid)
;


ALTER TABLE stockorder
	ADD FOREIGN KEY R_50 (uid) REFERENCES stock(uid)
;



ALTER TABLE team
	ADD FOREIGN KEY R_9 (assoc) REFERENCES team(tid)
;



ALTER TABLE work
	ADD FOREIGN KEY R_19 (custid) REFERENCES customer(custid)
;


ALTER TABLE work
	ADD FOREIGN KEY R_20 (tid) REFERENCES team(tid)
;




ALTER TABLE customer COMMENT = 'customer';
    ALTER TABLE customer CHANGE COLUMN custid custid INT(5) NOT NULL COMMENT 'custid';
    ALTER TABLE customer CHANGE COLUMN name name VARCHAR(10) NOT NULL COMMENT 'name';
    ALTER TABLE customer CHANGE COLUMN cellphone cellphone VARCHAR(15) NOT NULL COMMENT 'cellphone';
    ALTER TABLE customer CHANGE COLUMN email email VARCHAR(50)  COMMENT 'email';
    ALTER TABLE customer CHANGE COLUMN addr addr VARCHAR(150)  COMMENT 'addr';
    
ALTER TABLE employees COMMENT = 'Employees';
    ALTER TABLE employees CHANGE COLUMN eid eid INT(3) NOT NULL COMMENT 'eid';
    ALTER TABLE employees CHANGE COLUMN name name VARCHAR(8) NOT NULL COMMENT 'name';
    ALTER TABLE employees CHANGE COLUMN tid tid INTEGER  COMMENT 'tid';
    ALTER TABLE employees CHANGE COLUMN cellphone cellphone VARCHAR(15) NOT NULL COMMENT 'cellphone';
    ALTER TABLE employees CHANGE COLUMN email email VARCHAR(50) NOT NULL COMMENT 'email';
    ALTER TABLE employees CHANGE COLUMN addr addr VARCHAR(150) NOT NULL COMMENT 'addr';
    
ALTER TABLE items COMMENT = 'items';
    ALTER TABLE items CHANGE COLUMN iid iid INTEGER NOT NULL COMMENT 'iid';
    ALTER TABLE items CHANGE COLUMN compat compat INTEGER  COMMENT 'compat';
    ALTER TABLE items CHANGE COLUMN name name VARCHAR(30) NOT NULL COMMENT 'name';
    ALTER TABLE items CHANGE COLUMN price price INTEGER NOT NULL COMMENT 'price';
    ALTER TABLE items CHANGE COLUMN cprice cprice INTEGER NOT NULL COMMENT 'cprice';
    ALTER TABLE items CHANGE COLUMN type type VARCHAR(30) NOT NULL COMMENT 'type';
    
ALTER TABLE requirement_emp COMMENT = 'requirement_emp';
    ALTER TABLE requirement_emp CHANGE COLUMN wid wid INTEGER NOT NULL COMMENT 'wid';
    ALTER TABLE requirement_emp CHANGE COLUMN eid eid INT(3) NOT NULL COMMENT 'eid';
    
ALTER TABLE requirement_parts COMMENT = 'requirement_parts';
    ALTER TABLE requirement_parts CHANGE COLUMN iid iid INTEGER NOT NULL COMMENT 'iid';
    ALTER TABLE requirement_parts CHANGE COLUMN wid wid INTEGER NOT NULL COMMENT 'wid';
    ALTER TABLE requirement_parts CHANGE COLUMN quant quant INTEGER NOT NULL COMMENT 'quant';
    
ALTER TABLE sales COMMENT = 'sales';
    ALTER TABLE sales CHANGE COLUMN saleid saleid INTEGER NOT NULL COMMENT 'saleid';
    ALTER TABLE sales CHANGE COLUMN eid eid INT(3) NOT NULL COMMENT 'eid';
    ALTER TABLE sales CHANGE COLUMN custid custid INTEGER  COMMENT 'custid';
    ALTER TABLE sales CHANGE COLUMN quant quant INTEGER NOT NULL COMMENT 'quant';
    ALTER TABLE sales CHANGE COLUMN saletotal saletotal INTEGER NOT NULL COMMENT 'saletotal';
    ALTER TABLE sales CHANGE COLUMN stockid stockid INTEGER  COMMENT 'stockid';
    ALTER TABLE sales CHANGE COLUMN timestamp timestamp DATETIME  COMMENT 'timestamp';
    
ALTER TABLE shipping COMMENT = 'shipping';
    ALTER TABLE shipping CHANGE COLUMN saleid saleid INTEGER NOT NULL COMMENT 'saleid';
    ALTER TABLE shipping CHANGE COLUMN address address VARCHAR(150) NOT NULL COMMENT 'address';
    ALTER TABLE shipping CHANGE COLUMN tracking tracking VARCHAR(20) NOT NULL COMMENT 'tracking';
    
ALTER TABLE stock COMMENT = 'stock';
    ALTER TABLE stock CHANGE COLUMN uid uid INTEGER NOT NULL COMMENT 'uid';
    ALTER TABLE stock CHANGE COLUMN iid iid INTEGER NOT NULL COMMENT 'iid';
    ALTER TABLE stock CHANGE COLUMN dop dop DATE  COMMENT 'dop';
    ALTER TABLE stock CHANGE COLUMN doi doi DATE  COMMENT 'doi';
    ALTER TABLE stock CHANGE COLUMN quant quant INTEGER NOT NULL COMMENT 'quant';
    
ALTER TABLE stockorder COMMENT = 'stockorder';
    ALTER TABLE stockorder CHANGE COLUMN uid uid INTEGER NOT NULL COMMENT 'uid';
    ALTER TABLE stockorder CHANGE COLUMN quant quant INTEGER NOT NULL COMMENT 'quant';
    ALTER TABLE stockorder CHANGE COLUMN iid iid INTEGER  COMMENT 'iid';
    ALTER TABLE stockorder CHANGE COLUMN timestamp timestamp DATETIME NOT NULL COMMENT 'timestamp';
    
ALTER TABLE team COMMENT = 'team';
    ALTER TABLE team CHANGE COLUMN tid tid INT(2) NOT NULL COMMENT 'tid';
    ALTER TABLE team CHANGE COLUMN assoc assoc INT(2)  COMMENT 'assoc';
    ALTER TABLE team CHANGE COLUMN name name VARCHAR(20)  COMMENT 'name';
    
ALTER TABLE work COMMENT = 'work';
    ALTER TABLE work CHANGE COLUMN wid wid INTEGER NOT NULL COMMENT 'wid';
    ALTER TABLE work CHANGE COLUMN tid tid INT(2) NOT NULL COMMENT 'tid';
    ALTER TABLE work CHANGE COLUMN date_start date_start DATETIME NOT NULL COMMENT 'date_start';
    ALTER TABLE work CHANGE COLUMN date_deadline date_deadline DATETIME  COMMENT 'date_deadline';
    ALTER TABLE work CHANGE COLUMN date_finish date_finish DATETIME  COMMENT 'date_finish';
    ALTER TABLE work CHANGE COLUMN wname wname VARCHAR(40)  COMMENT 'wname';
    ALTER TABLE work CHANGE COLUMN custid custid INTEGER NOT NULL COMMENT 'custid';
    ALTER TABLE work CHANGE COLUMN wstat wstat VARCHAR(50)  COMMENT 'wstat';
    ALTER TABLE work CHANGE COLUMN fee fee INTEGER NOT NULL COMMENT 'fee';
    




set FOREIGN_KEY_CHECKS=1;


