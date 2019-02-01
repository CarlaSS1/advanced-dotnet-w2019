/*
 * Copyright 2016-2019 Mohawk College of Applied Arts and Technology
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
 * User: Nityan Khanna
 * Date: 2019-1-31
 */
using System;
using System.Collections.Generic;
using System.Text;

namespace Week5Attributes
{
	/// <summary>
	/// Represents a documentation attribute
	/// </summary>
	public class ActionDescriptionAttribute
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="ActionDescriptionAttribute"/> class.
		/// </summary>
		/// <param name="documentation">The documentation.</param>
		public ActionDescriptionAttribute(string documentation)
		{
			this.Documentation = documentation;
		}

		/// <summary>
		/// Gets or sets the documentation.
		/// </summary>
		/// <value>The documentation.</value>
		public string Documentation { get; set; }
	}
}
