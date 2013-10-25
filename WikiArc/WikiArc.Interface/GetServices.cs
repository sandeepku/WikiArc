using ServiceStack.ServiceHost;
using ServiceStack.ServiceInterface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WikiArc.Model.Operations;
using WikiArc.Model.Types;

namespace WikiArc.Interface
{
    /// <summary>
    /// Get the service listing for the wikiarc 
    /// available for the "/services" endpoint
    /// </summary>
    [ClientCanSwapTemplates]
    [DefaultView("services")]
    public class GetServices : ServiceStack.ServiceInterface.Service
    {
        public object Any(services request)
        {
            //get details from the rtegistered DB.
            servicesResponse serviceResponse = new servicesResponse();
            service service;

            try
            {
                //initialize a new service
                //TODO...hard code this as of now...will think of a configuration later
                //define the point layer
                service = new service();
                service.name = "WikiMapLocations";
                service.type = "FeatureServer";
                serviceResponse.services.Add(service);
                /*
                //define the polygon layer
                service = new service();
                service.name = "WikiMapRegions";
                service.type = "FeatureServer";
                serviceResponse.services.Add(service);

                //define the street layer
                service = new service();
                service.name = "WikiMapStreet";
                service.type = "FeatureServer";
                serviceResponse.services.Add(service);
                */
                //there will not be a folder as of now..will think of it.
                //so the folder would remain empty.
                

            }
            catch (Exception ex)
            {
                serviceResponse.ResponseStatus.Message = ex.Message;
                serviceResponse.ResponseStatus.StackTrace = ex.StackTrace;
            }

            return serviceResponse;

        }

    
    }
}
