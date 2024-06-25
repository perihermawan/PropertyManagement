using System;
using System.Collections.Generic;
using Microsoft.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using propertymanagement.service.Commons;
using propertymanagement.service.Repositories.IRepositories;
using propertymanagement.service.Models.Master;
using propertymanagement.service.Models.ViewModel;


namespace propertymanagement.service.Repositories
{
    public class ARPaymentRepository : DatabaseConfig, IARPaymentRepository
    {
        #region Constructor
        public ARPaymentRepository() : base() { }
        public ARPaymentRepository(DatabaseContext context) : base(context) { }
        #endregion

        #region Service to database

        #region GET
        public async Task<List<RentVoucherListModel>> GetARPaymentList()
        {
            List<RentVoucherListModel> listARPayment = new List<RentVoucherListModel>();
            try
            {
                listARPayment = (from a in Context.dbset_VW_RentVoucherList
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
            return listARPayment;
        }
        #endregion

        #endregion
    }
}
