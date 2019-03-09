﻿/*
 * MEDIC ATNA API
 * Copyright 2014-2019 Mohawk College of Applied Arts and Technology.
 *
 * Licensed under the Apache License, Version 2.0 (the "License"); you
 * may not use this file except in compliance with the License. You may
 * obtain a copy of the License at
 *
 * http://www.apache.org/licenses/LICENSE-2.0
 *
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an "AS IS" BASIS, WITHOUT
 * WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied. See the
 * License for the specific language governing permissions and limitations under
 * the License.
 *
 * Author: Justin
 */

using System;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using AtnaApi.Model;

namespace AtnaApi.Transport
{
	/// <summary>
	/// Represents a file syslog transport.
	/// </summary>
	/// <seealso cref="AtnaApi.Transport.ITransporter" />
	[Description("BSD Syslog File Appender")]
	public class FileSyslogTransport : ITransporter
	{
		/// <summary>
		/// Gets or sets the endpoint (file) to be appended.
		/// </summary>
		/// <value>The end point.</value>
		public String EndPoint { get; set; }

		/// <summary>
		/// Gets or sets the message format.
		/// </summary>
		/// <value>The message format.</value>
		public MessageFormatType MessageFormat { get; set; }

		/// <summary>
		/// Sends the audit message to the file appender
		/// </summary>
		/// <param name="auditMessage">The audit message.</param>
		public void SendMessage(AuditMessage auditMessage)
		{
			var message = AuditTransportUtil.CreateMessageBodyEx(auditMessage, this.MessageFormat);

			// Rotates the logs each day
			var fileName = Path.Combine(Path.GetDirectoryName(this.EndPoint), $"{Path.GetFileNameWithoutExtension(this.EndPoint)}.{DateTime.Now:yyyyMMdd}.{Path.GetExtension(this.EndPoint)}");

			try
			{
				using (TextWriter textWriter = File.AppendText(fileName))
				{
					textWriter.WriteLine("{0:MMM dd HH:mm:ss} {1} {2}({3}): {4}", DateTime.Now, Environment.UserName, Process.GetCurrentProcess().ProcessName, Process.GetCurrentProcess().Id, message);
				}
			}
			catch (Exception e)
			{
				Trace.TraceError("Could not write audit to file {0}. Error was {1}.\r\nMessage:\r\n{2}", fileName, e, message);
			}
		}
	}
}