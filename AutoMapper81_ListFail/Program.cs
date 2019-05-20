using AutoMapper;
using System;
using System.Collections.Generic;

namespace AutoMapper81_ListFail
{
	class Program
	{
		static void Main(string[] args)
		{
			var config = new MapperConfiguration(c =>
			{
				c.CreateMap<SourceClass, TargetClass>()
					.ForMember(x => x.Vals, o => o.MapFrom((srcCls, trgCls) =>
					{
						trgCls.Vals.Clear();
						trgCls.Vals.AddRange(srcCls.Vals);
						return trgCls.Vals;
					}));
			});

			config.AssertConfigurationIsValid();
			IMapper mapper = new Mapper(config);

			var src = new SourceClass();
			var trg = mapper.Map<TargetClass>(src);

			Console.WriteLine(string.Join('|', trg.Vals));
		}
	}


	class SourceClass
	{
		public SourceClass()
		{
			Vals = new List<int> { 1, 2, 3 };
		}

		public List<int> Vals { get; set; }
	}


	class TargetClass
	{
		private List<int> _vals = new List<int>();

		public List<int> Vals => _vals;
	}

}
