 


CREATE TRIGGER [tgr_DDLListChange]
ON DATABASE
FOR DDL_DATABASE_LEVEL_EVENTS
AS


SET NOCOUNT ON

DECLARE @dataXML XML
SET @dataXML = EVENTDATA() --� ������� ������ �� �������� �������.

IF (
SELECT @dataXML.value('(/EVENT_INSTANCE/ObjectName)[1]' ,'varchar(max)')
) IS NOT NULL
BEGIN
INSERT temp.dbo.tbl_ListChange
(
LoginName --� ��� ���� �������
,HostName --� �� ���� ������
,ObjectName --� ��� ��������
,ObjectType --� ��� ����������� �������
,EventType --� ��� ���������
,EventSQLCommand --� ��������� SQL �������
,EventTime --� �� ����� ��������
,XMLChange --� ��������� ��� ���-�������
,IP_address
)
VALUES
(
@dataXML.value('(/EVENT_INSTANCE/LoginName)[1]' ,'varchar(2000)') --� ��� ���� �������
,HOST_NAME() --� �� ���� ������
,@dataXML.value('(/EVENT_INSTANCE/ObjectName)[1]' ,'varchar(100)') --� ��� ��������
,@dataXML.value('(/EVENT_INSTANCE/ObjectType)[1]' ,'varchar(100)') --� ��� ����������� �������
,@dataXML.value('(/EVENT_INSTANCE/EventType)[1]' ,'varchar(100)') --� ��� ���������
,@dataXML.value('(/EVENT_INSTANCE/TSQLCommand)[1]' ,'varchar(max)') --� ��������� SQL �������
,GETDATE()
,@dataXML
,(
 SELECT  dmec.client_net_address 
  FROM sys.sysprocesses sp 
  JOIN sys.dm_exec_connections dmec ON sp.spid = dmec.session_id
  WHERE sp.spid = @@SPID)

) --� �� ����� ��������
END