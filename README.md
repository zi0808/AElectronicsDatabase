# AElectronicsDatabase
C# SQL Application Demo

## Dependencies / Pre-requisites [사전 준비사항]
- Latest Version of Visual Studio and C# (with WinForms)
- MySQL Connector/Net - https://dev.mysql.com/downloads/connector/net/ (Required for Basic SQL Connectivity)
- SSH.Net - https://github.com/sshnet/SSH.NET (Required for SSH Connectivity)
- (If you want to run/test it on Local SQL Server) MySQL Server

## How to Run [실행 방법]

- Check three .sql files on the root folder. They're used to create databases, tables, and procedures necessary. (DB name is set to 'elecdb')
  Order should be dbproject.sql > dbproject_inserts.sql > dbproject_procedures.sql<br>
  [ 루트 경로에있는 3개의 .sql 파일을 실행하세요. Db 와 테이블, 프로시저를 만들어줍니다. 순서는 dbproject.sql > dbproject_inserts.sql > dbproject_procedures.sql 입니다. ]
- To simply just run pre-built executable, look in the usual "bin" folder. In this case, DBProjWF/bin/Debug/DBProjWF.exe.<br>
  [ 실행파일은 DBProjWF/bin/Debug/DBProjWF.exe 경로에 있습니다. 보통 비주얼 스튜디오의 빌드 경로로 보시면 됩니다. ]
- Check DB.ini file within the same folder. They are used to define where to connect as SQL server and whether you want to use SSH.<br>
  [ 같은 폴더 내의 DB.ini 를 확인하세요. SQL 서버 및 추가적으로 SSH 연결에 대한 설정이 포함됩니다. ]

## What does it do? [기능]
 This app is aimed to simulate "Electronics Repair / Retail Database and Application"."<br>
 [ 전자제품 수리 / 판매점의 업무용 어플리케이션을 상정하여 제작되었습니다. ]<br>
 Functionalities include :
 - Managing Inventory [재고/물품 관리]
 - Managing Credentials of Customers [고객정보 관리]
 - Work Assignment / Management [업무 배정/관리]
 
SQL Structures have been made with ER Diagram (**ERWin**), Then was exported to SQL files to build up initial database.
