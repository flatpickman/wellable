using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using WellableBusinessService.WellableData;

namespace WellableBusinessService
{
    public class Wellable
    {
        public static WellableDbEntities Data
        {
            get {
                    string dataServiceUri = ConfigurationManager.AppSettings["WellableDataServicUri"];
                    WellableBusinessService.WellableData.WellableDbEntities proxy = new
                    WellableBusinessService.WellableData.WellableDbEntities(new Uri(dataServiceUri));
                    return proxy;
                }
        }



        /// <summary>
        /// Static method to get a datacontext by sending a dynamic service uri instead of the one from the appsettings
        /// </summary>
        /// <param name="dataServiceUri">The uri of the Wellable data service</param>
        /// <returns></returns>
        public static WellableDbEntities WellableDb(string dataServiceUri)
        {
            WellableBusinessService.WellableData.WellableDbEntities proxy = new
            WellableBusinessService.WellableData.WellableDbEntities(new Uri(dataServiceUri));
            return proxy;
        }
    }
}