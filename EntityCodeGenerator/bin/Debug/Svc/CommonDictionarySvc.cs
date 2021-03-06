using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using SourceCode.SmartObjects.Services.ServiceSDK.Attributes;
using SourceCode.SmartObjects.Services.ServiceSDK.Objects;
using SourceCode.SmartObjects.Services.ServiceSDK.Types;
using CSWF.CommonService.Entity;
using CSWF.CommonService.Services;
using CSWF.Common;

namespace CSWF.CommonService.CommonSvc
{
    [ServiceObject("CommonDictionarySvc", "CommonDictionarySvc", "CommonDictionarySvc")]
    public partial class CommonDictionarySvc
    {
		[Property("ID", SoType.Number, "ID", "ID")]
        public int ID { get; set; }

		[Property("ProcessCode", SoType.Text, "ProcessCode", "ProcessCode")]
        public string ProcessCode { get; set; }

		[Property("Type", SoType.Text, "Type", "Type")]
        public string Type { get; set; }

		[Property("SubType", SoType.Text, "SubType", "SubType")]
        public string SubType { get; set; }

		[Property("SubSubType", SoType.Text, "SubSubType", "SubSubType")]
        public string SubSubType { get; set; }

		[Property("Code", SoType.Text, "Code", "Code")]
        public string Code { get; set; }

		[Property("Value", SoType.Text, "Value", "Value")]
        public string Value { get; set; }

		[Property("OrderId", SoType.Number, "OrderId", "OrderId")]
        public int OrderId { get; set; }

		[Property("CreateBy", SoType.Text, "CreateBy", "CreateBy")]
        public string CreateBy { get; set; }

		[Property("CreateTime", SoType.DateTime, "CreateTime", "CreateTime")]
        public System.DateTime CreateTime { get; set; }

		[Property("UpdateBy", SoType.Text, "UpdateBy", "UpdateBy")]
        public string UpdateBy { get; set; }

		[Property("UpdateTime", SoType.DateTime, "UpdateTime", "UpdateTime")]
        public System.DateTime UpdateTime { get; set; }

		[Property("IsActive", SoType.YesNo, "IsActive", "IsActive")]
        public Nullable<bool> IsActive { get; set; }

    }

    public partial class CommonDictionarySvc : SvcBase
    {
        public CommonDictionarySvc()
        { }

        public static CommonDictionarySvc GetFromEntity(CommonDictionary entity)
        {
            CommonDictionarySvc svc = new CommonDictionarySvc();
            svc.ParseFromEntity(entity);
            return svc;
        }

        public void ParseFromEntity(CommonDictionary entity)
        {
			if (entity == null) return;

			this.ID = entity.ID;
			this.ProcessCode = entity.ProcessCode;
			this.Type = entity.Type;
			this.SubType = entity.SubType;
			this.SubSubType = entity.SubSubType;
			this.Code = entity.Code;
			this.Value = entity.Value;
			this.OrderId = entity.OrderId;
			this.CreateBy = entity.CreateBy;
			this.CreateTime = entity.CreateTime;
			this.UpdateBy = entity.UpdateBy;
			this.UpdateTime = entity.UpdateTime;
			this.IsActive = entity.IsActive;
		}

        public CommonDictionary ToEntity()
        {
            var entity = new CommonDictionary();
			entity.ID = this.ID;
			entity.ProcessCode = this.ProcessCode;
			entity.Type = this.Type;
			entity.SubType = this.SubType;
			entity.SubSubType = this.SubSubType;
			entity.Code = this.Code;
			entity.Value = this.Value;
			entity.OrderId = this.OrderId;
			entity.CreateBy = this.CreateBy;
			entity.CreateTime = this.CreateTime;
			entity.UpdateBy = this.UpdateBy;
			entity.UpdateTime = this.UpdateTime;
			entity.IsActive = this.IsActive;
            return entity;
        }

        [Method("Read", MethodType.Read, "Read", "Read",
            new string[] { },
            new string[] { "System", "ID" },
            new string[] { "ID","ProcessCode","Type","SubType","SubSubType","Code","Value","OrderId","CreateBy","CreateTime","UpdateBy","UpdateTime","IsActive"})]
        public CommonDictionarySvc Read()
        {
			try
			{
				CommonDictionaryService service = new CommonDictionaryService(ConnString);
				var model = service.Read(ID);
				if (model == null)
				{
					return null;
				}

				ParseFromEntity(model);
			}
			catch(Exception ex)
			{
				Dictionary<string, object> variables = new Dictionary<string, object>() { };
                variables.Add("ID", ID);
                variables.Add("Msg", ex.Message);
				Logger.ServiceConfiguration = ServiceConfiguration;
                Logger.Write(System, RequestID, CurrentUser, "CommonDictionarySvc.Read", SvcLogLevel, variables);
                throw ex;
			}
            return this;
        }

        [Method("Create", MethodType.Create, "Create", "Create",
            new string[] { },
            new string[] { "System", "ID","ProcessCode","Type","SubType","SubSubType","Code","Value","OrderId","CreateBy","CreateTime","UpdateBy","UpdateTime","IsActive" },
            new string[] { "ID"})]
        public CommonDictionarySvc Create()
        {
			try
			{
				CommonDictionaryService service = new CommonDictionaryService(ConnString);
				var entity = ToEntity();
                entity.CreateBy = CurrentUser;
                entity.CreateTime = DateTime.Now;
                entity.UpdateBy = CurrentUser;
                entity.UpdateTime = DateTime.Now;
				
                entity.CreateBy = CurrentUser;
                entity.CreateTime = DateTime.Now;
				ID = service.Create(entity);
			}
			catch(Exception ex)
			{
				Dictionary<string, object> variables = new Dictionary<string, object>() { };
                variables.Add("ID", ID);
                variables.Add("Msg", ex.Message);
				Logger.ServiceConfiguration = ServiceConfiguration;
                Logger.Write(System, RequestID, CurrentUser, "CommonDictionarySvc.Create", SvcLogLevel, variables);
                throw ex;
			}
            return this;
        }

        [Method("Update", MethodType.Update, "Update", "Update",
            new string[] { },
            new string[] { "System", "ID","ProcessCode","Type","SubType","SubSubType","Code","Value","OrderId","CreateBy","CreateTime","UpdateBy","UpdateTime","IsActive" },
            new string[] { })]
        public void Update()
        {
			try
			{
				CommonDictionaryService service = new CommonDictionaryService(ConnString);
				var entity = ToEntity();
                entity.UpdateBy = CurrentUser;
                entity.UpdateTime = DateTime.Now;
				service.Update(entity);
			}
			catch(Exception ex)
			{
				Dictionary<string, object> variables = new Dictionary<string, object>() { };
                variables.Add("ID", ID);
                variables.Add("Msg", ex.Message);
				Logger.ServiceConfiguration = ServiceConfiguration;
                Logger.Write(System, RequestID, CurrentUser, "CommonDictionarySvc.Update", SvcLogLevel, variables);
                throw ex;
			}
        }

        [Method("Delete", MethodType.Delete, "Delete", "Delete",
            new string[] { },
            new string[] { "System", "ID" },
            new string[] { })]
        public void Delete()
        {
			try
			{
				CommonDictionaryService service = new CommonDictionaryService(ConnString);
				service.Delete(ID);
			}
			catch(Exception ex)
			{
				Dictionary<string, object> variables = new Dictionary<string, object>() { };
                variables.Add("ID", ID);
                variables.Add("Msg", ex.Message);
				Logger.ServiceConfiguration = ServiceConfiguration;
                Logger.Write(System, RequestID, CurrentUser, "CommonDictionarySvc.Delete", SvcLogLevel, variables);
                throw ex;
			}
        }

        [Method("List", MethodType.List, "List", "List",
            new string[] { },
            new string[] { "System", "ID","ProcessCode","Type","SubType","SubSubType","Code","Value","OrderId","CreateBy","CreateTime","UpdateBy","UpdateTime","IsActive" },
            new string[] { "ID","ProcessCode","Type","SubType","SubSubType","Code","Value","OrderId","CreateBy","CreateTime","UpdateBy","UpdateTime","IsActive" })]
        public List<CommonDictionarySvc> List()
        {
			List<CommonDictionary> entityList = new List<CommonDictionary>();
			List<CommonDictionarySvc> result = new List<CommonDictionarySvc>();
			try
			{
				var conditions = BuildConditions();
				QueryDescriptor descriptor = new QueryDescriptor() { Conditions = conditions };
				using (RDCN_CSWF_DataContext db = new RDCN_CSWF_DataContext(ConnString))
				{
					entityList = db.CommonDictionary.Query(descriptor).ToList() ;
				}

				result = entityList.Select(m => GetFromEntity(m)).ToList();
			}
			catch(Exception ex)
			{
				Dictionary<string, object> variables = new Dictionary<string, object>() { };
                variables.Add("ID", ID);
                variables.Add("Msg", ex.Message);
				Logger.ServiceConfiguration = ServiceConfiguration;
                Logger.Write(System, RequestID, CurrentUser, "CommonDictionarySvc.List", SvcLogLevel, variables);
                throw ex;
			}
            return result;
        }

		private List<QueryCondition> BuildConditions()
        {
            List<QueryCondition> list = new List<QueryCondition>();
			if (ID != default(int))
			{
				QueryCondition condition = new QueryCondition();
				condition.Key = "ID";
				condition.Operator = QueryOperator.EQUAL;
				condition.Value = ID;
				condition.ValueType = typeof(int).GetTypeName();
				list.Add(condition);
			}
			if (ProcessCode != default(string))
			{
				QueryCondition condition = new QueryCondition();
				condition.Key = "ProcessCode";
				condition.Operator = QueryOperator.CONTAINS;
				condition.Value = ProcessCode;
				condition.ValueType = typeof(string).GetTypeName();
				list.Add(condition);
			}
			if (Type != default(string))
			{
				QueryCondition condition = new QueryCondition();
				condition.Key = "Type";
				condition.Operator = QueryOperator.CONTAINS;
				condition.Value = Type;
				condition.ValueType = typeof(string).GetTypeName();
				list.Add(condition);
			}
			if (SubType != default(string))
			{
				QueryCondition condition = new QueryCondition();
				condition.Key = "SubType";
				condition.Operator = QueryOperator.CONTAINS;
				condition.Value = SubType;
				condition.ValueType = typeof(string).GetTypeName();
				list.Add(condition);
			}
			if (SubSubType != default(string))
			{
				QueryCondition condition = new QueryCondition();
				condition.Key = "SubSubType";
				condition.Operator = QueryOperator.CONTAINS;
				condition.Value = SubSubType;
				condition.ValueType = typeof(string).GetTypeName();
				list.Add(condition);
			}
			if (Code != default(string))
			{
				QueryCondition condition = new QueryCondition();
				condition.Key = "Code";
				condition.Operator = QueryOperator.CONTAINS;
				condition.Value = Code;
				condition.ValueType = typeof(string).GetTypeName();
				list.Add(condition);
			}
			if (Value != default(string))
			{
				QueryCondition condition = new QueryCondition();
				condition.Key = "Value";
				condition.Operator = QueryOperator.CONTAINS;
				condition.Value = Value;
				condition.ValueType = typeof(string).GetTypeName();
				list.Add(condition);
			}
			if (OrderId != default(int))
			{
				QueryCondition condition = new QueryCondition();
				condition.Key = "OrderId";
				condition.Operator = QueryOperator.EQUAL;
				condition.Value = OrderId;
				condition.ValueType = typeof(int).GetTypeName();
				list.Add(condition);
			}
			if (CreateBy != default(string))
			{
				QueryCondition condition = new QueryCondition();
				condition.Key = "CreateBy";
				condition.Operator = QueryOperator.CONTAINS;
				condition.Value = CreateBy;
				condition.ValueType = typeof(string).GetTypeName();
				list.Add(condition);
			}
			if (CreateTime != default(System.DateTime))
			{
				QueryCondition condition = new QueryCondition();
				condition.Key = "CreateTime";
				condition.Operator = QueryOperator.EQUAL;
				condition.Value = CreateTime;
				condition.ValueType = typeof(System.DateTime).GetTypeName();
				list.Add(condition);
			}
			if (UpdateBy != default(string))
			{
				QueryCondition condition = new QueryCondition();
				condition.Key = "UpdateBy";
				condition.Operator = QueryOperator.CONTAINS;
				condition.Value = UpdateBy;
				condition.ValueType = typeof(string).GetTypeName();
				list.Add(condition);
			}
			if (UpdateTime != default(System.DateTime))
			{
				QueryCondition condition = new QueryCondition();
				condition.Key = "UpdateTime";
				condition.Operator = QueryOperator.EQUAL;
				condition.Value = UpdateTime;
				condition.ValueType = typeof(System.DateTime).GetTypeName();
				list.Add(condition);
			}
			if (IsActive != default(Nullable<bool>))
			{
				QueryCondition condition = new QueryCondition();
				condition.Key = "IsActive";
				condition.Operator = QueryOperator.EQUAL;
				condition.Value = IsActive;
				condition.ValueType = typeof(Nullable<bool>).GetTypeName();
				list.Add(condition);
			}
            return list;
        }
    }
}
