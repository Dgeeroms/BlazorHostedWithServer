using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Shared.Products
{
	public static class ProductDto
	{
		public class Index
		{
			public int Id { get; set; }
			public string Name { get; set; }
			public decimal Price { get; set; }
		}

		public class Detail : Index
		{
			public string Description { get; set; }
			public string Image { get; set; }	
		}
	}
}
