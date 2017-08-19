using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Net;
using Newtonsoft.Json.Linq;
using RestSharp;
using RestSharp.Authenticators;
using VersionOne.JiraConnector.Exceptions;

namespace VersionOne.JiraConnector.Rest
{
	public class JiraRestProxy : IJiraConnector
	{
		private readonly RestClient client;

		private readonly string currentUser;

		public JiraRestProxy(string baseUrl)
			: this(baseUrl, string.Empty, string.Empty)
		{
		}

		public JiraRestProxy(string baseUrl, string username, string password)
		{
			client = new RestClient(baseUrl);

			if (!string.IsNullOrEmpty(username) && !string.IsNullOrEmpty(password))
			{
				client.Authenticator = new HttpBasicAuthenticator(username, password);
			}

			currentUser = username;
		}

		public bool Validate()
		{
			var request = new RestRequest
			{
				Method = Method.GET,
				Resource = "user",
				RequestFormat = DataFormat.Json
			};
			request.AddQueryParameter("username", currentUser);

			var response = client.Execute(request);

			return response.StatusCode.Equals(HttpStatusCode.OK);
		}

		public void Login()
		{
			//throw new NotImplementedException();
		}

		public void Logout()
		{
			//throw new NotImplementedException();
		}

		private class GetResult<T>
		{
			public GetResult(T[] items, int totalAvailable)
			{
				Items = items;
				TotalAvailable = totalAvailable;
			}
			public T[] Items { get; private set; }
			public int TotalAvailable { get; private set; }
		}

		private GetResult<Issue> GetIssuesFromFilterByPage(string issueFilterId,
			int pageSize = 10, int startAt = 0)
		{
			var request = new RestRequest
			{
				Method = Method.GET,
				Resource = "search",
				RequestFormat = DataFormat.Json
			};
			request.AddQueryParameter("jql", $"filter={issueFilterId}");
			request.AddQueryParameter("maxResults", pageSize.ToString());
			request.AddQueryParameter("startAt", startAt.ToString());

			var response = client.Execute(request);

			if (response.StatusCode.Equals(HttpStatusCode.OK))
			{
				dynamic data = JObject.Parse(response.Content);
				var total = (int)data.total;
				var results = ((JArray)data.issues).Select(CreateIssue);
				var result = new GetResult<Issue>(results.ToArray(), total);
				return result;
			}

			if (response.StatusCode.Equals(HttpStatusCode.Unauthorized))
				throw new JiraLoginException();
			throw new JiraException(response.StatusDescription, new Exception(response.Content));
		}

		public Issue[] GetIssuesFromFilter(string issueFilterId)
		{
			const int pageSize = 10;
			var issues = new List<Issue>();

			var firstResult = GetIssuesFromFilterByPage(issueFilterId, pageSize);
			issues.AddRange(firstResult.Items);
			if (firstResult.TotalAvailable <= pageSize) return issues.ToArray();

			var timesToRepeat = CalculateTimesToRepeat(firstResult, pageSize);

			for (var i = 1; i <= timesToRepeat; i++)
			{
				var startAt = i * pageSize;
				var result = GetIssuesFromFilterByPage(issueFilterId, pageSize, startAt);
				issues.AddRange(result.Items);
			}

			return issues.ToArray();
		}

		private static int CalculateTimesToRepeat(GetResult<Issue> firstResult, int pageSize)
		{
			var remainingItems = firstResult.TotalAvailable - pageSize;
			var timesToRepeat = remainingItems / pageSize;
			var remainder = remainingItems % pageSize;
			if (remainder > 0) timesToRepeat++;
			return timesToRepeat;
		}

		public Issue UpdateIssue(string issueKey, string fieldName, string fieldValue)
		{
			dynamic editMetadata = GetEditMetadata(issueKey);
			dynamic fieldMeta = editMetadata.fields[fieldName];

			if (fieldMeta == null)
				throw new JiraException("Field metadata is missing", null);

			var type = fieldMeta.schema["type"];
			if (type == null)
				throw new JiraException("Field metadata is missing a type", null);

			var request = new RestRequest
			{
				Method = Method.PUT,
				Resource = "issue/{issueIdOrKey}",
				RequestFormat = DataFormat.Json,
			};
			request.AddUrlSegment("issueIdOrKey", issueKey);

			dynamic body;
			if (type.ToString().Equals("array"))
			{
				var custom = fieldMeta.schema["custom"];

				if (custom != null && (custom.ToString().Equals("com.atlassian.jira.plugin.system.customfieldtypes:multiselect")))
				{
					dynamic operation = new ExpandoObject();
					((IDictionary<string, object>)operation).Add(fieldName, new List<dynamic>
					{
						new
						{
							set = new List<object> { new { value = fieldValue} }
						}
					});
					body = new { update = operation };
				}
				else
				{
					dynamic operation = new ExpandoObject();
					((IDictionary<string, object>)operation).Add(fieldName, new List<dynamic>
					{
						new
						{
							set = new List<string> { fieldValue }
						}
					});
					body = new { update = operation };
				}
			}
			else
			{
				dynamic field = new ExpandoObject();
				((IDictionary<string, object>)field).Add(fieldName, fieldValue);
				body = new { fields = field };
			}
			request.AddBody(body);

			var response = client.Execute(request);

			if (response.StatusCode.Equals(HttpStatusCode.NoContent))
				return GetIssue(issueKey);
			if (response.StatusCode.Equals(HttpStatusCode.Unauthorized))
				throw new JiraLoginException();
			throw new JiraException(response.StatusDescription, new Exception(response.Content));
		}

		public IList<Item> GetPriorities()
		{
			var request = new RestRequest
			{
				Method = Method.GET,
				Resource = "priority",
				RequestFormat = DataFormat.Json
			};

			var response = client.Execute(request);

			if (response.StatusCode.Equals(HttpStatusCode.OK))
			{
				var data = JArray.Parse(response.Content);
				return data.Select(i => new Item(i["id"].Value<string>(), i["name"].Value<string>())).ToList();
			}
			if (response.StatusCode.Equals(HttpStatusCode.Unauthorized))
				throw new JiraLoginException();
			throw new JiraException(response.StatusDescription, new Exception(response.Content));
		}

		public IList<Item> GetProjects()
		{
			var request = new RestRequest
			{
				Method = Method.GET,
				Resource = "project",
				RequestFormat = DataFormat.Json
			};

			var response = client.Execute(request);

			if (response.StatusCode.Equals(HttpStatusCode.OK))
			{
				var data = JArray.Parse(response.Content);
				return data.Select(i => new Item(i["id"].Value<string>(), i["name"].Value<string>())).ToList();
			}
			if (response.StatusCode.Equals(HttpStatusCode.Unauthorized))
				throw new JiraLoginException();
			throw new JiraException(response.StatusDescription, new Exception(response.Content));
		}

		public void AddComment(string issueKey, string comment)
		{
			var request = new RestRequest
			{
				Method = Method.POST,
				Resource = "issue/{issueIdOrKey}/comment",
				RequestFormat = DataFormat.Json,
			};
			request.AddUrlSegment("issueIdOrKey", issueKey);

			request.AddBody(new { body = comment });

			var response = client.Execute(request);

			if (response.StatusCode.Equals(HttpStatusCode.Created))
				return;
			if (response.StatusCode.Equals(HttpStatusCode.Unauthorized))
				throw new JiraLoginException();
			throw new JiraException(response.StatusDescription, new Exception(response.Content));
		}

		public void ProgressWorkflow(string issueKey, string action, string assignee)
		{
			var request = new RestRequest
			{
				Method = Method.POST,
				Resource = "issue/{issueIdOrKey}/transitions",
				RequestFormat = DataFormat.Json,
			};
			request.AddUrlSegment("issueIdOrKey", issueKey);

			dynamic body = new ExpandoObject();
			((IDictionary<string, object>)body).Add("transition", new { id = action });
			if (assignee != null)
				((IDictionary<string, object>)body).Add("fields", new { assignee = new { name = assignee } });
			request.AddBody(body);

			var response = client.Execute(request);

			if (response.StatusCode.Equals(HttpStatusCode.NoContent))
				return;
			if (response.StatusCode.Equals(HttpStatusCode.Unauthorized))
				throw new JiraLoginException();
			throw new JiraException(response.StatusDescription, new Exception(response.Content));
		}

		public IEnumerable<Item> GetAvailableActions(string issueId)
		{
			var request = new RestRequest
			{
				Method = Method.GET,
				Resource = "issue/{issueIdOrKey}/transitions?expand=transitions.fields",
				RequestFormat = DataFormat.Json
			};
			request.AddUrlSegment("issueIdOrKey", issueId);

			var response = client.Execute(request);

			if (response.StatusCode.Equals(HttpStatusCode.OK))
			{
				dynamic data = JObject.Parse(response.Content);
				return ((JArray)data.transitions).Select(i => new Item(i["id"].Value<string>(), i["name"].Value<string>())).ToList();
			}
			if (response.StatusCode.Equals(HttpStatusCode.Unauthorized))
				throw new JiraLoginException();
			throw new JiraException(response.StatusDescription, new Exception(response.Content));
		}

		public IEnumerable<Item> GetCustomFields()
		{
			var request = new RestRequest
			{
				Method = Method.GET,
				Resource = "field",
				RequestFormat = DataFormat.Json
			};

			var response = client.Execute(request);

			if (response.StatusCode.Equals(HttpStatusCode.OK))
			{
				var data = JArray.Parse(response.Content);
				return data.Where(i => i["custom"].Value<bool>()).Select(i => new Item(i["id"].Value<string>(), i["name"].Value<string>())).ToList();
			}
			if (response.StatusCode.Equals(HttpStatusCode.Unauthorized))
				throw new JiraLoginException();
			throw new JiraException(response.StatusDescription, new Exception(response.Content));
		}

		private dynamic GetEditMetadata(string issueIdOrKey)
		{
			var request = new RestRequest
			{
				Method = Method.GET,
				Resource = "issue/{issueIdOrKey}/editmeta",
				RequestFormat = DataFormat.Json
			};
			request.AddUrlSegment("issueIdOrKey", issueIdOrKey);

			var response = client.Execute(request);

			if (response.StatusCode.Equals(HttpStatusCode.OK))
				return JObject.Parse(response.Content);
			if (response.StatusCode.Equals(HttpStatusCode.Unauthorized))
				throw new JiraLoginException();
			throw new JiraException(response.StatusDescription, new Exception(response.Content));
		}

		private Issue GetIssue(string issueIdOrKey)
		{
			var request = new RestRequest
			{
				Method = Method.GET,
				Resource = "issue/{issueIdOrKey}",
				RequestFormat = DataFormat.Json
			};
			request.AddUrlSegment("issueIdOrKey", issueIdOrKey);

			var response = client.Execute(request);

			if (response.StatusCode.Equals(HttpStatusCode.OK))
			{
				dynamic data = JObject.Parse(response.Content);
				return CreateIssue(data);
			}
			if (response.StatusCode.Equals(HttpStatusCode.Unauthorized))
				throw new JiraLoginException();
			throw new JiraException(response.StatusDescription, new Exception(response.Content));
		}

		private Issue CreateIssue(dynamic data)
		{
			return new Issue
			{
				Id = data.id,
				Key = data.key,
				Summary = data.fields.summary,
				Description = data.fields.description,
				Project = data.fields.project != null ? data.fields.project.name : string.Empty,
				IssueType = data.fields.issuetype != null ? data.fields.issuetype.name : string.Empty,
				Assignee = data.fields.assignee != null ? data.fields.assignee.name : string.Empty,
				Priority = data.fields.priority != null ? data.fields.priority.name : string.Empty
			};
		}
	}
}
