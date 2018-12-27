﻿//------------------------------------------------------------------------------
// <auto-generated>
//    Этот код был создан из шаблона.
//
//    Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//    Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.ComponentModel;
using System.Data.EntityClient;
using System.Data.Objects;
using System.Data.Objects.DataClasses;
using System.Linq;
using System.Runtime.Serialization;
using System.Xml.Serialization;

[assembly: EdmSchemaAttribute()]
namespace View_FORMS.Data
{
    #region Контексты
    
    /// <summary>
    /// Нет доступной документации по метаданным.
    /// </summary>
    public partial class WEBEntities : ObjectContext
    {
        #region Конструкторы
    
        /// <summary>
        /// Инициализирует новый объект WEBEntities, используя строку соединения из раздела "WEBEntities" файла конфигурации приложения.
        /// </summary>
        public WEBEntities() : base("name=WEBEntities", "WEBEntities")
        {
            OnContextCreated();
        }
    
        /// <summary>
        /// Инициализация нового объекта WEBEntities.
        /// </summary>
        public WEBEntities(string connectionString) : base(connectionString, "WEBEntities")
        {
            OnContextCreated();
        }
    
        /// <summary>
        /// Инициализация нового объекта WEBEntities.
        /// </summary>
        public WEBEntities(EntityConnection connection) : base(connection, "WEBEntities")
        {
            OnContextCreated();
        }
    
        #endregion
    
        #region Разделяемые методы
    
        partial void OnContextCreated();
    
        #endregion
    
        #region Свойства ObjectSet
    
        /// <summary>
        /// Нет доступной документации по метаданным.
        /// </summary>
        public ObjectSet<tbl_ListChange> tbl_ListChange
        {
            get
            {
                if ((_tbl_ListChange == null))
                {
                    _tbl_ListChange = base.CreateObjectSet<tbl_ListChange>("tbl_ListChange");
                }
                return _tbl_ListChange;
            }
        }
        private ObjectSet<tbl_ListChange> _tbl_ListChange;

        #endregion

        #region Методы AddTo
    
        /// <summary>
        /// Устаревший метод для добавления новых объектов в набор EntitySet tbl_ListChange. Взамен можно использовать метод .Add связанного свойства ObjectSet&lt;T&gt;.
        /// </summary>
        public void AddTotbl_ListChange(tbl_ListChange tbl_ListChange)
        {
            base.AddObject("tbl_ListChange", tbl_ListChange);
        }

        #endregion

    }

    #endregion

    #region Сущности
    
    /// <summary>
    /// Нет доступной документации по метаданным.
    /// </summary>
    [EdmEntityTypeAttribute(NamespaceName="WEBModel", Name="tbl_ListChange")]
    [Serializable()]
    [DataContractAttribute(IsReference=true)]
    public partial class tbl_ListChange : EntityObject
    {
        #region Фабричный метод
    
        /// <summary>
        /// Создание нового объекта tbl_ListChange.
        /// </summary>
        /// <param name="eventTime">Исходное значение свойства EventTime.</param>
        /// <param name="id">Исходное значение свойства Id.</param>
        public static tbl_ListChange Createtbl_ListChange(global::System.DateTime eventTime, global::System.Int32 id)
        {
            tbl_ListChange tbl_ListChange = new tbl_ListChange();
            tbl_ListChange.EventTime = eventTime;
            tbl_ListChange.Id = id;
            return tbl_ListChange;
        }

        #endregion

        #region Простые свойства
    
        /// <summary>
        /// Нет доступной документации по метаданным.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public global::System.String LoginName
        {
            get
            {
                return _LoginName;
            }
            set
            {
                OnLoginNameChanging(value);
                ReportPropertyChanging("LoginName");
                _LoginName = StructuralObject.SetValidValue(value, true, "LoginName");
                ReportPropertyChanged("LoginName");
                OnLoginNameChanged();
            }
        }
        private global::System.String _LoginName;
        partial void OnLoginNameChanging(global::System.String value);
        partial void OnLoginNameChanged();
    
        /// <summary>
        /// Нет доступной документации по метаданным.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public global::System.String HostName
        {
            get
            {
                return _HostName;
            }
            set
            {
                OnHostNameChanging(value);
                ReportPropertyChanging("HostName");
                _HostName = StructuralObject.SetValidValue(value, true, "HostName");
                ReportPropertyChanged("HostName");
                OnHostNameChanged();
            }
        }
        private global::System.String _HostName;
        partial void OnHostNameChanging(global::System.String value);
        partial void OnHostNameChanged();
    
        /// <summary>
        /// Нет доступной документации по метаданным.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public global::System.String ObjectName
        {
            get
            {
                return _ObjectName;
            }
            set
            {
                OnObjectNameChanging(value);
                ReportPropertyChanging("ObjectName");
                _ObjectName = StructuralObject.SetValidValue(value, true, "ObjectName");
                ReportPropertyChanged("ObjectName");
                OnObjectNameChanged();
            }
        }
        private global::System.String _ObjectName;
        partial void OnObjectNameChanging(global::System.String value);
        partial void OnObjectNameChanged();
    
        /// <summary>
        /// Нет доступной документации по метаданным.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public global::System.String ObjectType
        {
            get
            {
                return _ObjectType;
            }
            set
            {
                OnObjectTypeChanging(value);
                ReportPropertyChanging("ObjectType");
                _ObjectType = StructuralObject.SetValidValue(value, true, "ObjectType");
                ReportPropertyChanged("ObjectType");
                OnObjectTypeChanged();
            }
        }
        private global::System.String _ObjectType;
        partial void OnObjectTypeChanging(global::System.String value);
        partial void OnObjectTypeChanged();
    
        /// <summary>
        /// Нет доступной документации по метаданным.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public global::System.String EventType
        {
            get
            {
                return _EventType;
            }
            set
            {
                OnEventTypeChanging(value);
                ReportPropertyChanging("EventType");
                _EventType = StructuralObject.SetValidValue(value, true, "EventType");
                ReportPropertyChanged("EventType");
                OnEventTypeChanged();
            }
        }
        private global::System.String _EventType;
        partial void OnEventTypeChanging(global::System.String value);
        partial void OnEventTypeChanged();
    
        /// <summary>
        /// Нет доступной документации по метаданным.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public global::System.String EventSQLCommand
        {
            get
            {
                return _EventSQLCommand;
            }
            set
            {
                OnEventSQLCommandChanging(value);
                ReportPropertyChanging("EventSQLCommand");
                _EventSQLCommand = StructuralObject.SetValidValue(value, true, "EventSQLCommand");
                ReportPropertyChanged("EventSQLCommand");
                OnEventSQLCommandChanged();
            }
        }
        private global::System.String _EventSQLCommand;
        partial void OnEventSQLCommandChanging(global::System.String value);
        partial void OnEventSQLCommandChanged();
    
        /// <summary>
        /// Нет доступной документации по метаданным.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.DateTime EventTime
        {
            get
            {
                return _EventTime;
            }
            set
            {
                OnEventTimeChanging(value);
                ReportPropertyChanging("EventTime");
                _EventTime = StructuralObject.SetValidValue(value, "EventTime");
                ReportPropertyChanged("EventTime");
                OnEventTimeChanged();
            }
        }
        private global::System.DateTime _EventTime;
        partial void OnEventTimeChanging(global::System.DateTime value);
        partial void OnEventTimeChanged();
    
        /// <summary>
        /// Нет доступной документации по метаданным.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public global::System.String XMLChange
        {
            get
            {
                return _XMLChange;
            }
            set
            {
                OnXMLChangeChanging(value);
                ReportPropertyChanging("XMLChange");
                _XMLChange = StructuralObject.SetValidValue(value, true, "XMLChange");
                ReportPropertyChanged("XMLChange");
                OnXMLChangeChanged();
            }
        }
        private global::System.String _XMLChange;
        partial void OnXMLChangeChanging(global::System.String value);
        partial void OnXMLChangeChanged();
    
        /// <summary>
        /// Нет доступной документации по метаданным.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=true, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.Int32 Id
        {
            get
            {
                return _Id;
            }
            set
            {
                if (_Id != value)
                {
                    OnIdChanging(value);
                    ReportPropertyChanging("Id");
                    _Id = StructuralObject.SetValidValue(value, "Id");
                    ReportPropertyChanged("Id");
                    OnIdChanged();
                }
            }
        }
        private global::System.Int32 _Id;
        partial void OnIdChanging(global::System.Int32 value);
        partial void OnIdChanged();
    
        /// <summary>
        /// Нет доступной документации по метаданным.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public global::System.String IP_address
        {
            get
            {
                return _IP_address;
            }
            set
            {
                OnIP_addressChanging(value);
                ReportPropertyChanging("IP_address");
                _IP_address = StructuralObject.SetValidValue(value, true, "IP_address");
                ReportPropertyChanged("IP_address");
                OnIP_addressChanged();
            }
        }
        private global::System.String _IP_address;
        partial void OnIP_addressChanging(global::System.String value);
        partial void OnIP_addressChanged();

        #endregion

    }

    #endregion

}