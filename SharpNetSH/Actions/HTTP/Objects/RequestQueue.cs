using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Ignite.SharpNetSH.HTTP
{
	public sealed class RequestQueue : IOutputObject, IMultiResponseProcessor
	{
		internal RequestQueue()
		{
		}

		public String RequestQueueName { get; private set; }
		public String Version { get; private set; }
		public String State { get; private set; } // TODO: Move this to an enumeration
		public String RequestQueue503VerbosityLevel { get; private set; } // TODO: Move this to an enumeration
		public long MaxRequests { get; private set; }
		public int NumberOfActiveProcessesAttached { get; private set; }
		public int ControllerProcessId { get; private set; }
		public IEnumerable<int> ProcessIds { get; private set; }
		public IList<UrlGroup> UrlGroups { get; private set; }


		void IOutputObject.AddValue(string title, string value)
		{
			title = title.Trim();
			value = value.Trim();
			switch (title.ToLower())
			{
				case "request queue name": RequestQueueName = value; break;
				case "version": Version = value; break;
				case "state": State = value; break;
				case "request queue 503 verbosity level": RequestQueue503VerbosityLevel = value; break;
				case "max requests": MaxRequests = long.Parse(value); break;
				case "number of active processes attached": NumberOfActiveProcessesAttached = int.Parse(value); break;
				case "controller process id": ControllerProcessId = int.Parse(value); break;
				default:
					throw new Exception("Invalid Raw Request Queue Data. Title: " + title + ", Value: " + value);
			}
		}

		IEnumerable IMultiResponseProcessor.ProcessResponse(IEnumerable<string> responseLines, int exitCode)
		{
			var requestQueues = new List<RequestQueue>();
			var currentBlock = new List<string>();
			var currentUrlGroupBlock = new List<string>();
			var urlBlocks = new List<UrlGroup>();
			var isInProcessIds = false;
			var isInUrlGroup = false;
			var processIds = new List<int>();
			foreach (var line in responseLines.Skip(3))
			{
				if (line.StartsWith("request queue name:", StringComparison.OrdinalIgnoreCase))
				{
					if (isInUrlGroup && currentUrlGroupBlock.Any()) // Only add if there is data to be added
					{
						IResponseProcessor urlGroup = new UrlGroup();
						urlGroup.ProcessResponse(currentUrlGroupBlock, 0);
						urlBlocks.Add((UrlGroup)urlGroup);
					}

					if (currentBlock.Any()) // Only add if there is data to be added
					{
						var queue = new RequestQueue();
						queue.ProcessRawData(@":\s+", currentBlock);
						queue.ProcessIds = processIds;
						foreach (var urlBlock in urlBlocks)
							urlBlock.RequestQueue = queue;
						queue.UrlGroups = urlBlocks;
						requestQueues.Add(queue);
					}

					currentBlock = new List<string>();
					currentUrlGroupBlock = new List<string>();
					urlBlocks = new List<UrlGroup>();
					processIds = new List<int>();
					isInProcessIds = false;
					isInUrlGroup = false;
				}

				if (line.TrimStart().StartsWith("process ids:", StringComparison.OrdinalIgnoreCase))
				{
					isInProcessIds = true;
					isInUrlGroup = false;
					continue;
				}

				if (line.TrimStart().StartsWith("url groups:", StringComparison.OrdinalIgnoreCase))
				{
					isInProcessIds = false;
					isInUrlGroup = true;
					continue;
				}

				if (line.TrimStart().StartsWith("url group id:", StringComparison.OrdinalIgnoreCase))
				{
					if (currentUrlGroupBlock.Any()) // Only add if there is data to be added
					{
						IResponseProcessor urlGroup = new UrlGroup();
						urlGroup.ProcessResponse(currentUrlGroupBlock, 0);
						urlBlocks.Add((UrlGroup)urlGroup);
					}

					currentUrlGroupBlock = new List<string>();
				}

				if (isInProcessIds)
				{
					processIds.Add(int.Parse(line.Trim()));
					continue;
				}

				if (isInUrlGroup)
				{
					if (!String.IsNullOrWhiteSpace(line))
						currentUrlGroupBlock.Add(line);
					continue;
				} 
				
				if (!String.IsNullOrWhiteSpace(line))
					currentBlock.Add(line);
			}

			return requestQueues;
		}
	}
}