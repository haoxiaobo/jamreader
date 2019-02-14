using System;

namespace JAMReader
{
	/// <summary>
	/// 
	/// </summary>
	public struct CDateTime
	{
		private DateTime dtDateTime;
		public CDateTime(UInt32 uiTime)
		{
			long lt = (long)uiTime * 10000000;
			this.dtDateTime = new DateTime(lt);
			this.dtDateTime = this.dtDateTime.AddYears(1969);
		}

		public override string ToString()
		{
			return dtDateTime.ToString("yyyy-MM-dd HH:mm:ss");
		}
	}
}
