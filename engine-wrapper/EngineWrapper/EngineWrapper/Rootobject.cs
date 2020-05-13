using System;
using System.Collections.Generic;
using System.Text;

namespace EngineWrapper
{
    public class Rootobject
    {
        public string entryPoint { get; set; }
        public float msgVersion { get; set; }
        public string msgType { get; set; }
        public int msgId { get; set; }
        public Target target { get; set; }
        public List<Computeinfo> computeInfo { get; set; }
        public Project project { get; set; }
        public Population population { get; set; }
        public Enrollment enrollment { get; set; }
        public Design design { get; set; }
        public Summaryresult summaryResult { get; set; }
    }

    public class Target
    {
        public string location { get; set; }
        public string name { get; set; }
        public int id { get; set; }
        public string version { get; set; }
    }

    public class Project
    {
        public string scenarioId { get; set; }
        public string projectName { get; set; }
        public string timeUnit { get; set; }
        public string controlArm { get; set; }
        public string treatmentArm { get; set; }
        public int numberOfSim { get; set; }
        public int simSeed { get; set; }
    }

    public class Population
    {
        public string populationId { get; set; }
        public string name { get; set; }
        public int virtualPopulationSize { get; set; }
        public Endpointmodel[] endpointModel { get; set; }
        public Dropoutratemodel dropoutRateModel { get; set; }
    }

    public class Dropoutratemodel
    {
        public string modelName { get; set; }
        public string inputMethod { get; set; }
        public Inputdata[] inputData { get; set; }
    }

    public class Inputdata
    {
        public int byTime { get; set; }
        public float control { get; set; }
        public float treatment { get; set; }
    }

    public class Endpointmodel
    {
        public string name { get; set; }
        public string endpoint { get; set; }
        public string type { get; set; }
        public string modelName { get; set; }
        public string inputMethod { get; set; }
        public Inputdata1[] inputData { get; set; }
    }

    public class Inputdata1
    {
        public float control { get; set; }
        public float treatment { get; set; }
        public float hazardRatio { get; set; }
    }

    public class Enrollment
    {
        public string enrollmentId { get; set; }
        public string name { get; set; }
        public string inputMethod { get; set; }
        public string distribution { get; set; }
        public int numOfSites { get; set; }
        public Site[] sites { get; set; }
    }

    public class Site
    {
        public string geography { get; set; }
        public int siteInititationTime { get; set; }
        public int avgPatientsEnrolled { get; set; }
        public float enrollmentCap { get; set; }
    }

    public class Design
    {
        public string name { get; set; }
        public string primaryEndpoint { get; set; }
        public int numberOfArms { get; set; }
        public string regulatoryRiskAssessment { get; set; }
        public string statisticalDesign { get; set; }
        public string hypothesis { get; set; }
        public float nonInfMargin { get; set; }
        public int numberOfEvents { get; set; }
        public int sampleSize { get; set; }
        public float allocationRatio { get; set; }
        public string subjectsAreFollowedType { get; set; }
        public int subjectsAreFollowedPeriod { get; set; }
        public float type1Error { get; set; }
        public string testStatistics { get; set; }
        public string testType { get; set; }
        public string tailType { get; set; }
        public int numberOfInterimAnalysis { get; set; }
        public int[] interimAnalysesSpacing { get; set; }
        public Efficacy efficacy { get; set; }
        public int flgAdapt { get; set; }
 
    }

    public class Efficacy
    {
        public float[] boundaries { get; set; }
        public string boundaryFamily { get; set; }
        public string spendingFunction { get; set; }
        public string parameter { get; set; }
        public string boundaryScale { get; set; }
    }


    public class Summaryresult
    {
        public float FollowUpTime { get; set; }
        public float accrualDuration { get; set; }
        public float dropouts { get; set; }
        public float events { get; set; }
        public int insuffInfoCount { get; set; }
        public Outputboundaries outputBoundaries { get; set; }
        public float power { get; set; }
        public float sampleSize { get; set; }
        public int simSeed { get; set; }
        public float studyDuration { get; set; }
        public float[] probOfSimsStoopedEachLk { get; set; }
    }

    public class Outputboundaries
    {
        public float[] effBoundary { get; set; }        
    }

    public class Computeinfo
    {
        public string stage { get; set; }
        public string receviedTime { get; set; }
        public string sentTime { get; set; }
        public int RAM { get; set; }
        public int cpuTime { get; set; }
        public float elapsedTime { get; set; }
    }
}

