//
//  This file was auto-generated using the ChilliConnect SDK Generator.
//
//  The MIT License (MIT)
//
//  Copyright (c) 2015 Tag Games Ltd
//
//  Permission is hereby granted, free of charge, to any person obtaining a copy
//  of this software and associated documentation files (the "Software"), to deal
//  in the Software without restriction, including without limitation the rights
//  to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
//  copies of the Software, and to permit persons to whom the Software is
//  furnished to do so, subject to the following conditions:
//
//  The above copyright notice and this permission notice shall be included in
//  all copies or substantial portions of the Software.
//
//  THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
//  IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
//  FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
//  AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
//  LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
//  OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
//  THE SOFTWARE.
//

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using SdkCore;

namespace ChilliConnect 
{
	/// <summary>
	/// <para>A mutable description of a VirtualPurchaseDefinition.</para>
	///
	/// <para>This is not thread-safe and should typically only be used to create new 
	/// instances of VirtualPurchaseDefinition.</para>
	/// </summary>
	public sealed class VirtualPurchaseDefinitionDesc
	{
		/// <summary>
		/// The key of the item.
		/// </summary>
        public string Key { get; set; }
	
		/// <summary>
		/// The name of the item.
		/// </summary>
        public string Name { get; set; }
	
		/// <summary>
		/// The tags of the item.
		/// </summary>
        public IList<string> Tags { get; set; }
	
		/// <summary>
		/// The custom data of the item.
		/// </summary>
        public MultiTypeValue CustomData { get; set; }
	
		/// <summary>
		/// Costs that are required to make a purchase.
		/// </summary>
        public PurchaseExchangeDefinition Costs { get; set; }
	
		/// <summary>
		/// Rewards that will be allocated upon purchase.
		/// </summary>
        public PurchaseExchangeDefinition Rewards { get; set; }

		/// <summary>
		/// Initialises a new instance with the given required properties.
		/// </summary>
		///
		/// <param name="key">The key of the item.</param>
		/// <param name="name">The name of the item.</param>
		/// <param name="tags">The tags of the item.</param>
		/// <param name="costs">Costs that are required to make a purchase.</param>
		/// <param name="rewards">Rewards that will be allocated upon purchase.</param>
		public VirtualPurchaseDefinitionDesc(string key, string name, IList<string> tags, PurchaseExchangeDefinition costs, PurchaseExchangeDefinition rewards)
		{
			ReleaseAssert.IsNotNull(key, "Key cannot be null.");
			ReleaseAssert.IsNotNull(name, "Name cannot be null.");
			ReleaseAssert.IsNotNull(tags, "Tags cannot be null.");
			ReleaseAssert.IsNotNull(costs, "Costs cannot be null.");
			ReleaseAssert.IsNotNull(rewards, "Rewards cannot be null.");
	
            Key = key;
            Name = name;
            Tags = Mutability.ToImmutable(tags);
            Costs = costs;
            Rewards = rewards;
		}
	}
}
