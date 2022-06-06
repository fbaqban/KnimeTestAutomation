using APITest.Knime.Response;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APITest.Knime
{
    public class KnimeAPI
    {
        private HttpClient restClient = new HttpClient();
        private string baseURI = "https://api.hub.knime.com/";

        //Authorize a user URI
        private string firstURIForlogedinUser   = "repository/Users/fbaqban?";
        private string secondURIForLoggedinUser = "repository/Users/fbaqban/";
        private string thirdURIForlogedinUser   = "repository//Users/fbaqban";

        //Access to the logged in user spaces 
        private string firstCallForSpacesPageURI = "spaceDetails=true&contribSpaces=children";
        private string thirdCallForSpacesPageURI = "/onboarding/*NpxksCF7RpPQM17j";

        //Create a new space URI
        private string firstCallForNewSpaceCreationURI = "New%20space?overwrite=false";
        private string secondCallForNewSpaceCreationURI = "repository/*INpttpr0BUQQ5_Q6?details=aggregated&spaceDetails=true";
        //private string secondCallForNewSpaceCreationURI = "/New%20space?overwrite=false";
        private string thirdCallForNewSpaceCreationURI = "/New%20space%201?details=aggregated&spaceDetails=true";

        //Delete a space URI
        private string firstCallForSpaceDeletionURI = "/New%20space%202";


        public async Task<GetKnimeResponse> Get_Knime()
        {
            UriBuilder builder = new UriBuilder($"{baseURI}{firstURIForlogedinUser}{firstCallForSpacesPageURI}");
            var response = await restClient.GetAsync(builder.Uri);
            var context = await response.Content.ReadAsStringAsync();

            try
            {
                var responseModel = JsonConvert.DeserializeObject<GetKnimeResponse>(context);
                return responseModel;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw new Exception("Cannot deserialize context!");
            }

        }

        public async Task<GetKnimeResponse> Get_New_Spaces()
        {
            UriBuilder builder = new UriBuilder($"{baseURI}{secondURIForLoggedinUser}{firstCallForNewSpaceCreationURI}");
            var response = await restClient.GetAsync(builder.Uri);
            var context = await response.Content.ReadAsStringAsync();

            try
            {
                var responseModel = JsonConvert.DeserializeObject<GetKnimeResponse>(context);
                return responseModel;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw new Exception("Cannot deserialize context!");
            }

        }

        public async Task<GetKnimeResponse> Second_Request_Get_New_Spaces()
        {
            UriBuilder builder = new UriBuilder($"{baseURI}{firstURIForlogedinUser}");
            var response = await restClient.GetAsync(builder.Uri);
            var context = await response.Content.ReadAsStringAsync();

            try
            {
                var responseModel = JsonConvert.DeserializeObject<GetKnimeResponse>(context);
                return responseModel;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw new Exception("Cannot deserialize context!");
            }

        }

        public async Task<GetKnimeResponse> Third_Request_Get_New_Spaces()
        {
            UriBuilder builder = new UriBuilder($"{baseURI}{secondCallForNewSpaceCreationURI}{firstCallForSpacesPageURI}");
            var response = await restClient.GetAsync(builder.Uri);
            var context = await response.Content.ReadAsStringAsync();

            try
            {
                var responseModel = JsonConvert.DeserializeObject<GetKnimeResponse>(context);
                return responseModel;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw new Exception("Cannot deserialize context!");
            }

        }

        public async Task<GetKnimeResponse> Fourth_Request_Get_New_Spaces()
        {
            UriBuilder builder = new UriBuilder($"{baseURI}{firstURIForlogedinUser}{firstCallForSpacesPageURI}");
            var response = await restClient.GetAsync(builder.Uri);
            var context = await response.Content.ReadAsStringAsync();

            try
            {
                var responseModel = JsonConvert.DeserializeObject<GetKnimeResponse>(context);
                return responseModel;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw new Exception("Cannot deserialize context!");
            }

        }
    }
}

