 


CREATE TRIGGER [tgr_DDLListChange]
ON DATABASE
FOR DDL_DATABASE_LEVEL_EVENTS
AS


SET NOCOUNT ON

DECLARE @dataXML XML
SET @dataXML = EVENTDATA() --Ч получил данные по текущему событию.

IF (
SELECT @dataXML.value('(/EVENT_INSTANCE/ObjectName)[1]' ,'varchar(max)')
) IS NOT NULL
BEGIN
INSERT temp.dbo.tbl_ListChange
(
LoginName --Ч под чьим логином
,HostName --Ч на чьей машине
,ObjectName --Ч что изменено
,ObjectType --Ч тип измененного обьекта
,EventType --Ч тип изменени€
,EventSQLCommand --Ч полностью SQL команда
,EventTime --Ч во сколь изменено
,XMLChange --Ч полностью вс€ хмл-команда
,IP_address
)
VALUES
(
@dataXML.value('(/EVENT_INSTANCE/LoginName)[1]' ,'varchar(2000)') --Ч под чьим логином
,HOST_NAME() --Ч на чьей машине
,@dataXML.value('(/EVENT_INSTANCE/ObjectName)[1]' ,'varchar(100)') --Ч что изменено
,@dataXML.value('(/EVENT_INSTANCE/ObjectType)[1]' ,'varchar(100)') --Ч тип измененного обьекта
,@dataXML.value('(/EVENT_INSTANCE/EventType)[1]' ,'varchar(100)') --Ч тип изменени€
,@dataXML.value('(/EVENT_INSTANCE/TSQLCommand)[1]' ,'varchar(max)') --Ч полностью SQL команда
,GETDATE()
,@dataXML
,(
 SELECT  dmec.client_net_address 
  FROM sys.sysprocesses sp 
  JOIN sys.dm_exec_connections dmec ON sp.spid = dmec.session_id
  WHERE sp.spid = @@SPID)

) --Ч во сколь изменено
END