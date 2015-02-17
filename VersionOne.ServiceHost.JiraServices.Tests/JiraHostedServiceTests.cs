//using System;
//using System.Collections.Generic;
//using System.Xml;
//using Microsoft.VisualStudio.TestTools.UnitTesting;
//using Rhino.Mocks;
//using VersionOne.Profile;
//using VersionOne.ServiceHost.Core.Eventing;
//using VersionOne.ServiceHost.Core.Logging;
//using VersionOne.ServiceHost.Eventing;
//using VersionOne.ServiceHost.JiraServices;
//using VersionOne.ServiceHost.WorkitemServices;

//namespace VersionOne.ServiceHost.Tests.WorkitemServices.Jira
//{

//    [TestClass]
//    public class JiraHostedServiceTester : BaseWorkitemTester
//    {

//        private const string ConfigurationXml = @"
//        <JiraService disabled=""0"" class=""VersionOne.ServiceHost.JiraServices.JiraHostedService, VersionOne.ServiceHost.JiraServices"" >
//			<JIRAUrl>http://integsrv01:8083/rpc/soap/jirasoapservice-v2</JIRAUrl>
//			<JIRAUserName>remote</JIRAUserName>
//			<JIRAPassword>remote</JIRAPassword>
//            <CreateDefectFilter disabled=""0"" id=""10000""/>	
//            <CreateStoryFilter disabled=""0"" id=""10001""/>	
//			<CreateFieldValue>Open</CreateFieldValue>				
//			<CloseFieldId>customfield_10001</CloseFieldId>			
//			<CloseFieldValue>Closed</CloseFieldValue>				
//			<ProgressWorkflow>4</ProgressWorkflow>					
//			<ProgressWorkflowClosed>5</ProgressWorkflowClosed>		
//			<AssigneeStateChanged>-1</AssigneeStateChanged>			
//			<JIRAIssueUrlTemplate>http://localhost:8080/browse/#key#</JIRAIssueUrlTemplate>
//			<JIRAIssueUrlTitle>JIRA</JIRAIssueUrlTitle>
//            <SourceFieldValue>JIRA</SourceFieldValue>
//			<WorkitemLinkFieldId></WorkitemLinkFieldId>			
//			<ProjectMappings></ProjectMappings>
//            <PriorityMappings></PriorityMappings>
//		</JiraService>";

//        private IJiraIssueProcessor issueProcessorMock;
//        private IEventManager eventManager;
//        private IProfile profileMock;

//        public override void SetUp()
//        {
//            base.SetUp();

//            issueProcessorMock = Repository.StrictMock<IJiraIssueProcessor>();
//            eventManager = new EventManager();
//            profileMock = Repository.Stub<IProfile>();

//            MockingContainer.Bind<ILogger>().ToConstant(LoggerMock).When(x => true);
//            MockingContainer.Bind<IJiraIssueProcessor>().ToConstant(issueProcessorMock).When(x => true);
//            MockingContainer.Bind<IEventManager>().ToConstant(eventManager).When(x => true);
//        }

//        [TestMethod]
//        public void OnIntervalFailure()
//        {
//            var service = new JiraHostedService();
//            service.Initialize(GetConfigElement(), eventManager, profileMock);
//            service.RegisterComponents(MockingContainer);
//            service.Start();

//            eventManager.Subscribe(typeof(Story), x => Assert.Fail("Should not be called"));
//            eventManager.Subscribe(typeof(Defect), x => Assert.Fail("Should not be called"));

//            Expect.Call(issueProcessorMock.GetIssues<Defect>("10000")).Throw(new InvalidOperationException("Something went wrong"));
//            Expect.Call(issueProcessorMock.GetIssues<Story>("10001")).Repeat.Never();

//            Repository.ReplayAll();
//            eventManager.Publish(new JiraHostedService.IntervalSync());
//            Repository.VerifyAll();
//        }

//        [TestMethod]
//        public void OnIntervalPublishStory()
//        {
//            var story = new Story
//            {
//                ExternalId = "VERSIONONE-11",
//                ExternalLink = new UrlToExternalSystem("http://example.com", "Link"),
//                Number = "B-01058",
//            };

//            var service = new JiraHostedService();
//            service.Initialize(GetConfigElement(), eventManager, profileMock);
//            service.RegisterComponents(MockingContainer);
//            service.Start();

//            eventManager.Subscribe(typeof(Story), x =>
//            {
//                var receivedStory = (Story)x;
//                Assert.AreEqual(story.ExternalId, receivedStory.ExternalId);
//            });
//            eventManager.Subscribe(typeof(Defect), x => Assert.Fail("Should not be called"));

//            Expect.Call(issueProcessorMock.GetIssues<Defect>("10000")).Return(new List<Workitem>());
//            Expect.Call(issueProcessorMock.GetIssues<Story>("10001")).Return(new List<Workitem> { story });

//            Repository.ReplayAll();
//            eventManager.Publish(new JiraHostedService.IntervalSync());
//            Repository.VerifyAll();
//        }

//        [TestMethod]
//        public void OnIntervalPublishDefect()
//        {
//            var defect = new Defect
//            {
//                ExternalId = "VERSIONONE-11",
//                ExternalLink = new UrlToExternalSystem("http://example.com", "Link"),
//                Number = "D-01059",
//            };

//            var service = new JiraHostedService();
//            service.Initialize(GetConfigElement(), eventManager, profileMock);
//            service.RegisterComponents(MockingContainer);
//            service.Start();

//            eventManager.Subscribe(typeof(Defect), x =>
//            {
//                var receivedStory = (Defect)x;
//                Assert.AreEqual(defect.ExternalId, receivedStory.ExternalId);
//            });
//            eventManager.Subscribe(typeof(Story), x => Assert.Fail("Should not be called"));

//            Expect.Call(issueProcessorMock.GetIssues<Defect>("10000")).Return(new List<Workitem> { defect });
//            Expect.Call(issueProcessorMock.GetIssues<Story>("10001")).Return(new List<Workitem>());

//            Repository.ReplayAll();
//            eventManager.Publish(new JiraHostedService.IntervalSync());
//            Repository.VerifyAll();
//        }

//        [TestMethod]
//        public void WorkitemCreated()
//        {
//            var createdDefect = new Defect
//            {
//                ExternalId = "VERSIONONE-11",
//                ExternalLink = new UrlToExternalSystem("http://example.com", "Link"),
//                Number = "D-01059",
//            };
//            var creationResult = new WorkitemCreationResult(createdDefect);

//            var service = new JiraHostedService();
//            service.Initialize(GetConfigElement(), eventManager, profileMock);
//            service.RegisterComponents(MockingContainer);
//            service.Start();

//            Expect.Call(() => issueProcessorMock.OnWorkitemCreated(creationResult));

//            Repository.ReplayAll();
//            eventManager.Publish(creationResult);
//            Repository.VerifyAll();
//        }

//        [TestMethod]
//        public void WorkitemStateChanged()
//        {
//            var stateChangeCollection = new WorkitemStateChangeCollection {
//                new WorkitemStateChangeResult("VERSIONONE-10", "B-01001"),
//                new WorkitemStateChangeResult("VERSIONONE-11", "D-01002"),
//            };

//            var service = new JiraHostedService();
//            service.Initialize(GetConfigElement(), eventManager, profileMock);
//            service.RegisterComponents(MockingContainer);
//            service.Start();

//            Expect.Call(issueProcessorMock.OnWorkitemStateChanged(null)).IgnoreArguments().Return(true).Repeat.Twice();

//            Repository.ReplayAll();
//            eventManager.Publish(stateChangeCollection);
//            Repository.VerifyAll();
//        }

//        private XmlElement GetConfigElement()
//        {
//            var doc = new XmlDocument();
//            doc.LoadXml(ConfigurationXml);
//            return doc.DocumentElement;
//        }
//    }
//}