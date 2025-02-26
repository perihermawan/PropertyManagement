﻿using System;
using System.Collections.Generic;
using System.Data;
using Microsoft.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using propertymanagement.service.Commons;
using propertymanagement.service.Repositories.IRepositories;
using propertymanagement.service.Models.Master;
using propertymanagement.service.Models.ViewModel;
using propertymanagement.service.Models;
using System.ComponentModel;
using Microsoft.EntityFrameworkCore;
using propertymanagement.service.Models.DTO;
using Microsoft.AspNetCore.Mvc;


namespace propertymanagement.service.Repositories
{
    public class MasterRepository : DatabaseConfig, IMasterRepository
    {
        #region Constructor
        public MasterRepository() : base() { }
        public MasterRepository(DatabaseContext context) : base(context) { }
        #endregion

        #region Service to database

        #region MasterCbo
        #region GET
        public async Task<List<DropDownList>> GetMasterCBOByCode(string code)
        {
            List<DropDownList> mCboList = new List<DropDownList>();
            //Dictionary<string, string> result = new Dictionary<string, string>;
            try
            {
                
                using (var context = new DatabaseContext(ContextOption))
                {
                    var param = new SqlParameter[]
                     {
                        new SqlParameter("@Code",code)
                     };
                    mCboList = await context.ExecuteStoredProcedure<DropDownList>("sp_get_MCbo", param);
                    //result = mCboList.ToDictionary(e => e.Key, e => e.Value);
                }
            }
            catch (Exception e)
            {
                throw new Exception("Error !, " + e.Message);
            }
            return mCboList;
        }

        #endregion
        #endregion

        #region MasterUnit
        #region GET


        public async Task<List<UnitListModel>> GetMasterUnitList()
        {
            List<UnitListModel> listUnit = new List<UnitListModel>();
            try
            {
                //listUnit = (from a in Context.dbset_VW_MsUnit
                //            orderby a.UpdateDate descending, a.CreateDate descending
                //            select a).ToList();
                //Context.Database.Comm
                using (var context = new DatabaseContext(ContextOption))
                {
                    var param = new SqlParameter[]
                     {
                        //new SqlParameter("@UnitId",(Guid)UnitId)
                     };
                    listUnit = await context.ExecuteStoredProcedure<UnitListModel>("sp_get_unitAll", param);
                }
            }
            catch (Exception e)
            {
                throw new Exception("Error !, " + e.Message);
            }
            return listUnit;
        }

        public async Task<ViewUnitModel> GetMasterUnitDetail(string Param)
        {
            ViewUnitModel UnitDetail = new ViewUnitModel();
            try
            {
                Guid UnitId = new Guid(Param);
                //Context.Database.Comm
                using (var context = new DatabaseContext(ContextOption))
                {
                    var param = new SqlParameter[]
                     {
                        new SqlParameter("@UnitId",(Guid)UnitId)
                     };
                    UnitDetail = await context.ExecuteStoredProcedureSingleValue<ViewUnitModel>("sp_Sel_MsUnitDetail_MAG", param);
                }
            }
            catch (Exception e)
            {
                throw new Exception("Error !, " + e.Message);
            }
            return UnitDetail;
        }
        #endregion

        #region DELETE
        public async Task<List<StatusResult>> DeleteUnitByUnitId(Guid unitId, string userId, string reason)
        {
            List<StatusResult> result = new List<StatusResult>();
            //var context = new DatabaseContext(ContextOption);
            //var transaction = context.Database.BeginTransaction();
            try
            {
                using (var context = new DatabaseContext(ContextOption))
                {
                    var param = new SqlParameter[]
                     {
                         new SqlParameter("@UnitID",unitId),
                        new SqlParameter("@Reason",(string)reason?? ""),
                        new SqlParameter("@DeleteUser",(string)userId ?? "")

                     };
                    result = await context.ExecuteStoredProcedure<StatusResult>("sp_del_JSONMsUnit", param);


                }
            }
            catch (Exception ex)
            {
                string str = ex.Message;
                //transaction.Rollback();
            }
            return result;
        }
        #endregion

        #endregion

        #region MasterEmployee

        #region GET
        public async Task<List<ViewEmployeeModel>> GetMasterEmployeeList()
        {
            List<ViewEmployeeModel> listEmployee = new List<ViewEmployeeModel>();
            try
            {
                //listUnit = (from a in Context.dbset_VW_MsUnit
                //            orderby a.UpdateDate descending, a.CreateDate descending
                //            select a).ToList();
                //Context.Database.Comm
                using (var context = new DatabaseContext(ContextOption))
                {
                    var param = new SqlParameter[]
                     {
                        //new SqlParameter("@UnitId",(Guid)UnitId)
                     };
                    listEmployee = await context.ExecuteStoredProcedure<ViewEmployeeModel>("sp_get_EmployeeAll", param);
                }
            }
            catch (Exception e)
            {
                throw new Exception("Error !, " + e.Message);
            }
            return listEmployee;
        }

        public async Task<EmployeeModel> GetMasterEmployeeById(int employeeid)
        {
            EmployeeModel employeedetail = new EmployeeModel();
            try
            {
                //listUnit = (from a in Context.dbset_VW_MsUnit
                //            orderby a.UpdateDate descending, a.CreateDate descending
                //            select a).ToList();
                //Context.Database.Comm
                using (var context = new DatabaseContext(ContextOption))
                {
                    var param = new SqlParameter[]
                     {
                        new SqlParameter("@employeeid",(int)employeeid)
                     };
                    employeedetail = await context.ExecuteStoredProcedureSingleValue<EmployeeModel>("sp_get_EmployeeById", param);
                }
            }
            catch (Exception e)
            {
                throw new Exception("Error !, " + e.Message);
            }
            return employeedetail;
        }

        public async Task<EmployeeModel> ValidateEmployeeByEmployeeNo(string employeeno)
        {
            EmployeeModel empdata = new EmployeeModel();
            try
            {
                //listUser = (from a in Context.dbset_VW_MsUser
                //            select new ViewUserModel { Id =  a.UserId, UserName = a.UserName, EMPLOYEEBASICINFOID = a.EmployeeNo, FullName = a.EmployeeName, Sex = a.Sex, Address = "", Email = a.Email, Password = a.Password, CompId = a.CompId, IsActive = a.IsActive}).ToList();
                //Context.Database.Comm
                using (var context = new DatabaseContext(ContextOption))
                {
                    var param = new SqlParameter[]
                     {
                        new SqlParameter("@EMPLOYEENO",(string)employeeno)

                     };
                    empdata = await context.ExecuteStoredProcedureSingleValue<EmployeeModel>("sp_ValidateEmployeeByEmployeeNo", param);
                }
            }
            catch (Exception e)
            {
                throw new Exception("Error !, " + e.Message);
            }
            return empdata;
        }

        #endregion

        #region Delete
        public async Task<List<StatusResult>> DeleteEmployeeById(int employeeid, string user)
        {
            List<StatusResult> employee = new List<StatusResult>();
            try
            {
                //listUnit = (from a in Context.dbset_VW_MsUnit
                //            orderby a.UpdateDate descending, a.CreateDate descending
                //            select a).ToList();
                //Context.Database.Comm
                using (var context = new DatabaseContext(ContextOption))
                {
                    var param = new SqlParameter[]
                     {
                        new SqlParameter("@employeeid",(int)employeeid),
                        new SqlParameter("@DeleteUser",(string)user)

                     };
                    employee = await context.ExecuteStoredProcedure<StatusResult>("sp_del_MasterEmployee", param);
                }
            }
            catch (Exception e)
            {
                throw new Exception("Error !, " + e.Message);
            }
            return employee;
        }

        #endregion


        #endregion

        #region MasterOutlet

        public async Task<List<ViewOutletModel>> GetMasterOutletList()
        {
            List<ViewOutletModel> listOutlet = new List<ViewOutletModel>();
            try
            {
                //listUnit = (from a in Context.dbset_VW_MsUnit
                //            orderby a.UpdateDate descending, a.CreateDate descending
                //            select a).ToList();
                //Context.Database.Comm
                using (var context = new DatabaseContext(ContextOption))
                {
                    var param = new SqlParameter[]
                     {
                        //new SqlParameter("@UnitId",(Guid)UnitId)
                     };
                    listOutlet = await context.ExecuteStoredProcedure<ViewOutletModel>("sp_get_OutletAll", param);
                }
            }
            catch (Exception e)
            {
                throw new Exception("Error !, " + e.Message);
            }
            return listOutlet;
        }

        public async Task<OutletModel> GetMasterOutletByOutletId(Guid outletid)
        {
            OutletModel outlet = new OutletModel();
            try
            {
                //listUnit = (from a in Context.dbset_VW_MsUnit
                //            orderby a.UpdateDate descending, a.CreateDate descending
                //            select a).ToList();
                //Context.Database.Comm
                using (var context = new DatabaseContext(ContextOption))
                {
                    var param = new SqlParameter[]
                     {
                        new SqlParameter("@OutletId",(Guid)outletid)
                     };
                    outlet = await context.ExecuteStoredProcedureSingleValue<OutletModel>("sp_sel_MsOutletByOutletId", param);
                }
            }
            catch (Exception e)
            {
                throw new Exception("Error !, " + e.Message);
            }
            return outlet;
        }

        #endregion

        #region MasterPrmOthers
        #region GET
        public async Task<List<ParamModel>> GetPrmOthers(string prmcode)
        {
            List<ParamModel> result = new List<ParamModel>();
            try
            {
                using (var context = new DatabaseContext(ContextOption))
                {
                    var param = new SqlParameter[]
                     {
                        new SqlParameter("@paramcode", prmcode)
                     };
                    result = await context.ExecuteStoredProcedure<ParamModel>("sp_sel_PrmOthers", param);
                }
            }
            catch (Exception e)
            {
                throw new Exception("Error !, " + e.Message);
            }
            return result;
        }
        #endregion
        #endregion


        #region MasterBuilding
        #region GET
        public async Task<List<BuildingModel>> GetBuilding()
        {
            List<BuildingModel> listBuilding = new List<BuildingModel>();
            try
            {
                listBuilding = (from a in Context.dbset_M_Building
                                where a.IsDeleted == false
                            select a).ToList();
                //Context.Database.Comm
                //using (var context = new DatabaseContext(ContextOption))
                //{
                //    listUserApp = await context.ExecuteStoredProcedure<UserAppModel>("sp_activity_get_all");
                //}
            }
            catch (Exception e)
            {
                throw new Exception("Error !, " + e.Message);
            }
            return listBuilding;
        }
        #endregion
        #endregion


        #region MasterTenantOwner
        public async Task<List<TenantOwnerViewModel>> GetTenantOwnerList(string type, Guid tenantOwnerId)
        {
            List<TenantOwnerViewModel> result = new List<TenantOwnerViewModel>();
            try
            {
                using (var context = new DatabaseContext(ContextOption))
                {
                    var param = new SqlParameter[]
                      {
                          new SqlParameter("@TenantOwnerId",(Guid)tenantOwnerId),
                          new SqlParameter("@Type",(string)type)
                      };
                    result = await context.ExecuteStoredProcedure<TenantOwnerViewModel>("sp_sel_MsTenantOwner", param);
                }
            }
            catch (Exception e)
            {
                throw new Exception("Error !, " + e.Message);
            }
            return result;
        }

        public async Task<InvoiceTo> GetTenantOwnerInvoiceTo(Guid tenantOwnerId)
        {
            InvoiceTo result = new InvoiceTo();
            try
            {
                using (var context = new DatabaseContext(ContextOption))
                {
                    var param = new SqlParameter[]
                    {
                        new SqlParameter("@InvId",(Guid)tenantOwnerId)
                    };
                    result = await context.ExecuteStoredProcedureSingleValue<InvoiceTo>("sp_sel_MsInvoiceTo", param);
                }
            }
            catch (Exception e)
            {
                throw new Exception("Error !, " + e.Message);
            }
            return result;
        }

        public async Task<PersonInCharge> GetTenantOwnerPersonInCharge(Guid tenantOwnerId)
        {
            PersonInCharge result = new PersonInCharge();
            try
            {
                using (var context = new DatabaseContext(ContextOption))
                {
                    var param = new SqlParameter[]
                    {
                        new SqlParameter("@PicId",(Guid)tenantOwnerId)
                    };
                    result = await context.ExecuteStoredProcedureSingleValue<PersonInCharge>("sp_sel_MsPic", param);
                }
            }
            catch (Exception e)
            {
                throw new Exception("Error !, " + e.Message);
            }
            return result;
        }
        public async Task<Correspondence> GetTenantOwnerCorrespondence(Guid tenantOwnerId)
        {
            Correspondence result = new Correspondence();
            try
            {
                using (var context = new DatabaseContext(ContextOption))
                {
                    var param = new SqlParameter[]
                    {
                        new SqlParameter("@CorrId",(Guid)tenantOwnerId)
                    };
                    result = await context.ExecuteStoredProcedureSingleValue<Correspondence>("sp_sel_MsCorrespondence", param);
                }
            }
            catch (Exception e)
            {
                throw new Exception("Error !, " + e.Message);
            }
            return result;
        }

        #endregion


        public SqlParameter CreateSqlParamLeaveRequest(string parameterName, DataTable listData, string typeName)
        {

            var paramStruct = new Microsoft.Data.SqlClient.SqlParameter(parameterName, System.Data.SqlDbType.Structured);
            paramStruct.SqlDbType = SqlDbType.Structured;
            paramStruct.SqlValue = listData;
            paramStruct.TypeName = typeName;

            return paramStruct;
        }
        public static DataTable ConvertToDataTable<T>(IList<T> data)
        {
            PropertyDescriptorCollection props =
            TypeDescriptor.GetProperties(typeof(T));
            DataTable table = new DataTable();
            for (int i = 0; i < props.Count; i++)
            {
                PropertyDescriptor prop = props[i];
                table.Columns.Add(prop.Name, prop.PropertyType);
            }
            object[] values = new object[props.Count];
            foreach (T item in data)
            {
                for (int i = 0; i < values.Length; i++)
                {
                    values[i] = props[i].GetValue(item);
                }
                table.Rows.Add(values);
            }
            return table;
        }

        #endregion
    }
}
