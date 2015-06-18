$path = Resolve-Path ".\VersionOne.ServiceHost\bin\Release\VersionOne.ServiceHost.exe.config"

function Clean-ConfigFile {
	$xml = [xml](Get-Content $path)

	## LogService
	$xml.configuration.Services.LogService.Console.LogLevel = "Info"
	$xml.configuration.Services.LogService.File.LogLevel = "Info"
    
    ## ProfileFlushTimer
	$xml.configuration.Services.ProfileFlushTimer.Interval = "30000"

	## JiraService
	$xml.configuration.Services.JiraService.JIRAUrl = "http://hostname:port/rest/api/latest"
    $xml.configuration.Services.JiraService.JIRAUserName = "username"
    $xml.configuration.Services.JiraService.JIRAPassword = "password"
    $xml.configuration.Services.JiraService.CreateDefectFilter.id = ""
    $xml.configuration.Services.JiraService.CreateStoryFilter.id = ""
    $xml.configuration.Services.JiraService.CreateFieldId = ""
    $xml.configuration.Services.JiraService.CreateFieldValue = ""
    $xml.configuration.Services.JiraService.CloseFieldId = ""
    $xml.configuration.Services.JiraService.CloseFieldValue = ""
    $xml.configuration.Services.JiraService.ProgressWorkflow = ""
    $xml.configuration.Services.JiraService.ProgressWorkflowClosed = ""
    $xml.configuration.Services.JiraService.AssigneeStateChanged = ""
    $xml.configuration.Services.JiraService.JIRAIssueUrlTemplate = "http://hostname:port/browse/#key#"
    $xml.configuration.Services.JiraService.ProjectMappings.Mapping | % { $xml.configuration.Services.JiraService.ProjectMappings.RemoveChild($_) }
    $xml.configuration.Services.JiraService.PriorityMappings.Mapping | % { $xml.configuration.Services.JiraService.PriorityMappings.RemoveChild($_) }

    ## JiraServiceTimer
    $xml.configuration.Services.JiraServiceTimer.Interval = "60000"

	## WorkitemWriterService
	$xml.configuration.Services.WorkitemWriterService.Settings.ApplicationUrl = "http://server/instance"
	$xml.configuration.Services.WorkitemWriterService.Settings.AccessToken = "accessToken"
	$xml.configuration.Services.WorkitemWriterService.Settings.Username = "username"
	$xml.configuration.Services.WorkitemWriterService.Settings.Password = "password"
	$xml.configuration.Services.WorkitemWriterService.Settings.ProxySettings.Url = "http://proxyhost"
	$xml.configuration.Services.WorkitemWriterService.Settings.ProxySettings.UserName = "username"
	$xml.configuration.Services.WorkitemWriterService.Settings.ProxySettings.Password = "password"
    $xml.configuration.Services.WorkitemWriterService.Settings.ProxySettings.Domain = "domain"

	$xml.Save($path);
}

Clean-ConfigFile