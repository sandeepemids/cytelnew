using Simulation.Models.StatisticalDesignModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace Simulation.Api.Test.TestData
{
	public static class SimulationModelData
	{
		public static FixSampleScenario fixSampleScenarioValid = new FixSampleScenario
		{
			MsgVersion = (long)1.0,
			MsgType = "engine",
			MsgId = Guid.NewGuid(),
			Target = new FixSampleScenario.TargetModel
			{
				Location = "//regstry.docker.com/cytel/",
				Name = "2-arm-TimeToEvent-GroupSequential",
				Id = 123,
				Version = "1.0.0"
			},
			ComputeInfo = new List<FixSampleScenario.ComputeInfoModel>
			{
				new FixSampleScenario.ComputeInfoModel { Stage = "SimulationService",ReceivedTime = "20200402-12:23:31.342",SentTime = "20200402-12:23:33.348" },
				new FixSampleScenario.ComputeInfoModel { Stage = "InputQueue", ReceivedTime = "20200402-12:23:31.342", SentTime = "20200402-12:23:33.348" },
				new FixSampleScenario.ComputeInfoModel { Stage = "MonolithEngine", ReceivedTime = "20200402-12:23:33.349", SentTime = "20200402-12:23:53.350" }, // NEED TO CHECK, RAM= 123464353, CpuTime= 24231, "elapsedTime= 234325.234 },                    
				new FixSampleScenario.ComputeInfoModel { Stage = "OutputQueue", ReceivedTime = "20200402-12:23:53.352", SentTime = "20200402-12:23:53.369" },
				new FixSampleScenario.ComputeInfoModel { Stage = "StorageService", ReceivedTime = "20200402-12:23:31.342", SentTime = "20200402-12:23:33.348" },
			},
			Project = new FixSampleScenario.ProjectModel
			{
				ScenarioId = "bd57e927227311eaa3270b9e81dab55e",
				ProjectName = "Project Name",
				TimeUnit = "Month",
				ControlArm = "Salvage Chemo",
				TreatmentArm = "Quizartinib",
				NumberOfSim = 10000,
				SimSeed = 1234567
			},
			Population = new FixSampleScenario.PopulationModel
			{
				PopulationId = "bd57e92722731we1ea3270b9e81dab55e",
				Name = "Population Name",
				VirtualPopulationSize = 10000,
				EndpointModel = new List<FixSampleScenario.EndpointModel>
				{
					new FixSampleScenario.EndpointModel
					{
						Name = "Overall Survival",
						Endpoint = "Overall Survival",
						Type = "Time to Event",
						ModelName = "Exponential",
						InputMethod = "Median Survival Time",
						InputData = new List<FixSampleScenario.InputDataEndpointModel>
						{
							new FixSampleScenario.InputDataEndpointModel
							{
								Control = (long)0.035,
								Treatment = (long)0.017,
								HazardRatio = (long)0.486
							},
							new FixSampleScenario.InputDataEndpointModel
							{
								Control = (long)0.039,
								Treatment = (long)0.019,
								HazardRatio = (long)0.489
							},
						}
					},
					new FixSampleScenario.EndpointModel
					{
						Name = "Progress Free Survival",
						Endpoint = "Progress Free Survival",
						Type = "Time to Event",
						ModelName = "Exponential",
						InputMethod = "Median Survival Time",
						InputData = new List<FixSampleScenario.InputDataEndpointModel>
						{
							new FixSampleScenario.InputDataEndpointModel
							{
								Control = (long)0.035,
								Treatment = (long)0.017,
								HazardRatio = (long)0.486
							},
							new FixSampleScenario.InputDataEndpointModel
							{
								Control = (long)0.039,
								Treatment = (long)0.019,
								HazardRatio = (long)0.489
							},
						}
					}
				},
				DropoutRateModel = new FixSampleScenario.DropoutRateDataModel
				{
					ModelName = "Probability of Dropout",
					InputMethod = "Exponential",
					InputData = new List<FixSampleScenario.InputDataDropRateModel>
						{
							new FixSampleScenario.InputDataDropRateModel
							{
								ByTime = 10,
								Control = (long)0.035,
								Treatment = (long)0.017
							},
							new FixSampleScenario.InputDataDropRateModel
							{
								ByTime = 12,
								Control = (long)0.037,
								Treatment = (long)0.018
							},
						},
				},
			},
			Enrollment = new FixSampleScenario.EnrollmentModel
			{
				EnrollmentId = "fg57e92722731we1ea4570b9e81dab55e",
				Name = "Enrollment Name 1",
				InputMethod = "Accrual Rate",
				Distribution = "Uniform",
				Sites = new List<FixSampleScenario.SitesModel>
				{
					new FixSampleScenario.SitesModel
					{
						Geography = "USA",
						SiteInititationTime = 0,
						AvgPatientsEnrolled = 20,
						EnrollmentCap = (long)33.33
					},
					new FixSampleScenario.SitesModel
					{
						Geography = "UK",
						SiteInititationTime = 0,
						AvgPatientsEnrolled = 22,
						EnrollmentCap = (long)44.44
					},
				}
			},
			Design = new FixSampleScenario.DesignModel
			{
				Name = "Name of Design",
				PrimaryEndpoint = "Overall Survival",
				NumberOfArms = 2,
				RegulatoryRiskAssessment = "Low",
				StatisticalDesign = "Fixed Sample",
				Hypothesis = "Superiority",
				NumberOfEvents = 120,
				SampleSize = 400,
				AllocationRatio = (long)3.5,
				SubjectsAreFollowedType = "Fixed Period",
				SubjectsAreFollowedPeriod = 3,
				Type1Error = (long)0.5,
				TestStatistics = "Logrank",
				TestType = "1-Sided",
				TailType = "Left Tail",
				CriticalPoint = (long)-1.96
			},
			SimulationResults = new FixSampleScenario.SimulationResultsModel()
		};

		public static FixSampleScenario fixSampleScenarioInvalid = new FixSampleScenario
		{
			MsgVersion = (long)1.0,
			MsgType = "engine",
			MsgId = Guid.NewGuid(),
			Target = new FixSampleScenario.TargetModel
			{
				Location = "//regstry.docker.com/cytel/",
				Name = "2-arm-TimeToEvent-GroupSequential",
				Id = 123,
				Version = "1.0.0"
			},
			ComputeInfo = new List<FixSampleScenario.ComputeInfoModel>
			{
				new FixSampleScenario.ComputeInfoModel { Stage = "SimulationService", ReceivedTime = "20200402-12:23:31.342" },
				new FixSampleScenario.ComputeInfoModel { Stage = "InputQueue", ReceivedTime = "20200402-12:23:31.342", SentTime = "20200402-12:23:33.348" },
				new FixSampleScenario.ComputeInfoModel { Stage = "MonolithEngine", ReceivedTime = "20200402-12:23:33.349", SentTime = "20200402-12:23:53.350" }, // NEED TO CHECK, RAM= 123464353, CpuTime= 24231, "elapsedTime= 234325.234 },                    
				new FixSampleScenario.ComputeInfoModel { Stage = "OutputQueue" },
				new FixSampleScenario.ComputeInfoModel { Stage = "StorageService", ReceivedTime = "20200402-12:23:31.342", SentTime = "20200402-12:23:33.348" },
			},
			Population = new FixSampleScenario.PopulationModel
			{
				PopulationId = "bd57e92722731we1ea3270b9e81dab55e",
				Name = "Population Name",
				VirtualPopulationSize = 10000,
				EndpointModel = new List<FixSampleScenario.EndpointModel>
				{
					new FixSampleScenario.EndpointModel
					{
						Name = "Overall Survival",
						Endpoint = "Overall Survival",
						Type = "Time to Event",
						ModelName = "Exponential",
						InputMethod = "Median Survival Time",
						InputData = new List<FixSampleScenario.InputDataEndpointModel>
						{
							new FixSampleScenario.InputDataEndpointModel
							{
								Control = (long)0.035,
								Treatment = (long)0.017,
								HazardRatio = (long)0.486
							},
							new FixSampleScenario.InputDataEndpointModel
							{
								Control = (long)0.039,
								Treatment = (long)0.019,
								HazardRatio = (long)0.489
							},
						}
					},
					new FixSampleScenario.EndpointModel
					{
						Name = "Progress Free Survival",
						Endpoint = "Progress Free Survival",
						Type = "Time to Event",
						ModelName = "Exponential",
						InputMethod = "Median Survival Time"
						}
				},
				DropoutRateModel = new FixSampleScenario.DropoutRateDataModel
				{
					ModelName = "Probability of Dropout",
					InputMethod = "Exponential",
					InputData = new List<FixSampleScenario.InputDataDropRateModel>
						{
							new FixSampleScenario.InputDataDropRateModel
							{
								ByTime = 10,
								Control = (long)0.035,
								Treatment = (long)0.017
							},
							new FixSampleScenario.InputDataDropRateModel
							{
								ByTime = 12,
								Control = (long)0.037,
								Treatment = (long)0.018
							},
						},
				},
			},
			Enrollment = new FixSampleScenario.EnrollmentModel
			{
				EnrollmentId = "fg57e92722731we1ea4570b9e81dab55e",
				Name = "Enrollment Name 1",
				InputMethod = "Accrual Rate",
				Distribution = "Uniform",
				Sites = new List<FixSampleScenario.SitesModel>
				{
					new FixSampleScenario.SitesModel
					{
						Geography = "USA",
						SiteInititationTime = 0,
						AvgPatientsEnrolled = 20,
						EnrollmentCap = (long)33.33
					},
					new FixSampleScenario.SitesModel
					{
						Geography = "UK",
						SiteInititationTime = 0,
						AvgPatientsEnrolled = 22,
						EnrollmentCap = (long)44.44
					},
				}
			},
			Design = new FixSampleScenario.DesignModel
			{
				Name = "Name of Design",
				PrimaryEndpoint = "Overall Survival",
				NumberOfArms = 2,
				RegulatoryRiskAssessment = "Low",
				StatisticalDesign = "Fixed Sample",
				AllocationRatio = (long)3.5,
				SubjectsAreFollowedType = "Fixed Period",
				SubjectsAreFollowedPeriod = 3,
				Type1Error = (long)0.5,
				TestStatistics = "Logrank",
				TestType = "1-Sided",
				TailType = "Left Tail",
				CriticalPoint = (long)-1.96
			},
			SimulationResults = new FixSampleScenario.SimulationResultsModel()
		};
	}
}
