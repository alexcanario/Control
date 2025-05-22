namespace Dima.Core.Common;

public static class DateTimeExtensions
{
	public static DateTime GetFirstDay(this DateTime date) =>
		new DateTime(date.Year, date.Month, 1);

	public static DateTime GetLastDay(this DateTime date) =>
		new DateTime(date.Year, date.Month, DateTime.DaysInMonth(date.Year, date.Month), 23, 59, 59);
}