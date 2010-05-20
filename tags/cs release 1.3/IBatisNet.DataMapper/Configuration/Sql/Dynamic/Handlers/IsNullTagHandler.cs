
#region Apache Notice
/*****************************************************************************
 * $Header: $
 * $Revision: $
 * $Date: $
 * 
 * iBATIS.NET Data Mapper
 * Copyright (C) 2004 - Gilles Bayon
 *  
 * 
 * Licensed under the Apache License, Version 2.0 (the "License");
 * you may not use this file except in compliance with the License.
 * You may obtain a copy of the License at
 * 
 *      http://www.apache.org/licenses/LICENSE-2.0
 * 
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an "AS IS" BASIS,
 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 * See the License for the specific language governing permissions and
 * limitations under the License.
 * 
 ********************************************************************************/
#endregion

using System;

using IBatisNet.DataMapper.Configuration.Sql.Dynamic.Elements;
using IBatisNet.Common.Utilities.Objects;

namespace IBatisNet.DataMapper.Configuration.Sql.Dynamic.Handlers
{
	/// <summary>
	/// Summary description for IsNullTagHandler.
	/// </summary>
	public class IsNullTagHandler : ConditionalTagHandler
	{
		/// <summary>
		/// 
		/// </summary>
		/// <param name="ctx"></param>
		/// <param name="tag"></param>
		/// <param name="parameterObject"></param>
		/// <returns></returns>
		public override bool IsCondition(SqlTagContext ctx, SqlTag tag, object parameterObject)
		{
			if (parameterObject == null) 
			{
				return true;
			} 
			else 
			{
				string propertyName = ((BaseTag)tag).Property;
				object value;
				if (propertyName != null && propertyName.Length>0 ) 
				{
					value = ObjectProbe.GetPropertyValue(parameterObject, propertyName);
				} 
				else 
				{
					value = parameterObject;
				}
				return (value == null);
			}		
		}
	}
}
