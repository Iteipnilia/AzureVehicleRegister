#pragma warning disable 1591
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace VehicleRegister.Repository.DataAccess
{
	using System.Data.Linq;
	using System.Data.Linq.Mapping;
	using System.Data;
	using System.Collections.Generic;
	using System.Reflection;
	using System.Linq;
	using System.Linq.Expressions;
	using System.ComponentModel;
	using System;
	
	
	[global::System.Data.Linq.Mapping.DatabaseAttribute(Name="DB-VehicleRegistry")]
	public partial class AzureDbAccessDataContext : System.Data.Linq.DataContext
	{
		
		private static System.Data.Linq.Mapping.MappingSource mappingSource = new AttributeMappingSource();
		
    #region Extensibility Method Definitions
    partial void OnCreated();
    partial void InsertApiUser(ApiUser instance);
    partial void UpdateApiUser(ApiUser instance);
    partial void DeleteApiUser(ApiUser instance);
    partial void InsertVehicle(Vehicle instance);
    partial void UpdateVehicle(Vehicle instance);
    partial void DeleteVehicle(Vehicle instance);
    partial void InsertVehicleService(VehicleService instance);
    partial void UpdateVehicleService(VehicleService instance);
    partial void DeleteVehicleService(VehicleService instance);
    #endregion
		
		public AzureDbAccessDataContext() : 
				base(global::VehicleRegister.Repository.Properties.Settings.Default.DB_VehicleRegistryConnectionString, mappingSource)
		{
			OnCreated();
		}
		
		public AzureDbAccessDataContext(string connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public AzureDbAccessDataContext(System.Data.IDbConnection connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public AzureDbAccessDataContext(string connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public AzureDbAccessDataContext(System.Data.IDbConnection connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public System.Data.Linq.Table<ApiUser> ApiUsers
		{
			get
			{
				return this.GetTable<ApiUser>();
			}
		}
		
		public System.Data.Linq.Table<Vehicle> Vehicles
		{
			get
			{
				return this.GetTable<Vehicle>();
			}
		}
		
		public System.Data.Linq.Table<VehicleService> VehicleServices
		{
			get
			{
				return this.GetTable<VehicleService>();
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.ApiUsers")]
	public partial class ApiUser : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _UserId;
		
		private string _UserName;
		
		private string _UserPasswd;
		
		private string _UserRole;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnUserIdChanging(int value);
    partial void OnUserIdChanged();
    partial void OnUserNameChanging(string value);
    partial void OnUserNameChanged();
    partial void OnUserPasswdChanging(string value);
    partial void OnUserPasswdChanged();
    partial void OnUserRoleChanging(string value);
    partial void OnUserRoleChanged();
    #endregion
		
		public ApiUser()
		{
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_UserId", AutoSync=AutoSync.OnInsert, DbType="Int NOT NULL IDENTITY", IsPrimaryKey=true, IsDbGenerated=true)]
		public int UserId
		{
			get
			{
				return this._UserId;
			}
			set
			{
				if ((this._UserId != value))
				{
					this.OnUserIdChanging(value);
					this.SendPropertyChanging();
					this._UserId = value;
					this.SendPropertyChanged("UserId");
					this.OnUserIdChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_UserName", DbType="NVarChar(20)")]
		public string UserName
		{
			get
			{
				return this._UserName;
			}
			set
			{
				if ((this._UserName != value))
				{
					this.OnUserNameChanging(value);
					this.SendPropertyChanging();
					this._UserName = value;
					this.SendPropertyChanged("UserName");
					this.OnUserNameChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_UserPasswd", DbType="NVarChar(50)")]
		public string UserPasswd
		{
			get
			{
				return this._UserPasswd;
			}
			set
			{
				if ((this._UserPasswd != value))
				{
					this.OnUserPasswdChanging(value);
					this.SendPropertyChanging();
					this._UserPasswd = value;
					this.SendPropertyChanged("UserPasswd");
					this.OnUserPasswdChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_UserRole", DbType="NVarChar(50)")]
		public string UserRole
		{
			get
			{
				return this._UserRole;
			}
			set
			{
				if ((this._UserRole != value))
				{
					this.OnUserRoleChanging(value);
					this.SendPropertyChanging();
					this._UserRole = value;
					this.SendPropertyChanged("UserRole");
					this.OnUserRoleChanged();
				}
			}
		}
		
		public event PropertyChangingEventHandler PropertyChanging;
		
		public event PropertyChangedEventHandler PropertyChanged;
		
		protected virtual void SendPropertyChanging()
		{
			if ((this.PropertyChanging != null))
			{
				this.PropertyChanging(this, emptyChangingEventArgs);
			}
		}
		
		protected virtual void SendPropertyChanged(String propertyName)
		{
			if ((this.PropertyChanged != null))
			{
				this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.Vehicle")]
	public partial class Vehicle : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _VehicleId;
		
		private string _RegestrationNumber;
		
		private string _Model;
		
		private string _Brand;
		
		private string _Vehicle_Type;
		
		private decimal _Weight_;
		
		private System.Nullable<bool> _IsRegistered;
		
		private System.Nullable<decimal> _YearlyFee;
		
		private System.Nullable<int> _VehicleServiceId;
		
		private System.Nullable<System.DateTime> _FirstUseInTraffic;
		
		private EntitySet<VehicleService> _VehicleServices;
		
		private EntityRef<VehicleService> _VehicleService;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnVehicleIdChanging(int value);
    partial void OnVehicleIdChanged();
    partial void OnRegestrationNumberChanging(string value);
    partial void OnRegestrationNumberChanged();
    partial void OnModelChanging(string value);
    partial void OnModelChanged();
    partial void OnBrandChanging(string value);
    partial void OnBrandChanged();
    partial void OnVehicle_TypeChanging(string value);
    partial void OnVehicle_TypeChanged();
    partial void OnWeight_Changing(decimal value);
    partial void OnWeight_Changed();
    partial void OnIsRegisteredChanging(System.Nullable<bool> value);
    partial void OnIsRegisteredChanged();
    partial void OnYearlyFeeChanging(System.Nullable<decimal> value);
    partial void OnYearlyFeeChanged();
    partial void OnVehicleServiceIdChanging(System.Nullable<int> value);
    partial void OnVehicleServiceIdChanged();
    partial void OnFirstUseInTrafficChanging(System.Nullable<System.DateTime> value);
    partial void OnFirstUseInTrafficChanged();
    #endregion
		
		public Vehicle()
		{
			this._VehicleServices = new EntitySet<VehicleService>(new Action<VehicleService>(this.attach_VehicleServices), new Action<VehicleService>(this.detach_VehicleServices));
			this._VehicleService = default(EntityRef<VehicleService>);
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_VehicleId", AutoSync=AutoSync.OnInsert, DbType="Int NOT NULL IDENTITY", IsPrimaryKey=true, IsDbGenerated=true)]
		public int VehicleId
		{
			get
			{
				return this._VehicleId;
			}
			set
			{
				if ((this._VehicleId != value))
				{
					this.OnVehicleIdChanging(value);
					this.SendPropertyChanging();
					this._VehicleId = value;
					this.SendPropertyChanged("VehicleId");
					this.OnVehicleIdChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_RegestrationNumber", DbType="VarChar(255) NOT NULL", CanBeNull=false)]
		public string RegestrationNumber
		{
			get
			{
				return this._RegestrationNumber;
			}
			set
			{
				if ((this._RegestrationNumber != value))
				{
					this.OnRegestrationNumberChanging(value);
					this.SendPropertyChanging();
					this._RegestrationNumber = value;
					this.SendPropertyChanged("RegestrationNumber");
					this.OnRegestrationNumberChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Model", DbType="VarChar(255)")]
		public string Model
		{
			get
			{
				return this._Model;
			}
			set
			{
				if ((this._Model != value))
				{
					this.OnModelChanging(value);
					this.SendPropertyChanging();
					this._Model = value;
					this.SendPropertyChanged("Model");
					this.OnModelChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Brand", DbType="VarChar(255)")]
		public string Brand
		{
			get
			{
				return this._Brand;
			}
			set
			{
				if ((this._Brand != value))
				{
					this.OnBrandChanging(value);
					this.SendPropertyChanging();
					this._Brand = value;
					this.SendPropertyChanged("Brand");
					this.OnBrandChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Vehicle_Type", DbType="VarChar(255)")]
		public string Vehicle_Type
		{
			get
			{
				return this._Vehicle_Type;
			}
			set
			{
				if ((this._Vehicle_Type != value))
				{
					this.OnVehicle_TypeChanging(value);
					this.SendPropertyChanging();
					this._Vehicle_Type = value;
					this.SendPropertyChanged("Vehicle_Type");
					this.OnVehicle_TypeChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Weight_", DbType="Decimal(18,0) NOT NULL")]
		public decimal Weight_
		{
			get
			{
				return this._Weight_;
			}
			set
			{
				if ((this._Weight_ != value))
				{
					this.OnWeight_Changing(value);
					this.SendPropertyChanging();
					this._Weight_ = value;
					this.SendPropertyChanged("Weight_");
					this.OnWeight_Changed();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_IsRegistered", DbType="Bit")]
		public System.Nullable<bool> IsRegistered
		{
			get
			{
				return this._IsRegistered;
			}
			set
			{
				if ((this._IsRegistered != value))
				{
					this.OnIsRegisteredChanging(value);
					this.SendPropertyChanging();
					this._IsRegistered = value;
					this.SendPropertyChanged("IsRegistered");
					this.OnIsRegisteredChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_YearlyFee", DbType="Decimal(18,0)")]
		public System.Nullable<decimal> YearlyFee
		{
			get
			{
				return this._YearlyFee;
			}
			set
			{
				if ((this._YearlyFee != value))
				{
					this.OnYearlyFeeChanging(value);
					this.SendPropertyChanging();
					this._YearlyFee = value;
					this.SendPropertyChanged("YearlyFee");
					this.OnYearlyFeeChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_VehicleServiceId", DbType="Int")]
		public System.Nullable<int> VehicleServiceId
		{
			get
			{
				return this._VehicleServiceId;
			}
			set
			{
				if ((this._VehicleServiceId != value))
				{
					if (this._VehicleService.HasLoadedOrAssignedValue)
					{
						throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
					}
					this.OnVehicleServiceIdChanging(value);
					this.SendPropertyChanging();
					this._VehicleServiceId = value;
					this.SendPropertyChanged("VehicleServiceId");
					this.OnVehicleServiceIdChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_FirstUseInTraffic", DbType="DateTime")]
		public System.Nullable<System.DateTime> FirstUseInTraffic
		{
			get
			{
				return this._FirstUseInTraffic;
			}
			set
			{
				if ((this._FirstUseInTraffic != value))
				{
					this.OnFirstUseInTrafficChanging(value);
					this.SendPropertyChanging();
					this._FirstUseInTraffic = value;
					this.SendPropertyChanged("FirstUseInTraffic");
					this.OnFirstUseInTrafficChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="Vehicle_VehicleService", Storage="_VehicleServices", ThisKey="VehicleId", OtherKey="VehicleId")]
		public EntitySet<VehicleService> VehicleServices
		{
			get
			{
				return this._VehicleServices;
			}
			set
			{
				this._VehicleServices.Assign(value);
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="VehicleService_Vehicle", Storage="_VehicleService", ThisKey="VehicleServiceId", OtherKey="VehicleServiceId", IsForeignKey=true)]
		public VehicleService VehicleService
		{
			get
			{
				return this._VehicleService.Entity;
			}
			set
			{
				VehicleService previousValue = this._VehicleService.Entity;
				if (((previousValue != value) 
							|| (this._VehicleService.HasLoadedOrAssignedValue == false)))
				{
					this.SendPropertyChanging();
					if ((previousValue != null))
					{
						this._VehicleService.Entity = null;
						previousValue.Vehicles.Remove(this);
					}
					this._VehicleService.Entity = value;
					if ((value != null))
					{
						value.Vehicles.Add(this);
						this._VehicleServiceId = value.VehicleServiceId;
					}
					else
					{
						this._VehicleServiceId = default(Nullable<int>);
					}
					this.SendPropertyChanged("VehicleService");
				}
			}
		}
		
		public event PropertyChangingEventHandler PropertyChanging;
		
		public event PropertyChangedEventHandler PropertyChanged;
		
		protected virtual void SendPropertyChanging()
		{
			if ((this.PropertyChanging != null))
			{
				this.PropertyChanging(this, emptyChangingEventArgs);
			}
		}
		
		protected virtual void SendPropertyChanged(String propertyName)
		{
			if ((this.PropertyChanged != null))
			{
				this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
		
		private void attach_VehicleServices(VehicleService entity)
		{
			this.SendPropertyChanging();
			entity.Vehicle = this;
		}
		
		private void detach_VehicleServices(VehicleService entity)
		{
			this.SendPropertyChanging();
			entity.Vehicle = null;
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.VehicleService")]
	public partial class VehicleService : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _VehicleServiceId;
		
		private System.Nullable<int> _VehicleId;
		
		private System.Nullable<System.DateTime> _ServiceDate;
		
		private string _VehicleService_Type;
		
		private System.Nullable<bool> _IsServiceCompleted;
		
		private EntitySet<Vehicle> _Vehicles;
		
		private EntityRef<Vehicle> _Vehicle;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnVehicleServiceIdChanging(int value);
    partial void OnVehicleServiceIdChanged();
    partial void OnVehicleIdChanging(System.Nullable<int> value);
    partial void OnVehicleIdChanged();
    partial void OnServiceDateChanging(System.Nullable<System.DateTime> value);
    partial void OnServiceDateChanged();
    partial void OnVehicleService_TypeChanging(string value);
    partial void OnVehicleService_TypeChanged();
    partial void OnIsServiceCompletedChanging(System.Nullable<bool> value);
    partial void OnIsServiceCompletedChanged();
    #endregion
		
		public VehicleService()
		{
			this._Vehicles = new EntitySet<Vehicle>(new Action<Vehicle>(this.attach_Vehicles), new Action<Vehicle>(this.detach_Vehicles));
			this._Vehicle = default(EntityRef<Vehicle>);
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_VehicleServiceId", AutoSync=AutoSync.OnInsert, DbType="Int NOT NULL IDENTITY", IsPrimaryKey=true, IsDbGenerated=true)]
		public int VehicleServiceId
		{
			get
			{
				return this._VehicleServiceId;
			}
			set
			{
				if ((this._VehicleServiceId != value))
				{
					this.OnVehicleServiceIdChanging(value);
					this.SendPropertyChanging();
					this._VehicleServiceId = value;
					this.SendPropertyChanged("VehicleServiceId");
					this.OnVehicleServiceIdChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_VehicleId", DbType="Int")]
		public System.Nullable<int> VehicleId
		{
			get
			{
				return this._VehicleId;
			}
			set
			{
				if ((this._VehicleId != value))
				{
					if (this._Vehicle.HasLoadedOrAssignedValue)
					{
						throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
					}
					this.OnVehicleIdChanging(value);
					this.SendPropertyChanging();
					this._VehicleId = value;
					this.SendPropertyChanged("VehicleId");
					this.OnVehicleIdChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_ServiceDate", DbType="DateTime")]
		public System.Nullable<System.DateTime> ServiceDate
		{
			get
			{
				return this._ServiceDate;
			}
			set
			{
				if ((this._ServiceDate != value))
				{
					this.OnServiceDateChanging(value);
					this.SendPropertyChanging();
					this._ServiceDate = value;
					this.SendPropertyChanged("ServiceDate");
					this.OnServiceDateChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_VehicleService_Type", DbType="VarChar(255)")]
		public string VehicleService_Type
		{
			get
			{
				return this._VehicleService_Type;
			}
			set
			{
				if ((this._VehicleService_Type != value))
				{
					this.OnVehicleService_TypeChanging(value);
					this.SendPropertyChanging();
					this._VehicleService_Type = value;
					this.SendPropertyChanged("VehicleService_Type");
					this.OnVehicleService_TypeChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_IsServiceCompleted", DbType="Bit")]
		public System.Nullable<bool> IsServiceCompleted
		{
			get
			{
				return this._IsServiceCompleted;
			}
			set
			{
				if ((this._IsServiceCompleted != value))
				{
					this.OnIsServiceCompletedChanging(value);
					this.SendPropertyChanging();
					this._IsServiceCompleted = value;
					this.SendPropertyChanged("IsServiceCompleted");
					this.OnIsServiceCompletedChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="VehicleService_Vehicle", Storage="_Vehicles", ThisKey="VehicleServiceId", OtherKey="VehicleServiceId")]
		public EntitySet<Vehicle> Vehicles
		{
			get
			{
				return this._Vehicles;
			}
			set
			{
				this._Vehicles.Assign(value);
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="Vehicle_VehicleService", Storage="_Vehicle", ThisKey="VehicleId", OtherKey="VehicleId", IsForeignKey=true, DeleteRule="CASCADE")]
		public Vehicle Vehicle
		{
			get
			{
				return this._Vehicle.Entity;
			}
			set
			{
				Vehicle previousValue = this._Vehicle.Entity;
				if (((previousValue != value) 
							|| (this._Vehicle.HasLoadedOrAssignedValue == false)))
				{
					this.SendPropertyChanging();
					if ((previousValue != null))
					{
						this._Vehicle.Entity = null;
						previousValue.VehicleServices.Remove(this);
					}
					this._Vehicle.Entity = value;
					if ((value != null))
					{
						value.VehicleServices.Add(this);
						this._VehicleId = value.VehicleId;
					}
					else
					{
						this._VehicleId = default(Nullable<int>);
					}
					this.SendPropertyChanged("Vehicle");
				}
			}
		}
		
		public event PropertyChangingEventHandler PropertyChanging;
		
		public event PropertyChangedEventHandler PropertyChanged;
		
		protected virtual void SendPropertyChanging()
		{
			if ((this.PropertyChanging != null))
			{
				this.PropertyChanging(this, emptyChangingEventArgs);
			}
		}
		
		protected virtual void SendPropertyChanged(String propertyName)
		{
			if ((this.PropertyChanged != null))
			{
				this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
		
		private void attach_Vehicles(Vehicle entity)
		{
			this.SendPropertyChanging();
			entity.VehicleService = this;
		}
		
		private void detach_Vehicles(Vehicle entity)
		{
			this.SendPropertyChanging();
			entity.VehicleService = null;
		}
	}
}
#pragma warning restore 1591
