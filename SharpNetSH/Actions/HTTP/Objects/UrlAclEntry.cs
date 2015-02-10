using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Ignite.SharpNetSH.HTTP
{
	public sealed class UrlAclEntry : IOutputObject, IMultiResponseProcessor
	{
		internal UrlAclEntry()
		{ }

		public String ReservedURL { get; private set; }
		public IList<User> Users { get; private set; }

		void IOutputObject.AddValue(string title, string value)
		{
			title = title.Trim();
			value = value.Trim();
			switch (title.ToLower())
			{
				case "reserved url": ReservedURL = value; break;
				default:
					throw new Exception("Invalid Raw UrlAcl Data. Title: " + title + ", Value: " + value);
			}
		}

		IEnumerable IMultiResponseProcessor.ProcessResponse(IEnumerable<string> responseLines, int exitCode)
		{
			var entries = new List<UrlAclEntry>();
			if (responseLines == null || responseLines.Contains("There were no cache entries corresponding to the provided URL")) return entries;

			var currentEntryRows = new List<string>();
			foreach (var line in responseLines.Skip(3))
			{
				if (String.IsNullOrWhiteSpace(line))
				{
					if (currentEntryRows.Count > 0)
					{
						var entry = new UrlAclEntry();
						entry.Users = new List<User>();
						entry.ProcessRawData(@":\s+", currentEntryRows.Take(1)); //Process the reserved URL

						// Now process the users
						var userRows = new List<List<string>>();
						var currentUserRows = new List<string>();
						foreach (var row in currentEntryRows.Skip(1))
						{
							if (row.TrimStart().StartsWith("user:", StringComparison.OrdinalIgnoreCase))
							{
								userRows.Add(currentUserRows);
								currentUserRows = new List<string>();
							}
							if (!String.IsNullOrWhiteSpace(row))
								currentUserRows.Add(row);
						}
						userRows.Add(currentUserRows);

						foreach (var userBlock in userRows.Where(x => x.Any()))
						{
							var user = new User();
							user.ProcessRawData(@":\s+", userBlock);
							entry.Users.Add(user);
						}

						entries.Add(entry);
					}
					currentEntryRows = new List<string>();
				}
				else
					currentEntryRows.Add(line);
			}

			return entries;
		}
	}
}