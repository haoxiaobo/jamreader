using System;
using Microsoft.Win32;
using Microsoft;

namespace JAMReader
{
	/// <summary>
	/// RegMan 的摘要说明。
	/// </summary>
	public class RegMan
	{
		private RegistryKey rk;
		public string sPath;

		public RegMan(string sCompany, string sProduct, string sVersion)
		{
			sPath = "SOFTWARE\\" + sCompany + "\\" + sProduct + "\\" + sVersion;
			this.rk = Registry.CurrentUser.OpenSubKey(sPath, true);
			if (rk == null)
			{
				rk = Registry.CurrentUser.CreateSubKey(sPath);
			}
		}
		~RegMan()
		{
			rk.Close();
		}
		public object this[string sKey]
		{
			get
			{
				object o = this.rk.GetValue(sKey);
				return o;
			}
			set
			{
				this.rk.SetValue(sKey, value);
			}
		}
	}
}
