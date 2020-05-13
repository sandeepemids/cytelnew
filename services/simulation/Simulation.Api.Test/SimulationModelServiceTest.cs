using Moq;
using Newtonsoft.Json;
using Simulation.Api.Test.TestData;
using SimulationModel.Service;
using SimulationModel.Service.Interfaces;
using System;
using System.Collections.Generic;
using Xunit;

namespace Simulation.Api.Test
{
    public class SimulationModelServiceTest
    {
        [Fact]
        public void SimulateModelValid()
        {
            object jsonMessage = SimulationModelData.fixSampleScenarioValid;
            var expectedResult = new SimulationResponse()
            {
                ErrorMessages = null,
                QueueMessage = @"{'msgVersion':1.0,'msgType':'engine','msgId':123456789,'target':{'location':'//regstry.docker.com/cytel/','name':'2-arm-TimeToEvent-GroupSequential','id':123,'version':1.0},'computeInfo':[{'stage':'SimulationService','receivedTime':'20200402-12:23:31.342','sentTime':'20200402-12:23:33.348'},{'stage':'InputQueue','receivedTime':'20200402-12:23:31.342','sentTime':'20200402-12:23:33.348'},{'stage':'MonolithEngine','receivedTime':'20200402-12:23:33.349','sentTime':'20200402-12:23:53.350'},{'stage':'OutputQueue','receivedTime':'20200402-12:23:53.352','sentTime':'20200402-12:23:53.369'},{'stage':'StorageService','receivedTime':'20200402-12:23:31.342','sentTime':'20200402-12:23:33.348'}],'project':{'scenarioId':'bd57e927227311eaa3270b9e81dab55e','projectName':'Project Name','timeUnit':'Month','controlArm':'Salvage Chemo','treatmentArm':'Quizartinib','numberOfSim':10000,'simSeed':1234567},'population':{'populationId':'bd57e92722731we1ea3270b9e81dab55e','name':'Population Name','virtualPopulationSize':10000,'endpointModel':[{'name':'Overall Survival','endpoint':'Overall Survival','type':'Time to Event','modelName':'Exponential','inputMethod':'Median Survival Time','inputData':[{'control':0.0,'treatment':0.0,'hazardRatio':0.0},{'control':0.0,'treatment':0.0,'hazardRatio':0.0}]},{'name':'Progress Free Survival','endpoint':'Progress Free Survival','type':'Time to Event','modelName':'Exponential','inputMethod':'Median Survival Time','inputData':[{'control':0.0,'treatment':0.0,'hazardRatio':0.0},{'control':0.0,'treatment':0.0,'hazardRatio':0.0}]}],'dropoutRateModel':{'modelName':'Probability of Dropout','inputMethod':'Exponential','inputData':[{'byTime':10.0,'control':0.0,'treatment':0.0},{'byTime':12.0,'control':0.0,'treatment':0.0}]}},'enrollment':{'name':'Enrollment Name 1','inputMethod':'Accrual Rate','distribution':'Uniform','sites':[{'geography':'USA','siteInititationTime':0,'avgPatientsEnrolled':20,'enrollmentCap':33.0},{'geography':'UK','siteInititationTime':0,'avgPatientsEnrolled':22,'enrollmentCap':44.0}],'enrollmentId':'fg57e92722731we1ea4570b9e81dab55e'},'design':{'name':'Name of Design','primaryEndpoint':'Overall Survival','numberOfArms':2,'regulatoryRiskAssessment':'Low','statisticalDesign':'Fixed Sample','hypothesis':'Superiority','numberOfEvents':120,'sampleSize':400,'allocationRatio':3.0,'subjectsAreFollowedType':'Fixed Period','subjectsAreFollowedPeriod':3,'type1Error':0.0,'testStatistics':'Logrank','testType':'1-Sided','tailType':'Left Tail','criticalPoint':-1.0},'simulationResults':{}}"
            };

            var simulationService = new Mock<ISimulationModelService>();
            simulationService.Setup(service => service.SimulateModel("FixSampleJsonSchema.json", JsonConvert.SerializeObject(jsonMessage)))
                .Returns(expectedResult);
            var actualResult = simulationService.Object.SimulateModel("FixSampleJsonSchema.json", JsonConvert.SerializeObject(jsonMessage));
            Assert.NotNull(actualResult);
            Assert.Equal(expectedResult.ErrorMessages, actualResult.ErrorMessages);
            Assert.Equal(expectedResult.QueueMessage, actualResult.QueueMessage);
        }

        [Fact]
        public void SimulateModelInvalid()
        {
            var jsonMessage = SimulationModelData.fixSampleScenarioInvalid;
            IList<string> errorMessage = new List<string>
            {
                "Invalid type. Expected String but got Null. Path 'computeInfo[0].sentTime', line 1, position 271.",
                "Invalid type. Expected String but got Null. Path 'computeInfo[3].receivedTime', line 1, position 513.",
                "Invalid type. Expected String but got Null. Path 'computeInfo[3].sentTime', line 1, position 529.",
                "Invalid type. Expected Object but got Null. Path 'project', line 1, position 647.",
                "Invalid type. Expected Array but got Null. Path 'population.endpointModel[1].inputData', line 1, position 1214.",
                "Invalid type. Expected String but got Null. Path 'design.hypothesis', line 1, position 1919."
            };

            var expectedResult = new SimulationResponse()
            {
                ErrorMessages = errorMessage,
                QueueMessage = null
            };
            var simulationService = new Mock<ISimulationModelService>();
            simulationService.Setup(service => service.SimulateModel("FixSampleJsonSchema.json", JsonConvert.SerializeObject(jsonMessage))).Returns(expectedResult);
            var actualResult = simulationService.Object.SimulateModel("FixSampleJsonSchema.json", JsonConvert.SerializeObject(jsonMessage));
            Assert.NotNull(actualResult);
            Assert.Equal(expectedResult.ErrorMessages, actualResult.ErrorMessages);
            Assert.Equal(expectedResult.QueueMessage, actualResult.QueueMessage);
        }

        [Fact]
        public void CreateSimulationQueue()
        {
            var queueMessage = @"{'msgVersion':1.0,'msgType':'engine','msgId':123456789,'target':{'location':'//regstry.docker.com/cytel/','name':'2-arm-TimeToEvent-GroupSequential','id':123,'version':1.0},'computeInfo':[{'stage':'SimulationService','receivedTime':'20200402-12:23:31.342','sentTime':'20200402-12:23:33.348'},{'stage':'InputQueue','receivedTime':'20200402-12:23:31.342','sentTime':'20200402-12:23:33.348'},{'stage':'MonolithEngine','receivedTime':'20200402-12:23:33.349','sentTime':'20200402-12:23:53.350'},{'stage':'OutputQueue','receivedTime':'20200402-12:23:53.352','sentTime':'20200402-12:23:53.369'},{'stage':'StorageService','receivedTime':'20200402-12:23:31.342','sentTime':'20200402-12:23:33.348'}],'project':{'scenarioId':'bd57e927227311eaa3270b9e81dab55e','projectName':'Project Name','timeUnit':'Month','controlArm':'Salvage Chemo','treatmentArm':'Quizartinib','numberOfSim':10000,'simSeed':1234567},'population':{'populationId':'bd57e92722731we1ea3270b9e81dab55e','name':'Population Name','virtualPopulationSize':10000,'endpointModel':[{'name':'Overall Survival','endpoint':'Overall Survival','type':'Time to Event','modelName':'Exponential','inputMethod':'Median Survival Time','inputData':[{'control':0.0,'treatment':0.0,'hazardRatio':0.0},{'control':0.0,'treatment':0.0,'hazardRatio':0.0}]},{'name':'Progress Free Survival','endpoint':'Progress Free Survival','type':'Time to Event','modelName':'Exponential','inputMethod':'Median Survival Time','inputData':[{'control':0.0,'treatment':0.0,'hazardRatio':0.0},{'control':0.0,'treatment':0.0,'hazardRatio':0.0}]}],'dropoutRateModel':{'modelName':'Probability of Dropout','inputMethod':'Exponential','inputData':[{'byTime':10.0,'control':0.0,'treatment':0.0},{'byTime':12.0,'control':0.0,'treatment':0.0}]}},'enrollment':{'name':'Enrollment Name 1','inputMethod':'Accrual Rate','distribution':'Uniform','sites':[{'geography':'USA','siteInititationTime':0,'avgPatientsEnrolled':20,'enrollmentCap':33.0},{'geography':'UK','siteInititationTime':0,'avgPatientsEnrolled':22,'enrollmentCap':44.0}],'enrollmentId':'fg57e92722731we1ea4570b9e81dab55e'},'design':{'name':'Name of Design','primaryEndpoint':'Overall Survival','numberOfArms':2,'regulatoryRiskAssessment':'Low','statisticalDesign':'Fixed Sample','hypothesis':'Superiority','numberOfEvents':120,'sampleSize':400,'allocationRatio':3.0,'subjectsAreFollowedType':'Fixed Period','subjectsAreFollowedPeriod':3,'type1Error':0.0,'testStatistics':'Logrank','testType':'1-Sided','tailType':'Left Tail','criticalPoint':-1.0},'simulationResults':{}}";

            var simulationService = new Mock<ISimulationModelService>();
            simulationService.Setup(service => service.CreateSimulationQueue(queueMessage)).Returns(true);
            var actualResult = simulationService.Object.CreateSimulationQueue(queueMessage);
            Assert.True(actualResult);
        }
    }
}
