using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using propertymanagement.service.Models;
using propertymanagement.service.Models.Master;

namespace propertymanagement.service.Helpers
{
    public static class GlobalCache
    {
        private static string uniqueUser = "WCS";

        public static List<UserAppModel> GetUser()
        {
            return CacheStore.Get<List<UserAppModel>>(uniqueUser);
        }

        public static void SetUser(UserAppModel model)
        {     
            CacheStore.Add<UserAppModel>(uniqueUser, model);
        }

        public static void ClearPCA()
        {
            CacheStore.Remove<UserAppModel>(uniqueUser);
        }
        public static void ClearListUser()
        {
            CacheStore.Remove<List<UserAppModel>>(uniqueUser);
        }

        public static void SetListUser(List<UserAppModel> listmodel)
        {  
            CacheStore.Add<List<UserAppModel>>(uniqueUser, listmodel);
        }
    }
}