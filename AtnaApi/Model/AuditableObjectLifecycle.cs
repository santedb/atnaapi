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

using System.Xml.Serialization;

namespace AtnaApi.Model
{
	/// <summary>
	/// Auditable object lifecycle
	/// </summary>
	public enum AuditableObjectLifecycle
	{
		[XmlEnum("")]
		NotSet = 0x00,

		[XmlEnum("1")]
		Creation = 0x01,

		[XmlEnum("2")]
		Import = 0x02,

		[XmlEnum("3")]
		Amendment = 0x03,

		[XmlEnum("4")]
		Verification = 0x04,

		[XmlEnum("5")]
		Translation = 0x05,

		[XmlEnum("6")]
		Access = 0x06,

		[XmlEnum("7")]
		Deidentification = 0x07,

		[XmlEnum("8")]
		Aggregation = 0x08,

		[XmlEnum("9")]
		Report = 0x09,

		[XmlEnum("10")]
		Export = 0x0a,

		[XmlEnum("11")]
		Disclosure = 0x0b,

		[XmlEnum("12")]
		ReceiptOfDisclosure = 0x0c,

		[XmlEnum("13")]
		Archiving = 0x0d,

		[XmlEnum("14")]
		LogicalDeletion = 0x0e,

		[XmlEnum("15")]
		PermanentErasure = 0x0f
	}
}