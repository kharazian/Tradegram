namespace Hitasp.HitCommon.Extensions
{
	public static class FormattingExtensions
	{
		public static string ToHumanReadableSize(this long len)
		{
			string[] sizes = { "Bytes", "KB", "MB", "GB", "TB" };
			var order = 0;
			while (len >= 1024 && order + 1 < sizes.Length)
			{
				order++;
				len = len / 1024;
			}
			return $"{len:0.##} {sizes[order]}";
		}
	}
}
