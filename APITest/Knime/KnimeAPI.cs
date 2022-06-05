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

        private string firstURIForlogedinUser  = "repository/Users/fbaqban?";
        private string secondURIForlogedinUser = "extensions?owner=fbaqban";
        private string thirdURIForlogedinUser  = "repository//Users/fbaqban";

        private string firstCallForSpacesPageURI = "spaceDetails=true&contribSpaces=children";
        private string secondCallForSpacesPageURI = "&format=generic";
        private string thirdCallForSpacesPageURI = "/onboarding/*NpxksCF7RpPQM17j";

        private string firstCallForNewSpaceCreationURI = "/New%20space?overwrite=false";
        private string secondCallForNewSpaceCreationURI = "/New%20space%201?details=aggregated&spaceDetails=true";

        //Delete a space URI
        private string firstCallForSpaceDeletionURI = "/New%20space%202";

        //The third api for create action is the same as firstCallForSpacesPageURI//
        //The second api for delete action is the same as firstCallForSpacesPageURI//
        //private string thirdCallForNewSpaceCreationURI = "?spaceDetails=true&contribSpaces=children";

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

        public async Task<GetKnimeResponse> Get_Spaces()
        {
            UriBuilder builder = new UriBuilder($"{baseURI}{secondURIForlogedinUser}{secondCallForSpacesPageURI}");
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

