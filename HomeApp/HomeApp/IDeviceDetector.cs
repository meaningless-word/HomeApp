using System;
using System.Collections.Generic;
using System.Text;

namespace HomeApp
{
	/// <summary>
	/// Общий интерфейс для классов отдельных платформ
	/// </summary>
	public interface IDeviceDetector
	{
		/// <summary>
		/// Получение информации о платформе
		/// </summary>
		/// <returns></returns>
		string GetDevice();
	}
}
