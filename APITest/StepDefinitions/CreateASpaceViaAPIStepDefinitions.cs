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

        [When(@"The logged in user requests the second api in oreder to call spaces")]
        public async void WhenTheLoggedInUserRequestsTheSecondApiInOrederToCallSpaces()
        {
            var response = await api.Get_Spaces();
            Assert.NotNull(response);
        }

        [When(@"The logged in user requests the third api in oreder to call spaces")]
        public void WhenTheLoggedInUserRequestsTheThirdApiInOrederToCallSpaces()
        {
            
        }
    }
}
