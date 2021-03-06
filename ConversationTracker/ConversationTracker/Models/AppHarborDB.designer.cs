﻿#pragma warning disable 1591
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.34014
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ConversationTracker.Models
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
	
	
	[global::System.Data.Linq.Mapping.DatabaseAttribute(Name="ConversationTracker")]
	public partial class AppHarborDBDataContext : System.Data.Linq.DataContext
	{
		
		private static System.Data.Linq.Mapping.MappingSource mappingSource = new AttributeMappingSource();
		
    #region Extensibility Method Definitions
    partial void OnCreated();
    #endregion
		
		public AppHarborDBDataContext() : 
				base(global::System.Configuration.ConfigurationManager.ConnectionStrings["ConversationTrackerConnectionString"].ConnectionString, mappingSource)
		{
			OnCreated();
		}
		
		public AppHarborDBDataContext(string connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public AppHarborDBDataContext(System.Data.IDbConnection connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public AppHarborDBDataContext(string connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public AppHarborDBDataContext(System.Data.IDbConnection connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.FunctionAttribute(Name="dbo.prc_DeleteConversation")]
		public int prc_DeleteConversation([global::System.Data.Linq.Mapping.ParameterAttribute(Name="Id", DbType="Int")] System.Nullable<int> id)
		{
			IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), id);
			return ((int)(result.ReturnValue));
		}
		
		[global::System.Data.Linq.Mapping.FunctionAttribute(Name="dbo.prc_InsertConversation")]
		public ISingleResult<prc_InsertConversationResult> prc_InsertConversation([global::System.Data.Linq.Mapping.ParameterAttribute(Name="ConversationDate", DbType="DateTime")] System.Nullable<System.DateTime> conversationDate, [global::System.Data.Linq.Mapping.ParameterAttribute(Name="Environment", DbType="NVarChar(100)")] string environment, [global::System.Data.Linq.Mapping.ParameterAttribute(Name="Who", DbType="NVarChar(100)")] string who, [global::System.Data.Linq.Mapping.ParameterAttribute(Name="RateOfUnease", DbType="SmallInt")] System.Nullable<short> rateOfUnease, [global::System.Data.Linq.Mapping.ParameterAttribute(Name="Notes", DbType="NVarChar(1000)")] string notes)
		{
			IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), conversationDate, environment, who, rateOfUnease, notes);
			return ((ISingleResult<prc_InsertConversationResult>)(result.ReturnValue));
		}
		
		[global::System.Data.Linq.Mapping.FunctionAttribute(Name="dbo.prc_RetrieveConversations")]
		public ISingleResult<prc_RetrieveConversationsResult> prc_RetrieveConversations()
		{
			IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())));
			return ((ISingleResult<prc_RetrieveConversationsResult>)(result.ReturnValue));
		}
		
		[global::System.Data.Linq.Mapping.FunctionAttribute(Name="dbo.prc_CheckForUser")]
		public ISingleResult<prc_CheckForUserResult> prc_CheckForUser([global::System.Data.Linq.Mapping.ParameterAttribute(Name="UserName", DbType="NVarChar(100)")] string userName, [global::System.Data.Linq.Mapping.ParameterAttribute(Name="Password", DbType="NVarChar(100)")] string password)
		{
			IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), userName, password);
			return ((ISingleResult<prc_CheckForUserResult>)(result.ReturnValue));
		}
	}
	
	public partial class prc_InsertConversationResult
	{
		
		private System.Nullable<decimal> _Id;
		
		public prc_InsertConversationResult()
		{
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Id", DbType="Decimal(38,0)")]
		public System.Nullable<decimal> Id
		{
			get
			{
				return this._Id;
			}
			set
			{
				if ((this._Id != value))
				{
					this._Id = value;
				}
			}
		}
	}
	
	public partial class prc_RetrieveConversationsResult
	{
		
		private int _Id;
		
		private System.Nullable<System.DateTime> _Date;
		
		private string _SettingOrEnvironment;
		
		private string _Who;
		
		private System.Nullable<short> _RateOfUnease;
		
		private string _NotesOfChangeOverTime;
		
		public prc_RetrieveConversationsResult()
		{
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Id", DbType="Int NOT NULL")]
		public int Id
		{
			get
			{
				return this._Id;
			}
			set
			{
				if ((this._Id != value))
				{
					this._Id = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Date", DbType="DateTime")]
		public System.Nullable<System.DateTime> Date
		{
			get
			{
				return this._Date;
			}
			set
			{
				if ((this._Date != value))
				{
					this._Date = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_SettingOrEnvironment", DbType="NVarChar(100)")]
		public string SettingOrEnvironment
		{
			get
			{
				return this._SettingOrEnvironment;
			}
			set
			{
				if ((this._SettingOrEnvironment != value))
				{
					this._SettingOrEnvironment = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Who", DbType="NVarChar(100)")]
		public string Who
		{
			get
			{
				return this._Who;
			}
			set
			{
				if ((this._Who != value))
				{
					this._Who = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_RateOfUnease", DbType="SmallInt")]
		public System.Nullable<short> RateOfUnease
		{
			get
			{
				return this._RateOfUnease;
			}
			set
			{
				if ((this._RateOfUnease != value))
				{
					this._RateOfUnease = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_NotesOfChangeOverTime", DbType="NVarChar(1000)")]
		public string NotesOfChangeOverTime
		{
			get
			{
				return this._NotesOfChangeOverTime;
			}
			set
			{
				if ((this._NotesOfChangeOverTime != value))
				{
					this._NotesOfChangeOverTime = value;
				}
			}
		}
	}
	
	public partial class prc_CheckForUserResult
	{
		
		private System.Nullable<bool> _Exists;
		
		public prc_CheckForUserResult()
		{
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Name="[Exists]", Storage="_Exists", DbType="Bit")]
		public System.Nullable<bool> Exists
		{
			get
			{
				return this._Exists;
			}
			set
			{
				if ((this._Exists != value))
				{
					this._Exists = value;
				}
			}
		}
	}
}
#pragma warning restore 1591
