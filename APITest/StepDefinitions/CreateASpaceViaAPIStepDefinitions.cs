using System;
using TechTalk.SpecFlow;
using Xunit;
using APITest.Knime;

namespace APITest.StepDefinitions
{
    [Binding]
    public class CreateASpaceViaAPIStepDefinitions
    {
        KnimeAPI api = new KnimeAPI();

        [When(@"The logged in user requests the first api in oreder to call spaces")]
        public async void WhenTheLoggedInUserRequestsTheFirstApiInOrederToCallSpaces()
        {
            var response = await api.Get_Knime();
            Assert.NotNull(response);
        }

        [Then(@"The logged in user requsts create a new space first api")]
        public async void ThenTheLoggedInUserRequstsCreateANewSpaceFirstApi()
        {
            var response = await api.Get_New_Spaces();
            Assert.NotNull(response);
        }

        [Then(@"The logged in user requsts create a new space second api")]
        public async void ThenTheLoggedInUserRequstsCreateANewSpaceSecondApi()
        {
            var response = await api.Second_Request_Get_New_Spaces();
            Assert.NotNull(response);
        }

        [Then(@"The logged in user requsts create a new space third api")]
        public async void ThenTheLoggedInUserRequstsCreateANewSpaceThirdApi()
        {
            var response = await api.Third_Request_Get_New_Spaces();
            Assert.NotNull(response);
        }

        [Then(@"The logged in user requsts create a new space fourth api")]
        public async void ThenTheLoggedInUserRequstsCreateANewSpaceFourthApi()
        {
            var response = await api.Fourth_Request_Get_New_Spaces();
            Assert.NotNull(response);
        }

    }
}
