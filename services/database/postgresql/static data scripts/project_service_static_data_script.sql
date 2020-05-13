BEGIN;
	--project."Status"
	INSERT INTO project."Status" ("ID", "Value") VALUES
								(1, 'In Progress'),
								(2, 'In Review'),
								(3, 'Complete');
	
	--project."Indication"
	INSERT INTO project."Indication"("ID", "Value")	VALUES 
									(1,	'Acute Lymphoblastic Leukemia (ALL)'),		
									(2,	'Acute Myeloid Leukemia (AML)'),
									(3,	'Adolescents Cancer'),
									(4,	'Adrenocortical Carcinoma'),
									(5,	'AIDS-Related Cancers | Kaposi Sarcoma (Soft Tissue Sarcoma)'),
									(6,	'AIDS-Related Cancers | AIDS-Related Lymphoma (Lymphoma)'),
									(7,	'AIDS-Related Cancers | Primary CNS Lymphoma (Lymphoma)'),
									(8,	'Anal Cancer'),
									(9,	'Appendix Cancer - see Gastrointestinal Carcinoid Tumors'),
									(10,	'Astrocytomas, Childhood (Brain Cancer)'),
									(11,	'Atypical Teratoid/Rhabdoid Tumor, Childhood, Central Nervous System (Brain Cancer)'),
									(12,	'Basal Cell Carcinoma of the Skin'),
									(13,	'Bile Duct Cancer'),
									(14,	'Bladder Cancer'),
									(15,	'Bone Cancer (includes Ewing Sarcoma and Osteosarcoma and Malignant Fibrous Histiocytoma)'),
									(16,	'Brain Tumors'),
									(17,	'Breast Cancer'),
									(18,	'Bronchial Tumors (Lung Cancer)'),
									(19,	'Burkitt Lymphoma - see Non-Hodgkin Lymphoma'),
									(20,	'Cancer in Young Adults'),
									(21,	'Carcinoid Tumor (Gastrointestinal)'),
									(22,	'Carcinoma of Unknown Primary'),
									(23,	'Cardiac (Heart) Tumors, Childhood'),
									(24,	'Central Nervous System | Atypical Teratoid/Rhabdoid Tumor, Childhood (Brain Cancer)'),
									(25,	'Central Nervous System | Medulloblastoma and Other CNS Embryonal Tumors, Childhood (Brain Cancer)'),
									(26,	'Central Nervous System | Germ Cell Tumor, Childhood (Brain Cancer)'),
									(27,	'Central Nervous System | Primary CNS Lymphoma'),
									(28,	'Cervical Cancer'),
									(29,	'Childhood Cancers'),
									(30,	'Cancers of Childhood, Unusual'),
									(31,	'Cholangiocarcinoma'),
									(32,	'Chordoma, Childhood (Bone Cancer)'),
									(33,	'Chronic Lymphocytic Leukemia (CLL)'),
									(34,	'Chronic Myelogenous Leukemia (CML)'),
									(35,	'Chronic Myeloproliferative Neoplasms'),
									(36,	'Colorectal Cancer'),
									(37,	'Craniopharyngioma, Childhood (Brain Cancer)'),
									(38,	'Cutaneous T-Cell Lymphoma'),
									(39,	'Ductal Carcinoma In Situ (DCIS)'),
									(40,	'Embryonal Tumors, Medulloblastoma and Other Central Nervous System, Childhood (Brain Cancer)'),
									(41,	'Endometrial Cancer (Uterine Cancer)'),
									(42,	'Ependymoma, Childhood (Brain Cancer)'),
									(43,	'Esophageal Cancer'),
									(44,	'Esthesioneuroblastoma (Head and Neck Cancer)'),
									(45,	'Ewing Sarcoma (Bone Cancer)'),
									(46,	'Extracranial Germ Cell Tumor, Childhood'),
									(47,	'Extragonadal Germ Cell Tumor'),
									(48,	'Eye Cancer | Intraocular Melanoma'),
									(49,	'Eye Cancer | Retinoblastoma'),
									(50,	'Fallopian Tube Cancer'),
									(51,	'Fibrous Histiocytoma of Bone, Malignant, and Osteosarcoma'),
									(52,	'Gallbladder Cancer'),
									(53,	'Gastric (Stomach) Cancer'),
									(54,	'Gastrointestinal Carcinoid Tumor'),
									(55,	'Gastrointestinal Stromal Tumors (GIST) (Soft Tissue Sarcoma)'),
									(56,	'Germ Cell Tumors | Childhood Central Nervous System Germ Cell Tumors (Brain Cancer)'),
									(57,	'Germ Cell Tumors | Childhood Extracranial Germ Cell Tumors'),
									(58,	'Germ Cell Tumors | Extragonadal Germ Cell Tumors'),
									(59,	'Germ Cell Tumors | Ovarian Germ Cell Tumors'),
									(60,	'Germ Cell Tumors | Testicular Cancer'),
									(61,	'Gestational Trophoblastic Disease'),
									(62,	'Hairy Cell Leukemia'),
									(63,	'Head and Neck Cancer'),
									(64,	'Heart Tumors, Childhood'),
									(65,	'Hepatocellular (Liver) Cancer'),
									(66,	'Histiocytosis, Langerhans Cell'),
									(67,	'Hodgkin Lymphoma'),
									(68,	'Hypopharyngeal Cancer (Head and Neck Cancer)'),
									(69,	'Intraocular Melanoma'),
									(70,	'Islet Cell Tumors, Pancreatic Neuroendocrine Tumors'),
									(71,	'Kaposi Sarcoma (Soft Tissue Sarcoma)'),
									(72,	'Kidney (Renal Cell) Cancer'),
									(73,	'Langerhans Cell Histiocytosis'),
									(74,	'Laryngeal Cancer (Head and Neck Cancer)'),
									(75,	'Leukemia'),
									(76,	'Lip and Oral Cavity Cancer (Head and Neck Cancer)'),
									(77,	'Liver Cancer'),
									(78,	'Lung Cancer (Non-Small Cell, Small Cell, Pleuropulmonary Blastoma, and Tracheobronchial Tumor)'),
									(79,	'Lymphoma'),
									(80,	'Male Breast Cancer'),
									(81,	'Malignant Fibrous Histiocytoma of Bone and Osteosarcoma'),
									(82,	'Melanoma'),
									(83,	'Melanoma, Intraocular (Eye)'),
									(84,	'Merkel Cell Carcinoma (Skin Cancer)'),
									(85,	'Mesothelioma, Malignant'),
									(86,	'Metastatic Cancer'),
									(87,	'Metastatic Squamous Neck Cancer with Occult Primary (Head and Neck Cancer)'),
									(88,	'Midline Tract Carcinoma With NUT Gene Changes'),
									(89,	'Mouth Cancer (Head and Neck Cancer)'),
									(90,	'Multiple Endocrine Neoplasia Syndromes'),
									(91,	'Multiple Myeloma/Plasma Cell Neoplasms'),
									(92,	'Mycosis Fungoides (Lymphoma)'),
									(93,	'Myelodysplastic Syndromes'),
									(94,	'Myelogenous Leukemia, Chronic (CML)'),
									(95,	'Myeloid Leukemia, Acute (AML)'),
									(96,	'Myelodysplastic/Myeloproliferative Neoplasms, Chronic'),
									(97,	'Nasal Cavity and Paranasal Sinus Cancer (Head and Neck Cancer)'),
									(98,	'Nasopharyngeal Cancer (Head and Neck Cancer)'),
									(99,	'Neuroblastoma'),
									(100,	'Non-Hodgkin Lymphoma'),
									(101,	'Non-Small Cell Lung Cancer'),
									(102,	'Oral Cancer, Lip and Oral Cavity Cancer and Oropharyngeal Cancer (Head and Neck Cancer)'),
									(103,	'Osteosarcoma and Malignant Fibrous Histiocytoma of Bone'),
									(104,	'Ovarian Cancer'),
									(105,	'Pancreatic Cancer'),
									(106,	'Pancreatic Neuroendocrine Tumors (Islet Cell Tumors)'),
									(107,	'Papillomatosis (Childhood Laryngeal)'),
									(108,	'Paraganglioma'),
									(109,	'Paranasal Sinus and Nasal Cavity Cancer (Head and Neck Cancer)'),
									(110,	'Parathyroid Cancer'),
									(111,	'Penile Cancer'),
									(112,	'Pharyngeal Cancer (Head and Neck Cancer)'),
									(113,	'Pheochromocytoma'),
									(114,	'Pituitary Tumor'),
									(115,	'Plasma Cell Neoplasm/Multiple Myeloma'),
									(116,	'Pleuropulmonary Blastoma (Lung Cancer)'),
									(117,	'Pregnancy and Breast Cancer'),
									(118,	'Primary Central Nervous System (CNS) Lymphoma'),
									(119,	'Primary Peritoneal Cancer'),
									(120,	'Prostate Cancer'),
									(121,	'Rectal Cancer'),
									(122,	'Recurrent Cancer'),
									(123,	'Renal Cell (Kidney) Cancer'),
									(124,	'Retinoblastoma'),
									(125,	'Rhabdomyosarcoma, Childhood (Soft Tissue Sarcoma)'),
									(126,	'Salivary Gland Cancer (Head and Neck Cancer)'),
									(127,	'Sarcoma | Childhood Rhabdomyosarcoma (Soft Tissue Sarcoma)'),
									(128,	'Sarcoma | Childhood Vascular Tumors (Soft Tissue Sarcoma)'),
									(129,	'Sarcoma | Ewing Sarcoma (Bone Cancer)'),
									(130,	'Sarcoma | Kaposi Sarcoma (Soft Tissue Sarcoma)'),
									(131,	'Sarcoma | Osteosarcoma (Bone Cancer)'),
									(132,	'Sarcoma | Soft Tissue Sarcoma'),
									(133,	'Sarcoma | Uterine Sarcoma'),
									(134,	'Sézary Syndrome (Lymphoma)'),
									(135,	'Skin Cancer'),
									(136,	'Small Cell Lung Cancer'),
									(137,	'Small Intestine Cancer'),
									(138,	'Soft Tissue Sarcoma'),
									(139,	'Squamous Cell Carcinoma of the Skin'),
									(140,	'Squamous Neck Cancer with Occult Primary, Metastatic (Head and Neck Cancer)'),
									(141,	'Stomach (Gastric) Cancer'),
									(142,	'T-Cell Lymphoma, Cutaneous - see Lymphoma (Mycosis Fungoides and Sèzary Syndrome)'),
									(143,	'Testicular Cancer'),
									(144,	'Throat Cancer (Head and Neck Cancer)'),
									(145,	'Nasopharyngeal Cancer'),
									(146,	'Oropharyngeal Cancer'),
									(147,	'Hypopharyngeal Cancer'),
									(148,	'Thymoma and Thymic Carcinoma'),
									(149,	'Thyroid Cancer'),
									(150,	'Tracheobronchial Tumors (Lung Cancer)'),
									(151,	'Transitional Cell Cancer of the Renal Pelvis and Ureter (Kidney (Renal Cell) Cancer)'),
									(152,	'Unusual Cancers of Childhood'),
									(153,	'Ureter and Renal Pelvis, Transitional Cell Cancer (Kidney (Renal Cell) Cancer)'),
									(154,	'Urethral Cancer'),
									(155,	'Uterine Cancer, Endometrial'),
									(156,	'Uterine Sarcoma'),
									(157,	'Vaginal Cancer'),
									(158,	'Vascular Tumors (Soft Tissue Sarcoma)'),
									(159,	'Vulvar Cancer'),
									(160,	'Wilms Tumor and Other Childhood Kidney Tumors');
	
	--project."ProjectTimeUnit"
	INSERT INTO project."ProjectTimeUnit"("ID", "Value") VALUES 
										(1, 'Day'),
										(2, 'Week'),
										(3, 'Month'),
										(4, 'Year');
	
	--project."Currency"
	INSERT INTO project."Currency"("ID", "Value") VALUES 
								(1, 'USD');
		
	--project."Endpoint"
	INSERT INTO project."Endpoint"("ID", "Name", "Type") VALUES 
				(1, 'Overall Survival', 'Time to Event'),
				(2, 'Progression-Free Survival', 'Time to Event'),
				(3, 'Custom', 'Time to Event');

	--project."PopulationModel"
	INSERT INTO project."PopulationModel"("ID", "Value") VALUES 
				(1, 'Exponential');

	--project."PopulationInputMethod"
	INSERT INTO project."PopulationInputMethod"("ID", "Value") VALUES 
				(1, 'Median Event Time');

	--project."DropoutModel"
	INSERT INTO project."DropoutModel"("ID", "Value") VALUES 
				(1, 'Exponential');

	--project."DropoutInputMethod"
	INSERT INTO project."DropoutInputMethod"("ID", "Value") VALUES 
				(1, 'Probability of Dropout');

	--project."Geography"
	INSERT INTO project."Geography"("ID", "Value") VALUES 
				(1, 'USA'),
				(2, 'UK'),
				(3, 'Mexico'),
				(4, 'Brazil'),
				(5, 'China'),
				(6, 'India');

	--project."EnrollmentInputMethod"
	INSERT INTO project."EnrollmentInputMethod"("ID", "Value") VALUES 
				(1, 'Accrual Rate');

	--project."Distribution"
	INSERT INTO project."Distribution"("ID", "Value") VALUES 
				(1, 'Uniform');

	--project."StatisticalEngine"
	INSERT INTO project."StatisticalEngine"
                (
					"ID", 
					"Name", 
					"Schema",
					"Template",
					"UiSchema",
					"DefaultFormData",
					"Help", 
					"Location", 
					"Version", 
					"ReleaseDate"
				)
	 VALUES 
				(
					1, 
				    'Fixed Sample',
					'{"type":"object","properties":{"name":{"type":"string","title":"Name","maxLength":75},"primaryEndpoint":{"type":"string","title":"Primary Endpoint","enum":[],"enumNames":[]},"arms":{"type":"string","title":"Arms","default":"2-arms"},"statisticalDesign":{"type":"integer","title":"Statistical Design","enum":[],"enumNames":[]},"hypothesis":{"type":"integer","title":"Hypothesis","enum":[1,2],"enumNames":["Superiority","Non-Inferiority"]},"numberOfEvents":{"type":"string","title":"Number of Events","default":"88"},"sampleSize":{"type":"string","title":"Sample Size","default":"182"},"allocationRatio":{"type":"string","title":"Allocation Ratio","default":"1"},"subjectsAreFollowed":{"type":"integer","title":"Subjects are Followed","enum":[1,2],"enumNames":["Until End of Study","For Fixed Period"]},"type1Error":{"type":"string","title":"Type 1 Error","default":"0.025"},"testStatistics":{"title":"Test Statistics","type":"string","default":"Logrank"},"testType":{"title":"Test Type","type":"string","default":"1-sided"},"tailType":{"title":"Tail Type","type":"integer","enum":[1,2],"enumNames":["Left Tail","Right Tail"]},"criticalPoint":{"title":"Critical Point","type":"string"}},"required":["name","primaryEndpoint","statisticalDesign","hypothesis","allocationRatio","subjectsAreFollowed","type1Error","tailType"]}',
					'{"designId":null,"designKey":"","name":"","endpointId":null,"numberOfArms":null,"regulatoryRiskAssessment":{"id":null,"value":""},"statisticalDesign":{"id":null,"value":"","version":""},"hypothesis":{"id":null,"value":""},"numberOfEvents":"","sampleSize":"","allocationRatio":"","subjectsAreFollowedType":{"id":null,"value":""},"subjectsAreFollowedPeriod":null,"type1Error":"","testStatistics":{"id":null,"value":""},"testType":{"id":null,"value":""},"tailType":{"id":null,"value":""},"criticalPoint":null,"error":[{"field":"","message":""}]}',
					'{"name":{"ui:placeholder":"Name","ui:autocomplete":"off"},"primaryEndpoint":{"ui:placeholder":"Primary Endpoint"},"arms":{"ui:placeholder":"Arms","ui:readonly":true},"numberOfEvents":{"ui:placeholder":"Number of Events","ui:autocomplete":"off"},"sampleSize":{"ui:placeholder":"Sample Size","ui:autocomplete":"off"},"allocationRatio":{"ui:placeholder":"Allocation Ratio","ui:autocomplete":"off"},"type1Error":{"ui:placeholder":"Type 1 Error","ui:autocomplete":"off"},"testStatistics":{"ui:placeholder":"Test Statistics","ui:readonly":true},"testType":{"ui:placeholder":"Test Type","ui:readonly":true},"criticalPoint":{"ui:placeholder":"Critical Point","ui:readonly":true}}',
					'{"name":"","primaryEndpoint":"","arms":"2-arms","statisticalDesign":1,"hypothesis":1,"numberOfEvents":"88","sampleSize":"182","allocationRatio":"1","subjectsAreFollowed":1,"type1Error":"0.025","testStatistics":"Logrank","testType":"1-sided","tailType":1,"criticalPoint":""}',
					null, 
					'//regstry.docker.com/cytel/',
	  				'1.0.0', 
					NOW()
				),
				(
				    2,
				   'Group Sequential',
				   '{"title":"Group Sequential","type":"object","properties":{"name":{"description":"Name","type":"string"},"primaryEndpoint":"Fixed Sample","Arms":{"description":"Arms","type":"integer"},"regulatoryRiskAssessment":{"description":"Regulatory Risk Assessment ","type":"string","options":[{"label":"Low","value":1},{"label":"Medium","value":2},{"label":"High","value":3}]},"statisticalDesign":{"description":"Statistical Design","type":"string","options":[{"label":"Fixed Sample","value":1},{"label":"Group Sequential","value":2},{"label":"Group Sequential SSR","value":3}]},"hypothesis":{"description":"Hypothesis","type":"string","options":[{"label":"Superiority","value":1},{"label":"Non-Inferiority","value":2}]},"numberOfEvents":{"description":"Number Of Events","type":"integer"},"eventCalculator":{"type1Error":0.025,"power":0.9,"hazardRatio":0.5,"allocationRatio":3.5},"sampleSize":{"description":"Sample Size","type":"integer"},"allocationRatio":{"description":"Allocation Ratio","type":"integer"},"subjectsAreFollowedType":{"description":"Subjects Are Followed","type":"string","options":[{"label":"Until End Of Study","value":1},{"label":"Fixed Period","value":2}]},"subjectsAreFollowedPeriod":{"description":"Period","type":"integer"},"type1Error":{"description":"Type 1 Error","type":"integer"},"testStatistics":{"description":"Test Statistics","type":"string","options":[{"label":"Logrank","value":1}]},"testType":{"description":"Test Type","type":"string","options":[{"label":"1-Sided","value":1}]},"tailType":{"description":"Tail Type","type":"string","options":[{"label":"Left Tail","value":1},{"label":"Right Tail","value":2}]},"nonInferiorityMargin":{"description":"Non-Inferiority Margin","type":"integer"},"numberOfInterimAnalysis":{"description":"Number of Interim Analysis","type":"integer"},"interimAnalysesSpacing":{"description":"Interim Analyses Spacing (%)","type":"integer"},"efficacy":{"boundaryFamily":{"description":"Boundary Family","type":"string","options":[{"label":"Spending Functions","value":1}]},"spendingFunction":{"description":"Spending Function","type":"string","options":[{"label":"Lan-DeMets","value":1},{"label":"Gamma Family","value":2}]},"parameter_Lan-DeMets":{"description":"Parameter","type":"string","options":[{"label":"OF","value":1},{"label":"PK","value":2}]},"parameter_Gamma Family":{"description":"Parameter","type":"integer"},"type1Error":{"description":"Type 1 Error","type":"integer"},"boundaryScale":{"boundaryFamily":{"description":"Boundary Scale","type":"string","options":[{"label":"Z Scale","value":1}]}}},"required":["name","primaryEndpoint"]}}',
				   '{"designId":null,"designKey":"","name":"","endpointId":null,"numberOfArms":null,"regulatoryRiskAssessment":{"id":null,"value":""},"statisticalDesign":{"id":null,"value":"","version":""},"hypothesis":{"id":null,"value":""},"numberOfEvents":"","sampleSize":"","allocationRatio":"","subjectsAreFollowedType":{"id":null,"value":""},"subjectsAreFollowedPeriod":null,"type1Error":"","testStatistics":{"id":null,"value":""},"testType":{"id":null,"value":""},"tailType":{"id":null,"value":""},"nonInferiorityMargin":null,"numberOfInterimAnalysis":null,"interimAnalysesSpacing":[null],"efficacy":{"boundaries":[null],"boundaryFamily":{"id":null,"value":""},"spendingFunction":{"id":null,"value":""},"parameter":"","boundaryScale":{"id":null,"value":""}},"error":[{"field":"","message":""}]}',
				    null,
					null,
					null,
					'',
					'1.0.0',
					NOW()
				),
				(
				   3,
				   'Group Sequential SSR',
				   '{"title":"Group Sequential SSR ","type":"object","properties":{"name":{"description":"Name","type":"string"},"primaryEndpoint":"Fixed Sample","Arms":{"description":"Arms","type":"integer"},"regulatoryRiskAssessment":{"description":"Regulatory Risk Assessment ","type":"string","options":[{"label":"Low","value":1},{"label":"Medium","value":2},{"label":"High","value":3}]},"statisticalDesign":{"description":"Statistical Design","type":"string","options":[{"label":"Fixed Sample","value":1},{"label":"Group Sequential","value":2},{"label":"Group Sequential SSR","value":3}]},"hypothesis":{"description":"Hypothesis","type":"string","options":[{"label":"Superiority","value":1},{"label":"Non-Inferiority","value":2}]},"numberOfEvents":{"description":"Number Of Events","type":"integer"},"eventCalculator":{"type1Error":0.025,"power":0.9,"hazardRatio":0.5,"allocationRatio":3.5},"sampleSize":{"description":"Sample Size","type":"integer"},"allocationRatio":{"description":"Allocation Ratio","type":"integer"},"subjectsAreFollowedType":{"description":"Subjects Are Followed","type":"string","options":[{"label":"Until End Of Study","value":1},{"label":"Fixed Period","value":2}]},"subjectsAreFollowedPeriod":{"description":"Period","type":"integer"},"type1Error":{"description":"Type 1 Error","type":"integer"},"testStatistics":{"description":"Test Statistics","type":"string","options":[{"label":"Logrank","value":1}]},"testType":{"description":"Test Type","type":"string","options":[{"label":"1-Sided","value":1}]},"tailType":{"description":"Tail Type","type":"string","options":[{"label":"Left Tail","value":1},{"label":"Right Tail","value":2}]},"nonInferiorityMargin":{"description":"Non-Inferiority Margin","type":"integer"},"numberOfInterimAnalysis":{"description":"Number of Interim Analysis","type":"integer"},"interimAnalysesSpacing":{"description":"Interim Analyses Spacing (%)","type":"integer"},"efficacy":{"boundaryFamily":{"description":"Boundary Family","type":"string","options":[{"label":"Spending Functions","value":1}]},"spendingFunction":{"description":"Spending Function","type":"string","options":[{"label":"Lan-DeMets","value":1},{"label":"Gamma Family","value":2}]},"parameter_Lan-DeMets":{"description":"Parameter","type":"string","options":[{"label":"OF","value":1},{"label":"PK","value":2}]},"parameter_Gamma Family":{"description":"Parameter","type":"integer"},"type1Error":{"description":"Type 1 Error","type":"integer"},"boundaryScale":{"boundaryFamily":{"description":"Boundary Scale","type":"string","options":[{"label":"Z Scale","value":1}]}}},"ssr":{"adaptMethod":{"description":"Adaption Method","type":"string","options":[{"label":"CHW","value":1}]},"adaptAtLookNum":{"description":"Adapt at Interim Analysis","type":"integer"},"maxNumEventsIfAdapt":{"description":"Maximum Number of Events if Adapt","type":"integer"},"maxSampleSizeIfAdapt":{"description":"Maximum Sample Size if Adapt","type":"integer"},"upperLimitStudyDuration":{"description":"Upper Limit on Study Duration","type":"integer"},"targetCPforReEstimatingNumEvents":{"description":"Target CP for Re-Estimating Number of Events","type":"integer"},"promisingZoneScale":{"description":"Promising Zone Scale","type":"string","options":[{"label":"Conditional Power","value":1}]},"promisingZoneMinCondPow":{"description":"Promising Zone Minimum Conditional Power","type":"integer"},"promisingZoneMaxCondPow":{"description":"Promising Zone Maximum Conditional Power","type":"integer"},"condPowComputationBased":{"description":"Conditional Power Computation Based on","type":"string","options":[{"label":"Estimated HR","value":1}]},"accrualRateAfterAdapt":{"description":"Accrual Rate After Adaption","type":"string","options":[{"label":"No Change","value":1},{"label":"Use Fixed Accrual Rate","value":2}]},"fixedAccrualRateUsedAfterAdapt":{"description":"Fixed Accrual Rate Used After Adaptation","type":"integer"}},"required":["name","primaryEndpoint"]}}',
				   '{"designId":null,"designKey":"","name":"","endpointId":null,"numberOfArms":null,"regulatoryRiskAssessment":{"id":null,"value":""},"statisticalDesign":{"id":null,"value":"","version":""},"hypothesis":{"id":null,"value":""},"numberOfEvents":"","sampleSize":"","allocationRatio":"","subjectsAreFollowedType":{"id":null,"value":""},"subjectsAreFollowedPeriod":null,"type1Error":"","testStatistics":{"id":null,"value":""},"testType":{"id":null,"value":""},"tailType":{"id":null,"value":""},"nonInferiorityMargin":null,"numberOfInterimAnalysis":null,"interimAnalysesSpacing":[null],"efficacy":{"boundaries":[null],"boundaryFamily":{"id":null,"value":""},"spendingFunction":{"id":null,"value":""},"parameter":"","boundaryScale":{"id":null,"value":""}},"ssr":{"adaptMethod":{"id":null,"value":""},"adaptAtLookNum":null,"maxNumEventsIfAdapt":null,"maxSampleSizeIfAdapt":null,"upperLimitStudyDuration":null,"targetCPforReEstimatingNumEvents":null,"promisingZoneScale":{"id":null,"value":""},"promisingZoneMinCondPow":null,"promisingZoneMaxCondPow":null,"condPowComputationBased":{"id":null,"value":""},"accrualRateAfterAdapt":{"id":null,"value":""},"fixedAccrualRateUsedAfterAdapt":null},"error":[{"field":"","message":""}]}',
				    null,
					null,
					null,
					'',
					'1.0.0',
					NOW()
				);

	--project."InputAdvisorSchema"
	INSERT INTO project."InputAdvisorSchema"("Version", "Template", "ReleaseDate") VALUES 
				('1.0.0', '{"validated":true,"objective":{"populationName":"","treatmentArm":"","controlArm":"","endpoint":[{"id":1,"Name":"","Endpoint":"","Type":"","cardOrder":1,"error":[{"field":"","message":""}]}],"error":[{"field":"","message":""}]},"population":[{"populationId":1,"name":"","virtualPopulationSize":10000,"endpointModel":[{"endpointId":1,"model":{"id":1,"value":"Exponential"},"inputMethod":{"id":1,"value":"Median Event Times"},"numberOfPieces":1,"control":"20","treatment":"40","hazardRatio":"0.5","error":[{"field":"","message":""}]}],"dropoutRateModel":{"model":{"id":1,"value":"Exponential"},"inputMethod":{"id":1,"value":"Probability of Dropout"},"numberOfPieces":1,"byTime":1,"control":"0","treatment":"0","error":[{"field":"","message":""}]},"cardOrder":1,"error":[{"field":"","message":""}]}],"enrollment":[{"enrollmentId":1,"name":"","inputMethod":{"id":1,"value":"Accrual Rate"},"distribution":{"id":1,"value":"Uniform"},"sites":[{"geography":{"id":1,"value":"USA"},"siteInitiationTime":0,"avgPatientsEnrolled":8,"enrollmentCap":100,"order":1,"error":[{"field":"","message":""}]}],"cardOrder":1,"error":[{"field":"","message":""}]}],"operationalCost":[{"operationalCostID":null,"name":"","costPerPatient":null,"fixedCost":null,"interimLookCost":null,"cardOrder":1,"error":[{"field":"","message":""}]}],"marketAccess":[{"marketAccessId":1,"name":"","endpointId":null,"annualRevenueInPeakYear":null,"timeToPeakAnnualRevenue":null,"proportionOfResidualSales":null,"anticipatedTreatmentEffect":null,"timeToPatentExpiry":null,"discountRate":5,"cardOrder":1,"error":[{"field":"","message":""}]}],"design":[{}]}', NOW());
END;