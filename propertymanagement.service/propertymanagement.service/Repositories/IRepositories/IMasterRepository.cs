﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using propertymanagement.service.Models.ViewModel;
using propertymanagement.service.Models.Master;
using propertymanagement.service.Models;
using propertymanagement.service.Models.DTO;

namespace propertymanagement.service.Repositories.IRepositories
{
    interface IMasterRepository
    {
        #region CBO
        Task<List<DropDownList>> GetMasterCBOByCode(string code);
        #endregion
        #region Unit
        Task<List<UnitListModel>> GetMasterUnitList();
        Task<ViewUnitModel> GetMasterUnitDetail(string Param);
        Task<List<StatusResult>> DeleteUnitByUnitId(Guid unitId, string userId, string reason);
        #endregion

        #region Employee
        Task<List<ViewEmployeeModel>> GetMasterEmployeeList();
        Task<EmployeeModel> GetMasterEmployeeById(int employeeid);
        Task<List<StatusResult>> DeleteEmployeeById(int employeeid, string user);
        Task<EmployeeModel> ValidateEmployeeByEmployeeNo(string employeeno);

        #endregion

        #region Outlet
        Task<List<ViewOutletModel>> GetMasterOutletList();
        Task<OutletModel> GetMasterOutletByOutletId(Guid outletid);
        #endregion

        #region Building
        Task<List<BuildingModel>> GetBuilding();
        #endregion
        #region PrmOthers
        Task<List<ParamModel>> GetPrmOthers(string prmcode);

        
        #endregion
        #region 
        Task<List<TenantOwnerViewModel>> GetTenantOwnerList(string type, Guid tenantOwnerId);
        Task<InvoiceTo> GetTenantOwnerInvoiceTo(Guid tenantOwnerId);
        Task<PersonInCharge> GetTenantOwnerPersonInCharge(Guid tenantOwnerId);
        Task<Correspondence> GetTenantOwnerCorrespondence(Guid tenantOwnerId);
        #endregion
    }
}
